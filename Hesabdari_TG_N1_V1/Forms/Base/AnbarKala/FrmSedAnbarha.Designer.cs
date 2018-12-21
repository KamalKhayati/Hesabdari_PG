namespace Hesabdari_TG_N1_V1.Forms.Base.AnbarKala
{
    partial class FrmSedAnbarha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSedAnbarha));
            this.txtcodeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.txtNameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnSabtBastan = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtIdAnbar = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCodeJadid = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBadi = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
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
            this.txtcodeAnbar.TabStop = false;
            // 
            // txtNameAnbar
            // 
            this.txtNameAnbar.Location = new System.Drawing.Point(5, 47);
            this.txtNameAnbar.Name = "txtNameAnbar";
            this.txtNameAnbar.Properties.MaxLength = 100;
            this.txtNameAnbar.Size = new System.Drawing.Size(417, 32);
            this.txtNameAnbar.TabIndex = 0;
            // 
            // btnSabtBastan
            // 
            this.btnSabtBastan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBastan.ImageOptions.Image")));
            this.btnSabtBastan.Location = new System.Drawing.Point(161, 189);
            this.btnSabtBastan.Name = "btnSabtBastan";
            this.btnSabtBastan.Size = new System.Drawing.Size(150, 40);
            this.btnSabtBastan.TabIndex = 1;
            this.btnSabtBastan.Text = "ثبت و بستن";
            this.btnSabtBastan.Click += new System.EventHandler(this.btnSabtBastan_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 2;
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
            this.labelControl2.Location = new System.Drawing.Point(433, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام انبار";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(431, 123);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(58, 33);
            this.chkIsActive.TabIndex = 1;
            // 
            // txtIdAnbar
            // 
            this.txtIdAnbar.EditValue = "آیدی ";
            this.txtIdAnbar.Location = new System.Drawing.Point(5, 8);
            this.txtIdAnbar.Name = "txtIdAnbar";
            this.txtIdAnbar.Properties.NullText = "آیدی انبار";
            this.txtIdAnbar.Properties.ReadOnly = true;
            this.txtIdAnbar.Size = new System.Drawing.Size(108, 32);
            this.txtIdAnbar.TabIndex = 6;
            this.txtIdAnbar.TabStop = false;
            this.txtIdAnbar.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkedComboBoxEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnCodeJadid);
            this.panelControl1.Controls.Add(this.txtcodeAnbar);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtIdAnbar);
            this.panelControl1.Controls.Add(this.txtNameAnbar);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(590, 171);
            this.panelControl1.TabIndex = 7;
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(5, 85);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(417, 32);
            this.checkedComboBoxEdit1.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(428, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(147, 25);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "کاربران مجاز به استفاده";
            // 
            // btnCodeJadid
            // 
            this.btnCodeJadid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCodeJadid.ImageOptions.SvgImage")));
            this.btnCodeJadid.Location = new System.Drawing.Point(166, 6);
            this.btnCodeJadid.Name = "btnCodeJadid";
            this.btnCodeJadid.Size = new System.Drawing.Size(100, 35);
            this.btnCodeJadid.TabIndex = 7;
            this.btnCodeJadid.TabStop = false;
            this.btnCodeJadid.Text = "کد جدید";
            this.btnCodeJadid.Click += new System.EventHandler(this.btnCodeJadid_Click);
            // 
            // btnSabtBadi
            // 
            this.btnSabtBadi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBadi.ImageOptions.Image")));
            this.btnSabtBadi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtBadi.ImageOptions.SvgImage")));
            this.btnSabtBadi.Location = new System.Drawing.Point(317, 191);
            this.btnSabtBadi.Name = "btnSabtBadi";
            this.btnSabtBadi.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBadi.TabIndex = 0;
            this.btnSabtBadi.Text = "ثبت و بعدی";
            this.btnSabtBadi.Click += new System.EventHandler(this.btnSabtBadi_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(231, 123);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.checkEdit1.Properties.Caption = "اجازه دادن موجودی منفی";
            this.checkEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkEdit1.Size = new System.Drawing.Size(191, 33);
            this.checkEdit1.TabIndex = 1;
            // 
            // FrmSedAnbarha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 238);
            this.Controls.Add(this.btnSabtBadi);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSabtBastan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSedAnbarha";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت انبارها";
            this.Load += new System.EventHandler(this.FrmSedAnbarha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnSabtBastan;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtcodeAnbar;
        public DevExpress.XtraEditors.TextEdit txtNameAnbar;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtIdAnbar;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCodeJadid;
        public DevExpress.XtraEditors.SimpleButton btnSabtBadi;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}