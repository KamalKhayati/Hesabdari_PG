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
using DBHesabdari_PG;
using HelpClassLibrary;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DBHesabdari_PG.Models.AK;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmJabejaeeKala : DevExpress.XtraEditors.XtraForm
    {
        MyContext dbContext;
        public FrmJabejaeeKala()
        {
            InitializeComponent();
        }

        public EnumCED En1 = EnumCED.Cancel;
        public EnumCED En2;

        // XtraTabControl XtraTabControl1_1;
        GridControl gridControl;
        GridView gridView;
        //LookUpEdit cmbTabaghehKala;
        //LookUpEdit cmbGroupAsliKala;
        //LookUpEdit cmbGroupFareeKala;
        //LookUpEdit cmbVahedKala;
        //SimpleButton btnReloadTabaghehKala;
        //SimpleButton btnReloadGroupAsli;
        //SimpleButton btnReloadGroupFaree;
        //TextEdit txtCode;
        //TextEdit txtGroupCode;
        //CheckEdit chkEditCode;
        //SimpleButton btnNewCode;
        //TextEdit txtId;
        //TextEdit txtName;
        //TextEdit txtTarikhEjad;
        //CheckEdit chkIsActive;
        //TextEdit txtSharh;
        //PanelControl PanelControl1;
        //PanelControl PanelControl2;

        public int _AzAnbarId = 0;
        public int _BeAnbarId = 0;
        string _SharhSanad = string.Empty;

        public string _KalaId = string.Empty;
        public string _KalaCode = string.Empty;
        public string _KalaName = string.Empty;
        public string _VahedeKala = string.Empty;
        public string _Meghdar = string.Empty;
        public string _Nerkh = string.Empty;
        public string _Mablag = string.Empty;
        public string _Tozihat = string.Empty;
        public int _RowHandle = 0;

        string NoeAmaliatTabpageName = string.Empty;
        //string NoeSanadTabpageName = string.Empty;
        string NoeAmaliatTabpageText = string.Empty;
        //  int _IndexTabPage = 0;
        int _NoeAmaliatCodeResid = 0;
        int _NoeAmaliatCodeHavale = 0;
        int _NoeSanadCode = 0;

        int _SalId = 0;
        //int _AzAnbarId = 0;
        // int _TabPageCount = 0;
        int EditRowIndex = 0;
        bool IsClosed_AmaliatAddVEit = true;

        public void FillGridControl()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    var q2 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();

                    var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeHavale && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal_darSelectNoe).ToList();
                    if (q.Count() > 0)
                    {
                        foreach (var item in q.ToList())
                        {
                            //item.AzAnbarName = q1.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                            item.AzAnbarName = q1.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                            item.BeAnbarName = q1.FirstOrDefault(s => s.Id == item.BeAnbarId).Name;
                            //item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Code.ToString();
                            //item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name;
                            item.KalaCode = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                            item.KalaName = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                            item.VahedeKala = q2.FirstOrDefault(s => s.Id == item.KalaId).VahedAsliName_NM;
                        }

                        //dbContext.AkKhorojeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                        //{
                        //    // Bind data to control when loading complete
                        //    gridControl.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                        gridControl.DataSource = q.OrderBy(s => s.Seryal_darSelectNoe);
                    }
                    else
                        gridControl.DataSource = null;

                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillCmbAzAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                    foreach (var item in q1)
                    {
                        var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                        if (qq.Count > 0)
                        {
                            string _KalaId = String.Empty;
                            foreach (var item2 in qq)
                            {
                                _KalaId += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                            }
                            item.TabagheKalaIdName_NM = _KalaId;
                        }
                    }

                    if (En1 == EnumCED.Create)
                        epListAnbarhasBindingSource.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).ToList() : null;
                    else
                        epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;

                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    //var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    //if (En1 == EnumCED.Edit)
                    //    cmbAzAnbar.Properties.DataSource = q.Count > 0 ? q : null;
                    //else
                    //    cmbAzAnbar.Properties.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true) : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillCmbBeAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.Id != _AzAnbarId).OrderBy(s => s.Code).ToList();
                    var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                    foreach (var item in q1)
                    {
                        var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                        if (qq.Count > 0)
                        {
                            string _KalaId = String.Empty;
                            foreach (var item2 in qq)
                            {
                                _KalaId += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                            }
                            item.TabagheKalaIdName_NM = _KalaId;
                        }
                    }

                    if (En1 == EnumCED.Create)
                        epListAnbarhasBindingSource1.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).ToList() : null;
                    else
                        epListAnbarhasBindingSource1.DataSource = q1.Count > 0 ? q1 : null;


                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    //_AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                    //var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.Id != _AzAnbarId).OrderBy(s => s.Code).ToList();
                    //if (En1 == EnumCED.Edit)
                    //    cmbBeAnbar.Properties.DataSource = q.Count > 0 ? q : null;
                    //else
                    //    cmbBeAnbar.Properties.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true) : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ActiveButtons()
        {
            //if (En1 == EnumCED.None)
            //{
            //    btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled =
            //        btnSaveAndPrintAndClosed.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled =
            //        btnDisplyList.Enabled = btnPrintPreview.Enabled = false;
            //    btnClose.Enabled = true;
            //}
            if (En1 == EnumCED.Create)
            {
                btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled =
                    btnSaveAndPrintAndClosed.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled =
                    btnDisplyList.Enabled = btnPrintPreview.Enabled = btnClose.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (En1 == EnumCED.Edit)
            {
                btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled =
                    btnDisplyList.Enabled = btnPrintPreview.Enabled = btnClose.Enabled = false;
                btnCancel.Enabled = btnSaveAndClosed.Enabled = btnSaveAndPrintAndClosed.Enabled = btnSaveAndNext.Enabled = true;
            }
            else if (En1 == EnumCED.Save || En1 == EnumCED.Cancel)
            {
                btnDelete.Enabled = btnEdit.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled =
                   btnSaveAndPrintAndClosed.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnCancel.Enabled = false;
                if (IsClosed_AmaliatAddVEit)
                    btnClose.Enabled = btnCreate.Enabled = btnDisplyList.Enabled = btnPrintPreview.Enabled = true;
                else
                    btnCancel.Enabled = true;

            }
        }

        public bool IsValidation()
        {
            // string s = txtMeghdar.Text.Trim();
            if (Convert.ToInt32(cmbAzAnbar.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً انبار مبداء را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAzAnbar.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbBeAnbar.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً انبار مقصد را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBeAnbar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryal.Text))
            {
                XtraMessageBox.Show("فیلد سریال خالی است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryal.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikh.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNoeSanad.Text) || string.IsNullOrEmpty(txtNoeSanad1.Text) || string.IsNullOrEmpty(txtNoeAmaliat1.Text))
            {
                XtraMessageBox.Show("نوع سند مشخص نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoeSanad.Focus();
                return false;
            }
            else if (gridView_AmaliatAddVaEdit.RowCount == 0)
            {
                XtraMessageBox.Show("اطلاعاتی برای ذخیره وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnInsert.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //gridView_AmaliatAddVaEdit.DeleteSelectedRows();
                gridView_AmaliatAddVaEdit.DeleteRow(gridView_AmaliatAddVaEdit.FocusedRowHandle);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            En2 = EnumCED.Create;
            FrmAmaliatSelectKala fm = new FrmAmaliatSelectKala(this);
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
            fm.BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
            fm.ShowDialog();

            //gridView_AmaliatAddVaEdit.AddNewRow();
            //gridView_AmaliatAddVaEdit.FocusInvalidRow();
            //gridView_AmaliatAddVaEdit.SetRowCellValue(0, "M", 10);
            //add a new row
            //gridView_AmaliatAddVaEdit.AddNewRow();
            //set a new row cell value. The static GridControl.NewItemRowHandle field allows you to retrieve the added row
            //gridView_AmaliatAddVaEdit.SetRowCellValue(GridControl.NewItemRowHandle, gridView_AmaliatAddVaEdit.Columns["Meghdar"], 11);

            //gridView_AmaliatAddVaEdit_InitNewRow(null, null);
            //gridView_AmaliatAddVaEdit.AddNewRow();
            //if (gridView_AmaliatAddVaEdit.RowCount > 0)
            //    _Index = gridView_AmaliatAddVaEdit.RowCount;
            //else
            //    _Index = 0;
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Meghdar", "105");
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Nerkh", "106");
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Mablag", "107");


            //BindingList<AkKhorojeKala_Riz> List1 = new BindingList<AkKhorojeKala_Riz>();
            //List1[0].Mablag = 11;
            //(gridControl_AmaliatAddVaEdit.DataSource as BindingList<List1>).AddNew();


            //List<AkKhorojeKala_Riz> list = new List<AkKhorojeKala_Riz>()
            //          {
            //              new AkKhorojeKala_Riz { Meghdar = 11, },
            //              new AkKhorojeKala_Riz { Meghdar = 12, },
            //          };
            //BindingList<AkKhorojeKala_Riz> bindingList = new BindingList<AkKhorojeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

            //List<AkKhorojeKala_Riz> list = new List<AkKhorojeKala_Riz>()
            //{
            //    new AkKhorojeKala_Riz(){Meghdar = 13,Nerkh = 14,Mablag = 15,}
            //};
            //BindingList<AkKhorojeKala_Riz> bindingList = new BindingList<AkKhorojeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit.RowCount > 0)
            {
                En2 = EnumCED.Edit;
                _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetFocusedRowCellValue("AzAnbarId"));
                _KalaId = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaId");
                _KalaCode = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaCode");
                _KalaName = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaName");
                _VahedeKala = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("VahedeKala");
                _Meghdar = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Meghdar");
                _Nerkh = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Nerkh");
                _Mablag = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Mablag");
                _Tozihat = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Tozihat");
                _RowHandle = gridView_AmaliatAddVaEdit.FocusedRowHandle;

                FrmAmaliatSelectKala fm = new FrmAmaliatSelectKala(this);
                //fm.MdiParent = this;
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                fm.AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                fm.BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
                fm.ShowDialog();

            }
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "KalaCode", _KalaCode);
            view.SetRowCellValue(e.RowHandle, "KalaName", _KalaName);
            view.SetRowCellValue(e.RowHandle, "VahedeKala", _VahedeKala);
            view.SetRowCellValue(e.RowHandle, "Meghdar", _Meghdar);
            view.SetRowCellValue(e.RowHandle, "Nerkh", _Nerkh);
            view.SetRowCellValue(e.RowHandle, "Mablag", _Mablag);
            view.SetRowCellValue(e.RowHandle, "Tozihat", _Tozihat);
            view.SetRowCellValue(e.RowHandle, "AzAnbarId", _AzAnbarId);
            view.SetRowCellValue(e.RowHandle, "KalaId", _KalaId);

            // gridView_AmaliatAddVaEdit.AddNewRow();
        }

        private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);
            //HelpClass1.MoveFirst(gridView_AmaliatAddVaEdit);
            //gridView_AmaliatAddVaEdit.FocusInvalidRow();
            //HelpClass1.MoveLast(gridView_AmaliatAddVaEdit);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        En1 = EnumCED.Create;
                        ActiveButtons();
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        //XtraTabControl1_1 = xtcAmaliatRozaneh;
                        //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                        //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                        txtNoeAmaliat1.Text = xtcAmaliatJabejaee.SelectedTabPage.Name;
                        txtNoeSanad1.Text = xtcAmaliatJabejaee.SelectedTabPage.Name;
                        txtNoeSanad.Text = xtcAmaliatJabejaee.SelectedTabPage.Text;
                        //txtNoeSanad.BackColor = Color.LightGreen;
                        //lblSanadNamber.BackColor = Color.LightGreen;
                        xtpAmaliatAddVEdit.PageVisible = true;
                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                        xtpAmaliatAddVEdit.Text = "عملیات ایجاد";
                        HelpClass1.DateTimeMask(txtTarikh);
                        txtTarikh.Text = DateTime.Now.ToString();
                        chkIsSanadHesabdari.Checked = true;

                        var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeHavale && s.NoeSanadCode == _NoeSanadCode).ToList();
                        if (q.Count > 0)
                        {
                            txtSeryal.Text = (q.Max(s => s.Seryal_darSelectNoe) + 1).ToString();
                        }
                        else
                            txtSeryal.Text = "1";
                        xtcAmaliatJabejaee.SelectedTabPageIndex = 1;

                        dbContext = new MyContext();
                        //dbContext.AkKhorojeKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                        //{
                        //    // Bind data to control when loading complete
                        //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                        dbContext.AkKhorojeKala_Rizs.Where(s => s.Id == 0).Load();
                        // Bind data to control when loading complete
                        akKhorojeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();

                        xtpJabejaeeKala.PageEnabled = false;
                        FillCmbAzAnbar();
                        // FillCmbBeAnbar();
                        txtTarikh.Focus();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void FrmJabejaeeKala_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            //En1 = EnumCED.None;
            //ActiveButtons();
            //NoeAmaliatTabpageIndex = 0;
            //NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
            //_NoeAmaliatCodeResid = 2;
            //_NoeSanadCode = 201;
            //// xtcAmaliatRozaneh.SelectedTabPageIndex = 0;
            //NoeSanadTabpageIndex = 0;
            //XtraTabControl1_1 = xtc_VorodeKala;
            //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
            //NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
            xtcAmaliatRozaneh_SelectedPageChanged(null, null);
            gridControl = gridControl_JabejaeeKala;
            gridView = gridView_JabejaeeKala;
            // XtraTabControl1_1.SelectedTabPageIndex = 0;
            //FillCmbAzAnbar();
            FillGridControl();
            txtTarikh.Focus();
        }

        int NoeAmaliatTabpageIndex = 0;
        private void xtcAmaliatRozaneh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                if (xtcAmaliatJabejaee.SelectedTabPage.Name == "xtpJabejaeeKala")
                {
                    NoeAmaliatTabpageIndex = 0;
                    NoeAmaliatTabpageName = xtcAmaliatJabejaee.SelectedTabPage.Name;
                    //NoeSanadName = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCodeResid = 2;
                    _NoeAmaliatCodeHavale = 3;
                    //NoeSanadTabpageIndex = 2;
                    //NoeSanadTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    NoeAmaliatTabpageText = xtcAmaliatJabejaee.SelectedTabPage.Text;
                    gridControl = gridControl_JabejaeeKala;
                    gridView = gridView_JabejaeeKala;
                    _NoeSanadCode = 400;
                    btnCreate.Enabled = true;

                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;
                    btnDisplyList_Click(null, null);
                }
            }
        }

        private void btnReloadAzAnbar_Click(object sender, EventArgs e)
        {
            FillCmbAzAnbar();
        }

        private void btnReloadBeAnbar_Click(object sender, EventArgs e)
        {
            FillCmbBeAnbar();
        }

        private void cmbAzAnbar_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbAzAnbar.EditValue) > 0)
                FillCmbBeAnbar();
            //cmbBeAnbar.EditValue = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FillGridControl();

            xtpJabejaeeKala.PageEnabled = true;
            HelpClass1.ClearControls(panelControl_AddVaEdit);
            cmbBeAnbar.EditValue = cmbBeAnbar.EditValue = null;
            epListAnbarhasBindingSource.Clear();
            epListAnbarhasBindingSource1.Clear();
            btnDelete1.Enabled = btnEdit1.Enabled = false;

            En1 = EnumCED.Cancel;
            xtcAmaliatJabejaee.SelectedTabPageIndex = NoeAmaliatTabpageIndex;
            //XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex;
            // if (NoeAmaliatTabpageIndex == 0 && NoeSanadTabpageIndex == 0)
            // XtraTabControl1_1_SelectedPageChanged(null, null);

            xtpAmaliatAddVEdit.PageVisible = false;

            akKhorojeKala_RizsBindingSource.Clear();
            //akVorodeKala_RizsBindingSource.DataSource = null;

            ActiveButtons();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Enabled)
            {
                this.Close();

            }
        }

        bool _IsActiveRow = true;
        private void cmbControl_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    try
                    {
                        int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //string NoeSanad = XtraTabControl1_1.SelectedTabPage.Text;
                    if (XtraMessageBox.Show("آیا جابجایی مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                                var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal);
                                if (q != null)
                                {
                                    db.AkAllAmaliateRozanehs.RemoveRange(q);
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
                        int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        dbContext = new MyContext();
                        En1 = EnumCED.Edit;
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                        string _DateTimeSanad = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimeSanad")).ToString();
                        bool _IsRiali = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRiali"));
                        string _lblSanadNamber = gridView.GetFocusedRowCellValue("SanadNamber").ToString();
                        FillCmbAzAnbar();
                        int _AzAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AzAnbarId"));
                        int _BeAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("BeAnbarId"));
                        //string _BeAnbarId = gridView.GetFocusedRowCellValue("HesabTafsiliId").ToString();
                        _SharhSanad = gridView.GetFocusedRowCellValue("SharhSanad") != null ? gridView.GetFocusedRowCellValue("SharhSanad").ToString() : null;
                        // int _TafsiliId = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsiliId"));
                        ActiveButtons();

                        //for (int i = 0; i < xtcAmaliatRozaneh.TabPages.Count; i++)
                        //{
                        //    if (xtcAmaliatRozaneh.TabPages[i].Name != "xtpAmaliatAddVEdit")
                        //    {
                        //        xtcAmaliatRozaneh.TabPages[i].PageEnabled = false;
                        //    }
                        //}

                        //var q1 = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId).ToList();
                        var q2 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId).ToList();

                        var q = dbContext.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeHavale && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal).ToList();
                        if (q.Count > 0)
                        {
                            // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                            txtSeryal.Text = _Seryal.ToString();
                            txtNoeAmaliat1.Text = xtcAmaliatJabejaee.SelectedTabPage.Name;
                            txtNoeSanad1.Text = xtcAmaliatJabejaee.SelectedTabPage.Name;
                            txtNoeSanad.Text = xtcAmaliatJabejaee.SelectedTabPage.Text;
                            //txtNoeSanad.BackColor = Color.Yellow;
                            HelpClass1.DateTimeMask(txtTarikh);
                            txtTarikh.Text = _DateTimeSanad;
                            chkIsSanadHesabdari.Checked = _IsRiali;
                            lblSanadNamber.Text = _lblSanadNamber;
                            txtSharhSanad.Text = _SharhSanad;
                            //lblSanadNamber.BackColor = Color.Yellow;
                            // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                            xtpJabejaeeKala.PageEnabled = false;
                            xtcAmaliatJabejaee.SelectedTabPageIndex = 1;
                            xtpAmaliatAddVEdit.PageVisible = true;
                            xtpAmaliatAddVEdit.Text = "عملیات ویرایش";
                            xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                            FillCmbAzAnbar();
                            cmbAzAnbar.EditValue = _AzAnbarId;
                            cmbBeAnbar.EditValue = _BeAnbarId;
                            //cmbBeAnbar.Text = _BeAnbarId;
                            //cmbBeAnbar.ShowPopup();
                            //cmbBeAnbar.ClosePopup();

                            //List<AkKhorojeKala_Riz> DBGridControl = (List<AkKhorojeKala_Riz>)gridControl.DataSource;
                            //BindingList<AkKhorojeKala_Riz> bl = new BindingList<AkKhorojeKala_Riz>(DBGridControl);
                            //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                            foreach (var item in q)
                            {
                                item.KalaCode = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                item.KalaName = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                item.VahedeKala = q2.FirstOrDefault(s => s.Id == item.KalaId).VahedAsliName_NM;
                            }

                            //dbContext.AkKhorojeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                            //{
                            //    // Bind data to control when loading complete
                            //    gridControl.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                            //xtp_AddVaEdit.PageVisible = true;

                            //dbContext.AkKhorojeKala_Rizs.Where(s => s.Id == 0).Load();
                            // Bind data to control when loading complete
                            akKhorojeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                        }


                        //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                        //{
                        //    if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
                        //    {
                        //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                        //    }
                        //}
                        txtTarikh.Focus();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void cmbAzAnbar_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create || En1 == EnumCED.Save)
            {
                cmbAzAnbar.ShowPopup();
            }

        }

        private void cmbBeAnbar_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create)
            {
                cmbBeAnbar.ShowPopup();
            }

        }

        private void btnSaveAndClosed_Click(object sender, EventArgs e)
        {
            if (btnSaveAndClosed.Enabled)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        // int _AnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                        int _Seryal = Convert.ToInt32(txtSeryal.Text);
                        //DateTime _DateTimeSanad = Convert.ToDateTime(DateTime.Now.ToString().Replace(DateTime.Now.ToString().Substring(0, 10), txtTarikh.Text));
                        DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                        DateTime _DateTimeInsert = DateTime.Now;
                        _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                        _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
                        var _AnbarList = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                        var _MoinList = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                        _SharhSanad = txtSharhSanad.Text;
                        if (IsValidation())
                        {
                            var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                            if (En1 == EnumCED.Create)
                            {
                                List<AkAllAmaliateRozaneh> List = new List<AkAllAmaliateRozaneh>();
                                for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                                {
                                    long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                    decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                    decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                    decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                    string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;
                                    ////////////////////// دستورات خروج کالا ///////////////////
                                    AkKhorojeKala_Riz obj1 = new AkKhorojeKala_Riz();
                                    obj1.SalId = _SalId;
                                    obj1.AzAnbarId = _AzAnbarId;
                                    obj1.BeAnbarId = _BeAnbarId;
                                    obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                    obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                    obj1.Seryal_darSelectNoe = _Seryal;
                                    obj1.DateTimeSanad = _DateTimeSanad;
                                    obj1.DateTimeInsert = _DateTimeInsert;
                                    obj1.NoeAmaliatCode = _NoeAmaliatCodeHavale;
                                    obj1.NoeSanadCode = _NoeSanadCode;
                                    obj1.NoeSanadText = "حواله (جابجایی)";
                                    obj1.Meghdar = _Meghdar;
                                    obj1.Nerkh = _Nerkh;
                                    obj1.Mablag = _Mablag;
                                    obj1.IsRiali = _Mablag > 0 ? true : false;
                                    obj1.Radif = i + 1;
                                    obj1.Tozihat = _Tozihat;
                                    obj1.SharhSanad = _SharhSanad;
                                    obj1.RozaneSanadNumber = 1;
                                    obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                    obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                    obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                    obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;


                                    AkAllAmaliateRozaneh obj01 = new AkAllAmaliateRozaneh();
                                    obj01.SalId = _SalId;
                                    obj01.AzAnbarId = _AzAnbarId;
                                    obj01.BeAnbarId = _BeAnbarId;
                                    obj01.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                    obj01.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                    obj01.Seryal_darSelectNoe = _Seryal;
                                    obj01.DateTimeSanad = _DateTimeSanad;
                                    obj01.NoeAmaliatCode = _NoeAmaliatCodeHavale;
                                    obj01.NoeSanadCode = _NoeSanadCode;
                                    obj01.NoeSanadText = "حواله (جابجایی)";
                                    obj01.Meghdar = _Meghdar;
                                    obj01.Nerkh = _Nerkh;
                                    obj01.Mablag = _Mablag;
                                    obj01.IsRiali = _Mablag > 0 ? true : false;
                                    obj01.Radif = i + 1;
                                    obj01.RozaneSanadNumber = 1;
                                    obj01.AkKhorojeKala_Riz1 = obj1;
                                    obj01.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                    obj01.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                    obj01.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                    obj01.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                    List.Add(obj01);

                                    ////////////////////// دستورات ورود کالا ///////////////////
                                    AkVorodeKala_Riz obj2 = new AkVorodeKala_Riz();
                                    obj2.SalId = _SalId;
                                    obj2.AzAnbarId = _BeAnbarId;
                                    obj2.BeAnbarId = _AzAnbarId;
                                    obj2.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                    obj2.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                    obj2.Seryal_darSelectNoe = _Seryal;
                                    obj2.DateTimeSanad = _DateTimeSanad;
                                    obj2.DateTimeInsert = _DateTimeInsert;
                                    obj2.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                    obj2.NoeSanadCode = _NoeSanadCode;
                                    obj2.NoeSanadText = "رسید (جابجایی)";
                                    obj2.Meghdar = _Meghdar;
                                    obj2.Nerkh = _Nerkh;
                                    obj2.Mablag = _Mablag;
                                    obj2.IsRiali = _Mablag > 0 ? true : false;
                                    obj2.Radif = i + 1;
                                    obj2.Tozihat = _Tozihat;
                                    obj2.SharhSanad = _SharhSanad;
                                    obj2.RozaneSanadNumber = 1;
                                    obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                    obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                    obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                    obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;


                                    AkAllAmaliateRozaneh obj02 = new AkAllAmaliateRozaneh();
                                    obj02.SalId = _SalId;
                                    obj02.AzAnbarId = _BeAnbarId;
                                    obj02.BeAnbarId = _AzAnbarId;
                                    obj02.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                    obj02.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                    obj02.Seryal_darSelectNoe = _Seryal;
                                    obj02.DateTimeSanad = _DateTimeSanad;
                                    obj02.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                    obj02.NoeSanadCode = _NoeSanadCode;
                                    obj02.NoeSanadText = "رسید (جابجایی)";
                                    obj02.Meghdar = _Meghdar;
                                    obj02.Nerkh = _Nerkh;
                                    obj02.Mablag = _Mablag;
                                    obj02.IsRiali = _Mablag > 0 ? true : false;
                                    obj02.Radif = i + 1;
                                    obj02.RozaneSanadNumber = 1;
                                    obj02.AkVorodeKala_Riz1 = obj2;
                                    obj02.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                    obj02.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                    obj02.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                    obj02.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;

                                    List.Add(obj02);

                                }
                                db.AkAllAmaliateRozanehs.AddRange(List);
                                db.SaveChanges();
                                //En1 = EnumCED.Save;
                                //if (IsClosed_AmaliatAddVEit)
                                //    btnCancel_Click(null, null);


                            }
                            else if (En1 == EnumCED.Edit)
                            {
                                //_SalId = Convert.ToInt32(lblSalId.Text);
                                //int _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                //int _Seryal = Convert.ToInt32(txtSeryal.Text);
                                ///////////*******************
                                //DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                //DateTime _DateTimeInsert = DateTime.Now;
                                DateTime _DateTimeEdit = DateTime.Now;
                                BindingList<AkKhorojeKala_Riz> list = (BindingList<AkKhorojeKala_Riz>)akKhorojeKala_RizsBindingSource.DataSource;
                                var q2 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal && s.NoeSanadText == "حواله (جابجایی)").ToList();
                                var q21 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal).ToList();
                                foreach (var item in q2)
                                {
                                    if (!list.Any(s => s.Id == item.Id))
                                    {
                                        var kk = q21.Where(s => s.Radif == item.Radif).ToList();
                                        db.AkAllAmaliateRozanehs.RemoveRange(kk);
                                        db.SaveChanges();
                                    }
                                }

                                var q1 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal).ToList();
                                var k = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeHavale && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal).ToList();
                                var v = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeResid && s.NoeSanadCode == _NoeSanadCode && s.Seryal_darSelectNoe == _Seryal).ToList();
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i].Id > 0)
                                    {
                                        long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                        decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                        decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                        decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                        string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;
                                        int _RadifBefourEdit = list[i].Radif;
                                        /////////////////////// دستورات خروج کالا ///////////////////////
                                        var k1 = k.FirstOrDefault(s => s.Id == list[i].Id);
                                        //k1.SalId = _SalId;
                                        k1.AzAnbarId = _AzAnbarId;
                                        k1.BeAnbarId = _BeAnbarId;
                                        k1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        k1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        //k1.Seryal = _Seryal;
                                        k1.DateTimeSanad = _DateTimeSanad;
                                        k1.DateTimeEdit = _DateTimeEdit;
                                        //k1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        //k1.NoeSanadCode = _NoeSanadCode;
                                        //k1.NoeSanadText = NoeAmaliatTabpageText;
                                        k1.Meghdar = _Meghdar;
                                        k1.Nerkh = _Nerkh;
                                        k1.Mablag = _Mablag;
                                        k1.IsRiali = _Mablag > 0 ? true : false;
                                        k1.Radif = i + 1;
                                        k1.Tozihat = _Tozihat;
                                        k1.SharhSanad = _SharhSanad;
                                        k1.RozaneSanadNumber = 1;
                                        k1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                        k1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                        k1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                        k1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                        var A1 = q1.FirstOrDefault(s => s.Id == k1.Id);
                                        //A1.SalId = _SalId;
                                        A1.AzAnbarId = _AzAnbarId;
                                        A1.BeAnbarId = _BeAnbarId;
                                        A1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        A1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        A1.DateTimeSanad = _DateTimeSanad;
                                        //A1.Seryal = _Seryal;
                                        //A1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        //A1.NoeSanadCode = _NoeSanadCode;
                                        //A1.NoeSanadText = NoeAmaliatTabpageText;
                                        A1.Meghdar = _Meghdar;
                                        A1.Nerkh = _Nerkh;
                                        A1.Mablag = _Mablag;
                                        A1.IsRiali = _Mablag > 0 ? true : false;
                                        A1.Radif = i + 1;
                                        A1.RozaneSanadNumber = 1;
                                        A1.AkKhorojeKala_Riz1 = k1;
                                        A1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                        A1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                        A1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                        A1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;
                                        //db.SaveChanges();

                                        ////////////////////// دستورات ورود کالا ////////////////////
                                        var v1 = v.FirstOrDefault(s => s.Radif == _RadifBefourEdit);
                                        //k[j].SalId = _SalId;
                                        v1.AzAnbarId = _BeAnbarId;
                                        v1.BeAnbarId = _AzAnbarId;
                                        v1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        v1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        //v1.Seryal = _Seryal;
                                        v1.DateTimeSanad = _DateTimeSanad;
                                        v1.DateTimeEdit = _DateTimeEdit;
                                        //v1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        //v1.NoeSanadCode = _NoeSanadCode;
                                        //v1.NoeSanadText = NoeAmaliatTabpageText;
                                        v1.Meghdar = _Meghdar;
                                        v1.Nerkh = _Nerkh;
                                        v1.Mablag = _Mablag;
                                        v1.IsRiali = _Mablag > 0 ? true : false;
                                        v1.Radif = i + 1;
                                        v1.Tozihat = _Tozihat;
                                        v1.SharhSanad = _SharhSanad;
                                        v1.RozaneSanadNumber = 1;
                                        v1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                        v1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                        v1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                        v1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;

                                        var A2 = q1.FirstOrDefault(s => s.Id == v1.Id);
                                        // A.SalId = _SalId;
                                        A2.AzAnbarId = _BeAnbarId;
                                        A2.BeAnbarId = _AzAnbarId;
                                        A2.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        A2.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        A2.DateTimeSanad = _DateTimeSanad;
                                        //A.Seryal = _Seryal;
                                        //A.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        //A.NoeSanadCode = _NoeSanadCode;
                                        //A.NoeSanadText = NoeAmaliatTabpageText;
                                        A2.Meghdar = _Meghdar;
                                        A2.Nerkh = _Nerkh;
                                        A2.Mablag = _Mablag;
                                        A2.IsRiali = _Mablag > 0 ? true : false;
                                        A2.Radif = i + 1;
                                        A2.RozaneSanadNumber = 1;
                                        A2.AkVorodeKala_Riz1 = v1;
                                        A2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                        A2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                        A2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                        A2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;

                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                        decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                        decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                        decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                        string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                        ////////////////////// دستورات خروج کالا ///////////////////
                                        List<AkAllAmaliateRozaneh> List1 = new List<AkAllAmaliateRozaneh>();

                                        AkKhorojeKala_Riz obj1 = new AkKhorojeKala_Riz();
                                        obj1.SalId = _SalId;
                                        obj1.AzAnbarId = _AzAnbarId;
                                        obj1.BeAnbarId = _BeAnbarId;
                                        obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        obj1.Seryal_darSelectNoe = _Seryal;
                                        obj1.DateTimeSanad = _DateTimeSanad;
                                        obj1.DateTimeInsert = _DateTimeInsert;
                                        obj1.NoeAmaliatCode = _NoeAmaliatCodeHavale;
                                        obj1.NoeSanadCode = _NoeSanadCode;
                                        obj1.NoeSanadText = "حواله (جابجایی)";
                                        obj1.Meghdar = _Meghdar;
                                        obj1.Nerkh = _Nerkh;
                                        obj1.Mablag = _Mablag;
                                        obj1.IsRiali = _Mablag > 0 ? true : false;
                                        obj1.Radif = i + 1;
                                        obj1.Tozihat = _Tozihat;
                                        obj1.SharhSanad = _SharhSanad;
                                        obj1.RozaneSanadNumber = 1;
                                        obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                        obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                        obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                        obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;


                                        AkAllAmaliateRozaneh obj01 = new AkAllAmaliateRozaneh();
                                        obj01.SalId = _SalId;
                                        obj01.AzAnbarId = _AzAnbarId;
                                        obj01.BeAnbarId = _BeAnbarId;
                                        obj01.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        obj01.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        obj01.Seryal_darSelectNoe = _Seryal;
                                        obj01.DateTimeSanad = _DateTimeSanad;
                                        obj01.NoeAmaliatCode = _NoeAmaliatCodeHavale;
                                        obj01.NoeSanadCode = _NoeSanadCode;
                                        obj01.NoeSanadText = "حواله (جابجایی)";
                                        obj01.Meghdar = _Meghdar;
                                        obj01.Nerkh = _Nerkh;
                                        obj01.Mablag = _Mablag;
                                        obj01.IsRiali = _Mablag > 0 ? true : false;
                                        obj01.Radif = i + 1;
                                        obj01.RozaneSanadNumber = 1;
                                        obj01.AkKhorojeKala_Riz1 = obj1;
                                        obj01.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                        obj01.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                        obj01.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                        obj01.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                        List1.Add(obj01);

                                        ////////////////////// دستورات ورود کالا ///////////////////
                                        AkVorodeKala_Riz obj2 = new AkVorodeKala_Riz();
                                        obj2.SalId = _SalId;
                                        obj2.AzAnbarId = _BeAnbarId;
                                        obj2.BeAnbarId = _AzAnbarId;
                                        obj2.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        obj2.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        obj2.Seryal_darSelectNoe = _Seryal;
                                        obj2.DateTimeSanad = _DateTimeSanad;
                                        obj2.DateTimeInsert = _DateTimeInsert;
                                        obj2.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        obj2.NoeSanadCode = _NoeSanadCode;
                                        obj2.NoeSanadText = "رسید (جابجایی)";
                                        obj2.Meghdar = _Meghdar;
                                        obj2.Nerkh = _Nerkh;
                                        obj2.Mablag = _Mablag;
                                        obj2.IsRiali = _Mablag > 0 ? true : false;
                                        obj2.Radif = i + 1;
                                        obj2.Tozihat = _Tozihat;
                                        obj2.SharhSanad = _SharhSanad;
                                        obj2.RozaneSanadNumber = 1;
                                        obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                        obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                        obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                        obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;


                                        AkAllAmaliateRozaneh obj02 = new AkAllAmaliateRozaneh();
                                        obj02.SalId = _SalId;
                                        obj02.AzAnbarId = _BeAnbarId;
                                        obj02.BeAnbarId = _AzAnbarId;
                                        obj02.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                        obj02.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                        obj02.Seryal_darSelectNoe = _Seryal;
                                        obj02.DateTimeSanad = _DateTimeSanad;
                                        obj02.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                        obj02.NoeSanadCode = _NoeSanadCode;
                                        obj02.NoeSanadText = "رسید (جابجایی)";
                                        obj02.Meghdar = _Meghdar;
                                        obj02.Nerkh = _Nerkh;
                                        obj02.Mablag = _Mablag;
                                        obj02.IsRiali = _Mablag > 0 ? true : false;
                                        obj02.Radif = i + 1;
                                        obj02.RozaneSanadNumber = 1;
                                        obj02.AkVorodeKala_Riz1 = obj2;
                                        obj02.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                                        obj02.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                                        obj02.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                                        obj02.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;

                                        List1.Add(obj02);

                                        db.AkAllAmaliateRozanehs.AddRange(List1);
                                        db.SaveChanges();

                                    }
                                }
                            }

                            ///////////*******************
                            #region MyRegion1
                            //var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCodeResid && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                            //if (q.Count > 0)
                            //{
                            //    db.AkAllAmaliateRozanehs.RemoveRange(q);

                            //    List<AkAllAmaliateRozaneh> List = new List<AkAllAmaliateRozaneh>();
                            //    for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                            //    {
                            //        long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                            //        decimal _Meghdar = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                            //        decimal _Nerkh = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                            //        decimal _Mablag = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                            //        string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;
                            //        ////////////////////// دستورات خروج کالا ///////////////////
                            //        AkKhorojeKala_Riz obj1 = new AkKhorojeKala_Riz();
                            //        obj1.SalId = _SalId;
                            //        obj1.AzAnbarId = _AzAnbarId;
                            //        obj1.BeAnbarId = _BeAnbarId;
                            //        obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                            //        obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                            //        obj1.Seryal = _Seryal;
                            //        obj1.DateTimeSanad = _DateTimeSanad;
                            //        obj1.DateTimeInsert = _DateTimeInsert;
                            //        obj1.DateTimeEdit = _DateTimeEdit;
                            //        obj1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                            //        obj1.NoeSanadCode = _NoeSanadCode;
                            //        obj1.NoeSanadText = "حواله (جابجایی)";
                            //        obj1.Meghdar = _Meghdar;
                            //        obj1.Nerkh = _Nerkh;
                            //        obj1.Mablag = _Mablag;
                            //        obj1.IsRiali = _Mablag > 0 ? true : false;
                            //        obj1.Radif = i + 1;
                            //        obj1.Tozihat = _Tozihat;
                            //        obj1.SharhSanad = _SharhSanad;
                            //        obj1.SanadNamber = 1;
                            //        obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                            //        obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                            //        obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                            //        obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;


                            //        AkAllAmaliateRozaneh obj01 = new AkAllAmaliateRozaneh();
                            //        obj01.SalId = _SalId;
                            //        obj01.AzAnbarId = _AzAnbarId;
                            //        obj01.BeAnbarId = _BeAnbarId;
                            //        obj01.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                            //        obj01.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                            //        obj01.Seryal = _Seryal;
                            //        obj01.NoeAmaliatCode = _NoeAmaliatCodeResid;
                            //        obj01.NoeSanadCode = _NoeSanadCode;
                            //        obj01.NoeSanadText = "حواله (جابجایی)";
                            //        obj01.Meghdar = _Meghdar;
                            //        obj01.Nerkh = _Nerkh;
                            //        obj01.Mablag = _Mablag;
                            //        obj01.IsRiali = _Mablag > 0 ? true : false;
                            //        obj01.Radif = i + 1;
                            //        obj01.SanadNamber = 1;
                            //        obj01.AkKhorojeKala_Riz1 = obj1;
                            //        obj01.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                            //        obj01.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                            //        obj01.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                            //        obj01.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                            //        List.Add(obj01);

                            //        ////////////////////// دستورات خروج کالا ///////////////////
                            //        AkVorodeKala_Riz obj2 = new AkVorodeKala_Riz();
                            //        obj2.SalId = _SalId;
                            //        obj2.AzAnbarId = _BeAnbarId;
                            //        obj2.BeAnbarId = _AzAnbarId;
                            //        obj2.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                            //        obj2.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                            //        obj2.Seryal = _Seryal;
                            //        obj2.DateTimeSanad = _DateTimeSanad;
                            //        obj2.DateTimeInsert = _DateTimeInsert;
                            //        obj2.DateTimeEdit = _DateTimeEdit;
                            //        obj2.NoeAmaliatCode = _NoeAmaliatCodeResid;
                            //        obj2.NoeSanadCode = _NoeSanadCode;
                            //        obj2.NoeSanadText = "رسید (جابجایی)";
                            //        obj2.Meghdar = _Meghdar;
                            //        obj2.Nerkh = _Nerkh;
                            //        obj2.Mablag = _Mablag;
                            //        obj2.IsRiali = _Mablag > 0 ? true : false;
                            //        obj2.Radif = i + 1;
                            //        obj2.Tozihat = _Tozihat;
                            //        obj2.SharhSanad = _SharhSanad;
                            //        obj2.SanadNamber = 1;
                            //        obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                            //        obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                            //        obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                            //        obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;


                            //        AkAllAmaliateRozaneh obj02 = new AkAllAmaliateRozaneh();
                            //        obj02.SalId = _SalId;
                            //        obj02.AzAnbarId = _BeAnbarId;
                            //        obj02.BeAnbarId = _AzAnbarId;
                            //        obj02.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                            //        obj02.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                            //        obj02.Seryal = _Seryal;
                            //        obj02.NoeAmaliatCode = _NoeAmaliatCodeResid;
                            //        obj02.NoeSanadCode = _NoeSanadCode;
                            //        obj02.NoeSanadText = "رسید (جابجایی)";
                            //        obj02.Meghdar = _Meghdar;
                            //        obj02.Nerkh = _Nerkh;
                            //        obj02.Mablag = _Mablag;
                            //        obj02.IsRiali = _Mablag > 0 ? true : false;
                            //        obj02.Radif = i + 1;
                            //        obj02.SanadNamber = 1;
                            //        obj02.AkVorodeKala_Riz1 = obj2;
                            //        obj02.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).MoinId;
                            //        obj02.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId1;
                            //        obj02.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId2;
                            //        obj02.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _AzAnbarId).TafsiliId3;

                            //        List.Add(obj02);

                            //    }
                            //    db.AkAllAmaliateRozanehs.AddRange(List);
                            //    db.SaveChanges();
                            //}

                            #endregion
                        }

                        En1 = EnumCED.Save;
                        if (IsClosed_AmaliatAddVEit)
                            btnCancel_Click(null, null);

                        if (IsClosed_AmaliatAddVEit == false)
                            ActiveButtons();

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void gridView_AmaliatAddVaEdit_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit.RowCount > 0)
            {
                btnDelete1.Enabled = btnEdit1.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled =
        btnFirst.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = true;
                cmbAzAnbar.ReadOnly = cmbBeAnbar.ReadOnly = true;
            }
            else
            {
                btnDelete1.Enabled = btnEdit1.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled =
        btnFirst.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
                cmbAzAnbar.ReadOnly = cmbBeAnbar.ReadOnly = false;
            }
        }

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (btnSaveAndNext.Enabled)
            {
                IsClosed_AmaliatAddVEit = false;
                btnSaveAndClosed_Click(null, null);

                if (En1 == EnumCED.Save)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (txtNoeAmaliat1.Text == "xtpJabejaeeKala")
                            {
                                var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCodeHavale && s.NoeSanadCode == _NoeSanadCode).ToList();
                                if (q.Count > 0)
                                {
                                    txtSeryal.Text = (q.Max(s => s.Seryal_darSelectNoe) + 1).ToString();
                                }
                                else
                                    txtSeryal.Text = "1";

                                txtTarikh.Text = DateTime.Now.ToString();
                                chkIsSanadHesabdari.Checked = true;
                            }
                            // ActiveButtons();
                            // btnCancel.Enabled = true;
                            txtSharhSanad.Text = string.Empty;
                            akKhorojeKala_RizsBindingSource.Clear();
                            IsClosed_AmaliatAddVEit = true;
                            En1 = EnumCED.Create;
                            XtraMessageBox.Show("اطلاعات جدید ذخیره شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }

        private void btnSaveAndPrintAndClosed_Click_1(object sender, EventArgs e)
        {
            if (btnSaveAndPrintAndClosed.Enabled)
            {
                btnSaveAndClosed_Click(null, null);

            }
        }

        private void FrmJabejaeeKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnSaveAndClosed_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSaveAndNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSaveAndPrintAndClosed_Click_1(sender, null);
            }
            //else if (e.KeyCode == Keys.F7)
            //{
            //    btnCancel_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F8)
            //{
            //    btnDisplyList_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.F10)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillGridControl();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void gridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (xtcAmaliatJabejaee.SelectedTabPageIndex == 1)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = true;
                }
                else
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = true;

            }
            catch (Exception)
            {
            }

        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);
        }

        private void gridView_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);
        }

        private void FrmJabejaeeKala_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext.Dispose();

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (xtcAmaliatJabejaee.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
            {
                HelpClass1.MoveLast(gridView_AmaliatAddVaEdit);
            }
            else
            {
                HelpClass1.MoveLast(gridView);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (xtcAmaliatJabejaee.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
            {
                HelpClass1.MoveNext(gridView_AmaliatAddVaEdit);
            }
            else
            {
                HelpClass1.MoveNext(gridView);
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (xtcAmaliatJabejaee.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
            {
                HelpClass1.MovePrev(gridView_AmaliatAddVaEdit);
            }
            else
            {
                HelpClass1.MovePrev(gridView);
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (xtcAmaliatJabejaee.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
            {
                HelpClass1.MoveFirst(gridView_AmaliatAddVaEdit);
            }
            else
            {
                HelpClass1.MoveFirst(gridView);
            }

        }

        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;

        }

        private void cmbControl_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }
    }
}