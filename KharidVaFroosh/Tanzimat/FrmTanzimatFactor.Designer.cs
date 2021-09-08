namespace KharidVaFroosh.Tanzimat
{
    partial class FrmFKTanzimatFactor
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtc_FKTanzimatFactor = new DevExpress.XtraTab.XtraTabControl();
            this.xtp_Anbar = new DevExpress.XtraTab.XtraTabPage();
            this.xtp_Khadamat = new DevExpress.XtraTab.XtraTabPage();
            this.xtp_Ezafat = new DevExpress.XtraTab.XtraTabPage();
            this.xtp_Ksorat = new DevExpress.XtraTab.XtraTabPage();
            this.xtp_Vasete = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtc_FKTanzimatFactor)).BeginInit();
            this.xtc_FKTanzimatFactor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtc_FKTanzimatFactor);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1252, 705);
            this.panelControl1.TabIndex = 0;
            // 
            // xtc_FKTanzimatFactor
            // 
            this.xtc_FKTanzimatFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtc_FKTanzimatFactor.Location = new System.Drawing.Point(2, 2);
            this.xtc_FKTanzimatFactor.Name = "xtc_FKTanzimatFactor";
            this.xtc_FKTanzimatFactor.SelectedTabPage = this.xtp_Anbar;
            this.xtc_FKTanzimatFactor.Size = new System.Drawing.Size(1248, 701);
            this.xtc_FKTanzimatFactor.TabIndex = 0;
            this.xtc_FKTanzimatFactor.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtp_Anbar,
            this.xtp_Khadamat,
            this.xtp_Ezafat,
            this.xtp_Ksorat,
            this.xtp_Vasete});
            // 
            // xtp_Anbar
            // 
            this.xtp_Anbar.Name = "xtp_Anbar";
            this.xtp_Anbar.Size = new System.Drawing.Size(1246, 660);
            this.xtp_Anbar.Text = "تنظیمات انبار جهت اقلام کالا";
            // 
            // xtp_Khadamat
            // 
            this.xtp_Khadamat.Name = "xtp_Khadamat";
            this.xtp_Khadamat.Size = new System.Drawing.Size(1246, 660);
            this.xtp_Khadamat.Text = "تنظیمات کدینگ خدمات";
            // 
            // xtp_Ezafat
            // 
            this.xtp_Ezafat.Name = "xtp_Ezafat";
            this.xtp_Ezafat.Size = new System.Drawing.Size(1246, 660);
            this.xtp_Ezafat.Text = "تنظیمات اضافات فاکتور";
            // 
            // xtp_Ksorat
            // 
            this.xtp_Ksorat.Name = "xtp_Ksorat";
            this.xtp_Ksorat.Size = new System.Drawing.Size(1246, 660);
            this.xtp_Ksorat.Text = "تنظیمات کسورات فاکتور";
            // 
            // xtp_Vasete
            // 
            this.xtp_Vasete.Name = "xtp_Vasete";
            this.xtp_Vasete.Size = new System.Drawing.Size(1246, 660);
            this.xtp_Vasete.Text = "تنظیمات واسطه فاکتور";
            // 
            // FrmFKTanzimatFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 705);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.Name = "FrmFKTanzimatFactor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات فاکتور";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtc_FKTanzimatFactor)).EndInit();
            this.xtc_FKTanzimatFactor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtc_FKTanzimatFactor;
        private DevExpress.XtraTab.XtraTabPage xtp_Anbar;
        private DevExpress.XtraTab.XtraTabPage xtp_Khadamat;
        private DevExpress.XtraTab.XtraTabPage xtp_Ezafat;
        private DevExpress.XtraTab.XtraTabPage xtp_Ksorat;
        private DevExpress.XtraTab.XtraTabPage xtp_Vasete;
    }
}