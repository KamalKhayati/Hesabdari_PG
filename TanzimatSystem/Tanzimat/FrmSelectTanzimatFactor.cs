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
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System.Data.Entity;

namespace TanzimatSystem.Tanzimat
{
    public partial class FrmSelectFKTanzimatFactor : DevExpress.XtraEditors.XtraForm
    {
        public FrmSelectFKTanzimatFactor()
        {
            InitializeComponent();
        }
        FrmTanzimatSystem Fm;
        public FrmSelectFKTanzimatFactor(FrmTanzimatSystem fm)
        {
            InitializeComponent();
            Fm = fm;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cmbHesabMoin.EditValue) > 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        //_SalId = Convert.ToInt32(lblSalId.Text);
                        //_AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                        Fm._HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);

                        if (Fm._HesabMoinId != 0)
                        {
                            Fm._HesabTafsili1Id = Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.LevelNumber == 1 && s.EpAllGroupTafsili1.Id == 19 && s.Name == "سایر 1").Id : Convert.ToInt32(cmbHesabTafsili1.EditValue);
                            Fm._HesabTafsili2Id = Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.LevelNumber == 2 && s.EpAllGroupTafsili1.Id == 38 && s.Name == "سایر 2").Id : Convert.ToInt32(cmbHesabTafsili2.EditValue);
                            Fm._HesabTafsili3Id = Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.LevelNumber == 3 && s.EpAllGroupTafsili1.Id == 57 && s.Name == "سایر 3").Id : Convert.ToInt32(cmbHesabTafsili3.EditValue);
                            //_Code = gridView1.GetFocusedRowCellValue("Code") != null ? Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code")) : 0;
                            //_Name = gridView1.GetFocusedRowCellValue("Name") != null ? gridView1.GetFocusedRowCellValue("Name").ToString() : "";
                            //_NameSanad = gridView1.GetFocusedRowCellValue("NameSanad") != null ? gridView1.GetFocusedRowCellValue("NameSanad").ToString() : "";
                            Fm._HesabMoinName = Fm._HesabMoinId != 0 ? db.EpAllCodingHesabdaris.FirstOrDefault(s => s.SalId == Fm._SalId && s.Id == Fm._HesabMoinId).LevelName : "";
                            Fm._HesabTafsili1Name = Fm._HesabTafsili1Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.Id == Fm._HesabTafsili1Id).Name : "";
                            Fm._HesabTafsili2Name = Fm._HesabTafsili2Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.Id == Fm._HesabTafsili2Id).Name : "";
                            Fm._HesabTafsili3Name = Fm._HesabTafsili3Id != 0 ? db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == Fm._SalId && s.Id == Fm._HesabTafsili3Id).Name : "";

                        }
                        else
                        {
                            Fm._HesabTafsili1Id = 0;
                            Fm._HesabTafsili2Id = 0;
                            Fm._HesabTafsili3Id = 0;
                            Fm._HesabMoinName = "";
                            Fm._HesabTafsili1Name = "";
                            Fm._HesabTafsili2Name = "";
                            Fm._HesabTafsili3Name = "";
                        }
                        if (Fm.XtraTabControl1.SelectedTabPage.Name == "xtp_Anbar")
                        {
                            var q = db.FKTanzimatFactors.FirstOrDefault(s => s.SalId == Fm._SalId && s.AnbarId == Fm._cmbId && s.NoeAghlam == Fm._NoeAghlam && s.Code == Fm._Code);
                            if (q != null)
                            {
                                q.HesabMoinId = Fm._HesabMoinId;
                                q.HesabTafsili1Id = Fm._HesabTafsili1Id;
                                q.HesabTafsili2Id = Fm._HesabTafsili2Id;
                                q.HesabTafsili3Id = Fm._HesabTafsili3Id;
                                db.SaveChanges();
                            }

                        }
                        else if (Fm.XtraTabControl1.SelectedTabPage.Name == "xtp_Khadamat")
                        {
                            var q = db.FKTanzimatFactors.FirstOrDefault(s => s.SalId == Fm._SalId && s.KhadamatId == Fm._cmbId && s.NoeAghlam == Fm._NoeAghlam && s.Code == Fm._Code);
                            if (q != null)
                            {
                                q.HesabMoinId = Fm._HesabMoinId;
                                q.HesabTafsili1Id = Fm._HesabTafsili1Id;
                                q.HesabTafsili2Id = Fm._HesabTafsili2Id;
                                q.HesabTafsili3Id = Fm._HesabTafsili3Id;
                                db.SaveChanges();
                            }

                        }
                        else if (Fm.XtraTabControl1.SelectedTabPage.Name == "xtp_Ezafat")
                        {
                            var q = db.FKTanzimatFactors.FirstOrDefault(s => s.SalId == Fm._SalId && s.Ez_KsId == Fm._cmbId && s.NoeAghlam == Fm._NoeAghlam && s.Code == Fm._Code);
                            if (q != null)
                            {
                                q.HesabMoinId = Fm._HesabMoinId;
                                q.HesabTafsili1Id = Fm._HesabTafsili1Id;
                                q.HesabTafsili2Id = Fm._HesabTafsili2Id;
                                q.HesabTafsili3Id = Fm._HesabTafsili3Id;
                                db.SaveChanges();
                            }

                        }
                        else if (Fm.XtraTabControl1.SelectedTabPage.Name == "xtp_Ksorat")
                        {
                            var q = db.FKTanzimatFactors.FirstOrDefault(s => s.SalId == Fm._SalId && s.Ez_KsId == Fm._cmbId && s.NoeAghlam == Fm._NoeAghlam && s.Code == Fm._Code);
                            if (q != null)
                            {
                                q.HesabMoinId = Fm._HesabMoinId;
                                q.HesabTafsili1Id = Fm._HesabTafsili1Id;
                                q.HesabTafsili2Id = Fm._HesabTafsili2Id;
                                q.HesabTafsili3Id = Fm._HesabTafsili3Id;
                                db.SaveChanges();
                            }

                        }
                        else if (Fm.XtraTabControl1.SelectedTabPage.Name == "xtp_Vasete")
                        {
                            var q = db.FKTanzimatFactors.FirstOrDefault(s => s.SalId == Fm._SalId && s.VizitorId == Fm._cmbId && s.NoeAghlam == Fm._NoeAghlam && s.Code == Fm._Code);
                            if (q != null)
                            {
                                q.HesabMoinId = Fm._HesabMoinId;
                                q.HesabTafsili1Id = Fm._HesabTafsili1Id;
                                q.HesabTafsili2Id = Fm._HesabTafsili2Id;
                                q.HesabTafsili3Id = Fm._HesabTafsili3Id;
                                db.SaveChanges();
                            }

                        }
                        //else
                        //{
                        //    FKTanzimatFactor obj = new FKTanzimatFactor();
                        //    obj.SalId = _SalId;
                        //    obj.NameSanad = _NameSanad;
                        //    obj.AnbarId = _AnbarId;
                        //    obj.Name = _Name;
                        //    obj.HesabMoinId = _HesabMoinId;
                        //    obj.HesabTafsili1Id = _HesabTafsili1Id;
                        //    obj.HesabTafsili2Id = _HesabTafsili2Id;
                        //    obj.HesabTafsili3Id = _HesabTafsili3Id;
                        //    db.FKTanzimatFactors.Add(obj);
                        //    db.SaveChanges();
                        //}

                        //Fm.gridView1.SetRowCellValue(Fm._RowHandle, "AnbarId", Fm._AnbarId);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabMoinId", Fm._HesabMoinId);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili1Id", Fm._HesabTafsili1Id);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili2Id", Fm._HesabTafsili2Id);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili3Id", Fm._HesabTafsili3Id);

                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabMoinName_NM", Fm._HesabMoinName);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili1Name_NM", Fm._HesabTafsili1Name);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili2Name_NM", Fm._HesabTafsili2Name);
                        Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili3Name_NM", Fm._HesabTafsili3Name);

                        //var qq = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.AnbarId == _AnbarId).ToList();
                        //if (qq.Count>0)
                        //{
                        //    var List = (DataTable)gridControl1.DataSource;
                        //    foreach (var item in List.Select("Code"))
                        //    {
                        //        if (qq.Any(s => s.Code == Convert.ToInt32(item)))
                        //        {

                        //        }
                        //    }

                        //}
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            this.Close();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void FillCmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabMoin1s.Where(s => s.SalId == Fm._SalId).OrderBy(s => s.Code).ToList();
                    epHesabMoin1sBindingSource.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    var q = db.EpHesabMoin1s.FirstOrDefault(s => s.SalId == Fm._SalId && s.Id == _HesabMoinId);
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

                    FillCmbHesabTafsili();
                    btnSave.Enabled = true;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if (Convert.ToInt32(cmbHesabMoin.EditValue) > 0)
            //    btnSave.Enabled = true;
            //{
            //    btnSave_Click(null, null);
            //}
        }

        public void FillCmbHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);

                    List<EpAllHesabTafsili> list = new List<EpAllHesabTafsili>();

                    var q1 = db.R_EpHesabMoin1_B_EpAllGroupTafsilis.Where(s => s.EpHesabMoin1Id == _HesabMoinId && s.SalId == Fm._SalId).Select(s => s.AllGroupTafsiliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == Fm._SalId && s.GroupTafsiliId == item).OrderBy(s => s.Code).ToList();
                            list.AddRange(q);
                        }
                        epAllHesabTafsilisBindingSource.DataSource = list.Where(s => s.LevelNumber == 1).OrderBy(s => s.Code);
                        epAllHesabTafsilisBindingSource1.DataSource = list.Where(s => s.LevelNumber == 2).OrderBy(s => s.Code);
                        epAllHesabTafsilisBindingSource2.DataSource = list.Where(s => s.LevelNumber == 3).OrderBy(s => s.Code);
                    }
                    else
                    {
                        epAllHesabTafsilisBindingSource.DataSource = null;
                        epAllHesabTafsilisBindingSource1.DataSource = null;
                        epAllHesabTafsilisBindingSource2.DataSource = null;

                    }



                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmSelectFKTanzimatFactor_Load(object sender, EventArgs e)
        {
            FillCmbHesabMoin();

            lblName.Text = Fm._NameSanad.Replace(".", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "");
            groupControl1.Text = Fm._Name;
            cmbHesabMoin.EditValue = Fm._HesabMoinId;
            cmbHesabTafsili1.EditValue = Fm._HesabTafsili1Id;
            cmbHesabTafsili2.EditValue = Fm._HesabTafsili2Id;
            cmbHesabTafsili3.EditValue = Fm._HesabTafsili3Id;
        }

        private void btnReloadHesabAnbar_Click(object sender, EventArgs e)
        {
            FillCmbHesabMoin();
        }

        private void btnReloadTafsili1_Click(object sender, EventArgs e)
        {
            FillCmbHesabTafsili();
        }

        private void btnReloadTafsili2_Click(object sender, EventArgs e)
        {
            FillCmbHesabTafsili();
        }

        private void btnReloadTafsili3_Click(object sender, EventArgs e)
        {
            FillCmbHesabTafsili();
        }

        private void cmbHesabMoin_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0)
                cmbHesabMoin.ShowPopup();
        }

        private void FrmSelectFKTanzimatFactor_Shown(object sender, EventArgs e)
        {
            cmbHesabMoin.Focus();
        }

        private void cmbHesabTafsili1_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0)
                cmbHesabTafsili1.ShowPopup();

        }

        private void cmbHesabTafsili2_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0)
                cmbHesabTafsili2.ShowPopup();

        }

        private void cmbHesabTafsili3_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0)
                cmbHesabTafsili3.ShowPopup();

        }

        private void cmbHesabMoin_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0)
                cmbHesabMoin.ShowPopup();

        }

        private void cmbHesabTafsili1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0)
                cmbHesabTafsili1.ShowPopup();
        }

        private void cmbHesabTafsili2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0)
                cmbHesabTafsili2.ShowPopup();

        }

        private void cmbHesabTafsili3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0)
                cmbHesabTafsili3.ShowPopup();

        }

        private void cmbHesabMoin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbHesabMoin.Text))
                cmbHesabMoin.EditValue = 0;
        }

        private void cmbHesabTafsili1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbHesabTafsili1.Text))
                cmbHesabTafsili1.EditValue = 0;

        }

        private void cmbHesabTafsili2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbHesabTafsili2.Text))
                cmbHesabTafsili2.EditValue = 0;

        }

        private void cmbHesabTafsili3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbHesabTafsili3.Text))
                cmbHesabTafsili3.EditValue = 0;

        }
    }
}