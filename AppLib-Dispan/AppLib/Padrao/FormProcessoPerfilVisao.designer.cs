﻿namespace AppLib.Padrao
{
    partial class FormProcessoPerfilVisao
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BotaoEditar = true;
            this.grid1.BotaoExcluir = true;
            this.grid1.BotaoNovo = true;
            this.grid1.Consulta = new string[] {
        "SELECT",
        "CODPROCESSO,",
        "(SELECT NOME FROM ZPROCESSO WHERE CODPROCESSO = ZPROCESSOPERFIL.CODPROCESSO) PROC" +
            "ESSO,",
        "CODPERFIL,",
        "(SELECT NOME FROM ZPERFIL WHERE CODPERFIL = ZPROCESSOPERFIL.CODPERFIL) PERFIL,",
        "ATIVO",
        "FROM ZPROCESSOPERFIL"};
            this.grid1.NomeGrid = "ZPROCESSOPERFIL";
            this.grid1.Size = new System.Drawing.Size(624, 472);
            this.grid1.Novo += new AppLib.Windows.GridData.NovoHandler(this.grid1_Novo);
            this.grid1.Editar += new AppLib.Windows.GridData.EditarHandler(this.grid1_Editar);
            this.grid1.Excluir += new AppLib.Windows.GridData.ExcluirHandler(this.grid1_Excluir);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(624, 472);
            // 
            // FormProcessoPerfilVisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 472);
            this.Name = "FormProcessoPerfilVisao";
            this.Text = "Visão de Processo/Perfil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProcessoPerfilVisao_FormClosed);
            this.Load += new System.EventHandler(this.FormProcessoPerfilVisao_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}