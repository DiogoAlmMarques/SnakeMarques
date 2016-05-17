namespace Desenhar
{
    partial class FrmOpcoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nupnivel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_ajudanivel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupnivel)).BeginInit();
            this.SuspendLayout();
            // 
            // nupnivel
            // 
            this.nupnivel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.nupnivel.Location = new System.Drawing.Point(51, 20);
            this.nupnivel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupnivel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupnivel.Name = "nupnivel";
            this.nupnivel.Size = new System.Drawing.Size(120, 20);
            this.nupnivel.TabIndex = 0;
            this.nupnivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupnivel.ValueChanged += new System.EventHandler(this.nupnivel_ValueChanged);
            this.nupnivel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nupnivel_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nível";
            // 
            // btn_ajudanivel
            // 
            this.btn_ajudanivel.Location = new System.Drawing.Point(177, 20);
            this.btn_ajudanivel.Name = "btn_ajudanivel";
            this.btn_ajudanivel.Size = new System.Drawing.Size(75, 23);
            this.btn_ajudanivel.TabIndex = 5;
            this.btn_ajudanivel.Text = "Ajuda";
            this.btn_ajudanivel.UseVisualStyleBackColor = true;
            this.btn_ajudanivel.Click += new System.EventHandler(this.btn_ajudanivel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(177, 99);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(15, 99);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 7;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // FrmOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 132);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_ajudanivel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nupnivel);
            this.Name = "FrmOpcoes";
            this.Text = "Opções";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpcoes_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOpcoes_FormClosed);
            this.Load += new System.EventHandler(this.FrmOpcoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupnivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupnivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_ajudanivel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancelar;
    }
}