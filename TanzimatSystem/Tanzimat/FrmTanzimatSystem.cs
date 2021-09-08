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
        public int _HesabMoinId = 0;
        public int _HesabTafsili1Id = 0;
        public int _HesabTafsili2Id = 0;
        public int _HesabTafsili3Id = 0;
        public int _Code = 0;
        public string _Name = string.Empty;
        public string _NameSanad = string.Empty;
        public string _HesabMoinName = string.Empty;
        public string _HesabTafsili1Name = string.Empty;
        public string _HesabTafsili2Name = string.Empty;
        public string _HesabTafsili3Name = string.Empty;
        public int _RowHandle = 0;
        public byte _NoeAghlam = 0;

        public XtraTabControl XtraTabControl1;
        public GridView gridView1;
        public SimpleButton btnEdit;
        public SimpleButton btnReload;
        public LookUpEdit cmbControl;

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
            if (Convert.ToInt32(cmbControl.EditValue) == 0)
                cmbControl.ShowPopup();

        }

        private void FrmTanzimatSystem_Shown(object sender, EventArgs e)
        {
            cmbNameAnbar1_1.Focus();
        }



        private void cmbControl_EditValueChanged(object sender, EventArgs e)
        {
            //FillCmbHesabMoin();
            _SalId = Convert.ToInt32(lblSalId.Text);
            _cmbId = Convert.ToInt32(cmbControl.EditValue);
            //btnSave.Enabled = false;

            using (var db = new MyContext())
            {
                try
                {
                    if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Anbar)
                    {
                        var q = db.FKTanzimatFactors.Any(s => s.SalId == _SalId && s.AnbarId == _cmbId && s.NoeAghlam == _NoeAghlam);
                        if (!q)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.NoeAghlam = _NoeAghlam;
                                obj.AnbarId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Name = gridView1.GetRowCellValue(i, "Name").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                //obj.HesabMoinId = 0;
                                //obj.HesabTafsili1Id = 0;
                                //obj.HesabTafsili2Id = 0;
                                //obj.HesabTafsili3Id = 0;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                db.FKTanzimatFactors.AddRange(List);
                                db.SaveChanges();

                            }
                        }
                        else
                        {
                            var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _cmbId && s.NoeAghlam == _NoeAghlam).ToList();
                            foreach (var item in qq)
                            {
                                item.HesabMoinName_NM = item.HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabMoinId).LevelName : "";
                                item.HesabTafsili1Name_NM = item.HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili1Id).Name : "";
                                item.HesabTafsili2Name_NM = item.HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili2Id).Name : "";
                                item.HesabTafsili3Name_NM = item.HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili3Id).Name : "";

                            }
                            fktanzimatFactorsBindingSource_Kala.DataSource = qq.ToList();
                        }

                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
                    {
                        var q = db.FKTanzimatFactors.Any(s => s.SalId == _SalId && s.KhadamatId == _cmbId && s.NoeAghlam == _NoeAghlam);
                        if (!q)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.NoeAghlam = _NoeAghlam;
                                obj.KhadamatId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Name = gridView1.GetRowCellValue(i, "Name").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                db.FKTanzimatFactors.AddRange(List);
                                db.SaveChanges();

                            }
                        }

                        var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.KhadamatId == _cmbId && s.NoeAghlam == _NoeAghlam).ToList();
                        foreach (var item in qq)
                        {
                            item.HesabMoinName_NM = item.HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabMoinId).LevelName : "";
                            item.HesabTafsili1Name_NM = item.HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili1Id).Name : "";
                            item.HesabTafsili2Name_NM = item.HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili2Id).Name : "";
                            item.HesabTafsili3Name_NM = item.HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili3Id).Name : "";

                        }
                        fktanzimatFactorsBindingSource1_Khadamat.DataSource = qq.ToList();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
                    {
                        var q = db.FKTanzimatFactors.Any(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.NoeAghlam == _NoeAghlam);
                        if (!q)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.NoeAghlam = _NoeAghlam;
                                obj.Ez_KsId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Name = gridView1.GetRowCellValue(i, "Name").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                db.FKTanzimatFactors.AddRange(List);
                                db.SaveChanges();

                            }
                        }

                        var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.NoeAghlam == _NoeAghlam).ToList();
                        foreach (var item in qq)
                        {
                            item.HesabMoinName_NM = item.HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabMoinId).LevelName : "";
                            item.HesabTafsili1Name_NM = item.HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili1Id).Name : "";
                            item.HesabTafsili2Name_NM = item.HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili2Id).Name : "";
                            item.HesabTafsili3Name_NM = item.HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili3Id).Name : "";

                        }
                        fKTanzimatFactorsBindingSource2_Ezafat.DataSource = qq.ToList();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
                    {
                        var q = db.FKTanzimatFactors.Any(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.NoeAghlam == _NoeAghlam);
                        if (!q)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.NoeAghlam = _NoeAghlam;
                                obj.Ez_KsId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Name = gridView1.GetRowCellValue(i, "Name").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                db.FKTanzimatFactors.AddRange(List);
                                db.SaveChanges();

                            }
                        }

                        var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.Ez_KsId == _cmbId && s.NoeAghlam == _NoeAghlam).ToList();
                        foreach (var item in qq)
                        {
                            item.HesabMoinName_NM = item.HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabMoinId).LevelName : "";
                            item.HesabTafsili1Name_NM = item.HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili1Id).Name : "";
                            item.HesabTafsili2Name_NM = item.HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili2Id).Name : "";
                            item.HesabTafsili3Name_NM = item.HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili3Id).Name : "";

                        }
                        fKTanzimatFactorsBindingSource3_Ksorat.DataSource = qq.ToList();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vasete)
                    {
                        var q = db.FKTanzimatFactors.Any(s => s.SalId == _SalId && s.VizitorId == _cmbId && s.NoeAghlam == _NoeAghlam);
                        if (!q)
                        {
                            List<FKTanzimatFactor> List = new List<FKTanzimatFactor>();
                            for (int i = 0; i < gridView1.RowCount - 4; i++)
                            {
                                FKTanzimatFactor obj = new FKTanzimatFactor();
                                obj.SalId = _SalId;
                                obj.NoeAghlam = _NoeAghlam;
                                obj.VizitorId = _cmbId;
                                obj.Code = Convert.ToInt32(gridView1.GetRowCellValue(i, "Code"));
                                obj.Name = gridView1.GetRowCellValue(i, "Name").ToString();
                                obj.NameSanad = gridView1.GetRowCellValue(i, "NameSanad").ToString();
                                //obj.HesabMoinId = _HesabMoinId;
                                //obj.HesabTafsili1Id = _HesabTafsili1Id;
                                //obj.HesabTafsili2Id = _HesabTafsili2Id;
                                //obj.HesabTafsili3Id = _HesabTafsili3Id;
                                List.Add(obj);
                            }
                            if (List.Count > 0)
                            {
                                db.FKTanzimatFactors.AddRange(List);
                                db.SaveChanges();

                            }
                        }

                        var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.VizitorId == _cmbId && s.NoeAghlam == _NoeAghlam).ToList();
                        foreach (var item in qq)
                        {
                            item.HesabMoinName_NM = item.HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabMoinId).LevelName : "";
                            item.HesabTafsili1Name_NM = item.HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili1Id).Name : "";
                            item.HesabTafsili2Name_NM = item.HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili2Id).Name : "";
                            item.HesabTafsili3Name_NM = item.HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.Id == item.HesabTafsili3Id).Name : "";

                        }
                        fKTanzimatFactorsBindingSource5_Vizitor.DataSource = qq.ToList();
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

                    if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Anbar)
                    {
                        var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epListAnbarhasBindingSource.DataSource = q1; else epListAnbarhasBindingSource.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
                    {
                        var q1 = db.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.NoeTabagheIndex == 1).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epNameKalasBindingSource.DataSource = q1; else epNameKalasBindingSource.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
                    {
                        var q1 = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == _NoeAghlam).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) fKTarifEz_Ks_FactorsBindingSource_Ezafat.DataSource = q1; else fKTarifEz_Ks_FactorsBindingSource_Ezafat.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
                    {
                        var q1 = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == _NoeAghlam).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) fKTarifEz_Ks_FactorsBindingSource1_Ksorat.DataSource = q1; else fKTarifEz_Ks_FactorsBindingSource1_Ksorat.Clear();
                    }
                    else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vasete)
                    {
                        var q1 = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupIndex==0 && s.EpHesabTafsiliAshkhas1.IsVizitor==true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0) epAllHesabTafsilisBindingSource.DataSource = q1; else epAllHesabTafsilisBindingSource.Clear();
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
            _NoeAghlam =Convert.ToByte(XtraTabControl1.SelectedTabPageIndex + 1);

            if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Anbar)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbNameAnbar1_1.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید", Code = 101, Name = "بدهکاری خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید", Code = 102, Name = "بستانکاری خرید" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید", Code = 151, Name = "بدهکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید", Code = 152, Name = "بستانکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید", Code = 153, Name = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 201, Name = "بدهکاری فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 202, Name = "بستانکاری فروش داخلی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 203, Name = "بستانکاری فروش صادراتی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 204, Name = "بدهکاری بهای تمام شده فروش داخلی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 205, Name = "بدهکاری بهای تمام شده فروش صادراتی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش", Code = 206, Name = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 251, Name = "بدهکاری برگشت از فروش داخلی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 252, Name = "بدهکاری برگشت از فروش صادراتی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 253, Name = "بستانکاری برگشت از فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 254, Name = "بدهکاری بهای تمام شده برگشت" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 255, Name = "بستانکاری بهای تمام شده برگشت داخلی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 256, Name = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش", Code = 257, Name = "انحراف نرخ فروش با برگشت" });

                    fktanzimatFactorsBindingSource_Kala.DataSource = list.ToList();

                }
                cmbControl = cmbNameAnbar1_1;
                gridView1 = gridView1_1;
                btnEdit = btnEdit1_1;
                btnReload = btnReloadNameAnbar1_1;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Khadamat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeKhadamat.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید خدمات", Code = 301, Name = "بدهکاری خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید خدمات", Code = 302, Name = "بستانکاری خرید" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید خدمات", Code = 351, Name = "بدهکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید خدمات", Code = 352, Name = "بستانکاری برگشت از خرید" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید خدمات", Code = 353, Name = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 401, Name = "بدهکاری فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 402, Name = "بستانکاری فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 403, Name = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 404, Name = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 405, Name = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش خدمات", Code = 406, Name = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 451, Name = "بدهکاری برگشت از فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 452, Name = "بستانکاری برگشت از فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 452, Name = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 454, Name = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 455, Name = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 456, Name = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش خدمات", Code = 457, Name = "انحراف نرخ فروش با برگشت" });

                    fktanzimatFactorsBindingSource1_Khadamat.DataSource = list.ToList();

                }
                cmbControl = cmbCodeKhadamat;
                gridView1 = gridView1_2;
                btnEdit = btnEdit1_2;
                btnReload = btnReloadCodeKhadamat;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ezafat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeEzafat.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 501, Name = "بدهکاری خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 502, Name = "بستانکاری خرید" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 551, Name = "بدهکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 552, Name = "بستانکاری برگشت از خرید" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Name = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 601, Name = "بدهکاری فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 602, Name = "بستانکاری فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Name = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Name = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Name = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Name = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 651, Name = "بدهکاری برگشت از فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 652, Name = "بستانکاری برگشت از فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Name = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Name = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Name = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Name = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Name = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource2_Ezafat.DataSource = list.ToList();

                }
                cmbControl = cmbCodeEzafat;
                gridView1 = gridView1_3;
                btnEdit = btnEdit1_3;
                btnReload = btnReloadEzafat;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Ksorat)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbCodeKsorat.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 701, Name = "بدهکاری خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 702, Name = "بستانکاری خرید" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 751, Name = "بدهکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 752, Name = "بستانکاری برگشت از خرید" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Name = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 801, Name = "بدهکاری فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 802, Name = "بستانکاری فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Name = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Name = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Name = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Name = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 851, Name = "بدهکاری برگشت از فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 852, Name = "بستانکاری برگشت از فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Name = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Name = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Name = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Name = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Name = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource3_Ksorat.DataSource = list.ToList();

                }
                cmbControl = cmbCodeKsorat;
                gridView1 = gridView1_4;
                btnEdit = btnEdit1_4;
                btnReload = btnReloadKsorat;
            }
            else if (xtc_FKTanzimatFactor.SelectedTabPage == xtp_Vasete)
            {
                FillCmbControl();

                if (Convert.ToInt32(cmbVizitor.EditValue) == 0)
                {
                    List<FKTanzimatFactor> list = new List<FKTanzimatFactor>();

                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 901, Name = "بدهکاری خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "1. فاکتور خرید ", Code = 902, Name = "بستانکاری خرید" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 951, Name = "بدهکاری برگشت از خرید" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 952, Name = "بستانکاری برگشت از خرید" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "2. فاکتور برگشت از خرید ", Code = 353, Name = "انحراف نرخ خرید با برگشت" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 1001, Name = "بدهکاری فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 1002, Name = "بستانکاری فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 403, Name = "بستانکاری فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 404, Name = "بدهکاری بهای تمام شده فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 405, Name = "بدهکاری بهای تمام شده فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "3. فاکتور فروش ", Code = 406, Name = "بستانکاری بهای تمام شده فروش" });

                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 1051, Name = "بدهکاری برگشت از فروش" });
                    list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 1052, Name = "بستانکاری برگشت از فروش" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 452, Name = "بدهکاری برگشت از فروش صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 454, Name = "بدهکاری بهای تمام شده برگشت" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 455, Name = "بستانکاری بهای تمام شده برگشت داخلی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 456, Name = "بستانکاری بهای تمام شده برگشت صادراتی" });
                    //list.Add(new FKTanzimatFactor() { NameSanad = "4. فاکتور برگشت از فروش ", Code = 457, Name = "انحراف نرخ فروش با برگشت" });

                    fKTanzimatFactorsBindingSource5_Vizitor.DataSource = list.ToList();

                }
                cmbControl = cmbVizitor;
                gridView1 = gridView1_5;
                btnEdit = btnEdit1_5;
                btnReload = btnReloadVzitor;
            }

            cmbControl.Focus();

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
            if (Convert.ToInt32(cmbControl.EditValue) > 0)
            {
                _RowHandle = gridView1.FocusedRowHandle;
                _SalId = Convert.ToInt32(lblSalId.Text);
                _cmbId = Convert.ToInt32(cmbControl.EditValue);
                _HesabMoinId = gridView1.GetFocusedRowCellValue("HesabMoinId") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabMoinId")) : 0;
                _HesabTafsili1Id = gridView1.GetFocusedRowCellValue("HesabTafsili1Id") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili1Id")) : 0;
                _HesabTafsili2Id = gridView1.GetFocusedRowCellValue("HesabTafsili2Id") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili2Id")) : 0;
                _HesabTafsili3Id = gridView1.GetFocusedRowCellValue("HesabTafsili3Id") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("HesabTafsili3Id")) : 0;
                _Code = gridView1.GetFocusedRowCellValue("Code") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code")) : 0;
                _Name = gridView1.GetFocusedRowCellValue("Name") != null ? gridView1.GetFocusedRowCellValue("Name").ToString() : "";
                _NameSanad = gridView1.GetFocusedRowCellValue("NameSanad") != null ? gridView1.GetFocusedRowCellValue("NameSanad").ToString() : "";

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
    }
}