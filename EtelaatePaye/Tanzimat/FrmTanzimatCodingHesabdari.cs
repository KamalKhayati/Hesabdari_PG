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
using DBHesabdari_PG;
using DBHesabdari_PG.Models.EP.Tanzimat;

namespace EtelaatePaye.Tanzimat
{
    public partial class FrmTanzimatCodingHesabdari : DevExpress.XtraEditors.XtraForm
    {
        public FrmTanzimatCodingHesabdari()
        {
            InitializeComponent();
        }

        public void FillTanzimatCodingHesabdari()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q1 = db.EpTanzimatCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId);
                    if (q1!=null)
                    {
                        if (lblUserId.Text == "1")
                        {
                            txtTabaghehCarakter.Text = q1.HesabTabaghehCarakter.ToString();
                            txtGroupCarakter.Text = q1.HesabGroupCarakter.ToString();
                            txtColCarakter.Text = q1.HesabColCarakter.ToString();
                            txtMoinCarakter.Text = q1.HesabMoinCarakter.ToString();
                        }

                    }
                    var q2 = db.EpTanzimatGroupTafsilis.FirstOrDefault();
                    if (q2 != null)
                    {
                        if (lblUserId.Text == "1")
                        {
                            txtGroupTafsiliLevel1Carakter.Text = q2.GroupTafsiliLevel1Carakter.ToString();
                            txtGroupTafsiliLevel2Carakter.Text = q2.GroupTafsiliLevel2Carakter.ToString();
                            txtGroupTafsiliLevel3Carakter.Text = q2.GroupTafsiliLevel3Carakter.ToString();
                            txtCodeTafsiliCarakter.Text = q2.CodeTafsiliCarakter.ToString();
                        }

                    }                    //else
                    //{
                    //    int _UserId = Convert.ToInt32(lblUserId.Text);
                    //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabTabaghehId).ToList();

                    //    if (q1.Count > 0)
                    //    {
                    //        if (q2.Count > 0)
                    //        {
                    //            q2.ForEach(item3 =>
                    //            {
                    //                q1.Remove(dataContext.EpHesabTabagheh.FirstOrDefault(s => s.Id == item3));
                    //            });
                    //            epHesabTabaghehsBindingSource.DataSource = q1;
                    //        }
                    //        else
                    //        {
                    //            epHesabTabaghehsBindingSource.DataSource = q1;
                    //        }
                    //    }
                    //    else
                    //        epHesabTabaghehsBindingSource.DataSource = null;
                    //}
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void IsAnyData()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);

                    if (db.EpHesabTabaghehs.Any(s => s.SalId == _SalId))
                        txtTabaghehCarakter.Enabled = false;
                    else
                        txtTabaghehCarakter.Enabled = true;

                    if (db.EpHesabGroups.Any(s => s.SalId == _SalId))
                        txtGroupCarakter.Enabled = false;
                    else
                        txtGroupCarakter.Enabled = true;

                    if (db.EpHesabCols.Any(s => s.SalId == _SalId))
                        txtColCarakter.Enabled = false;
                    else
                        txtColCarakter.Enabled = true;

                    if (db.EpHesabMoins.Any(s => s.SalId == _SalId))
                        txtMoinCarakter.Enabled = false;
                    else
                        txtMoinCarakter.Enabled = true;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void FrmTanzimatCodingHesabdari_Load(object sender, EventArgs e)

        {
            FillTanzimatCodingHesabdari();
            IsAnyData();
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtTabaghehCarakter.Text) || string.IsNullOrEmpty(txtGroupCarakter.Text) || string.IsNullOrEmpty(txtColCarakter.Text) || string.IsNullOrEmpty(txtMoinCarakter.Text))
            {
                XtraMessageBox.Show("هیچکدام از فیلدها نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpTanzimatCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId);
                        if (q != null)
                        {
                            q.HesabTabaghehCarakter = Convert.ToInt32(txtTabaghehCarakter.Text);
                            q.HesabGroupCarakter = Convert.ToInt32(txtGroupCarakter.Text);
                            q.HesabColCarakter = Convert.ToInt32(txtColCarakter.Text);
                            q.HesabMoinCarakter = Convert.ToInt32(txtMoinCarakter.Text);

                            q.HesabTabaghehMinCode = "1";
                            q.HesabTabaghehMaxCode = "9";

                            q.HesabGroupMinCode = txtGroupCarakter.Text == "1" ? "1" : "01";
                            q.HesabGroupMaxCode = txtGroupCarakter.Text == "1" ? "9" : "99";

                            q.HesabColMinCode = txtColCarakter.Text == "1" ? "1" : txtColCarakter.Text == "2" ? "01" : "001";
                            q.HesabColMaxCode = txtColCarakter.Text == "1" ? "9" : txtColCarakter.Text == "2" ? "01" : "999";

                            q.HesabMoinMinCode = txtMoinCarakter.Text == "1" ? "1" : txtMoinCarakter.Text == "2" ? "01" : "001";
                            q.HesabMoinMaxCode = txtMoinCarakter.Text == "1" ? "9" : txtMoinCarakter.Text == "2" ? "01" : "999";
                            db.SaveChanges();
                            this.Close();
                        }
                        //else
                        //{
                        //    EpTanzimatCodingHesabdari obj = new EpTanzimatCodingHesabdari();
                        //    obj.SalId = _SalId;
                        //    obj.HesabTabaghehCarakter = Convert.ToInt32(txtTabaghehCarakter.Text);
                        //    obj.HesabGroupCarakter = Convert.ToInt32(txtGroupCarakter.Text);
                        //    obj.HesabColCarakter = Convert.ToInt32(txtColCarakter.Text);
                        //    obj.HesabMoinCarakter = Convert.ToInt32(txtMoinCarakter.Text);
                        //    obj.HesabTabaghehMinCod = txtTabaghehCarakter.Text == "1" ? "1" : "01";
                        //    obj.HesabTabaghehMaxCod = txtTabaghehCarakter.Text == "1" ? "9" : "99";
                        //    obj.HesabGroupMinCod = txtGroupCarakter.Text == "1" ? "1" : "01";
                        //    obj.HesabGroupMaxCod = txtGroupCarakter.Text == "1" ? "9" : "99";
                        //    obj.HesabColMinCod = txtColCarakter.Text == "1" ? "1" : "01";
                        //    obj.HesabColMaxCod = txtColCarakter.Text == "1" ? "9" : "99";
                        //    obj.HesabMoinMinCod = txtGroupCarakter.Text == "1" ? "1" : "01";
                        //    obj.HesabMoinMaxCod = txtGroupCarakter.Text == "1" ? "9" : "99";
                        //    db.EpTanzimatCodingHesabdaris.Add(obj);
                        //    /////////////////////////////////////////////////////////////////////////////////////
                        //    db.SaveChanges();
                        //}
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmTanzimatCodingHesabdari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }
        }
    }
}