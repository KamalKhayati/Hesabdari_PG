namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    partial class FrmShoabatList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShoabatList));
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisplyActiveList = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisplyNotActiveList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnListPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmkanat = new DevExpress.XtraBars.BarSubItem();
            this.btnAdvancedSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.colMsShobeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShobeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShobeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShobeIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMsMajmoeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMajmoeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMsVahedId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVahedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMsVahed1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPermissiveUsers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRmsShobehaBmsUserhas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Line = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1085, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 447);
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
            this.btnSave,
            this.btnEdit,
            this.btnDelete,
            this.btnDisplyActiveList,
            this.btnDisplyNotActiveList,
            this.btnPrintPreview,
            this.btnListPrint,
            this.btnEmkanat,
            this.btnAdvancedSearch});
            this.barManager1.MaxItemId = 9;
            this.barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDisplyActiveList, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDisplyNotActiveList, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnListPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEmkanat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.MinHeight = 60;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "ایجاد کردن";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreate_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "ویرایش کردن";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "حذف کردن";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnDisplyActiveList
            // 
            this.btnDisplyActiveList.Caption = "نمایش لیست (فعال)";
            this.btnDisplyActiveList.Id = 3;
            this.btnDisplyActiveList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplyActiveList.ImageOptions.SvgImage")));
            this.btnDisplyActiveList.Name = "btnDisplyActiveList";
            this.btnDisplyActiveList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisplyActiveList_ItemClick);
            // 
            // btnDisplyNotActiveList
            // 
            this.btnDisplyNotActiveList.Caption = "نمایش لیست (غیرفعال)";
            this.btnDisplyNotActiveList.Id = 4;
            this.btnDisplyNotActiveList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplyNotActiveList.ImageOptions.SvgImage")));
            this.btnDisplyNotActiveList.Name = "btnDisplyNotActiveList";
            this.btnDisplyNotActiveList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisplyNotActiveList_ItemClick);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "پیش نمایش چاپ";
            this.btnPrintPreview.Id = 5;
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnListPrint
            // 
            this.btnListPrint.Caption = "چاپ لیست";
            this.btnListPrint.Id = 6;
            this.btnListPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnListPrint.ImageOptions.SvgImage")));
            this.btnListPrint.Name = "btnListPrint";
            // 
            // btnEmkanat
            // 
            this.btnEmkanat.Caption = "امکانات";
            this.btnEmkanat.Id = 7;
            this.btnEmkanat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEmkanat.ImageOptions.SvgImage")));
            this.btnEmkanat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdvancedSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.btnEmkanat.Name = "btnEmkanat";
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.Caption = "جستجوی پیشرفته";
            this.btnAdvancedSearch.Id = 8;
            this.btnAdvancedSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdvancedSearch.ImageOptions.SvgImage")));
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdvancedSearch_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1085, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 507);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1085, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 447);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.HorzLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.VertLine.BackColor2 = System.Drawing.Color.Yellow;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.Options.UseBorderColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMsShobeId,
            this.Line,
            this.colMajmoeName,
            this.colVahedName,
            this.colShobeCode,
            this.colShobeName,
            this.colShobeIsActive,
            this.colPermissiveUsers,
            this.colMsMajmoeId,
            this.colMsVahedId,
            this.colMsVahed1,
            this.colRmsShobehaBmsUserhas});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
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
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1085, 447);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // entityInstantFeedbackSource1
            // 
            this.entityInstantFeedbackSource1.DefaultSorting = "ShobeCode ASC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(Hesabdari_TG_N1_V1.Models.MS.DafaterMali.MsShobe);
            this.entityInstantFeedbackSource1.KeyExpression = "MsShobeId";
            // 
            // colMsShobeId
            // 
            this.colMsShobeId.Caption = "آیدی";
            this.colMsShobeId.FieldName = "MsShobeId";
            this.colMsShobeId.Name = "colMsShobeId";
            // 
            // colShobeCode
            // 
            this.colShobeCode.AppearanceCell.Options.UseTextOptions = true;
            this.colShobeCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShobeCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colShobeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShobeCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeCode.Caption = "کد";
            this.colShobeCode.FieldName = "ShobeCode";
            this.colShobeCode.Name = "colShobeCode";
            this.colShobeCode.Visible = true;
            this.colShobeCode.VisibleIndex = 3;
            this.colShobeCode.Width = 100;
            // 
            // colShobeName
            // 
            this.colShobeName.AppearanceCell.Options.UseTextOptions = true;
            this.colShobeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colShobeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShobeName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeName.Caption = "نام شعبه";
            this.colShobeName.FieldName = "ShobeName";
            this.colShobeName.Name = "colShobeName";
            this.colShobeName.Visible = true;
            this.colShobeName.VisibleIndex = 4;
            this.colShobeName.Width = 250;
            // 
            // colShobeIsActive
            // 
            this.colShobeIsActive.AppearanceCell.Options.UseTextOptions = true;
            this.colShobeIsActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShobeIsActive.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeIsActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colShobeIsActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShobeIsActive.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShobeIsActive.Caption = "فعال";
            this.colShobeIsActive.FieldName = "ShobeIsActive";
            this.colShobeIsActive.Name = "colShobeIsActive";
            this.colShobeIsActive.Visible = true;
            this.colShobeIsActive.VisibleIndex = 5;
            this.colShobeIsActive.Width = 60;
            // 
            // colMsMajmoeId
            // 
            this.colMsMajmoeId.Caption = "آیدی مجموعه";
            this.colMsMajmoeId.FieldName = "MsMajmoeId";
            this.colMsMajmoeId.Name = "colMsMajmoeId";
            // 
            // colMajmoeName
            // 
            this.colMajmoeName.AppearanceCell.Options.UseTextOptions = true;
            this.colMajmoeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMajmoeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMajmoeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMajmoeName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMajmoeName.Caption = "نام مجتمع / مجموعه";
            this.colMajmoeName.FieldName = "MajmoeName";
            this.colMajmoeName.Name = "colMajmoeName";
            this.colMajmoeName.Visible = true;
            this.colMajmoeName.VisibleIndex = 1;
            this.colMajmoeName.Width = 250;
            // 
            // colMsVahedId
            // 
            this.colMsVahedId.Caption = "آیدی واحد تجاری";
            this.colMsVahedId.FieldName = "MsVahedId";
            this.colMsVahedId.Name = "colMsVahedId";
            // 
            // colVahedName
            // 
            this.colVahedName.AppearanceCell.Options.UseTextOptions = true;
            this.colVahedName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVahedName.AppearanceHeader.Options.UseTextOptions = true;
            this.colVahedName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVahedName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVahedName.Caption = "نام واحد تجاری / خدماتی";
            this.colVahedName.FieldName = "VahedName";
            this.colVahedName.Name = "colVahedName";
            this.colVahedName.Visible = true;
            this.colVahedName.VisibleIndex = 2;
            this.colVahedName.Width = 250;
            // 
            // colMsVahed1
            // 
            this.colMsVahed1.FieldName = "MsVahed1";
            this.colMsVahed1.Name = "colMsVahed1";
            // 
            // colPermissiveUsers
            // 
            this.colPermissiveUsers.AppearanceCell.Options.UseTextOptions = true;
            this.colPermissiveUsers.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPermissiveUsers.AppearanceHeader.Options.UseTextOptions = true;
            this.colPermissiveUsers.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPermissiveUsers.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPermissiveUsers.Caption = "کاربران مجاز به ثبت عملیات";
            this.colPermissiveUsers.FieldName = "PermissiveUsers";
            this.colPermissiveUsers.Name = "colPermissiveUsers";
            this.colPermissiveUsers.Visible = true;
            this.colPermissiveUsers.VisibleIndex = 6;
            this.colPermissiveUsers.Width = 600;
            // 
            // colRmsShobehaBmsUserhas
            // 
            this.colRmsShobehaBmsUserhas.FieldName = "RmsShobehaBmsUserhas";
            this.colRmsShobehaBmsUserhas.Name = "colRmsShobehaBmsUserhas";
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
            this.Line.Name = "Line";
            this.Line.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Line.Visible = true;
            this.Line.VisibleIndex = 0;
            this.Line.Width = 60;
            // 
            // FrmShoabatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 507);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmShoabatList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "لیست شعبات واحدها";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnDisplyActiveList;
        private DevExpress.XtraBars.BarButtonItem btnDisplyNotActiveList;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem btnListPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarSubItem btnEmkanat;
        private DevExpress.XtraBars.BarButtonItem btnAdvancedSearch;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colMsShobeId;
        private DevExpress.XtraGrid.Columns.GridColumn colShobeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShobeName;
        private DevExpress.XtraGrid.Columns.GridColumn colShobeIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colMsMajmoeId;
        private DevExpress.XtraGrid.Columns.GridColumn colMajmoeName;
        private DevExpress.XtraGrid.Columns.GridColumn colMsVahedId;
        private DevExpress.XtraGrid.Columns.GridColumn colVahedName;
        private DevExpress.XtraGrid.Columns.GridColumn colMsVahed1;
        private DevExpress.XtraGrid.Columns.GridColumn colPermissiveUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colRmsShobehaBmsUserhas;
        private DevExpress.XtraGrid.Columns.GridColumn Line;
    }
}