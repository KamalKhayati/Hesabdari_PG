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
using DBHesabdari_PG.Models.EP.CodingAnbar;

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
        public GridControl gridControl1;
        GridView gridView;
        public GridView gridView1;
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
        int _SeryalCol_BeNoeAmaliat_BeSelectAnbar = 0;
        int _SeryalCol_BaNoeAmaliat_BaSelectAnbar = 0;

        int _SeryalCol_BeNoeAmaliat_BaSelectAnbar = 0;
        int _SeryalCol_BaNoeAmaliat_BeSelectAnbar = 0;

        int _SeryalJoze_BaNoeSanad_BeSelectAnbar = 0;
        int _SeryalJoze_BaNoeSanad_BaSelectAnbar = 0;

        int _HesabMoinId = 0;
        int _HesabTafsili1Id = 0;
        int _HesabTafsili2Id = 0;
        int _HesabTafsili3Id = 0;
        string _SharhSanad = string.Empty;

        int _SalId = 0;
        public int _AzAnbarId = 0;
        public int _BeAnbarId = 0;
        public int _KalaId = 0;
        public int _VahedeKalaId = 0;
        public string _AzAnbarName_NM = string.Empty;
        public string _BeAnbarName_NM = string.Empty;
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
        int _NoeAmaliatTabpageIndex = 0;
        public int _NoeSanadIndex = 0;
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
                    List<AmaliatAnbarVKala_Riz> q = new List<AmaliatAnbarVKala_Riz>();
                    if (_FirstSelectAnbar_NextSanad)
                    {
                        _AzAnbarId = _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        if (_NoeAmaliatTabpageName == "xtpVrodeKala")
                        {
                            var list = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                        else if (_NoeAmaliatTabpageName == "xtpKhrojeKala")
                        {
                            //var list = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).OrderBy(s => s.Seryal).ToList();
                            var list = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                    }
                    else
                    {
                        if (_NoeAmaliatTabpageName == "xtpVrodeKala")
                        {
                            var list = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            q = list;
                        }
                        else if (_NoeAmaliatTabpageName == "xtpKhrojeKala")
                        {
                            var list = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
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
                                            gridControl.DataSource = q.Count > 0 ? q.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar).ToList() : null;
                                            break;
                                        }
                                    case "xtp_ResidKharid":
                                        {
                                            var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                            gridControl.DataSource = qq.Count > 0 ? qq.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList() : null;
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
                                    case "xtp_ResidJabejaee":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidTabdil":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_ResidSayer":
                                        {
                                            goto case "xtp_ResidKharid";
                                        }
                                    case "xtp_MojodiAvalDore":
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
                                            gridControl.DataSource = q.Count > 0 ? q.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar).ToList() : null;
                                            break;
                                        }
                                    case "xtp_BargashtAzKharid":
                                        {
                                            var qq4 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                            gridControl.DataSource = qq4.Count > 0 ? qq4.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList() : null;
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
                                    case "xtp_HavaleJabejaee":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleTabdil":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
                                    case "xtp_HavaleSayer":
                                        {
                                            goto case "xtp_BargashtAzKharid";
                                        }
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

        public void FillCmbAnbarName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0) epListAnbarhasBindingSource2.DataSource = q1; else epListAnbarhasBindingSource2.Clear();

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

        public void FillCmbAzAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (_NoeSanadIndex == 8)
                    {
                        if (_NoeAmaliatTabpageIndex == 0)
                        {
                            if (_FirstSelectAnbar_NextSanad)
                            {
                                _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId && s.Id != _BeAnbarId).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();
                            }
                            else
                            {
                                var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();
                            }
                        }
                        else if (_NoeAmaliatTabpageIndex == 1)
                        {
                            //_AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                            var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();
                        }
                    }
                    else if (_NoeSanadIndex == 9)
                    {
                        var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();
                    }
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

        public void FillCmbBeAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                    List<EpListAnbarha> lidt1 = new List<EpListAnbarha>();
                    var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    if (_NoeSanadIndex == 8)
                        lidt1 = q.Where(s => s.Id != _AzAnbarId).OrderBy(s => s.Code).ToList();
                    else
                        lidt1 = q.OrderBy(s => s.Code).ToList();

                    if (lidt1.Count > 0)
                        epListAnbarhasBindingSource1.DataSource = lidt1;
                    else
                        epListAnbarhasBindingSource1.Clear();

                    //epListAnbarhasBindingSource1.DataSource = q1.Count > 0 ? q1 : null;
                    //var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                    //foreach (var item in q1)
                    //{
                    //    var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                    //    if (qq.Count > 0)
                    //    {
                    //        string _KalaId = String.Empty;
                    //        foreach (var item2 in qq)
                    //        {
                    //            _KalaId += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                    //        }
                    //        item.TabagheKalaIdName_NM = _KalaId;
                    //    }
                    //}


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
            else if (Convert.ToInt32(cmbAzAnbar.EditValue) == 0 && (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9))
            {
                XtraMessageBox.Show("لطفاً انبار مبداء را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAzAnbar.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbBeAnbar.EditValue) == 0 && (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9))
            {
                XtraMessageBox.Show("لطفاً انبار مقصد را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBeAnbar.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0 && cmbNoeSanad.SelectedIndex != 8 && cmbNoeSanad.SelectedIndex != 9)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabMoin.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 && cmbHesabTafsili1.ReadOnly == false && cmbNoeSanad.SelectedIndex != 8 && cmbNoeSanad.SelectedIndex != 9)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili1.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili1.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 && cmbHesabTafsili2.ReadOnly == false && cmbNoeSanad.SelectedIndex != 8 && cmbNoeSanad.SelectedIndex != 9)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili2.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili2.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 && cmbHesabTafsili3.ReadOnly == false && cmbNoeSanad.SelectedIndex != 8 && cmbNoeSanad.SelectedIndex != 9)
            {
                XtraMessageBox.Show("لطفاً " + lblHesabTafsili3.Text + " را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili3.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text) && _FirstSelectAnbar_NextSanad == false)
            {
                XtraMessageBox.Show("فیلد " + lblSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text) && _FirstSelectAnbar_NextSanad == false)
            {
                XtraMessageBox.Show("فیلد " + lblSeryalJoze_BaNoeSanad_BeSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text) && _FirstSelectAnbar_NextSanad == true)
            {
                XtraMessageBox.Show("فیلد " + lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text) && _FirstSelectAnbar_NextSanad == true)
            {
                XtraMessageBox.Show("فیلد " + lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Text + " خالی است ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRozaneSanadNumber.Text))
            {
                XtraMessageBox.Show("فیلد " + lblRozaneSanadNumber + " خالی است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRozaneSanadNumber.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikhSanad.Text))
            {
                XtraMessageBox.Show("لطفاً تاریخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarikhSanad.Focus();
                return false;
            }
            else if (gridView_AmaliatAddVaEdit2.RowCount == 0 && (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9))
            {
                XtraMessageBox.Show("در انبار مقصد اطلاعاتی برای ذخیره وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnInsert2.Focus();
                return false;
            }
            else if (gridView_AmaliatAddVaEdit1.RowCount == 0)
            {
                XtraMessageBox.Show("اطلاعاتی برای ذخیره وجود ندارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnInsert1.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (sender == btnDelete1)
            {
                gridControl1 = gridControl_AmaliatAddVaEdit1;
                gridView1 = gridView_AmaliatAddVaEdit1;
            }
            else if (sender == btnDelete2)
            {
                gridControl1 = gridControl_AmaliatAddVaEdit2;
                gridView1 = gridView_AmaliatAddVaEdit2;
            }


            if (gridView1.RowCount > 0)
            {
                if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //gridView_AmaliatAddVaEdit.DeleteSelectedRows();
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    if (_NoeSanadIndex == 8)
                        amaliatAnbarVKala_RizsBindingSource2.DataSource = amaliatAnbarVKala_RizsBindingSource1.DataSource;
                }
            }
        }

        private void btnInsert1_Click(object sender, EventArgs e)
        {

            En2 = EnumCED.Create;
            FrmAmaliatSelectKala fm = new FrmAmaliatSelectKala(this);
            if (sender == btnInsert1)
            {
                fm.gridControl = gridControl1 = gridControl_AmaliatAddVaEdit1;
                fm.gridView = gridView1 = gridView_AmaliatAddVaEdit1;
                fm.btnInsert = btnInsert1;
            }
            else if (sender == btnInsert2)
            {
                fm.gridControl = gridControl1 = gridControl_AmaliatAddVaEdit2;
                fm.gridView = gridView1 = gridView_AmaliatAddVaEdit2;
                fm.btnInsert = btnInsert2;
            }

            if (_FirstSelectAnbar_NextSanad)
            {
                if (_NoeSanadIndex == 8 || _NoeSanadIndex == 9)
                {
                    fm.AzAnbarId = _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                    fm.BeAnbarId = _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
                }
                else
                {
                    fm.AzAnbarId = _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    fm.BeAnbarId = _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                }
            }
            else
            {
                if (_NoeSanadIndex == 8 || _NoeSanadIndex == 9)
                {
                    fm.AzAnbarId = _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                    fm.BeAnbarId = _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
                }
            }

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


            //BindingList<AmaliatAnbarVKala_Riz> List1 = new BindingList<AmaliatAnbarVKala_Riz>();
            //List1[0].Mablag = 11;
            //(gridControl_AmaliatAddVaEdit.DataSource as BindingList<List1>).AddNew();


            //List<AmaliatAnbarVKala_Riz> list = new List<AmaliatAnbarVKala_Riz>()
            //          {
            //              new AmaliatAnbarVKala_Riz { Meghdar = 11, },
            //              new AmaliatAnbarVKala_Riz { Meghdar = 12, },
            //          };
            //BindingList<AmaliatAnbarVKala_Riz> bindingList = new BindingList<AmaliatAnbarVKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

            //List<AmaliatAnbarVKala_Riz> list = new List<AmaliatAnbarVKala_Riz>()
            //{
            //    new AmaliatAnbarVKala_Riz(){Meghdar = 13,Nerkh = 14,Mablag = 15,}
            //};
            //BindingList<AmaliatAnbarVKala_Riz> bindingList = new BindingList<AmaliatAnbarVKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

        }

        public void gridView_AmaliatAddVaEdit1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //int a = gridView1.RowCount - 1;
            gridView1.SetRowCellValue(e.RowHandle, "AzAnbarId", _AzAnbarId);
            gridView1.SetRowCellValue(e.RowHandle, "BeAnbarId", _BeAnbarId);
            gridView1.SetRowCellValue(e.RowHandle, "KalaId", _KalaId);
            gridView1.SetRowCellValue(e.RowHandle, "VahedeKalaId", _VahedeKalaId);
            gridView1.SetRowCellValue(e.RowHandle, "KalaCode_NM", _KalaCode_NM);
            gridView1.SetRowCellValue(e.RowHandle, "KalaName_NM", _KalaName_NM);
            gridView1.SetRowCellValue(e.RowHandle, "VahedeKala_NM", _VahedeKala_NM);
            gridView1.SetRowCellValue(e.RowHandle, "AzAnbarName_NM", _AzAnbarName_NM);
            gridView1.SetRowCellValue(e.RowHandle, "BeAnbarName_NM", _BeAnbarName_NM);
            gridView1.SetRowCellValue(e.RowHandle, "Meghdar", _Meghdar);
            gridView1.SetRowCellValue(e.RowHandle, "Nerkh", _Nerkh);
            gridView1.SetRowCellValue(e.RowHandle, "Mablag", _Mablag);
            gridView1.SetRowCellValue(e.RowHandle, "Tozihat", _Tozihat);

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
                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                        if (_FirstSelectAnbar_NextSanad)
                        {
                            panelControl_NameAnbar.Enabled = false;
                            txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = "0";

                            if (_NoeAmaliatTabpageIndex == 0)
                            {
                                _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                if (_BeAnbarId == 0)
                                {
                                    XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cmbNameAnbar.ShowPopup();
                                    return;
                                }
                                var qp2 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.BeAnbarId == _BeAnbarId).ToList();
                                txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = qp2.Count > 0 ? (qp2.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";

                            }
                            else if (_NoeAmaliatTabpageIndex == 1)
                            {
                                _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                if (_AzAnbarId == 0)
                                {
                                    XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cmbNameAnbar.ShowPopup();
                                    return;
                                }
                                var qp2 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.AzAnbarId == _AzAnbarId).ToList();
                                txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = qp2.Count > 0 ? (qp2.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";

                            }

                        }
                        else
                        {
                            txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = "0";
                            //txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = false;
                            //lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = false;


                            var qp2 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                            txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = qp2.Count > 0 ? (qp2.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1).ToString() : "1";

                            //var qp3 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.AzAnbarId == _AzAnbarId).ToList();
                            //txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = qp2.Count > 0 ? (qp2.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1).ToString() : "1";

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
                                    cmbNoeSanad.Properties.Items.Add("رسید خرید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از فروش");
                                    cmbNoeSanad.Properties.Items.Add("رسید کالای امانی");
                                    cmbNoeSanad.Properties.Items.Add("رسید تولید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله تولید");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله هزینه");
                                    cmbNoeSanad.Properties.Items.Add("برگشت از حواله اموال");
                                    cmbNoeSanad.Properties.Items.Add("اضافات انبار");
                                    if (_FirstSelectAnbar_NextSanad)
                                        cmbNoeSanad.Properties.Items.Add("رسید (جابجایی)");
                                    else
                                        cmbNoeSanad.Properties.Items.Add("جابجایی کالا");
                                    cmbNoeSanad.Properties.Items.Add("رسید تبدیل");
                                    cmbNoeSanad.Properties.Items.Add("رسید سایر");
                                    cmbNoeSanad.Properties.Items.Add("موجودی اول دوره");


                                    //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                                    //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                    //txtNoeSanad.BackColor = Color.LightGreen;
                                    //lblSanadNamber.BackColor = Color.LightGreen;
                                    XtraTabControl1_1 = xtc_VorodeKala;
                                    //txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                    //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                    xtpAmaliatAddVEdit.PageVisible = true;
                                    xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                                    HelpClass1.DateTimeMask(txtTarikhSanad);
                                    HelpClass1.DateTimeMask(txtPaygiriTarikh);
                                    txtTarikhSanad.Text = DateTime.Now.ToString();
                                    //chkIsSanadHesabdari.Checked = true;
                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_AllVorode":
                                            {
                                                if (_FirstSelectAnbar_NextSanad)
                                                {
                                                    cmbBeAnbar.EditValue = _BeAnbarId;
                                                    cmbBeAnbar.ReadOnly = true;
                                                }

                                                goto case "xtp_ResidKharid";
                                            }
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
                                        case "xtp_ResidJabejaee":
                                            {
                                                if (_FirstSelectAnbar_NextSanad)
                                                {
                                                    cmbBeAnbar.EditValue = _BeAnbarId;
                                                    cmbBeAnbar.ReadOnly = true;
                                                }
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_ResidTabdil":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_ResidSayer":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_MojodiAvalDore":
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
                                    //dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                                    //{
                                    //    // Bind data to control when loading complete
                                    //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                    //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                                    dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).Load();
                                    // Bind data to control when loading complete
                                    amaliatAnbarVKala_RizsBindingSource1.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();


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
                                    if (_FirstSelectAnbar_NextSanad)
                                        cmbNoeSanad.Properties.Items.Add("حواله (جابجایی)");
                                    else
                                        cmbNoeSanad.Properties.Items.Add("جابجایی کالا");
                                    cmbNoeSanad.Properties.Items.Add("حواله تبدیل");
                                    cmbNoeSanad.Properties.Items.Add("حواله سایر");

                                    //var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                    //txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1).ToString() : "1";

                                    XtraTabControl1_1 = xtc_KhorojeKala;
                                    //_IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                    //NoeSanadTabpageName = XtraTabControl1_1.SelectedTabPage.Name;
                                    //txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                    //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                    //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                    //txtNoeSanad.BackColor = Color.LightGreen;
                                    //lblSanadNamber.BackColor = Color.LightGreen;
                                    xtpAmaliatAddVEdit.PageVisible = true;
                                    xtpAmaliatAddVEdit.Appearance.Header.BackColor = Color.LightGreen;
                                    //xtpAmaliatAddVEdit.Text = "عملیات ایجاد";
                                    HelpClass1.DateTimeMask(txtTarikhSanad);
                                    txtTarikhSanad.Text = DateTime.Now.ToString();
                                    //chkIsSanadHesabdari.Checked = true;


                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_AllKhoroji":
                                            {
                                                if (_FirstSelectAnbar_NextSanad)
                                                {
                                                    cmbAzAnbar.EditValue = _AzAnbarId;
                                                    cmbAzAnbar.ReadOnly = true;
                                                }

                                                goto case "xtp_BargashtAzKharid";
                                            }
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
                                        case "xtp_HavaleJabejaee":
                                            {
                                                if (_FirstSelectAnbar_NextSanad)
                                                {
                                                    cmbAzAnbar.EditValue = _AzAnbarId;
                                                    cmbAzAnbar.ReadOnly = true;
                                                }

                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleTabdil":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }
                                        case "xtp_HavaleSayer":
                                            {
                                                goto case "xtp_BargashtAzKharid";
                                            }

                                        default:
                                            break;
                                    }
                                    // _TabPageCount = xtcAmaliatRozaneh.TabPages.Count;
                                    xtcAmaliatRozaneh.SelectedTabPageIndex = 2;
                                    //lblSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = "ش حواله در کل انبارها";
                                    //lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = "ش حواله در انبار انتخابی";
                                    //lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = "ش حواله در نوع انتخابی";


                                    dbContext = new MyContext();
                                    //dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                                    //{
                                    //    // Bind data to control when loading complete
                                    //    akVorodeKala_RizsBindingSource.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                    //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                                    dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).Load();
                                    // Bind data to control when loading complete
                                    amaliatAnbarVKala_RizsBindingSource1.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();


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

        public bool _FirstSelectAnbar_NextSanad = false;
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
                FillCmbAnbarName();
                gridView.Columns["SeryalCol_BaNoeAmaliat_BeSelectAnbar"].Visible = false;
                gridView.Columns["SeryalJoze_BaNoeSanad_BeSelectAnbar"].Visible = false;
                lblSeryalCol_BaNoeAmaliat_BeSelectAnbar.Visible = txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Visible = false;
                lblSeryalJoze_BaNoeSanad_BeSelectAnbar.Visible = txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Visible = false;
                textEdit1.Focus();
            }
            else
            {
                panelControl_NameAnbar.Enabled = false;
                panelControl_NameAnbar.Visible = false;
                panelControl_NameAnbar.Width = 0;
                xtcAmaliatRozaneh.Enabled = true;
                gridView.Columns["SeryalCol_BaNoeAmaliat_BaSelectAnbar"].Visible = false;
                gridView.Columns["SeryalJoze_BaNoeSanad_BaSelectAnbar"].Visible = false;
                lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = false;
                lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = false;
                xtc_VorodeKala.TabPages[9].Text = "جابجایی کالا";
                xtc_KhorojeKala.TabPages[9].Text = "جابجایی کالا";
                btnCreate.Focus();
            }

            panelControl1_2.Width = 0;
            //panelControl1_2.Height = 364;

        }

        private void xtcAmaliatRozaneh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (En1 == EnumCED.Cancel)
            {
                XtraTabControl1_1 = new XtraTabControl();
                if (xtcAmaliatRozaneh.SelectedTabPage.Name == "xtpVrodeKala")
                {
                    _NoeAmaliatTabpageIndex = 0;
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
                    _NoeAmaliatTabpageIndex = 1;
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
                gridControl = new GridControl();
                gridView = new GridView();
                objGridControl = new GridControl();

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
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKharid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 1;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidKharid_Riz;
                        //gridView = gridView_ResidKharid_Riz;
                        _NoeSanadCode = 201;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzFroosh")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 2;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzFroosh;
                        //gridView = gridView_BargashtAzFroosh;
                        _NoeSanadCode = 202;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidKalaAmani")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 3;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidKalaAmani;
                        //gridView = gridView_ResidKalaAmani;
                        _NoeSanadCode = 203;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidTolid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 4;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidTolid;
                        //gridView = gridView_ResidTolid;
                        _NoeSanadCode = 204;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleTolid")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 5;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleTolid;
                        // gridView = gridView_BargashtAzHavaleTolid;
                        _NoeSanadCode = 205;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleHazine")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 6;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleHazine;
                        //gridView = gridView_BargashtAzHavaleHazine;
                        _NoeSanadCode = 206;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_BargashtAzHavaleAmval")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 7;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_BargashtAzHavaleAmval;
                        //gridView = gridView_BargashtAzHavaleAmval;
                        _NoeSanadCode = 207;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_EzafateAnbar")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 8;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_EzafateAnbar;
                        //gridView = gridView_EzafateAnbar;
                        _NoeSanadCode = 208;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidJabejaee")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 9;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_ResidJabejaee;
                        //gridView = gridView_ResidJabejaee;
                        _NoeSanadCode = 209;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidTabdil")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 10;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_MojodiAvalDore;
                        //gridView = gridView_MojodiAvalDore;
                        _NoeSanadCode = 210;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_ResidSayer")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 11;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_MojodiAvalDore;
                        //gridView = gridView_MojodiAvalDore;
                        _NoeSanadCode = 211;
                    }
                    else if (xtc_VorodeKala.SelectedTabPage.Name == "xtp_MojodiAvalDore")
                    {
                        NoeSanadTabpageIndex_VorodeKala = 12;
                        _NoeSanadTabpageName = xtc_VorodeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_VorodeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_MojodiAvalDore;
                        //gridView = gridView_MojodiAvalDore;
                        _NoeSanadCode = 212;
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
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleTabdil")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 10;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleJabeJaee;
                        //gridView = gridView_HavaleJabeJaee;
                        _NoeSanadCode = 310;
                    }
                    else if (xtc_KhorojeKala.SelectedTabPage.Name == "xtp_HavaleSayer")
                    {
                        NoeSanadTabpageIndex_KhorojeKala = 11;
                        _NoeSanadTabpageName = xtc_KhorojeKala.SelectedTabPage.Name;
                        //NoeSanadText = xtc_KhorojeKala.SelectedTabPage.Text;
                        //gridControl = gridControl_HavaleJabeJaee;
                        //gridView = gridView_HavaleJabeJaee;
                        _NoeSanadCode = 311;
                    }


                }

                gridControl = gridControl_KolAmaliat;
                gridView = gridView_KolAmaliat;
                objGridControl = gridControl;

                if (_NoeSanadTabpageName == "xtp_ResidJabejaee" || _NoeSanadTabpageName == "xtp_HavaleJabejaee")
                {
                    gridView.Columns["EpAllHesabTafsili1.Code"].Visible = false;
                    gridView.Columns["EpAllHesabTafsili1.Name"].Visible = false;
                    gridView.Columns["FactorNamber"].Visible = false;
                    gridView.Columns["EpHesabMoin1.Code"].Visible = false;
                    gridView.Columns["EpHesabMoin1.Name"].Visible = false;
                    //gridView.Columns["EpListAnbarha1.Name"].Caption = "از انبار";
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
                    gridView.Columns["SeryalCol_BeNoeAmaliat_BeSelectAnbar"].VisibleIndex = 23;
                    gridView.Columns["Id"].VisibleIndex = 24;
                    gridView.Columns["Tozihat"].VisibleIndex = 25;
                    gridView.Columns["SharhSanad"].VisibleIndex = 26;

                }
                else
                {
                    gridView.Columns["EpAllHesabTafsili1.Code"].Visible = true;
                    gridView.Columns["EpAllHesabTafsili1.Name"].Visible = true;
                    gridView.Columns["FactorNamber"].Visible = true;
                    gridView.Columns["EpHesabMoin1.Code"].Visible = true;
                    gridView.Columns["EpHesabMoin1.Name"].Visible = true;
                    //gridView.Columns["EpListAnbarha1.Name"].Caption = "نام انبار";

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

                    if (_NoeAmaliatTabpageIndex == 0)
                    {
                        gridView.Columns["EpListAnbarha1.Name"].Visible = false;
                        gridView.Columns["EpListAnbarha2.Name"].VisibleIndex = 23;

                    }
                    else
                    {
                        gridView.Columns["EpListAnbarha2.Name"].Visible = false;
                        gridView.Columns["EpListAnbarha1.Name"].VisibleIndex = 23;

                    }

                    gridView.Columns["RozaneSanadNumber"].VisibleIndex = 24;
                    gridView.Columns["GhateySanadNamber"].VisibleIndex = 25;
                    gridView.Columns["PaygiriNumber"].VisibleIndex = 26;
                    gridView.Columns["SeryalCol_BeNoeAmaliat_BeSelectAnbar"].VisibleIndex = 27;
                    gridView.Columns["Id"].VisibleIndex = 28;
                    gridView.Columns["Tozihat"].VisibleIndex = 29;
                    gridView.Columns["SharhSanad"].VisibleIndex = 30;


                }



                if (_FirstSelectAnbar_NextSanad)
                {
                    if (XtraTabControl1_1.SelectedTabPageIndex == 0)
                        gridView.Columns["SeryalCol_BaNoeAmaliat_BaSelectAnbar"].GroupIndex = 0;
                    else
                        gridView.Columns["SeryalJoze_BaNoeSanad_BaSelectAnbar"].GroupIndex = 0;
                }
                else
                {
                    if (XtraTabControl1_1.SelectedTabPageIndex == 0)
                        gridView.Columns["SeryalCol_BaNoeAmaliat_BeSelectAnbar"].GroupIndex = 0;
                    else
                        gridView.Columns["SeryalJoze_BaNoeSanad_BeSelectAnbar"].GroupIndex = 0;
                }

                objXtraTabPage.Controls.Add(objGridControl);

                btnDelete.Enabled = btnEdit.Enabled = false;
                btnDisplyList_Click(null, null);

            }
        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillCmbAnbarName();
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

                    if (Convert.ToInt32(cmbHesabMoin.EditValue) > 0)
                    {
                        btnInsert1.Enabled = true;
                    }
                    else
                    {
                        btnInsert1.Enabled = false;
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
            cmbHesabMoin.EditValue = cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = 0;
            //cmbHesabMoin.Properties.DataSource = cmbHesabTafsili1.Properties.DataSource = cmbHesabTafsili2.Properties.DataSource = cmbHesabTafsili3.Properties.DataSource = null;
            cmbAzAnbar.EditValue = cmbBeAnbar.EditValue = 0;
            //cmbAzAnbar.Properties.DataSource = cmbBeAnbar.Properties.DataSource = null;
            cmbNoeSanad.ReadOnly = cmbAzAnbar.ReadOnly = cmbBeAnbar.ReadOnly = false;
            txtSharhSanad.Text = txtTarikhSanad.Text = txtPaygiriNumber.Text = txtPaygiriTarikh.Text = string.Empty;
            //btnDelete1.Enabled = btnEdit1.Enabled = false;

            xtcAmaliatRozaneh.SelectedTabPageIndex = _NoeAmaliatTabpageIndex;
            if (_NoeAmaliatTabpageIndex == 0)
                XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex_VorodeKala;
            else
                XtraTabControl1_1.SelectedTabPageIndex = NoeSanadTabpageIndex_KhorojeKala;

            // if (NoeAmaliatTabpageIndex == 0 && NoeSanadTabpageIndex == 0)
            // XtraTabControl1_1_SelectedPageChanged(null, null);

            xtpAmaliatAddVEdit.PageVisible = false;
            panelControl_NameAnbar.Enabled = true;

            amaliatAnbarVKala_RizsBindingSource1.Clear();
            amaliatAnbarVKala_RizsBindingSource2.Clear();
            //gridControl_AmaliatAddVaEdit.DataBindings.Clear();
            //gridControl_AmaliatAddVaEdit.DataSource = null;

            ActiveButtons();

            lblAzAnbar.Visible = lblBeAnbar.Visible = false;
            cmbAzAnbar.Visible = cmbBeAnbar.Visible = false;
            btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = false;

            lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = true;
            cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = true;
            btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = true;

            panelControl1_2.Width = 0;
            panelControl1_2.Height = 0;
            panelControl_AzAnbar.Width = 0;
            panelControl_AzAnbar.Height = 0;
            panelControl_BeAnbar.Width = 0;
            panelControl_BeAnbar.Height = 0;
            lblAzAnbar1.Text = "از انبار : " + "مشخص نشده";
            lblBeAnbar1.Text = "به انبار : " + "مشخص نشده";
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
            //gridControl1 = new GridControl();
            //gridView1 = new GridView();
            En2 = EnumCED.Edit;
            FrmAmaliatSelectKala fm = new FrmAmaliatSelectKala(this);
            if (sender == btnEdit1)
            {
                fm.gridControl = gridControl1 = gridControl_AmaliatAddVaEdit1;
                fm.gridView = gridView1 = gridView_AmaliatAddVaEdit1;
                fm.btnEdit = btnEdit1;
            }
            else if (sender == btnEdit2)
            {
                fm.gridControl = gridControl1 = gridControl_AmaliatAddVaEdit2;
                fm.gridView = gridView1 = gridView_AmaliatAddVaEdit2;
                fm.btnEdit = btnEdit2;
            }

            if (gridView1.RowCount > 0)
            {
                _AzAnbarId = fm.AzAnbarId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AzAnbarId"));
                _BeAnbarId = fm.BeAnbarId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BeAnbarId"));
                _KalaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("KalaId"));
                _VahedeKalaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VahedeKalaId"));
                //_KalaCode_NM = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaCode");
                //_KalaName_NM = gridView_AmaliatAddVaEdit.GetFocusedRowCellDisplayText("KalaName");
                _Meghdar = gridView1.GetFocusedRowCellDisplayText("Meghdar");
                _Nerkh = gridView1.GetFocusedRowCellDisplayText("Nerkh");
                _Mablag = gridView1.GetFocusedRowCellDisplayText("Mablag");
                _Tozihat = gridView1.GetFocusedRowCellDisplayText("Tozihat");
                _RowHandle = gridView1.FocusedRowHandle;

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
                    try
                    {
                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BeSelectAnbar").ToString());
                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BeSelectAnbar").ToString());
                        _SeryalCol_BaNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BaSelectAnbar").ToString());
                        _SeryalJoze_BaNoeSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BaSelectAnbar").ToString());
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
                                var q = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList();
                                if (q.Count > 0)
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        var q1 = q.Where(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar == _SeryalCol_BaNoeAmaliat_BaSelectAnbar && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _SeryalJoze_BaNoeSanad_BaSelectAnbar && s.AzAnbarId == _AzAnbarId).ToList();
                                        db.AmaliatAnbarVKala_Rizs.RemoveRange(q1);
                                    }
                                    else
                                        db.AmaliatAnbarVKala_Rizs.RemoveRange(q);
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
                        int _SeryalCol_BaNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BeSelectAnbar").ToString());

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
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                        // btnSaveAndNext.Enabled = false;
                        _AzAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("AzAnbarId"));
                        _BeAnbarId = Convert.ToInt32(gridView.GetFocusedRowCellValue("BeAnbarId"));
                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar").ToString());

                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BeSelectAnbar").ToString());
                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BeSelectAnbar").ToString());

                        if (_FirstSelectAnbar_NextSanad)
                        {
                            panelControl_NameAnbar.Enabled = false;
                            txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = "0";
                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BaSelectAnbar").ToString());
                            _SeryalJoze_BaNoeSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BaSelectAnbar").ToString());
                        }
                        else
                        {
                            txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = "0";
                            //txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = false;
                            //lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Visible = false;
                        }

                        _NoeSanadIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeSanadIndex"));
                        _NoeSanadCode = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeSanadCode").ToString());
                        int? _GhateySanadNamber = null;
                        if (gridView.GetFocusedRowCellValue("GhateySanadNamber") != null)
                            _GhateySanadNamber = Convert.ToInt32(gridView.GetFocusedRowCellValue("GhateySanadNamber").ToString());
                        int _SabetAtefNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("SabetAtefNumber").ToString());
                        int _RozaneSanadNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("RozaneSanadNumber").ToString());
                        int? _PaygiriNumber = null;
                        if (gridView.GetFocusedRowCellValue("PaygiriNumber") != null)
                            _PaygiriNumber = Convert.ToInt32(gridView.GetFocusedRowCellValue("PaygiriNumber").ToString());
                        string _DateTimePaygiri = string.Empty;
                        if (gridView.GetFocusedRowCellValue("DateTimePaygiri") != null)
                            _DateTimePaygiri = Convert.ToDateTime(gridView.GetFocusedRowCellValue("DateTimePaygiri")).ToString();
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

                        var q2 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                        var q3 = dbContext.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                        switch (_NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        cmbBeAnbar.EditValue = _BeAnbarId;
                                        cmbBeAnbar.ReadOnly = true;
                                    }

                                    var q1 = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                    var q = q1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar).ToList();
                                    if (q.Count > 0)
                                    {
                                        cmbNoeSanad.Properties.Items.Clear();
                                        cmbNoeSanad.Properties.Items.Add("رسید خرید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از فروش");
                                        cmbNoeSanad.Properties.Items.Add("رسید کالای امانی");
                                        cmbNoeSanad.Properties.Items.Add("رسید تولید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله تولید");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله هزینه");
                                        cmbNoeSanad.Properties.Items.Add("برگشت از حواله اموال");
                                        cmbNoeSanad.Properties.Items.Add("اضافات انبار");
                                        if (_FirstSelectAnbar_NextSanad)
                                            cmbNoeSanad.Properties.Items.Add("رسید (جابجایی)");
                                        else
                                            cmbNoeSanad.Properties.Items.Add("جابجایی کالا");
                                        cmbNoeSanad.Properties.Items.Add("رسید تبدیل");
                                        cmbNoeSanad.Properties.Items.Add("رسید سایر");
                                        cmbNoeSanad.Properties.Items.Add("موجودی اول دوره");

                                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                        cmbNoeSanad.SelectedIndex = _NoeSanadIndex;
                                        txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = _SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                        txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = _SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                        txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = _SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                        txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = _SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                        txtGhateySanadNumber.Text = _GhateySanadNamber != null ? _GhateySanadNamber.ToString() : "";
                                        txtSabetAtefNumber.Text = _SabetAtefNumber.ToString();
                                        txtRozaneSanadNumber.Text = _RozaneSanadNumber.ToString();
                                        txtPaygiriNumber.Text = _PaygiriNumber != null ? _PaygiriNumber.ToString() : "";
                                        //txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                        //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                        //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                        //txtNoeSanad.BackColor = Color.Yellow;
                                        HelpClass1.DateTimeMask(txtPaygiriTarikh);
                                        txtPaygiriTarikh.Text = _DateTimePaygiri;
                                        HelpClass1.DateTimeMask(txtTarikhSanad);
                                        txtTarikhSanad.Text = _DateTimeSanad;
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
                                        //lblSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = "ش رسید در کل انبارها";
                                        //lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = "ش رسید در انبار انتخابی";
                                        //lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = "ش رسید در نوع رسید";
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

                                        //List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)gridControl.DataSource;
                                        //BindingList<AmaliatAnbarVKala_Riz> bl = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);
                                        //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                                        foreach (var item in q1)
                                        {
                                            item.KalaCode_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                            item.KalaName_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                            item.VahedeKala_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).EpVahedAsliKala.Name;
                                            item.AzAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                                            item.BeAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.BeAnbarId).Name;
                                        }

                                        //dbContext.AmaliatAnbarVKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                        //{
                                        //    // Bind data to control when loading complete
                                        //    gridControl.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                        //xtp_AddVaEdit.PageVisible = true;

                                        //dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).Load();
                                        // Bind data to control when loading complete

                                        if (_NoeSanadIndex == 8 || _NoeSanadIndex == 9)
                                        {
                                            cmbAzAnbar.EditValue = _AzAnbarId;
                                            cmbBeAnbar.EditValue = _BeAnbarId;
                                            amaliatAnbarVKala_RizsBindingSource1.DataSource = q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == 3).ToList().Count > 0 ? q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == 3).ToList() : null;
                                            amaliatAnbarVKala_RizsBindingSource2.DataSource = q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == 2).ToList().Count > 0 ? q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == 2).ToList() : null;
                                        }
                                        else
                                        {
                                            if (!_FirstSelectAnbar_NextSanad)
                                            {
                                                //akVorodeKala_RizsBindingSource.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                                amaliatAnbarVKala_RizsBindingSource1.DataSource = q.Count > 0 ? q.ToList() : null;
                                            }
                                            else
                                            {
                                                var q4 = q.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                amaliatAnbarVKala_RizsBindingSource1.DataSource = q4.Count > 0 ? q4.ToList() : null;
                                            }
                                        }


                                        txtTarikhSanad.Focus();

                                    }


                                    //for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                                    //{
                                    //    if (XtraTabControl1_1.TabPages[i].Name != NoeSanadTabpageName)
                                    //    {
                                    //        XtraTabControl1_1.TabPages[i].PageEnabled = false;
                                    //    }
                                    //}

                                    break;
                                }
                            case "xtpKhrojeKala":
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        cmbAzAnbar.EditValue = _AzAnbarId;
                                        cmbAzAnbar.ReadOnly = true;
                                    }

                                    var q1 = dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                    var q = q1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar).ToList();

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
                                        if (_FirstSelectAnbar_NextSanad)
                                            cmbNoeSanad.Properties.Items.Add("حواله (جابجایی)");
                                        else
                                            cmbNoeSanad.Properties.Items.Add("جابجایی کالا");
                                        cmbNoeSanad.Properties.Items.Add("حواله تبدیل");
                                        cmbNoeSanad.Properties.Items.Add("حواله سایر");

                                        // _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                        cmbNoeSanad.SelectedIndex = _NoeSanadIndex;
                                        txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = _SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                        txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = _SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                        txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = _SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                        txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = _SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                        txtGhateySanadNumber.Text = _GhateySanadNamber != null ? _GhateySanadNamber.ToString() : "";
                                        txtSabetAtefNumber.Text = _SabetAtefNumber.ToString();
                                        txtRozaneSanadNumber.Text = _RozaneSanadNumber.ToString();
                                        txtPaygiriNumber.Text = _PaygiriNumber != null ? _PaygiriNumber.ToString() : "";
                                        //txtNoeAmaliat1.Text = xtcAmaliatRozaneh.SelectedTabPage.Name;
                                        //txtNoeSanad1.Text = XtraTabControl1_1.SelectedTabPage.Name;
                                        //txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                        //txtNoeSanad.BackColor = Color.Yellow;
                                        HelpClass1.DateTimeMask(txtPaygiriTarikh);
                                        txtPaygiriTarikh.Text = _DateTimePaygiri;
                                        HelpClass1.DateTimeMask(txtTarikhSanad);
                                        txtTarikhSanad.Text = _DateTimeSanad;
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
                                        //lblSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = "ش حواله در کل انبارها";
                                        //lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = "ش حواله در انبار انتخابی";
                                        //lblSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = "ش حواله در نوع حواله";
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

                                        //List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)gridControl.DataSource;
                                        //BindingList<AmaliatAnbarVKala_Riz> bl = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);
                                        //akVorodeKala_RizsBindingSource.DataSource = bl.Where(s => s.Seryal == _Seryal);

                                        foreach (var item in q1)
                                        {
                                            item.KalaCode_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Code.ToString();
                                            item.KalaName_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).Name;
                                            item.VahedeKala_NM = q2.FirstOrDefault(s => s.Id == item.KalaId).EpVahedAsliKala.Name;
                                            item.AzAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.AzAnbarId).Name;
                                            item.BeAnbarName_NM = new MyContext().EpListAnbarhas.FirstOrDefault(s => s.Id == item.BeAnbarId).Name;
                                        }

                                        //dbContext.AmaliatAnbarVKala_Rizs.LoadAsync().ContinueWith(loadTask =>
                                        //{
                                        //    // Bind data to control when loading complete
                                        //    gridControl.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

                                        //xtp_AddVaEdit.PageVisible = true;

                                        //dbContext.AmaliatAnbarVKala_Rizs.Where(s => s.Id == 0).Load();
                                        // Bind data to control when loading complete
                                        //akVorodeKala_RizsBindingSource.DataSource = dbContext.AkKhorojeKala_Rizs.Local.ToBindingList();

                                        if (_NoeSanadIndex == 8 || _NoeSanadIndex == 9)
                                        {
                                            cmbAzAnbar.EditValue = _AzAnbarId;
                                            cmbBeAnbar.EditValue = _BeAnbarId;
                                            amaliatAnbarVKala_RizsBindingSource1.DataSource = q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == 3).ToList().Count > 0 ? q1.Where(s => s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == 3).ToList() : null;
                                            amaliatAnbarVKala_RizsBindingSource2.DataSource = q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == 2).ToList().Count > 0 ? q1.Where(s => s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == 2).ToList() : null;
                                        }
                                        else
                                        {
                                            if (!_FirstSelectAnbar_NextSanad)
                                            {
                                                //akVorodeKala_RizsBindingSource.DataSource = dbContext.AmaliatAnbarVKala_Rizs.Local.ToBindingList();
                                                amaliatAnbarVKala_RizsBindingSource1.DataSource = q.Count > 0 ? q.ToList() : null;
                                            }
                                            else
                                            {
                                                var q4 = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                amaliatAnbarVKala_RizsBindingSource1.DataSource = q4.Count > 0 ? q4.ToList() : null;
                                            }
                                        }


                                        txtTarikhSanad.Focus();

                                    }

                                    break;
                                }
                            default:
                                break;
                        }

                        cmbNoeSanad.ReadOnly = true;

                        //if (cmbNoeSanad.SelectedIndex == 8)
                        //{
                        //    cmbAzAnbar.EditValue = _AzAnbarId;
                        //    cmbBeAnbar.EditValue = _BeAnbarId;
                        //    amaliatAnbarVKala_RizsBindingSource2.DataSource = amaliatAnbarVKala_RizsBindingSource1.DataSource;
                        //}
                        //if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                        //{
                        //    cmbAzAnbar.EditValue = _AzAnbarId;
                        //    cmbBeAnbar.EditValue = _BeAnbarId;
                        //}

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

                        DateTime? _DateTimePaygiri = null;
                        if (!string.IsNullOrEmpty(txtPaygiriTarikh.Text))
                            _DateTimePaygiri = Convert.ToDateTime(txtPaygiriTarikh.Text);
                        DateTime _DateTimeSanad = Convert.ToDateTime(txtTarikhSanad.Text);
                        DateTime _DateTimeInsert = DateTime.Now;
                        _NoeSanadIndex = Convert.ToInt32(cmbNoeSanad.SelectedIndex);
                        _NoeSanadText = cmbNoeSanad.Text;
                        int? _GhateySanadNamber = null;
                        int _SabetAtefNumber = 0;
                        int _RozaneSanadNumber = Convert.ToInt32(txtRozaneSanadNumber.Text);
                        int? _PaygiriNumber = null;
                        if (txtPaygiriNumber.Text != "")
                            _PaygiriNumber = Convert.ToInt32(txtPaygiriNumber.Text);
                        _SharhSanad = txtSharhSanad.Text;

                        switch (_NoeAmaliatTabpageName)
                        {
                            case "xtpVrodeKala":
                                {
                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_AllVorode":
                                            {
                                                if (_NoeSanadIndex == 8)
                                                {
                                                    goto case "xtp_ResidJabejaee";
                                                }
                                                else if (_NoeSanadIndex == 9)
                                                {
                                                    goto case "xtp_ResidTabdil";
                                                }
                                                else
                                                {
                                                    goto case "xtp_ResidKharid";
                                                }
                                            }
                                        case "xtp_ResidKharid":
                                            {
                                                if (IsValidation())
                                                {
                                                    _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                    _HesabTafsili1Id = Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 1 && s.EpAllGroupTafsili1.Id == 19 && s.Name == "سایر 1").Id : Convert.ToInt32(cmbHesabTafsili1.EditValue);
                                                    _HesabTafsili2Id = Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 2 && s.EpAllGroupTafsili1.Id == 38 && s.Name == "سایر 2").Id : Convert.ToInt32(cmbHesabTafsili2.EditValue);
                                                    _HesabTafsili3Id = Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 3 && s.EpAllGroupTafsili1.Id == 57 && s.Name == "سایر 3").Id : Convert.ToInt32(cmbHesabTafsili3.EditValue);

                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        var qp3 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        var qp4 = qp3.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                                                            //var qp2 = qp1.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = qp2.Count > 0 ? qp2.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var q = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                        }
                                                        List<AmaliatAnbarVKala_Riz> list = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _BeAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "AzAnbarId"));
                                                                //var qp2 = qp1.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                                //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = qp2.Count > 0 ? qp2.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var q = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                                _SeryalCol_BaNoeAmaliat_BaSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                _SeryalJoze_BaNoeSanad_BaSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                            }

                                                            int _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            int _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            //long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _BeAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
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
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(list);
                                                        db.SaveChanges();
                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        _SalId = Convert.ToInt32(lblSalId.Text);
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar"));
                                                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BeSelectAnbar"));
                                                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BeSelectAnbar"));

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BaSelectAnbar"));
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BaSelectAnbar"));
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BaSelectAnbar"));
                                                        }
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource1.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);

                                                        //BindingList<AmaliatAnbarVKala_Riz> list = (BindingList<AmaliatAnbarVKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        List<AmaliatAnbarVKala_Riz> q2 = new List<AmaliatAnbarVKala_Riz>();
                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _BeAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.BeAnbarId == _BeAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_BaNoeAmaliat_BaSelectAnbar == _SeryalCol_BaNoeAmaliat_BaSelectAnbar
                                                            && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _SeryalJoze_BaNoeSanad_BaSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AmaliatAnbarVKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }
                                                        else
                                                        {
                                                            var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                            && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AmaliatAnbarVKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }


                                                        var q = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _BeAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "AzAnbarId"));

                                                                var pp1 = q.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                                //var ss1 = q2.FirstOrDefault(s => s.BeAnbarId == _BeAnbarId);
                                                                //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = ss1 != null ? ss1.SeryalCol_BeNoeAmaliat_BaSelectAnbar : pp1.Count > 0 ? pp1.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var pp2 = pp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                                var ss2 = q2.FirstOrDefault(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.BeAnbarId == _BeAnbarId);
                                                                _SeryalCol_BaNoeAmaliat_BaSelectAnbar = ss2 != null ? ss2.SeryalCol_BaNoeAmaliat_BaSelectAnbar : pp2.Count > 0 ? pp2.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var pp3 = pp2.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                var ss3 = q2.FirstOrDefault(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.BeAnbarId == _BeAnbarId);
                                                                _SeryalJoze_BaNoeSanad_BaSelectAnbar = ss3 != null ? ss3.SeryalJoze_BaNoeSanad_BaSelectAnbar : pp3.Count > 0 ? pp3.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                            }

                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            //long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {

                                                                var v1 = q.FirstOrDefault(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                                && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar
                                                                && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                                && s.Id == list[i].Id);

                                                                v1.SalId = _SalId;
                                                                v1.AzAnbarId = _BeAnbarId;
                                                                v1.BeAnbarId = _BeAnbarId;
                                                                //v1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                                v1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                                v1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
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

                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _BeAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
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
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                        && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                        && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList();
                                                        if (qq1.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1.Count; j++)
                                                            {
                                                                qq1[j].Radif = j + 1;
                                                            }
                                                            db.SaveChanges();
                                                        }
                                                    }


                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
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
                                        case "xtp_ResidJabejaee":
                                            {
                                                _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue.ToString());
                                                _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue.ToString());
                                                var _AnbarList = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                                                var _MoinList = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                                                //_SharhSanad = txtSharhSanad.Text;

                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = 0;


                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = 0;


                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        ////////// کلی
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        {
                                                            //////////// مربوط به حواله جابجایی
                                                            var qp5 = qp1.Where(s => s.NoeAmaliatCode == 3).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp5.Count > 0 ? qp5.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp6 = qp5.Where(s => s.NoeSanadCode == 309).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp6.Count > 0 ? qp6.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            var qp8 = qp1.Where(s => s.AzAnbarId == _AzAnbarId || s.BeAnbarId == _AzAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp8.Count > 0 ? qp8.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp10 = qp5.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp10.Count > 0 ? qp10.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp11 = qp10.Where(s => s.NoeSanadCode == 309).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp11.Count > 0 ? qp11.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        {
                                                            //////////// مربوط به رسید جابجایی
                                                            var qp3 = qp1.Where(s => s.NoeAmaliatCode == 2).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp4 = qp3.Where(s => s.NoeSanadCode == 209).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp7 = qp1.Where(s => s.BeAnbarId == _BeAnbarId  || s.AzAnbarId==_BeAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp7.Count > 0 ? qp7.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp9 = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp9.Count > 0 ? qp9.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp12 = qp9.Where(s => s.NoeSanadCode == 209).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp12.Count > 0 ? qp12.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            ////////////////////// دستورات خروج کالا ///////////////////
                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 3;
                                                            obj1.NoeSanadCode = 309;
                                                            obj1.NoeSanadText = "حواله جابجایی";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List.Add(obj1);


                                                            ////////////////////// دستورات رسید کالا ///////////////////
                                                            AmaliatAnbarVKala_Riz obj2 = new AmaliatAnbarVKala_Riz();
                                                            obj2.SalId = _SalId;
                                                            obj2.AzAnbarId = _AzAnbarId;
                                                            obj2.BeAnbarId = _BeAnbarId;
                                                            obj2.KalaId = _KalaId;
                                                            obj2.VahedeKalaId = _VahedeKalaId;
                                                            obj2.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj2.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                            obj2.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                            //obj2.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                            obj2.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                            obj2.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                            obj2.GhateySanadNamber = _GhateySanadNamber;
                                                            obj2.SabetAtefNumber = _SabetAtefNumber;
                                                            obj2.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj2.PaygiriNumber = _PaygiriNumber;
                                                            obj2.DateTimePaygiri = _DateTimePaygiri;
                                                            obj2.DateTimeSanad = _DateTimeSanad;
                                                            obj2.DateTimeInsert = _DateTimeInsert;
                                                            obj2.NoeAmaliatCode = 2;
                                                            obj2.NoeSanadCode = 209;
                                                            obj2.NoeSanadText = "رسید جابجایی";
                                                            obj2.NoeSanadIndex = _NoeSanadIndex;
                                                            obj2.Meghdar = _Meghdar;
                                                            obj2.Nerkh = _Nerkh;
                                                            obj2.Mablag = _Mablag;
                                                            obj2.IsRiali = _Mablag > 0 ? true : false;
                                                            obj2.Radif = i + 1;
                                                            obj2.Tozihat = _Tozihat;
                                                            obj2.SharhSanad = _SharhSanad;
                                                            obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List.Add(obj2);

                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List);
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

                                                        List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource2.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);

                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = (int)gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar");
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        var qp1_H = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309);
                                                        var qp1_R = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209);
                                                        if (qp1.Count > 0)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1_H.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BeNoeAmaliat_BaSelectAnbar;


                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp1_R.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp1_R.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp1_R.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp1_R.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp1_R.SeryalCol_BeNoeAmaliat_BaSelectAnbar;

                                                        }

                                                        var q2 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        //var q21 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp1.Where(s => s.Radif == item.Radif).ToList();
                                                                db.AmaliatAnbarVKala_Rizs.RemoveRange(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        //var q1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        var k = qp1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).ToList();
                                                        var v = qp1.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list[i].Radif;

                                                                /////////////////////// دستورات خروج کالا ///////////////////////
                                                                var k1 = k.FirstOrDefault(s => s.Radif == list[i].Radif);
                                                                //k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.BeAnbarId = _BeAnbarId;
                                                                k1.KalaId = _KalaId;
                                                                k1.VahedeKalaId = _VahedeKalaId;
                                                                k1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                k1.PaygiriNumber = _PaygiriNumber;
                                                                k1.DateTimePaygiri = _DateTimePaygiri;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                //k1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //k1.NoeSanadCode = _NoeSanadCode;
                                                                //k1.NoeSanadText = NoeAmaliatTabpageText;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                //k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                k1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                k1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                k1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                k1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();

                                                                ////////////// دستورات رسید کالا
                                                                var v1 = v.FirstOrDefault(s => s.Radif == list[i].Radif);
                                                                //v1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _BeAnbarId;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                //v1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //v1.NoeSanadCode = _NoeSanadCode;
                                                                //v1.NoeSanadText = NoeAmaliatTabpageText;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                //v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                v1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                v1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                v1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;


                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                int _Radif = k.Count > 0 ? k.Max(s => s.Radif) + 1 : 1;
                                                                ////////////////////// دستورات خروج کالا ///////////////////
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 3;
                                                                obj1.NoeSanadCode = 309;
                                                                obj1.NoeSanadText = "حواله جابجایی";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                List.Add(obj1);


                                                                ////////////////////// دستورات رسید کالا ///////////////////
                                                                AmaliatAnbarVKala_Riz obj2 = new AmaliatAnbarVKala_Riz();
                                                                obj2.SalId = _SalId;
                                                                obj2.AzAnbarId = _AzAnbarId;
                                                                obj2.BeAnbarId = _BeAnbarId;
                                                                obj2.KalaId = _KalaId;
                                                                obj2.VahedeKalaId = _VahedeKalaId;
                                                                obj2.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj2.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                                obj2.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                                //obj2.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                                obj2.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                                obj2.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                                obj2.GhateySanadNamber = _GhateySanadNamber;
                                                                obj2.SabetAtefNumber = _SabetAtefNumber;
                                                                obj2.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj2.PaygiriNumber = _PaygiriNumber;
                                                                obj2.DateTimePaygiri = _DateTimePaygiri;
                                                                obj2.DateTimeSanad = _DateTimeSanad;
                                                                obj2.DateTimeInsert = _DateTimeInsert;
                                                                obj2.NoeAmaliatCode = 2;
                                                                obj2.NoeSanadCode = 209;
                                                                obj2.NoeSanadText = "رسید جابجایی";
                                                                obj2.NoeSanadIndex = _NoeSanadIndex;
                                                                obj2.Meghdar = _Meghdar;
                                                                obj2.Nerkh = _Nerkh;
                                                                obj2.Mablag = _Mablag;
                                                                obj2.IsRiali = _Mablag > 0 ? true : false;
                                                                obj2.Radif = _Radif;
                                                                obj2.Tozihat = _Tozihat;
                                                                obj2.SharhSanad = _SharhSanad;
                                                                obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                List.Add(obj2);

                                                                db.AmaliatAnbarVKala_Rizs.AddRange(List);
                                                                db.SaveChanges();

                                                            }
                                                        }

                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        var qq1_H = qq1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).OrderBy(s => s.Radif).ToList();
                                                        var qq1_R = qq1.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209).OrderBy(s => s.Radif).ToList();
                                                        if (qq1_H.Count > 0 && qq1_R.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1_H.Count; j++)
                                                            {
                                                                qq1_H[j].Radif = qq1_R[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();
                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
                                                        ActiveButtons();

                                                }
                                                break;

                                            }
                                        case "xtp_ResidTabdil":
                                            {
                                                //goto case "xtp_ResidKharid";
                                                _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue.ToString());
                                                _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue.ToString());
                                                var _AnbarList = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                                                var _MoinList = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                                                //_SharhSanad = txtSharhSanad.Text;

                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = 0;


                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = 0;


                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        ////////// کلی
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        {
                                                            //////////// مربوط به حواله تبدیل
                                                            var qp5 = qp1.Where(s => s.NoeAmaliatCode == 3).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp5.Count > 0 ? qp5.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp6 = qp5.Where(s => s.NoeSanadCode == 310).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp6.Count > 0 ? qp6.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp8 = qp1.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp8.Count > 0 ? qp8.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp10 = qp5.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp10.Count > 0 ? qp10.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp11 = qp10.Where(s => s.NoeSanadCode == 310).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp11.Count > 0 ? qp11.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        {
                                                            //////////// مربوط به رسید تبدیل
                                                            var qp3 = qp1.Where(s => s.NoeAmaliatCode == 2).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp4 = qp3.Where(s => s.NoeSanadCode == 210).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp7 = qp1.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp7.Count > 0 ? qp7.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp9 = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp9.Count > 0 ? qp9.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp12 = qp9.Where(s => s.NoeSanadCode == 210).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp12.Count > 0 ? qp12.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        ////////////////////// دستورات حواله تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> List_H = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 3;
                                                            obj1.NoeSanadCode = 310;
                                                            obj1.NoeSanadText = "حواله تبدیل";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List_H.Add(obj1);
                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List_H);
                                                        db.SaveChanges();

                                                        ////////////////////// دستورات رسید تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> List_R = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit2.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 2;
                                                            obj1.NoeSanadCode = 210;
                                                            obj1.NoeSanadText = "رسید تبدیل";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List_R.Add(obj1);
                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List_R);
                                                        db.SaveChanges();

                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar"));
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        ////////////////////// دستورات حواله تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl_H = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource1.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list_H = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl_H);

                                                        var qp1_H = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310);
                                                        if (qp1_H != null)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1_H.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                        }

                                                        var q2 = qp1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list_H.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp1.FirstOrDefault(s => s.Id == item.Id);
                                                                db.AmaliatAnbarVKala_Rizs.Remove(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var k = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar && s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).ToList();
                                                        for (int i = 0; i < list_H.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list_H[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list_H[i].Radif;

                                                                var k1 = k.FirstOrDefault(s => s.Id == list_H[i].Id);
                                                                //k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.BeAnbarId = _BeAnbarId;
                                                                k1.KalaId = _KalaId;
                                                                k1.VahedeKalaId = _VahedeKalaId;
                                                                k1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                k1.PaygiriNumber = _PaygiriNumber;
                                                                k1.DateTimePaygiri = _DateTimePaygiri;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                //k1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //k1.NoeSanadCode = _NoeSanadCode;
                                                                //k1.NoeSanadText = NoeAmaliatTabpageText;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                //k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                k1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                k1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                k1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                k1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                //List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                int _Radif = k.Count > 0 ? k.Max(s => s.Radif) + 1 : 1;
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 3;
                                                                obj1.NoeSanadCode = 310;
                                                                obj1.NoeSanadText = "حواله تبدیل";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                //List_H.Add(obj1);
                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        var qq1_H = qq1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).OrderBy(s => s.Radif).ToList();
                                                        if (qq1_H.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1_H.Count; j++)
                                                            {
                                                                qq1_H[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();

                                                        ////////////////////// دستورات رسید تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl_R = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource2.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list_R = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl_R);

                                                        var qp2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        var qp2_R = qp2.FirstOrDefault(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210);
                                                        if (qp2_R != null)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp2_R.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp2_R.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp2_R.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp2_R.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp2_R.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp2_R.SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                        }

                                                        var q02 = qp2.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                        foreach (var item in q02)
                                                        {
                                                            if (!list_R.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp2.FirstOrDefault(s => s.Id == item.Id);
                                                                db.AmaliatAnbarVKala_Rizs.Remove(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        //var q1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        var v = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar && s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                        for (int i = 0; i < list_R.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list_R[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list_R[i].Radif;

                                                                var v1 = v.FirstOrDefault(s => s.Id == list_R[i].Id);
                                                                //k1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _BeAnbarId;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                //v1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //v1.NoeSanadCode = _NoeSanadCode;
                                                                //v1.NoeSanadText = NoeAmaliatTabpageText;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                //v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                v1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                v1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                v1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                //List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                //var w = v.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                                int _Radif = v.Count > 0 ? v.Max(s => s.Radif) + 1 : 1;
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 2;
                                                                obj1.NoeSanadCode = 210;
                                                                obj1.NoeSanadText = "رسید تبدیل";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                //List.Add(obj1);

                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();

                                                            }
                                                        }

                                                        var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        //var qq1_H = qq01.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).OrderBy(s => s.Radif).ToList();
                                                        var qq2_R = qq2.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).OrderBy(s => s.Radif).ToList();
                                                        if (qq2_R.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq2_R.Count; j++)
                                                            {
                                                                qq2_R[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();

                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
                                                        ActiveButtons();

                                                }

                                                break;

                                            }
                                        case "xtp_ResidSayer":
                                            {
                                                goto case "xtp_ResidKharid";
                                            }
                                        case "xtp_MojodiAvalDore":
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
                                    switch (_NoeSanadTabpageName)
                                    {
                                        case "xtp_AllKhoroji":
                                            {
                                                if (_NoeSanadIndex == 8)
                                                {
                                                    goto case "xtp_HavaleJabejaee";
                                                }
                                                else if (_NoeSanadIndex == 9)
                                                {
                                                    goto case "xtp_HavaleTabdil";
                                                }
                                                else
                                                {
                                                    goto case "xtp_BargashtAzKharid";
                                                }

                                            }
                                        case "xtp_BargashtAzKharid":
                                            {
                                                if (IsValidation())
                                                {
                                                    _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                                    _HesabTafsili1Id = Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 1 && s.EpAllGroupTafsili1.Id == 19 && s.Name == "سایر 1").Id : Convert.ToInt32(cmbHesabTafsili1.EditValue);
                                                    _HesabTafsili2Id = Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 2 && s.EpAllGroupTafsili1.Id == 38 && s.Name == "سایر 2").Id : Convert.ToInt32(cmbHesabTafsili2.EditValue);
                                                    _HesabTafsili3Id = Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == 3 && s.EpAllGroupTafsili1.Id == 57 && s.Name == "سایر 3").Id : Convert.ToInt32(cmbHesabTafsili3.EditValue);

                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        var qp3 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        var qp4 = qp3.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {

                                                            //var qp2 = qp1.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = qp2.Count > 0 ? qp2.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var q = qp3.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                        }
                                                        List<AmaliatAnbarVKala_Riz> list = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "AzAnbarId"));
                                                                //var qp2 = qp1.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                                //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = qp2.Count > 0 ? qp2.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var q = qp3.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                                _SeryalCol_BaNoeAmaliat_BaSelectAnbar = q.Count > 0 ? q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var qq1 = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                _SeryalJoze_BaNoeSanad_BaSelectAnbar = qq1.Count > 0 ? qq1.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                            }

                                                            int _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            int _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            //long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _AzAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
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
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(list);
                                                        db.SaveChanges();
                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        _SalId = Convert.ToInt32(lblSalId.Text);
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar"));
                                                        _SeryalCol_BaNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BeSelectAnbar"));
                                                        _SeryalJoze_BaNoeSanad_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BeSelectAnbar"));

                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            // _SeryalCol_BeNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BaSelectAnbar"));
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BaNoeAmaliat_BaSelectAnbar"));
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalJoze_BaNoeSanad_BaSelectAnbar"));
                                                        }
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource1.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);

                                                        //BindingList<AmaliatAnbarVKala_Riz> list = (BindingList<AmaliatAnbarVKala_Riz>)akVorodeKala_RizsBindingSource.DataSource;
                                                        List<AmaliatAnbarVKala_Riz> q2 = new List<AmaliatAnbarVKala_Riz>();
                                                        if (_FirstSelectAnbar_NextSanad)
                                                        {
                                                            _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                                                            var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_BaNoeAmaliat_BaSelectAnbar == _SeryalCol_BaNoeAmaliat_BaSelectAnbar
                                                            && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _SeryalJoze_BaNoeSanad_BaSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AmaliatAnbarVKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }
                                                        else
                                                        {
                                                            var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                            && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                            && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList();
                                                            foreach (var item in qq2)
                                                            {
                                                                if (!list.Any(s => s.Id == item.Id))
                                                                {
                                                                    db.AmaliatAnbarVKala_Rizs.Remove(qq2.FirstOrDefault(s => s.Id == item.Id));
                                                                    db.SaveChanges();
                                                                }
                                                            }
                                                            q2 = qq2;
                                                        }


                                                        var q = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            if (!_FirstSelectAnbar_NextSanad)
                                                            {
                                                                _AzAnbarId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "AzAnbarId"));

                                                                var pp1 = q.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                                //var ss1 = q2.FirstOrDefault(s => s.AzAnbarId == _AzAnbarId);
                                                                //_SeryalCol_BeNoeAmaliat_BaSelectAnbar = ss1 != null ? ss1.SeryalCol_BeNoeAmaliat_BaSelectAnbar : pp1.Count > 0 ? pp1.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var pp2 = pp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                                                var ss2 = q2.FirstOrDefault(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.AzAnbarId == _AzAnbarId);
                                                                _SeryalCol_BaNoeAmaliat_BaSelectAnbar = ss2 != null ? ss2.SeryalCol_BaNoeAmaliat_BaSelectAnbar : pp2.Count > 0 ? pp2.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                                var pp3 = pp2.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                                                var ss3 = q2.FirstOrDefault(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode && s.AzAnbarId == _AzAnbarId);
                                                                _SeryalJoze_BaNoeSanad_BaSelectAnbar = ss3 != null ? ss3.SeryalJoze_BaNoeSanad_BaSelectAnbar : pp3.Count > 0 ? pp3.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;
                                                            }

                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            //long _Code = Convert.ToInt64(gridView_AmaliatAddVaEdit.GetRowCellValue(i, "KalaCode_NM"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {

                                                                var v1 = q.FirstOrDefault(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                                && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar
                                                                && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                                && s.Id == list[i].Id);

                                                                v1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _AzAnbarId;
                                                                //v1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                                v1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                                v1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
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

                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _AzAnbarId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
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
                                                                obj1.HesabMoinId = _HesabMoinId;
                                                                obj1.HesabTafsili1Id = _HesabTafsili1Id;
                                                                obj1.HesabTafsili2Id = _HesabTafsili2Id;
                                                                obj1.HesabTafsili3Id = _HesabTafsili3Id;


                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }
                                                        }
                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode
                                                        && s.SeryalCol_BaNoeAmaliat_BeSelectAnbar == _SeryalCol_BaNoeAmaliat_BeSelectAnbar
                                                        && s.SeryalJoze_BaNoeSanad_BeSelectAnbar == _SeryalJoze_BaNoeSanad_BeSelectAnbar).ToList();
                                                        if (qq1.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1.Count; j++)
                                                            {
                                                                qq1[j].Radif = j + 1;
                                                            }
                                                            db.SaveChanges();
                                                        }
                                                    }


                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
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
                                        case "xtp_HavaleJabejaee":
                                            {
                                                _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue);
                                                _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue);
                                                var _AnbarList = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                                                var _MoinList = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                                                _SharhSanad = txtSharhSanad.Text;

                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = 0;


                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = 0;


                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        ////////// کلی
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        {
                                                            //////////// مربوط به حواله جابجایی
                                                            var qp5 = qp1.Where(s => s.NoeAmaliatCode == 3).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp5.Count > 0 ? qp5.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp6 = qp5.Where(s => s.NoeSanadCode == 309).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp6.Count > 0 ? qp6.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp8 = qp1.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp8.Count > 0 ? qp8.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp10 = qp5.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp10.Count > 0 ? qp10.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp11 = qp10.Where(s => s.NoeSanadCode == 309).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp11.Count > 0 ? qp11.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        {
                                                            //////////// مربوط به رسید جابجایی
                                                            var qp3 = qp1.Where(s => s.NoeAmaliatCode == 2).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp4 = qp3.Where(s => s.NoeSanadCode == 209).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp7 = qp1.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp7.Count > 0 ? qp7.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp9 = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp9.Count > 0 ? qp9.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp12 = qp9.Where(s => s.NoeSanadCode == 209).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp12.Count > 0 ? qp12.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            ////////////////////// دستورات خروج کالا ///////////////////
                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 3;
                                                            obj1.NoeSanadCode = 309;
                                                            obj1.NoeSanadText = "حواله جابجایی";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List.Add(obj1);


                                                            ////////////////////// دستورات رسید کالا ///////////////////
                                                            AmaliatAnbarVKala_Riz obj2 = new AmaliatAnbarVKala_Riz();
                                                            obj2.SalId = _SalId;
                                                            obj2.AzAnbarId = _AzAnbarId;
                                                            obj2.BeAnbarId = _BeAnbarId;
                                                            obj2.KalaId = _KalaId;
                                                            obj2.VahedeKalaId = _VahedeKalaId;
                                                            obj2.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj2.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                            obj2.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                            //obj2.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                            obj2.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                            obj2.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                            obj2.GhateySanadNamber = _GhateySanadNamber;
                                                            obj2.SabetAtefNumber = _SabetAtefNumber;
                                                            obj2.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj2.PaygiriNumber = _PaygiriNumber;
                                                            obj2.DateTimePaygiri = _DateTimePaygiri;
                                                            obj2.DateTimeSanad = _DateTimeSanad;
                                                            obj2.DateTimeInsert = _DateTimeInsert;
                                                            obj2.NoeAmaliatCode = 2;
                                                            obj2.NoeSanadCode = 209;
                                                            obj2.NoeSanadText = "رسید جابجایی";
                                                            obj2.NoeSanadIndex = _NoeSanadIndex;
                                                            obj2.Meghdar = _Meghdar;
                                                            obj2.Nerkh = _Nerkh;
                                                            obj2.Mablag = _Mablag;
                                                            obj2.IsRiali = _Mablag > 0 ? true : false;
                                                            obj2.Radif = i + 1;
                                                            obj2.Tozihat = _Tozihat;
                                                            obj2.SharhSanad = _SharhSanad;
                                                            obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List.Add(obj2);

                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List);
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

                                                        List<AmaliatAnbarVKala_Riz> DBGridControl = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource1.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl);

                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = (int)gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar");
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        var qp1_H = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309);
                                                        var qp1_R = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209);
                                                        if (qp1.Count > 0)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1_H.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BeNoeAmaliat_BaSelectAnbar;


                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp1_R.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp1_R.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp1_R.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp1_R.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp1_R.SeryalCol_BeNoeAmaliat_BaSelectAnbar;

                                                        }

                                                        var q2 = qp1.Where(s => s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                                        //var q21 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp1.Where(s => s.Radif == item.Radif).ToList();
                                                                db.AmaliatAnbarVKala_Rizs.RemoveRange(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        //var q1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        var k = qp1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).ToList();
                                                        var v = qp1.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209).ToList();
                                                        for (int i = 0; i < list.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list[i].Radif;

                                                                /////////////////////// دستورات خروج کالا ///////////////////////
                                                                var k1 = k.FirstOrDefault(s => s.Radif == list[i].Radif);
                                                                //k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.BeAnbarId = _BeAnbarId;
                                                                k1.KalaId = _KalaId;
                                                                k1.VahedeKalaId = _VahedeKalaId;
                                                                k1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                k1.PaygiriNumber = _PaygiriNumber;
                                                                k1.DateTimePaygiri = _DateTimePaygiri;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                //k1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //k1.NoeSanadCode = _NoeSanadCode;
                                                                //k1.NoeSanadText = NoeAmaliatTabpageText;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                //k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                k1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                k1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                k1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                k1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();

                                                                ////////////// دستورات رسید کالا
                                                                var v1 = v.FirstOrDefault(s => s.Radif == list[i].Radif);
                                                                //v1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _BeAnbarId;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                //v1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //v1.NoeSanadCode = _NoeSanadCode;
                                                                //v1.NoeSanadText = NoeAmaliatTabpageText;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                //v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                v1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                v1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                v1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;


                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                int _Radif = k.Count > 0 ? k.Max(s => s.Radif) + 1 : 1;
                                                                ////////////////////// دستورات خروج کالا ///////////////////
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 3;
                                                                obj1.NoeSanadCode = 309;
                                                                obj1.NoeSanadText = "حواله جابجایی";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                List.Add(obj1);


                                                                ////////////////////// دستورات رسید کالا ///////////////////
                                                                AmaliatAnbarVKala_Riz obj2 = new AmaliatAnbarVKala_Riz();
                                                                obj2.SalId = _SalId;
                                                                obj2.AzAnbarId = _AzAnbarId;
                                                                obj2.BeAnbarId = _BeAnbarId;
                                                                obj2.KalaId = _KalaId;
                                                                obj2.VahedeKalaId = _VahedeKalaId;
                                                                obj2.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj2.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                                obj2.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                                //obj2.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                                obj2.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                                obj2.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                                obj2.GhateySanadNamber = _GhateySanadNamber;
                                                                obj2.SabetAtefNumber = _SabetAtefNumber;
                                                                obj2.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj2.PaygiriNumber = _PaygiriNumber;
                                                                obj2.DateTimePaygiri = _DateTimePaygiri;
                                                                obj2.DateTimeSanad = _DateTimeSanad;
                                                                obj2.DateTimeInsert = _DateTimeInsert;
                                                                obj2.NoeAmaliatCode = 2;
                                                                obj2.NoeSanadCode = 209;
                                                                obj2.NoeSanadText = "رسید جابجایی";
                                                                obj2.NoeSanadIndex = _NoeSanadIndex;
                                                                obj2.Meghdar = _Meghdar;
                                                                obj2.Nerkh = _Nerkh;
                                                                obj2.Mablag = _Mablag;
                                                                obj2.IsRiali = _Mablag > 0 ? true : false;
                                                                obj2.Radif = _Radif;
                                                                obj2.Tozihat = _Tozihat;
                                                                obj2.SharhSanad = _SharhSanad;
                                                                obj2.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj2.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj2.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj2.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                List.Add(obj2);

                                                                db.AmaliatAnbarVKala_Rizs.AddRange(List);
                                                                db.SaveChanges();

                                                            }
                                                        }

                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        var qq1_H = qq1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).OrderBy(s => s.Radif).ToList();
                                                        var qq1_R = qq1.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 209).OrderBy(s => s.Radif).ToList();
                                                        if (qq1_H.Count > 0 && qq1_R.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1_H.Count; j++)
                                                            {
                                                                qq1_H[j].Radif = qq1_R[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();
                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
                                                        ActiveButtons();

                                                }
                                                break;
                                            }
                                        case "xtp_HavaleTabdil":
                                            {
                                                //goto case "xtp_ResidKharid";
                                                _AzAnbarId = Convert.ToInt32(cmbAzAnbar.EditValue.ToString());
                                                _BeAnbarId = Convert.ToInt32(cmbBeAnbar.EditValue.ToString());
                                                var _AnbarList = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                                                var _MoinList = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                                                //_SharhSanad = txtSharhSanad.Text;

                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = 0;


                                                int _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = 0;
                                                int _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = 0;
                                                int _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = 0;
                                                //int _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = 0;


                                                if (IsValidation())
                                                {
                                                    var qq = db.EpNameKalas.Where(s => s.SalId == _SalId);

                                                    if (En1 == EnumCED.Create)
                                                    {
                                                        ////////// کلی
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1.Count > 0 ? qp1.Max(s => s.SeryalCol_BeNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                        {
                                                            //////////// مربوط به حواله تبدیل
                                                            var qp5 = qp1.Where(s => s.NoeAmaliatCode == 3).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp5.Count > 0 ? qp5.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp6 = qp5.Where(s => s.NoeSanadCode == 310).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp6.Count > 0 ? qp6.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp8 = qp1.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp8.Count > 0 ? qp8.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp10 = qp5.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp10.Count > 0 ? qp10.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp11 = qp10.Where(s => s.NoeSanadCode == 310).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp11.Count > 0 ? qp11.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        {
                                                            //////////// مربوط به رسید تبدیل
                                                            var qp3 = qp1.Where(s => s.NoeAmaliatCode == 2).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp3.Count > 0 ? qp3.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1 : 1;

                                                            var qp4 = qp3.Where(s => s.NoeSanadCode == 210).ToList();
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp4.Count > 0 ? qp4.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1 : 1;

                                                            //var qp7 = qp1.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp7.Count > 0 ? qp7.Max(s => s.SeryalCol_BeNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp9 = qp3.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp9.Count > 0 ? qp9.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1 : 1;

                                                            var qp12 = qp9.Where(s => s.NoeSanadCode == 210).ToList();
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp12.Count > 0 ? qp12.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1 : 1;

                                                        }


                                                        ////////////////////// دستورات حواله تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> List_H = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit1.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 3;
                                                            obj1.NoeSanadCode = 310;
                                                            obj1.NoeSanadText = "حواله تبدیل";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List_H.Add(obj1);
                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List_H);
                                                        db.SaveChanges();

                                                        ////////////////////// دستورات رسید تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> List_R = new List<AmaliatAnbarVKala_Riz>();
                                                        for (int i = 0; i < gridView_AmaliatAddVaEdit2.RowCount; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                            obj1.SalId = _SalId;
                                                            obj1.AzAnbarId = _AzAnbarId;
                                                            obj1.BeAnbarId = _BeAnbarId;
                                                            obj1.KalaId = _KalaId;
                                                            obj1.VahedeKalaId = _VahedeKalaId;
                                                            obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                            obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                            obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                            //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                            obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                            obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                            obj1.GhateySanadNamber = _GhateySanadNamber;
                                                            obj1.SabetAtefNumber = _SabetAtefNumber;
                                                            obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                            obj1.PaygiriNumber = _PaygiriNumber;
                                                            obj1.DateTimePaygiri = _DateTimePaygiri;
                                                            obj1.DateTimeSanad = _DateTimeSanad;
                                                            obj1.DateTimeInsert = _DateTimeInsert;
                                                            obj1.NoeAmaliatCode = 2;
                                                            obj1.NoeSanadCode = 210;
                                                            obj1.NoeSanadText = "رسید تبدیل";
                                                            obj1.NoeSanadIndex = _NoeSanadIndex;
                                                            obj1.Meghdar = _Meghdar;
                                                            obj1.Nerkh = _Nerkh;
                                                            obj1.Mablag = _Mablag;
                                                            obj1.IsRiali = _Mablag > 0 ? true : false;
                                                            obj1.Radif = i + 1;
                                                            obj1.Tozihat = _Tozihat;
                                                            obj1.SharhSanad = _SharhSanad;
                                                            obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                            obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                            obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                            obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                            List_R.Add(obj1);
                                                        }
                                                        db.AmaliatAnbarVKala_Rizs.AddRange(List_R);
                                                        db.SaveChanges();

                                                        //En1 = EnumCED.Save;
                                                        //if (IsClosed_AmaliatAddVEit)
                                                        //    btnCancel_Click(null, null);


                                                    }
                                                    else if (En1 == EnumCED.Edit)
                                                    {
                                                        DateTime _DateTimeEdit = DateTime.Now;
                                                        _SeryalCol_BeNoeAmaliat_BeSelectAnbar = Convert.ToInt32(gridView.GetFocusedRowCellValue("SeryalCol_BeNoeAmaliat_BeSelectAnbar"));
                                                        var qp1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        ////////////////////// دستورات حواله تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl_H = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource1.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list_H = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl_H);

                                                        var qp1_H = qp1.FirstOrDefault(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310);
                                                        if (qp1_H != null)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp1_H.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_H = qp1_H.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_H = qp1_H.SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                        }

                                                        var q2 = qp1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).ToList();
                                                        foreach (var item in q2)
                                                        {
                                                            if (!list_H.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp1.FirstOrDefault(s => s.Id == item.Id);
                                                                db.AmaliatAnbarVKala_Rizs.Remove(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var k = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar && s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).ToList();
                                                        for (int i = 0; i < list_H.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit1.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list_H[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list_H[i].Radif;

                                                                var k1 = k.FirstOrDefault(s => s.Id == list_H[i].Id);
                                                                //k1.SalId = _SalId;
                                                                k1.AzAnbarId = _AzAnbarId;
                                                                k1.BeAnbarId = _BeAnbarId;
                                                                k1.KalaId = _KalaId;
                                                                k1.VahedeKalaId = _VahedeKalaId;
                                                                k1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                k1.PaygiriNumber = _PaygiriNumber;
                                                                k1.DateTimePaygiri = _DateTimePaygiri;
                                                                k1.DateTimeSanad = _DateTimeSanad;
                                                                k1.DateTimeEdit = _DateTimeEdit;
                                                                //k1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //k1.NoeSanadCode = _NoeSanadCode;
                                                                //k1.NoeSanadText = NoeAmaliatTabpageText;
                                                                k1.Meghdar = _Meghdar;
                                                                k1.Nerkh = _Nerkh;
                                                                k1.Mablag = _Mablag;
                                                                k1.IsRiali = _Mablag > 0 ? true : false;
                                                                //k1.Radif = i + 1;
                                                                k1.Tozihat = _Tozihat;
                                                                k1.SharhSanad = _SharhSanad;
                                                                k1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                k1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                k1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                k1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                //List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                int _Radif = k.Count > 0 ? k.Max(s => s.Radif) + 1 : 1;
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_H;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_H;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_H;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 3;
                                                                obj1.NoeSanadCode = 310;
                                                                obj1.NoeSanadText = "حواله تبدیل";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                //List_H.Add(obj1);
                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        var qq1_H = qq1.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 310).OrderBy(s => s.Radif).ToList();
                                                        if (qq1_H.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq1_H.Count; j++)
                                                            {
                                                                qq1_H[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();

                                                        ////////////////////// دستورات رسید تبدیل ///////////////////
                                                        List<AmaliatAnbarVKala_Riz> DBGridControl_R = (List<AmaliatAnbarVKala_Riz>)amaliatAnbarVKala_RizsBindingSource2.DataSource;
                                                        BindingList<AmaliatAnbarVKala_Riz> list_R = new BindingList<AmaliatAnbarVKala_Riz>(DBGridControl_R);

                                                        var qp2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();

                                                        var qp2_R = qp2.FirstOrDefault(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210);
                                                        if (qp2_R != null)
                                                        {
                                                            _SeryalCol_BeNoeAmaliat_BeSelectAnbar = qp2_R.SeryalCol_BeNoeAmaliat_BeSelectAnbar;

                                                            _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R = qp2_R.SeryalCol_BaNoeAmaliat_BeSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BeSelectAnbar_R = qp2_R.SeryalJoze_BaNoeSanad_BeSelectAnbar;
                                                            _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R = qp2_R.SeryalCol_BaNoeAmaliat_BaSelectAnbar;
                                                            _SeryalJoze_BaNoeSanad_BaSelectAnbar_R = qp2_R.SeryalJoze_BaNoeSanad_BaSelectAnbar;
                                                            //_SeryalCol_BeNoeAmaliat_BaSelectAnbar_R = qp2_R.SeryalCol_BeNoeAmaliat_BaSelectAnbar;
                                                        }

                                                        var q02 = qp2.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                        foreach (var item in q02)
                                                        {
                                                            if (!list_R.Any(s => s.Id == item.Id))
                                                            {
                                                                var kk = qp2.FirstOrDefault(s => s.Id == item.Id);
                                                                db.AmaliatAnbarVKala_Rizs.Remove(kk);
                                                                db.SaveChanges();
                                                            }
                                                        }

                                                        //var q1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeSanadCode == _NoeSanadCode && s.SeryalJoze_BaNoeSanad_BaSelectAnbar == _Seryal).ToList();
                                                        var v = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar && s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                        for (int i = 0; i < list_R.Count; i++)
                                                        {
                                                            _KalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "KalaId"));
                                                            _VahedeKalaId = Convert.ToInt32(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "VahedeKalaId"));
                                                            decimal _Meghdar = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Meghdar"));
                                                            decimal _Nerkh = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Nerkh"));
                                                            decimal _Mablag = Convert.ToDecimal(gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Mablag"));
                                                            string _Tozihat = gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat") != null ? gridView_AmaliatAddVaEdit2.GetRowCellValue(i, "Tozihat").ToString() : null;

                                                            if (list_R[i].Id > 0)
                                                            {
                                                                int _RadifBefourEdit = list_R[i].Radif;

                                                                var v1 = v.FirstOrDefault(s => s.Id == list_R[i].Id);
                                                                //k1.SalId = _SalId;
                                                                v1.AzAnbarId = _AzAnbarId;
                                                                v1.BeAnbarId = _BeAnbarId;
                                                                v1.KalaId = _KalaId;
                                                                v1.VahedeKalaId = _VahedeKalaId;
                                                                v1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                v1.PaygiriNumber = _PaygiriNumber;
                                                                v1.DateTimePaygiri = _DateTimePaygiri;
                                                                v1.DateTimeSanad = _DateTimeSanad;
                                                                v1.DateTimeEdit = _DateTimeEdit;
                                                                //v1.NoeAmaliatCode = _NoeAmaliatCodeResid;
                                                                //v1.NoeSanadCode = _NoeSanadCode;
                                                                //v1.NoeSanadText = NoeAmaliatTabpageText;
                                                                v1.Meghdar = _Meghdar;
                                                                v1.Nerkh = _Nerkh;
                                                                v1.Mablag = _Mablag;
                                                                v1.IsRiali = _Mablag > 0 ? true : false;
                                                                //v1.Radif = i + 1;
                                                                v1.Tozihat = _Tozihat;
                                                                v1.SharhSanad = _SharhSanad;
                                                                v1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                v1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                v1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                v1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                //List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                                                                //var w = v.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).ToList();
                                                                int _Radif = v.Count > 0 ? v.Max(s => s.Radif) + 1 : 1;
                                                                AmaliatAnbarVKala_Riz obj1 = new AmaliatAnbarVKala_Riz();
                                                                obj1.SalId = _SalId;
                                                                obj1.AzAnbarId = _AzAnbarId;
                                                                obj1.BeAnbarId = _BeAnbarId;
                                                                obj1.KalaId = _KalaId;
                                                                obj1.VahedeKalaId = _VahedeKalaId;
                                                                obj1.SeryalCol_BeNoeAmaliat_BeSelectAnbar = _SeryalCol_BeNoeAmaliat_BeSelectAnbar;
                                                                obj1.SeryalCol_BaNoeAmaliat_BeSelectAnbar = _SeryalCol_BaNoeAmaliat_BeSelectAnbar_R;
                                                                obj1.SeryalJoze_BaNoeSanad_BeSelectAnbar = _SeryalJoze_BaNoeSanad_BeSelectAnbar_R;
                                                                //obj1.SeryalCol_BeNoeAmaliat_BaSelectAnbar = _SeryalCol_BeNoeAmaliat_BaSelectAnbar_R;
                                                                obj1.SeryalCol_BaNoeAmaliat_BaSelectAnbar = _SeryalCol_BaNoeAmaliat_BaSelectAnbar_R;
                                                                obj1.SeryalJoze_BaNoeSanad_BaSelectAnbar = _SeryalJoze_BaNoeSanad_BaSelectAnbar_R;
                                                                obj1.GhateySanadNamber = _GhateySanadNamber;
                                                                obj1.SabetAtefNumber = _SabetAtefNumber;
                                                                obj1.RozaneSanadNumber = _RozaneSanadNumber;
                                                                obj1.PaygiriNumber = _PaygiriNumber;
                                                                obj1.DateTimePaygiri = _DateTimePaygiri;
                                                                obj1.DateTimeSanad = _DateTimeSanad;
                                                                obj1.DateTimeInsert = _DateTimeInsert;
                                                                obj1.NoeAmaliatCode = 2;
                                                                obj1.NoeSanadCode = 210;
                                                                obj1.NoeSanadText = "رسید تبدیل";
                                                                obj1.NoeSanadIndex = _NoeSanadIndex;
                                                                obj1.Meghdar = _Meghdar;
                                                                obj1.Nerkh = _Nerkh;
                                                                obj1.Mablag = _Mablag;
                                                                obj1.IsRiali = _Mablag > 0 ? true : false;
                                                                obj1.Radif = _Radif;
                                                                obj1.Tozihat = _Tozihat;
                                                                obj1.SharhSanad = _SharhSanad;
                                                                obj1.HesabMoinId = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).MoinId;
                                                                obj1.HesabTafsili1Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId1;
                                                                obj1.HesabTafsili2Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId2;
                                                                obj1.HesabTafsili3Id = _AnbarList.FirstOrDefault(s => s.Id == _BeAnbarId).TafsiliId3;

                                                                //List.Add(obj1);

                                                                db.AmaliatAnbarVKala_Rizs.Add(obj1);
                                                                db.SaveChanges();

                                                            }
                                                        }

                                                        var qq2 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.SeryalCol_BeNoeAmaliat_BeSelectAnbar == _SeryalCol_BeNoeAmaliat_BeSelectAnbar).ToList();
                                                        //var qq1_H = qq01.Where(s => s.NoeAmaliatCode == 3 && s.NoeSanadCode == 309).OrderBy(s => s.Radif).ToList();
                                                        var qq2_R = qq2.Where(s => s.NoeAmaliatCode == 2 && s.NoeSanadCode == 210).OrderBy(s => s.Radif).ToList();
                                                        if (qq2_R.Count > 0)
                                                        {
                                                            for (int j = 0; j < qq2_R.Count; j++)
                                                            {
                                                                qq2_R[j].Radif = j + 1;
                                                            }

                                                        }
                                                        db.SaveChanges();

                                                    }

                                                    En1 = EnumCED.Save;
                                                    if (IsClosed_AmaliatAddVEit)
                                                        btnCancel_Click(null, null);
                                                    else
                                                        ActiveButtons();

                                                }

                                                break;
                                            }
                                        case "xtp_HavaleSayer":
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

        private void gridView_AmaliatAddVaEdit1_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit1.RowCount > 0)
            {
                if (_FirstSelectAnbar_NextSanad)
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        if (_NoeAmaliatTabpageIndex == 0)
                        {
                            cmbAzAnbar.ReadOnly = true;
                        }
                        else if (_NoeAmaliatTabpageIndex == 1)
                        {
                            cmbBeAnbar.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        cmbAzAnbar.ReadOnly = true;
                        cmbBeAnbar.ReadOnly = true;
                    }
                }
                btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = true;
                cmbNoeSanad.ReadOnly = true;
            }
            else
            {
                if (_FirstSelectAnbar_NextSanad)
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        if (_NoeAmaliatTabpageIndex == 0)
                        {
                            cmbAzAnbar.ReadOnly = false;
                        }
                        else if (_NoeAmaliatTabpageIndex == 1)
                        {
                            cmbBeAnbar.ReadOnly = false;
                        }
                    }
                }
                else
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        cmbAzAnbar.ReadOnly = false;
                        cmbBeAnbar.ReadOnly = false;
                    }
                }

                btnDelete1.Enabled = btnEdit1.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
                if (XtraTabControl1_1.SelectedTabPageIndex == 0 && En1 == EnumCED.Create)
                    cmbNoeSanad.ReadOnly = false;

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
                            if (_NoeAmaliatTabpageName == "xtpVrodeKala")
                            {
                                if (_FirstSelectAnbar_NextSanad)
                                {
                                    var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.BeAnbarId == _BeAnbarId).ToList();
                                    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";

                                }
                                else
                                {
                                    var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                    txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1).ToString() : "1";
                                }
                                //cmbNoeSanad_SelectedIndexChanged(null, null);
                                //cmbNoeSanad.ReadOnly = true;

                                //if (_FirstSelectAnbar_NextSanad)
                                //{
                                //    _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                                //    var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";

                                //    var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                                //}
                                //else
                                //{
                                //    var q = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = "0";
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = false;
                                //}


                                //var q = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AzAnbarId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                                //if (q.Count > 0)
                                //{
                                //    txtSeryal_darSelectNoe.Text = (q.Max(s => s.Seryal_darSelectNoe) + 1).ToString();
                                //}
                                //else
                                //    txtSeryal_darSelectNoe.Text = "1";

                                //txtTarikh.Text = DateTime.Now.ToString();
                                //chkIsSanadHesabdari.Checked = true;
                            }
                            else if (_NoeAmaliatTabpageName == "xtpKhrojeKala")
                            {
                                if (_FirstSelectAnbar_NextSanad)
                                {
                                    var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.AzAnbarId == _AzAnbarId).ToList();
                                    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";
                                }
                                else
                                {
                                    var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode).ToList();
                                    txtSeryalCol_BaNoeAmaliat_BeSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalCol_BaNoeAmaliat_BeSelectAnbar) + 1).ToString() : "1";
                                }

                                //if (_FirstSelectAnbar_NextSanad)
                                //{
                                //    _AzAnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);

                                //    var q = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalCol_BaNoeAmaliat_BaSelectAnbar) + 1).ToString() : "1";

                                //    var qq = q.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                                //}
                                //else
                                //{
                                //    var q = qp.Where(s => s.NoeSanadCode == _NoeSanadCode).ToList();
                                //    txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = q.Count > 0 ? (q.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Text = "0";
                                //    txtSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = lblSeryalCol_BaNoeAmaliat_BaSelectAnbar.Visible = false;
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

                            cmbNoeSanad_SelectedIndexChanged(null, null);
                            txtSharhSanad.Text = txtPaygiriNumber.Text = txtPaygiriTarikh.Text = string.Empty;
                            btnDelete1.Enabled = btnEdit1.Enabled = false;
                            btnDelete2.Enabled = btnEdit2.Enabled = false;
                            amaliatAnbarVKala_RizsBindingSource1.Clear();
                            amaliatAnbarVKala_RizsBindingSource2.Clear();
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
                HelpClass1.MoveLast(gridView_AmaliatAddVaEdit1);
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
                HelpClass1.MoveNext(gridView_AmaliatAddVaEdit1);
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
                HelpClass1.MovePrev(gridView_AmaliatAddVaEdit1);
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
                HelpClass1.MoveFirst(gridView_AmaliatAddVaEdit1);
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
                    _NoeSanadIndex = cmbNoeSanad.SelectedIndex;
                    _NoeSanadText = cmbNoeSanad.Text;
                    xtpAmaliatAddVEdit.Text = titelAmaliatAddVEdit + " : " + "نوع سند" + " : " + _NoeSanadText;
                    if (cmbNoeSanad.SelectedIndex < 0 || cmbNoeSanad.Text == "" || string.IsNullOrEmpty(cmbNoeSanad.Text))
                    {
                        if (En1 == EnumCED.Create)
                        {

                            XtraMessageBox.Show("لطفاً نوع سند را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbNoeSanad.ShowPopup();
                            return;
                        }

                    }
                    else
                    {
                        if (_NoeAmaliatTabpageIndex == 0)
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
                                case 10:
                                    _NoeSanadCode = 211;
                                    break;
                                case 11:
                                    _NoeSanadCode = 212;
                                    break;
                            }

                        }
                        else if (_NoeAmaliatTabpageIndex == 1)
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
                                case 9:
                                    _NoeSanadCode = 310;
                                    break;
                                case 10:
                                    _NoeSanadCode = 311;
                                    break;
                            }
                        }


                        if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                        {
                            lblAzAnbar.Visible = lblBeAnbar.Visible = true;
                            cmbAzAnbar.Visible = cmbBeAnbar.Visible = true;
                            btnReloadAzAnbar.Visible = btnReloadBeAnbar.Visible = true;

                            lblHesabMoin.Visible = lblHesabTafsili1.Visible = lblHesabTafsili2.Visible = lblHesabTafsili3.Visible = false;
                            cmbHesabMoin.Visible = cmbHesabTafsili1.Visible = cmbHesabTafsili2.Visible = cmbHesabTafsili3.Visible = false;
                            btnReloadHesabMoin.Visible = btnReloadHesabTafsili.Visible = btnReloadHesabTafsili2.Visible = btnReloadHesabTafsili3.Visible = false;
                            FillCmbAzAnbar();

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

                        if (cmbNoeSanad.SelectedIndex == 8)
                        {
                            panelControl1_2.Width = 929;
                            panelControl1_2.Height = 364;
                            labelControl4.Text = "انتقال به";
                            btnInsert2.Visible = btnDelete2.Visible = btnEdit2.Visible = false;
                            panelControl_AzAnbar.Width = 859;
                            panelControl_AzAnbar.Height = 33;
                            panelControl_BeAnbar.Width = 859;
                            panelControl_BeAnbar.Height = 33;
                        }
                        else if (cmbNoeSanad.SelectedIndex == 9)
                        {
                            panelControl1_2.Width = 929;
                            panelControl1_2.Height = 364;
                            labelControl4.Text = "تبدیل به";
                            btnInsert2.Visible = btnDelete2.Visible = btnEdit2.Visible = true;
                            panelControl_AzAnbar.Width = 859;
                            panelControl_AzAnbar.Height = 33;
                            panelControl_BeAnbar.Width = 859;
                            panelControl_BeAnbar.Height = 33;
                        }
                        else
                        {
                            panelControl1_2.Width = 0;
                            panelControl1_2.Height = 0;
                            panelControl_AzAnbar.Width = 0;
                            panelControl_AzAnbar.Height = 0;
                            panelControl_BeAnbar.Width = 0;
                            panelControl_BeAnbar.Height = 0;
                        }

                        var qp = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.NoeAmaliatCode == _NoeAmaliatCode && s.NoeSanadCode == _NoeSanadCode).ToList();
                        if (_FirstSelectAnbar_NextSanad)
                        {
                            if (_NoeAmaliatTabpageIndex == 0)
                            {
                                var qq = qp.Where(s => s.BeAnbarId == _BeAnbarId).ToList();
                                txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                            }
                            else if (_NoeAmaliatTabpageIndex == 1)
                            {
                                var qq = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                                txtSeryalJoze_BaNoeSanad_BaSelectAnbar.Text = qq.Count > 0 ? (qq.Max(s => s.SeryalJoze_BaNoeSanad_BaSelectAnbar) + 1).ToString() : "1";
                            }
                        }
                        else
                        {
                            //var qq = qp.Where(s => s.AzAnbarId == _AzAnbarId).ToList();
                            txtSeryalJoze_BaNoeSanad_BeSelectAnbar.Text = qp.Count > 0 ? (qp.Max(s => s.SeryalJoze_BaNoeSanad_BeSelectAnbar) + 1).ToString() : "1";

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
            if (gridView_KolAmaliat.RowCount > 0)
                btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = true;
            else
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = btnPrintPreview.Enabled = false;

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
            {
                FillCmbBeAnbar();
                lblAzAnbar1.Text = "از : " + cmbAzAnbar.Text;
            }
            else
            {
                lblAzAnbar1.Text = "از انبار : " + "مشخص نشده";
            }

        }

        private void cmbAzAnbar_Enter(object sender, EventArgs e)
        {
            if (En1 == EnumCED.Create)
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

        private void txtTarikh_Leave(object sender, EventArgs e)
        {
            if (cmbHesabMoin.Visible == true)
            {
                cmbHesabMoin.Focus();
            }
            else
            {
                cmbAzAnbar.Focus();
            }

        }

        private void cmbHesabTafsili3_Leave(object sender, EventArgs e)
        {
            txtPaygiriNumber.Focus();
        }

        private void txtSharhSanad_Leave(object sender, EventArgs e)
        {
            btnInsert1.Focus();
        }

        private void gridView_AmaliatAddVaEdit1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (sender == gridView_AmaliatAddVaEdit1)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = true;
                    btnDelete2.Enabled = btnEdit2.Enabled = false;
                    gridControl1 = gridControl_AmaliatAddVaEdit1;
                    gridView1 = gridView_AmaliatAddVaEdit1;
                }
                else if (sender == gridView_AmaliatAddVaEdit2)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = false;
                    btnDelete2.Enabled = btnEdit2.Enabled = true;
                    gridControl1 = gridControl_AmaliatAddVaEdit2;
                    gridView1 = gridView_AmaliatAddVaEdit2;
                }
            }
            catch (Exception)
            {
            }

        }

        private void gridView_AmaliatAddVaEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_AmaliatAddVaEdit1_RowCellClick(null, null);
        }

        private void gridView_AmaliatAddVaEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_AmaliatAddVaEdit1_RowCellClick(null, null);
        }

        private void gridView_AmaliatAddVaEdit2_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit2.RowCount > 0)
            {
                if (_FirstSelectAnbar_NextSanad)
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        if (_NoeAmaliatTabpageIndex == 0)
                        {
                            cmbAzAnbar.ReadOnly = true;
                        }
                        else if (_NoeAmaliatTabpageIndex == 1)
                        {
                            cmbBeAnbar.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                    {
                        cmbAzAnbar.ReadOnly = true;
                        cmbBeAnbar.ReadOnly = true;
                    }
                }
                btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = true;
                cmbNoeSanad.ReadOnly = true;
            }
            else
            {
                //if (_FirstSelectAnbar_NextSanad)
                //{
                //    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                //    {
                //        if (_NoeAmaliatTabpageIndex == 0)
                //        {
                //            cmbAzAnbar.ReadOnly = false;
                //        }
                //        else if (_NoeAmaliatTabpageIndex == 1)
                //        {
                //            cmbBeAnbar.ReadOnly = false;
                //        }
                //    }
                //}
                //else
                //{
                //    if (cmbNoeSanad.SelectedIndex == 8 || cmbNoeSanad.SelectedIndex == 9)
                //    {
                //        cmbAzAnbar.ReadOnly = false;
                //        cmbBeAnbar.ReadOnly = false;
                //    }
                //}

                btnDelete2.Enabled = btnEdit2.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
                //if (XtraTabControl1_1.SelectedTabPageIndex == 0 && En1 == EnumCED.Create)
                //    cmbNoeSanad.ReadOnly = false;
            }
        }

        private void cmbBeAnbar_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbBeAnbar.EditValue) > 0)
            {
                btnInsert1.Enabled = btnInsert2.Enabled = true;
                lblBeAnbar1.Text = "به : " + cmbBeAnbar.Text;
            }
            else
            {
                btnInsert1.Enabled = btnInsert2.Enabled = false;
                lblBeAnbar1.Text = "یه انبار : " + "مشخص نشده";
            }


        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtRozaneSanadNumber.Enabled = chkEditCode.Checked ? true : false;
        }

        private void cmbAzAnbar_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbBeAnbar.EditValue) > 0)
            {
                btnInsert1.Enabled = btnInsert2.Enabled = true;
                lblBeAnbar1.Text = "به : " + cmbBeAnbar.Text;
            }
            else
            {
                btnInsert1.Enabled = btnInsert2.Enabled = false;
                lblBeAnbar1.Text = "یه انبار : " + "مشخص نشده";
            }

        }
    }
}
