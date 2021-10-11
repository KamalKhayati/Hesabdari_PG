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
using DBHesabdari_PG.Models.FK.Tanzimat;
using DevExpress.XtraGrid.Views.Grid;
using HelpClassLibrary;
using DBHesabdari_PG;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using KharidVaFroosh.Tanzimat;
using DevExpress.XtraTab;

namespace TanzimatSystem.Tanzimat
{
    public partial class FrmTanzimatSystem : DevExpress.XtraEditors.XtraForm
    {
        public FrmTanzimatSystem()
        {
            InitializeComponent();
        }

        public int _SalId = 0;
        public int _cmbId = 0;
        //public int _cmbId = 0;
        public int? _HesabMoinId = null;
        public int? _HesabTafsili1Id = null;
        public int? _HesabTafsili2Id = null;
        public int? _HesabTafsili3Id = null;
        public int _Code = 0;
        public string _Titel = string.Empty;
        public string _NameSanad = string.Empty;
        public string _HesabMoinName = null;
        public string _HesabTafsili1Name = null;
        public string _HesabTafsili2Name = null;
        public string _HesabTafsili3Name = null;
        public int _RowHandle = 0;
        public byte _IndexAghlamFactor = 0;

        public XtraTabControl XtraTabControl1;
        public GridView gridView1;
        public SimpleButton btnEdit;
        public SimpleButton btnReload;
        public SimpleButton btnSetingCopy;
        public SimpleButton btnOk;
        public LookUpEdit cmbControl1;
        public LookUpEdit cmbControl2;

        MyContext Mydb;
        private void FrmTanzimatSystem_Load(object sender, EventArgs e)
        {
            xtc_TanzimatSystem_SelectedPageChanged(null, null);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

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

        bool _IsActiveRow = true;

        private void cmbControl_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));

        }

        private void cmbControl_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbControl1.EditValue) == 0)
                cmbControl1.ShowPopup();

        }

        private void FrmTanzimatSystem_Shown(object sender, EventArgs e)
        {
            cmbNameAnbar1_1.Focus();
        }



        private void cmbControl_EditValueChanged(object sender, EventArgs e)
        {
            //FillCmbHesabMoin();
            _SalId = Convert.ToInt32(lblSalId.Text);
            _cmbId = Convert.ToInt32(cmbControl1.EditValue);
            //btnSave.Enabled = false;

            Mydb = new MyContext();
            {
                try
                {
                    if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_AnbarDarFactor)
                    {

                        var q5 = Mydb.EpListAnbarhas.Where(s => s.SalId == _SalId && s.Id != _cmbId).OrderBy(s => s.Code).ToList();
                        if (q5.Count > 0) epListAnbarhasBindingSource1_2.DataSource = q5; else epListAnbarhasBindingSource1_2.Clear();

                        var q = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                        if (q.Count == 0)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.IndexAghlamFactor = _IndexAghlamFactor;
                                obj.AnbarId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                obj.Titel = gridView1.GetRowCellValue(i, "Titel").ToString();
                                obj.Sharh = gridView1.GetRowCellValue(i, "Sharh").ToString();
                                //obj.HesabMoinId = 0;
                                //obj.HesabTafsili1Id = 0;
                                //obj.HesabTafsili2Id = 0;
                                //obj.HesabTafsili3Id = 0;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                Mydb.FKTanzimatFactors.AddRange(List);
                                Mydb.SaveChanges();
                                var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                                fktanzimatFactorsBindingSource_Kala.DataSource = q1.ToList();

                            }
                        }
                        else
                        {
                            var q_HesabMoin = Mydb.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                            var q_AllHesabTafsili = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                            foreach (var item in q)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != null ? q_HesabMoin.FirstOrDefault(s => s.Id == item.HesabMoinId).Name : null;
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name : null;
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili2Id).Name : null;
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili3Id).Name : null;

                            }
                            fktanzimatFactorsBindingSource_Kala.DataSource = q.ToList();
                        }

                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
                    {
                        var q5 = Mydb.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.NoeTabagheIndex == 1 && s.Id != _cmbId).OrderBy(s => s.Code).ToList();
                        if (q5.Count > 0) epNameKalasBindingSource_Khadamat1_2.DataSource = q5; else epNameKalasBindingSource_Khadamat1_2.Clear();

                        var q = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.KhadamatId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                        if (q.Count == 0)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.IndexAghlamFactor = _IndexAghlamFactor;
                                obj.KhadamatId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Titel = gridView1.GetRowCellValue(i, "Titel").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                obj.Sharh = gridView1.GetRowCellValue(i, "Sharh").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                Mydb.FKTanzimatFactors.AddRange(List);
                                Mydb.SaveChanges();
                                var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.KhadamatId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                                fktanzimatFactorsBindingSource1_Khadamat.DataSource = q1.ToList();
                            }
                        }
                        else
                        {
                            var q_HesabMoin = Mydb.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                            var q_AllHesabTafsili = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                            foreach (var item in q)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != null ? q_HesabMoin.FirstOrDefault(s => s.Id == item.HesabMoinId).Name : null;
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name : null;
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili2Id).Name : null;
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili3Id).Name : null;

                            }
                            fktanzimatFactorsBindingSource1_Khadamat.DataSource = q.ToList();
                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
                    {
                        var q5 = Mydb.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == 2 && s.Id != _cmbId).OrderBy(s => s.Code).ToList();
                        if (q5.Count > 0) fKTarifEz_Ks_FactorsBindingSource_Ezafat1_2.DataSource = q5; else fKTarifEz_Ks_FactorsBindingSource_Ezafat1_2.Clear();

                        var q = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                        if (q.Count == 0)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.IndexAghlamFactor = _IndexAghlamFactor;
                                obj.Ez_KsId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Titel = gridView1.GetRowCellValue(i, "Titel").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                obj.Sharh = gridView1.GetRowCellValue(i, "Sharh").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                Mydb.FKTanzimatFactors.AddRange(List);
                                Mydb.SaveChanges();
                                var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                                fKTanzimatFactorsBindingSource2_Ezafat.DataSource = q1.ToList();
                            }
                        }
                        else
                        {
                            var q_HesabMoin = Mydb.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                            var q_AllHesabTafsili = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                            foreach (var item in q)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != null ? q_HesabMoin.FirstOrDefault(s => s.Id == item.HesabMoinId).Name : null;
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name : null;
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili2Id).Name : null;
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili3Id).Name : null;

                            }
                            fKTanzimatFactorsBindingSource2_Ezafat.DataSource = q.ToList();
                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
                    {
                        var q5 = Mydb.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == 3 && s.Id != _cmbId).OrderBy(s => s.Code).ToList();
                        if (q5.Count > 0) fKTarifEz_Ks_FactorsBindingSource_Ksorat1_2.DataSource = q5; else fKTarifEz_Ks_FactorsBindingSource_Ksorat1_2.Clear();

                        var q = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                        if (q.Count == 0)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.IndexAghlamFactor = _IndexAghlamFactor;
                                obj.Ez_KsId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Titel = gridView1.GetRowCellValue(i, "Titel").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                obj.Sharh = gridView1.GetRowCellValue(i, "Sharh").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                Mydb.FKTanzimatFactors.AddRange(List);
                                Mydb.SaveChanges();
                                var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                                fKTanzimatFactorsBindingSource3_Ksorat.DataSource = q1.ToList();
                            }
                        }
                        else
                        {
                            var q_HesabMoin = Mydb.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                            var q_AllHesabTafsili = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                            foreach (var item in q)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != null ? q_HesabMoin.FirstOrDefault(s => s.Id == item.HesabMoinId).Name : null;
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name : null;
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili2Id).Name : null;
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili3Id).Name : null;

                            }
                            fKTanzimatFactorsBindingSource3_Ksorat.DataSource = q.ToList();
                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vizitor)
                    {
                        var q5 = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupIndex == 0 && s.EpHesabTafsiliAshkhas1.IsVizitor == true && s.Id != _cmbId).OrderBy(s => s.Code).ToList();
                        if (q5.Count > 0) epAllHesabTafsilisBindingSource_Vizitor1_2.DataSource = q5; else epAllHesabTafsilisBindingSource_Vizitor1_2.Clear();

                        var q = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.VizitorId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                        if (q.Count == 0)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.IndexAghlamFactor = _IndexAghlamFactor;
                                obj.VizitorId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Titel = gridView1.GetRowCellValue(i, "Titel").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                obj.Sharh = gridView1.GetRowCellValue(i, "Sharh").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                Mydb.FKTanzimatFactors.AddRange(List);
                                Mydb.SaveChanges();
                                var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.VizitorId == _cmbId && s.IndexAghlamFactor == _IndexAghlamFactor).ToList();
                                fKTanzimatFactorsBindingSource5_Vizitor.DataSource = q1;
                            }
                        }
                        else
                        {
                            var q_HesabMoin = Mydb.EpHesabMoin1s.Where(s => s.SalId == _SalId).ToList();
                            var q_AllHesabTafsili = Mydb.EpAllHesabTafsilis.Where(s => s.SalId == _SalId).ToList();
                            foreach (var item in q)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != null ? q_HesabMoin.FirstOrDefault(s => s.Id == item.HesabMoinId).Name : null;
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili1Id).Name : null;
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili2Id).Name : null;
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != null ? q_AllHesabTafsili.FirstOrDefault(s => s.Id == item.HesabTafsili3Id).Name : null;

                            }
                            fKTanzimatFactorsBindingSource5_Vizitor.DataSource = q.ToList();
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

        private void xtc_TanzimatSystem_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtc_TanzimatSystem.SelectedTabPage == xtp_FKTanzimatFactor)
            {
                xtc_FKTanzimatFactor_SelectedPageChanged(null, null);
            }
            else if (xtc_TanzimatSystem.SelectedTabPage == xtp_TanzimatAnbar)
            {

            }
        }

        public void FillCmbControl()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_AnbarDarFactor)
                    {
                        var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epListAnbarhasBindingSource1_1.DataSource = q1; else epListAnbarhasBindingSource1_1.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
                    {
                        var q1 = db.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.NoeTabagheIndex == 1).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epNameKalasBindingSource_Khadamat1_1.DataSource = q1; else epNameKalasBindingSource_Khadamat1_1.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
                    {
                        var q1 = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == 2).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) fKTarifEz_Ks_FactorsBindingSource_Ezafat1_1.DataSource = q1; else fKTarifEz_Ks_FactorsBindingSource_Ezafat1_1.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
                    {
                        var q1 = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == 3).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) fKTarifEz_Ks_FactorsBindingSource_Ksorat1_1.DataSource = q1; else fKTarifEz_Ks_FactorsBindingSource_Ksorat1_1.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vizitor)
                    {
                        var q1 = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupIndex == 0 && s.EpHesabTafsiliAshkhas1.IsVizitor == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epAllHesabTafsilisBindingSource_Vizitor1_1.DataSource = q1; else epAllHesabTafsilisBindingSource_Vizitor1_1.Clear();
                    }


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void xtc_FKTanzimatFactor_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl1 = xtc_FKTanzimatFactor;
            _IndexAghlamFactor = Convert.ToByte(XtraTabControl1.SelectedTabPageIndex);

            if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_AnbarDarFactor)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbNameAnbar1_1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید کالا", Code = 101, Titel = "بدهکاری خرید", Sharh = "حساب موجودی انبار بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید کالا", Code = 102, Titel = "بستانکاری خرید", Sharh = "حسابهای پرداختنی بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید کالا", Code = 201, Titel = "بدهکاری برگشت از خرید", Sharh = "حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید کالا", Code = 202, Titel = "بستانکاری برگشت از خرید", Sharh = "حساب انحراف نرخ برگشت از خرید بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید کالا", Code = 203, Titel = "بدهکاری بهای تمام شده برگشت", Sharh = "حساب انحراف نرخ برگشت از خرید بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید کالا", Code = 204, Titel = "بستانکاری بهای تمام شده برگشت", Sharh = "حساب موجودی انبار بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 301, Titel = "بدهکاری فروش", Sharh = "حسابهای دریافتنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 302, Titel = "بستانکاری فروش داخلی", Sharh = "فروش کالای داخلی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 303, Titel = "بستانکاری فروش صادراتی", Sharh = "فروش کالای صادراتی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 304, Titel = "بدهکاری بهای تمام شده فروش داخلی", Sharh = "بهای تمام شده کالای فروش رفته داخلی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 305, Titel = "بدهکاری بهای تمام شده فروش صادراتی", Sharh = "بهای تمام شده کالای فروش رفته صادراتی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش کالا", Code = 306, Titel = "بستانکاری بهای تمام شده فروش", Sharh = "حساب موجودی انبار بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 401, Titel = "بدهکاری برگشت از فروش داخلی", Sharh = "حساب برگشت از فروش و تخفیفات داخلی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 402, Titel = "بدهکاری برگشت از فروش صادراتی", Sharh = "حساب برگشت از فروش و تخفیفات صادراتی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 403, Titel = "بستانکاری برگشت از فروش", Sharh = "حسابهای دریافتنی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 404, Titel = "بدهکاری بهای تمام شده برگشت", Sharh = "حساب موجودی انبار بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 405, Titel = "بستانکاری بهای تمام شده برگشت داخلی", Sharh = "بهای تمام شده کالای فروش رفته داخلی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 406, Titel = "بستانکاری بهای تمام شده برگشت صادراتی", Sharh = "بهای تمام شده کالای فروش رفته صادراتی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش کالا", Code = 407, Titel = "انحراف نرخ برگشت از فروش", Sharh = "انحراف نرخ برگشت از فروش با توجه به مابه التفاوت قیمت فروش و میانگین، بدهکار یا بستانکار میشود" });

                    fktanzimatFactorsBindingSource_Kala.DataSource = list.ToList();

                }
                cmbControl1 = cmbNameAnbar1_1;
                gridView1 = gridView1_1;
                btnEdit = btnEdit1_1;
                btnReload = btnReloadNameAnbar1_1;
                btnSetingCopy = btnSetingCopy1_1;
                cmbControl2 = cmbNameAnbar1_2;
                btnOk = btnOk1_1;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeKhadamat1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید خدمات", Code = 101, Titel = "بدهکاری خرید", Sharh = "حساب هزینه بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید خدمات", Code = 102, Titel = "بستانکاری خرید", Sharh = "حسابهای پرداختنی بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید خدمات", Code = 201, Titel = "بدهکاری برگشت از خرید", Sharh = "حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید خدمات", Code = 202, Titel = "بستانکاری برگشت از خرید", Sharh = "حساب هزینه بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 301, Titel = "بدهکاری فروش", Sharh = "حسابهای دریافتنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 302, Titel = "بستانکاری فروش داخلی", Sharh = "حساب فروش خدمات داخلی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 303, Titel = "بستانکاری فروش خارجی", Sharh = "حساب فروش خدمات خارجی بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 401, Titel = "بدهکاری برگشت از فروش داخلی", Sharh = "حساب برگشت از فروش خدمات داخلی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 402, Titel = "بدهکاری برگشت از فروش خارجی", Sharh = "حساب برگشت از فروش خدمات خارجی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 403, Titel = "بستانکاری برگشت از فروش", Sharh = "حسابهای دریافتنی بستانکار میشود" });

                    fktanzimatFactorsBindingSource1_Khadamat.DataSource = list.ToList();

                }
                cmbControl1 = cmbCodeKhadamat1;
                gridView1 = gridView1_2;
                btnEdit = btnEdit1_2;
                btnReload = btnReloadCodeKhadamat;
                btnSetingCopy = btnSetingCopy1_2;
                cmbControl2 = cmbCodeKhadamat2;
                btnOk = btnOk1_2;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeEzafat1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 101, Titel = "بدهکاری خرید", Sharh = "حساب سایر هزینه ها بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 102, Titel = "بستانکاری خرید", Sharh = "حسابهای پرداختنی بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 201, Titel = "بدهکاری برگشت از خرید", Sharh = "حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 202, Titel = "بستانکاری برگشت از خرید", Sharh = "حساب سایر هزینه ها بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Titel = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 301, Titel = "بدهکاری فروش", Sharh = "حسابهای دریافتنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 302, Titel = "بستانکاری فروش داخلی", Sharh = "حساب سایر درآمدهای داخلی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 303, Titel = "بستانکاری فروش خارجی", Sharh = "حساب سایر درآمدهای خارجی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Titel = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Titel = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Titel = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Titel = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 401, Titel = "بدهکاری برگشت از فروش داخلی", Sharh = "حساب سایر درآمدهای داخلی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 402, Titel = "بدهکاری برگشت از فروش خارجی", Sharh = "حساب سایر درآمدهای خارجی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 403, Titel = "بستانکاری برگشت از فروش", Sharh = "حسابهای دریافتنی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Titel = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Titel = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Titel = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Titel = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Titel = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource2_Ezafat.DataSource = list.ToList();

                }
                cmbControl1 = cmbCodeEzafat1;
                gridView1 = gridView1_3;
                btnEdit = btnEdit1_3;
                btnReload = btnReloadEzafat;
                btnSetingCopy = btnSetingCopy1_3;
                cmbControl2 = cmbCodeEzafat2;
                btnOk = btnOk1_3;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeKsorat1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 101, Titel = "بدهکاری خرید", Sharh = "حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 102, Titel = "بستانکاری خرید", Sharh = "حساب تخفیف خرید/اشانتیون بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 201, Titel = "بدهکاری برگشت از خرید", Sharh = "حساب تخفیف خرید/اشانتیون بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 202, Titel = "بستانکاری برگشت از خرید", Sharh = "حسابهای پرداختنی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Titel = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 301, Titel = "بدهکاری فروش داخلی", Sharh = "حساب تخفیف فروش/اشانتیون داخلی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 302, Titel = "بدهکاری فروش خارجی", Sharh = "حساب تخفیف فروش/اشانتیون خارجی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 303, Titel = "بستانکاری فروش", Sharh = "حسابهای دریافتنی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Titel = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Titel = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Titel = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Titel = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 401, Titel = "بدهکاری برگشت از فروش", Sharh = "حسابهای دریافتنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 402, Titel = "بستانکاری برگشت از فروش داخلی", Sharh = "حساب تخفیف فروش/اشانتیون داخلی بستانکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 403, Titel = "بستانکاری برگشت از فروش خارجی", Sharh = "حساب تخفیف فروش/اشانتیون خارجی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Titel = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Titel = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Titel = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Titel = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Titel = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource3_Ksorat.DataSource = list.ToList();

                }
                cmbControl1 = cmbCodeKsorat1;
                gridView1 = gridView1_4;
                btnEdit = btnEdit1_4;
                btnReload = btnReloadKsorat;
                btnSetingCopy = btnSetingCopy1_4;
                cmbControl2 = cmbCodeKsorat2;
                btnOk = btnOk1_4;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vizitor)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbVizitor1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 101, Titel = "بدهکاری خرید", Sharh = "حساب هزینه پورسانت بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 102, Titel = "بستانکاری خرید", Sharh = "سایر حسابهای پرداختنی بستانکار میشود" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 201, Titel = "بدهکاری برگشت از خرید", Sharh = "سایر حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 202, Titel = "بستانکاری برگشت از خرید", Sharh = "حساب هزینه پورسانت بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Titel = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 301, Titel = "بدهکاری فروش", Sharh = "حساب هزینه پورسانت بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 302, Titel = "بستانکاری فروش", Sharh = "سایر حسابهای پرداختنی بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Titel = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Titel = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Titel = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Titel = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 401, Titel = "بدهکاری برگشت از فروش", Sharh = "سایر حسابهای پرداختنی بدهکار میشود" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 402, Titel = "بستانکاری برگشت از فروش", Sharh = "حساب هزینه پورسانت بستانکار میشود" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Titel = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Titel = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Titel = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Titel = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Titel = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource5_Vizitor.DataSource = list.ToList();

                }
                cmbControl1 = cmbVizitor1;
                gridView1 = gridView1_5;
                btnEdit = btnEdit1_5;
                btnReload = btnReloadVzitor;
                btnSetingCopy = btnSetingCopy1_5;
                cmbControl2 = cmbVizitor2;
                btnOk = btnOk1_5;
            }

            cmbControl1.Focus();

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int _Code = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code").ToString());
                btnEdit.Enabled = true;

            }
            catch (Exception)
            {
                btnEdit.Enabled = false;
                //XtraMessageBox.Show("لطفاً روی زیر گروه مربوطه کلیک کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit1_Click(null, null);
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbControl1.EditValue) > 0)
            {
                _RowHandle = gridView1.FocusedRowHandle;
                _SalId = Convert.ToInt32(lblSalId.Text);
                _cmbId = Convert.ToInt32(cmbControl1.EditValue);
                _HesabMoinId = null;
                _HesabTafsili1Id = null;
                _HesabTafsili2Id = null;
                _HesabTafsili3Id = null;

                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("HesabMoinId"))) _HesabMoinId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId"));
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("HesabTafsili1Id"))) _HesabTafsili1Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili1Id"));
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("HesabTafsili2Id"))) _HesabTafsili2Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili2Id"));
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellDisplayText("HesabTafsili3Id"))) _HesabTafsili3Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili3Id"));
                _Code = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code")) != 0 ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code")) : 0;
                _Titel = gridView1.GetFocusedRowCellDisplayText("Titel") != null ? gridView1.GetFocusedRowCellDisplayText("Titel").ToString() : "";
                _NameSanad = gridView1.GetFocusedRowCellDisplayText("NameSanad") != null ? gridView1.GetFocusedRowCellDisplayText("NameSanad").ToString() : "";

                FrmSelectFKTanzimatFactor fm = new FrmSelectFKTanzimatFactor(this);
                //fm.MdiParent = this;
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                //fm.Name = "FrmFactorFroosh";
                //fm.Text = "فاکتور فروش";
                //fm.cmbNameSanad.SelectedIndex = 0;
                //fm.En1 = EnumCED.Create;
                fm.ShowDialog();
            }
        }

        private void btnReloadCmbControl_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            FillCmbControl();
        }

        private void btnSetingCopy_Click(object sender, EventArgs e)
        {
            cmbControl2.Visible = btnOk.Visible = (cmbControl2.Visible = btnOk.Visible == false) ? cmbControl2.Visible = btnOk.Visible = true : cmbControl2.Visible = btnOk.Visible = false;
            if (cmbControl2.Visible == true)
                cmbControl2.ShowPopup();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Mydb = new MyContext();
            {
                try
                {
                    if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_AnbarDarFactor)
                    {
                        int _cmbId1 = Convert.ToInt32(cmbControl1.EditValue);
                        int _cmbId2 = Convert.ToInt32(cmbControl2.EditValue);
                        if (_cmbId2 != 0)
                        {
                            var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _cmbId2).OrderBy(s => s.Code).ToList();
                            var q2 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _cmbId1).OrderBy(s => s.Code).ToList();
                            var q5 = Mydb.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _cmbId1);
                            if (q1.Count > 0)
                            {
                                foreach (var item in q1)
                                {
                                    var q3 = q2.FirstOrDefault(s => s.Code == item.Code);
                                    if (q3 != null)
                                    {
                                        if (q3.Code == 101 || q3.Code == 204 || q3.Code == 306 || q3.Code == 404)
                                        {
                                            q3.HesabMoinId = q5.MoinId;
                                            q3.HesabTafsili1Id = q5.TafsiliId1;
                                            q3.HesabTafsili2Id = q5.TafsiliId2;
                                            q3.HesabTafsili3Id = q5.TafsiliId3;
                                            //q3.HesabMoinId = 0;
                                            //q3.HesabTafsili1Id = 0;
                                            //q3.HesabTafsili2Id = 0;
                                            //q3.HesabTafsili3Id = 0;
                                            //q3.HesabMoinName_NM = string.Empty;
                                            //q3.HesabTafsili1Name_NM = string.Empty;
                                            //q3.HesabTafsili2Name_NM = string.Empty;
                                            //q3.HesabTafsili3Name_NM = string.Empty;
                                        }
                                        else
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = item.HesabTafsili3Id;
                                        }
                                    }
                                }
                                Mydb.SaveChanges();
                                cmbControl_EditValueChanged(null, null);
                            }

                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
                    {
                        int _cmbId1 = Convert.ToInt32(cmbControl1.EditValue);
                        int _cmbId2 = Convert.ToInt32(cmbControl2.EditValue);
                        if (_cmbId2 != 0)
                        {
                            var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.KhadamatId == _cmbId2).OrderBy(s => s.Code).ToList();
                            var q2 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.KhadamatId == _cmbId1).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                            {
                                foreach (var item in q1)
                                {
                                    var q3 = q2.FirstOrDefault(s => s.Code == item.Code);
                                    if (q3 != null)
                                    {
                                        if (q3.Code == 101 || q3.Code == 202)
                                        {
                                            q3.HesabMoinId = null;
                                            q3.HesabTafsili1Id = null;
                                            q3.HesabTafsili2Id = null;
                                            q3.HesabTafsili3Id = null;
                                            q3.HesabMoinName_NM = string.Empty;
                                            q3.HesabTafsili1Name_NM = string.Empty;
                                            q3.HesabTafsili2Name_NM = string.Empty;
                                            q3.HesabTafsili3Name_NM = string.Empty;
                                        }
                                        else
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = item.HesabTafsili3Id;
                                        }
                                    }
                                }
                                Mydb.SaveChanges();
                                cmbControl_EditValueChanged(null, null);
                            }

                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
                    {
                        int _cmbId1 = Convert.ToInt32(cmbControl1.EditValue);
                        int _cmbId2 = Convert.ToInt32(cmbControl2.EditValue);
                        if (_cmbId2 != 0)
                        {
                            var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId2).OrderBy(s => s.Code).ToList();
                            var q2 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId1).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                            {
                                foreach (var item in q1)
                                {
                                    var q3 = q2.FirstOrDefault(s => s.Code == item.Code);
                                    if (q3 != null)
                                    {
                                        //if (q3.Code == 501 || q3.Code == 552 )
                                        //{
                                        //    q3.HesabMoinId = 0;
                                        //    q3.HesabTafsili1Id = 0;
                                        //    q3.HesabTafsili2Id = 0;
                                        //    q3.HesabTafsili3Id = 0;
                                        //    q3.HesabMoinName_NM = string.Empty;
                                        //    q3.HesabTafsili1Name_NM = string.Empty;
                                        //    q3.HesabTafsili2Name_NM = string.Empty;
                                        //    q3.HesabTafsili3Name_NM = string.Empty;
                                        //}
                                        //else
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = item.HesabTafsili3Id;
                                        }
                                    }
                                }
                                Mydb.SaveChanges();
                                cmbControl_EditValueChanged(null, null);
                            }

                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
                    {
                        int _cmbId1 = Convert.ToInt32(cmbControl1.EditValue);
                        int _cmbId2 = Convert.ToInt32(cmbControl2.EditValue);
                        if (_cmbId2 != 0)
                        {
                            var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId2).OrderBy(s => s.Code).ToList();
                            var q2 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId1).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                            {
                                foreach (var item in q1)
                                {
                                    var q3 = q2.FirstOrDefault(s => s.Code == item.Code);
                                    if (q3 != null)
                                    {
                                        //if (q3.Code == 702 || q3.Code == 751 )
                                        //{
                                        //    q3.HesabMoinId = 0;
                                        //    q3.HesabTafsili1Id = 0;
                                        //    q3.HesabTafsili2Id = 0;
                                        //    q3.HesabTafsili3Id = 0;
                                        //    q3.HesabMoinName_NM = string.Empty;
                                        //    q3.HesabTafsili1Name_NM = string.Empty;
                                        //    q3.HesabTafsili2Name_NM = string.Empty;
                                        //    q3.HesabTafsili3Name_NM = string.Empty;
                                        //}
                                        //else
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = item.HesabTafsili3Id;
                                        }
                                    }
                                }
                                Mydb.SaveChanges();
                                cmbControl_EditValueChanged(null, null);
                            }

                        }
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vizitor)
                    {
                        int _cmbId1 = Convert.ToInt32(cmbControl1.EditValue);
                        int _cmbId2 = Convert.ToInt32(cmbControl2.EditValue);
                        if (_cmbId2 != 0)
                        {
                            var q1 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.VizitorId == _cmbId2).OrderBy(s => s.Code).ToList();
                            var q2 = Mydb.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.VizitorId == _cmbId1).OrderBy(s => s.Code).ToList();
                            var q5 = Mydb.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.SalId == _SalId && s.Id == _cmbId1 && s.IsVizitor == true).LevelNumber;
                            if (q1.Count > 0)
                            {
                                foreach (var item in q1)
                                {
                                    var q3 = q2.FirstOrDefault(s => s.Code == item.Code);
                                    if (q3 != null)
                                    {
                                        if (q3.Code == 102 || q3.Code == 201 || q3.Code == 302 || q3.Code == 401)
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = q5 == 1 ? _cmbId1 : item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = q5 == 2 ? _cmbId1 : item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = q5 == 3 ? _cmbId1 : item.HesabTafsili3Id;

                                            //q3.HesabMoinId = 0;
                                            //q3.HesabTafsili1Id = 0;
                                            //q3.HesabTafsili2Id = 0;
                                            //q3.HesabTafsili3Id = 0;
                                            //q3.HesabMoinName_NM = string.Empty;
                                            //q3.HesabTafsili1Name_NM = string.Empty;
                                            //q3.HesabTafsili2Name_NM = string.Empty;
                                            //q3.HesabTafsili3Name_NM = string.Empty;
                                        }
                                        else
                                        {
                                            q3.HesabMoinId = item.HesabMoinId; ;
                                            q3.HesabTafsili1Id = item.HesabTafsili1Id;
                                            q3.HesabTafsili2Id = item.HesabTafsili2Id;
                                            q3.HesabTafsili3Id = item.HesabTafsili3Id;
                                        }
                                    }
                                }
                                Mydb.SaveChanges();
                                cmbControl_EditValueChanged(null, null);
                            }

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

        private void FrmTanzimatSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Mydb!=null)
            {
                Mydb.Dispose();
            }
        }
    }
}