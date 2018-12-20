namespace Hesabdari_TG_N1_V1.Forms.Base.AnbarKala
{
    partial class FrmListAnbars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListAnbars));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBSAnbarId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPreviewPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplyListNotActive = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintList = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplyListActive = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.entityServerModeSource1 = new DevExpress.Data.Linq.EntityServerModeSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1136, 440);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.colBSAnbarId,
            this.colLine,
            this.colCode,
            this.colName,
            this.colIsActive});
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
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colBSAnbarId
            // 
            this.colBSAnbarId.AppearanceCell.Options.UseTextOptions = true;
            this.colBSAnbarId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBSAnbarId.AppearanceHeader.Options.UseTextOptions = true;
            this.colBSAnbarId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBSAnbarId.Caption = "آیدی";
            this.colBSAnbarId.FieldName = "BSAnbarId";
            this.colBSAnbarId.MinWidth = 10;
            this.colBSAnbarId.Name = "colBSAnbarId";
            // 
            // colLine
            // 
            this.colLine.AppearanceCell.Options.UseTextOptions = true;
            this.colLine.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.AppearanceHeader.Options.UseTextOptions = true;
            this.colLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.Caption = "ردیف";
            this.colLine.FieldName = "Line";
            this.colLine.Name = "colLine";
            this.colLine.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.Caption = "کد انبار";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "نام انبار";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 300;
            // 
            // colIsActive
            // 
            this.colIsActive.AppearanceCell.Options.UseTextOptions = true;
            this.colIsActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.Caption = "فعال";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPreviewPrint);
            this.panelControl1.Controls.Add(this.btnDisplyListNotActive);
            this.panelControl1.Controls.Add(this.btnPrintList);
            this.panelControl1.Controls.Add(this.btnDisplyListActive);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1136, 59);
            this.panelControl1.TabIndex = 9;
            // 
            // btnPreviewPrint
            // 
            this.btnPreviewPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPreviewPrint.ImageOptions.SvgImage")));
            this.btnPreviewPrint.Location = new System.Drawing.Point(144, 5);
            this.btnPreviewPrint.Name = "btnPreviewPrint";
            this.btnPreviewPrint.Size = new System.Drawing.Size(158, 48);
            this.btnPreviewPrint.TabIndex = 0;
            this.btnPreviewPrint.Text = "پیش نمایش چاپ";
            this.btnPreviewPrint.Click += new System.EventHandler(this.btnPreviewPrint_Click);
            // 
            // btnDisplyListNotActive
            // 
            this.btnDisplyListNotActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplyListNotActive.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnDisplyListNotActive.Location = new System.Drawing.Point(308, 5);
            this.btnDisplyListNotActive.Name = "btnDisplyListNotActive";
            this.btnDisplyListNotActive.Size = new System.Drawing.Size(197, 48);
            this.btnDisplyListNotActive.TabIndex = 0;
            this.btnDisplyListNotActive.Text = "نمایش لیست (غیرفعال)";
            this.btnDisplyListNotActive.Click += new System.EventHandler(this.btnDisplyListNotActive_Click);
            // 
            // btnPrintList
            // 
            this.btnPrintList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintList.ImageOptions.SvgImage")));
            this.btnPrintList.Location = new System.Drawing.Point(12, 5);
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(126, 48);
            this.btnPrintList.TabIndex = 0;
            this.btnPrintList.Text = "چاپ لیست";
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // btnDisplyListActive
            // 
            this.btnDisplyListActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplyListActive.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDisplyListActive.ImageOptions.SvgImage")));
            this.btnDisplyListActive.Location = new System.Drawing.Point(511, 5);
            this.btnDisplyListActive.Name = "btnDisplyListActive";
            this.btnDisplyListActive.Size = new System.Drawing.Size(176, 48);
            this.btnDisplyListActive.TabIndex = 0;
            this.btnDisplyListActive.Text = "نمایش لیست (فعال)";
            this.btnDisplyListActive.Click += new System.EventHandler(this.btnDisplyListActive_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Location = new System.Drawing.Point(693, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 48);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "حذف کردن";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.Location = new System.Drawing.Point(841, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(142, 48);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "ویرایش کردن";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.Location = new System.Drawing.Point(989, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 48);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ایجاد کردن";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // entityInstantFeedbackSource1
            // 
            this.entityInstantFeedbackSource1.DefaultSorting = "Code ASC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(Hesabdari_TG_N1_V1.Models.Base.AnbarKala.BSAnbar);
            this.entityInstantFeedbackSource1.KeyExpression = "BSAnbarId";
            // 
            // entityServerModeSource1
            // 
            this.entityServerModeSource1.DefaultSorting = "Code ASC";
            this.entityServerModeSource1.ElementType = typeof(Hesabdari_TG_N1_V1.Models.Base.AnbarKala.BSAnbar);
            this.entityServerModeSource1.KeyExpression = "BSAnbarId";
            // 
            // FrmListAnbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 499);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmListAnbars";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "لیست انبارها";
            this.Activated += new System.EventHandler(this.FrmListAnbars_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrintList;
        private DevExpress.XtraEditors.SimpleButton btnDisplyListActive;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colBSAnbarId;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource1;
        private DevExpress.XtraEditors.SimpleButton btnPreviewPrint;
        private DevExpress.XtraEditors.SimpleButton btnDisplyListNotActive;
    }
}