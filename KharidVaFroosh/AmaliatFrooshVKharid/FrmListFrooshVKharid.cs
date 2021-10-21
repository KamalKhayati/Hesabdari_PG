using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using HelpClassLibrary;
using DBHesabdari_PG;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DBHesabdari_PG.Models.FK;

namespace FrooshVKharid.AmaliatFrooshVKharid
{
    public partial class FrmListFrooshVKharid : DevExpress.XtraEditors.XtraForm
    {
        public FrmListFrooshVKharid()
        {
            InitializeComponent();
        }

        int _SalId = 0;
        public bool _FirstSelectAnbar_NextSanad = false;
        public byte _NoeFactor = 0;
        MyContext dbContext;

        private void FrmListFrooshVKharid_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == 4401001);
                    if (q != null)
                        _FirstSelectAnbar_NextSanad = q.IsChecked;

                    //gridControl1 = gridControl_AghlamKala;
                    //gridView1 = gridView_AghlamKala;

                    if (this.Name == "FrmListFrooshKhadamat" || this.Name == "FrmListKharidKhadamat")
                    {
                        //xtp_FactorBargashtAzFroosh.PageVisible = xtp_FactorBargashtAzKharid.PageVisible = false;
                        xtp_FactorFroosh.Text = "فاکتور فروش خدمات";
                        xtp_FactorBargashtAzFroosh.Text = "فاکتور برگشت از فروش خدمات";
                        xtp_SefareshFroosh.Text = "سفارش فروش خدمات";
                        xtp_FactorKharid.Text = "فاکتور خرید خدمات";
                        xtp_FactorBargashtAzKharid.Text = "فاکتور برگشت از خرید خدمات";
                        xtp_SefareshKharid.Text = "سفارش خرید خدمات";
                        panelControl_NameAnbar.Enabled = false;
                        panelControl_NameAnbar.Visible = false;
                        panelControl_NameAnbar.Width = 0;
                        _NoeFactor = 1;
                        xtc_ListFrooshVKharid.Enabled = true;
                        btnDisplyList.Enabled = true;
                    }
                    else
                    {
                        _NoeFactor = 0;
                        if (!_FirstSelectAnbar_NextSanad)
                        {
                            panelControl_NameAnbar.Enabled = false;
                            panelControl_NameAnbar.Visible = false;
                            panelControl_NameAnbar.Width = 0;
                            xtc_ListFrooshVKharid.Enabled = true;
                            btnDisplyList.Enabled = true;
                        }

                    }

                    xtc_ListFrooshVKharid_SelectedPageChanged(null, null);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmFactor fm = new FrmFactor(this);
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.En1 = EnumCED.Create;

            //_NoeFactor = Convert.ToByte(gridView.GetFocusedRowCellValue("NoeFactor").ToString());
            if (_FirstSelectAnbar_NextSanad && _NoeFactor == 0)
                fm._AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

            if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorFroosh)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmFactorFrooshKala";
                else
                    fm.Name = "FrmFactorFrooshKhadamat";
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmFactorBargashtAzFrooshKala";
                else
                    fm.Name = "FrmFactorBargashtAzFrooshKhadamat";
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmSefareshFrooshKala";
                else
                    fm.Name = "FrmSefareshFrooshKhadamat";
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmFactorKharidKala";
                else
                    fm.Name = "FrmFactorKharidKhadamat";
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmFactorBargashtAzKharidKala";
                else
                    fm.Name = "FrmFactorBargashtAzKharidKhadamat";
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
            {
                if (_NoeFactor == 0)
                    fm.Name = "FrmSefareshKharidKala";
                else
                    fm.Name = "FrmSefareshKharidKhadamat";
            }

            fm.ShowDialog(this);

        }

        private void gridView_List_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView_List_RowCellClick(object sender, RowCellClickEventArgs e)
        {
        }

        private void gridView_List_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_List_RowCellClick(null, null);

        }

        private void gridView_List_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_List_RowCellClick(null, null);

        }

        private void gridView_List_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_List.RowCount > 0)
                btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = true;
            else
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;

        }

        public void FillCmbAnbarName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmListFrooshVKharid_Shown(object sender, EventArgs e)
        {
            if (_FirstSelectAnbar_NextSanad)
            {
                FillCmbAnbarName();
                //gridView.Columns["SeryalCol_BaNameAmaliat_BeSelectAnbar"].Visible = false;
                //gridView.Columns["SeryalJoze_BaNameSanad_BeSelectAnbar"].Visible = false;
                //lblSeryalCol_BaNameAmaliat_BeSelectAnbar.Visible = txtSeryalCol_BaNameAmaliat_BeSelectAnbar.Visible = false;
                //lblSeryalJoze_BaNameSanad_BeSelectAnbar.Visible = txtSeryalJoze_BaNameSanad_BeSelectAnbar.Visible = false;
                cmbNameAnbar.Focus();
            }
            else
            {
                panelControl_NameAnbar.Enabled = false;
                panelControl_NameAnbar.Visible = false;
                panelControl_NameAnbar.Width = 0;
                xtc_ListFrooshVKharid.Enabled = true;
                //xtcAmaliatRozaneh.Enabled = true;
                //gridView.Columns["SeryalCol_BaNameAmaliat_BaSelectAnbar"].Visible = false;
                //gridView.Columns["SeryalJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                //lblSeryalCol_BaNameAmaliat_BaSelectAnbar.Visible = txtSeryalCol_BaNameAmaliat_BaSelectAnbar.Visible = false;
                //lblSeryalJoze_BaNameSanad_BaSelectAnbar.Visible = txtSeryalJoze_BaNameSanad_BaSelectAnbar.Visible = false;
                //txtFNumberJoze_BaNameSanad_BaSelectAnbar.Visible = labelControl4.Visible = false;
                //xtc_VorodeKala.TabPages[9].Text = "جابجایی کالا";
                //xtc_KhorojeKala.TabPages[9].Text = "جابجایی کالا";
                //cmbNoeAghlamFactor.Focus();
            }

        }

        private void cmbNameAnbar_EditValueChanged(object sender, EventArgs e)
        {
            if (xtc_ListFrooshVKharid.Enabled == false)
                xtc_ListFrooshVKharid.Enabled = true;
            xtc_ListFrooshVKharid_SelectedPageChanged(null, null);
            btnDisplyList.Enabled = true;
        }

        bool _IsActiveRow = true;

        private void cmbNameAnbar_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));

        }

        private void cmbNameAnbar_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            if (!_IsActiveRow)
                e.Appearance.ForeColor = Color.Red;

            if (e.Header.Caption == "فعال" && e.DisplayText == "True")
                e.DisplayText = "بله";
            if (e.Header.Caption == "فعال" && e.DisplayText == "False")
                e.DisplayText = "خیر";
            if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "True")
                e.DisplayText = "بله";
            if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "False")
                e.DisplayText = "خیر";

        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillCmbAnbarName();

        }

        XtraTabPage objXtraTabPage;
        //XtraTabControl XtraTabControl1_1;
        GridControl gridControl;
        GridView gridView;
        //public GridControl gridControl1;
        //public GridView gridView1;
        GridControl objGridControl = null;
        int _NameAmaliatCode = 0;
        int _NameSanadCode = 0;
        string _NameSanadText = string.Empty;
        private void xtc_ListFrooshVKharid_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //if (En1 == EnumCED.Cancel)
            {
                objXtraTabPage = new XtraTabPage();
                gridControl = new GridControl();
                gridView = new GridView();
                objGridControl = new GridControl();

                objXtraTabPage = xtc_ListFrooshVKharid.SelectedTabPage;

                if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorFroosh)
                {
                    _NameAmaliatCode = 2;
                    _NameSanadCode = 201;
                    //_NameSanadText = xtp_FactorFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
                {
                    _NameAmaliatCode = 2;
                    _NameSanadCode = 202;
                    // _NameSanadText = xtp_FactorBargashtAzFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
                {
                    _NameAmaliatCode = 2;
                    _NameSanadCode = 203;
                    // _NameSanadText = xtp_SefareshFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 101;
                    // _NameSanadText = xtp_FactorKharid.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 102;
                    //  _NameSanadText = xtp_FactorBargashtAzKharid.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 103;
                    // _NameSanadText = xtp_SefareshKharid.Text;
                }


                gridControl = gridControl_List;
                gridView = gridView_List;
                objGridControl = gridControl;

                //{
                //    gridView.Columns["EpAllHesabTafsili1.Code"].Visible = true;
                //    gridView.Columns["EpAllHesabTafsili1.Name"].Visible = true;
                //    gridView.Columns["FactorNamber"].Visible = true;
                //    gridView.Columns["EpHesabMoin1.Code"].Visible = true;
                //    gridView.Columns["EpHesabMoin1.Name"].Visible = true;
                //    //gridView.Columns["EpListAnbarha1.Name"].Caption = "نام انبار";

                //    gridView.Columns["EpAllHesabTafsili1.Code"].VisibleIndex = 8;
                //    gridView.Columns["EpAllHesabTafsili1.Name"].VisibleIndex = 9;
                //    gridView.Columns["FactorNamber"].VisibleIndex = 10;
                //    gridView.Columns["Radif"].VisibleIndex = 11;
                //    gridView.Columns["EpNameKala1.Code"].VisibleIndex = 12;
                //    gridView.Columns["EpNameKala1.Name"].VisibleIndex = 13;
                //    gridView.Columns["EpVahedKala1.Name"].VisibleIndex = 14;
                //    gridView.Columns["Meghdar"].VisibleIndex = 15;
                //    gridView.Columns["Nerkh"].VisibleIndex = 16;
                //    gridView.Columns["Mablag"].VisibleIndex = 17;
                //    gridView.Columns["IsRiali"].VisibleIndex = 18;
                //    gridView.Columns["DateTimeInsert"].VisibleIndex = 19;
                //    gridView.Columns["DateTimeEdit"].VisibleIndex = 20;
                //    gridView.Columns["EpHesabMoin1.Code"].VisibleIndex = 21;
                //    gridView.Columns["EpHesabMoin1.Name"].VisibleIndex = 22;

                //    if (_NameAmaliatTabpageIndex == 0)
                //    {
                //        gridView.Columns["EpListAnbarha1.Name"].Visible = false;
                //        gridView.Columns["EpListAnbarha2.Name"].VisibleIndex = 23;

                //    }
                //    else
                //    {
                //        gridView.Columns["EpListAnbarha2.Name"].Visible = false;
                //        gridView.Columns["EpListAnbarha1.Name"].VisibleIndex = 23;

                //    }

                //    gridView.Columns["RozaneSanadNumber"].VisibleIndex = 24;
                //    gridView.Columns["GhateySanadNamber"].VisibleIndex = 25;
                //    gridView.Columns["PaygiriNumber"].VisibleIndex = 26;
                //    gridView.Columns["SeryalCol_BeNameAmaliat_BeSelectAnbar"].VisibleIndex = 27;
                //    gridView.Columns["Id"].VisibleIndex = 28;
                //    gridView.Columns["Tozihat"].VisibleIndex = 29;
                //    gridView.Columns["SharhSanad"].VisibleIndex = 30;


                //}



                if (_FirstSelectAnbar_NextSanad && _NoeFactor == 0)
                {
                    //gridView.Columns["FNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    //gridView.Columns["SNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    //gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = true;
                    //gridView.Columns["SNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = true;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].GroupIndex = 0;
                }
                else if (!_FirstSelectAnbar_NextSanad && _NoeFactor == 0)
                {
                    //gridView.Columns["FNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    //gridView.Columns["SNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["SNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaNoeFactor"].GroupIndex = 0;
                }
                else if ((_FirstSelectAnbar_NextSanad && _NoeFactor == 1) || (!_FirstSelectAnbar_NextSanad && _NoeFactor == 1))
                {
                    gridView.Columns["EpNameKala1.Code"].Caption = "کد خدمات";
                    gridView.Columns["EpNameKala1.Name"].Caption = "نام خدمات";
                    gridView.Columns["EpVahedKala1.Name"].Caption = "واحد خدمات";
                    gridView.Columns["SNumberCol_BaNameSanad_BeSelectAnbar"].Visible = false;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["SNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaNoeFactor"].GroupIndex = 0;
                    gridView.Columns["EpListAnbarha1.Name"].Visible = false;
                }

                objXtraTabPage.Controls.Add(objGridControl);

                btnDelete.Enabled = btnEdit.Enabled = false;
                btnDisplyList_Click(null, null);

            }

        }

        int _AnbarId = 0;
        public void FillGridControl()
        {
            dbContext = new MyContext();
            {
                try
                {
                    //List<FkAmaliatFrooshVKharid_Riz> q = new List<FkAmaliatFrooshVKharid_Riz>();
                    if (_FirstSelectAnbar_NextSanad)
                    {
                        if (_NoeFactor == 0)
                        {
                            _AnbarId = _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                            var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode && s.NoeFactor == _NoeFactor).ToList();
                            gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar).ToList() : null;
                        }
                        else
                        {
                            var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == null && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode && s.NoeFactor == _NoeFactor).ToList();
                            gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaNoeFactor).ToList() : null;
                        }
                    }
                    else
                    {
                        if (_NoeFactor == 0)
                        {
                            var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.AnbarId != 0 && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode && s.NoeFactor == _NoeFactor).ToList();
                            gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar).ToList() : null;
                        }
                        else
                        {
                            var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == null && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode && s.NoeFactor == _NoeFactor).ToList();
                            gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar).ToList() : null;
                        }
                    }

                    btnDelete.Enabled = btnEdit.Enabled = false;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillGridControl();
        }

        int _TabPageCount = 0;
        int EditRowIndex = 0;
        int _FNumber_BeNameAmaliat_BeSelectAnbar = 0;
        int _FNumberCol_BaNameSanad_BeSelectAnbar = 0;
        int _FNumberJoze_BaNameSanad_BaNoeFactor = 0;
        int _FNumberJoze_BaNameSanad_BaSelectAnbar = 0;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    try
                    {
                        _FNumber_BeNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BeNameAmaliat_BeSelectAnbar").ToString());
                        _FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar").ToString());
                        _FNumberJoze_BaNameSanad_BaNoeFactor = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaNoeFactor").ToString());
                    }
                    catch (Exception)
                    {
                        //XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnEdit.Enabled = btnDelete.Enabled = false;
                        return;
                    }

                    _NameSanadText = gridView.GetFocusedRowCellValue("NameSanadText").ToString();
                    if (XtraMessageBox.Show("آیا " + _NameSanadText + " مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        _NameAmaliatCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameAmaliatCode").ToString());
                        _NameSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameSanadCode").ToString());
                        _NoeFactor = Convert.ToByte(gridView.GetFocusedRowCellValue("NoeFactor").ToString());

                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                //_AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                var q = db.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode
                                && s.FNumberCol_BaNameSanad_BeSelectAnbar == _FNumberCol_BaNameSanad_BeSelectAnbar
                                && s.FNumberJoze_BaNameSanad_BaNoeFactor == _FNumberJoze_BaNameSanad_BaNoeFactor).ToList();
                                var q11 = db.FKMotamemFactors.FirstOrDefault(s => s.SalId == _SalId && s.FNumber_BeNameAmaliat_BeSelectAnbar == _FNumber_BeNameAmaliat_BeSelectAnbar && s.FNumberCol_BaNameSanad_BeSelectAnbar == _FNumberCol_BaNameSanad_BeSelectAnbar && s.FNumberJoze_BaNameSanad_BaNoeFactor == _FNumberJoze_BaNameSanad_BaNoeFactor);
                                if (q.Count > 0 && q11 != null)
                                {
                                    //if (_FirstSelectAnbar_NextSanad && _NoeFactor == 0)
                                    //{
                                    //    _FNumberJoze_BaNameSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaSelectAnbar").ToString());

                                    //    _AnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AnbarId").ToString());
                                    //    var q1 = q.Where(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar == _FNumberJoze_BaNameSanad_BaSelectAnbar && s.AnbarId == _AnbarId).ToList();
                                    //    db.FkAmaliatFrooshVKharid_Rizs.RemoveRange(q1);
                                    //}
                                    //else
                                    db.FkAmaliatFrooshVKharid_Rizs.RemoveRange(q);
                                    db.FKMotamemFactors.Remove(q11);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView.RowCount > 0)
                                        gridView.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //catch (DbUpdateException)
                            //{
                            //    if (_SelectedTabPage != "xtraTabPage_NameKala")
                            //    {
                            //        XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                            //    " جهت حذف حساب بایستی در ابتدا زیرمجموعه های این حساب حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    }
                            //    else
                            //        XtraMessageBox.Show("حذف این حساب مقدور نیست \n" + " زیرا با حساب فوق سند صادر گردیده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (gridView.RowCount > 0)
                {

                    try
                    {
                        _FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar").ToString());
                    }
                    catch (Exception)
                    {
                        //XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnEdit.Enabled = btnDelete.Enabled = false;
                        return;
                    }

                    try
                    {
                        dbContext = new MyContext();
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        FrmFactor fm = new FrmFactor(this);
                        fm.En1 = EnumCED.Edit;
                        fm.Text = "عملیات ویرایش";
                        fm.lblUserId.Text = lblUserId.Text;
                        fm.lblUserName.Text = lblUserName.Text;
                        fm.lblSalId.Text = lblSalId.Text;
                        fm.lblSalMali.Text = lblSalMali.Text;

                        _NoeFactor = Convert.ToByte(gridView.GetFocusedRowCellValue("NoeFactor").ToString());
                        if (_FirstSelectAnbar_NextSanad && _NoeFactor == 0)
                        {
                            fm._AnbarId = fm._BeforEditAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                        }

                        if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorFroosh)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmFactorFrooshKala";
                            else
                                fm.Name = "FrmFactorFrooshKhadamat";
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmFactorBargashtAzFrooshKala";
                            else
                                fm.Name = "FrmFactorBargashtAzFrooshKhadamat";
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmSefareshFrooshKala";
                            else
                                fm.Name = "FrmSefareshFrooshKhadamat";
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmFactorKharidKala";
                            else
                                fm.Name = "FrmFactorKharidKhadamat";
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmFactorBargashtAzKharidKala";
                            else
                                fm.Name = "FrmFactorBargashtAzKharidKhadamat";
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
                        {
                            if (_NoeFactor == 0)
                                fm.Name = "FrmSefareshKharidKala";
                            else
                                fm.Name = "FrmSefareshKharidKhadamat";
                        }

                        fm._FNumber_BeNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BeNameAmaliat_BeSelectAnbar"));
                        //fm._FNumber_BaNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BaNameAmaliat_BeSelectAnbar"));
                        fm._FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar"));
                        //fm._FNumber_BaNameAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BaNameAmaliat_BaSelectAnbar"));
                        fm._FNumberJoze_BaNameSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaSelectAnbar"));
                        fm._FNumberJoze_BaNameSanad_BaNoeFactor = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaNoeFactor"));


                        fm.ShowDialog(this);

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNameAnbar_Enter(object sender, EventArgs e)
        {
            cmbNameAnbar.ShowPopup();
        }

        private void gridView_List_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                _FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar").ToString());
                btnDelete.Enabled = btnEdit.Enabled = true;
            }
            catch (Exception)
            {
                //XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEdit.Enabled = btnDelete.Enabled = false;
                return;
            }
        }

        private void FrmListFrooshVKharid_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}