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
using DBHesabdari_PG;
using System.Data.Entity;
using HelpClassLibrary;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DBHesabdari_PG.Models.AK;
using DevExpress.XtraGrid.Views.Grid;
using DBHesabdari_PG.Models.EP.CodingAnbar;

namespace AnbarVaKala.Reports
{
    public partial class FrmKardeksKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmKardeksKala()
        {
            InitializeComponent();
        }
        int _SalId = 0;
        public void FillcmbAnbarName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    //var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    #region MyRegion
                    //foreach (var item in q1)
                    //{
                    //    List<int> List1 = new List<int>();
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

                    #endregion

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

                    if (q1.Count > 0)
                        epListAnbarhasBindingSource.DataSource = q1;
                    else
                        epListAnbarhasBindingSource.Clear();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbKalaName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _AnbarhId = Convert.ToInt32(cmbAnbarName.EditValue);
                    //var q1 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    //var q5 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    var q2 = db.EpVahedKalas.Where(s => s.SalId == _SalId).ToList();
                    //var q3 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                    var q4 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == _AnbarhId).Select(s => s.TabagheKalaId).ToList();
                    var q6 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AnbarhId).ToList();

                    List<EpNameKala> List1 = new List<EpNameKala>();
                    foreach (var item in q4)
                    {
                        var q5 = db.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.TabaghehId == item).ToList();
                        List1.AddRange(q5);
                    }
                    var q1 = List1.OrderBy(s => s.Code).ToList();

                    //foreach (var item in q5)
                    //{
                    //    int _TabagheId = item.EpGroupFareeKala1.EpGroupAsliKala1.TabaghehId;
                    //    if (!q4.Any(s => s.TabagheKalaId == _TabagheId))
                    //    {
                    //        q1.Remove(item);
                    //    }
                    //}
                    foreach (var item in q1)
                    {
                        item.VahedAsliName_NM = db.EpVahedKalas.FirstOrDefault(s => s.SalId == _SalId &&  s.Id == item.VahedAsliId).Name;
                        item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                        item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                        item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                        item.MeghdarMa_NM = q6.Where(s => s.KalaId == item.Id && s.NoeAmaliatCode == 2).Sum(s => s.Meghdar) - q6.Where(s => s.KalaId == item.Id && s.NoeAmaliatCode == 3).Sum(s => s.Meghdar);
                    }

                    if (q1.Count > 0)
                        epNameKalasBindingSource.DataSource = q1;
                    else
                        epNameKalasBindingSource.Clear();

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public bool _FirstSelectAnbar_NextSanad = false;

        public void FillbandedGridView()
        {
            //int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
            // var StartData = Convert.ToDateTime(txtAzTarikh.Text);
            // var EndData = Convert.ToDateTime(txtTaTarikh.Text);
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == 4401001);
                    if (q != null)
                        _FirstSelectAnbar_NextSanad = q.IsChecked;


                    _SalId = Convert.ToInt32(lblSalId.Text);
                    //DataSet ds = new DataSet();

                    //var q2 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId && s.LevelNamber==4).ToList();
                    int _AnbarId = Convert.ToInt32(cmbAnbarName.EditValue);
                    int _KalaId = Convert.ToInt32(cmbKalaName.EditValue);

                    //DateTime _DateTimeSanad = Convert.ToDateTime();
                    var StartDate = Convert.ToDateTime(txtAzTarikh.Text);
                    var EndDate = Convert.ToDateTime(txtTaTarikh.Text);
                    //int yyyy1 = Convert.ToInt32(txtAzTarikh.Text.Substring(0, 4));
                    //int MM1 = Convert.ToInt32(txtAzTarikh.Text.Substring(5, 2));
                    //int dd1 = Convert.ToInt32(txtAzTarikh.Text.Substring(8, 2));
                    //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    //d1.DecrementDay();
                    //var q = db.AsnadeHesabdariRows.Where(f => f.HesabTafId == TafziliId && f.Tarikh <= EndData).OrderBy(f => f.Tarikh).ToList();
                    var qq1 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.KalaId == _KalaId && s.DateTimeSanad <= EndDate).ToList();
                    var qq2 = qq1.Where(s =>  s.BeAnbarId == _AnbarId  && s.NoeAmaliatCode==2).ToList();
                    var qq3 = qq1.Where(s =>  s.AzAnbarId == _AnbarId && s.NoeAmaliatCode == 3).ToList();
                    List<AmaliatAnbarVKala_Riz> List = new List<AmaliatAnbarVKala_Riz>();
                    List.AddRange(qq2);
                    List.AddRange(qq3);
                    var q1 = List.OrderBy(s => s.DateTimeSanad).ToList();
                    var q7 = q1.Where(s => s.DateTimeSanad < StartDate).OrderBy(s => s.DateTimeSanad).ThenBy(s => s.Id).ToList();
                    var q4 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    var q5 = db.EpVahedKalas.Where(s => s.SalId == _SalId).ToList();
                    var q6 = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == 1).ToList();
                    //var q8 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();

                    if (q1.Count > 0)
                    {
                        if (_chkIsEdgham)
                        {
                            if (q7.Count > 0)
                            {
                                //AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                q1[0].Id = 0;
                                q1[0].SeryalCol_NM = "0";
                                q1[0].SeryalJoze_NM = "0";
                                q1[0].DateTimeSanadString_NM = txtAzTarikh.Text;
                                q1[0].AnbarName_NM = cmbAnbarName.Text;
                                q1[0].NoeSanadText = "جمع مانده از قبل";
                                //q1[0].FactorNamber = 0;
                                q1[0].Radif = 0;
                                q1[0].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q7[0].VahedeKalaId).Name;

                                q1[0].MeghdarMo_NM = 0;
                                q1[0].NerkhMo_NM = 0;
                                q1[0].MablagMo_NM = 0;
                                q1[0].MeghdarVa_NM = 0;
                                q1[0].NerkhVa_NM = 0;
                                q1[0].MablagVa_NM = 0;
                                q1[0].MeghdarSa_NM = 0;
                                q1[0].NerkhSa_NM = 0;
                                q1[0].MablagSa_NM = 0;
                                q1[0].MeghdarMa_NM = 0;
                                q1[0].NerkhMa_NM = 0;
                                q1[0].MablagMa_NM = 0;

                                decimal _MeghdarMo = q7.Where(s =>  s.NoeAmaliatCode == 2).Sum(s => s.Meghdar);
                                decimal _MablagMo = q7.Where(s =>  s.NoeAmaliatCode == 2).Sum(s => s.Mablag);
                                //q1[0].NerkhVa = q1[0].MeghdarVa != 0 ? q1[0].MablagVa / q1[0].MeghdarVa : 0;
                                decimal _MeghdarSa = q7.Where(s => s.NoeAmaliatCode == 3).Sum(s => s.Meghdar);
                                decimal _MablagSa = q7.Where(s => s.NoeAmaliatCode == 3).Sum(s => s.Mablag);
                                //q1[0].NerkhSa = q1[0].MeghdarSa != 0 ? q1[0].MablagSa / q1[0].MeghdarSa : 0;
                                q1[0].MeghdarMo_NM = _MeghdarMo - _MeghdarSa;
                                q1[0].MablagMo_NM = _MablagMo - _MablagSa;
                                q1[0].NerkhMo_NM = q1[0].MeghdarMo_NM != 0 ? q1[0].MablagMo_NM / q1[0].MeghdarMo_NM : 0;

                                q1[0].HesabTafsiliName_NM = "جمع مانده از قبل";
                                q1[0].SeryalCol_BeNoeAmaliat_BeSelectAnbar = 0;
                                q1[0].SabetAtefNumber = 0;

                                q1.RemoveRange(1, q7.Count - 1);

                                for (int i = 0; i < q1.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        q1[i].MeghdarMa_NM = q1[i].MeghdarMo_NM + q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i].MablagMo_NM + q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                    else
                                    {
                                        if (_FirstSelectAnbar_NextSanad)
                                        {
                                            q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                            q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                        }
                                        else
                                        {
                                            q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                            q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                        }
                                        q1[i].DateTimeSanadString_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).DateTimeSanad.ToString().Substring(0, 10);
                                        q1[i].AnbarName_NM = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;
                                        q1[i].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;
                                        q1[i].HesabTafsiliName_NM = q6.FirstOrDefault(s => s.Id == q1[i].HesabTafsili1Id).Name;
                                        if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 2))
                                        {
                                            q1[i].MeghdarVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Meghdar;
                                            q1[i].NerkhVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Nerkh;
                                            q1[i].MablagVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Mablag;
                                        }

                                        if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3))
                                        {
                                            q1[i].MeghdarSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Meghdar;
                                            q1[i].NerkhSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Nerkh;
                                            q1[i].MablagSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Mablag;
                                        }

                                        q1[i].MeghdarMa_NM = q1[i - 1].MeghdarMa_NM + q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i - 1].MablagMa_NM + q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < q1.Count; i++)
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                        q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                    }
                                    else
                                    {
                                        q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                        q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                    }
                                    q1[i].DateTimeSanadString_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).DateTimeSanad.ToString().Substring(0, 10);
                                    q1[i].AnbarName_NM = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;
                                    q1[i].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;
                                    q1[i].HesabTafsiliName_NM = q6.FirstOrDefault(s => s.Id == q1[i].HesabTafsili1Id).Name;
                                    if (q1.Any(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2))
                                    {
                                        q1[i].MeghdarVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Meghdar;
                                        q1[i].NerkhVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Nerkh;
                                        q1[i].MablagVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Mablag;
                                    }

                                    if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3))
                                    {
                                        q1[i].MeghdarSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Meghdar;
                                        q1[i].NerkhSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Nerkh;
                                        q1[i].MablagSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Mablag;
                                    }

                                    if (i == 0)
                                    {
                                        q1[i].MeghdarMa_NM = q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        //q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                    else
                                    {
                                        q1[i].MeghdarMa_NM = q1[i - 1].MeghdarMa_NM + q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i - 1].MablagMa_NM + q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        //q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (q7.Count > 0)
                            {
                                //AkAllAmaliateRozaneh obj = new AkAllAmaliateRozaneh();
                                q1[0].Id = 0;
                                q1[0].SeryalCol_NM = "0";
                                q1[0].SeryalJoze_NM = "0";
                                q1[0].DateTimeSanadString_NM = txtAzTarikh.Text;
                                q1[0].AnbarName_NM = cmbAnbarName.Text;
                                q1[0].NoeSanadText = "جمع مانده از قبل";
                                //q1[0].FactorNamber = 0;
                                q1[0].Radif = 0;
                                q1[0].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q7[0].VahedeKalaId).Name;
                                q1[0].MeghdarVa_NM = q7.Where(s =>  s.NoeAmaliatCode == 2).Sum(s => s.Meghdar);
                                q1[0].MablagVa_NM = q7.Where(s =>  s.NoeAmaliatCode == 2).Sum(s => s.Mablag);
                                q1[0].NerkhVa_NM = q1[0].MeghdarVa_NM != 0 ? q1[0].MablagVa_NM / q1[0].MeghdarVa_NM : 0;
                                q1[0].MeghdarSa_NM = q7.Where(s => s.NoeAmaliatCode == 3).Sum(s => s.Meghdar);
                                q1[0].MablagSa_NM = q7.Where(s => s.NoeAmaliatCode == 3).Sum(s => s.Mablag);
                                q1[0].NerkhSa_NM = q1[0].MeghdarSa_NM != 0 ? q1[0].MablagSa_NM / q1[0].MeghdarSa_NM : 0;
                                q1[0].HesabTafsiliName_NM = "جمع مانده از قبل";
                                q1[0].SeryalCol_BeNoeAmaliat_BeSelectAnbar = 0;
                                q1[0].SabetAtefNumber = 0;

                                q1.RemoveRange(1, q7.Count - 1);

                                for (int i = 0; i < q1.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        q1[i].MeghdarMa_NM = q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                    else
                                    {
                                        if (_FirstSelectAnbar_NextSanad)
                                        {
                                            q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                            q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                        }
                                        else
                                        {
                                            q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                            q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                        }
                                        q1[i].DateTimeSanadString_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).DateTimeSanad.ToString().Substring(0, 10);
                                        q1[i].AnbarName_NM = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;
                                        q1[i].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;
                                        q1[i].HesabTafsiliName_NM = q6.FirstOrDefault(s => s.Id == q1[i].HesabTafsili1Id).Name;
                                        if (q1.Any(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2))
                                        {
                                            q1[i].MeghdarVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Meghdar;
                                            q1[i].NerkhVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Nerkh;
                                            q1[i].MablagVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Mablag;
                                        }

                                        if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3))
                                        {
                                            q1[i].MeghdarSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Meghdar;
                                            q1[i].NerkhSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Nerkh;
                                            q1[i].MablagSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Mablag;
                                        }

                                        q1[i].MeghdarMa_NM = q1[i - 1].MeghdarMa_NM + q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i - 1].MablagMa_NM + q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < q1.Count; i++)
                                {
                                    if (_FirstSelectAnbar_NextSanad)
                                    {
                                        q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BaSelectAnbar.ToString();
                                        q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BaSelectAnbar.ToString();
                                    }
                                    else
                                    {
                                        q1[i].SeryalCol_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalCol_BaNoeAmaliat_BeSelectAnbar.ToString();
                                        q1[i].SeryalJoze_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).SeryalJoze_BaNoeSanad_BeSelectAnbar.ToString();
                                    }
                                    q1[i].DateTimeSanadString_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id).DateTimeSanad.ToString().Substring(0, 10);
                                    q1[i].AnbarName_NM = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;
                                    q1[i].VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;
                                    q1[i].HesabTafsiliName_NM = q6.FirstOrDefault(s => s.Id == q1[i].HesabTafsili1Id).Name;
                                    if (q1.Any(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2))
                                    {
                                        q1[i].MeghdarVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Meghdar;
                                        q1[i].NerkhVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Nerkh;
                                        q1[i].MablagVa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Mablag;
                                    }

                                    if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3))
                                    {
                                        q1[i].MeghdarSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Meghdar;
                                        q1[i].NerkhSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Nerkh;
                                        q1[i].MablagSa_NM = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Mablag;
                                    }

                                    if (i == 0)
                                    {
                                        q1[i].MeghdarMa_NM = q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        //q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                    else
                                    {
                                        q1[i].MeghdarMa_NM = q1[i - 1].MeghdarMa_NM + q1[i].MeghdarVa_NM - q1[i].MeghdarSa_NM;
                                        q1[i].MablagMa_NM = q1[i - 1].MablagMa_NM + q1[i].MablagVa_NM - q1[i].MablagSa_NM;
                                        //q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                                        q1[i].NerkhMa_NM = q1[i].MeghdarMa_NM != 0 ? q1[i].MablagMa_NM / q1[i].MeghdarMa_NM : 0;
                                    }
                                }
                            }
                        }

                        #region MyRegion
                        //DataTable dt = new DataTable();
                        //for (int ColumnCounter = 0; ColumnCounter < bandedGridView_MeghdariVRiali.Columns.Count; ColumnCounter++)
                        //    dt.Columns.Add(bandedGridView_MeghdariVRiali.Columns[ColumnCounter].FieldName);
                        //dt.Columns[0].DataType = typeof(decimal);
                        ////dt.Columns[1].DataType = typeof(decimal);
                        ////dt.Columns[2].DataType = typeof(decimal);
                        //dt.Columns[3].DataType = typeof(DateTime);
                        //dt.Columns[4].DataType = typeof(string);
                        //dt.Columns[5].DataType = typeof(string);
                        ////dt.Columns[6].DataType = typeof(int);
                        //dt.Columns[7].DataType = typeof(string);

                        //dt.Columns[8].DataType = typeof(decimal);
                        //dt.Columns[9].DataType = typeof(decimal);
                        //dt.Columns[10].DataType = typeof(decimal);
                        //dt.Columns[11].DataType = typeof(decimal);
                        //dt.Columns[12].DataType = typeof(decimal);
                        //dt.Columns[13].DataType = typeof(decimal);
                        //dt.Columns[14].DataType = typeof(decimal);
                        //dt.Columns[15].DataType = typeof(decimal);
                        //dt.Columns[16].DataType = typeof(decimal);
                        ////dt.Columns[17].DataType = typeof(decimal);
                        ////dt.Columns[18].DataType = typeof(decimal);
                        ////dt.Columns[19].DataType = typeof(decimal);

                        //for (int i = 0; i < q1.Count; i++)
                        //{
                        //    DataRow DataRow1 = dt.NewRow();
                        //    DataRow1.Table.Columns[0].DataType = typeof(decimal);
                        //    //DataRow1.Table.Columns[1].DataType = typeof(decimal);
                        //    //DataRow1.Table.Columns[2].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[3].DataType = typeof(DateTime);
                        //    DataRow1.Table.Columns[4].DataType = typeof(string);
                        //    DataRow1.Table.Columns[5].DataType = typeof(string);
                        //    //DataRow1.Table.Columns[6].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[7].DataType = typeof(string);

                        //    DataRow1.Table.Columns[8].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[9].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[10].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[11].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[12].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[13].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[14].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[15].DataType = typeof(decimal);
                        //    DataRow1.Table.Columns[16].DataType = typeof(decimal);
                        //    //DataRow1.Table.Columns[17].DataType = typeof(decimal);
                        //    //DataRow1.Table.Columns[18].DataType = typeof(decimal);
                        //    //DataRow1.Table.Columns[19].DataType = typeof(decimal);

                        //    DataRow1[0] = 0;
                        //    //DataRow1[1] = 0;
                        //    //DataRow1[2] = 0;
                        //    //DataRow1[3] = 0;
                        //    //DataRow1[4] = 0;
                        //    //DataRow1[5] = 0;
                        //    //DataRow1[6] = 0;
                        //    //DataRow1[7] = 0;
                        //    DataRow1[8] = 0;
                        //    DataRow1[9] = 0;
                        //    DataRow1[10] = 0;
                        //    DataRow1[11] = 0;
                        //    DataRow1[12] = 0;
                        //    DataRow1[13] = 0;
                        //    DataRow1[14] = 0;
                        //    DataRow1[15] = 0;
                        //    DataRow1[16] = 0;
                        //    //DataRow1[17] = 0;
                        //    //DataRow1[18] = 0;
                        //    //DataRow1[19] = 0;

                        //    DataRow1[0] = q1[i].Id;
                        //    DataRow1[1] = i + 1;
                        //    DataRow1[2] = q1[i].Seryal;
                        //    DataRow1[3] = DateTime.Now;
                        //    DataRow1[4] = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;

                        //    DataRow1[5] = q1[i].NoeSanadText;
                        //    DataRow1[6] = q1[i].Seryal;
                        //    DataRow1[7] = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;

                        //    //DataRow1[8] = q1.Where(s => s.KalaId == q1[i] && s.NoeAmaliatCode == 2).Sum(s => s.Meghdar);
                        //    //DataRow1[10] = q1.Where(s => s.KalaId == q1[i] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag);
                        //    //DataRow1[9] = q1.Where(s => s.KalaId == q1[i] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[i] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[i] && s.NoeAmaliatCode == 2).Sum(s => s.Meghdar) : 0;

                        //    DataRow1[8] = q1[i].NoeAmaliatCode == 1 || q1[i].NoeAmaliatCode == 2 ? q1[i].Meghdar : 0;
                        //    DataRow1[9] = q1[i].NoeAmaliatCode == 1 || q1[i].NoeAmaliatCode == 2 ? q1[i].Nerkh : 0;
                        //    DataRow1[10] = q1[i].NoeAmaliatCode == 1 || q1[i].NoeAmaliatCode == 2 ? q1[i].Mablag : 0;

                        //    DataRow1[11] = q1[i].NoeAmaliatCode == 3 ? q1[i].Meghdar : 0;
                        //    DataRow1[12] = q1[i].NoeAmaliatCode == 3 ? q1[i].Nerkh : 0;
                        //    DataRow1[13] = q1[i].NoeAmaliatCode == 3 ? q1[i].Mablag : 0;

                        //    //DataRow1[14] = q1[i].NoeAmaliatCode == 3 ? q1[i].Meghdar : 0;
                        //    //DataRow1[15] = q1[i].NoeAmaliatCode == 3 ? q1[i].Nerkh : 0;
                        //    //DataRow1[16] = q1[i].NoeAmaliatCode == 3 ? q1[i].Mablag : 0;

                        //    dt.Rows.Add(DataRow1);
                        //}
                        //ds.Tables.Add(dt); 
                        //BindingList bindingList = new BindingList(ds);
                        //BindingSource source = new BindingSource(bindingList, null);
                        //gridControl_AmaliatAddVaEdit.DataSource = source;

                        //DataTable DTable = new DataTable();
                        //BindingSource SBind = new BindingSource();
                        // SBind.DataSource = dt;
                        // DataGridViewBand ServersTable = new DataGridViewBand();

                        //bandedGridView_MeghdariVRiali.AutoGenerateColumns = false;
                        // bandedGridView_MeghdariVRiali.set = dt;

                        // ServersTable.DataSource = SBind;
                        // ServersTable.Refresh();

                        #endregion

                        //gridControl_MeghdariVRiali.DataSource = q1.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.Seryal);
                        amaliatAnbarVKala_RizsBindingSource.DataSource = q1.ToList();
                        //bandedGridView_MeghdariVRiali.Columns[0].DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                        //bandedGridView_MeghdariVRiali.Columns[0].DisplayFormat.FormatString = "" ;

                    }
                    else
                    {
                        amaliatAnbarVKala_RizsBindingSource.Clear();
                    }

                    #region MyRegion
                    //if (q1.Count > 0)
                    //{
                    //    int _AnbarId = Convert.ToInt32(item.Value);
                    //    var CheckedList = cmbAnbarName.Properties.Items.ToList();
                    //    if (CheckedList.Count > 0)
                    //    {
                    //        foreach (var item in CheckedList)
                    //        {
                    //            if (item.CheckState == CheckState.Unchecked)
                    //            {
                    //                int _AnbarId = Convert.ToInt32(item.Value);
                    //                var q2 = q1.Where(s => s.AzAnbarId == _AnbarId).ToList();
                    //                if (q2.Count > 0)
                    //                    q1 = q1.Except(q2).ToList();
                    //            }
                    //        }

                    //    }
                    //    else
                    //    {
                    //        amaliatAnbarVKala_RizsBindingSource.Clear();
                    //    }
                    //if (q1.Count > 0)
                    //{
                    //    for (int i = 0; i < q1.Count; i++)
                    //    {
                    //        q1[i].DateTimeSanad = DateTime.Now;
                    //        q1[i].AnbarName = q4.FirstOrDefault(s => s.Id == q1[i].AzAnbarId).Name;
                    //        q1[i].VahedKala = q5.FirstOrDefault(s => s.Id == q1[i].VahedeKalaId).Name;
                    //        q1[i].HesabTafsiliName = q6.FirstOrDefault(s => s.Id == q1[i].HesabTafsili1Id).Name;
                    //        if (q1.Any(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2))
                    //        {
                    //            q1[i].MeghdarVa = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Meghdar;
                    //            q1[i].NerkhVa = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Nerkh;
                    //            q1[i].MablagVa = q1.FirstOrDefault(s => s.Id == q1[i].Id &&  s.NoeAmaliatCode == 2).Mablag;
                    //        }

                    //        if (q1.Any(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3))
                    //        {
                    //            q1[i].MeghdarSa = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Meghdar;
                    //            q1[i].NerkhSa = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Nerkh;
                    //            q1[i].MablagSa = q1.FirstOrDefault(s => s.Id == q1[i].Id && s.NoeAmaliatCode == 3).Mablag;
                    //        }
                    //        if (i == 0)
                    //        {
                    //            q1[i].MeghdarMa = q1[i].MeghdarVa - q1[i].MeghdarSa;
                    //            q1[i].MablagMa = q1[i].MablagVa - q1[i].MablagSa;
                    //            q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                    //        }
                    //        else
                    //        {
                    //            q1[i].MeghdarMa = q1[i - 1].MeghdarMa + q1[i].MeghdarVa - q1[i].MeghdarSa;
                    //            q1[i].MablagMa = q1[i - 1].MablagMa + q1[i].MablagVa - q1[i].MablagSa;
                    //            q1[i].NerkhMa = q1[i].MablagMa / q1[i].MeghdarMa;
                    //        }
                    //    }

                    //    }
                    //else
                    //{
                    //    amaliatAnbarVKala_RizsBindingSource.Clear();
                    //} 
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public bool _chkIsEdgham = false;
        private void FrmKardeksKala_Load(object sender, EventArgs e)
        {
            if (cmbNoeGozaresh.SelectedIndex == -1)
                cmbNoeGozaresh.SelectedIndex = 0;

            chkIsEdgham.Checked = _chkIsEdgham;
            gridBand6.Visible = _chkIsEdgham;
            FillcmbAnbarName();
            //FillcmbKalaName();
            //FillbandedGridView();
            HelpClass1.DateTimeMask(txtAzTarikh);
            HelpClass1.DateTimeMask(txtTaTarikh);
            if (string.IsNullOrEmpty(txtAzTarikh.Text))
                using (var db = new MyContext())
                {
                    try
                    {
                        int _DoreMaliId = Convert.ToInt32(lblSalId.Text);
                        var q = db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == _DoreMaliId).StartDoreMali;
                        if (q != null)
                            txtAzTarikh.Text = q.ToString();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            if (string.IsNullOrEmpty(txtTaTarikh.Text))
                txtTaTarikh.Text = DateTime.Now.ToString();
            textEdit1.Focus();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillcmbAnbarName();
            cmbAnbarName.EditValue = 0;
            amaliatAnbarVKala_RizsBindingSource.Clear();
        }

        private void cmbKalaName_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void cmbKalaName_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            HelpClass1._IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }

        private void cmbKalaName_Enter(object sender, EventArgs e)
        {
            if (cmbKalaName.Text == "")
                cmbKalaName.ShowPopup();
        }

        private void btnReloadKalaName_Click(object sender, EventArgs e)
        {
            FillcmbKalaName();
            cmbKalaName.EditValue = 0;
            amaliatAnbarVKala_RizsBindingSource.Clear();
        }

        private void cmbAnbarName_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbAnbarName.EditValue != null && cmbAnbarName.EditValue.ToString() != "0" && cmbAnbarName.EditValue.ToString() != "")
            {
                FillcmbKalaName();

                if (cmbKalaName.EditValue != null && cmbKalaName.EditValue.ToString() != "0" && cmbKalaName.EditValue.ToString() != "")
                {
                    if (cmbKalaName.Text != "")
                    {
                        FillbandedGridView();
                        txtAzTarikh.Focus();
                    }
                    else
                    {
                        amaliatAnbarVKala_RizsBindingSource.Clear();
                        cmbKalaName.ShowPopup();
                        cmbKalaName.Focus();
                    }

                }
                else
                {
                    amaliatAnbarVKala_RizsBindingSource.Clear();
                    cmbKalaName.ShowPopup();
                    cmbKalaName.Focus();
                }
            }
        }

        private void cmbKalaName_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKalaName.EditValue != null && cmbKalaName.EditValue.ToString() != "0" && cmbKalaName.EditValue.ToString() != "")
            {
                if (cmbAnbarName.EditValue != null && cmbAnbarName.EditValue.ToString() != "0" && cmbAnbarName.EditValue.ToString() != "")
                {
                    FillbandedGridView();
                    txtAzTarikh.Focus();
                }
                else
                {
                    cmbAnbarName.ShowPopup();
                    cmbAnbarName.Focus();
                }
            }
        }

        private void bandedGridView_MeghdariVRiali_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //bandedGridView_MeghdariVRiali.IndicatorWidth = 60;
            // Handle this event to paint RowIndicator manually
            //DataGridViewBand view = sender as DataGridViewBand;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bandedGridView_MeghdariVRiali_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (bandedGridView_MeghdariVRiali == null || bandedGridView_MeghdariVRiali.RowCount == 0)
                return;
            decimal SumMeghdarVa = Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MeghdarMo_NM"].SummaryItem.SummaryValue) + Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MeghdarVa_NM"].SummaryItem.SummaryValue);
            decimal SumMeghdarSa = Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MeghdarSa_NM"].SummaryItem.SummaryValue);
            decimal _MeghdarMa = SumMeghdarVa - SumMeghdarSa;

            decimal SumMablagVa = Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MablagMo_NM"].SummaryItem.SummaryValue) + Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MablagVa_NM"].SummaryItem.SummaryValue);
            decimal SumMablagSa = Convert.ToDecimal(bandedGridView_MeghdariVRiali.Columns["MablagSa_NM"].SummaryItem.SummaryValue);
            decimal _MablagMa = SumMablagVa - SumMablagSa;

            var item = e.Item as GridColumnSummaryItem;

            if (item == null)
                return;
            else if (item.FieldName != "MeghdarMa_NM" && item.FieldName != "MablagMa_NM")
                return;

            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                if (item.FieldName == "MeghdarMa_NM")
                    e.TotalValue = _MeghdarMa;
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                if (item.FieldName == "MablagMa_NM")
                    e.TotalValue = _MablagMa;
        }

        bool _IsActiveRow = true;
        private void cmbAnbarName_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
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

            //if (!_IsActiveRow)
            //{
            //    e.Appearance.ForeColor = Color.Red;
            //    if (e.Header.Caption == "فعال" && e.DisplayText == "False")
            //        e.DisplayText = "خیر";
            //    if (e.Header.Caption == "فعال" && e.DisplayText == "True")
            //        e.DisplayText = "بله";
            //    if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "False")
            //        e.DisplayText = "خیر";
            //    if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "True")
            //        e.DisplayText = "بله";
            //}
            //else
            //{
            //    if (e.Header.Caption == "فعال" && e.DisplayText == "True")
            //        e.DisplayText = "بله";
            //    if (e.Header.Caption == "فعال" && e.DisplayText == "False")
            //        e.DisplayText = "خیر";
            //    if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "True")
            //        e.DisplayText = "بله";
            //    if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "False")
            //        e.DisplayText = "خیر";
            //}

        }

        private void cmbAnbarName_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }

        private void cmbNoeGozaresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoeGozaresh.SelectedIndex == 0)
            {
                bandedGridView_MeghdariVRiali.Columns[7].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[16].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[17].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[18].Visible = true;
            }
            else if (cmbNoeGozaresh.SelectedIndex == 1)
            {
                bandedGridView_MeghdariVRiali.Columns[7].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[16].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[17].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[18].Visible = false;

            }
            else if (cmbNoeGozaresh.SelectedIndex == 2)
            {
                bandedGridView_MeghdariVRiali.Columns[7].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[16].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[17].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[18].Visible = true;
            }

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAnbarName.Text) || Convert.ToInt32(cmbAnbarName.EditValue) == 0)
                cmbAnbarName.ShowPopup();
            else if (string.IsNullOrEmpty(cmbKalaName.Text) || Convert.ToInt32(cmbKalaName.EditValue) == 0)
                cmbKalaName.ShowPopup();
            else
                FillbandedGridView();
        }

        private void bandedGridView_MeghdariVRiali_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle == 0)
            {
                string RowIndex = View.GetRowCellDisplayText(e.RowHandle, View.Columns["SeryalCol_NM"]);
                if (RowIndex == "0")
                {
                    e.Appearance.ForeColor = Color.FromArgb(150, Color.Red);
                    //e.Appearance.BackColor2 = Color.White;
                }
            }
        }

        private void chkIsEdgham_CheckedChanged(object sender, EventArgs e)
        {
            _chkIsEdgham = chkIsEdgham.Checked ? true : false;
            gridBand6.Visible = _chkIsEdgham;
            btnDisplyList_Click(null, null);

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
                cmbAnbarName.ShowPopup();
        }
    }
}