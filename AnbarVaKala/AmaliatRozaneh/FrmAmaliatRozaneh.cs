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
using DBHesabdari_PG.Models.AK;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using HelpClassLibrary;
using DBHesabdari_PG;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DevExpress.XtraTab;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmAmaliatRozaneh : DevExpress.XtraEditors.XtraForm
    {
        MyContext dbContext;
        public FrmAmaliatRozaneh()
        {
            InitializeComponent();
            dbContext = new MyContext();
        }

        public EnumCED En1 = EnumCED.Cancel;
        public EnumCED En2;

        XtraTabControl XtraTabControl1_1;
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

        int _HesabMoinId = 0;
        int _HesabTafsiliId = 0;
        public string _KalaCode = string.Empty;
        public string _KalaName = string.Empty;
        public string _VahedeKala = string.Empty;
        public string _Meghdar = string.Empty;
        public string _Nerkh = string.Empty;
        public string _Mablag = string.Empty;
        public string _Tozihat = string.Empty;
        public int _RowHandle = 0;

        string NoeAmaliatTabpageName = string.Empty;
        string NoeSanadTabpageName = string.Empty;
        string NoeSanadText = string.Empty;
        int _IndexTabPage = 0;
        int _NoeAmaliatCode = 0;
        int _NoeSanadCode = 0;

        int _SalId = 0;
        int _AnbarId = 0;
        int _TabPageCount = 0;
        int EditRowIndex = 0;
        bool IsClosed_AmaliatAddVEit = true;

        public void FillGridControl()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    var q1 = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId).ToList();
                    var q2 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    var q3 = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();

                    switch (NoeAmaliatTabpageName)
                    {
                        case "xtpVrodeKala":
                            {
                                switch (NoeSanadTabpageName)
                                {
                                    case "xtp_ResidKharid":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsiliId).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsiliId).Name;
                                                    item.KalaCode = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                                    item.KalaName = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                                    item.VahedeKala = q2.FirstOrDefault(s => s.Id == item.KalaId).VahedAsliName;
                                                }

                                                //dbContext.AkVorodeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                                //{
                                                //    // Bind data to control when loading complete
                                                //    gridControl.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                                //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                                gridControl.DataSource = q.OrderBy(s => s.Seryal);
                                            }
                                            else
                                                gridControl.DataSource = null;
                                            break;
                                        }
                                    case "xtp_BargashtAzFroosh":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidKalaAmani":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_BargashtAzHavaleTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidSayer":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_EzafateAnbar":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_AllVorode":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsiliId).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsiliId).Name;
                                                    item.KalaCode = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                                    item.KalaName = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                                    item.VahedeKala = q2.FirstOrDefault(s => s.Id == item.KalaId).VahedAsliName;
                                                }

                                                //dbContext.AkVorodeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                                //{
                                                //    // Bind data to control when loading complete
                                                //    gridControl.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                                //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                                gridControl.DataSource = q.OrderBy(s => s.Seryal);
                                            }
                                            else
                                                gridControl.DataSource = null;
                                            break;
                                        }
                                    default:
                                        break;
                                }

                                break;
                            }
                        default:
                            break;
                    }

                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillCmbNameAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.IsActive == true).OrderBy(s => s.Code).ToList();
                    cmbNameAnbar.Properties.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillCmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {

                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabMoin1s.Where(s => s.SalId == _SalId && s.IsActive == true).OrderBy(s => s.Code).ToList();
                    cmbHesabMoin.Properties.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillCmbHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);

                    List<EpAllHesabTafsili> list = new List<EpAllHesabTafsili>();

                    var q1 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == _HesabMoinId && s.SalId == _SalId).Select(s => s.AllGroupTafsiliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.IsActive == true && s.GroupTafsiliId == item).OrderBy(s => s.Code).ToList();
                            list.AddRange(q);
                        }
                        //db.EpAllHesabTafsilis.AddRange(list);
                        List<EpAllHesabTafsili_HesabMovaghat> list1 = new List<EpAllHesabTafsili_HesabMovaghat>();
                        foreach (var item in list)
                        {
                            EpAllHesabTafsili_HesabMovaghat obj = new EpAllHesabTafsili_HesabMovaghat();
                            obj.Id = item.Id;
                            obj.SalId = item.SalId;
                            obj.LevelNamber = item.LevelNamber;
                            obj.Code = item.Code;
                            obj.Name = item.Name;
                            obj.GroupTafsiliId = item.GroupTafsiliId;
                            obj.MoinId = _HesabMoinId;
                            obj.IsActive = item.IsActive;
                            obj.IsDefault = item.IsDefault;
                            obj.SharhHesab = item.SharhHesab;
                            list1.Add(obj);
                        }
                        db.EpAllHesabTafsili_HesabMovaghats.AddRange(list1);

                        //BindingSource bs = new BindingSource();
                        //bs.DataSource = list;
                        //BindingList<EpAllHesabTafsili> ok = new BindingList<EpAllHesabTafsili>(list);
                        db.EpAllHesabTafsili_HesabMovaghats.Load();
                        cmbHesabTafsili.Properties.DataSource = db.EpAllHesabTafsili_HesabMovaghats.Local.ToBindingList();
                    }
                    else
                        cmbHesabTafsili.Properties.DataSource = null;

                    //if (_HesabMoinId == 14)
                    //{
                    //    cmbHesabTafsili.Properties.DataSource = db.EpAllHesabTafsilis.Where(s => s.GroupTafsiliId == 1 || s.GroupTafsiliId == 2).ToList();
                    //}
                    //else if (_HesabMoinId == 15)
                    //{
                    //    cmbHesabTafsili.Properties.DataSource = db.EpAllHesabTafsilis.Where(s => s.GroupTafsiliId == 3 || s.GroupTafsiliId == 4).ToList();
                    //}

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
            if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً حساب معین را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbHesabTafsili.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً حساب تفضیل را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili.Focus();
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
            FrmAmaliatVorodeKala fm = new FrmAmaliatVorodeKala(this);
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
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


            //BindingList<AkVorodeKala_Riz> List1 = new BindingList<AkVorodeKala_Riz>();
            //List1[0].Mablag = 11;
            //(gridControl_AmaliatAddVaEdit.DataSource as BindingList<List1>).AddNew();


            //List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>()
            //          {
            //              new AkVorodeKala_Riz { Meghdar = 11, },
            //              new AkVorodeKala_Riz { Meghdar = 12, },
            //          };
            //BindingList<AkVorodeKala_Riz> bindingList = new BindingList<AkVorodeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

            //List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>()
            //{
            //    new AkVorodeKala_Riz(){Meghdar = 13,Nerkh = 14,Mablag = 15,}
            //};
            //BindingList<AkVorodeKala_Riz> bindingList = new BindingList<AkVorodeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

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
            using (var db = new MyContext())
            {
                try
                {
                    _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    //if (_AnbarId == 0)
                    //{
                    //    XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    cmbNameAnbar.Focus();
                    //    return;
                    //}

                    En1 = EnumCED.Create;
                    ActiveButtons();
                    panelControl_NameAnbar.Enabled = false;
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    switch (NoeAmaliatTabpageName)
                    {
                        case "xtpVrodeKala":
                            {
                                XtraTabControl1_1 = xtc_VorodeKala;
                                //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                                txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                //txtNoeSanad.BackColor = Color.LightGreen;
                                //lblSanadNamber.BackColor = Color.LightGreen;
                                xtpAmaliatAddVEdit.PageVisible = true;
                                xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                                xtpAmaliatAddVEdit.Text = "عملیات ایجاد";
                                HelpClass1.DateTimeMask(txtTarikh);
                                txtTarikh.Text = DateTime.Now.ToString();
                                chkIsSanadHesabdari.Checked = true;
                                switch (NoeSanadTabpageName)
                                {
                                    case "xtp_ResidKharid":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                            if (q.Count > 0)
                                            {
                                                txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                                            }
                                            else
                                                txtSeryal.Text = "1";
                                            break;
                                        }
                                    case "xtp_BargashtAzFroosh":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidKalaAmani":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_BargashtAzHavaleTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidSayer":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_EzafateAnbar":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }

                                    default:
                                        break;
                                }
                                // _TabPageCount = xtcAmaliatRozaneh.TabPages.Count;
                                xtcAmaliatRozaneh.SelectedTabPageIndex = 4;

                                break;
                            }
                        case "xtpKhrojeKala":
                            {
                                break;
                            }
                        case "xtpJabejaeeKala":
                            {
                                break;
                            }
                        case "xtpMojodiAvalDore":
                            {
                                break;
                            }
                        default:
                            break;
                    }

                    for (int i = 0; i < xtcAmaliatRozaneh.TabPages.Count; i++)
                    {
                        if (xtcAmaliatRozaneh.TabPages[i].Name != "xtpAmaliatAddVEdit")
                        {
                            xtcAmaliatRozaneh.TabPages[i].PageEnabled = false;
                        }
                    }
                    //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                    //{
                    //    if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
                    //    {
                    //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                    //    }
                    //}
                    xtpAmaliatAddVEdit.PageEnabled = true;
                    FillCmbHesabMoin();
                    cmbHesabMoin.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dbContext = new MyContext();

            //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
            //{
            //    // Bind data to control when loading complete
            //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).Load();
            // Bind data to control when loading complete
            akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();


        }

        private void FrmAmaliatRozaneh_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            //En1 = EnumCED.None;
            //ActiveButtons();
            NoeAmaliatTabpageIndex = 0;
            NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
            _NoeAmaliatCode = 2;
            _NoeSanadCode = 201;
            // xtcAmaliatRozaneh.SelectedTabPageIndex = 0;
            NoeSanadTabpageIndex = 0;
            XtraTabControl1_1 = xtc_VorodeKala;
            NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
            NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
            gridControl = gridControl_ResidKharid_Riz;
            gridView = gridView_ResidKharid_Riz;
            // XtraTabControl1_1.SelectedTabPageIndex = 0;
            FillCmbNameAnbar();
            cmbNameAnbar.Focus();
        }

        int NoeAmaliatTabpageIndex = 0;
        private void xtcAmaliatRozaneh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                {
                    NoeAmaliatTabpageIndex = 0;
                    NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    XtraTabControl1_1 = xtc_VorodeKala;
                    NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCode = 2;

                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpKhrojeKala")
                {
                    NoeAmaliatTabpageIndex = 1;
                    NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    XtraTabControl1_1 = xtc_KhorojeKala;
                    NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCode = 3;
                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpJabejaeeKala")
                {
                    NoeAmaliatTabpageIndex = 2;
                    NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    //NoeSanadName = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCode = 4;
                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpMojodiAvalDore")
                {
                    NoeAmaliatTabpageIndex = 3;
                    NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    //NoeSanadName = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCode = 1;
                }

            }
        }

        int NoeSanadTabpageIndex = 0;
        private void xtc_VorodeKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                btnCreate.Enabled = true;
                if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKharid")
                {
                    NoeSanadTabpageIndex = 0;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_ResidKharid_Riz;
                    gridView = gridView_ResidKharid_Riz;
                    _NoeSanadCode = 200;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzFroosh")
                {
                    NoeSanadTabpageIndex = 1;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_BargashtAzFroosh;
                    gridView = gridView_BargashtAzFroosh;
                    _NoeSanadCode = 201;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKalaAmani")
                {
                    NoeSanadTabpageIndex = 2;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_ResidKalaAmani;
                    gridView = gridView_ResidKalaAmani;
                    _NoeSanadCode = 202;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidTolid")
                {
                    NoeSanadTabpageIndex = 3;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_ResidTolid;
                    gridView = gridView_ResidTolid;
                    _NoeSanadCode = 203;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleTolid")
                {
                    NoeSanadTabpageIndex = 4;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_BargashtAzHavaleTolid;
                    gridView = gridView_BargashtAzHavaleTolid;
                    _NoeSanadCode = 204;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidSayer")
                {
                    NoeSanadTabpageIndex = 5;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_ResidSayer;
                    gridView = gridView_ResidSayer;
                    _NoeSanadCode = 205;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_EzafateAnbar")
                {
                    NoeSanadTabpageIndex = 6;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_EzafateAnbar;
                    gridView = gridView_EzafateAnbar;
                    _NoeSanadCode = 206;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_AllVorode")
                {
                    NoeSanadTabpageIndex = 7;
                    NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                    NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    gridControl = gridControl_AllVorode;
                    gridView = gridView_AllVorode;
                    //_NoeSanadCode = 207;
                    btnCreate.Enabled = false;
                }

                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;
                btnDisplyList_Click(null, null);

            }
        }

        private void xtc_KhorojeKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl1_1 = xtc_KhorojeKala;
            NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;

        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillCmbNameAnbar();
        }

        private void btnReloadHesabMoin_Click(object sender, EventArgs e)
        {
            FillCmbHesabMoin();
        }

        private void btnReloadHesabTafsili_Click(object sender, EventArgs e)
        {
            FillCmbHesabTafsili();
        }

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabMoin.EditValue) > 0)
                FillCmbHesabTafsili();
            //cmbHesabTafsili.EditValue = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < xtcAmaliatRozaneh.TabPages.Count; i++)
            {
                if (xtcAmaliatRozaneh.TabPages[i].Name != "xtpAmaliatAddVEdit")
                {
                    xtcAmaliatRozaneh.TabPages[i].PageEnabled = true;
                }
            }

            //NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
            //switch (NoeAmaliatTabpageName)
            //{
            //    case "xtpVrodeKala":
            //        {
            //            for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
            //            {
            //                if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
            //                {
            //                    XtraTabControl1_1.TabPages[i].PageEnabled = true;
            //                }
            //            }
            //            XtraTabControl1_1.SelectedTabPageIndex = _IndexTabPage;
            //            break;
            //        }
            //    case "xtpKhrojeKala":
            //        {
            //            for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
            //            {
            //                if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
            //                {
            //                    XtraTabControl1_1.TabPages[i].PageEnabled = true;
            //                }
            //            }
            //            XtraTabControl1_1.SelectedTabPageIndex = _IndexTabPage;
            //            break;
            //        }
            //    case "xtpJabejaeeKala":
            //        {
            //            break;
            //        }
            //    case "xtpMojodiAvalDore":
            //        {
            //            break;
            //        }
            //    default:
            //        break;
            //}

            HelpClass1.ClearControls(panelControl_AddVaEdit);
            cmbHesabTafsili.EditValue = cmbHesabTafsili.EditValue = null;
            cmbHesabMoin.Properties.DataSource = cmbHesabTafsili.Properties.DataSource = null;
            btnDelete1.Enabled = btnEdit1.Enabled = false;

            En1 = EnumCED.Cancel;
            xtcAmaliatRozaneh.SelectedTabPageIndex = NoeAmaliatTabpageIndex;
            XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex;
            // if (NoeAmaliatTabpageIndex == 0 && NoeSanadTabpageIndex == 0)
            xtc_VorodeKala_SelectedPageChanged(null, null);

            xtpAmaliatAddVEdit.PageVisible = false;
            panelControl_NameAnbar.Enabled = true;

            akVorodeKala_RizsBindingSource.Clear();
            //akVorodeKala_RizsBindingSource.DataSource = null;

            ActiveButtons();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //dbContext.Dispose();
            panelControl_NameAnbar.Enabled = true;
            this.Close();
        }

        private void cmbControl_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit.RowCount > 0)
            {
                En2 = EnumCED.Edit;
                _KalaCode = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaCode");
                _KalaName = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaName");
                _VahedeKala = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("VahedeKala");
                _Meghdar = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Meghdar");
                _Nerkh = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Nerkh");
                _Mablag = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Mablag");
                _Tozihat = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("Tozihat");
                _RowHandle = gridView_AmaliatAddVaEdit.FocusedRowHandle;

                FrmAmaliatVorodeKala fm = new FrmAmaliatVorodeKala(this);
                //fm.MdiParent = this;
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                fm.ShowDialog();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView.RowCount > 0)
                {
                    string NoeSanad = XtraTabControl1_1.SelectedTabPage.Text;
                    if (XtraMessageBox.Show("آیا " + NoeSanad + " مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                                var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.Seryal == _Seryal);
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
            if (btnEdit.Visible)
            {
                if (gridView.RowCount > 0)
                {
                    try
                    {
                        dbContext = new MyContext();
                        En1 = EnumCED.Edit;
                        int _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                        // btnSaveAndNext.Enabled = false;
                        panelControl_NameAnbar.Enabled = false;
                        int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                        string _DateTimeSanad = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimeSanad")).ToString();
                        bool _IsRiali = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRiali"));
                        string _lblSanadNamber = gridView.GetFocusedRowCellValue("SanadNamber").ToString();
                        int _MoinId = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabMoinId"));
                        string _TafsiliId = gridView.GetFocusedRowCellValue("TafsiliName").ToString();
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

                        switch (NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    var q = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                    if (q.Count > 0)
                                    {
                                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                        txtSeryal.Text = _Seryal.ToString();
                                        txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                        txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                        txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                        //txtNoeSanad.BackColor = Color.Yellow;
                                        HelpClass1.DateTimeMask(txtTarikh);
                                        txtTarikh.Text = _DateTimeSanad;
                                        chkIsSanadHesabdari.Checked = _IsRiali;
                                        lblSanadNamber.Text = _lblSanadNamber;
                                        //lblSanadNamber.BackColor = Color.Yellow;
                                        // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                        xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = xtpJabejaeeKala.PageEnabled = xtpMojodiAvalDore.PageEnabled = false;
                                        xtcAmaliatRozaneh.SelectedTabPageIndex = 4;
                                        xtpAmaliatAddVEdit.PageVisible = true;
                                        xtpAmaliatAddVEdit.Text = "عملیات ویرایش";
                                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                                        FillCmbHesabMoin();
                                        cmbHesabMoin.EditValue = _MoinId;
                                        cmbHesabTafsili.Text = _TafsiliId;
                                        cmbHesabTafsili.ShowPopup();
                                        cmbHesabTafsili.ClosePopup();

                                        //List<AkVorodeKala_Riz> DBGridControl = (List<AkVorodeKala_Riz>)gridControl.DataSource;
                                        //BindingList<AkVorodeKala_Riz> bl = new BindingList<AkVorodeKala_Riz>(DBGridControl);
                                        //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                                        foreach (var item in q)
                                        {
                                            item.KalaCode = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                            item.KalaName = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                            item.VahedeKala = q2.FirstOrDefault(s => s.Id == item.KalaId).VahedAsliName;
                                        }

                                        //dbContext.AkVorodeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                        //{
                                        //    // Bind data to control when loading complete
                                        //    gridControl.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                        //xtp_AddVaEdit.PageVisible = true;

                                        //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).Load();
                                        // Bind data to control when loading complete
                                        akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                    }


                                    //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                                    //{
                                    //    if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
                                    //    {
                                    //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                                    //    }
                                    //}
                                    btnCreate.Focus();

                                    break;
                                }
                            default:
                                break;
                        }


                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }

        private void cmbNameAnbar_Enter(object sender, EventArgs e)
        {
            cmbNameAnbar.ShowPopup();
        }

        private void cmbHesabMoin_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create || En1 == EnumCED.Save)
            {
                cmbHesabMoin.ShowPopup();
            }

        }

        private void cmbHesabTafsili_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create)
            {
                cmbHesabTafsili.ShowPopup();
            }

        }

        private void btnSaveAndClosed_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                    switch (txtNoeAmaliat1.Text)
                    {
                        case "xtpVrodeKala":
                            {
                                int _Seryal = Convert.ToInt32(txtSeryal.Text);
                                DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                DateTime _DateTimeInsert = DateTime.Now;
                                _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                _HesabTafsiliId = Convert.ToInt32(cmbHesabTafsili.EditValue);
                                switch (txtNoeSanad1.Text)
                                {
                                    case "xtp_ResidKharid":
                                        {
                                            if (IsValidation())
                                            {
                                                var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                if (En1 == EnumCED.Create)
                                                {
                                                    List<AkAllAmaliateRozaneh> List = new List<AkAllAmaliateRozaneh>();
                                                    for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                                                    {
                                                        int _Code = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                        decimal _Meghdar = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                        decimal _Nerkh = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                        decimal _Mablag = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                        string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                        AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                        obj1.SalId = _SalId;
                                                        obj1.AnbarId = _AnbarId;
                                                        obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                        obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                        obj1.Seryal = _Seryal;
                                                        obj1.DateTimeSanad = _DateTimeSanad;
                                                        obj1.DateTimeInsert = _DateTimeInsert;
                                                        obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                        obj1.NoeSanadCode = _NoeSanadCode;
                                                        obj1.NoeSanadText = NoeSanadText;
                                                        obj1.Meghdar = _Meghdar;
                                                        obj1.Nerkh = _Nerkh;
                                                        obj1.Mablag = _Mablag;
                                                        obj1.IsRiali = _Mablag > 0 ? true : false;
                                                        obj1.Radif = i + 1;
                                                        obj1.Tozihat = _Tozihat;
                                                        obj1.SanadNamber = 1;
                                                        obj1.HesabMoinId = _HesabMoinId;
                                                        obj1.HesabTafsiliId = _HesabTafsiliId;


                                                        AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                        obj.SalId = _SalId;
                                                        obj.AnbarId = _AnbarId;
                                                        obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                        obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                        obj.Seryal = _Seryal;
                                                        obj.NoeAmaliatCode = _NoeAmaliatCode;
                                                        obj.NoeSanadCode = _NoeSanadCode;
                                                        obj.NoeSanadText = NoeSanadText;
                                                        obj.Meghdar = _Meghdar;
                                                        obj.Nerkh = _Nerkh;
                                                        obj.Mablag = _Mablag;
                                                        obj.IsRiali = _Mablag > 0 ? true : false;
                                                        obj.Radif = i + 1;
                                                        obj.SanadNamber = 1;
                                                        obj.AkVorodeKala_Riz1 = obj1;
                                                        obj.HesabMoinId = _HesabMoinId;
                                                        obj.HesabTafsiliId = _HesabTafsiliId;

                                                        List.Add(obj);
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
                                                    BindingList<AkVorodeKala_Riz> list = (BindingList<AkVorodeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                    var q2 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                    foreach (var item in q2)
                                                    {
                                                        if (!list.Any(s => s.Id == item.Id))
                                                        {
                                                            db.AkAllAmaliateRozanehs.Remove(q2.FirstOrDefault(s => s.Id == item.Id));
                                                            db.SaveChanges();
                                                        }
                                                    }

                                                    var q1 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                    var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                    for (int i = 0; i < list.Count; i++)
                                                    {
                                                        if (list[i].Id > 0)
                                                        {
                                                            for (int j = 0; j < q.Count; j++)
                                                            {
                                                                if (list[i].Id == q[j].Id)
                                                                {
                                                                    int _Code = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                    decimal _Meghdar = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                    decimal _Nerkh = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                    decimal _Mablag = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                    string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                    q[j].SalId = _SalId;
                                                                    q[j].AnbarId = _AnbarId;
                                                                    q[j].KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                    q[j].VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                    q[j].Seryal = _Seryal;
                                                                    q[j].DateTimeSanad = _DateTimeSanad;
                                                                    q[j].DateTimeEdit = _DateTimeEdit;
                                                                    q[j].NoeAmaliatCode = _NoeAmaliatCode;
                                                                    q[j].NoeSanadCode = _NoeSanadCode;
                                                                    q[j].NoeSanadText = NoeSanadText;
                                                                    q[j].Meghdar = _Meghdar;
                                                                    q[j].Nerkh = _Nerkh;
                                                                    q[j].Mablag = _Mablag;
                                                                    q[j].IsRiali = _Mablag > 0 ? true : false;
                                                                    q[j].Radif = i + 1;
                                                                    q[j].Tozihat = _Tozihat;
                                                                    q[j].SanadNamber = 1;
                                                                    q[j].HesabMoinId = _HesabMoinId;
                                                                    q[j].HesabTafsiliId = _HesabTafsiliId;

                                                                    q1[j].SalId = _SalId;
                                                                    q1[j].AnbarId = _AnbarId;
                                                                    q1[j].KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                    q1[j].VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                    q1[j].Seryal = _Seryal;
                                                                    q1[j].NoeAmaliatCode = _NoeAmaliatCode;
                                                                    q1[j].NoeSanadCode = _NoeSanadCode;
                                                                    q1[j].NoeSanadText = NoeSanadText;
                                                                    q1[j].Meghdar = _Meghdar;
                                                                    q1[j].Nerkh = _Nerkh;
                                                                    q1[j].Mablag = _Mablag;
                                                                    q1[j].IsRiali = _Mablag > 0 ? true : false;
                                                                    q1[j].Radif = i + 1;
                                                                    q1[j].SanadNamber = 1;
                                                                    q1[j].AkVorodeKala_Riz1 = q[j];
                                                                    q1[j].HesabMoinId = _HesabMoinId;
                                                                    q1[j].HesabTafsiliId = _HesabTafsiliId;

                                                                    db.SaveChanges();
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            int _Code = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                            decimal _Meghdar = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AnbarId = _AnbarId;
                                                            obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj1.Seryal = _Seryal;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                            obj1.NoeSanadCode = _NoeSanadCode;
                                                            obj1.NoeSanadText = NoeSanadText;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SanadNamber = 1;
                                                            obj1.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                            obj1.HesabTafsiliId = Convert.ToInt32(cmbHesabTafsili.EditValue);


                                                            AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                            obj.SalId = _SalId;
                                                            obj.AnbarId = _AnbarId;
                                                            obj.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj.Seryal = _Seryal;
                                                            obj.NoeAmaliatCode = _NoeAmaliatCode;
                                                            obj.NoeSanadCode = _NoeSanadCode;
                                                            obj.NoeSanadText = NoeSanadText;
                                                            obj.Meghdar = _Meghdar;
                                                            obj.Nerkh = _Nerkh;
                                                            obj.Mablag = _Mablag;
                                                            obj.IsRiali = _Mablag > 0 ? true : false;
                                                            obj.Radif = i + 1;
                                                            obj.SanadNamber = 1;
                                                            obj.AkVorodeKala_Riz1 = obj1;
                                                            obj.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                            obj.HesabTafsiliId = Convert.ToInt32(cmbHesabTafsili.EditValue);

                                                            db.AkAllAmaliateRozanehs.Add(obj);
                                                            db.SaveChanges();
                                                        }
                                                    }
                                                }

                                                En1 = EnumCED.Save;
                                                if (IsClosed_AmaliatAddVEit)
                                                    btnCancel_Click(null, null);

                                                if (IsClosed_AmaliatAddVEit == false)
                                                    ActiveButtons();

                                                ///////////*******************
                                                //var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatIndex == 2 && s.AmaliatIndex == 201 && s.Seryal == _Seryal).ToList();
                                                //if (q.Count > 0)
                                                //{
                                                //    db.AkAllAmaliateRozanehs.RemoveRange(q);

                                                //    List<AkAllAmaliateRozaneh> List = new List<AkAllAmaliateRozaneh>();
                                                //    DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                                //    DateTime _DateTimeInsert = DateTime.Now;
                                                //    for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                                                //    {
                                                //        int _Code = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                //        decimal _Meghdar = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                //        decimal _Nerkh = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                //        decimal _Mablag = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                //        string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                //        AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                //        obj1.SalId = _SalId;
                                                //        obj1.AnbarId = _AnbarId;
                                                //        obj1.KalaId = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _Code).Id;
                                                //        obj1.VahedeKalaId = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _Code).VahedAsliId;
                                                //        obj1.Seryal = _Seryal;
                                                //        obj1.DateTimeSanad = _DateTimeSanad;
                                                //        obj1.DateTimeInsert = _DateTimeInsert;
                                                //        obj1.NoeAmaliatIndex = 2;
                                                //        obj1.AmaliatIndex = 201;
                                                //        obj1.Meghdar = _Meghdar;
                                                //        obj1.Nerkh = _Nerkh;
                                                //        obj1.Mablag = _Mablag;
                                                //        obj1.IsRiali = _Mablag > 0 ? true : false;
                                                //        obj1.Radif = i + 1;
                                                //        obj1.Tozihat = _Tozihat;
                                                //        obj1.SanadNamber = 1;
                                                //        obj1.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                //        obj1.HesabTafsiliId = Convert.ToInt32(cmbHesabTafsili.EditValue);


                                                //        AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                //        obj.SalId = _SalId;
                                                //        obj.AnbarId = _AnbarId;
                                                //        obj.KalaId = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _Code).Id;
                                                //        obj.VahedeKalaId = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _Code).VahedAsliId;
                                                //        obj.Seryal = _Seryal;
                                                //        obj.NoeAmaliatIndex = 2;
                                                //        obj.AmaliatIndex = 201;
                                                //        obj.Meghdar = _Meghdar;
                                                //        obj.Nerkh = _Nerkh;
                                                //        obj.Mablag = _Mablag;
                                                //        obj.IsRiali = _Mablag > 0 ? true : false;
                                                //        obj.Radif = i + 1;
                                                //        obj.SanadNamber = 1;
                                                //        obj.AkVorodeKala_Riz1 = obj1;
                                                //        obj.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                //        obj.HesabTafsiliId = Convert.ToInt32(cmbHesabTafsili.EditValue);

                                                //        List.Add(obj);
                                                //    }
                                                //    db.AkAllAmaliateRozanehs.AddRange(List);
                                                //    db.SaveChanges();
                                                //    En1 = EnumCED.Save;
                                                //    if (IsClosed_AmaliatAddVEit)
                                                //        btnCancel_Click(null, null);
                                                //}
                                            }
                                            break;
                                        }
                                    case "xtp_BargashtAzFroosh":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidKalaAmani":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_BargashtAzHavaleTolid":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidSayer":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_EzafateAnbar":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    default:
                                        break;
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridView_AmaliatAddVaEdit_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit.RowCount > 0)
            {
                btnDelete1.Enabled = btnEdit1.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled =
        btnFirst.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = true;
            }
            else
            {
                btnDelete1.Enabled = btnEdit1.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled =
        btnFirst.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
            }
        }

        private void cmbNameAnbar_EditValueChanged(object sender, EventArgs e)
        {
            if (xtcAmaliatRozaneh.Enabled == false)
            {
                xtcAmaliatRozaneh.Enabled = true;
                xtc_VorodeKala_SelectedPageChanged(null, null);
            }
            else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                xtc_VorodeKala_SelectedPageChanged(null, null);

        }

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            IsClosed_AmaliatAddVEit = false;
            btnSaveAndClosed_Click(null, null);

            if (En1 == EnumCED.Save)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (txtNoeAmaliat1.Text == "xtpVrodeKala")
                        {
                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                            if (q.Count > 0)
                            {
                                txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                            }
                            else
                                txtSeryal.Text = "1";

                            txtTarikh.Text = DateTime.Now.ToString();
                            chkIsSanadHesabdari.Checked = true;
                        }
                        // ActiveButtons();
                        // btnCancel.Enabled = true;
                        akVorodeKala_RizsBindingSource.Clear();
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

        private void btnSaveAndPrintAndClosed_Click_1(object sender, EventArgs e)
        {
            btnSaveAndClosed_Click(null, null);
        }

        private void FrmAmaliatRozaneh_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F7)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyList_Click(sender, null);
            }
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
                if (xtcAmaliatRozaneh.SelectedTabPageIndex == 4)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = true;
                }
                else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_AllVorode")
                    btnDelete.Enabled = btnEdit.Enabled = btnCreate.Enabled = false;
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

        private void FrmAmaliatRozaneh_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext.Dispose();

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
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
            if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
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
            if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
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
            if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpAmaliatAddVEdit")
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
    }
}
