namespace AnbarVaKala.Tanzimat
{
    partial class FrmTanzimatAnbarVKala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTanzimatAnbarVKala));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colLevelName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsSetAllUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colR_MsUser_B_TzTanzimatSystems = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKeyId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tzTanzimatSystemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblUserId = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAllUser = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.msUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAllUser = new DevExpress.XtraEditors.SimpleButton();
            this.lblUsersName = new DevExpress.XtraEditors.LabelControl();
            this.chkIsSetAllUser = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tzTanzimatSystemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAllUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSetAllUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Controls.Add(this.lblUserName);
            this.panelControl1.Controls.Add(this.lblUserId);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1318, 616);
            this.panelControl1.TabIndex = 36;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colLevelName,
            this.colIsSetAllUser,
            this.colR_MsUser_B_TzTanzimatSystems,
            this.colKeyId,
            this.colParentId});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.DataSource = this.tzTanzimatSystemsBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.IndicatorWidth = 60;
            this.treeList1.KeyFieldName = "KeyId";
            this.treeList1.Location = new System.Drawing.Point(2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsSelection.MultiSelect = true;
            this.treeList1.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeList1.Size = new System.Drawing.Size(1314, 612);
            this.treeList1.TabIndex = 28;
            this.treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            this.treeList1.RowCellClick += new DevExpress.XtraTreeList.RowCellClickEventHandler(this.treeList1_RowCellClick);
            this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            this.treeList1.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList1_BeforeCheckNode);
            this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
            this.treeList1.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeList1_CustomDrawNodeIndicator);
            // 
            // colLevelName
            // 
            this.colLevelName.AppearanceCell.Options.UseTextOptions = true;
            this.colLevelName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLevelName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevelName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLevelName.Caption = "تنظیمات مربوط به انبار وکالا";
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 0;
            this.colLevelName.Width = 914;
            // 
            // colIsSetAllUser
            // 
            this.colIsSetAllUser.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSetAllUser.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsSetAllUser.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSetAllUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSetAllUser.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsSetAllUser.Caption = "اعمال به همه کاربران";
            this.colIsSetAllUser.FieldName = "IsSetAllUser";
            this.colIsSetAllUser.MaxWidth = 160;
            this.colIsSetAllUser.MinWidth = 160;
            this.colIsSetAllUser.Name = "colIsSetAllUser";
            this.colIsSetAllUser.Visible = true;
            this.colIsSetAllUser.VisibleIndex = 1;
            this.colIsSetAllUser.Width = 160;
            // 
            // colR_MsUser_B_TzTanzimatSystems
            // 
            this.colR_MsUser_B_TzTanzimatSystems.FieldName = "R_MsUser_B_TzTanzimatSystems";
            this.colR_MsUser_B_TzTanzimatSystems.Name = "colR_MsUser_B_TzTanzimatSystems";
            // 
            // colKeyId
            // 
            this.colKeyId.FieldName = "KeyId";
            this.colKeyId.Name = "colKeyId";
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            // 
            // tzTanzimatSystemsBindingSource
            // 
            this.tzTanzimatSystemsBindingSource.DataSource = typeof(DBHesabdari_PG.Models.Tz.TzTanzimatSystem);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(13, 45);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 27);
            this.lblUserName.TabIndex = 27;
            this.lblUserName.Text = "نام کاربر";
            this.lblUserName.Visible = false;
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(13, 12);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(72, 27);
            this.lblUserId.TabIndex = 26;
            this.lblUserId.Text = "آیدی  کاربر";
            this.lblUserId.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.cmbAllUser);
            this.panelControl2.Controls.Add(this.btnAllUser);
            this.panelControl2.Controls.Add(this.lblUsersName);
            this.panelControl2.Controls.Add(this.chkIsSetAllUser);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 616);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1318, 47);
            this.panelControl2.TabIndex = 37;
            this.panelControl2.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(52, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 40);
            this.btnSave.TabIndex = 215;
            this.btnSave.Text = "ذخیره تغییرات";
            this.btnSave.ToolTip = "ذخیره";
            this.btnSave.ToolTipTitle = "F5";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbAllUser
            // 
            this.cmbAllUser.AllowDrop = true;
            this.cmbAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAllUser.EditValue = "";
            this.cmbAllUser.Enabled = false;
            this.cmbAllUser.EnterMoveNextControl = true;
            this.cmbAllUser.Location = new System.Drawing.Point(277, 7);
            this.cmbAllUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbAllUser.Name = "cmbAllUser";
            this.cmbAllUser.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cmbAllUser.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.cmbAllUser.Properties.Appearance.Options.UseForeColor = true;
            this.cmbAllUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAllUser.Properties.DataSource = this.msUsersBindingSource;
            this.cmbAllUser.Properties.DisplayMember = "Name";
            this.cmbAllUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbAllUser.Properties.ValueMember = "MsUserId";
            this.cmbAllUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAllUser.Size = new System.Drawing.Size(697, 34);
            this.cmbAllUser.TabIndex = 212;
            // 
            // msUsersBindingSource
            // 
            this.msUsersBindingSource.DataSource = typeof(DBHesabdari_PG.Models.Ms.SystemUsers.MsUser);
            // 
            // btnAllUser
            // 
            this.btnAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllUser.Enabled = false;
            this.btnAllUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAllUser.ImageOptions.SvgImage")));
            this.btnAllUser.Location = new System.Drawing.Point(223, 10);
            this.btnAllUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAllUser.Name = "btnAllUser";
            this.btnAllUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAllUser.Size = new System.Drawing.Size(46, 32);
            this.btnAllUser.TabIndex = 214;
            this.btnAllUser.TabStop = false;
            this.btnAllUser.ToolTipTitle = "بعدی";
            // 
            // lblUsersName
            // 
            this.lblUsersName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsersName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.lblUsersName.Appearance.Options.UseForeColor = true;
            this.lblUsersName.AutoEllipsis = true;
            this.lblUsersName.Enabled = false;
            this.lblUsersName.Location = new System.Drawing.Point(982, 11);
            this.lblUsersName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblUsersName.Name = "lblUsersName";
            this.lblUsersName.Size = new System.Drawing.Size(69, 27);
            this.lblUsersName.TabIndex = 213;
            this.lblUsersName.Text = "نام کاربران";
            // 
            // chkIsSetAllUser
            // 
            this.chkIsSetAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsSetAllUser.EditValue = true;
            this.chkIsSetAllUser.EnterMoveNextControl = true;
            this.chkIsSetAllUser.Location = new System.Drawing.Point(1097, 6);
            this.chkIsSetAllUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkIsSetAllUser.Name = "chkIsSetAllUser";
            this.chkIsSetAllUser.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.chkIsSetAllUser.Properties.Appearance.Options.UseForeColor = true;
            this.chkIsSetAllUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsSetAllUser.Properties.Caption = "اعمال به همه کاربران";
            this.chkIsSetAllUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsSetAllUser.Size = new System.Drawing.Size(212, 35);
            this.chkIsSetAllUser.TabIndex = 9;
            this.chkIsSetAllUser.CheckedChanged += new System.EventHandler(this.chkIsSetAllUser_CheckedChanged);
            // 
            // FrmTanzimatAnbarVKala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 663);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmTanzimatAnbarVKala.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmTanzimatAnbarVKala";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات انبار و کالا";
            this.Load += new System.EventHandler(this.FrmTanzimatAnbarVKala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tzTanzimatSystemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAllUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSetAllUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.LabelControl lblUserName;
        public DevExpress.XtraEditors.LabelControl lblUserId;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLevelName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsSetAllUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colR_MsUser_B_TzTanzimatSystems;
        private System.Windows.Forms.BindingSource tzTanzimatSystemsBindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.CheckEdit chkIsSetAllUser;
        public DevExpress.XtraEditors.CheckedComboBoxEdit cmbAllUser;
        private System.Windows.Forms.BindingSource msUsersBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAllUser;
        private DevExpress.XtraEditors.LabelControl lblUsersName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKeyId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}