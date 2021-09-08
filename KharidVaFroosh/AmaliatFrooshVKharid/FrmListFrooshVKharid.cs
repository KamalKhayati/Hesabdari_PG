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
            if (_FirstSelectAnbar_NextSanad)
                fm._AnbarId= Convert.ToInt32(cmbNameAnbar.EditValue);

            if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorFroosh)
            {
                fm.Name = "FrmFactorFrooshKala";
                fm.Text = "فاکتور فروش کالا";
                //fm.cmbNameSanad.SelectedIndex = 0;
                fm.ShowDialog(this);
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
            {
                fm.Name = "FrmFactorBargashtAzFroosh";
                fm.Text = "فاکتور برگشت از فروش کالا";
               // fm.cmbNameSanad.SelectedIndex = 1;
                fm.ShowDialog(this);
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
            {
                fm.Name = "FrmSefareshFrooshKala";
                fm.Text = "سفارش فروش کالا";
               // fm.cmbNameSanad.SelectedIndex = 2;
                fm.ShowDialog(this);
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
            {
                fm.Name = "FrmFactorKharidKala";
                fm.Text = "فاکتور خرید کالا";
                //fm.cmbNameSanad.SelectedIndex = 0;
                fm.ShowDialog(this);
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
            {
                fm.Name = "FrmFactorBargashtAzKharid";
                fm.Text = "فاکتور برگشت از خرید کالا";
               // fm.cmbNameSanad.SelectedIndex = 1;
                fm.ShowDialog(this);
            }
            else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
            {
                fm.Name = "FrmSefareshKharidKala";
                fm.Text = "سفارش خرید کالا";
                //fm.cmbNameSanad.SelectedIndex = 2;
                fm.ShowDialog(this);
            }


        }

        private void gridView_List_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void gridView_List_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                btnDelete.Enabled = btnEdit.Enabled = true;
            }
            catch (Exception)
            {
            }
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
                    _NameSanadText = xtp_FactorFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
                {
                    _NameAmaliatCode = 2;
                    _NameSanadCode = 202;
                    _NameSanadText = xtp_FactorBargashtAzFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
                {
                    _NameAmaliatCode = 2;
                    _NameSanadCode = 203;
                    _NameSanadText = xtp_SefareshFroosh.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 101;
                    _NameSanadText = xtp_FactorKharid.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 102;
                    _NameSanadText = xtp_FactorBargashtAzKharid.Text;
                }
                else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
                {
                    _NameAmaliatCode = 1;
                    _NameSanadCode = 103;
                    _NameSanadText = xtp_SefareshKharid.Text;
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



                if (_FirstSelectAnbar_NextSanad)
                {
                    gridView.Columns["FNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    gridView.Columns["SNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = true;
                    gridView.Columns["SNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = true;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].GroupIndex = 0;
                    //if (Convert.ToInt32(cmbNameAnbar.EditValue) > 0)
                    //    btnDisplyList.Enabled = true;
                    //else
                    //    btnDisplyList.Enabled = false;

                }
                else
                {
                    gridView.Columns["FNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    gridView.Columns["SNumberCol_BaNameSanad_BeSelectAnbar"].Visible = true;
                    gridView.Columns["FNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["SNumberJoze_BaNameSanad_BaSelectAnbar"].Visible = false;
                    gridView.Columns["FNumberCol_BaNameSanad_BeSelectAnbar"].GroupIndex = 0;
                    btnDisplyList.Enabled = true;
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
                        _AnbarId = _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode).ToList();
                        gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar).ToList() : null;

                    }
                    else
                    {
                        var list = dbContext.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode).ToList();
                        gridControl.DataSource = list.Count > 0 ? list.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar).ToList() : null;
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
        int _FNumberCol_BaNameSanad_BeSelectAnbar = 0;
        int _FNumberJoze_BaNameSanad_BaSelectAnbar = 0;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    try
                    {
                        _FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar").ToString());
                        _FNumberJoze_BaNameSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaSelectAnbar").ToString());
                        _NameAmaliatCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameAmaliatCode").ToString());
                        _NameSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameSanadCode").ToString());
                        _NameSanadText = gridView.GetFocusedRowCellValue("NameSanadText").ToString();

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //string NameSanad = XtraTabControl1_1.SelectedTabPage.Text;
                    if (XtraMessageBox.Show("آیا " + _NameSanadText + " مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                //_AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                _AnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AnbarId").ToString());
                                var q = db.FkAmaliatFrooshVKharid_Rizs.Where(s => s.SalId == _SalId && s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode
                                && s.FNumberCol_BaNameSanad_BeSelectAnbar == _FNumberCol_BaNameSanad_BeSelectAnbar).ToList();
                                if (q.Count > 0)
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        var q1 = q.Where(s => s.FNumberJoze_BaNameSanad_BaSelectAnbar == _FNumberJoze_BaNameSanad_BaSelectAnbar && s.AnbarId == _AnbarId).ToList();
                                        db.FkAmaliatFrooshVKharid_Rizs.RemoveRange(q1);
                                    }
                                    else
                                        db.FkAmaliatFrooshVKharid_Rizs.RemoveRange(q);
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
                        int _FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar").ToString());
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (_FirstSelectAnbar_NextSanad)
                            fm._AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                        if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorFroosh)
                        {
                            fm.Name = "FrmFactorFrooshKala";
                            //fm.Text = "فاکتور فروش";
                            //fm.cmbNameSanad.SelectedIndex = 0;
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzFroosh)
                        {
                            fm.Name = "FrmFactorBargashtAzFroosh";
                            //fm.Text = "فاکتور برگشت از فروش";
                            //fm.cmbNameSanad.SelectedIndex = 1;
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshFroosh)
                        {
                            fm.Name = "FrmSefareshFrooshKala";
                            //fm.Text = "سفارش فروش";
                            //fm.cmbNameSanad.SelectedIndex = 2;
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorKharid)
                        {
                            fm.Name = "FrmFactorKharidKala";
                            //fm.Text = "فاکتور خرید";
                            //fm.cmbNameSanad.SelectedIndex = 4;
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_FactorBargashtAzKharid)
                        {
                            fm.Name = "FrmFactorBargashtAzKharid";
                            //fm.Text = "فاکتور برگشت از خرید";
                            //fm.cmbNameSanad.SelectedIndex = 5;
                        }
                        else if (xtc_ListFrooshVKharid.SelectedTabPage == xtp_SefareshKharid)
                        {
                            fm.Name = "FrmSefareshKharidKala";
                            // fm.Text = "سفارش خرید";
                            //fm.cmbNameSanad.SelectedIndex = 6;
                        }

                        fm._FNumber_BeNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BeNameAmaliat_BeSelectAnbar"));
                        fm._FNumber_BaNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumber_BaNameAmaliat_BeSelectAnbar"));
                        fm._FNumberCol_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberCol_BaNameSanad_BeSelectAnbar"));
                        fm._FNumber_BaNameAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaSelectAnbar"));
                        fm._FNumberJoze_BaNameSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaSelectAnbar"));
                        fm._FNumberJoze_BaNameSanad_BaNoeFactor = Convert.ToInt32(gridView.GetFocusedRowCellValue("FNumberJoze_BaNameSanad_BaNoeFactor"));


                        fm.ShowDialog(this);

                       // // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                       // // btnSaveAndNext.Enabled = false;
                       // //_AnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AnbarId"));
                       // //_SeryalCol_BaNameAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNameAmaliat_BeSelectAnbar").ToString());
                       // //_SeryalJoze_BaNameSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNameSanad_BeSelectAnbar").ToString());

                       // //if (_FirstSelectAnbar_NextSanad)
                       //// {
                       //     //panelControl_NameAnbar.Enabled = false;

                       //     //txtSeryalCol_BaNameAmaliat_BeSelectAnbar.Text = txtSeryalJoze_BaNameSanad_BeSelectAnbar.Text = "0";
                       //     //_SeryalCol_BaNameAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNameAmaliat_BaSelectAnbar").ToString());
                       //     //_SeryalJoze_BaNameSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNameSanad_BaSelectAnbar").ToString());
                       // //}
                       //// else
                       //// {
                       //     //txtSeryalCol_BaNameAmaliat_BaSelectAnbar.Text = txtSeryalJoze_BaNameSanad_BaSelectAnbar.Text = "0";
                       //     //txtSeryalCol_BaNameAmaliat_BaSelectAnbar.Visible = txtSeryalJoze_BaNameSanad_BaSelectAnbar.Visible = false;
                       //     //lblSeryalCol_BaNameAmaliat_BaSelectAnbar.Visible = lblSeryalJoze_BaNameSanad_BaSelectAnbar.Visible = false;
                       //// }
                       // //////////////////////////////////////////////////////////////////////////////////////////////////////
                       // fm._NameSanadIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameSanadIndex"));
                       // fm._NameSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameSanadCode").ToString());
                       // int? fm._GhateySanadNamber = null;
                       // if (gridView.GetFocusedRowCellValue("GhateySanadNamber") != null)
                       //     _GhateySanadNamber = Convert.ToInt32(gridView.GetFocusedRowCellValue("GhateySanadNamber").ToString());
                       // int _SabetAtefNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("SabetAtefNumber").ToString());
                       // int _RozaneSanadNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("RozaneSanadNumber").ToString());
                       // int? _PaygiriNumber = null;
                       // if (gridView.GetFocusedRowCellValue("PaygiriNumber") != null)
                       //     _PaygiriNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("PaygiriNumber").ToString());
                       // string _DateTimePaygiri = string.Empty;
                       // if (gridView.GetFocusedRowCellValue("DateTimePaygiri") != null)
                       //     _DateTimePaygiri = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimePaygiri")).ToString();
                       // string _DateTimeSanad = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimeSanad")).ToString();
                       // bool _IsRiali = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRiali"));
                       // //string _SabetAtefNumber = gridView.GetFocusedRowCellValue("SabetAtefNumber").ToString();
                       // int _MoinId = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabMoinId"));
                       // // string _TafsiliId = gridView.GetFocusedRowCellValue("TafsiliName").ToString();
                       // _SharhSanad = gridView.GetFocusedRowCellValue("SharhSanad") != null ? gridView.GetFocusedRowCellValue("SharhSanad").ToString() : null;
                       // int _Tafsili1Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili1Id"));
                       // int _Tafsili2Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili2Id"));
                       // int _Tafsili3Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili3Id"));
                       // ActiveButtons();

                       // var q2 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                       // var q3 = dbContext.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                       // switch (_NameAmaliatTabpageName)
                       // {
                       //     case "xtpVrodeKala":
                       //         {
                       //             if (_FirstSelectAnbar_NextSanad)
                       //             {
                       //                 cmbBeAnbar.EditValue = _BeAnbarId;
                       //                 cmbBeAnbar.ReadOnly = true;
                       //             }

                       //             var q1 = dbContext.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNameAmaliat_BeSelectAnbar == _SeryalCol_BeNameAmaliat_BeSelectAnbar).ToList();
                       //             var q = q1.Where(s => s.NameAmaliatCode == _NameAmaliatCode && s.NameSanadCode == _NameSanadCode && s.SeryalCol_BaNameAmaliat_BeSelectAnbar == _SeryalCol_BaNameAmaliat_BeSelectAnbar).ToList();
                       //             if (q.Count > 0)
                       //             {
                       //                 cmbNameSanad.Properties.Items.Clear();
                       //                 cmbNameSanad.Properties.Items.Add("رسید خرید");
                       //                 cmbNameSanad.Properties.Items.Add("برگشت از فروش");
                       //                 cmbNameSanad.Properties.Items.Add("رسید کالای امانی");
                       //                 cmbNameSanad.Properties.Items.Add("رسید تولید");
                       //                 cmbNameSanad.Properties.Items.Add("برگشت از حواله تولید");
                       //                 cmbNameSanad.Properties.Items.Add("برگشت از حواله هزینه");
                       //                 cmbNameSanad.Properties.Items.Add("برگشت از حواله اموال");
                       //                 cmbNameSanad.Properties.Items.Add("اضافات انبار");
                       //                 if (_FirstSelectAnbar_NextSanad)
                       //                     cmbNameSanad.Properties.Items.Add("رسید (جابجایی)");
                       //                 else
                       //                     cmbNameSanad.Properties.Items.Add("جابجایی کالا");
                       //                 cmbNameSanad.Properties.Items.Add("رسید تبدیل");
                       //                 cmbNameSanad.Properties.Items.Add("رسید سایر");
                       //                 cmbNameSanad.Properties.Items.Add("موجودی اول دوره");

                       //                 // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                       //                 cmbNameSanad.SelectedIndex = _NameSanadIndex;
                       //                 txtSeryalCol_BaNameAmaliat_BeSelectAnbar.Text = _SeryalCol_BaNameAmaliat_BeSelectAnbar.ToString();
                       //                 txtSeryalJoze_BaNameSanad_BeSelectAnbar.Text = _SeryalJoze_BaNameSanad_BeSelectAnbar.ToString();
                       //                 txtSeryalCol_BaNameAmaliat_BaSelectAnbar.Text = _SeryalCol_BaNameAmaliat_BaSelectAnbar.ToString();
                       //                 txtSeryalJoze_BaNameSanad_BaSelectAnbar.Text = _SeryalJoze_BaNameSanad_BaSelectAnbar.ToString();
                       //                 txtGhateySanadNumber.Text = _GhateySanadNamber != null ? _GhateySanadNamber.ToString() : "";
                       //                 txtSabetAtefNumber.Text = _SabetAtefNumber.ToString();
                       //                 txtRozaneSanadNumber.Text = _RozaneSanadNumber.ToString();
                       //                 txtPaygiriNumber.Text = _PaygiriNumber != null ? _PaygiriNumber.ToString() : "";
                       //                 //txtNameAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                       //                 //txtNameSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                       //                 //txtNameSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                       //                 //txtNameSanad.BackColor = Color.Yellow;
                       //                 HelpClass1.DateTimeMask(txtPaygiriTarikh);
                       //                 txtPaygiriTarikh.Text = _DateTimePaygiri;
                       //                 HelpClass1.DateTimeMask(txtTarikhSanad);
                       //                 txtTarikhSanad.Text = _DateTimeSanad;
                       //                 //chkIsSanadHesabdari.Checked = _IsRiali;
                       //                 //txtSabetAtefNumber.Text = _SabetAtefNumber;
                       //                 txtSharhSanad.Text = _SharhSanad;
                       //                 //lblSanadNamber.BackColor = Color.Yellow;
                       //                 // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                       //                 xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = false;
                       //                 xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                       //                 xtpAmaliatAddVEdit.PageVisible = true;
                       //                 //NameSanad = NameSanad + " : نوع رسید " + ": " + XtraTabControl1_1.SelectedTabPage.Text;
                       //                 //xtpAmaliatAddVEdit.Text = NameSanad;
                       //                 xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                       //                 //lblSeryalCol_BaNameAmaliat_BeSelectAnbar.Text = "ش رسید در کل انبارها";
                       //                 //lblSeryalCol_BaNameAmaliat_BaSelectAnbar.Text = "ش رسید در انبار انتخابی";
                       //                 //lblSeryalJoze_BaNameSanad_BaSelectAnbar.Text = "ش رسید در نوع رسید";
                       //                 FillCmbHesabMoin();
                       //                 cmbHesabMoin.EditValue = _MoinId;
                       //                 cmbHesabTafsili1.EditValue = _Tafsili1Id;
                       //                 cmbHesabTafsili2.EditValue = _Tafsili2Id;
                       //                 cmbHesabTafsili3.EditValue = _Tafsili3Id;
                       //                 //cmbHesabTafsili1.Text = q3.Find(s => s.Id == _Tafsili1Id).Name.ToString();
                       //                 //cmbHesabTafsili2.Text = q3.Find(s => s.Id == _Tafsili2Id).Name.ToString();
                       //                 //cmbHesabTafsili3.Text = q3.Find(s => s.Id == _Tafsili3Id).Name.ToString();
                       //                 //cmbHesabTafsili1.ShowPopup();
                       //                 //cmbHesabTafsili1.ClosePopup();
                       //                 //cmbHesabTafsili2.ShowPopup();
                       //                 //cmbHesabTafsili2.ClosePopup();
                       //                 //cmbHesabTafsili3.ShowPopup();
                       //                 //cmbHesabTafsili3.ClosePopup();

                       //                 //List<AKAmaliatAnbarVKala_Riz> DBGridControl = (List<AKAmaliatAnbarVKala_Riz>)gridControl.DataSource;
                       //                 //BindingList<AKAmaliatAnbarVKala_Riz> bl = new BindingList<AKAmaliatAnbarVKala_Riz>(DBGridControl);
                       //                 //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                       //                 foreach (var item in q1)
                       //                 {
                       //                     item.KalaCode_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                       //                     item.KalaName_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                       //                     item.VahedeKala_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).EpVahedAsliKala.Name;
                       //                     item.AzAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                       //                     item.BeAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.BeAnbarId).Name;
                       //                 }

                       //                 //dbContext.AKAmaliatAnbarVKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                       //                 //{
                       //                 //    // Bind data to control when loading complete
                       //                 //    gridControl.DataSource = dbContext.AKAmaliatAnbarVKala_Rizs.Local.ToBindingList();
                       //                 //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                       //                 //xtp_AddVaEdit.PageVisible = true;

                       //                 //dbContext.AKAmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).Load();
                       //                 // Bind data to control when loading complete

                       //                 if (_NameSanadIndex == 8 || _NameSanadIndex == 9)
                       //                 {
                       //                     cmbAzAnbar.EditValue = _AzAnbarId;
                       //                     cmbBeAnbar.EditValue = _BeAnbarId;
                       //                     amaliatAnbarVKala_RizsBindingSource1.DataSource = q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NameAmaliatCode == 3).ToList().Count > 0 ? q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NameAmaliatCode == 3).ToList() : null;
                       //                     amaliatAnbarVKala_RizsBindingSource2.DataSource = q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NameAmaliatCode == 2).ToList().Count > 0 ? q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NameAmaliatCode == 2).ToList() : null;
                       //                 }
                       //                 else
                       //                 {
                       //                     if (!_FirstSelectAnbar_NextSanad)
                       //                     {
                       //                         //akVorodeKala_RizsBindingSource.DataSource = dbContext.AKAmaliatAnbarVKala_Rizs.Local.ToBindingList();
                       //                         amaliatAnbarVKala_RizsBindingSource1.DataSource = q.Count > 0 ? q.ToList() : null;
                       //                     }
                       //                     else
                       //                     {
                       //                         var q4 = q.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                       //                         amaliatAnbarVKala_RizsBindingSource1.DataSource = q4.Count > 0 ? q4.ToList() : null;
                       //                     }
                       //                 }


                       //                 txtTarikhSanad.Focus();

                       //             }


                       //             //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                       //             //{
                       //             //    if (XtraTabControl1_1.TabPages[i].Name != NameSanadTabpageName)
                       //             //    {
                       //             //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                       //             //    }
                       //             //}

                       //             break;
                       //         }
                       //     default:
                       //         break;
                       // }

                       // cmbNameSanad.ReadOnly = true;

                       // //if (cmbNameSanad.SelectedIndex == 8)
                       // //{
                       // //    cmbAzAnbar.EditValue = _AzAnbarId;
                       // //    cmbBeAnbar.EditValue = _BeAnbarId;
                       // //    amaliatAnbarVKala_RizsBindingSource2.DataSource = amaliatAnbarVKala_RizsBindingSource1.DataSource;
                       // //}
                       // //if (cmbNameSanad.SelectedIndex == 8 || cmbNameSanad.SelectedIndex == 9)
                       // //{
                       // //    cmbAzAnbar.EditValue = _AzAnbarId;
                       // //    cmbBeAnbar.EditValue = _BeAnbarId;
                       // //}

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
    }
}