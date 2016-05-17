using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desenhar
{
    public partial class FrmOpcoes : Form
    {
        public bool aux = false;
        public FrmOpcoes()
        {
            InitializeComponent();
        }

        private void FrmOpcoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }
        public int auxnivel;

        public int nivel = 2;

        public bool grellha;
        private void nupnivel_ValueChanged(object sender, EventArgs e)
        {
            auxnivel = nivel;
        }

        private void FrmOpcoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }





        private void btn_ajudanivel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nível mais alto é igual a maior velociade", "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void nupnivel_MouseDown(object sender, MouseEventArgs e)
        {
            if (aux == false)
            {
                btn_ajudanivel.PerformClick();
                aux = true;
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            nivel = (int)nupnivel.Value;

            Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            nupnivel.Value = auxnivel;

            Hide();
        }

        private void FrmOpcoes_Load(object sender, EventArgs e)
        {

        }



    }
}
