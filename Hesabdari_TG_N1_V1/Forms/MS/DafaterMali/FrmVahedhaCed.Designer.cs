namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    partial class FrmVahedhaCed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVahedhaCed));
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMajmoehaList = new DevExpress.XtraEditors.LookUpEdit();
            this.chkcmbPermissiveUsers = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnNewCode = new DevExpress.XtraEditors.SimpleButton();
            this.txtMajmoeCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateNext = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.msMajmoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMajmoehaList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbPermissiveUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMajmoeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msMajmoesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(366, 45);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "f0";
            this.txtCode.Properties.MaxLength = 3;
            this.txtCode.Size = new System.Drawing.Size(123, 32);
            this.txtCode.TabIndex = 1;
            this.txtCode.TabStop = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 84);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(483, 32);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateClose
            // 
            this.btnCreateClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateClose.ImageOptions.Image")));
            this.btnCreateClose.Location = new System.Drawing.Point(151, 5);
            this.btnCreateClose.Name = "btnCreateClose";
            this.btnCreateClose.Size = new System.Drawing.Size(160, 38);
            this.btnCreateClose.TabIndex = 1;
            this.btnCreateClose.Text = "ایجاد و بستن";
            this.btnCreateClose.Click += new System.EventHandler(this.btnCreateClose_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(495, 166);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(54, 33);
            this.chkIsActive.TabIndex = 3;
            this.chkIsActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(6, 45);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(108, 32);
            this.txtId.TabIndex = 7;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(495, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(155, 32);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام مجتمع یا مجموعه (زنجیره ای)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(495, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cmbMajmoehaList);
            this.panelControl1.Controls.Add(this.chkcmbPermissiveUsers);
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtMajmoeCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(673, 210);
            this.panelControl1.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(492, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 25);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "کاربران مجاز به ثبت عملیات";
            // 
            // cmbMajmoehaList
            // 
            this.cmbMajmoehaList.Location = new System.Drawing.Point(5, 7);
            this.cmbMajmoehaList.Name = "cmbMajmoehaList";
            this.cmbMajmoehaList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMajmoehaList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MsMajmoeId", "آیدی", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MajmoeName", "نام مجتمع یا مجموعه را انتخاب کنید")});
            this.cmbMajmoehaList.Properties.DataSource = this.msMajmoesBindingSource;
            this.cmbMajmoehaList.Properties.DisplayMember = "MajmoeName";
            this.cmbMajmoehaList.Properties.NullText = "";
            this.cmbMajmoehaList.Properties.ValueMember = "MsMajmoeId";
            this.cmbMajmoehaList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMajmoehaList.Size = new System.Drawing.Size(484, 32);
            this.cmbMajmoehaList.TabIndex = 0;
            this.cmbMajmoehaList.EditValueChanged += new System.EventHandler(this.cmbListMajmoeha_EditValueChanged);
            this.cmbMajmoehaList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // chkcmbPermissiveUsers
            // 
            this.chkcmbPermissiveUsers.EditValue = "";
            this.chkcmbPermissiveUsers.Location = new System.Drawing.Point(6, 122);
            this.chkcmbPermissiveUsers.Name = "chkcmbPermissiveUsers";
            this.chkcmbPermissiveUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbPermissiveUsers.Properties.DataSource = this.msUsersBindingSource;
            this.chkcmbPermissiveUsers.Properties.DisplayMember = "UserName";
            this.chkcmbPermissiveUsers.Properties.ValueMember = "MsUserId";
            this.chkcmbPermissiveUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkcmbPermissiveUsers.Size = new System.Drawing.Size(483, 32);
            this.chkcmbPermissiveUsers.TabIndex = 2;
            this.chkcmbPermissiveUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCode.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(125, 43);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(114, 35);
            this.btnNewCode.TabIndex = 6;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtMajmoeCode
            // 
            this.txtMajmoeCode.Location = new System.Drawing.Point(245, 45);
            this.txtMajmoeCode.Name = "txtMajmoeCode";
            this.txtMajmoeCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMajmoeCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMajmoeCode.Properties.Mask.EditMask = "f0";
            this.txtMajmoeCode.Properties.MaxLength = 3;
            this.txtMajmoeCode.Properties.NullText = "کد مجموعه";
            this.txtMajmoeCode.Properties.ReadOnly = true;
            this.txtMajmoeCode.Size = new System.Drawing.Size(115, 32);
            this.txtMajmoeCode.TabIndex = 5;
            this.txtMajmoeCode.TabStop = false;
            this.txtMajmoeCode.Leave += new System.EventHandler(this.txtMajmoeCode_Leave);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(495, 87);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(167, 25);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "نام واحد تجاری / خدماتی";
            // 
            // btnCreateNext
            // 
            this.btnCreateNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNext.ImageOptions.Image")));
            this.btnCreateNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreateNext.ImageOptions.SvgImage")));
            this.btnCreateNext.Location = new System.Drawing.Point(530, 5);
            this.btnCreateNext.Name = "btnCreateNext";
            this.btnCreateNext.Size = new System.Drawing.Size(138, 38);
            this.btnCreateNext.TabIndex = 0;
            this.btnCreateNext.Text = "ایجاد و بعدی";
            this.btnCreateNext.Click += new System.EventHandler(this.btnCreateNext_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCreateClose);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnCreateNext);
            this.panelControl2.Location = new System.Drawing.Point(12, 228);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(673, 48);
            this.panelControl2.TabIndex = 14;
            // 
            // msMajmoesBindingSource
            // 
            this.msMajmoesBindingSource.DataSource = typeof(Hesabdari_TG_N1_V1.Models.MS.DafaterMali.MsMajmoe);
            // 
            // msUsersBindingSource
            // 
            this.msUsersBindingSource.DataSource = typeof(Hesabdari_TG_N1_V1.Models.MS.UsersSystem.MsUser);
            // 
            // FrmVahedhaCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 286);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVahedhaCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد واحدهای تجاری یا خدماتی";
            this.Load += new System.EventHandler(this.FrmVahedhaCed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMajmoehaList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbPermissiveUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMajmoeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msMajmoesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUsersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtCode;
        public DevExpress.XtraEditors.TextEdit txtName;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnCreateClose;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbPermissiveUsers;
        private DevExpress.XtraEditors.SimpleButton btnNewCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtMajmoeCode;
        public DevExpress.XtraEditors.SimpleButton btnCreateNext;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.BindingSource msUsersBindingSource;
        private System.Windows.Forms.BindingSource msMajmoesBindingSource;
        public DevExpress.XtraEditors.LookUpEdit cmbMajmoehaList;
    }
}