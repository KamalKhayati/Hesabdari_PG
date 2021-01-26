﻿using System;
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
    public partial class FrmAmaliatRozanehAnbarVKala : DevExpress.XtraEditors.XtraForm
    {
        MyContext dbContext;
        public FrmAmaliatRozanehAnbarVKala()
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

        int _SalId = 0;
        public int _AzAnbarId = 0;
        public int _KalaId = 0;
        public int _VahedeKalaId = 0;
        public string _AzAnbarName_NM = string.Empty;
        public string _KalaCode_NM = string.Empty;
        public string _KalaName_NM = string.Empty;
        public string _VahedeKala_NM = string.Empty;
        public string _Meghdar = string.Empty;
        public string _Nerkh = string.Empty;
        public string _Mablag = string.Empty;
        public string _Tozihat = string.Empty;
        public int _RowHandle = 0;

        string _NoeAmaliatTabpageName = string.Empty;
        string _NoeSanadTabpageName = string.Empty;
        string _NoeSanadText = string.Empty;
        int _NoeSanadIndex = 0;
        int _IndexTabPage = 0;
        int _NoeAmaliatCode = 0;
        int _NoeSanadCode = 0;

        int _TabPageCount = 0;
        int EditRowIndex = 0;
        bool IsClosed_AmaliatAddVEit = true;

        public void FillGridControl()
        {
            dbContext = new MyContext();
            {
                try
                {
                    List<AkVorodeKala_Riz> q = new List<AkVorodeKala_Riz>();
                    if (_FirstSelectAnbar_NextSanad)
                    {
                        _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        if (_NoeAmaliatTabpageName == "xtpVrodeKala")
                        {
                            var list = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                        else if (_NoeAmaliatTabpageName == "xtpKhrojeKala")
                        {
                            //var list = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal).ToList();
                            var list = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                    }
                    else
                    {
                        if (_NoeAmaliatTabpageName == "xtpVrodeKala")
                        {
                            var list = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                        else if (_NoeAmaliatTabpageName == "xtpKhrojeKala")
                        {
                            var list = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;

                        }
                    }


                    //int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    //var q1 = dbContext.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                    //var q2 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    //var q3 = dbContext.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();

                    switch (_NoeAmaliatTabpageName)
                    {
                        case "xtpVrodeKala":
                            {
                                switch (_NoeSanadTabpageName)
                                {
                                    case "xtp_AllVorode":
                                        {
                                            akVorodeKala_RizsBindingSource1.DataSource = q.Count > 0 ? q.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_darColAnbarha).ToList() : null;
                                            break;
                                        }
                                    case "xtp_MojodiAvalDore":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidKharid":
                                        {
                                            var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                            akVorodeKala_RizsBindingSource1.DataSource = qq.Count > 0 ? qq.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_darColAnbarha).ToList() : null;
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
                                }
                                break;
                            }
                        case "xtpKhrojeKala":
                            {
                                switch (_NoeSanadTabpageName)
                                {
                                    case "xtp_AllKhoroji":
                                        {
                                            akVorodeKala_RizsBindingSource1.DataSource = q.Count > 0 ? q.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_darColAnbarha).ToList() : null;
                                            break;
                                        }
                                    case "xtp_BargashtAzKharid":
                                        {
                                            var qq4 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                            akVorodeKala_RizsBindingSource1.DataSource = qq4.Count > 0 ? qq4.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_darColAnbarha).ToList() : null;
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

                    btnDelete.Enabled = btnEdit.Enabled = false;

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

                    #region MyRegion
                    //var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.IsActive == true).OrderBy(s => s.Code).ToList();

                    //foreach (var item in q1)
                    //{
                    //    IList<int> List1 = new List<int>();
                    //    string _Id1 = String.Empty;
                    //    if (item.TabagheKalaId != null)
                    //    {
                    //        char[] item1 = item.TabagheKalaId.ToArray();
                    //        for (int i = 0; i < item1.Count(); i++)
                    //        {
                    //            if (i == 0)
                    //            {
                    //                _Id1 = _Id1 + item1[i].ToString();
                    //            }
                    //            else
                    //            {
                    //                if (item1[i] == ',')
                    //                {
                    //                    int _Id2 = Convert.ToInt32(_Id1);
                    //                    List1.Add(_Id2);
                    //                    _Id1 = String.Empty;
                    //                }
                    //                else
                    //                {
                    //                    _Id1 = _Id1 + item1[i].ToString();
                    //                }

                    //            }
                    //        }

                    //        string _KalaId = String.Empty;
                    //        foreach (var item2 in List1)
                    //        {
                    //            _KalaId += db.EpTabaghehKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == item2).Name + ",";
                    //        }
                    //        item.TabagheKalaIdName_NM = _KalaId;
                    //    }

                    //}
                    //if (q1.Count > 0)
                    //    epListAnbarhasBindingSource.DataSource = q1;
                    //else
                    //    epListAnbarhasBindingSource.Clear();

                    #endregion

                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    //var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();
                    //foreach (var item in q1)
                    //{
                    //    var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                    //    if (qq.Count > 0)
                    //    {
                    //        string _TabagheKalaName = String.Empty;
                    //        foreach (var item2 in qq)
                    //        {
                    //            _TabagheKalaName += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                    //        }
                    //        item.TabagheKalaIdName_NM = _TabagheKalaName;
                    //    }
                    //}

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
                    if (En1 == EnumCED.Edit)
                        cmbHesabMoin.Properties.DataSource = q.Count > 0 ? q : null;
                    else
                        cmbHesabMoin.Properties.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true).ToList() : null;
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

                    var q1 = db.R_EpHesabMoin1_B_EpAllGroupTafsilis.Where(s => s.EpHesabMoin1Id == _HesabMoinId && s.SalId == _SalId).Select(s => s.AllGroupTafsiliId).ToList();
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
                        if (En1 == EnumCED.Create)
                        {
                            cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNamber == 1).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNamber == 1).OrderBy(s => s.Code).ToList() : null;
                            cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNamber == 2).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNamber == 2).OrderBy(s => s.Code).ToList() : null;
                            cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNamber == 3).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNamber == 3).OrderBy(s => s.Code).ToList() : null;

                        }
                        else
                        {
                            cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.LevelNamber == 1).OrderBy(s => s.Code);
                            cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.LevelNamber == 2).OrderBy(s => s.Code);
                            cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.LevelNamber == 3).OrderBy(s => s.Code);
                        }
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
            if (cmbNoeSanad.SelectedIndex < 0 || cmbNoeSanad.Text == "" || string.IsNullOrEmpty(cmbNoeSanad.Text))
            {
                //xtpAmaliatAddVEdit.Text = NoeSanad + " : نوع سند " + ": " + cmbNoeSanad.Text;
                XtraMessageBox.Show("لطفاً نوع سند را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbNoeSanad.ShowPopup();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabMoin.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 && cmbHesabTafsili1.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili1.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili1.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 && cmbHesabTafsili2.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili2.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili2.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 && cmbHesabTafsili3.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili3.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili3.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalCol_darColAnbarha.Text))
            {
                XtraMessageBox.Show("فیلد " + lblSeryalCol_darColAnbarha.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalCol_darColAnbarha.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalJoze_darColAnbarha.Text))
            {
                XtraMessageBox.Show("فیلد " + lblSeryalJoze_darColAnbarha.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalJoze_darColAnbarha.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalCol_darSelectAnbar.Text))
            {
                if (_FirstSelectAnbar_NextSanad)
                {
                    XtraMessageBox.Show("فیلد " + lblSeryalCol_darSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSeryalCol_darSelectAnbar.Focus();
                    return false;

                }
            }
            else if (string.IsNullOrEmpty(txtSeryalJoze_darSelectAnbar.Text))
            {
                if (_FirstSelectAnbar_NextSanad)
                {
                    XtraMessageBox.Show("فیلد " + lblSeryalJoze_darSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSeryalJoze_darSelectAnbar.Focus();
                    return false;
                }
            }
            else if (string.IsNullOrEmpty(txtTarikh.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNoeSanad1.Text) || string.IsNullOrEmpty(txtNoeAmaliat1.Text))
            {
                XtraMessageBox.Show("نوع سند مشخص نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtNoeSanad.Focus();
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
            if (_FirstSelectAnbar_NextSanad)
                fm.AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
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
            view.SetRowCellValue(e.RowHandle, "AzAnbarId", _AzAnbarId);
            view.SetRowCellValue(e.RowHandle, "KalaId", _KalaId);
            view.SetRowCellValue(e.RowHandle, "VahedeKalaId", _VahedeKalaId);
            view.SetRowCellValue(e.RowHandle, "KalaCode_NM", _KalaCode_NM);
            view.SetRowCellValue(e.RowHandle, "KalaName_NM", _KalaName_NM);
            view.SetRowCellValue(e.RowHandle, "VahedeKala_NM", _VahedeKala_NM);
            view.SetRowCellValue(e.RowHandle, "AzAnbarName_NM", _AzAnbarName_NM);
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
        string titelAmaliatAddVEdit = string.Empty;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (_FirstSelectAnbar_NextSanad)
                        {
                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                            if (_AzAnbarId == 0)
                            {
                                XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbNameAnbar.ShowPopup();
                                return;
                            }

                            panelControl_NameAnbar.Enabled = false;

                        }
                        else
                        {
                            txtSeryalCol_darSelectAnbar.Text = txtSeryalJoze_darSelectAnbar.Text = "0";
                            txtSeryalCol_darSelectAnbar.Visible = txtSeryalJoze_darSelectAnbar.Visible = false;
                            lblSeryalCol_darSelectAnbar.Visible = lblSeryalJoze_darSelectAnbar.Visible = false;
                        }

                        En1 = EnumCED.Create;
                        ActiveButtons();
                        titelAmaliatAddVEdit = "عملیات ایجاد";
                        //panelControl_NameAnbar.Enabled = false;
                        switch (_NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    cmbNoeSanad.Properties.Items.Clear();
                                    cmbNoeSanad.Properties.Items.Add("موجودی اول دوره");
                                    cmbNoeSanad.Properties.Items.Add("رسید خرید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از فروش");
                                    cmbNoeSanad.Properties.Items.Add("رسید کالای امانی");
                                    cmbNoeSanad.Properties.Items.Add("رسید تولید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله تولید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله هزینه");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله اموال");
                                    cmbNoeSanad.Properties.Items.Add("اضافات انبار");
                                    cmbNoeSanad.Properties.Items.Add("رسید (جابجایی)");

                                    var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                    txtSeryalCol_darColAnbarha.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_darColAnbarha) + 1).ToString() : "1";

                                    //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                                    //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                    //txtNoeSanad.BackColor = Color.LightGreen;
                                    //lblSanadNamber.BackColor = Color.LightGreen;
                                    XtraTabControl1_1 = xtc_VorodeKala;
                                    txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                    txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                    xtpAmaliatAddVEdit.PageVisible = true;
                                    xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                                    HelpClass1.DateTimeMask(txtTarikh);
                                    txtTarikh.Text = DateTime.Now.ToString();
                                    //chkIsSanadHesabdari.Checked = true;
                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_ResidKharid":
                                            {
                                                //NoeSanad = NoeSanad + " : نوع سند " + ": " + XtraTabControl1_1.SelectedTabPage.Text;
                                                if (NoeSanadTabpageIndex_VorodeKala != 0)
                                                {
                                                    cmbNoeSanad.SelectedIndex = NoeSanadTabpageIndex_VorodeKala - 1;
                                                    cmbNoeSanad.ReadOnly = true;
                                                }
                                                else
                                                {
                                                    cmbNoeSanad.ReadOnly = false;
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
                                        case "xtp_MojodiAvalDore":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_AllVorode":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }

                                        default:
                                            break;
                                    }
                                    // _TabPageCount = xtcAmaliatRozaneh.TabPages.Count;
                                    xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                    //lblSeryal_darColAnbarha.Text = "ش رسید در کل انبارها";
                                    //lblSeryal_darSelectAnbar.Text = "ش رسید در انبار انتخابی";
                                    //lblSeryal_darSelectNoe.Text = "ش رسید در نوع رسید";

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
                                    cmbNoeSanad.Properties.Items.Clear();
                                    cmbNoeSanad.Properties.Items.Add("برگشت از خرید");
                                    cmbNoeSanad.Properties.Items.Add("حواله فروش");
                                    cmbNoeSanad.Properties.Items.Add("حواله کالای امانی");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از رسید تولید");
                                    cmbNoeSanad.Properties.Items.Add("حواله تولید");
                                    cmbNoeSanad.Properties.Items.Add("حواله هزینه");
                                    cmbNoeSanad.Properties.Items.Add("حواله اموال");
                                    cmbNoeSanad.Properties.Items.Add("کسورات انبار");
                                    cmbNoeSanad.Properties.Items.Add("حواله (جابجایی)");

                                    var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                    txtSeryalCol_darColAnbarha.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_darColAnbarha) + 1).ToString() : "1";

                                    XtraTabControl1_1 = xtc_KhorojeKala;
                                    //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                                    txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                    txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                    //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                    //txtNoeSanad.BackColor = Color.LightGreen;
                                    //lblSanadNamber.BackColor = Color.LightGreen;
                                    xtpAmaliatAddVEdit.PageVisible = true;
                                    xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                                    //xtpAmaliatAddVEdit.Text = "عملیات ایجاد";
                                    HelpClass1.DateTimeMask(txtTarikh);
                                    txtTarikh.Text = DateTime.Now.ToString();
                                    //chkIsSanadHesabdari.Checked = true;


                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_BargashtAzKharid":
                                            {
                                                //NoeSanad = NoeSanad + " : نوع سند  " + ": " + XtraTabControl1_1.SelectedTabPage.Text;
                                                if (NoeSanadTabpageIndex_KhorojeKala != 0)
                                                {
                                                    cmbNoeSanad.SelectedIndex = NoeSanadTabpageIndex_KhorojeKala - 1;
                                                    cmbNoeSanad.ReadOnly = true;
                                                }
                                                else
                                                {
                                                    cmbNoeSanad.ReadOnly = false;
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
                                        case "xtp_AllKhoroji":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }

                                        default:
                                            break;
                                    }
                                    // _TabPageCount = xtcAmaliatRozaneh.TabPages.Count;
                                    xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                    //lblSeryalCol_darColAnbarha.Text = "ش حواله در کل انبارها";
                                    //lblSeryalCol_darSelectAnbar.Text = "ش حواله در انبار انتخابی";
                                    //lblSeryalJoze_darSelectAnbar.Text = "ش حواله در نوع انتخابی";


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
                        //xtpAmaliatAddVEdit.Text = NoeSanad;
                        cmbNoeSanad.Focus();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public bool _FirstSelectAnbar_NextSanad = true;
        GridControl objGridControl = null;
        private void FrmAmaliatRozanehAnbarVKala_Load(object sender, EventArgs e)
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
            //xtcAmaliatRozaneh.SelectedTabPageIndex = 0;
            //gridControl = gridControl_AllVorode;
            //gridView = gridView_AllVorode;
            //xtcAmaliatRozaneh.SelectedTabPageIndex = 0;
            xtcAmaliatRozaneh_SelectedPageChanged(null, null);
            //xtc_VorodeKala.SelectedTabPageIndex = 0;
            //objGridControl = new GridControl();
            //objGridControl = gridControl_AllVorode;
            //gridControl_AllVorode.DataBindings.Clear();
            //xtp_ResidJabejaee.Controls.Add(gc);

            // XtraTabControl1_1.SelectedTabPageIndex = 0;
            //FillCmbNameAnbar();
            //textEdit1.Focus();

            if (_FirstSelectAnbar_NextSanad)
            {
                FillCmbNameAnbar();
                gridView.Columns["SeryalCol_darColAnbarha"].Visible = false;
                gridView.Columns["SeryalJoze_darColAnbarha"].Visible = false;
                lblSeryalCol_darColAnbarha.Visible = txtSeryalCol_darColAnbarha.Visible = false;
                lblSeryalJoze_darColAnbarha.Visible = txtSeryalJoze_darColAnbarha.Visible = false;
                textEdit1.Focus();
            }
            else
            {
                panelControl_NameAnbar.Enabled = false;
                panelControl_NameAnbar.Visible = false;
                panelControl_NameAnbar.Width = 0;
                xtcAmaliatRozaneh.Enabled = true;
                gridView.Columns["SeryalCol_darSelectAnbar"].Visible = false;
                gridView.Columns["SeryalJoze_darSelectAnbar"].Visible = false;
                lblSeryalCol_darSelectAnbar.Visible = txtSeryalCol_darSelectAnbar.Visible = false;
                lblSeryalJoze_darSelectAnbar.Visible = txtSeryalJoze_darSelectAnbar.Visible = false;
                btnCreate.Focus();
            }

        }

        int NoeAmaliatTabpageIndex = 0;
        private void xtcAmaliatRozaneh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                XtraTabControl1_1 = new XtraTabControl();
                if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                {
                    NoeAmaliatTabpageIndex = 0;
                    _NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    XtraTabControl1_1 = xtc_VorodeKala;
                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    //_NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                    _NoeAmaliatCode = 2;
                    //gridControl = gridControl_AllVorode;
                    //gridView = gridView_AllVorode;
                    // objGridControl = new GridControl();
                    //objGridControl = gridControl_AllVorode;
                    ///objXtraTabPage = xtc_VorodeKala.SelectedTabPage;
                    xtc_VorodeKala.SelectedTabPageIndex = NoeSanadTabpageIndex_VorodeKala == 0 ? 0 : NoeSanadTabpageIndex_VorodeKala;
                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpKhrojeKala")
                {
                    NoeAmaliatTabpageIndex = 1;
                    _NoeAmaliatTabpageName = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    XtraTabControl1_1 = xtc_KhorojeKala;
                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                    //_NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                    // XtraTabControl1_1.SelectedTabPageIndex = 0;
                    _NoeAmaliatCode = 3;
                    //gridControl = gridControl_AllKhoroji;
                    //gridView = gridView_AllKhoroji;
                    //objGridControl = new GridControl();
                    //objGridControl = gridControl_AllKhoroji;
                    //objXtraTabPage = xtc_KhorojeKala.SelectedTabPage;
                    xtc_KhorojeKala.SelectedTabPageIndex = NoeSanadTabpageIndex_KhorojeKala == 0 ? 0 : NoeSanadTabpageIndex_KhorojeKala;
                }
                //objXtraTabPage.Controls.Add(objGridControl);
                XtraTabControl1_1_SelectedPageChanged(null, null);
            }
        }

        int NoeSanadTabpageIndex_VorodeKala = 0;
        int NoeSanadTabpageIndex_KhorojeKala = 0;
        XtraTabPage objXtraTabPage;
        private void XtraTabControl1_1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                objXtraTabPage = new XtraTabPage();

                if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                {
                    objXtraTabPage = xtc_VorodeKala.SelectedTabPage;

                    if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_AllVorode")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 0;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        // _NoeSanadCode = 200;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_MojodiAvalDore")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 1;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_MojodiAvalDore;
                        //gridView = gridView_MojodiAvalDore;
                        _NoeSanadCode = 201;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKharid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 2;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidKharid_Riz;
                        //gridView = gridView_ResidKharid_Riz;
                        _NoeSanadCode = 202;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzFroosh")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 3;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzFroosh;
                        //gridView = gridView_BargashtAzFroosh;
                        _NoeSanadCode = 203;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKalaAmani")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 4;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidKalaAmani;
                        //gridView = gridView_ResidKalaAmani;
                        _NoeSanadCode = 204;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidTolid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 5;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidTolid;
                        //gridView = gridView_ResidTolid;
                        _NoeSanadCode = 205;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleTolid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 6;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleTolid;
                        // gridView = gridView_BargashtAzHavaleTolid;
                        _NoeSanadCode = 206;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleHazine")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 7;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleHazine;
                        //gridView = gridView_BargashtAzHavaleHazine;
                        _NoeSanadCode = 207;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleAmval")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 8;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleAmval;
                        //gridView = gridView_BargashtAzHavaleAmval;
                        _NoeSanadCode = 208;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_EzafateAnbar")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 9;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_EzafateAnbar;
                        //gridView = gridView_EzafateAnbar;
                        _NoeSanadCode = 209;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidJabejaee")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 10;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidJabejaee;
                        //gridView = gridView_ResidJabejaee;
                        _NoeSanadCode = 210;
                    }

                }
                else if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpKhrojeKala")
                {
                    objXtraTabPage = xtc_KhorojeKala.SelectedTabPage;

                    if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_AllKhoroji")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 0;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //_NoeSanadCode = 300;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_BargashtAzKharid")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 1;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzKharid;
                        //gridView = gridView_BargashtAzKharid;
                        _NoeSanadCode = 301;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleFroosh")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 2;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleFroosh;
                        //gridView = gridView_HavaleFroosh;
                        _NoeSanadCode = 302;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleKalaAmani")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 3;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleKalaAmani;
                        //gridView = gridView_HavaleKalaAmani;
                        _NoeSanadCode = 303;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_BargashtAzResidTolid")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 4;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzResidTolid;
                        //gridView = gridView_BargashtAzResidTolid;
                        _NoeSanadCode = 304;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleTolid")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 5;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleTolid;
                        //gridView = gridView_HavaleTolid;
                        _NoeSanadCode = 305;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleHazine")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 6;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        // NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleHazine;
                        //gridView = gridView_HavaleHazine;
                        _NoeSanadCode = 306;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleAmval")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 7;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleAmval;
                        //gridView = gridView_HavaleAmval;
                        _NoeSanadCode = 307;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_KosoratAnbar")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 8;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_KosoratAnbar;
                        //gridView = gridView_KosoratAnbar;
                        _NoeSanadCode = 308;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleJabejaee")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 9;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleJabeJaee;
                        //gridView = gridView_HavaleJabeJaee;
                        _NoeSanadCode = 309;
                    }


                }

                gridControl = gridControl_AllVorode;
                gridView = gridView_AllVorode;
                objGridControl = new GridControl();
                objGridControl = gridControl_AllVorode;


                if (_NoeSanadTabpageName == "xtp_ResidJabejaee" || _NoeSanadTabpageName == "xtp_HavaleJabejaee")
                {
                    gridView.Columns["EpAllHesabTafsili1.Code"].Visible = false;
                    gridView.Columns["EpAllHesabTafsili1.Name"].Visible = false;
                    gridView.Columns["FactorNamber"].Visible = false;
                    gridView.Columns["EpHesabMoin1.Code"].Visible = false;
                    gridView.Columns["EpHesabMoin1.Name"].Visible = false;
                    gridView.Columns["EpListAnbarha1.Name"].Caption = "از انبار";
                    gridView.Columns["EpListAnbarha2.Name"].Visible = true;

                    //gridView.Columns["EpAllHesabTafsili1.Code"].VisibleIndex = 7;
                    //gridView.Columns["EpAllHesabTafsili1.Name"].VisibleIndex = 8;
                    //gridView.Columns["FactorNamber"].VisibleIndex = 9;
                    gridView.Columns["Radif"].VisibleIndex = 8;
                    gridView.Columns["EpNameKala1.Code"].VisibleIndex = 9;
                    gridView.Columns["EpNameKala1.Name"].VisibleIndex = 10;
                    gridView.Columns["EpVahedKala1.Name"].VisibleIndex = 11;
                    gridView.Columns["Meghdar"].VisibleIndex = 12;
                    gridView.Columns["Nerkh"].VisibleIndex = 13;
                    gridView.Columns["Mablag"].VisibleIndex = 14;
                    gridView.Columns["IsRiali"].VisibleIndex = 15;
                    gridView.Columns["DateTimeInsert"].VisibleIndex = 16;
                    gridView.Columns["DateTimeEdit"].VisibleIndex = 17;
                    //gridView.Columns["EpHesabMoin1.Code"].VisibleIndex = 20;
                    //gridView.Columns["EpHesabMoin1.Name"].VisibleIndex = 21;
                    gridView.Columns["EpListAnbarha1.Name"].VisibleIndex = 18;
                    gridView.Columns["EpListAnbarha2.Name"].VisibleIndex = 19;
                    gridView.Columns["RozaneSanadNumber"].VisibleIndex = 20;
                    gridView.Columns["GhateySanadNamber"].VisibleIndex = 21;
                    gridView.Columns["PaygiriNumber"].VisibleIndex = 22;
                    gridView.Columns["Tozihat"].VisibleIndex = 23;
                    gridView.Columns["SharhSanad"].VisibleIndex = 24;

                }
                else
                {
                    gridView.Columns["EpAllHesabTafsili1.Code"].Visible = true;
                    gridView.Columns["EpAllHesabTafsili1.Name"].Visible = true;
                    gridView.Columns["FactorNamber"].Visible = true;
                    gridView.Columns["EpHesabMoin1.Code"].Visible = true;
                    gridView.Columns["EpHesabMoin1.Name"].Visible = true;
                    gridView.Columns["EpListAnbarha1.Name"].Caption = "نام انبار";
                    gridView.Columns["EpListAnbarha2.Name"].Visible = false;

                    gridView.Columns["EpAllHesabTafsili1.Code"].VisibleIndex = 8;
                    gridView.Columns["EpAllHesabTafsili1.Name"].VisibleIndex = 9;
                    gridView.Columns["FactorNamber"].VisibleIndex = 10;
                    gridView.Columns["Radif"].VisibleIndex = 11;
                    gridView.Columns["EpNameKala1.Code"].VisibleIndex = 12;
                    gridView.Columns["EpNameKala1.Name"].VisibleIndex = 13;
                    gridView.Columns["EpVahedKala1.Name"].VisibleIndex = 14;
                    gridView.Columns["Meghdar"].VisibleIndex = 15;
                    gridView.Columns["Nerkh"].VisibleIndex = 16;
                    gridView.Columns["Mablag"].VisibleIndex = 17;
                    gridView.Columns["IsRiali"].VisibleIndex = 18;
                    gridView.Columns["DateTimeInsert"].VisibleIndex = 19;
                    gridView.Columns["DateTimeEdit"].VisibleIndex = 20;
                    gridView.Columns["EpHesabMoin1.Code"].VisibleIndex = 21;
                    gridView.Columns["EpHesabMoin1.Name"].VisibleIndex = 22;
                    gridView.Columns["EpListAnbarha1.Name"].VisibleIndex = 23;
                    //gridView.Columns["EpListAnbarha2.Name"].VisibleIndex = 23;
                    gridView.Columns["RozaneSanadNumber"].VisibleIndex = 24;
                    gridView.Columns["GhateySanadNamber"].VisibleIndex = 25;
                    gridView.Columns["PaygiriNumber"].VisibleIndex = 26;
                    gridView.Columns["Tozihat"].VisibleIndex = 27;
                    gridView.Columns["SharhSanad"].VisibleIndex = 28;


                }


                objXtraTabPage.Controls.Add(objGridControl);

                if (_FirstSelectAnbar_NextSanad)
                {
                    if (XtraTabControl1_1.SelectedTabPageIndex == 0)
                        gridView.Columns["SeryalCol_darSelectAnbar"].GroupIndex = 0;
                    else
                        gridView.Columns["SeryalJoze_darSelectAnbar"].GroupIndex = 0;
                }
                else
                {
                    if (XtraTabControl1_1.SelectedTabPageIndex == 0)
                        gridView.Columns["SeryalCol_darColAnbarha"].GroupIndex = 0;
                    else
                        gridView.Columns["SeryalJoze_darColAnbarha"].GroupIndex = 0;
                }

                btnDelete.Enabled = btnEdit.Enabled = false;
                btnDisplyList_Click(null, null);

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
                        switch (q.GroupTafsiliLevelsIndex)
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

            En1 = EnumCED.Cancel;

            HelpClass1.ClearControls(panelControl_AddVaEdit);
            cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = null;
            cmbHesabMoin.Properties.DataSource = cmbHesabTafsili1.Properties.DataSource = cmbHesabTafsili2.Properties.DataSource = cmbHesabTafsili3.Properties.DataSource = null;
            btnDelete1.Enabled = btnEdit1.Enabled = false;

            xtcAmaliatRozaneh.SelectedTabPageIndex = NoeAmaliatTabpageIndex;
            if (NoeAmaliatTabpageIndex == 0)
                XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex_VorodeKala;
            else
                XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex_KhorojeKala;

            // if (NoeAmaliatTabpageIndex == 0 && NoeSanadTabpageIndex == 0)
            // XtraTabControl1_1_SelectedPageChanged(null, null);

            xtpAmaliatAddVEdit.PageVisible = false;
            panelControl_NameAnbar.Enabled = true;

            akVorodeKala_RizsBindingSource.Clear();
            //gridControl_AmaliatAddVaEdit.DataBindings.Clear();
            //gridControl_AmaliatAddVaEdit.DataSource = null;

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
                _AzAnbarId = (int)gridView_AmaliatAddVaEdit.GetFocusedRowCellValue("AzAnbarId");
                _KalaId = (int)gridView_AmaliatAddVaEdit.GetFocusedRowCellValue("KalaId");
                _VahedeKalaId = (int)gridView_AmaliatAddVaEdit.GetFocusedRowCellValue("VahedeKalaId");
                //_KalaCode_NM = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaCode");
                //_KalaName_NM = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaName");
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
                //fm.AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                fm.ShowDialog();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    int _SeryalCol_darColAnbarha = 0;
                    int _SeryalJoze_darColAnbarha = 0;
                    int _SeryalCol_darSelectAnbar = 0;
                    int _SeryalJoze_darSelectAnbar = 0;
                    try
                    {
                        _SeryalCol_darColAnbarha = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_darColAnbarha").ToString());
                        _SeryalJoze_darColAnbarha = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_darColAnbarha").ToString());
                        _SeryalCol_darSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_darSelectAnbar").ToString());
                        _SeryalJoze_darSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_darSelectAnbar").ToString());
                        _NoeSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeSanadCode").ToString());

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //string NoeSanad = XtraTabControl1_1.SelectedTabPage.Text;
                    if (XtraMessageBox.Show("آیا " + _NoeSanadText + " مورد نظر کلاً حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                //_AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                _AzAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AzAnbarId").ToString());
                                var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha).ToList();
                                if (q.Count > 0)
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        var q1 = q.Where(s => s.SeryalCol_darSelectAnbar == _SeryalCol_darSelectAnbar && s.SeryalJoze_darSelectAnbar == _SeryalJoze_darSelectAnbar && s.AzAnbarId == _AzAnbarId).ToList();
                                        db.AkVorodeKala_Rizs.RemoveRange(q1);
                                    }
                                    else
                                        db.AkVorodeKala_Rizs.RemoveRange(q);
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
                        int _SeryalCol_darColAnbarha = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_darColAnbarha").ToString());

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
                        titelAmaliatAddVEdit = "عملیات ویرایش";
                        //int _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                        // btnSaveAndNext.Enabled = false;
                        if (_FirstSelectAnbar_NextSanad)
                        {
                            _AzAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AzAnbarId"));
                            panelControl_NameAnbar.Enabled = false;
                        }
                        else
                        {
                            txtSeryalCol_darSelectAnbar.Text = txtSeryalJoze_darSelectAnbar.Text = "0";
                            txtSeryalCol_darSelectAnbar.Visible = txtSeryalJoze_darSelectAnbar.Visible = false;
                            lblSeryalCol_darSelectAnbar.Visible = lblSeryalJoze_darSelectAnbar.Visible = false;
                        }

                        _NoeSanadIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeSanadIndex"));
                        _NoeSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeSanadCode").ToString());
                        int _SeryalCol_darColAnbarha = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_darColAnbarha").ToString());
                        int _SeryalJoze_darColAnbarha = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_darColAnbarha").ToString());
                        int _SeryalCol_darSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_darSelectAnbar").ToString());
                        int _SeryalJoze_darSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_darSelectAnbar").ToString());
                        int? _GhateySanadNamber = null;
                        if (gridView.GetFocusedRowCellValue("GhateySanadNamber") != null)
                            _GhateySanadNamber = Convert.ToInt32(gridView.GetFocusedRowCellValue("GhateySanadNamber").ToString());
                        int _SabetAtefNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("SabetAtefNumber").ToString());
                        int _RozaneSanadNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("RozaneSanadNumber").ToString());
                        int? _PaygiriNumber = null;
                        if (gridView.GetFocusedRowCellValue("PaygiriNumber") != null)
                            _PaygiriNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("PaygiriNumber").ToString());
                        string _DateTimeSanad = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimeSanad")).ToString();
                        bool _IsRiali = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRiali"));
                        //string _SabetAtefNumber = gridView.GetFocusedRowCellValue("SabetAtefNumber").ToString();
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
                        switch (_NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    var q = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha).ToList();
                                    if (q.Count > 0)
                                    {
                                        cmbNoeSanad.Properties.Items.Clear();
                                        cmbNoeSanad.Properties.Items.Add("موجودی اول دوره");
                                        cmbNoeSanad.Properties.Items.Add("رسید خرید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از فروش");
                                        cmbNoeSanad.Properties.Items.Add("رسید کالای امانی");
                                        cmbNoeSanad.Properties.Items.Add("رسید تولید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله تولید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله هزینه");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله اموال");
                                        cmbNoeSanad.Properties.Items.Add("اضافات انبار");
                                        cmbNoeSanad.Properties.Items.Add("رسید (جابجایی)");

                                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                        cmbNoeSanad.SelectedIndex = _NoeSanadIndex;
                                        txtSeryalCol_darColAnbarha.Text = _SeryalCol_darColAnbarha.ToString();
                                        txtSeryalJoze_darColAnbarha.Text = _SeryalJoze_darColAnbarha.ToString();
                                        txtSeryalCol_darSelectAnbar.Text = _SeryalCol_darSelectAnbar.ToString();
                                        txtSeryalJoze_darSelectAnbar.Text = _SeryalJoze_darSelectAnbar.ToString();
                                        txtGhateySanadNumber.Text = _GhateySanadNamber != null ? _GhateySanadNamber.ToString() : "";
                                        txtSabetAtefNumber.Text = _SabetAtefNumber.ToString();
                                        txtRozaneSanadNumber.Text = _RozaneSanadNumber.ToString();
                                        txtPaygiriNumber.Text = _PaygiriNumber != null ? _PaygiriNumber.ToString() : "";
                                        txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                        txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                        //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                        //txtNoeSanad.BackColor = Color.Yellow;
                                        HelpClass1.DateTimeMask(txtTarikh);
                                        txtTarikh.Text = _DateTimeSanad;
                                        //chkIsSanadHesabdari.Checked = _IsRiali;
                                        //txtSabetAtefNumber.Text = _SabetAtefNumber;
                                        txtSharhSanad.Text = _SharhSanad;
                                        //lblSanadNamber.BackColor = Color.Yellow;
                                        // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                        xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = false;
                                        xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                        xtpAmaliatAddVEdit.PageVisible = true;
                                        //NoeSanad = NoeSanad + " : نوع رسید " + ": " + XtraTabControl1_1.SelectedTabPage.Text;
                                        //xtpAmaliatAddVEdit.Text = NoeSanad;
                                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                                        //lblSeryalCol_darColAnbarha.Text = "ش رسید در کل انبارها";
                                        //lblSeryalCol_darSelectAnbar.Text = "ش رسید در انبار انتخابی";
                                        //lblSeryalJoze_darSelectAnbar.Text = "ش رسید در نوع رسید";
                                        FillCmbHesabMoin();
                                        cmbHesabMoin.EditValue = _MoinId;
                                        cmbHesabTafsili1.EditValue = _Tafsili1Id;
                                        cmbHesabTafsili2.EditValue = _Tafsili2Id;
                                        cmbHesabTafsili3.EditValue = _Tafsili3Id;
                                        //cmbHesabTafsili1.Text = q3.Find(s => s.Id == _Tafsili1Id).Name.ToString();
                                        //cmbHesabTafsili2.Text = q3.Find(s => s.Id == _Tafsili2Id).Name.ToString();
                                        //cmbHesabTafsili3.Text = q3.Find(s => s.Id == _Tafsili3Id).Name.ToString();
                                        //cmbHesabTafsili1.ShowPopup();
                                        //cmbHesabTafsili1.ClosePopup();
                                        //cmbHesabTafsili2.ShowPopup();
                                        //cmbHesabTafsili2.ClosePopup();
                                        //cmbHesabTafsili3.ShowPopup();
                                        //cmbHesabTafsili3.ClosePopup();

                                        //List<AkVorodeKala_Riz> DBGridControl = (List<AkVorodeKala_Riz>)gridControl.DataSource;
                                        //BindingList<AkVorodeKala_Riz> bl = new BindingList<AkVorodeKala_Riz>(DBGridControl);
                                        //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                                        foreach (var item in q)
                                        {
                                            item.KalaCode_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                            item.KalaName_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                            item.VahedeKala_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).EpVahedAsliKala.Name;
                                            item.AzAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                                        }

                                        //dbContext.AkVorodeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                        //{
                                        //    // Bind data to control when loading complete
                                        //    gridControl.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                        //xtp_AddVaEdit.PageVisible = true;

                                        //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).Load();
                                        // Bind data to control when loading complete
                                        if (!_FirstSelectAnbar_NextSanad)
                                        {
                                            //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                            akVorodeKala_RizsBindingSource.DataSource = q.Count > 0 ? q.ToList() : null;
                                        }
                                        else
                                        {
                                            //var q4 = dbContext.AkVorodeKala_Rizs.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                            //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                            var q4 = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                            akVorodeKala_RizsBindingSource.DataSource = q4.Count > 0 ? q4.ToList() : null;
                                        }

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
                                    var q = dbContext.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha).ToList();
                                    if (q.Count > 0)
                                    {
                                        cmbNoeSanad.Properties.Items.Clear();
                                        cmbNoeSanad.Properties.Items.Add("برگشت از خرید");
                                        cmbNoeSanad.Properties.Items.Add("حواله فروش");
                                        cmbNoeSanad.Properties.Items.Add("حواله کالای امانی");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از رسید تولید");
                                        cmbNoeSanad.Properties.Items.Add("حواله تولید");
                                        cmbNoeSanad.Properties.Items.Add("حواله هزینه");
                                        cmbNoeSanad.Properties.Items.Add("حواله اموال");
                                        cmbNoeSanad.Properties.Items.Add("کسورات انبار");
                                        cmbNoeSanad.Properties.Items.Add("حواله (جابجایی)");

                                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                        cmbNoeSanad.SelectedIndex = _NoeSanadIndex;
                                        txtSeryalCol_darColAnbarha.Text = _SeryalCol_darColAnbarha.ToString();
                                        txtSeryalJoze_darColAnbarha.Text = _SeryalJoze_darColAnbarha.ToString();
                                        txtSeryalCol_darSelectAnbar.Text = _SeryalCol_darSelectAnbar.ToString();
                                        txtSeryalJoze_darSelectAnbar.Text = _SeryalJoze_darSelectAnbar.ToString();
                                        txtGhateySanadNumber.Text = _GhateySanadNamber != null ? _GhateySanadNamber.ToString() : "";
                                        txtSabetAtefNumber.Text = _SabetAtefNumber.ToString();
                                        txtRozaneSanadNumber.Text = _RozaneSanadNumber.ToString();
                                        txtPaygiriNumber.Text = _PaygiriNumber != null ? _PaygiriNumber.ToString() : "";
                                        txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                        txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                        //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                        //txtNoeSanad.BackColor = Color.Yellow;
                                        HelpClass1.DateTimeMask(txtTarikh);
                                        txtTarikh.Text = _DateTimeSanad;
                                        //chkIsSanadHesabdari.Checked = _IsRiali;
                                        //txtSabetAtefNumber.Text = _SabetAtefNumber;
                                        txtSharhSanad.Text = _SharhSanad;
                                        //lblSanadNamber.BackColor = Color.Yellow;
                                        // _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                        xtpVrodeKala.PageEnabled = xtpKhrojeKala.PageEnabled = false;
                                        xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                        xtpAmaliatAddVEdit.PageVisible = true;
                                        //NoeSanad = NoeSanad + " : نوع حواله " + ": " + XtraTabControl1_1.SelectedTabPage.Text;
                                        //xtpAmaliatAddVEdit.Text = NoeSanad;
                                        xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.Pink;
                                        //lblSeryalCol_darColAnbarha.Text = "ش حواله در کل انبارها";
                                        //lblSeryalCol_darSelectAnbar.Text = "ش حواله در انبار انتخابی";
                                        //lblSeryalJoze_darSelectAnbar.Text = "ش حواله در نوع حواله";
                                        FillCmbHesabMoin();
                                        cmbHesabMoin.EditValue = _MoinId;
                                        cmbHesabTafsili1.EditValue = _Tafsili1Id;
                                        cmbHesabTafsili2.EditValue = _Tafsili2Id;
                                        cmbHesabTafsili3.EditValue = _Tafsili3Id;
                                        //cmbHesabTafsili1.Text = q3.Find(s => s.Id == _Tafsili1Id).Name.ToString();
                                        //cmbHesabTafsili2.Text = q3.Find(s => s.Id == _Tafsili2Id).Name.ToString();
                                        //cmbHesabTafsili3.Text = q3.Find(s => s.Id == _Tafsili3Id).Name.ToString();
                                        //cmbHesabTafsili1.ShowPopup();
                                        //cmbHesabTafsili1.ClosePopup();
                                        //cmbHesabTafsili2.ShowPopup();
                                        //cmbHesabTafsili2.ClosePopup();
                                        //cmbHesabTafsili3.ShowPopup();
                                        //cmbHesabTafsili3.ClosePopup();

                                        //List<AkVorodeKala_Riz> DBGridControl = (List<AkVorodeKala_Riz>)gridControl.DataSource;
                                        //BindingList<AkVorodeKala_Riz> bl = new BindingList<AkVorodeKala_Riz>(DBGridControl);
                                        //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                                        foreach (var item in q)
                                        {
                                            item.KalaCode_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                            item.KalaName_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                            item.VahedeKala_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).EpVahedAsliKala.Name;
                                            item.AzAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                                        }

                                        //dbContext.AkVorodeKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                        //{
                                        //    // Bind data to control when loading complete
                                        //    gridControl.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                        //xtp_AddVaEdit.PageVisible = true;

                                        //dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).Load();
                                        // Bind data to control when loading complete
                                        //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();
                                        if (!_FirstSelectAnbar_NextSanad)
                                        {
                                            //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                            akVorodeKala_RizsBindingSource.DataSource = q.Count > 0 ? q.ToList() : null;
                                        }
                                        else
                                        {
                                            //var q4 = dbContext.AkVorodeKala_Rizs.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                            //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                                            var q4 = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                            akVorodeKala_RizsBindingSource.DataSource = q4.Count > 0 ? q4.ToList() : null;
                                        }
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
                        //if (_FirstSelectAnbar_NextSanad)
                        //{
                        //    _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                        //}
                        //int _Seryal_darSelectAnbar = 0;
                        _NoeSanadIndex = Convert.ToInt32(cmbNoeSanad.SelectedIndex);
                        int _SeryalCol_darColAnbarha = 0;
                        int _SeryalJoze_darColAnbarha = 0;
                        int _SeryalCol_darSelectAnbar = 0;
                        int _SeryalJoze_darSelectAnbar = 0;
                        int? _GhateySanadNamber = null;
                        int _SabetAtefNumber = 0;
                        //int _RozaneSanadNumber = 0;
                        int _RozaneSanadNumber = Convert.ToInt32(txtRozaneSanadNumber.Text);
                        int? _PaygiriNumber = null;
                        if (txtPaygiriNumber.Text != "")
                            _PaygiriNumber = Convert.ToInt32(txtPaygiriNumber.Text);

                        //int _Seryal = Convert.ToInt32(txtSeryal_darSelectNoe.Text);
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
                                        case "xtp_AllVorode":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_MojodiAvalDore":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_ResidKharid":
                                            {
                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        _SeryalCol_darColAnbarha = qp.Count > 0 ? qp.Max(s => s.SeryalCol_darColAnbarha) + 1 : 1;

                                                        var qp1 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        _SeryalJoze_darColAnbarha = qp1.Count > 0 ? qp1.Max(s => s.SeryalJoze_darColAnbarha) + 1 : 1;

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_darSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                            var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                            _SeryalJoze_darSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                        }
                                                       List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "AzAnbarId"));
                                                                var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                                _SeryalCol_darSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                                var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                _SeryalJoze_darSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                            }

                                                            long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _AzAnbarId;
                                                            obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                            obj1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                            obj1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                            obj1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                            obj1.NoeSanadCode = _NoeSanadCode;
                                                            obj1.NoeSanadText = _NoeSanadText;
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            //obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            //obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.HesabMoinId = _HesabMoinId;
                                                            obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj1.HesabTafsili3Id = _HesabTafsili3Id;
                                                            list.Add(obj1);

                                                        }
                                                        db.AkVorodeKala_Rizs.AddRange(list);
                                                        db.SaveChanges();
                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        _SalId = Convert.ToInt32(lblSalId.Text);
                                                        _SeryalCol_darColAnbarha = Convert.ToInt32(txtSeryalCol_darColAnbarha.Text);
                                                        _SeryalJoze_darColAnbarha = Convert.ToInt32(txtSeryalJoze_darColAnbarha.Text);

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _SeryalCol_darSelectAnbar = Convert.ToInt32(txtSeryalCol_darSelectAnbar.Text);
                                                            _SeryalJoze_darSelectAnbar = Convert.ToInt32(txtSeryalJoze_darSelectAnbar.Text);
                                                        }
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        List<AkVorodeKala_Riz> DBGridControl = (List<AkVorodeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        BindingList<AkVorodeKala_Riz> list = new BindingList<AkVorodeKala_Riz>(DBGridControl);

                                                        //BindingList<AkVorodeKala_Riz> list = (BindingList<AkVorodeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        List<AkVorodeKala_Riz> q2 = new List<AkVorodeKala_Riz>();
                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var qq2 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha
                                                            && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha
                                                            && s.SeryalCol_darSelectAnbar == _SeryalCol_darSelectAnbar
                                                            && s.SeryalJoze_darSelectAnbar == _SeryalJoze_darSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AkVorodeKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }
                                                        else
                                                        {
                                                            var qq2 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AkVorodeKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }


                                                        var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "AzAnbarId"));
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                var qp = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();

                                                                var qp1 = q2.FirstOrDefault(s => s.AzAnbarId == _AzAnbarId);
                                                                _SeryalCol_darSelectAnbar = qp1 != null ? qp1.SeryalCol_darSelectAnbar : qp.Count > 0 ? qp.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                                var qp2 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                //var qp3 = q2.FirstOrDefault(s => s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha);
                                                                _SeryalJoze_darSelectAnbar = qp1 != null ? qp1.SeryalJoze_darSelectAnbar : qp2.Count > 0 ? qp2.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                            }

                                                            long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {

                                                                var v1 = q.FirstOrDefault(s => s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha && s.NoeSanadCode == _NoeSanadCode && s.Id == list[i].Id);

                                                                v1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _AzAnbarId;
                                                                v1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                                v1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                                v1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                                v1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                v1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                //v1.Seryal_darSelectNoe = _Seryal;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                v1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                v1.NoeSanadCode = _NoeSanadCode;
                                                                v1.NoeSanadText = _NoeSanadText;
                                                                v1.NoeSanadIndex = _NoeSanadIndex;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                //v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.HesabMoinId = _HesabMoinId;
                                                                v1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                v1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                v1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {

                                                                AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _AzAnbarId;
                                                                obj1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                                obj1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                                obj1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                                obj1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                //obj1.Seryal_darSelectNoe = _Seryal;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                obj1.NoeSanadCode = _NoeSanadCode;
                                                                obj1.NoeSanadText = _NoeSanadText;
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = 0;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                //obj1.RozaneSanadNumber = 1;
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                                db.AkVorodeKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                        var qq1 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha).ToList();
                                                        if (qq1.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1.Count; j++)
                                                            {
                                                                qq1[j].Radif = qq1[j].Radif = j + 1;
                                                            }
                                                            db.SaveChanges();
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
                                    switch (txtNoeSanad1.Text)
                                    {
                                        case "xtp_AllKhoroji":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_BargashtAzKharid":
                                            {
                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        _SeryalCol_darColAnbarha = qp.Count > 0 ? qp.Max(s => s.SeryalCol_darColAnbarha) + 1 : 1;

                                                        var qp1 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        _SeryalJoze_darColAnbarha = qp1.Count > 0 ? qp1.Max(s => s.SeryalJoze_darColAnbarha) + 1 : 1;

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_darSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                            var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                            _SeryalJoze_darSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                        }


                                                        List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit.RowCount; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "AzAnbarId"));
                                                                var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                                _SeryalCol_darSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                                var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                _SeryalJoze_darSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                            }

                                                            long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _AzAnbarId;
                                                            obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                            obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                            obj1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                            obj1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                            obj1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                            obj1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                            obj1.NoeSanadCode = _NoeSanadCode;
                                                            obj1.NoeSanadText = _NoeSanadText;
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            //obj1.RozaneSanadNumber = 1;
                                                            obj1.HesabMoinId = _HesabMoinId;
                                                            obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                            obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                            obj1.HesabTafsili3Id = _HesabTafsili3Id;
                                                            list.Add(obj1);
                                                        }
                                                        db.AkVorodeKala_Rizs.AddRange(list);
                                                        db.SaveChanges();
                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        _SalId = Convert.ToInt32(lblSalId.Text);
                                                        _SeryalCol_darColAnbarha = Convert.ToInt32(txtSeryalCol_darColAnbarha.Text);
                                                        _SeryalJoze_darColAnbarha = Convert.ToInt32(txtSeryalJoze_darColAnbarha.Text);

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _SeryalCol_darSelectAnbar = Convert.ToInt32(txtSeryalCol_darSelectAnbar.Text);
                                                            _SeryalJoze_darSelectAnbar = Convert.ToInt32(txtSeryalJoze_darSelectAnbar.Text);
                                                        }
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        List<AkVorodeKala_Riz> DBGridControl = (List<AkVorodeKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        BindingList<AkVorodeKala_Riz> list = new BindingList<AkVorodeKala_Riz>(DBGridControl);

                                                        List<AkVorodeKala_Riz> q2 = new List<AkVorodeKala_Riz>();
                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var qq2 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha
                                                            && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha
                                                            && s.SeryalCol_darSelectAnbar == _SeryalCol_darSelectAnbar
                                                            && s.SeryalJoze_darSelectAnbar == _SeryalJoze_darSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AkVorodeKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }
                                                        else
                                                        {
                                                            var qq2 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha && s.SeryalJoze_darSelectAnbar == _SeryalJoze_darSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AkVorodeKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }


                                                        var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "AzAnbarId"));
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                var qp = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();

                                                                var qp1 = q2.FirstOrDefault(s => s.AzAnbarId == _AzAnbarId);
                                                                _SeryalCol_darSelectAnbar = qp1 != null ? qp1.SeryalCol_darSelectAnbar : qp.Count > 0 ? qp.Max(s => s.SeryalCol_darSelectAnbar) + 1 : 1;

                                                                var qp2 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                //var qp3 = q2.FirstOrDefault(s => s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha);
                                                                _SeryalJoze_darSelectAnbar = qp1 != null ? qp1.SeryalJoze_darSelectAnbar : qp2.Count > 0 ? qp2.Max(s => s.SeryalJoze_darSelectAnbar) + 1 : 1;
                                                            }

                                                            long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {
                                                                var k1 = q.FirstOrDefault(s => s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha && s.SeryalJoze_darColAnbarha == _SeryalJoze_darColAnbarha && s.NoeSanadCode == _NoeSanadCode && s.Id == list[i].Id);

                                                                k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.BeAnbarId = _AzAnbarId;
                                                                k1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                                k1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                                k1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                                k1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                                k1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                k1.PaygiriNumber = _PaygiriNumber;
                                                                k1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                k1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                k1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                k1.NoeSanadCode = _NoeSanadCode;
                                                                k1.NoeSanadText = _NoeSanadText;
                                                                k1.NoeSanadIndex = _NoeSanadIndex;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                //k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                //k1.RozaneSanadNumber = 1;
                                                                k1.HesabMoinId = _HesabMoinId;
                                                                k1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                k1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                k1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                //long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode"));
                                                                //decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Meghdar"));
                                                                //decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Nerkh"));
                                                                //decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Mablag"));
                                                                //string _Tozihat = gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                                AkVorodeKala_Riz obj1 = new AkVorodeKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _AzAnbarId;
                                                                obj1.SeryalCol_darColAnbarha = _SeryalCol_darColAnbarha;
                                                                obj1.SeryalJoze_darColAnbarha = _SeryalJoze_darColAnbarha;
                                                                obj1.SeryalCol_darSelectAnbar = _SeryalCol_darSelectAnbar;
                                                                obj1.SeryalJoze_darSelectAnbar = _SeryalJoze_darSelectAnbar;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.KalaId = qq.FirstOrDefault(s => s.Code == _Code).Id;
                                                                obj1.VahedeKalaId = qq.FirstOrDefault(s => s.Code == _Code).VahedAsliId;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = _NoeAmaliatCode;
                                                                obj1.NoeSanadCode = _NoeSanadCode;
                                                                obj1.NoeSanadText = _NoeSanadText;
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = 0;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                //obj1.RozaneSanadNumber = 1;
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;

                                                                db.AkVorodeKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }

                                                        }
                                                        var qq1 = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_darColAnbarha == _SeryalCol_darColAnbarha).ToList();
                                                        if (qq1.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1.Count; j++)
                                                            {
                                                                qq1[j].Radif = qq1[j].Radif = j + 1;
                                                            }
                                                            db.SaveChanges();
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
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
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
                xtcAmaliatRozaneh.Enabled = true;
            XtraTabControl1_1_SelectedPageChanged(null, null);
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
                                var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                txtSeryalCol_darColAnbarha.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_darColAnbarha) + 1).ToString() : "1";

                                cmbNoeSanad_SelectedIndexChanged(null, null);
                                //cmbNoeSanad.ReadOnly = true;

                                //if (_FirstSelectAnbar_NextSanad)
                                //{
                                //    _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                                //    var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                //    txtSeryalCol_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_darSelectAnbar) + 1).ToString() : "1";

                                //    var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_darSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                                //}
                                //else
                                //{
                                //    var q = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                                //    txtSeryalCol_darSelectAnbar.Text = "0";
                                //    txtSeryalCol_darSelectAnbar.Visible = lblSeryalCol_darSelectAnbar.Visible = false;
                                //}


                                //var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                //if (q.Count > 0)
                                //{
                                //    txtSeryal_darSelectNoe.Text = (q.Max(s => s.Seryal_darSelectNoe) + 1).ToString();
                                //}
                                //else
                                //    txtSeryal_darSelectNoe.Text = "1";

                                //txtTarikh.Text = DateTime.Now.ToString();
                                //chkIsSanadHesabdari.Checked = true;
                            }
                            else if (txtNoeAmaliat1.Text == "xtpKhrojeKala")
                            {
                                var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                txtSeryalCol_darColAnbarha.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_darColAnbarha) + 1).ToString() : "1";

                                cmbNoeSanad_SelectedIndexChanged(null, null);

                                //if (_FirstSelectAnbar_NextSanad)
                                //{
                                //    _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                                //    var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                //    txtSeryalCol_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_darSelectAnbar) + 1).ToString() : "1";

                                //    var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_darSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                                //}
                                //else
                                //{
                                //    var q = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                                //    txtSeryalCol_darSelectAnbar.Text = "0";
                                //    txtSeryalCol_darSelectAnbar.Visible = lblSeryalCol_darSelectAnbar.Visible = false;
                                //}


                                //var q = db.AkKhorojeKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                //if (q.Count > 0)
                                //{
                                //    txtSeryal_darSelectNoe.Text = (q.Max(s => s.Seryal_darSelectNoe) + 1).ToString();
                                //}
                                //else
                                //    txtSeryal_darSelectNoe.Text = "1";

                                //txtTarikh.Text = DateTime.Now.ToString();
                                //chkIsSanadHesabdari.Checked = true;
                            }

                            // ActiveButtons();
                            // btnCancel.Enabled = true;
                            txtSharhSanad.Text = txtPaygiriNumber.Text = string.Empty;
                            btnDelete1.Enabled = btnEdit1.Enabled = false;
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

        private void FrmAmaliatRozanehAnbarVKala_KeyDown(object sender, KeyEventArgs e)
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
                if (xtcAmaliatRozaneh.SelectedTabPageIndex == 2)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = true;
                }
                //else if (XtraTabControl1_1.SelectedTabPage.Name == "xtp_AllVorode")
                //    btnDelete.Enabled = btnEdit.Enabled = btnCreate.Enabled = false;
                //else if (XtraTabControl1_1.SelectedTabPage.Name == "xtp_AllKhoroji")
                //    btnDelete.Enabled = btnEdit.Enabled = btnCreate.Enabled = false;
                else
                    btnDelete.Enabled = btnEdit.Enabled = true;

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

        private void FrmAmaliatRozanehAnbarVKala_FormClosed(object sender, FormClosedEventArgs e)
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

        private void cmbNoeSanad_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (cmbNoeSanad.SelectedIndex < 0 || cmbNoeSanad.Text == "" || string.IsNullOrEmpty(cmbNoeSanad.Text))
                    {
                        if (En1 == EnumCED.Create)
                        {

                            xtpAmaliatAddVEdit.Text = titelAmaliatAddVEdit + " : نوع سند " + ": " + cmbNoeSanad.Text;
                            XtraMessageBox.Show("لطفاً نوع عملیات را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbNoeSanad.ShowPopup();
                            return;
                        }

                    }
                    else
                    {
                        if (NoeAmaliatTabpageIndex == 0)
                        {
                            switch (cmbNoeSanad.SelectedIndex)
                            {
                                case 0:
                                    _NoeSanadCode = 201;
                                    break;
                                case 1:
                                    _NoeSanadCode = 202;
                                    break;
                                case 2:
                                    _NoeSanadCode = 203;
                                    break;
                                case 3:
                                    _NoeSanadCode = 204;
                                    break;
                                case 4:
                                    _NoeSanadCode = 205;
                                    break;
                                case 5:
                                    _NoeSanadCode = 206;
                                    break;
                                case 6:
                                    _NoeSanadCode = 207;
                                    break;
                                case 7:
                                    _NoeSanadCode = 208;
                                    break;
                                case 8:
                                    _NoeSanadCode = 209;
                                    break;
                                case 9:
                                    _NoeSanadCode = 210;
                                    break;
                            }

                            if (_NoeSanadCode == 210)
                            {
                                lblAzAnbar.Visible = lblBeAnbar.Visible = true;
                                cmbAzAnbar.Visible = cmbBeAnbar.Visible = true;
                                btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = true;

                                lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = false;
                                cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = false;
                                btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = false;

                            }
                            else
                            {
                                lblAzAnbar.Visible = lblBeAnbar.Visible = false;
                                cmbAzAnbar.Visible = cmbBeAnbar.Visible = false;
                                btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = false;

                                lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = true;
                                cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = true;
                                btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = true;

                            }
                            var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();

                            var qp1 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                            txtSeryalJoze_darColAnbarha.Text = qp1.Count > 0 ? (qp1.Max(s => s.SeryalJoze_darColAnbarha) + 1).ToString() : "1";

                            if (_FirstSelectAnbar_NextSanad)
                            {
                                var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                txtSeryalCol_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_darSelectAnbar) + 1).ToString() : "1";

                                var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                txtSeryalJoze_darSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                            }

                        }
                        else if (NoeAmaliatTabpageIndex == 1)
                        {
                            switch (cmbNoeSanad.SelectedIndex)
                            {
                                case 0:
                                    _NoeSanadCode = 301;
                                    break;
                                case 1:
                                    _NoeSanadCode = 302;
                                    break;
                                case 2:
                                    _NoeSanadCode = 303;
                                    break;
                                case 3:
                                    _NoeSanadCode = 304;
                                    break;
                                case 4:
                                    _NoeSanadCode = 305;
                                    break;
                                case 5:
                                    _NoeSanadCode = 306;
                                    break;
                                case 6:
                                    _NoeSanadCode = 307;
                                    break;
                                case 7:
                                    _NoeSanadCode = 308;
                                    break;
                                case 8:
                                    _NoeSanadCode = 309;
                                    break;
                            }


                            if (_NoeSanadCode == 309)
                            {
                                lblAzAnbar.Visible = lblBeAnbar.Visible = true;
                                cmbAzAnbar.Visible = cmbBeAnbar.Visible = true;
                                btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = true;

                                lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = false;
                                cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = false;
                                btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = false;

                            }
                            else
                            {
                                lblAzAnbar.Visible = lblBeAnbar.Visible = false;
                                cmbAzAnbar.Visible = cmbBeAnbar.Visible = false;
                                btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = false;

                                lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = true;
                                cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = true;
                                btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = true;

                            }

                            var qp = db.AkVorodeKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();

                            var qp1 = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                            txtSeryalJoze_darColAnbarha.Text = qp1.Count > 0 ? (qp1.Max(s => s.SeryalJoze_darColAnbarha) + 1).ToString() : "1";

                            if (_FirstSelectAnbar_NextSanad)
                            {
                                var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                txtSeryalCol_darSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_darSelectAnbar) + 1).ToString() : "1";

                                var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                txtSeryalJoze_darSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_darSelectAnbar) + 1).ToString() : "1";
                            }
                        }
                    }

                    _NoeSanadText = cmbNoeSanad.Text;
                    xtpAmaliatAddVEdit.Text = titelAmaliatAddVEdit + " : نوع سند " + ": " + cmbNoeSanad.Text;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbNoeSanad_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create)
            {
                cmbNoeSanad.ShowPopup();
            }
        }


        private void cmbNoeSanad_Leave(object sender, EventArgs e)
        {
            if (cmbNoeSanad.SelectedIndex < 0 || cmbNoeSanad.Text == "" || string.IsNullOrEmpty(cmbNoeSanad.Text))
            {
                if (En1 != EnumCED.Cancel)
                {
                    xtpAmaliatAddVEdit.Text = titelAmaliatAddVEdit + " : نوع سند " + ": " + cmbNoeSanad.Text;
                    XtraMessageBox.Show("لطفاً نوع عملیات را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNoeSanad.ShowPopup();
                    return;

                }
            }

        }

        private void gridView_AllVorode_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_AllVorode.RowCount > 0)
                btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = true;
            else
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;

        }

    }
}
