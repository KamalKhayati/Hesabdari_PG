namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
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
            this.txtcode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkcmbMajavezKarbaran = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnCodeJadid = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBadi = new DevExpress.XtraEditors.SimpleButton();
            this.btnSabtBastan = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbMajavezKarbaran.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(346, 8);
            this.txtcode.Name = "txtcode";
            this.txtcode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtcode.Properties.Mask.EditMask = "f0";
            this.txtcode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcode.Properties.MaxLength = 3;
            this.txtcode.Properties.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(133, 32);
            this.txtcode.TabIndex = 0;
            this.txtcode.TabStop = false;
            this.txtcode.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(5, 8);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(474, 32);
            this.txtName.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(485, 90);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(54, 33);
            this.chkIsActive.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(5, 8);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(108, 32);
            this.txtId.TabIndex = 6;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(485, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد";
            this.labelControl1.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.chkcmbMajavezKarbaran);
            this.panelControl1.Controls.Add(this.btnCodeJadid);
            this.panelControl1.Controls.Add(this.txtcode);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 132);
            this.panelControl1.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(485, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(155, 32);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "نام مجتمع یا مجموعه (زنجیره ای)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(485, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 25);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "کاربران مجاز به ثبت عملیات";
            // 
            // chkcmbMajavezKarbaran
            // 
            this.chkcmbMajavezKarbaran.Location = new System.Drawing.Point(5, 46);
            this.chkcmbMajavezKarbaran.Name = "chkcmbMajavezKarbaran";
            this.chkcmbMajavezKarbaran.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbMajavezKarbaran.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkcmbMajavezKarbaran.Size = new System.Drawing.Size(474, 32);
            this.chkcmbMajavezKarbaran.TabIndex = 1;
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
            this.btnCodeJadid.Visible = false;
            // 
            // btnSabtBadi
            // 
            this.btnSabtBadi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBadi.ImageOptions.Image")));
            this.btnSabtBadi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSabtBadi.ImageOptions.SvgImage")));
            this.btnSabtBadi.Location = new System.Drawing.Point(545, 152);
            this.btnSabtBadi.Name = "btnSabtBadi";
            this.btnSabtBadi.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBadi.TabIndex = 0;
            this.btnSabtBadi.Text = "ثبت و بعدی";
            this.btnSabtBadi.Click += new System.EventHandler(this.btnSabtBadi_Click);
            // 
            // btnSabtBastan
            // 
            this.btnSabtBastan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSabtBastan.ImageOptions.Image")));
            this.btnSabtBastan.Location = new System.Drawing.Point(157, 150);
            this.btnSabtBastan.Name = "btnSabtBastan";
            this.btnSabtBastan.Size = new System.Drawing.Size(135, 38);
            this.btnSabtBastan.TabIndex = 1;
            this.btnSabtBastan.Text = "ثبت و بستن";
            this.btnSabtBastan.Click += new System.EventHandler(this.btnSabtBastan_Click);
            // 
            // FrmSedMajmoeha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 198);
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
            this.Text = " ثبت مجتمع یا مجموعه های زنجیره ای";
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbMajavezKarbaran.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtcode;
        public DevExpress.XtraEditors.TextEdit txtName;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCodeJadid;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbMajavezKarbaran;
        public DevExpress.XtraEditors.SimpleButton btnSabtBadi;
        public DevExpress.XtraEditors.SimpleButton btnSabtBastan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}