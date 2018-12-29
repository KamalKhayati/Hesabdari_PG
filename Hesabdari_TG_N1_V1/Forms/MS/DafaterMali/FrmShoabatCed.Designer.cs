namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    partial class FrmShoabatCed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShoabatCed));
            this.txtcodeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.txtNameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBastan = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtIdAnbar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnCodeJadid = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSabtBadi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodeAnbar
            // 
            this.txtcodeAnbar.Location = new System.Drawing.Point(366, 83);
            this.txtcodeAnbar.Name = "txtcodeAnbar";
            this.txtcodeAnbar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtcodeAnbar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtcodeAnbar.Properties.Mask.EditMask = "f0";
            this.txtcodeAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcodeAnbar.Properties.MaxLength = 3;
            this.txtcodeAnbar.Size = new System.Drawing.Size(123, 32);
            this.txtcodeAnbar.TabIndex = 4;
            this.txtcodeAnbar.TabStop = false;
            // 
            // txtNameAnbar
            // 
            this.txtNameAnbar.Location = new System.Drawing.Point(6, 122);
            this.txtNameAnbar.Name = "txtNameAnbar";
            this.txtNameAnbar.Properties.MaxLength = 50;
            this.txtNameAnbar.Size = new System.Drawing.Size(483, 32);
            this.txtNameAnbar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            // 
            // btnSabtBastan
            // 
            this.btnSabtBastan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBastan.ImageOptions.Image")));
            this.btnSabtBastan.Location = new System.Drawing.Point(158, 263);
            this.btnSabtBastan.Name = "btnSabtBastan";
            this.btnSabtBastan.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBastan.TabIndex = 1;
            this.btnSabtBastan.Text = "ایجاد و بستن";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(495, 204);
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
            this.txtIdAnbar.Location = new System.Drawing.Point(6, 83);
            this.txtIdAnbar.Name = "txtIdAnbar";
            this.txtIdAnbar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIdAnbar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIdAnbar.Properties.Mask.EditMask = "f0";
            this.txtIdAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtIdAnbar.Properties.NullText = "آیدی انبار";
            this.txtIdAnbar.Properties.ReadOnly = true;
            this.txtIdAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdAnbar.Size = new System.Drawing.Size(108, 32);
            this.txtIdAnbar.TabIndex = 7;
            this.txtIdAnbar.TabStop = false;
            this.txtIdAnbar.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(495, 86);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lookUpEdit2);
            this.panelControl1.Controls.Add(this.lookUpEdit1);
            this.panelControl1.Controls.Add(this.checkedComboBoxEdit1);
            this.panelControl1.Controls.Add(this.btnCodeJadid);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.txtcodeAnbar);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtIdAnbar);
            this.panelControl1.Controls.Add(this.txtNameAnbar);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(673, 245);
            this.panelControl1.TabIndex = 17;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoEllipsis = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(495, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(155, 32);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "نام مجتمع یا مجموعه (زنجیره ای)";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(4, 45);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lookUpEdit2.Size = new System.Drawing.Size(484, 32);
            this.lookUpEdit2.TabIndex = 0;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(5, 7);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lookUpEdit1.Size = new System.Drawing.Size(484, 32);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(6, 160);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(483, 32);
            this.checkedComboBoxEdit1.TabIndex = 1;
            // 
            // btnCodeJadid
            // 
            this.btnCodeJadid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCodeJadid.ImageOptions.SvgImage")));
            this.btnCodeJadid.Location = new System.Drawing.Point(125, 81);
            this.btnCodeJadid.Name = "btnCodeJadid";
            this.btnCodeJadid.Size = new System.Drawing.Size(114, 35);
            this.btnCodeJadid.TabIndex = 6;
            this.btnCodeJadid.TabStop = false;
            this.btnCodeJadid.Text = "کد جدید";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "کد مجموعه و واحد";
            this.textEdit1.Location = new System.Drawing.Point(245, 83);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.Mask.EditMask = "f0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.MaxLength = 3;
            this.textEdit1.Properties.NullText = "کد مجموعه";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.Size = new System.Drawing.Size(115, 32);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.TabStop = false;
            this.textEdit1.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(495, 48);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(167, 25);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "نام واحد تجاری / خدماتی";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(495, 125);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(106, 25);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "نام شعبه مربوطه";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(495, 163);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 25);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "کاربران مجاز به ثبت عملیات";
            // 
            // btnSabtBadi
            // 
            this.btnSabtBadi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBadi.ImageOptions.Image")));
            this.btnSabtBadi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtBadi.ImageOptions.SvgImage")));
            this.btnSabtBadi.Location = new System.Drawing.Point(301, 263);
            this.btnSabtBadi.Name = "btnSabtBadi";
            this.btnSabtBadi.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBadi.TabIndex = 0;
            this.btnSabtBadi.Text = "ایجاد و بعدی";
            // 
            // FrmShoabatCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 311);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSabtBastan);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnSabtBadi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShoabatCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد شعبات واحدها";
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtcodeAnbar;
        public DevExpress.XtraEditors.TextEdit txtNameAnbar;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSabtBastan;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtIdAnbar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton btnCodeJadid;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.SimpleButton btnSabtBadi;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}