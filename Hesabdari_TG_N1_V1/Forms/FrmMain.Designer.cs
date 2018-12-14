namespace Hesabdari_TG_N1_V1.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnFactorFroosh = new DevExpress.XtraBars.BarButtonItem();
            this.btnBargashtFroosh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPishFactor = new DevExpress.XtraBars.BarButtonItem();
            this.btnListFroosh = new DevExpress.XtraBars.BarButtonItem();
            this.btnFactorKharid = new DevExpress.XtraBars.BarButtonItem();
            this.btnBargashtKharid = new DevExpress.XtraBars.BarButtonItem();
            this.btnSefareshatKharid = new DevExpress.XtraBars.BarButtonItem();
            this.btnListKharid = new DevExpress.XtraBars.BarButtonItem();
            this.btnDaryaft = new DevExpress.XtraBars.BarButtonItem();
            this.btnListDaryaft = new DevExpress.XtraBars.BarButtonItem();
            this.btnPardakht = new DevExpress.XtraBars.BarButtonItem();
            this.btnListPardakht = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnteghalat = new DevExpress.XtraBars.BarButtonItem();
            this.btnListEnteghalat = new DevExpress.XtraBars.BarButtonItem();
            this.btnVazeyateAsnadeDaryaftani = new DevExpress.XtraBars.BarButtonItem();
            this.btnListVazeyateAsnadeDaryaftani = new DevExpress.XtraBars.BarButtonItem();
            this.btnVazeyateAsnadePardakhtani = new DevExpress.XtraBars.BarButtonItem();
            this.btnListVazeyateAsnadePardakhtani = new DevExpress.XtraBars.BarButtonItem();
            this.rpKharidFroosh = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgFroosh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgKharid = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpDaryaftPardakht = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgDaryaft = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPardakht = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgEnteghalat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgOmoreAsnadeDaryaftani = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgOmoreAsnadePardakhtani = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.rpAsnadeHesabdari = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgAsnadeHesabdari = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnSanadDasti = new DevExpress.XtraBars.BarButtonItem();
            this.btnListAsnad = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnFactorFroosh,
            this.btnBargashtFroosh,
            this.btnPishFactor,
            this.btnListFroosh,
            this.btnFactorKharid,
            this.btnBargashtKharid,
            this.btnSefareshatKharid,
            this.btnListKharid,
            this.btnDaryaft,
            this.btnListDaryaft,
            this.btnPardakht,
            this.btnListPardakht,
            this.btnEnteghalat,
            this.btnListEnteghalat,
            this.btnVazeyateAsnadeDaryaftani,
            this.btnListVazeyateAsnadeDaryaftani,
            this.btnVazeyateAsnadePardakhtani,
            this.btnListVazeyateAsnadePardakhtani,
            this.btnSanadDasti,
            this.btnListAsnad});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbon.MaxItemId = 33;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderMinWidth = 50;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpKharidFroosh,
            this.rpDaryaftPardakht,
            this.rpAsnadeHesabdari});
            this.ribbon.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Center;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowItemCaptionsInPageHeader = true;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1225, 206);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnFactorFroosh
            // 
            this.btnFactorFroosh.Caption = "فاکتورفروش";
            this.btnFactorFroosh.Id = 1;
            this.btnFactorFroosh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFactorFroosh.ImageOptions.SvgImage")));
            this.btnFactorFroosh.Name = "btnFactorFroosh";
            // 
            // btnBargashtFroosh
            // 
            this.btnBargashtFroosh.Caption = "فاکتور برگشت از فروش";
            this.btnBargashtFroosh.Id = 2;
            this.btnBargashtFroosh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBargashtFroosh.ImageOptions.SvgImage")));
            this.btnBargashtFroosh.Name = "btnBargashtFroosh";
            // 
            // btnPishFactor
            // 
            this.btnPishFactor.Caption = "پیش فاکتور";
            this.btnPishFactor.Id = 3;
            this.btnPishFactor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPishFactor.ImageOptions.Image")));
            this.btnPishFactor.Name = "btnPishFactor";
            this.btnPishFactor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListFroosh
            // 
            this.btnListFroosh.Caption = "لیست فروش";
            this.btnListFroosh.Id = 4;
            this.btnListFroosh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnListFroosh.ImageOptions.SvgImage")));
            this.btnListFroosh.Name = "btnListFroosh";
            // 
            // btnFactorKharid
            // 
            this.btnFactorKharid.Caption = "فاکتورخرید";
            this.btnFactorKharid.Id = 5;
            this.btnFactorKharid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFactorKharid.ImageOptions.SvgImage")));
            this.btnFactorKharid.Name = "btnFactorKharid";
            this.btnFactorKharid.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnBargashtKharid
            // 
            this.btnBargashtKharid.Caption = "فاکتور برگشت از خرید";
            this.btnBargashtKharid.Id = 6;
            this.btnBargashtKharid.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBargashtKharid.ImageOptions.Image")));
            this.btnBargashtKharid.Name = "btnBargashtKharid";
            this.btnBargashtKharid.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSefareshatKharid
            // 
            this.btnSefareshatKharid.Caption = "سفارشات خرید";
            this.btnSefareshatKharid.Id = 7;
            this.btnSefareshatKharid.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSefareshKharid.ImageOptions.Image")));
            this.btnSefareshatKharid.Name = "btnSefareshatKharid";
            this.btnSefareshatKharid.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListKharid
            // 
            this.btnListKharid.Caption = "لیست خرید";
            this.btnListKharid.Id = 8;
            this.btnListKharid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnListKharid.ImageOptions.SvgImage")));
            this.btnListKharid.Name = "btnListKharid";
            this.btnListKharid.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnDaryaft
            // 
            this.btnDaryaft.Caption = "دریافت";
            this.btnDaryaft.Id = 21;
            this.btnDaryaft.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDaryaft.ImageOptions.SvgImage")));
            this.btnDaryaft.Name = "btnDaryaft";
            this.btnDaryaft.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListDaryaft
            // 
            this.btnListDaryaft.Caption = "لیست دریافت";
            this.btnListDaryaft.Id = 22;
            this.btnListDaryaft.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnListDaryaft.ImageOptions.SvgImage")));
            this.btnListDaryaft.Name = "btnListDaryaft";
            this.btnListDaryaft.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnPardakht
            // 
            this.btnPardakht.Caption = "پرداخت";
            this.btnPardakht.Id = 23;
            this.btnPardakht.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPardakht.ImageOptions.SvgImage")));
            this.btnPardakht.Name = "btnPardakht";
            this.btnPardakht.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListPardakht
            // 
            this.btnListPardakht.Caption = "لیست پرداخت";
            this.btnListPardakht.Id = 24;
            this.btnListPardakht.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnListPardakht.ImageOptions.SvgImage")));
            this.btnListPardakht.Name = "btnListPardakht";
            this.btnListPardakht.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnEnteghalat
            // 
            this.btnEnteghalat.Caption = "نقل و انتقال بین حسابها";
            this.btnEnteghalat.Id = 25;
            this.btnEnteghalat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.btnEnteghalat.Name = "btnEnteghalat";
            this.btnEnteghalat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListEnteghalat
            // 
            this.btnListEnteghalat.Caption = "لیست نقل و انتقال";
            this.btnListEnteghalat.Id = 26;
            this.btnListEnteghalat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.btnListEnteghalat.Name = "btnListEnteghalat";
            this.btnListEnteghalat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnVazeyateAsnadeDaryaftani
            // 
            this.btnVazeyateAsnadeDaryaftani.Caption = "تعیین وضعیت اسناد دریافتنی";
            this.btnVazeyateAsnadeDaryaftani.Id = 27;
            this.btnVazeyateAsnadeDaryaftani.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.btnVazeyateAsnadeDaryaftani.Name = "btnVazeyateAsnadeDaryaftani";
            this.btnVazeyateAsnadeDaryaftani.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListVazeyateAsnadeDaryaftani
            // 
            this.btnListVazeyateAsnadeDaryaftani.Caption = "لیست اسناد دریافتنی";
            this.btnListVazeyateAsnadeDaryaftani.Id = 28;
            this.btnListVazeyateAsnadeDaryaftani.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.btnListVazeyateAsnadeDaryaftani.Name = "btnListVazeyateAsnadeDaryaftani";
            this.btnListVazeyateAsnadeDaryaftani.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnVazeyateAsnadePardakhtani
            // 
            this.btnVazeyateAsnadePardakhtani.Caption = "تعیین وضعیت اسناد پرداختنی";
            this.btnVazeyateAsnadePardakhtani.Id = 29;
            this.btnVazeyateAsnadePardakhtani.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem5.ImageOptions.SvgImage")));
            this.btnVazeyateAsnadePardakhtani.Name = "btnVazeyateAsnadePardakhtani";
            this.btnVazeyateAsnadePardakhtani.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListVazeyateAsnadePardakhtani
            // 
            this.btnListVazeyateAsnadePardakhtani.Caption = "لیست اسناد پرداختنی";
            this.btnListVazeyateAsnadePardakhtani.Id = 30;
            this.btnListVazeyateAsnadePardakhtani.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem6.ImageOptions.SvgImage")));
            this.btnListVazeyateAsnadePardakhtani.Name = "btnListVazeyateAsnadePardakhtani";
            this.btnListVazeyateAsnadePardakhtani.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // rpKharidFroosh
            // 
            this.rpKharidFroosh.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgFroosh,
            this.rpgKharid});
            this.rpKharidFroosh.Name = "rpKharidFroosh";
            this.rpKharidFroosh.Text = "فروش و خرید";
            // 
            // rpgFroosh
            // 
            this.rpgFroosh.ItemLinks.Add(this.btnFactorFroosh, true);
            this.rpgFroosh.ItemLinks.Add(this.btnBargashtFroosh, true);
            this.rpgFroosh.ItemLinks.Add(this.btnPishFactor, true);
            this.rpgFroosh.ItemLinks.Add(this.btnListFroosh, true);
            this.rpgFroosh.Name = "rpgFroosh";
            this.rpgFroosh.Text = "فروش";
            // 
            // rpgKharid
            // 
            this.rpgKharid.ItemLinks.Add(this.btnFactorKharid, true);
            this.rpgKharid.ItemLinks.Add(this.btnBargashtKharid, true);
            this.rpgKharid.ItemLinks.Add(this.btnSefareshatKharid, true);
            this.rpgKharid.ItemLinks.Add(this.btnListKharid, true);
            this.rpgKharid.Name = "rpgKharid";
            this.rpgKharid.Text = "خرید";
            // 
            // rpDaryaftPardakht
            // 
            this.rpDaryaftPardakht.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDaryaft,
            this.rpgPardakht,
            this.rpgEnteghalat,
            this.rpgOmoreAsnadeDaryaftani,
            this.rpgOmoreAsnadePardakhtani});
            this.rpDaryaftPardakht.Name = "rpDaryaftPardakht";
            this.rpDaryaftPardakht.Text = "دریافت و پرداخت";
            // 
            // rpgDaryaft
            // 
            this.rpgDaryaft.ItemLinks.Add(this.btnDaryaft, true);
            this.rpgDaryaft.ItemLinks.Add(this.btnListDaryaft, true);
            this.rpgDaryaft.Name = "rpgDaryaft";
            this.rpgDaryaft.Text = "دریافت";
            // 
            // rpgPardakht
            // 
            this.rpgPardakht.ItemLinks.Add(this.btnPardakht, true);
            this.rpgPardakht.ItemLinks.Add(this.btnListPardakht, true);
            this.rpgPardakht.Name = "rpgPardakht";
            this.rpgPardakht.Text = "پرداخت";
            // 
            // rpgEnteghalat
            // 
            this.rpgEnteghalat.ItemLinks.Add(this.btnEnteghalat, true);
            this.rpgEnteghalat.ItemLinks.Add(this.btnListEnteghalat, true);
            this.rpgEnteghalat.Name = "rpgEnteghalat";
            this.rpgEnteghalat.Text = "نقل و انتقال";
            // 
            // rpgOmoreAsnadeDaryaftani
            // 
            this.rpgOmoreAsnadeDaryaftani.ItemLinks.Add(this.btnVazeyateAsnadeDaryaftani);
            this.rpgOmoreAsnadeDaryaftani.ItemLinks.Add(this.btnListVazeyateAsnadeDaryaftani, true);
            this.rpgOmoreAsnadeDaryaftani.Name = "rpgOmoreAsnadeDaryaftani";
            this.rpgOmoreAsnadeDaryaftani.Text = "امور اسناد دریافتنی ";
            // 
            // rpgOmoreAsnadePardakhtani
            // 
            this.rpgOmoreAsnadePardakhtani.ItemLinks.Add(this.btnVazeyateAsnadePardakhtani, true);
            this.rpgOmoreAsnadePardakhtani.ItemLinks.Add(this.btnListVazeyateAsnadePardakhtani, true);
            this.rpgOmoreAsnadePardakhtani.Name = "rpgOmoreAsnadePardakhtani";
            this.rpgOmoreAsnadePardakhtani.Text = "امور اسناد پرداختنی";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 597);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1225, 41);
            // 
            // rpAsnadeHesabdari
            // 
            this.rpAsnadeHesabdari.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgAsnadeHesabdari});
            this.rpAsnadeHesabdari.Name = "rpAsnadeHesabdari";
            this.rpAsnadeHesabdari.Text = "اسناد حسابداری";
            // 
            // rpgAsnadeHesabdari
            // 
            this.rpgAsnadeHesabdari.ItemLinks.Add(this.btnSanadDasti, true);
            this.rpgAsnadeHesabdari.ItemLinks.Add(this.btnListAsnad, true);
            this.rpgAsnadeHesabdari.Name = "rpgAsnadeHesabdari";
            this.rpgAsnadeHesabdari.Text = "اسناد حسابداری";
            // 
            // btnSanadDasti
            // 
            this.btnSanadDasti.Caption = "صدور سند دستی";
            this.btnSanadDasti.Id = 31;
            this.btnSanadDasti.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage1")));
            this.btnSanadDasti.Name = "btnSanadDasti";
            this.btnSanadDasti.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnListAsnad
            // 
            this.btnListAsnad.Caption = "لیست اسناد";
            this.btnListAsnad.Id = 32;
            this.btnListAsnad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage1")));
            this.btnListAsnad.Name = "btnListAsnad";
            this.btnListAsnad.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // FrmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 638);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "نرم افزار حسابداری تلاشگران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpKharidFroosh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFroosh;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnFactorFroosh;
        private DevExpress.XtraBars.BarButtonItem btnBargashtFroosh;
        private DevExpress.XtraBars.BarButtonItem btnPishFactor;
        private DevExpress.XtraBars.BarButtonItem btnListFroosh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgKharid;
        private DevExpress.XtraBars.BarButtonItem btnFactorKharid;
        private DevExpress.XtraBars.BarButtonItem btnBargashtKharid;
        private DevExpress.XtraBars.BarButtonItem btnSefareshatKharid;
        private DevExpress.XtraBars.BarButtonItem btnListKharid;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDaryaftPardakht;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDaryaft;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPardakht;
        private DevExpress.XtraBars.BarButtonItem btnDaryaft;
        private DevExpress.XtraBars.BarButtonItem btnListDaryaft;
        private DevExpress.XtraBars.BarButtonItem btnPardakht;
        private DevExpress.XtraBars.BarButtonItem btnListPardakht;
        private DevExpress.XtraBars.BarButtonItem btnEnteghalat;
        private DevExpress.XtraBars.BarButtonItem btnListEnteghalat;
        private DevExpress.XtraBars.BarButtonItem btnVazeyateAsnadeDaryaftani;
        private DevExpress.XtraBars.BarButtonItem btnListVazeyateAsnadeDaryaftani;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEnteghalat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOmoreAsnadeDaryaftani;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOmoreAsnadePardakhtani;
        private DevExpress.XtraBars.BarButtonItem btnVazeyateAsnadePardakhtani;
        private DevExpress.XtraBars.BarButtonItem btnListVazeyateAsnadePardakhtani;
        private DevExpress.XtraBars.BarButtonItem btnSanadDasti;
        private DevExpress.XtraBars.BarButtonItem btnListAsnad;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAsnadeHesabdari;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAsnadeHesabdari;
    }
}