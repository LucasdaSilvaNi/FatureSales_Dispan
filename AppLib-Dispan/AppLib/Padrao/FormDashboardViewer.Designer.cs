﻿namespace AppLib.Padrao
{
    partial class FormDashboardViewer
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
            this.components = new System.ComponentModel.Container();
            this.dashboardViewer1 = new DevExpress.DashboardWin.DashboardViewer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardViewer1
            // 
            this.dashboardViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardViewer1.Location = new System.Drawing.Point(0, 0);
            this.dashboardViewer1.Name = "dashboardViewer1";
            this.dashboardViewer1.PrintingOptions.FontInfo.GdiCharSet = ((byte)(0));
            this.dashboardViewer1.PrintingOptions.FontInfo.Name = null;
            this.dashboardViewer1.Size = new System.Drawing.Size(654, 422);
            this.dashboardViewer1.TabIndex = 0;
            this.dashboardViewer1.ConfigureDataConnection += dashboardViewer1_ConfigureDataConnection;
            // 
            // FormDashboardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 422);
            this.Controls.Add(this.dashboardViewer1);
            this.Name = "FormDashboardViewer";
            this.Text = "Visualizador de Dashboard";
            this.Load += new System.EventHandler(this.FormDashboardView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.DashboardWin.DashboardViewer dashboardViewer1;

    }
}