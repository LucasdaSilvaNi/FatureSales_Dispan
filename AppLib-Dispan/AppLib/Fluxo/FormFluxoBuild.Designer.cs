﻿namespace AppLib.Fluxo
{
    partial class FormFluxoBuild
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxERROS = new System.Windows.Forms.ListBox();
            this.listBoxCODIGOFONTE = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxCODIGOFONTE);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxERROS);
            this.splitContainer1.Size = new System.Drawing.Size(384, 361);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 8;
            // 
            // listBoxERROS
            // 
            this.listBoxERROS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxERROS.FormattingEnabled = true;
            this.listBoxERROS.Location = new System.Drawing.Point(0, 0);
            this.listBoxERROS.Name = "listBoxERROS";
            this.listBoxERROS.Size = new System.Drawing.Size(384, 86);
            this.listBoxERROS.TabIndex = 0;
            this.listBoxERROS.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBoxCODIGOFONTE
            // 
            this.listBoxCODIGOFONTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCODIGOFONTE.FormattingEnabled = true;
            this.listBoxCODIGOFONTE.Location = new System.Drawing.Point(0, 0);
            this.listBoxCODIGOFONTE.Name = "listBoxCODIGOFONTE";
            this.listBoxCODIGOFONTE.Size = new System.Drawing.Size(384, 271);
            this.listBoxCODIGOFONTE.TabIndex = 1;
            // 
            // FormFluxoBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormFluxoBuild";
            this.Text = "Build de Fluxos";
            this.Load += new System.EventHandler(this.FormFluxoBuild_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ListBox listBoxERROS;
        public System.Windows.Forms.ListBox listBoxCODIGOFONTE;

    }
}