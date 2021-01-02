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
        int _HesabTafsili1Id = 0;
        int _HesabTafsili2Id = 0;
        int _HesabTafsili3Id = 0;
        string _SharhSanad = string.Empty;

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
        int _AzAnbarId = 0;
        int _TabPageCount = 0;
        int EditRowIndex = 0;
        bool IsClosed_AmaliatAddVEit = true;

        public void FillGridControl()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    var q1 = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
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
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name;
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
                                    case "xtp_BargashtAzHavaleHazine":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_BargashtAzHavaleAmval":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_EzafateAnbar":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_AllVorode":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name;
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
                                }
                                break;
                            }
                        case "xtpKhrojeKala":
                            {
                                switch (NoeSanadTabpageName)
                                {
                                    case "xtp_BargashtAzKharid":
                                        {
                                            var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name;
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
                                    case "xtp_HavaleFroosh":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleKalaAmani":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_BargashtAzResidTolid":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleTolid":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleHazine":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleAmval":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_KosoratAnbar":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_AllKhoroji":
                                        {
                                            var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).OrderBy(s => s.Seryal).ToList();
                                            if (q.Count() > 0)
                                            {
                                                foreach (var item in q.ToList())
                                                {
                                                    item.MoinCode = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Code.ToString();
                                                    item.MoinName = q3.FirstOrDefault(s => s.Id == item.HesabMoinId).Name;
                                                    item.TafsiliCode = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Code.ToString();
                                                    item.TafsiliName = q1.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name;
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
                    //var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();

                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.IsActive == true).OrderBy(s => s.Code).ToList();

                    foreach (var item in q1)
                    {
                        IList<int> List1 = new List<int>();
                        string _Id1 = String.Empty;
                        if (item.TabagheKalaId != null)
                        {
                            char[] item1 = item.TabagheKalaId.ToArray();
                            for (int i = 0; i < item1.Count(); i++)
                            {
                                if (i == 0)
                                {
                                    _Id1 = _Id1 + item1[i].ToString();
                                }
                                else
                                {
                                    if (item1[i] == ',')
                                    {
                                        int _Id2 = Convert.ToInt32(_Id1);
                                        List1.Add(_Id2);
                                        _Id1 = String.Empty;
                                    }
                                    else
                                    {
                                        _Id1 = _Id1 + item1[i].ToString();
                                    }

                                }
                            }

                            string _KalaId = String.Empty;
                            foreach (var item2 in List1)
                            {
                                _KalaId += db.EpTabaghehKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == item2).Name + ",";
                            }
                            item.TabagheKalaIdName_NM = _KalaId;
                        }

                    }
                    if (q1.Count > 0)
                        epListAnbarhasBindingSource.DataSource = q1;
                    else
                        epListAnbarhasBindingSource.Clear();


                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    //var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.IsActive == true).OrderBy(s => s.Code).ToList();
                    //cmbNameAnbar.Properties.DataSource = q.Count > 0 ? q : null;
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
                    var q = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
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
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.GroupTafsiliId == item).OrderBy(s => s.Code).ToList();
                            list.AddRange(q);
                        }
                        #region MyRegion
                        ////db.EpAllHesabTafsilis.AddRange(list);
                        //List<EpAllHesabTafsili_HesabMovaghat> list1 = new List<EpAllHesabTafsili_HesabMovaghat>();
                        //foreach (var item in list)
                        //{
                        //    EpAllHesabTafsili_HesabMovaghat obj = new EpAllHesabTafsili_HesabMovaghat();
                        //    obj.Id = item.Id;
                        //    obj.SalId = item.SalId;
                        //    obj.LevelNamber = item.LevelNamber;
                        //    obj.Code = item.Code;
                        //    obj.Name = item.Name;
                        //    obj.GroupTafsiliId = item.GroupTafsiliId;
                        //    obj.MoinId = _HesabMoinId;
                        //    obj.IsActive = item.IsActive;
                        //    obj.IsDefault = item.IsDefault;
                        //    obj.SharhHesab = item.SharhHesab;
                        //    list1.Add(obj);
                        //}
                        //db.EpAllHesabTafsili_HesabMovaghats.AddRange(list1);

                        ////BindingSource bs = new BindingSource();
                        ////bs.DataSource = list;
                        ////BindingList<EpAllHesabTafsili> ok = new BindingList<EpAllHesabTafsili>(list);
                        //db.EpAllHesabTafsili_HesabMovaghats.Load(); 
                        #endregion
                        cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.LevelNamber == 1).OrderBy(s => s.Code);
                        cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.LevelNamber == 2).OrderBy(s => s.Code);
                        cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.LevelNamber == 3).OrderBy(s => s.Code);
                    }
                    else
                    {
                        cmbHesabTafsili1.Properties.DataSource = null;
                        cmbHesabTafsili2.Properties.DataSource = null;
                        cmbHesabTafsili3.Properties.DataSource = null;

                    }

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
                XtraMessageBox.Show("لطفاً " + lblHesabMoin.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili1.Focus();
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
            if (btnCreate.Enabled)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        if (_AzAnbarId == 0)
                        {
                            XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbNameAnbar.ShowPopup();
                            return;
                        }

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
                                                var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
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
                                        case "xtp_BargashtAzHavaleHazine":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_BargashtAzHavaleAmval":
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
                                    xtcAmaliatRozaneh.SelectedTabPageIndex = 2;

                                    dbContext = new MyContext();
                                    //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                                    //{
                                    //    // Bind data to control when loading complete
                                    //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                    //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                                    dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).Load();
                                    // Bind data to control when loading complete
                                    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();


                                    break;
                                }
                            case "xtpKhrojeKala":
                                {
                                    XtraTabControl1_1 = xtc_KhorojeKala;
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
                                        case "xtp_BargashtAzKharid":
                                            {
                                                var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                                if (q.Count > 0)
                                                {
                                                    txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                                                }
                                                else
                                                    txtSeryal.Text = "1";
                                                break;
                                            }
                                        case "xtp_HavaleFroosh":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleKalaAmani":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_BargashtAzResidTolid":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleTolid":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleHazine":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleAmval":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_KosoratAnbar":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }

                                        default:
                                            break;
                                    }
                                    // _TabPageCount = xtcAmaliatRozaneh.TabPages.Count;
                                    xtcAmaliatRozaneh.SelectedTabPageIndex = 2;

                                    dbContext = new MyContext();
                                    //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                                    //{
                                    //    // Bind data to control when loading complete
                                    //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                    //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                                    dbContext.AkKhorojeKala_Rizs.Where(s => s.Id == 0).Load();
                                    // Bind data to control when loading complete
                                    akVorodeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();


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
                        // xtpAmaliatAddVEdit.PageEnabled = true;
                        FillCmbHesabMoin();
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

        private void FrmAmaliatRozaneh_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            //En1 = EnumCED.None;
            //ActiveButtons();
            //NoeAmaliatTabpageIndex = 0;
            //NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
            //_NoeAmaliatCode = 2;
            //_NoeSanadCode = 201;
            //// xtcAmaliatRozaneh.SelectedTabPageIndex = 0;
            //NoeSanadTabpageIndex = 0;
            //XtraTabControl1_1 = xtc_VorodeKala;
            //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
            //NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
            xtcAmaliatRozaneh_SelectedPageChanged(null, null);
            gridControl = gridControl_ResidKharid_Riz;
            gridView = gridView_ResidKharid_Riz;
            // XtraTabControl1_1.SelectedTabPageIndex = 0;
            FillCmbNameAnbar();
            textEdit1.Focus();
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
                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    //NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
                    _NoeAmaliatCode = 2;

                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpKhrojeKala")
                {
                    NoeAmaliatTabpageIndex = 1;
                    NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    XtraTabControl1_1 = xtc_KhorojeKala;
                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    //NoeSanadText = XtraTabControl1_1.SelectedTabPage.Text;
                    // XtraTabControl1_1.SelectedTabPageIndex = 0;
                    _NoeAmaliatCode = 3;
                }
                XtraTabControl1_1_SelectedPageChanged(null, null);
            }
        }

        int NoeSanadTabpageIndex = 0;
        private void XtraTabControl1_1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

            if (En1 == EnumCED.Cancel)
            {
                if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                {
                    if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKharid")
                    {
                        NoeSanadTabpageIndex = 0;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_ResidKharid_Riz;
                        gridView = gridView_ResidKharid_Riz;
                        _NoeSanadCode = 200;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzFroosh")
                    {
                        NoeSanadTabpageIndex = 1;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzFroosh;
                        gridView = gridView_BargashtAzFroosh;
                        _NoeSanadCode = 201;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKalaAmani")
                    {
                        NoeSanadTabpageIndex = 2;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_ResidKalaAmani;
                        gridView = gridView_ResidKalaAmani;
                        _NoeSanadCode = 202;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidTolid")
                    {
                        NoeSanadTabpageIndex = 3;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_ResidTolid;
                        gridView = gridView_ResidTolid;
                        _NoeSanadCode = 203;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleTolid")
                    {
                        NoeSanadTabpageIndex = 4;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzHavaleTolid;
                        gridView = gridView_BargashtAzHavaleTolid;
                        _NoeSanadCode = 204;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleHazine")
                    {
                        NoeSanadTabpageIndex = 5;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzHavaleHazine;
                        gridView = gridView_BargashtAzHavaleHazine;
                        _NoeSanadCode = 205;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleAmval")
                    {
                        NoeSanadTabpageIndex = 6;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzHavaleAmval;
                        gridView = gridView_BargashtAzHavaleAmval;
                        _NoeSanadCode = 206;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_EzafateAnbar")
                    {
                        NoeSanadTabpageIndex = 7;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_EzafateAnbar;
                        gridView = gridView_EzafateAnbar;
                        _NoeSanadCode = 207;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_AllVorode")
                    {
                        NoeSanadTabpageIndex = 8;
                        NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        gridControl = gridControl_AllVorode;
                        gridView = gridView_AllVorode;
                        //_NoeSanadCode = 208;
                        btnCreate.Enabled = false;
                    }

                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;
                    btnDisplyList_Click(null, null);

                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpKhrojeKala")
                {
                    if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_BargashtAzKharid")
                    {
                        NoeSanadTabpageIndex = 0;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzKharid;
                        gridView = gridView_BargashtAzKharid;
                        _NoeSanadCode = 300;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleFroosh")
                    {
                        NoeSanadTabpageIndex = 1;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_HavaleFroosh;
                        gridView = gridView_HavaleFroosh;
                        _NoeSanadCode = 301;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleKalaAmani")
                    {
                        NoeSanadTabpageIndex = 2;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_HavaleKalaAmani;
                        gridView = gridView_HavaleKalaAmani;
                        _NoeSanadCode = 302;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_BargashtAzResidTolid")
                    {
                        NoeSanadTabpageIndex = 3;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_BargashtAzResidTolid;
                        gridView = gridView_BargashtAzResidTolid;
                        _NoeSanadCode = 303;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleTolid")
                    {
                        NoeSanadTabpageIndex = 4;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_HavaleTolid;
                        gridView = gridView_HavaleTolid;
                        _NoeSanadCode = 304;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleHazine")
                    {
                        NoeSanadTabpageIndex = 5;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_HavaleHazine;
                        gridView = gridView_HavaleHazine;
                        _NoeSanadCode = 305;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleAmval")
                    {
                        NoeSanadTabpageIndex = 6;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_HavaleAmval;
                        gridView = gridView_HavaleAmval;
                        _NoeSanadCode = 306;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_KosoratAnbar")
                    {
                        NoeSanadTabpageIndex = 7;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_KosoratAnbar;
                        gridView = gridView_KosoratAnbar;
                        _NoeSanadCode = 307;
                        btnCreate.Enabled = true;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_AllKhoroji")
                    {
                        NoeSanadTabpageIndex = 8;
                        NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        gridControl = gridControl_AllKhoroji;
                        gridView = gridView_AllKhoroji;
                        //_NoeSanadCode = 308;
                        btnCreate.Enabled = false;
                    }

                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;
                    btnDisplyList_Click(null, null);

                }
            }
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
            //if (Convert.ToInt32(cmbHesabMoin.EditValue) > 0)
            //    FillCmbHesabTafsili();
            //cmbHesabTafsili.EditValue = 0;
            using (var db = new MyContext())
            {
                try
                {
                    FillCmbHesabTafsili();
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    var q = db.EpHesabMoin1s.FirstOrDefault(s => s.SalId == _SalId && s.Id == _HesabMoinId);
                    if (q != null)
                    {
                        switch (q.GroupLevelsId)
                        {
                            case 0:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    break;
                                }
                            case 1:
                                {
                                    cmbHesabTafsili1.ReadOnly = false;
                                    cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    break;
                                }
                            case 2:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = false;
                                    cmbHesabTafsili3.ReadOnly = true;
                                    break;
                                }
                            case 3:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = false;
                                    break;
                                }
                            default:
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FillGridControl();

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
            //    default:
            //        break;
            //}

            HelpClass1.ClearControls(panelControl_AddVaEdit);
            cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = null;
            cmbHesabMoin.Properties.DataSource = cmbHesabTafsili1.Properties.DataSource = cmbHesabTafsili2.Properties.DataSource = cmbHesabTafsili3.Properties.DataSource = null;
            btnDelete1.Enabled = btnEdit1.Enabled = false;

            En1 = EnumCED.Cancel;
            xtcAmaliatRozaneh.SelectedTabPageIndex = NoeAmaliatTabpageIndex;
            XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex;
            // if (NoeAmaliatTabpageIndex == 0 && NoeSanadTabpageIndex == 0)
            // XtraTabControl1_1_SelectedPageChanged(null, null);

            xtpAmaliatAddVEdit.PageVisible = false;
            panelControl_NameAnbar.Enabled = true;

            akVorodeKala_RizsBindingSource.Clear();
            //akVorodeKala_RizsBindingSource.DataSource = null;

            ActiveButtons();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Enabled)
            {
                //dbContext.Dispose();
                //panelControl_NameAnbar.Enabled = true;
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

                FrmAmaliatSelectKala fm = new FrmAmaliatSelectKala(this);
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
                    if (XtraMessageBox.Show("آیا " + NoeSanadText + " مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                                var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                if (q.Count > 0)
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
                        int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                        // btnSaveAndNext.Enabled = false;
                        panelControl_NameAnbar.Enabled = false;
                        int _Seryal = Convert.ToInt32(gridView.GetFocusedRowCellValue("Seryal").ToString());
                        string _DateTimeSanad = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimeSanad")).ToString();
                        bool _IsRiali = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRiali"));
                        string _lblSanadNamber = gridView.GetFocusedRowCellValue("SanadNamber").ToString();
                        int _MoinId = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabMoinId"));
                        // string _TafsiliId = gridView.GetFocusedRowCellValue("TafsiliName").ToString();
                        _SharhSanad = gridView.GetFocusedRowCellValue("SharhSanad") != null ? gridView.GetFocusedRowCellValue("SharhSanad").ToString() : null;
                        int _Tafsili1Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili1Id"));
                        int _Tafsili2Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili2Id"));
                        int _Tafsili3Id = Convert.ToInt32(gridView.GetFocusedRowCellValue("HesabTafsili3Id"));
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
                        var q3 = dbContext.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                        switch (NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    var q = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
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
                                        txtSharhSanad.Text = _SharhSanad;
                                        //lblSanadNamber.BackColor = Color.Yellow;
                                        // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                        xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = false;
                                        xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                        xtpAmaliatAddVEdit.PageVisible = true;
                                        xtpAmaliatAddVEdit.Text = "عملیات ویرایش";
                                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                                        FillCmbHesabMoin();
                                        cmbHesabMoin.EditValue = _MoinId;
                                        cmbHesabTafsili1.Text = q3.Find(s => s.Id == _Tafsili1Id).Name.ToString();
                                        cmbHesabTafsili2.Text = q3.Find(s => s.Id == _Tafsili2Id).Name.ToString();
                                        cmbHesabTafsili3.Text = q3.Find(s => s.Id == _Tafsili3Id).Name.ToString();
                                        cmbHesabTafsili1.ShowPopup();
                                        cmbHesabTafsili1.ClosePopup();
                                        cmbHesabTafsili2.ShowPopup();
                                        cmbHesabTafsili2.ClosePopup();
                                        cmbHesabTafsili3.ShowPopup();
                                        cmbHesabTafsili3.ClosePopup();

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
                                    txtTarikh.Focus();

                                    break;
                                }
                            case "xtpKhrojeKala":
                                {
                                    var q = dbContext.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
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
                                        txtSharhSanad.Text = _SharhSanad;
                                        //lblSanadNamber.BackColor = Color.Yellow;
                                        // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                        xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = false;
                                        xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                        xtpAmaliatAddVEdit.PageVisible = true;
                                        xtpAmaliatAddVEdit.Text = "عملیات ویرایش";
                                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                                        FillCmbHesabMoin();
                                        cmbHesabMoin.EditValue = _MoinId;
                                        cmbHesabTafsili1.Text = q3.Find(s => s.Id == _Tafsili1Id).Name.ToString();
                                        cmbHesabTafsili2.Text = q3.Find(s => s.Id == _Tafsili2Id).Name.ToString();
                                        cmbHesabTafsili3.Text = q3.Find(s => s.Id == _Tafsili3Id).Name.ToString();
                                        cmbHesabTafsili1.ShowPopup();
                                        cmbHesabTafsili1.ClosePopup();
                                        cmbHesabTafsili2.ShowPopup();
                                        cmbHesabTafsili2.ClosePopup();
                                        cmbHesabTafsili3.ShowPopup();
                                        cmbHesabTafsili3.ClosePopup();

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
                                        akVorodeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                                    }


                                    //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                                    //{
                                    //    if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
                                    //    {
                                    //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                                    //    }
                                    //}
                                    txtTarikh.Focus();

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
            if (En1 == EnumCED.Create || En1 == EnumCED.Save)
            {
                cmbHesabTafsili1.ShowPopup();
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
                        _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        int _Seryal = Convert.ToInt32(txtSeryal.Text);
                        //DateTime _DateTimeSanad = Convert.ToDateTime(DateTime.Now.ToString().Replace(DateTime.Now.ToString().Substring(0, 10), txtTarikh.Text));
                        DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                        DateTime _DateTimeInsert = DateTime.Now;
                        _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                        _HesabTafsili1Id = Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 1 && s.EpAllGroupTafsili1.Id == 19 && s.Name == "سایر 1").Id : Convert.ToInt32(cmbHesabTafsili1.EditValue);
                        _HesabTafsili2Id = Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 2 && s.EpAllGroupTafsili1.Id == 38 && s.Name == "سایر 2").Id : Convert.ToInt32(cmbHesabTafsili2.EditValue);
                        _HesabTafsili3Id = Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 3 && s.EpAllGroupTafsili1.Id == 57 && s.Name == "سایر 3").Id : Convert.ToInt32(cmbHesabTafsili3.EditValue);
                        _SharhSanad = txtSharhSanad.Text;

                        switch (txtNoeAmaliat1.Text)
                        {
                            case "xtpVrodeKala":
                                {
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
                                                            long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
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
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.SanadNamber = 1;
                                                            obj1.HesabMoinId = _HesabMoinId;
                                                            obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                            AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                            obj.SalId = _SalId;
                                                            obj.AzAnbarId = _AzAnbarId;
                                                            obj.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj.Seryal = _Seryal;
                                                            obj.DateTimeSanad = _DateTimeSanad;
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
                                                            obj.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj.HesabTafsili3Id = _HesabTafsili3Id;

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
                                                        //int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                        //int _Seryal = Convert.ToInt32(txtSeryal.Text);
                                                        ///////////*******************
                                                        //DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                                        //DateTime _DateTimeInsert = DateTime.Now;
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        BindingList<AkVorodeKala_Riz> list = (BindingList<AkVorodeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        var q2 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list.Any(s => s.Id == item.Id))
                                                            {
                                                                db.AkAllAmaliateRozanehs.Remove(q2.FirstOrDefault(s => s.Id == item.Id));
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var q1 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            if (list[i].Id > 0)
                                                            {
                                                                long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                var v1 = q.FirstOrDefault(s => s.Id == list[i].Id);

                                                                v1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                v1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                v1.Seryal = _Seryal;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                v1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                v1.NoeSanadCode = _NoeSanadCode;
                                                                v1.NoeSanadText = NoeSanadText;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.SanadNamber = 1;
                                                                v1.HesabMoinId = _HesabMoinId;
                                                                v1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                v1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                v1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                var A1 = q1.FirstOrDefault(s => s.Id == v1.Id);

                                                                A1.SalId = _SalId;
                                                                A1.AzAnbarId = _AzAnbarId;
                                                                A1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                A1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                A1.Seryal = _Seryal;
                                                                A1.DateTimeSanad = _DateTimeSanad;
                                                                A1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                A1.NoeSanadCode = _NoeSanadCode;
                                                                A1.NoeSanadText = NoeSanadText;
                                                                A1.Meghdar = _Meghdar;
                                                                A1.Nerkh = _Nerkh;
                                                                A1.Mablag = _Mablag;
                                                                A1.IsRiali = _Mablag > 0 ? true : false;
                                                                A1.Radif = i + 1;
                                                                A1.SanadNamber = 1;
                                                                A1.AkVorodeKala_Riz1 = v1;
                                                                A1.HesabMoinId = _HesabMoinId;
                                                                A1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                A1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                A1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
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
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.SanadNamber = 1;
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                                AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                                obj.SalId = _SalId;
                                                                obj.AzAnbarId = _AzAnbarId;
                                                                obj.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                obj.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                obj.Seryal = _Seryal;
                                                                obj.DateTimeSanad = _DateTimeSanad;
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
                                                                obj.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.AkAllAmaliateRozanehs.Add(obj);
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                    {
                                                        btnCancel_Click(null, null);
                                                    }

                                                    if (IsClosed_AmaliatAddVEit == false)
                                                        ActiveButtons();

                                                    ///////////*******************
                                                    //var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AnbarId == _AzAnbarId && s.NoeAmaliatIndex == 2 && s.AmaliatIndex == 201 && s.Seryal == _Seryal).ToList();
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
                                                    //        obj1.AnbarId = _AzAnbarId;
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
                                                    //        obj.AnbarId = _AzAnbarId;
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
                                        case "xtp_BargashtAzHavaleHazine":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_BargashtAzHavaleAmval":
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
                            case "xtpKhrojeKala":
                                {
                                    //int _Seryal = Convert.ToInt32(txtSeryal.Text);
                                    //DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                    //DateTime _DateTimeInsert = DateTime.Now;
                                    //_HesabTafsili1Id = Convert.ToInt32(cmbHesabTafsili1.EditValue);
                                    //_HesabTafsili2Id = Convert.ToInt32(cmbHesabTafsili2.EditValue);
                                    //_HesabTafsili3Id = Convert.ToInt32(cmbHesabTafsili3.EditValue);
                                    // _SharhSanad = gridView.GetFocusedRowCellValue("SharhSanad") != null ? gridView.GetFocusedRowCellValue("SharhSanad").ToString() : null;
                                    switch (txtNoeSanad1.Text)
                                    {
                                        case "xtp_BargashtAzKharid":
                                            {
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

                                                            AkKhorojeKala_Riz obj1 = new AkKhorojeKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
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
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.SanadNamber = 1;
                                                            obj1.HesabMoinId = _HesabMoinId;
                                                            obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                            AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                            obj.SalId = _SalId;
                                                            obj.AzAnbarId = _AzAnbarId;
                                                            obj.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj.Seryal = _Seryal;
                                                            obj.DateTimeSanad = _DateTimeSanad;
                                                            obj.NoeAmaliatCode = _NoeAmaliatCode;
                                                            obj.NoeSanadCode = _NoeSanadCode;
                                                            obj.NoeSanadText = NoeSanadText;
                                                            obj.Meghdar = _Meghdar;
                                                            obj.Nerkh = _Nerkh;
                                                            obj.Mablag = _Mablag;
                                                            obj.IsRiali = _Mablag > 0 ? true : false;
                                                            obj.Radif = i + 1;
                                                            obj.SanadNamber = 1;
                                                            obj.AkKhorojeKala_Riz1 = obj1;
                                                            obj.HesabMoinId = _HesabMoinId;
                                                            obj.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj.HesabTafsili3Id = _HesabTafsili3Id;

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
                                                        //int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                        //int _Seryal = Convert.ToInt32(txtSeryal.Text);
                                                        ///////////*******************
                                                        //DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikh.Text);
                                                        //DateTime _DateTimeInsert = DateTime.Now;
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        BindingList<AkKhorojeKala_Riz> list = (BindingList<AkKhorojeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        var q2 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list.Any(s => s.Id == item.Id))
                                                            {
                                                                db.AkAllAmaliateRozanehs.Remove(q2.FirstOrDefault(s => s.Id == item.Id));
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var q1 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.Seryal == _Seryal).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            if (list[i].Id > 0)
                                                            {

                                                                long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                var k1 = q.FirstOrDefault(s => s.Id == list[i].Id);

                                                                k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                k1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                k1.Seryal = _Seryal;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                k1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                k1.NoeSanadCode = _NoeSanadCode;
                                                                k1.NoeSanadText = NoeSanadText;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                k1.SanadNamber = 1;
                                                                k1.HesabMoinId = _HesabMoinId;
                                                                k1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                k1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                k1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                var A1 = q1.FirstOrDefault(s => s.Id == k1.Id);

                                                                A1.SalId = _SalId;
                                                                A1.AzAnbarId = _AzAnbarId;
                                                                A1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                A1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                A1.Seryal = _Seryal;
                                                                A1.DateTimeSanad = _DateTimeSanad;
                                                                A1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                A1.NoeSanadCode = _NoeSanadCode;
                                                                A1.NoeSanadText = NoeSanadText;
                                                                A1.Meghdar = _Meghdar;
                                                                A1.Nerkh = _Nerkh;
                                                                A1.Mablag = _Mablag;
                                                                A1.IsRiali = _Mablag > 0 ? true : false;
                                                                A1.Radif = i + 1;
                                                                A1.SanadNamber = 1;
                                                                A1.AkKhorojeKala_Riz1 = k1;
                                                                A1.HesabMoinId = _HesabMoinId;
                                                                A1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                A1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                A1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                AkKhorojeKala_Riz obj1 = new AkKhorojeKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
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
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.SanadNamber = 1;
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                                AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                                                obj.SalId = _SalId;
                                                                obj.AzAnbarId = _AzAnbarId;
                                                                obj.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                obj.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                obj.Seryal = _Seryal;
                                                                obj.DateTimeSanad = _DateTimeSanad;
                                                                obj.NoeAmaliatCode = _NoeAmaliatCode;
                                                                obj.NoeSanadCode = _NoeSanadCode;
                                                                obj.NoeSanadText = NoeSanadText;
                                                                obj.Meghdar = _Meghdar;
                                                                obj.Nerkh = _Nerkh;
                                                                obj.Mablag = _Mablag;
                                                                obj.IsRiali = _Mablag > 0 ? true : false;
                                                                obj.Radif = i + 1;
                                                                obj.SanadNamber = 1;
                                                                obj.AkKhorojeKala_Riz1 = obj1;
                                                                obj.HesabMoinId = _HesabMoinId;
                                                                obj.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.AkAllAmaliateRozanehs.Add(obj);
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                    {
                                                        btnCancel_Click(null, null);
                                                    }

                                                    if (IsClosed_AmaliatAddVEit == false)
                                                        ActiveButtons();

                                                    ///////////*******************
                                                    //var q = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AnbarId == _AzAnbarId && s.NoeAmaliatIndex == 2 && s.AmaliatIndex == 201 && s.Seryal == _Seryal).ToList();
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
                                                    //        obj1.AnbarId = _AzAnbarId;
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
                                                    //        obj.AnbarId = _AzAnbarId;
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
                                        case "xtp_HavaleFroosh":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleKalaAmani":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_BargashtAzResidTolid":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleTolid":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleHazine":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleAmval":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_KosoratAnbar":
                                            {
                                                goto case "xtp_BargashtAzKharid";
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
                XtraTabControl1_1_SelectedPageChanged(null, null);
            }
            else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                XtraTabControl1_1_SelectedPageChanged(null, null);

            btnDisplyList.Enabled = true;

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
                            if (txtNoeAmaliat1.Text == "xtpVrodeKala")
                            {
                                var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                if (q.Count > 0)
                                {
                                    txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                                }
                                else
                                    txtSeryal.Text = "1";

                                txtTarikh.Text = DateTime.Now.ToString();
                                chkIsSanadHesabdari.Checked = true;
                            }
                            else if (txtNoeAmaliat1.Text == "xtpKhrojeKala")
                            {
                                var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
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
                            txtSharhSanad.Text = string.Empty;
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
        }

        private void btnSaveAndPrintAndClosed_Click_1(object sender, EventArgs e)
        {
            if (btnSaveAndPrintAndClosed.Enabled)
            {
                btnSaveAndClosed_Click(null, null);

            }
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
                if (xtcAmaliatRozaneh.SelectedTabPageIndex == 4)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = true;
                }
                else if (XtraTabControl1_1.SelectedTabPage.Name == "xtp_AllVorode")
                    btnDelete.Enabled = btnEdit.Enabled = btnCreate.Enabled = false;
                else if (XtraTabControl1_1.SelectedTabPage.Name == "xtp_AllKhoroji")
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
            if (dbContext != null)
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

        private void cmbHesabTafsili2_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create || En1 == EnumCED.Save)
            {
                cmbHesabTafsili2.ShowPopup();
            }

        }

        private void cmbHesabTafsili3_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create || En1 == EnumCED.Save)
            {
                cmbHesabTafsili3.ShowPopup();
            }

        }

        private void cmbControl_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }

        private void cmbNameAnbar_Enter_1(object sender, EventArgs e)
        {
            if (cmbNameAnbar.Text == "")
                cmbNameAnbar.ShowPopup();
        }
    }
}
