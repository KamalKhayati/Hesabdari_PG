namespace Hesabdari_TG_N1_V1.Forms.Base.AnbarKala
{
    partial class FrmSaveAnbars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaveAnbars));
            this.txtcodeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.txtNameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtIdAnbar = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCodeJadid = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtcodeAnbar
            // 
            this.txtcodeAnbar.Location = new System.Drawing.Point(272, 8);
            this.txtcodeAnbar.Name = "txtcodeAnbar";
            this.txtcodeAnbar.Properties.Mask.EditMask = "f0";
            this.txtcodeAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcodeAnbar.Properties.MaxLength = 3;
            this.txtcodeAnbar.Size = new System.Drawing.Size(150, 32);
            this.txtcodeAnbar.TabIndex = 0;
            // 
            // txtNameAnbar
            // 
            this.txtNameAnbar.Location = new System.Drawing.Point(5, 54);
            this.txtNameAnbar.Name = "txtNameAnbar";
            this.txtNameAnbar.Properties.MaxLength = 100;
            this.txtNameAnbar.Size = new System.Drawing.Size(417, 32);
            this.txtNameAnbar.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(158, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(9, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(432, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد انبار";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(433, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام انبار";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(293, 99);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "انبار فعال باشد؟  ";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIsActive.Size = new System.Drawing.Size(129, 33);
            this.chkIsActive.TabIndex = 2;
            // 
            // txtIdAnbar
            // 
            this.txtIdAnbar.Location = new System.Drawing.Point(5, 8);
            this.txtIdAnbar.Name = "txtIdAnbar";
            this.txtIdAnbar.Properties.NullText = "آیدی انبار";
            this.txtIdAnbar.Properties.ReadOnly = true;
            this.txtIdAnbar.Size = new System.Drawing.Size(108, 32);
            this.txtIdAnbar.TabIndex = 6;
            this.txtIdAnbar.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCodeJadid);
            this.panelControl1.Controls.Add(this.txtcodeAnbar);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtIdAnbar);
            this.panelControl1.Controls.Add(this.txtNameAnbar);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(9, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(487, 138);
            this.panelControl1.TabIndex = 7;
            // 
            // btnCodeJadid
            // 
            this.btnCodeJadid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCodeJadid.ImageOptions.SvgImage")));
            this.btnCodeJadid.Location = new System.Drawing.Point(166, 6);
            this.btnCodeJadid.Name = "btnCodeJadid";
            this.btnCodeJadid.Size = new System.Drawing.Size(100, 35);
            this.btnCodeJadid.TabIndex = 7;
            this.btnCodeJadid.Text = "کد جدید";
            this.btnCodeJadid.Click += new System.EventHandler(this.btnCodeJadid_Click);
            // 
            // FrmSaveAnbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 199);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaveAnbars";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSaveAnbars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtcodeAnbar;
        public DevExpress.XtraEditors.TextEdit txtNameAnbar;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtIdAnbar;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCodeJadid;
    }
}