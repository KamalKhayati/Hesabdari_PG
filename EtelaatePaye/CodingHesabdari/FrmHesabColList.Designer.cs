namespace EtelaatePaye.CodingHesabdari
{
    partial class FrmHesabColList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHesabColList));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.colSharhHesab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahiatHesab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEpHesabGroup1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndexMahiatHesab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.epHesabColsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisplyActiveList = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisplyNotActiveList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnListPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmkanat = new DevExpress.XtraBars.BarSubItem();
            this.btnAdvancedSearch = new DevExpress.XtraBars.BarCheckItem();
            this.btnSharhHesab = new DevExpress.XtraBars.BarCheckItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.lblUserId = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epHesabColsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(22, 438);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(50, 25);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "نام کاربر";
            this.lblUserName.Visible = false;
            // 
            // colSharhHesab
            // 
            this.colSharhHesab.AppearanceCell.Options.UseTextOptions = true;
            this.colSharhHesab.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhHesab.AppearanceHeader.Options.UseTextOptions = true;
            this.colSharhHesab.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSharhHesab.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSharhHesab.Caption = "تشریح حساب";
            this.colSharhHesab.FieldName = "SharhHesab";
            this.colSharhHesab.MinWidth = 19;
            this.colSharhHesab.Name = "colSharhHesab";
            this.colSharhHesab.Width = 400;
            // 
            // colIsActive
            // 
            this.colIsActive.AppearanceCell.Options.UseTextOptions = true;
            this.colIsActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsActive.Caption = "فعال";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.MinWidth = 19;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 5;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.Caption = "نام حساب کل";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 19;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 400;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.Caption = "کد حساب";
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 19;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 100;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 19;
            this.colId.Name = "colId";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.Line,
            this.colCode,
            this.colName,
            this.colGroupName,
            this.colMahiatHesab,
            this.colIsActive,
            this.colSharhHesab,
            this.colGroupId,
            this.colEpHesabGroup1,
            this.colIndexMahiatHesab});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Line
            // 
            this.Line.AppearanceCell.Options.UseTextOptions = true;
            this.Line.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Line.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Line.AppearanceHeader.Options.UseTextOptions = true;
            this.Line.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Line.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Line.Caption = "ردیف";
            this.Line.FieldName = "Line";
            this.Line.MinWidth = 19;
            this.Line.Name = "Line";
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 60;
            // 
            // colGroupName
            // 
            this.colGroupName.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroupName.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroupName.Caption = "نام حساب گروه";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.MinWidth = 19;
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 3;
            this.colGroupName.Width = 320;
            // 
            // colMahiatHesab
            // 
            this.colMahiatHesab.AppearanceCell.Options.UseTextOptions = true;
            this.colMahiatHesab.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMahiatHesab.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMahiatHesab.AppearanceHeader.Options.UseTextOptions = true;
            this.colMahiatHesab.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMahiatHesab.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMahiatHesab.Caption = "ماهیت حساب";
            this.colMahiatHesab.FieldName = "MahiatHesab";
            this.colMahiatHesab.MinWidth = 19;
            this.colMahiatHesab.Name = "colMahiatHesab";
            this.colMahiatHesab.Visible = true;
            this.colMahiatHesab.VisibleIndex = 4;
            this.colMahiatHesab.Width = 100;
            // 
            // colGroupId
            // 
            this.colGroupId.FieldName = "GroupId";
            this.colGroupId.MinWidth = 19;
            this.colGroupId.Name = "colGroupId";
            // 
            // colEpHesabGroup1
            // 
            this.colEpHesabGroup1.FieldName = "EpHesabGroup1";
            this.colEpHesabGroup1.MinWidth = 19;
            this.colEpHesabGroup1.Name = "colEpHesabGroup1";
            // 
            // colIndexMahiatHesab
            // 
            this.colIndexMahiatHesab.FieldName = "IndexMahiatHesab";
            this.colIndexMahiatHesab.Name = "colIndexMahiatHesab";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.epHesabColsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1223, 473);
            this.gridControl1.TabIndex = 24;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // epHesabColsBindingSource
            // 
            this.epHesabColsBindingSource.DataSource = typeof(DBHesabdari_TG.EpHesabCol);
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
            this.btnCreate,
            this.btnEdit,
            this.btnDelete,
            this.btnDisplyActiveList,
            this.btnDisplyNotActiveList,
            this.btnPrintPreview,
            this.btnListPrint,
            this.btnEmkanat,
            this.btnAdvancedSearch,
            this.btnSharhHesab});
            this.barManager1.MaxItemId = 12;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCreate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDisplyActiveList, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDisplyNotActiveList, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnListPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEmkanat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.MinHeight = 60;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnCreate
            // 
            this.btnCreate.Caption = "ایجاد کردن";
            this.btnCreate.Id = 0;
            this.btnCreate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.ImageOptions.Image")));
            this.btnCreate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.btnCreate.Name = "btnCreate";
            toolTipTitleItem1.Text = "F4";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnCreate.SuperTip = superToolTip1;
            this.btnCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreate_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "ویرایش کردن";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnEdit.Name = "btnEdit";
            toolTipTitleItem2.Text = "F5";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnEdit.SuperTip = superToolTip2;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "حذف کردن";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.btnDelete.Name = "btnDelete";
            toolTipTitleItem3.Text = "F6";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnDelete.SuperTip = superToolTip3;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnDisplyActiveList
            // 
            this.btnDisplyActiveList.Caption = "نمایش لیست (فعال)";
            this.btnDisplyActiveList.Id = 3;
            this.btnDisplyActiveList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplyActiveList.ImageOptions.Image")));
            this.btnDisplyActiveList.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.btnDisplyActiveList.Name = "btnDisplyActiveList";
            toolTipTitleItem4.Text = "F7";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnDisplyActiveList.SuperTip = superToolTip4;
            this.btnDisplyActiveList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisplyActiveList_ItemClick);
            // 
            // btnDisplyNotActiveList
            // 
            this.btnDisplyNotActiveList.Caption = "نمایش لیست (غیرفعال)";
            this.btnDisplyNotActiveList.Id = 4;
            this.btnDisplyNotActiveList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplyNotActiveList.ImageOptions.Image")));
            this.btnDisplyNotActiveList.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            this.btnDisplyNotActiveList.Name = "btnDisplyNotActiveList";
            toolTipTitleItem5.Text = "F8";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnDisplyNotActiveList.SuperTip = superToolTip5;
            this.btnDisplyNotActiveList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisplyNotActiveList_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "پیش نمایش چاپ";
            this.btnPrintPreview.Id = 5;
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.btnPrintPreview.Name = "btnPrintPreview";
            toolTipTitleItem6.Text = "F9";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnPrintPreview.SuperTip = superToolTip6;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnListPrint
            // 
            this.btnListPrint.Caption = "چاپ لیست";
            this.btnListPrint.Id = 6;
            this.btnListPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListPrint.ImageOptions.Image")));
            this.btnListPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F10);
            this.btnListPrint.Name = "btnListPrint";
            toolTipTitleItem7.Text = "F10";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnListPrint.SuperTip = superToolTip7;
            // 
            // btnEmkanat
            // 
            this.btnEmkanat.Caption = "امکانات";
            this.btnEmkanat.Id = 7;
            this.btnEmkanat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmkanat.ImageOptions.Image")));
            this.btnEmkanat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdvancedSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSharhHesab)});
            this.btnEmkanat.Name = "btnEmkanat";
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.Caption = "جستجوی پیشرفته";
            this.btnAdvancedSearch.Id = 10;
            this.btnAdvancedSearch.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdvancedSearch_CheckedChanged);
            // 
            // btnSharhHesab
            // 
            this.btnSharhHesab.Caption = "توضیح یا تشریح حساب";
            this.btnSharhHesab.Id = 11;
            this.btnSharhHesab.Name = "btnSharhHesab";
            this.btnSharhHesab.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSharhHesab_CheckedChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1223, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 533);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1223, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1223, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 473);
            // 
            // bar4
            // 
            this.bar4.BarName = "Tools";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(88, 153);
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DisableClose = true;
            this.bar4.OptionsBar.DisableCustomization = true;
            this.bar4.OptionsBar.MinHeight = 60;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Tools";
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(22, 408);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(69, 25);
            this.lblUserId.TabIndex = 25;
            this.lblUserId.Text = "آیدی  کاربر";
            this.lblUserId.Visible = false;
            // 
            // FrmHesabColList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 533);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmHesabColList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست حسابهای کل";
            this.Load += new System.EventHandler(this.FrmHesabColList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmHesabColList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epHesabColsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colSharhHesab;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnDisplyActiveList;
        private DevExpress.XtraBars.BarButtonItem btnDisplyNotActiveList;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem btnListPrint;
        private DevExpress.XtraBars.BarSubItem btnEmkanat;
        private DevExpress.XtraBars.BarCheckItem btnAdvancedSearch;
        private DevExpress.XtraBars.BarCheckItem btnSharhHesab;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraEditors.LabelControl lblUserId;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupId;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
        private DevExpress.XtraGrid.Columns.GridColumn colMahiatHesab;
        private DevExpress.XtraGrid.Columns.GridColumn colEpHesabGroup1;
        private System.Windows.Forms.BindingSource epHesabColsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIndexMahiatHesab;
    }
}