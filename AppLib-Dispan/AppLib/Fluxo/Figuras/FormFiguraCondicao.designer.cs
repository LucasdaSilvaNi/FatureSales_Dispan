﻿namespace AppLib.Fluxo
{
    partial class FormFiguraCondicao
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
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSALVAR = new System.Windows.Forms.Button();
            this.buttonCANCELAR = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonEDITOR = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEXPRESSAO = new System.Windows.Forms.TextBox();
            this.buttonLIMPARDESTINOF = new System.Windows.Forms.Button();
            this.buttonLIMPARDESTINOV = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxFALSO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVERDADEIRO = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTEXTO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNOME = new System.Windows.Forms.TextBox();
            this.buttonLIMPARDESTINO = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDESTINO = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Destino:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(114, 119);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Descrição:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(114, 41);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(312, 72);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSALVAR);
            this.panel1.Controls.Add(this.buttonCANCELAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 46);
            this.panel1.TabIndex = 7;
            // 
            // buttonSALVAR
            // 
            this.buttonSALVAR.Location = new System.Drawing.Point(62, 11);
            this.buttonSALVAR.Name = "buttonSALVAR";
            this.buttonSALVAR.Size = new System.Drawing.Size(75, 23);
            this.buttonSALVAR.TabIndex = 2;
            this.buttonSALVAR.Text = "Salvar";
            this.buttonSALVAR.UseVisualStyleBackColor = true;
            this.buttonSALVAR.Click += new System.EventHandler(this.buttonSALVAR_Click);
            // 
            // buttonCANCELAR
            // 
            this.buttonCANCELAR.Location = new System.Drawing.Point(143, 11);
            this.buttonCANCELAR.Name = "buttonCANCELAR";
            this.buttonCANCELAR.Size = new System.Drawing.Size(75, 23);
            this.buttonCANCELAR.TabIndex = 3;
            this.buttonCANCELAR.Text = "Cancelar";
            this.buttonCANCELAR.UseVisualStyleBackColor = true;
            this.buttonCANCELAR.Click += new System.EventHandler(this.buttonCANCELAR_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 343);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonLIMPARDESTINO);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.comboBoxDESTINO);
            this.tabPage1.Controls.Add(this.buttonEDITOR);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBoxEXPRESSAO);
            this.tabPage1.Controls.Add(this.buttonLIMPARDESTINOF);
            this.tabPage1.Controls.Add(this.buttonLIMPARDESTINOV);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBoxFALSO);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBoxVERDADEIRO);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxTEXTO);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBoxNOME);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Geral";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonEDITOR
            // 
            this.buttonEDITOR.Location = new System.Drawing.Point(139, 278);
            this.buttonEDITOR.Name = "buttonEDITOR";
            this.buttonEDITOR.Size = new System.Drawing.Size(75, 23);
            this.buttonEDITOR.TabIndex = 14;
            this.buttonEDITOR.Text = "Editor";
            this.buttonEDITOR.UseVisualStyleBackColor = true;
            this.buttonEDITOR.Click += new System.EventHandler(this.buttonEDITOR_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Expressão:";
            // 
            // textBoxEXPRESSAO
            // 
            this.textBoxEXPRESSAO.Location = new System.Drawing.Point(139, 200);
            this.textBoxEXPRESSAO.Multiline = true;
            this.textBoxEXPRESSAO.Name = "textBoxEXPRESSAO";
            this.textBoxEXPRESSAO.ReadOnly = true;
            this.textBoxEXPRESSAO.Size = new System.Drawing.Size(312, 72);
            this.textBoxEXPRESSAO.TabIndex = 12;
            // 
            // buttonLIMPARDESTINOF
            // 
            this.buttonLIMPARDESTINOF.Location = new System.Drawing.Point(266, 144);
            this.buttonLIMPARDESTINOF.Name = "buttonLIMPARDESTINOF";
            this.buttonLIMPARDESTINOF.Size = new System.Drawing.Size(23, 23);
            this.buttonLIMPARDESTINOF.TabIndex = 9;
            this.buttonLIMPARDESTINOF.Text = "X";
            this.buttonLIMPARDESTINOF.UseVisualStyleBackColor = true;
            this.buttonLIMPARDESTINOF.Click += new System.EventHandler(this.buttonLIMPARDESTINOF_Click);
            // 
            // buttonLIMPARDESTINOV
            // 
            this.buttonLIMPARDESTINOV.Location = new System.Drawing.Point(266, 117);
            this.buttonLIMPARDESTINOV.Name = "buttonLIMPARDESTINOV";
            this.buttonLIMPARDESTINOV.Size = new System.Drawing.Size(23, 23);
            this.buttonLIMPARDESTINOV.TabIndex = 8;
            this.buttonLIMPARDESTINOV.Text = "X";
            this.buttonLIMPARDESTINOV.UseVisualStyleBackColor = true;
            this.buttonLIMPARDESTINOV.Click += new System.EventHandler(this.buttonLIMPARDESTINOV_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Destino se falso:";
            // 
            // comboBoxFALSO
            // 
            this.comboBoxFALSO.FormattingEnabled = true;
            this.comboBoxFALSO.Location = new System.Drawing.Point(139, 146);
            this.comboBoxFALSO.Name = "comboBoxFALSO";
            this.comboBoxFALSO.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFALSO.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destino se verdadeiro:";
            // 
            // comboBoxVERDADEIRO
            // 
            this.comboBoxVERDADEIRO.FormattingEnabled = true;
            this.comboBoxVERDADEIRO.Location = new System.Drawing.Point(139, 119);
            this.comboBoxVERDADEIRO.Name = "comboBoxVERDADEIRO";
            this.comboBoxVERDADEIRO.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVERDADEIRO.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Texto:";
            // 
            // textBoxTEXTO
            // 
            this.textBoxTEXTO.Location = new System.Drawing.Point(139, 41);
            this.textBoxTEXTO.Multiline = true;
            this.textBoxTEXTO.Name = "textBoxTEXTO";
            this.textBoxTEXTO.Size = new System.Drawing.Size(312, 72);
            this.textBoxTEXTO.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nome:";
            // 
            // textBoxNOME
            // 
            this.textBoxNOME.Location = new System.Drawing.Point(139, 15);
            this.textBoxNOME.Name = "textBoxNOME";
            this.textBoxNOME.ReadOnly = true;
            this.textBoxNOME.Size = new System.Drawing.Size(100, 20);
            this.textBoxNOME.TabIndex = 0;
            // 
            // buttonLIMPARDESTINO
            // 
            this.buttonLIMPARDESTINO.Location = new System.Drawing.Point(266, 171);
            this.buttonLIMPARDESTINO.Name = "buttonLIMPARDESTINO";
            this.buttonLIMPARDESTINO.Size = new System.Drawing.Size(23, 23);
            this.buttonLIMPARDESTINO.TabIndex = 17;
            this.buttonLIMPARDESTINO.Text = "X";
            this.buttonLIMPARDESTINO.UseVisualStyleBackColor = true;
            this.buttonLIMPARDESTINO.Click += new System.EventHandler(this.buttonLIMPARDESTINO_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Destino:";
            // 
            // comboBoxDESTINO
            // 
            this.comboBoxDESTINO.FormattingEnabled = true;
            this.comboBoxDESTINO.Location = new System.Drawing.Point(139, 173);
            this.comboBoxDESTINO.Name = "comboBoxDESTINO";
            this.comboBoxDESTINO.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDESTINO.TabIndex = 15;
            // 
            // FormFiguraCondicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 389);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFiguraCondicao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propriedades Figura Condição";
            this.Load += new System.EventHandler(this.FormFiguraCondicao_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSALVAR;
        private System.Windows.Forms.Button buttonCANCELAR;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVERDADEIRO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTEXTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNOME;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxFALSO;
        private System.Windows.Forms.Button buttonLIMPARDESTINOF;
        private System.Windows.Forms.Button buttonLIMPARDESTINOV;
        private System.Windows.Forms.Button buttonEDITOR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEXPRESSAO;
        private System.Windows.Forms.Button buttonLIMPARDESTINO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDESTINO;
    }
}