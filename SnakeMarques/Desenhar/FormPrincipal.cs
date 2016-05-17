using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace Desenhar
{
    public partial class frmPrincipal : Form
    {
        // http://oops4you.blogspot.pt/2011/05/flicker-free-controls-splitcontainer.html
        public frmPrincipal()
        {
            InitializeComponent();
            // http://www.dreamincode.net/forums/topic/69027-stop-controls-from-flashing/
            // http://www.progtown.com/topic1166958-form-blinking.html
            DoubleBuffered = true; // resulta?
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true); // ativar os 3 parametros... não resulta?
            LerScore();
        }

        private void SetCelula(int _linha, int _coluna, int imagem)
        {
            int coluna, linha;
            PictureBox x = new PictureBox();

            // percorre todos os controlos (Label) da TableLayoutPanel
            // Nota: enquanto que no ciclo "for" temos um contador do tipo inteiro, no ciclo "foreach"
            //       temos os elementos contidos numa coleção (neste caso o elemento é uma label e a coleção são 
            //       todas as labels contidas no TableLayoutPanel
            foreach (Control c in tlpDemo.Controls)
            {
                // Ler a posição do controlo
                coluna = tlpDemo.GetColumn(c);
                linha = tlpDemo.GetRow(c);


                // Verifica se o control tem as coordenadas desejadas. Se sim, trata-se da célula que queremos alterar
                if ((coluna == _coluna) && (linha == _linha))
                {
                    x = (PictureBox)c;
                    x.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (imagem == 0)
                    {
                        x.Image = null;
                    }
                    if (imagem == 1)//cabeca
                    {
                        x.Image = Desenhar.Properties.Resources.Cabecar;
                    }

                    if (imagem == 2)
                    {
                        x.Image = Desenhar.Properties.Resources.corpo;
                    }
                    if (imagem == 3)
                    {
                        x.Image = Desenhar.Properties.Resources.apple;
                    }
                    if (imagem == 4)
                    {
                        x.Image = Desenhar.Properties.Resources.caudaparacima;
                    }
                    if (imagem == 5)
                    {
                        x.Image = Desenhar.Properties.Resources.caudaparabaixo;
                    }
                    if (imagem == 6)
                    {
                        x.Image = Desenhar.Properties.Resources.caudaparaesquerda;
                    }
                    if (imagem == 7)
                    {
                        x.Image = Desenhar.Properties.Resources.caudaparadireita;
                    }
                }

            }
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {



            label1.Text = "Score: " + score.ToString();
            for (int x = 0; x < tlpDemo.RowCount; x++)
            {
                for (int y = 0; y < tlpDemo.ColumnCount; y++)
                {
                    AddDockedControl(x, y);
                }
            }
            SnakeBody.Add(new Snake(10, 10, 1));
            SnakeBody.Add(new Snake(11, 10, 5));
            SetCelula(SnakeBody[0].row, SnakeBody[0].col, 1);
            SetCelula(SnakeBody[1].row, SnakeBody[1].col, 4);
            macarow = RandomNumber();
            macacol = RandomNumber();
            SetCelula(macarow, macacol, 3);
            MessageBox.Show("Primeiro introduza o seu nome", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }

        public int direcaocauda;
        public int Direcao;
        ///se direcao for igual :
        ///1 -> para cima
        ///2 -> para esquerda 
        ///3 -> para a direita
        ///4 -> para baixo
        // Método para adicionar um controlo numa determinada célula
        int macarow = 0, macacol = 0;

        int nivel;
        public Color cor = Color.Green;
        bool isTimer1Running = false;
        int score;
        public List<Snake> SnakeBody = new List<Snake>();
        public bool grelha, auxName;
        public class Snake
        {
            public int row, col;
            public int imagem;

            public Snake(int _row, int _col, int _imagem)
            {
                row = _row;
                col = _col;
                imagem = _imagem;
            }

        }
        private void AddDockedControl(int row, int col)
        {
            //UserControl newOne = new UserControl();


            //newOne.BorderStyle = BorderStyle.FixedSingle;
            //newOne.BackColor = colour; // Cor
            //newOne.Dock = DockStyle.Fill; // preencher toda a célula
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.LightBlue;
            tlpDemo.Controls.Add(pictureBox, col, row);
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Margin = new Padding(0);




        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tlpDemo.Controls.Clear();
        }
        private int RandomNumber()
        {
            Random r = new Random();
            int number = r.Next(1, 20);

            return number;
        }


        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

            if (auxName == true)
            {
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    if ((Direcao != 1 && Direcao != 4) || SnakeBody.Count == 1)
                    {

                        Direcao = 1;
                        limpar();
                        UpdateSnake();
                        Pintar();
                    }

                }
                if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    if ((Direcao != 1 && Direcao != 4) || SnakeBody.Count == 1)
                    {

                        Direcao = 4;
                        limpar();
                        UpdateSnake();
                        Pintar();
                    }

                }
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {

                    if ((Direcao != 2 && Direcao != 3) || SnakeBody.Count == 1)
                    {

                        Direcao = 2;
                        limpar();
                        UpdateSnake();
                        Pintar();
                    }

                }
                if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {

                    if ((Direcao != 2 && Direcao != 3) || SnakeBody.Count == 1)
                    {

                        Direcao = 3;
                        limpar();
                        UpdateSnake();
                        Pintar();
                    }

                }

            }


        }

        private void UpdateSnake()
        {

            if (SnakeBody.Count > 2) //colisão de SnakeBody consigo mesma 
            {
                for (int it = 0; it < SnakeBody.Count - 1; it++)
                {
                    for (int i = 1 + it; i < SnakeBody.Count - 1; i++)
                    {
                        if (SnakeBody[it].row == SnakeBody[i].row && SnakeBody[it].col == SnakeBody[i].col)
                        {
                            timer1.Stop();

                            Console.Beep();
                            MessageBox.Show(String.Format("Game Over, O teu score foi: {0}", score), "GG", MessageBoxButtons.OK);
                            isTimer1Running = false;
                            Top.Add(new Score(score, Nome));
                            startToolStripMenuItem.PerformClick();
                            LerScore();
                        }
                    }
                }
            }

            if (SnakeBody[SnakeBody.Count - 1].row == macarow && SnakeBody[SnakeBody.Count - 1].col == macacol) //colisao de sankeBody 0 com maça
            {

                Snake part = new Snake(SnakeBody[SnakeBody.Count - 2].row, SnakeBody[SnakeBody.Count - 2].col, 2);

                /*if (SnakeBody.Count > 2)
               {
                   SnakeBody[SnakeBody.Count - 1].imagem = 2;
               }*/

                SnakeBody.RemoveAt(SnakeBody.Count - 1);
                SnakeBody.Add(part);

                //SnakeBody.Add(new Snake(SnakeBody[SnakeBody.Count - 1].row, SnakeBody[SnakeBody.Count - 1].col, direcaocauda));
                switch (Direcao)
                {
                    case 1://para cima
                        SnakeBody.Add(new Snake(SnakeBody[SnakeBody.Count - 1].row++, SnakeBody[SnakeBody.Count - 1].col, 4));
                        break;
                    case 2://para esquerda 
                        SnakeBody.Add(new Snake(SnakeBody[SnakeBody.Count - 1].row, SnakeBody[SnakeBody.Count - 1].col++, 6));
                        break;
                    case 3://para direita
                        SnakeBody.Add(new Snake(SnakeBody[SnakeBody.Count - 1].row, SnakeBody[SnakeBody.Count - 1].col--, 7));
                        break;
                    default://para baixo
                        SnakeBody.Add(new Snake(SnakeBody[SnakeBody.Count - 1].row--, SnakeBody[SnakeBody.Count - 1].col, 5));
                        break;
                }

                /* Random randonGen = new Random();
                 Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255),             <------------ cobra colorida
                 randonGen.Next(255));
                 SnakeBody[SnakeBody.Count - 1].cor = randomColor;*/
                //SnakeBody[SnakeBody.Count - 1].imagem = 2;


                score++;
                label1.BackColor = Color.Transparent;
                label1.ForeColor = Color.Black;

                label1.Text = "Score: " + score.ToString();
                macarow = RandomNumber();
                macacol = RandomNumber();

                SetCelula(macarow, macacol, 3);

            }
            if (SnakeBody[0].col < 0)
            {
                SnakeBody[0].col = 21;
            }
            else if (SnakeBody[0].col > 20)
            {
                SnakeBody[0].col = 0;
            }
            else if (SnakeBody[0].row < 0)
            {
                SnakeBody[0].row = 21;
            }
            else if (SnakeBody[0].row > 20)
            {
                SnakeBody[0].row = 0;
            }
            limpar();

            for (int i = SnakeBody.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Direcao)
                    {
                        case 1: //continuar para cima
                            if ((SnakeBody[SnakeBody.Count - 2].col == SnakeBody[SnakeBody.Count - 1].col))
                            {
                                direcaocauda = 4;
                                SnakeBody[SnakeBody.Count - 1].imagem = direcaocauda;
                            }
                            SnakeBody[i].row--;

                            break;
                        case 2: //para esquerda
                            if ((SnakeBody[SnakeBody.Count - 2].row == SnakeBody[SnakeBody.Count - 1].row))
                            {
                                direcaocauda = 6;
                                SnakeBody[SnakeBody.Count - 1].imagem = direcaocauda;
                            }
                            SnakeBody[i].col--;

                            break;
                        case 3: //para direita
                            if ((SnakeBody[SnakeBody.Count - 2].row == SnakeBody[SnakeBody.Count - 1].row))
                            {
                                direcaocauda = 7;

                                SnakeBody[SnakeBody.Count - 1].imagem = direcaocauda;
                            }
                            SnakeBody[i].col++;
                            break;
                        case 4: //para baixo
                            if ((SnakeBody[SnakeBody.Count - 2].col == SnakeBody[SnakeBody.Count - 1].col))
                            {
                                direcaocauda = 5;
                                SnakeBody[SnakeBody.Count - 1].imagem = direcaocauda;
                            }
                            SnakeBody[i].row++;
                            break;

                    }
                }
                else
                {
                    SnakeBody[i].row = SnakeBody[i - 1].row;
                    SnakeBody[i].col = SnakeBody[i - 1].col;
                }

            }


        }
        class Score
        {
            int score;
            string nome;

            public Score(int _score, string _nome)
            {
                score = _score;
                nome = _nome;
            }
            public override string ToString()
            {
                string linha;

                // Os campos são automáticamente convertidos para String como o método ToString()
                linha = nome + "\t" + score;

                return linha;
            }
            public string getnome()
            {
                return nome;
            }

            public int getscore()
            {
                return score;
            }


        }


        List<Score> Top = new List<Score>();
        private void LerScore()
        {
            // sugestões para a extenção: .bin; .bd; .dat
            const string caminhoFich = ".\\dados.dat";
            string _nome;
            int _score;
            // 1.) Abrir o ficheiro binário. Se não existir cria um novo
            // Nos ficheiros binários, é importante garantir que o programa crie o ficheiro
            // binário caso ele não exista... nos ficheiros de texto esta preocupação não é tão relevante
            // Igual ao ficheiro de texto... o que muda é o nome da classe
            BinaryReader binIn = new BinaryReader(new FileStream(caminhoFich, FileMode.OpenOrCreate, FileAccess.Read));

            // Ciclo de repetição para ler os dados do ficheiro e guardá-los numa lista 
            while ((binIn.PeekChar() != -1))
            {
                // 3 operações de leitura contínua para ler cada campo do registo
                // Cada leitura representa uma quantidade de byte e a respetiva conversão dos dados
                _nome = binIn.ReadString();
                _score = binIn.ReadInt32();

                // adiciona um registo na lista
                Top.Add(new Score(_score, _nome));
            }
            binIn.Close(); // Fecha o acesso ao ficheiro. Muito IMPORTANTE. Dever ser executado antes  de criar uma nova stream


            // 4.) Criar o ficheiro. Se existir (e existe mesmo) substitui o ficheiro
            //     Nota: queremos substituir o ficheiro existente para guardar novamente TODOS os dados da lista
            // NOTA: Deve ser executado primeiro o close()
            BinaryWriter binOut = new BinaryWriter(new FileStream(caminhoFich, FileMode.Create, FileAccess.Write));

            // Gravar todos os dados no ficheiro

            // Write() e não WriteLine()

            foreach (var item in Top)
            {
                // Write() e não WriteLine()

                binOut.Write(item.getnome());
                binOut.Write(item.getscore());

            }



            // Fechar o ficheiro. Desta forma garantimos que os dados são gravados no ficheiro antes de sair do programa.
            binOut.Close(); // MUITO IMPORTANTE. A diferença entre o amador e o profissional... :D

            label2.Text = "";
            Top = Top.OrderBy(x => -x.getscore()).ToList();
            if (Top.Count > 5)
            {
                for (int i = 5; i < Top.Count; i++)
                {
                    Top.RemoveAt(i);
                }
            }

            for (int i = 0; i < Top.Count; i++)
            {
                if (i == 0)
                {
                    label2.Text = string.Format("*****ScoreBoard*****\n{0}: {1}", Top[i].getnome(), Top[i].getscore());
                }
                else
                {
                    label2.Text += "\n" + string.Format("{0}: {1}", Top[i].getnome(), Top[i].getscore());
                }


            }


        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            tlpDemo.SuspendLayout();

            switch (nivel)
            {
                case 1:
                    Thread.Sleep(150);
                    break;
                case 2:
                    Thread.Sleep(50);
                    break;
                case 3:
                    Thread.Sleep(0);
                    break;
                default:
                    break;
            }


            limpar();
            UpdateSnake();
            Pintar();
            tlpDemo.ResumeLayout();
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            label1.Text = "";
            score = 0;
            SnakeBody.Clear();
            for (int x = 0; x < tlpDemo.RowCount; x++)
            {
                for (int y = 0; y < tlpDemo.ColumnCount; y++)
                {
                    SetCelula(x, y, 0);

                }
            }
            label1.Text = "Score: " + score.ToString();
            SnakeBody.Add(new Snake(10, 10, 1));
            SnakeBody.Add(new Snake(10, 11, 4));
            SetCelula(SnakeBody[0].row, SnakeBody[0].col, 1);
            SetCelula(SnakeBody[1].row, SnakeBody[1].col, 2);
            macarow = RandomNumber();
            macacol = RandomNumber();
            SetCelula(macarow, macacol, 3);
            isTimer1Running = true;
            timer1.Start();
        }
        private void limpar()
        {
            for (int x = 0; x < tlpDemo.RowCount; x++)
            {
                for (int y = 0; y < tlpDemo.ColumnCount; y++)
                {
                    if (x != macarow || y != macacol)
                    {
                        SetCelula(x, y, 0);
                    }

                }
            }


        }
        private void Pintar()
        {
            for (int i = 0; i < SnakeBody.Count; i++)
            {
                SetCelula(SnakeBody[i].row, SnakeBody[i].col, SnakeBody[i].imagem);
            }

        }
        FrmOpcoes opcoes = new FrmOpcoes();


        private void abourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            opcoes.ShowDialog();
            nivel = opcoes.nivel;
            grelha = opcoes.grellha;
            if (grelha == true)
            {
                tlpDemo.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                this.Refresh();
            }
            else
            {
                tlpDemo.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                this.Refresh();
            }
            Thread.Sleep(3000);
            timer1.Enabled = true;
        }

        private void instruçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Instrucoes ins = new Instrucoes();
            ins.ShowDialog();
            Thread.Sleep(3000);
            timer1.Enabled = true;

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }
        string Nome;
        private void btnNome_Click(object sender, EventArgs e)
        {
            Nome = txtnome.Text;
            lbl_nome.Hide();
            txtnome.Hide();
            btnNome.Hide();
            auxName = true;

            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
