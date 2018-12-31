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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShoabatCed));
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.txtKind = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKindDefinition = new DevExpress.XtraEditors.TextEdit();
            this.chkcmbPermissiveUsers = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbVahedhaList = new DevExpress.XtraEditors.LookUpEdit();
            this.msVahedsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMajmoehaList = new DevExpress.XtraEditors.LookUpEdit();
            this.msMajmoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewCode = new DevExpress.XtraEditors.SimpleButton();
            this.txtVahedCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateNext = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.msUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKindDefinition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbPermissiveUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVahedhaList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msVahedsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMajmoehaList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msMajmoesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVahedCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msUsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(366, 83);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "f0";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 3;
            this.txtCode.Size = new System.Drawing.Size(123, 32);
            this.txtCode.TabIndex = 4;
            this.txtCode.TabStop = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 122);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(483, 32);
            this.txtName.TabIndex = 2;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 46);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateClose
            // 
            this.btnCreateClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateClose.ImageOptions.Image")));
            this.btnCreateClose.Location = new System.Drawing.Point(151, 5);
            this.btnCreateClose.Name = "btnCreateClose";
            this.btnCreateClose.Size = new System.Drawing.Size(166, 46);
            this.btnCreateClose.TabIndex = 1;
            this.btnCreateClose.Text = "ایجاد و بستن";
            this.btnCreateClose.Click += new System.EventHandler(this.btnCreateClose_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(6, 159);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(54, 33);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(6, 83);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.chkcmbPermissiveUsers);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.cmbVahedhaList);
            this.panelControl1.Controls.Add(this.cmbMajmoehaList);
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtVahedCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(682, 555);
            this.panelControl1.TabIndex = 17;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.panelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 198);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(678, 355);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "سایر مشخصات";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(674, 283);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnCreate);
            this.panelControl3.Controls.Add(this.btnEdit);
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Controls.Add(this.txtKind);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.txtKindDefinition);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 32);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(674, 38);
            this.panelControl3.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.ImageOptions.Image")));
            this.btnCreate.Location = new System.Drawing.Point(68, 9);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(25, 21);
            this.btnCreate.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(37, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 21);
            this.btnEdit.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(6, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 21);
            this.btnDelete.TabIndex = 1;
            // 
            // txtKind
            // 
            this.txtKind.Location = new System.Drawing.Point(491, 2);
            this.txtKind.Name = "txtKind";
            this.txtKind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtKind.Properties.NullText = "";
            this.txtKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKind.Size = new System.Drawing.Size(142, 32);
            this.txtKind.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(639, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نوع ";
            // 
            // txtKindDefinition
            // 
            this.txtKindDefinition.Location = new System.Drawing.Point(98, 2);
            this.txtKindDefinition.Name = "txtKindDefinition";
            this.txtKindDefinition.Properties.MaxLength = 50;
            this.txtKindDefinition.Size = new System.Drawing.Size(386, 32);
            this.txtKindDefinition.TabIndex = 2;
            // 
            // chkcmbPermissiveUsers
            // 
            this.chkcmbPermissiveUsers.Location = new System.Drawing.Point(66, 160);
            this.chkcmbPermissiveUsers.Name = "chkcmbPermissiveUsers";
            this.chkcmbPermissiveUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbPermissiveUsers.Properties.DataSource = this.msUsersBindingSource;
            this.chkcmbPermissiveUsers.Properties.DisplayMember = "UserName";
            this.chkcmbPermissiveUsers.Properties.ValueMember = "MsUserId";
            this.chkcmbPermissiveUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkcmbPermissiveUsers.Size = new System.Drawing.Size(423, 32);
            this.chkcmbPermissiveUsers.TabIndex = 3;
            this.chkcmbPermissiveUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(495, 163);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 25);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "کاربران مجاز به ثبت عملیات";
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
            // cmbVahedhaList
            // 
            this.cmbVahedhaList.Location = new System.Drawing.Point(4, 45);
            this.cmbVahedhaList.Name = "cmbVahedhaList";
            this.cmbVahedhaList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVahedhaList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MsVahedId", "آیدی", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VahedName", "نام واحد تجاری یا خدماتی را انتخاب کنید")});
            this.cmbVahedhaList.Properties.DataSource = this.msVahedsBindingSource;
            this.cmbVahedhaList.Properties.DisplayMember = "VahedName";
            this.cmbVahedhaList.Properties.NullText = "";
            this.cmbVahedhaList.Properties.ValueMember = "MsVahedId";
            this.cmbVahedhaList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbVahedhaList.Size = new System.Drawing.Size(484, 32);
            this.cmbVahedhaList.TabIndex = 1;
            this.cmbVahedhaList.EditValueChanged += new System.EventHandler(this.cmbVahedhaList_EditValueChanged);
            this.cmbVahedhaList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // msVahedsBindingSource
            // 
            this.msVahedsBindingSource.DataSource = typeof(Hesabdari_TG_N1_V1.Models.MS.DafaterMali.MsVahed);
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
            // msMajmoesBindingSource
            // 
            this.msMajmoesBindingSource.DataSource = typeof(Hesabdari_TG_N1_V1.Models.MS.DafaterMali.MsMajmoe);
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCode.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(125, 81);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(114, 35);
            this.btnNewCode.TabIndex = 6;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtVahedCode
            // 
            this.txtVahedCode.EditValue = "کد مجموعه و واحد";
            this.txtVahedCode.Location = new System.Drawing.Point(245, 83);
            this.txtVahedCode.Name = "txtVahedCode";
            this.txtVahedCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtVahedCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtVahedCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtVahedCode.Properties.Mask.EditMask = "f0";
            this.txtVahedCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVahedCode.Properties.MaxLength = 3;
            this.txtVahedCode.Properties.NullText = "کد مجموعه";
            this.txtVahedCode.Properties.ReadOnly = true;
            this.txtVahedCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVahedCode.Size = new System.Drawing.Size(115, 32);
            this.txtVahedCode.TabIndex = 5;
            this.txtVahedCode.TabStop = false;
            this.txtVahedCode.Visible = false;
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
            // btnCreateNext
            // 
            this.btnCreateNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNext.ImageOptions.Image")));
            this.btnCreateNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreateNext.ImageOptions.SvgImage")));
            this.btnCreateNext.Location = new System.Drawing.Point(542, 5);
            this.btnCreateNext.Name = "btnCreateNext";
            this.btnCreateNext.Size = new System.Drawing.Size(135, 46);
            this.btnCreateNext.TabIndex = 0;
            this.btnCreateNext.Text = "ایجاد و بعدی";
            this.btnCreateNext.Click += new System.EventHandler(this.btnCreateNext_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCreateClose);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnCreateNext);
            this.panelControl2.Location = new System.Drawing.Point(12, 573);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(682, 56);
            this.panelControl2.TabIndex = 18;
            // 
            // msUsersBindingSource
            // 
            this.msUsersBindingSource.DataSource = typeof(Hesabdari_TG_N1_V1.Models.MS.UsersSystem.MsUser);
            // 
            // FrmShoabatCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 641);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShoabatCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد شعبات واحدها";
            this.Load += new System.EventHandler(this.FrmShobehaCed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKindDefinition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbPermissiveUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVahedhaList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msVahedsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMajmoehaList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msMajmoesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVahedCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbVahedhaList;
        private DevExpress.XtraEditors.LookUpEdit cmbMajmoehaList;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbPermissiveUsers;
        private DevExpress.XtraEditors.SimpleButton btnNewCode;
        public DevExpress.XtraEditors.TextEdit txtVahedCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.SimpleButton btnCreateNext;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LookUpEdit txtKind;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtKindDefinition;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource msMajmoesBindingSource;
        private System.Windows.Forms.BindingSource msVahedsBindingSource;
        private System.Windows.Forms.BindingSource msUsersBindingSource;
    }
}