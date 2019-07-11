namespace SystemManagement.UsersSystem
{
    partial class FrmAccesslevelCodingHesabdari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccesslevelCodingHesabdari));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.treeListCodingHesabdari = new DevExpress.XtraTreeList.TreeList();
            this.colLevelName2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKeyId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHesabGroupId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHesabColId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHesabMoinId2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.epAccessLevelCodingHesabdarisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.cmbUsersList = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.msUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.chkSelectAll = new DevExpress.XtraBars.BarCheckItem();
            this.chkOpenClose = new DevExpress.XtraBars.BarCheckItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.lblUserId = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCodingHesabdari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccessLevelCodingHesabdarisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListCodingHesabdari
            // 
            this.treeListCodingHesabdari.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colLevelName2,
            this.colKeyId2,
            this.colId2,
            this.colParentId2,
            this.colHesabGroupId2,
            this.colHesabColId2,
            this.colHesabMoinId2,
            this.colIsActive2});
            this.treeListCodingHesabdari.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListCodingHesabdari.DataSource = this.epAccessLevelCodingHesabdarisBindingSource;
            this.treeListCodingHesabdari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListCodingHesabdari.KeyFieldName = "KeyId";
            this.treeListCodingHesabdari.Location = new System.Drawing.Point(0, 60);
            this.treeListCodingHesabdari.Margin = new System.Windows.Forms.Padding(4);
            this.treeListCodingHesabdari.MinWidth = 24;
            this.treeListCodingHesabdari.Name = "treeListCodingHesabdari";
            this.treeListCodingHesabdari.OptionsBehavior.Editable = false;
            this.treeListCodingHesabdari.OptionsFilter.ExpandNodesOnFiltering = true;
            this.treeListCodingHesabdari.OptionsSelection.MultiSelect = true;
            this.treeListCodingHesabdari.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeListCodingHesabdari.OptionsView.ShowAutoFilterRow = true;
            this.treeListCodingHesabdari.OptionsView.ShowHorzLines = false;
            this.treeListCodingHesabdari.OptionsView.ShowIndicator = false;
            this.treeListCodingHesabdari.ParentFieldName = "ParentId";
            this.treeListCodingHesabdari.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeListCodingHesabdari.Size = new System.Drawing.Size(1495, 601);
            this.treeListCodingHesabdari.TabIndex = 37;
            this.treeListCodingHesabdari.TreeLevelWidth = 31;
            this.treeListCodingHesabdari.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            this.treeListCodingHesabdari.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListCodingHesabdari_AfterCheckNode);
            // 
            // colLevelName2
            // 
            this.colLevelName2.AppearanceCell.Options.UseTextOptions = true;
            this.colLevelName2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLevelName2.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevelName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelName2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLevelName2.Caption = "نام سطوح کدینگ حسابداری (گروه،کل،معین) ";
            this.colLevelName2.FieldName = "LevelName";
            this.colLevelName2.MaxWidth = 856;
            this.colLevelName2.MinWidth = 24;
            this.colLevelName2.Name = "colLevelName2";
            this.colLevelName2.Visible = true;
            this.colLevelName2.VisibleIndex = 0;
            this.colLevelName2.Width = 856;
            // 
            // colKeyId2
            // 
            this.colKeyId2.AppearanceCell.Options.UseTextOptions = true;
            this.colKeyId2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKeyId2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colKeyId2.AppearanceHeader.Options.UseTextOptions = true;
            this.colKeyId2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKeyId2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colKeyId2.Caption = "کد";
            this.colKeyId2.FieldName = "KeyId";
            this.colKeyId2.MaxWidth = 159;
            this.colKeyId2.MinWidth = 24;
            this.colKeyId2.Name = "colKeyId2";
            this.colKeyId2.Visible = true;
            this.colKeyId2.VisibleIndex = 1;
            this.colKeyId2.Width = 159;
            // 
            // colId2
            // 
            this.colId2.FieldName = "Id";
            this.colId2.MinWidth = 24;
            this.colId2.Name = "colId2";
            this.colId2.Width = 92;
            // 
            // colParentId2
            // 
            this.colParentId2.FieldName = "ParentId";
            this.colParentId2.MinWidth = 24;
            this.colParentId2.Name = "colParentId2";
            this.colParentId2.Width = 92;
            // 
            // colHesabGroupId2
            // 
            this.colHesabGroupId2.FieldName = "HesabGroupId";
            this.colHesabGroupId2.MinWidth = 24;
            this.colHesabGroupId2.Name = "colHesabGroupId2";
            this.colHesabGroupId2.Width = 92;
            // 
            // colHesabColId2
            // 
            this.colHesabColId2.FieldName = "HesabColId";
            this.colHesabColId2.MinWidth = 24;
            this.colHesabColId2.Name = "colHesabColId2";
            this.colHesabColId2.Width = 92;
            // 
            // colHesabMoinId2
            // 
            this.colHesabMoinId2.FieldName = "HesabMoinId";
            this.colHesabMoinId2.MinWidth = 24;
            this.colHesabMoinId2.Name = "colHesabMoinId2";
            this.colHesabMoinId2.Width = 92;
            // 
            // colIsActive2
            // 
            this.colIsActive2.FieldName = "IsActive";
            this.colIsActive2.MinWidth = 24;
            this.colIsActive2.Name = "colIsActive2";
            this.colIsActive2.Width = 92;
            // 
            // epAccessLevelCodingHesabdarisBindingSource
            // 
            this.epAccessLevelCodingHesabdarisBindingSource.DataSource = typeof(DBHesabdari_PG.EpAccessLevelCodingHesabdari);
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.CloseButtonAffectAllTabs = false;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmbUsersList,
            this.barStaticItem1,
            this.btnPrintPreview,
            this.btnSave,
            this.chkSelectAll,
            this.chkOpenClose});
            this.barManager1.MaxItemId = 39;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemTextEdit2,
            this.repositoryItemCheckEdit3});
            this.barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(88, 153);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmbUsersList),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkSelectAll, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkOpenClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.MinHeight = 60;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "نام کاربر";
            this.barStaticItem1.Id = 17;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // cmbUsersList
            // 
            this.cmbUsersList.Edit = this.repositoryItemLookUpEdit1;
            this.cmbUsersList.EditWidth = 250;
            this.cmbUsersList.Id = 9;
            this.cmbUsersList.Name = "cmbUsersList";
            this.cmbUsersList.EditValueChanged += new System.EventHandler(this.cmbUsersList_EditValueChanged);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MsUserId", "آیدی", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نام کاربر", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.msUserBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.DropDownRows = 10;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "MsUserId";
            // 
            // msUserBindingSource
            // 
            this.msUserBindingSource.DataSource = typeof(DBHesabdari_PG.MsUser);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "ذخیره کردن";
            this.btnSave.Id = 34;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            toolTipTitleItem1.Text = "F2";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSave.SuperTip = superToolTip1;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Caption = "انتخاب  همه گزینه ها";
            this.chkSelectAll.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.AfterText;
            this.chkSelectAll.Id = 37;
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkOpenClose
            // 
            this.chkOpenClose.Caption = "گسترش همه گزینه ها";
            this.chkOpenClose.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.AfterText;
            this.chkOpenClose.Id = 38;
            this.chkOpenClose.Name = "chkOpenClose";
            this.chkOpenClose.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkOpenClose_CheckedChanged);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "پیش نمایش چاپ";
            this.btnPrintPreview.Id = 31;
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.btnPrintPreview.Name = "btnPrintPreview";
            toolTipTitleItem2.Text = "F9";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnPrintPreview.SuperTip = superToolTip2;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.barDockControlTop.Size = new System.Drawing.Size(1495, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.barDockControlBottom.Size = new System.Drawing.Size(1495, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 601);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1495, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 601);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = this.repositoryItemLookUpEdit1;
            this.barEditItem1.EditWidth = 250;
            this.barEditItem1.Id = 9;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(15, 48);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(85, 31);
            this.lblUserId.TabIndex = 30;
            this.lblUserId.Text = "آیدی  کاربر";
            this.lblUserId.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(15, 87);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(61, 31);
            this.lblUserName.TabIndex = 31;
            this.lblUserName.Text = "نام کاربر";
            this.lblUserName.Visible = false;
            // 
            // FrmAccesslevelCodingHesabdari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 661);
            this.Controls.Add(this.treeListCodingHesabdari);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAccesslevelCodingHesabdari";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "دسترسی کاربران به کدینگ حسابداری (گروه،کل،معین";
            this.Load += new System.EventHandler(this.FrmAccesslevelCodingHesabdari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListCodingHesabdari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccessLevelCodingHesabdarisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem cmbUsersList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarCheckItem chkSelectAll;
        private DevExpress.XtraBars.BarCheckItem chkOpenClose;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraEditors.LabelControl lblUserId;
        public DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraTreeList.TreeList treeListCodingHesabdari;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLevelName2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKeyId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHesabGroupId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHesabColId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHesabMoinId2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive2;
        private System.Windows.Forms.BindingSource epAccessLevelCodingHesabdarisBindingSource;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private System.Windows.Forms.BindingSource msUserBindingSource;
    }
}