namespace Hesabdari_TG_N1_V1.Forms.ModirSystem.DafaterMali
{
    partial class FrmSedMajmoeha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSedMajmoeha));
            this.txtcodeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.txtNameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtIdAnbar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnCodeJadid = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBadi = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBastan = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodeAnbar
            // 
            this.txtcodeAnbar.Location = new System.Drawing.Point(346, 8);
            this.txtcodeAnbar.Name = "txtcodeAnbar";
            this.txtcodeAnbar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtcodeAnbar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtcodeAnbar.Properties.Mask.EditMask = "f0";
            this.txtcodeAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcodeAnbar.Properties.MaxLength = 3;
            this.txtcodeAnbar.Size = new System.Drawing.Size(133, 32);
            this.txtcodeAnbar.TabIndex = 0;
            this.txtcodeAnbar.TabStop = false;
            // 
            // txtNameAnbar
            // 
            this.txtNameAnbar.Location = new System.Drawing.Point(5, 47);
            this.txtNameAnbar.Name = "txtNameAnbar";
            this.txtNameAnbar.Properties.MaxLength = 150;
            this.txtNameAnbar.Size = new System.Drawing.Size(474, 32);
            this.txtNameAnbar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(485, 129);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(54, 33);
            this.chkIsActive.TabIndex = 2;
            // 
            // txtIdAnbar
            // 
            this.txtIdAnbar.EditValue = "آیدی ";
            this.txtIdAnbar.Location = new System.Drawing.Point(5, 8);
            this.txtIdAnbar.Name = "txtIdAnbar";
            this.txtIdAnbar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIdAnbar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIdAnbar.Properties.Mask.EditMask = "f0";
            this.txtIdAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtIdAnbar.Properties.NullText = "آیدی انبار";
            this.txtIdAnbar.Properties.ReadOnly = true;
            this.txtIdAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdAnbar.Size = new System.Drawing.Size(108, 32);
            this.txtIdAnbar.TabIndex = 6;
            this.txtIdAnbar.TabStop = false;
            this.txtIdAnbar.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(486, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(141, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام مجموعه زنجیره ای";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(485, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.checkedComboBoxEdit1);
            this.panelControl1.Controls.Add(this.btnCodeJadid);
            this.panelControl1.Controls.Add(this.txtcodeAnbar);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtIdAnbar);
            this.panelControl1.Controls.Add(this.txtNameAnbar);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 167);
            this.panelControl1.TabIndex = 10;
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(5, 85);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(474, 32);
            this.checkedComboBoxEdit1.TabIndex = 1;
            // 
            // btnCodeJadid
            // 
            this.btnCodeJadid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCodeJadid.ImageOptions.SvgImage")));
            this.btnCodeJadid.Location = new System.Drawing.Point(236, 5);
            this.btnCodeJadid.Name = "btnCodeJadid";
            this.btnCodeJadid.Size = new System.Drawing.Size(100, 35);
            this.btnCodeJadid.TabIndex = 7;
            this.btnCodeJadid.TabStop = false;
            this.btnCodeJadid.Text = "کد جدید";
            // 
            // btnSabtBadi
            // 
            this.btnSabtBadi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBadi.ImageOptions.Image")));
            this.btnSabtBadi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtBadi.ImageOptions.SvgImage")));
            this.btnSabtBadi.Location = new System.Drawing.Point(299, 185);
            this.btnSabtBadi.Name = "btnSabtBadi";
            this.btnSabtBadi.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBadi.TabIndex = 0;
            this.btnSabtBadi.Text = "ثبت و بعدی";
            this.btnSabtBadi.Click += new System.EventHandler(this.btnSabtBadi_Click);
            // 
            // btnSabtBastan
            // 
            this.btnSabtBastan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBastan.ImageOptions.Image")));
            this.btnSabtBastan.Location = new System.Drawing.Point(157, 185);
            this.btnSabtBastan.Name = "btnSabtBastan";
            this.btnSabtBastan.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBastan.TabIndex = 1;
            this.btnSabtBastan.Text = "ثبت و بستن";
            this.btnSabtBastan.Click += new System.EventHandler(this.btnSabtBastan_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(485, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 25);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "کاربران مجاز به ثبت عملیات";
            // 
            // FrmSedMajmoeha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 231);
            this.Controls.Add(this.btnSabtBadi);
            this.Controls.Add(this.btnSabtBastan);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSedMajmoeha";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ثبت مجموعه های زنجیره ای";
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtcodeAnbar;
        public DevExpress.XtraEditors.TextEdit txtNameAnbar;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtIdAnbar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCodeJadid;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        public DevExpress.XtraEditors.SimpleButton btnSabtBadi;
        public DevExpress.XtraEditors.SimpleButton btnSabtBastan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}