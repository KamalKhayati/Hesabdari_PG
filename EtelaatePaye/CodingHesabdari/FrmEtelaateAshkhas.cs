/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmEtelaateAshkhas.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 10   10:00 ق.ظ
*	
***********************************************************************************/
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
using System.Data.Entity.Infrastructure;
using System.IO;
using DBHesabdari_PG.Models.EP.CodingHesabdari;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmEtelaateAshkhas : DevExpress.XtraEditors.XtraForm
    {
        public FrmEtelaateAshkhas()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;
        public void FillcmbGroupTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafsiliLevel1s.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true && s.Id == 3 || s.Id == 4).Load();
                            epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.Id == 3 || s.Id == 4).Load();
                            epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
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
        public void FillcmbTafsiliAshkhas()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTafsiliAshkhass.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpHesabTafsiliAshkhass.Where(s => s.IsActive == true).Load();
                            epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabTafsiliAshkhass.Load();
                            epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
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
        private void FrmEtelaateAshkhas_Load(object sender, EventArgs e)
        {
            FillcmbGroupTafsili();
            FillcmbTafsiliAshkhas();
            //if (lblUserId.Text == "1")
            //{
            //    chkIsActive.Visible = true;
            //    labelControl6.Visible = true;
            //}
            //labelControl1.Text = "کد صندوق";
            //labelControl2.Text = "نام صندوق";
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        int _UserId = Convert.ToInt32(lblUserId.Text);
            //        var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
            //        if (q1.Count() > 0)
            //        {
            //            //btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010201) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010202) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010203) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int Before_GroupTafsili_EditValueChanged = 0;
        private void cmbGroupTafsili_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbGroupTafsili.EditValue) == 3)
            {

                using (var db = new MyContext())
                {
                    try
                    {
                        if (db.EpHesabTafsiliAshkhass.Any())
                        {
                            if (IsActiveList == true)
                            {
                                db.EpHesabTafsiliAshkhass.Where(s => s.IsActive == true && s.GroupTafsiliId == 3).Load();
                                epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
                            }
                            else
                            {
                                db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 3).Load();
                                epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
                            }
                            labelControl1.Text = "نام شخص حقیقی";
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (Convert.ToInt32(cmbGroupTafsili.EditValue) == 4)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (db.EpHesabTafsiliAshkhass.Any())
                        {
                            if (IsActiveList == true)
                            {
                                db.EpHesabTafsiliAshkhass.Where(s => s.IsActive == true && s.GroupTafsiliId == 4).Load();
                                epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
                            }
                            else
                            {
                                db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 4).Load();
                                epHesabTafsiliAshkhassBindingSource.DataSource = db.EpHesabTafsiliAshkhass.Local.ToBindingList();
                            }
                            labelControl1.Text = "نام شخص حقوقی";
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            txtGroupTafsiliId.Text = cmbGroupTafsili.EditValue.ToString();
            if (Before_GroupTafsili_EditValueChanged != Convert.ToInt32(cmbGroupTafsili.EditValue))
                cmbTafsiliAshkhas.EditValue = 0;
            Before_GroupTafsili_EditValueChanged = Convert.ToInt32(cmbGroupTafsili.EditValue);
        }
        private void cmbTafsiliAshkhas_EditValueChanged(object sender, EventArgs e)
        {
            txtId.Text = cmbTafsiliAshkhas.EditValue.ToString();
            int _Id = Convert.ToInt32(txtId.Text);
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(f => f.Id == _Id);
                    if (q != null)
                    {
                        tpPersonel.PageVisible = q.IsKarkonan;
                        tpSahmSahamdar.PageVisible = q.IsSahamdar;
                        tpDarsadVizitor.PageVisible = q.IsVizitor;
                        tpDarsadRanande.PageVisible = q.IsRanande;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            FillDataGridView();

            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                btnCreate.Enabled = gridViewMoshkhasat1.RowCount == 0 ? true : false;
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
                btnCreate.Enabled = gridViewMPersoneli1.RowCount == 0 ? true : false;

            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTafsiliAshkhass.Any())
                    {
                        int AshkhasId = Convert.ToInt32(txtId.Text);
                        var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id == AshkhasId);
                        if (q != null)
                        {
                            if (q.GroupTafsiliId == 3)
                            {
                                labelControl5.Text = "نام اختصار";
                                labelControl18.Text = "کد ملی";
                                txtShenaseMelli.Properties.MaxLength = 10;
                            }
                            else
                            {
                                labelControl5.Text = "نام مدیر عامل";
                                labelControl18.Text = "شناسه ملی";
                                txtShenaseMelli.Properties.MaxLength = 11;
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void FillDataGridView()
        {
            if (Convert.ToInt32(cmbTafsiliAshkhas.EditValue) != 0)
            {
                using (var dataContext = new MyContext())
                {
                    try
                    {
                        int AshkhasId = Convert.ToInt32(txtId.Text);
                        //////////////////////////////epMoshakhasat_AsBindingSource//////////////////////////////
                        var q1 = dataContext.EpMoshakhasat_As.Where(s => s.Id == AshkhasId).OrderBy(s => s.Id).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q1.Count > 0)
                            epMoshakhasat_AsBindingSource.DataSource = q1;
                        else
                            epMoshakhasat_AsBindingSource.DataSource = null;
                        //////////////////////////////epAdress_AsBindingSource//////////////////////////////
                        var q2 = dataContext.EpAdress_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q2.Count > 0)
                            epAdress_AsBindingSource.DataSource = q2;
                        else
                            epAdress_AsBindingSource.DataSource = null;
                        //////////////////////////////epShTamas_AsBindingSource//////////////////////////////
                        var q3 = dataContext.EpShTamas_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q3.Count > 0)
                            epShTamas_AsBindingSource.DataSource = q3;
                        else
                            epShTamas_AsBindingSource.DataSource = null;
                        //////////////////////////////epEetebarat_AsBindingSource//////////////////////////////
                        var q4 = dataContext.EpEetebarat_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q4.Count > 0)
                            epEetebarat_AsBindingSource.DataSource = q4;
                        else
                            epEetebarat_AsBindingSource.DataSource = null;
                        //////////////////////////////epFazaMajazi_AsBindingSource//////////////////////////////
                        var q5 = dataContext.EpFazaMajazi_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q5.Count > 0)
                            epFazaMajazi_AsBindingSource.DataSource = q5;
                        else
                            epFazaMajazi_AsBindingSource.DataSource = null;
                        //////////////////////////////epHesabBanki_AsBindingSource//////////////////////////////
                        var q6 = dataContext.EpHesabBanki_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q6.Count > 0)
                            epHesabBanki_AsBindingSource.DataSource = q6;
                        else
                            epHesabBanki_AsBindingSource.DataSource = null;
                        //////////////////////////////epDarsadTakhfif_AsBindingSource//////////////////////////////
                        var q7 = dataContext.EpDarsadTakhfif_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q7.Count > 0)
                            epDarsadTakhfif_AsBindingSource.DataSource = q7;
                        else
                            epDarsadTakhfif_AsBindingSource.DataSource = null;
                        //////////////////////////////epMPersoneli_AsBindingSource//////////////////////////////
                        var q8 = dataContext.EpMPersoneli_As.Where(s => s.Id == AshkhasId).OrderByDescending(s => s.Id).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q8.Count > 0)
                            epMPersoneli_AsBindingSource.DataSource = q8;
                        else
                            epMPersoneli_AsBindingSource.DataSource = null;
                        //////////////////////////////epSahmSahamdar_AsBindingSource//////////////////////////////
                        var q9 = dataContext.EpSahmSahamdar_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.Id).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q9.Count > 0)
                            epSahmSahamdar_AsBindingSource.DataSource = q9;
                        else
                            epSahmSahamdar_AsBindingSource.DataSource = null;
                        //////////////////////////////epDarsadVizitor_AsBindingSource//////////////////////////////
                        var q10 = dataContext.EpDarsadVizitor_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q10.Count > 0)
                            epDarsadVizitor_AsBindingSource.DataSource = q10;
                        else
                            epDarsadVizitor_AsBindingSource.DataSource = null;
                        //////////////////////////////epDarsadRanande_AsBindingSource//////////////////////////////
                        var q11 = dataContext.EpDarsadRanande_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        //if (lblUserId.Text == "1")
                        //{
                        if (q11.Count > 0)
                            epDarsadRanande_AsBindingSource.DataSource = q11;
                        else
                            epDarsadRanande_AsBindingSource.DataSource = null;

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //ActiveButtons();
            }
            else
                epMoshakhasat_AsBindingSource.DataSource = epAdress_AsBindingSource.DataSource = epShTamas_AsBindingSource.DataSource
                    = epEetebarat_AsBindingSource.DataSource = epFazaMajazi_AsBindingSource.DataSource = epHesabBanki_AsBindingSource.DataSource
                    = epDarsadTakhfif_AsBindingSource.DataSource = epMPersoneli_AsBindingSource.DataSource = epSahmSahamdar_AsBindingSource.DataSource
                    = epDarsadVizitor_AsBindingSource.DataSource = epDarsadRanande_AsBindingSource.DataSource = null;
        }

        public void FillcmbNameAdress()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpNameAdresss.Any())
                    {
                        db.EpNameAdresss.Load();
                        epAdressNamesBindingSource.DataSource = db.EpNameAdresss.Local.ToBindingList();
                    }
                    else
                    {
                        epAdressNamesBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameOstan()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpNameOstans.Any())
                    {
                        db.EpNameOstans.Load();
                        epNameOstansBindingSource.DataSource = db.EpNameOstans.Local.ToBindingList();
                    }
                    else
                    {
                        epNameOstansBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameShahrstan()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpNameShahrstans.Any())
                    {
                        if (Convert.ToInt32(cmbNameOstan.EditValue) != 0)
                        {
                            int _NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);
                            db.EpNameShahrstans.Where(f => f.NameOstanId == _NameOstanId).Load();
                            epNameShahrstansBindingSource.DataSource = db.EpNameShahrstans.Local.ToBindingList();

                        }
                    }
                    else
                    {
                        epNameShahrstansBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameBank()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    if (db.EpNameBanks.Any())
                    {
                        db.EpNameBanks.Where(s => s.SalId == _SalId).OrderBy(s => s.Id).Load();
                        epNameBanksBindingSource.DataSource = db.EpNameBanks.Local.ToBindingList();
                    }
                    else
                        epNameBanksBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private bool TextEditValidation()
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (string.IsNullOrEmpty(txtNameEkhtesar.Text) && string.IsNullOrEmpty(txtNoeFaaliat.Text) && string.IsNullOrEmpty(txtShenaseMelli.Text) && string.IsNullOrEmpty(txtCodeEghtesadi.Text) && string.IsNullOrEmpty(txtShomareSabt.Text) && string.IsNullOrEmpty(txtMolahezat_M.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                if (db.EpMoshakhasat_As.Any())
                                {
                                    var q1 = db.EpMoshakhasat_As.FirstOrDefault(p => p.ShenaseMelli == txtShenaseMelli.Text);
                                    var q2 = db.EpMoshakhasat_As.FirstOrDefault(p => p.CodeEghtesadi == txtCodeEghtesadi.Text);
                                    if (q1 != null)
                                    {
                                        XtraMessageBox.Show("این کد/شناسه ملی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                        return false;
                                    }
                                    if (q2 != null)
                                    {
                                        XtraMessageBox.Show("این کداقتصادی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                        return false;
                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtNameEkhtesar.Text) && string.IsNullOrEmpty(txtNoeFaaliat.Text) && string.IsNullOrEmpty(txtShenaseMelli.Text) && string.IsNullOrEmpty(txtCodeEghtesadi.Text) && string.IsNullOrEmpty(txtShomareSabt.Text) && string.IsNullOrEmpty(txtMolahezat_M.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                return false;
                            }
                            else
                            {
                                int AshkhasId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpMoshakhasat_As.FirstOrDefault(p => p.Id != AshkhasId && p.ShenaseMelli == txtShenaseMelli.Text);
                                var q2 = db.EpMoshakhasat_As.FirstOrDefault(p => p.Id != AshkhasId && p.CodeEghtesadi == txtCodeEghtesadi.Text);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد/شناسه ملی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
                                    xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                    return false;
                                }
                                if (q2 != null)
                                {
                                    XtraMessageBox.Show("این کداقتصادی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                    return false;
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (string.IsNullOrEmpty(cmbNameAdress.Text) && string.IsNullOrEmpty(cmbNameOstan.Text) && string.IsNullOrEmpty(cmbNameShahrstan.Text) && string.IsNullOrEmpty(txtSharhAdress.Text) && string.IsNullOrEmpty(txtCodePosti.Text) && string.IsNullOrEmpty(txtSandoghPosti.Text) && string.IsNullOrEmpty(txtMolahezat_A.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                if (db.EpAdress_As.Any())
                                {
                                    var q1 = db.EpAdress_As.FirstOrDefault(p => p.CodePosti == txtCodePosti.Text);
                                    var q2 = db.EpAdress_As.FirstOrDefault(p => p.SandoghPosti == txtSandoghPosti.Text);
                                    if (q1 != null)
                                    {
                                        if (XtraMessageBox.Show("این کد پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            xtraTabControl.SelectedTabPage = tpAdress;
                                            return false;
                                        }

                                    }
                                    if (q2 != null)
                                    {
                                        if (XtraMessageBox.Show("این صندوق پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            xtraTabControl.SelectedTabPage = tpAdress;
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(cmbNameAdress.Text) && string.IsNullOrEmpty(cmbNameOstan.Text) && string.IsNullOrEmpty(cmbNameShahrstan.Text) && string.IsNullOrEmpty(txtSharhAdress.Text) && string.IsNullOrEmpty(txtCodePosti.Text) && string.IsNullOrEmpty(txtSandoghPosti.Text) && string.IsNullOrEmpty(txtMolahezat_A.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpAdress;
                                return false;
                            }
                            else
                            {
                                int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                var q1 = db.EpAdress_As.FirstOrDefault(p => p.Id != RowId && p.CodePosti == txtCodePosti.Text);
                                var q2 = db.EpAdress_As.FirstOrDefault(p => p.Id != RowId && p.SandoghPosti == txtSandoghPosti.Text);
                                if (q1 != null)
                                {
                                    if (XtraMessageBox.Show("این کد پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        xtraTabControl.SelectedTabPage = tpAdress;
                                        return false;
                                    }

                                }
                                if (q2 != null)
                                {
                                    if (XtraMessageBox.Show("این صندوق پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        xtraTabControl.SelectedTabPage = tpAdress;
                                        return false;
                                    }
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (string.IsNullOrEmpty(cmbNoeTamas.Text) && string.IsNullOrEmpty(txtShTamas.Text) && string.IsNullOrEmpty(txtNameTaraf.Text) && string.IsNullOrEmpty(txtNameGhesmat.Text)
                                && string.IsNullOrEmpty(txtShDakheli.Text) && string.IsNullOrEmpty(txtMolahezat_T.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                if (db.EpShTamas_As.Any())
                                {
                                    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.ShTamas == txtShTamas.Text);
                                    if (q1 != null)
                                    {
                                        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            xtraTabControl.SelectedTabPage = tpTamas;
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(cmbNoeTamas.Text) && string.IsNullOrEmpty(txtShTamas.Text) && string.IsNullOrEmpty(txtNameTaraf.Text) && string.IsNullOrEmpty(txtNameGhesmat.Text)
                                && string.IsNullOrEmpty(txtShDakheli.Text) && string.IsNullOrEmpty(txtMolahezat_T.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpTamas;
                                return false;
                            }
                            else
                            {
                                int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                                var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                                if (q1 != null)
                                {
                                    if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        xtraTabControl.SelectedTabPage = tpTamas;
                                        return false;
                                    }

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtMablagh.Text)
                                && string.IsNullOrEmpty(txtShGharadad.Text)
                                && string.IsNullOrEmpty(txtTarikhGharadad.Text)
                                && string.IsNullOrEmpty(txtMolahezat_E.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtMablagh.Text)
                                && string.IsNullOrEmpty(txtShGharadad.Text)
                                && string.IsNullOrEmpty(txtTarikhGharadad.Text)
                                && string.IsNullOrEmpty(txtMolahezat_E.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpEetebarat;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(cmbNameAdress_F.Text)
                                && string.IsNullOrEmpty(txtSharhAdress_F.Text)
                                && string.IsNullOrEmpty(txtMolahezat_F.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(cmbNameAdress_F.Text)
                                && string.IsNullOrEmpty(txtSharhAdress_F.Text)
                                && string.IsNullOrEmpty(txtMolahezat_F.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpFazaMajazi;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtShomareHesab.Text)
                                && string.IsNullOrEmpty(txtShomareKart.Text)
                                && string.IsNullOrEmpty(txtShomareShaba.Text)
                                && string.IsNullOrEmpty(txtShomareMoshtari.Text)
                                && string.IsNullOrEmpty(txtMolahezat_H.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            else if ((!string.IsNullOrEmpty(txtShomareHesab.Text)
                                || !string.IsNullOrEmpty(txtShomareKart.Text)
                                || !string.IsNullOrEmpty(txtShomareShaba.Text)
                                || !string.IsNullOrEmpty(txtShomareMoshtari.Text)
                                || !string.IsNullOrEmpty(txtMolahezat_H.Text))
                                && string.IsNullOrEmpty(cmbNameBank.Text))
                            {
                                XtraMessageBox.Show("لطفاً نام بانک را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtShomareHesab.Text)
                                && string.IsNullOrEmpty(txtShomareKart.Text)
                                && string.IsNullOrEmpty(txtShomareShaba.Text)
                                && string.IsNullOrEmpty(txtShomareMoshtari.Text)
                                && string.IsNullOrEmpty(txtMolahezat_H.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtDarsadTakhfif.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            else if (!string.IsNullOrEmpty(txtDarsadTakhfif.Text)
                                && string.IsNullOrEmpty(cmbNoeTakhfif.Text))
                            {
                                XtraMessageBox.Show("لطفاً نوع تخفیف را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpTakhfif;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtDarsadTakhfif.Text) || txtDarsadTakhfif.Text == "0")
                            {
                                XtraMessageBox.Show("لطفاً درصد تخفیف را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if ((!string.IsNullOrEmpty(txtCodPersoneli.Text)
                                || !string.IsNullOrEmpty(txtTarikhEstekhdam.Text)
                                || !string.IsNullOrEmpty(txtNamePedar.Text)
                                || !string.IsNullOrEmpty(txtShShenasname.Text)
                                || !string.IsNullOrEmpty(txtTarikhTavalod.Text)
                                || !string.IsNullOrEmpty(txtShogl.Text)
                                || !string.IsNullOrEmpty(txtMolahezat_MP.Text))
                               && string.IsNullOrEmpty(cmbJensiat.Text))
                            {
                                XtraMessageBox.Show("لطفاً جنسیت را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            if ((!string.IsNullOrEmpty(txtCodPersoneli.Text)
                                || !string.IsNullOrEmpty(txtTarikhEstekhdam.Text)
                                || !string.IsNullOrEmpty(txtNamePedar.Text)
                                || !string.IsNullOrEmpty(txtShShenasname.Text)
                                || !string.IsNullOrEmpty(txtTarikhTavalod.Text)
                                || !string.IsNullOrEmpty(txtShogl.Text)
                                || !string.IsNullOrEmpty(txtMolahezat_MP.Text))
                               && string.IsNullOrEmpty(cmbTaahol.Text))
                            {
                                XtraMessageBox.Show("لطفاً وضعیت تأهل را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtCodPersoneli.Text)
                                     && string.IsNullOrEmpty(txtTarikhEstekhdam.Text)
                                     && string.IsNullOrEmpty(txtNamePedar.Text)
                                     && string.IsNullOrEmpty(txtShShenasname.Text)
                                     && string.IsNullOrEmpty(txtTarikhTavalod.Text)
                                     && string.IsNullOrEmpty(txtShogl.Text)
                                     && string.IsNullOrEmpty(txtMolahezat_MP.Text)
                                     && string.IsNullOrEmpty(cmbTaahol.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtCodPersoneli.Text)
                               && string.IsNullOrEmpty(txtTarikhEstekhdam.Text)
                               && string.IsNullOrEmpty(txtNamePedar.Text)
                               && string.IsNullOrEmpty(txtShShenasname.Text)
                               && string.IsNullOrEmpty(txtTarikhTavalod.Text)
                               && string.IsNullOrEmpty(txtShogl.Text)
                               && string.IsNullOrEmpty(txtMolahezat_MP.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if ((!string.IsNullOrEmpty(txtTedadSahm.Text)
                                || !string.IsNullOrEmpty(txtMablaghHarSahm.Text))
                               && string.IsNullOrEmpty(txtSumMablagh.Text))
                            {
                                XtraMessageBox.Show("لطفاً جمع مبلغ سهام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtTedadSahm.Text)
                                     && string.IsNullOrEmpty(txtMablaghHarSahm.Text)
                                     && string.IsNullOrEmpty(txtSumMablagh.Text))
                            {
                                //XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if ((!string.IsNullOrEmpty(txtTedadSahm.Text)
                                 || !string.IsNullOrEmpty(txtMablaghHarSahm.Text))
                                 && string.IsNullOrEmpty(txtSumMablagh.Text))
                            {
                                XtraMessageBox.Show("لطفاً جمع مبلغ سهام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtTedadSahm.Text)
                                 && string.IsNullOrEmpty(txtMablaghHarSahm.Text)
                                 && string.IsNullOrEmpty(txtSumMablagh.Text))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtDarsadVizitor.Text))
                            {
                                XtraMessageBox.Show("لطفاً درصد ویزیتور را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpDarsadVizitor;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtDarsadVizitor.Text))
                            {
                                XtraMessageBox.Show("لطفاً درصد ویزیتور را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpDarsadVizitor;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            int _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtDarsadRanande.Text))
                            {
                                XtraMessageBox.Show("لطفاً درصد راننده را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpDarsadRanande;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(p => p.ShGharadad == txtShGharadad.Text && p.AshkhasId==_AshkhasId);
                            //        if (q1 != null)
                            //        {
                            //            if (XtraMessageBox.Show("این شماره قرارداد قبلاً تعریف شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //            {
                            //                xtraTabControl.SelectedTabPage = tpEetebarat;
                            //                return false;
                            //            }

                            //        }
                            //    }
                            //}
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtDarsadRanande.Text))
                            {
                                XtraMessageBox.Show("لطفاً درصد راننده را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                xtraTabControl.SelectedTabPage = tpDarsadRanande;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(p => p.Id != RowId && p.ShTamas == txtShTamas.Text);
                            //    if (q1 != null)
                            //    {
                            //        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //        {
                            //            xtraTabControl.SelectedTabPage = tpTamas;
                            //            return false;
                            //        }

                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return true;
        }

        private void FrmEtelaateAshkhas_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender, null);
            }
            //else if (e.KeyCode == Keys.F6)
            //{
            //    btnSaveNext_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.F7)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            //else if (e.KeyCode == Keys.F9)
            //{
            //    btnDisplyNotActiveList_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F10)
            //{
            //    btnPrintPreview_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                HelpClass1.MoveLast(gridViewMoshkhasat1);
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                HelpClass1.MoveLast(gridViewAdress1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                HelpClass1.MoveLast(gridViewTamas1);
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                HelpClass1.MoveLast(gridViewEetebar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                HelpClass1.MoveLast(gridViewFazaMajazi1);
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                HelpClass1.MoveLast(gridViewHesabBanki1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                HelpClass1.MoveLast(gridViewTakhfif1);
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                HelpClass1.MoveLast(gridViewMPersoneli1);
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                HelpClass1.MoveLast(gridViewSahmSahamdar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                HelpClass1.MoveLast(gridViewDarsadVizitor1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                HelpClass1.MoveLast(gridViewDarsadRanande1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                HelpClass1.MoveNext(gridViewMoshkhasat1);
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                HelpClass1.MoveNext(gridViewAdress1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                HelpClass1.MoveNext(gridViewTamas1);
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                HelpClass1.MoveNext(gridViewEetebar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                HelpClass1.MoveNext(gridViewFazaMajazi1);
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                HelpClass1.MoveNext(gridViewHesabBanki1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                HelpClass1.MoveNext(gridViewTakhfif1);
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                HelpClass1.MoveNext(gridViewMPersoneli1);
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                HelpClass1.MoveNext(gridViewSahmSahamdar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                HelpClass1.MoveNext(gridViewDarsadVizitor1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                HelpClass1.MoveNext(gridViewDarsadRanande1);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                HelpClass1.MovePrev(gridViewMoshkhasat1);
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                HelpClass1.MovePrev(gridViewAdress1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                HelpClass1.MovePrev(gridViewTamas1);
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                HelpClass1.MovePrev(gridViewEetebar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                HelpClass1.MovePrev(gridViewFazaMajazi1);
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                HelpClass1.MovePrev(gridViewHesabBanki1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                HelpClass1.MovePrev(gridViewTakhfif1);
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                HelpClass1.MovePrev(gridViewMPersoneli1);
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                HelpClass1.MovePrev(gridViewSahmSahamdar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                HelpClass1.MovePrev(gridViewDarsadVizitor1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                HelpClass1.MovePrev(gridViewDarsadRanande1);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                HelpClass1.MoveFirst(gridViewMoshkhasat1);
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                HelpClass1.MoveFirst(gridViewAdress1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                HelpClass1.MoveFirst(gridViewTamas1);
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                HelpClass1.MoveFirst(gridViewEetebar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                HelpClass1.MoveFirst(gridViewFazaMajazi1);
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                HelpClass1.MoveFirst(gridViewHesabBanki1);
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                HelpClass1.MoveFirst(gridViewTakhfif1);
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                HelpClass1.MoveFirst(gridViewMPersoneli1);
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                HelpClass1.MoveFirst(gridViewSahmSahamdar1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                HelpClass1.MoveFirst(gridViewDarsadVizitor1);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                HelpClass1.MoveFirst(gridViewDarsadRanande1);
            }
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTafsiliAshkhas.EditValue) != 0)
            {
                using (var dataContext = new MyContext())
                {
                    try
                    {
                        int AshkhasId = Convert.ToInt32(txtId.Text);
                        IsActiveList = true;
                        if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                        {
                            var q1 = dataContext.EpMoshakhasat_As.Where(s => s.Id == AshkhasId).OrderBy(s => s.Id).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q1.Count > 0)
                                epMoshakhasat_AsBindingSource.DataSource = q1;
                            else
                                epMoshakhasat_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpAdress)
                        {
                            var q2 = dataContext.EpAdress_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q2.Count > 0)
                                epAdress_AsBindingSource.DataSource = q2;
                            else
                                epAdress_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpTamas)
                        {
                            var q3 = dataContext.EpShTamas_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epShTamas_AsBindingSource.DataSource = q3;
                            else
                                epShTamas_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                        {
                            var q3 = dataContext.EpEetebarat_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epEetebarat_AsBindingSource.DataSource = q3;
                            else
                                epEetebarat_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                        {
                            var q3 = dataContext.EpFazaMajazi_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epFazaMajazi_AsBindingSource.DataSource = q3;
                            else
                                epFazaMajazi_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                        {
                            var q3 = dataContext.EpHesabBanki_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epHesabBanki_AsBindingSource.DataSource = q3;
                            else
                                epHesabBanki_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                        {
                            var q3 = dataContext.EpDarsadTakhfif_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epDarsadTakhfif_AsBindingSource.DataSource = q3;
                            else
                                epDarsadTakhfif_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpPersonel)
                        {
                            var q3 = dataContext.EpMPersoneli_As.Where(s => s.Id == AshkhasId).OrderByDescending(s => s.Id).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epMPersoneli_AsBindingSource.DataSource = q3;
                            else
                                epMPersoneli_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                        {
                            var q3 = dataContext.EpSahmSahamdar_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.Id).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epSahmSahamdar_AsBindingSource.DataSource = q3;
                            else
                                epSahmSahamdar_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                        {
                            var q3 = dataContext.EpDarsadVizitor_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epDarsadVizitor_AsBindingSource.DataSource = q3;
                            else
                                epDarsadVizitor_AsBindingSource.DataSource = null;
                        }
                        else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                        {
                            var q3 = dataContext.EpDarsadRanande_As.Where(s => s.AshkhasId == AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q3.Count > 0)
                                epDarsadRanande_AsBindingSource.DataSource = q3;
                            else
                                epDarsadRanande_AsBindingSource.DataSource = null;
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

        private void gridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        public void InActiveButtons()
        {
            //btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled
            //    = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled
            //    = btnFirst.Enabled = false;

            //btnSave.Enabled = true;
            //btnCancel.Enabled = true;
            HelpClass1.InActiveButtons(panelControl6);
        }

        public void ActiveButtons()
        {
            HelpClass1.ActiveButtons(panelControl6);

            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                //btnDelete.Enabled = btnEdit.Enabled = true;
                btnCreate.Enabled = gridViewMoshkhasat1.RowCount == 0 ? true : false;
                //btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = epMoshakhasat_AsBindingSource.DataSource != null ? true : false;
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                //btnDelete.Enabled = btnEdit.Enabled = true;
                btnCreate.Enabled = gridViewMPersoneli1.RowCount == 0 ? true : false;
                //btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = epMoshakhasat_AsBindingSource.DataSource != null ? true : false;
            }
            //else if (xtraTabControl.SelectedTabPage == tpAdress)
            //{
            //btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
            //btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = epAdress_AsBindingSource.DataSource != null ? true : false;
            //}
            //btnSave.Enabled = false;
            // btnCancel.Enabled = false;
        }

        public void ClearControls()
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                //txtNameEkhtesar.Text = string.Empty;
                //txtNoeFaaliat.Text = string.Empty;
                //txtShenaseMelli.Text = string.Empty;
                //txtCodeEghtesadi.Text = string.Empty;
                //txtShomareSabt.Text = string.Empty;
                //txtMolahezat_M.Text = string.Empty;
                HelpClass1.ClearControls(panelControl_Moshakhasat);
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                //cmbNameAdress.EditValue = 0;
                //cmbNameOstan.EditValue = 0;
                //cmbNameShahrstan.EditValue = 0;
                //txtSharhAdress.Text = string.Empty;
                //txtCodePosti.Text = string.Empty;
                //txtSandoghPosti.Text = string.Empty;
                //txtMolahezat_A.Text = string.Empty;
                //chkDefaultAdress.Checked = false;
                HelpClass1.ClearControls(panelControl_Adress);
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                HelpClass1.ClearControls(panelControl_Tamas);
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                HelpClass1.ClearControls(panelControl_Eetebarat);
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                HelpClass1.ClearControls(panelControl_FazaMajazi);
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                HelpClass1.ClearControls(panelControl_HesabBanki);
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                HelpClass1.ClearControls(panelControl_Takhfif);
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                HelpClass1.ClearControls(panelControl_MPersoneli);
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                HelpClass1.ClearControls(panelControl_SahmSahamdar);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                HelpClass1.ClearControls(panelControl_DarsadVizitor);
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                HelpClass1.ClearControls(panelControl_DarsadRanande);
            }
        }

        public void ActiveControls()
        {
            panelControl1.Enabled = false;
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                //txtNameEkhtesar.ReadOnly = false;
                //txtNoeFaaliat.ReadOnly = false;
                //txtShenaseMelli.ReadOnly = false;
                //txtCodeEghtesadi.ReadOnly = false;
                //txtShomareSabt.ReadOnly = false;
                //txtMolahezat_M.ReadOnly = false;
                gridControlMoshkhasat1.Enabled = false;
                panelControl_Moshakhasat.Enabled = true;
                txtNameEkhtesar.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                //cmbNameAdress.ReadOnly = false;
                //cmbNameOstan.ReadOnly = false;
                //cmbNameShahrstan.ReadOnly = false;
                //txtSharhAdress.ReadOnly = false;
                //txtCodePosti.ReadOnly = false;
                //txtSandoghPosti.ReadOnly = false;
                //txtMolahezat_A.ReadOnly = false;
                //chkDefaultAdress.ReadOnly = false;
                //btnAdress.Enabled = true;
                //btnOstan.Enabled = true;
                //btnShahrstan.Enabled = true;
                gridControlAdress1.Enabled = false;
                panelControl_Adress.Enabled = true;
                FillcmbNameAdress();
                FillcmbNameOstan();
                FillcmbNameShahrstan();
                cmbNameAdress.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                gridControlTamas1.Enabled = false;
                panelControl_Tamas.Enabled = true;
                cmbNoeTamas.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                gridControlEetebar1.Enabled = false;
                panelControl_Eetebarat.Enabled = true;
                chkEetebarat.Checked = true;
                txtMablagh.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                gridControlFazaMajazi1.Enabled = false;
                panelControl_FazaMajazi.Enabled = true;
                cmbNameAdress_F.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                gridControlHesabBanki1.Enabled = false;
                panelControl_HesabBanki.Enabled = true;
                FillcmbNameBank();
                cmbNameBank.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                gridControlTakhfif1.Enabled = false;
                panelControl_Takhfif.Enabled = true;
                cmbNoeTakhfif.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                gridControlMPersoneli1.Enabled = false;
                panelControl_MPersoneli.Enabled = true;
                txtCodPersoneli.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                gridControlSahmSahamdar1.Enabled = false;
                panelControl_SahmSahamdar.Enabled = true;
                txtTedadSahm.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                gridControlDarsadVizitor1.Enabled = false;
                panelControl_DarsadVizitor.Enabled = true;
                txtMablaghSabet.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                gridControlDarsadRanande1.Enabled = false;
                panelControl_DarsadRanande.Enabled = true;
                txtMablaghSabet_2.Focus();
            }
        }

        public void InActiveControls()
        {
            panelControl1.Enabled = true;
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                //txtNameEkhtesar.ReadOnly = true;
                //txtNoeFaaliat.ReadOnly = true;
                //txtShenaseMelli.ReadOnly = true;
                //txtCodeEghtesadi.ReadOnly = true;
                //txtShomareSabt.ReadOnly = true;
                //txtMolahezat_M.ReadOnly = true;
                gridControlMoshkhasat1.Enabled = true;
                panelControl_Moshakhasat.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                //cmbNameAdress.ReadOnly = true;
                //cmbNameOstan.ReadOnly = true;
                //cmbNameShahrstan.ReadOnly = true;
                //txtSharhAdress.ReadOnly = true;
                //txtCodePosti.ReadOnly = true;
                //txtSandoghPosti.ReadOnly = true;
                //txtMolahezat_A.ReadOnly = true;
                //chkDefaultAdress.ReadOnly = true;
                //btnAdress.Enabled = false;
                //btnOstan.Enabled = false;
                //btnShahrstan.Enabled = false;
                gridControlAdress1.Enabled = true;
                panelControl_Adress.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                gridControlTamas1.Enabled = true;
                panelControl_Tamas.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                gridControlEetebar1.Enabled = true;
                panelControl_Eetebarat.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                gridControlFazaMajazi1.Enabled = true;
                panelControl_FazaMajazi.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                gridControlHesabBanki1.Enabled = true;
                panelControl_HesabBanki.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                gridControlTakhfif1.Enabled = true;
                panelControl_Takhfif.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                gridControlMPersoneli1.Enabled = true;
                panelControl_MPersoneli.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                gridControlSahmSahamdar1.Enabled = true;
                panelControl_SahmSahamdar.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                gridControlDarsadVizitor1.Enabled = true;
                panelControl_DarsadVizitor.Enabled = false;
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                gridControlDarsadRanande1.Enabled = true;
                panelControl_DarsadRanande.Enabled = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Visible)
            {
                En = EnumCED.Create;
                InActiveButtons();
                ClearControls();
                ActiveControls();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                {
                    if (gridViewMoshkhasat1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewMoshkhasat1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewMoshkhasat1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMoshakhasat_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpMoshakhasat_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        // btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        //if (gridViewMoshkhasat1.RowCount > 0)
                                        //    gridViewMoshkhasat1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                        btnCreate.Enabled = true;

                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpAdress)
                {
                    if (gridViewAdress1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewAdress1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpAdress_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpAdress_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewAdress1.RowCount > 0)
                                            gridViewAdress1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTamas)
                {
                    if (gridViewTamas1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewTamas1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpShTamas_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpShTamas_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        // btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewTamas1.RowCount > 0)
                                            gridViewTamas1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                {
                    if (gridViewEetebar1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewEetebar1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewEetebar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpEetebarat_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpEetebarat_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewEetebar1.RowCount > 0)
                                            gridViewEetebar1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                {
                    if (gridViewFazaMajazi1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewFazaMajazi1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewFazaMajazi1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpFazaMajazi_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpFazaMajazi_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewFazaMajazi1.RowCount > 0)
                                            gridViewFazaMajazi1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                {
                    if (gridViewHesabBanki1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewHesabBanki1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewHesabBanki1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpHesabBanki_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpHesabBanki_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewHesabBanki1.RowCount > 0)
                                            gridViewHesabBanki1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                {
                    if (gridViewTakhfif1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewTakhfif1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewTakhfif1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadTakhfif_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpDarsadTakhfif_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewTakhfif1.RowCount > 0)
                                            gridViewTakhfif1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpPersonel)
                {
                    if (gridViewMPersoneli1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewMPersoneli1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMPersoneli_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpMPersoneli_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewMPersoneli1.RowCount > 0)
                                            gridViewMPersoneli1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                {
                    if (gridViewSahmSahamdar1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewSahmSahamdar1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewSahmSahamdar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpSahmSahamdar_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpSahmSahamdar_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewSahmSahamdar1.RowCount > 0)
                                            gridViewSahmSahamdar1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                {
                    if (gridViewDarsadVizitor1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewDarsadVizitor1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadVizitor1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadVizitor_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpDarsadVizitor_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewDarsadVizitor1.RowCount > 0)
                                            gridViewDarsadVizitor1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                {
                    if (gridViewDarsadRanande1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            EditRowIndex = gridViewDarsadRanande1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadRanande1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadRanande_As.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpDarsadRanande_As.Remove(q);
                                        //db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        //btnDisplyActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewDarsadRanande1.RowCount > 0)
                                            gridViewDarsadRanande1.FocusedRowHandle = EditRowIndex - 1;
                                        ClearControls();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //catch (DbUpdateException)
                                //{
                                //    XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                //        " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                xtraTabControl_SelectedPageChanged(null, null);

            }
        }

        public int EditRowIndex = 0;
        Image img;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Visible)
            {
                if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                {
                    if (gridViewMoshkhasat1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewMoshkhasat1.FocusedRowHandle;

                        txtNameEkhtesar.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NameEkhtesar").ToString();
                        txtNoeFaaliat.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NoeFaaliat").ToString();
                        txtShenaseMelli.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShenaseMelli").ToString();
                        txtCodeEghtesadi.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("CodeEghtesadi").ToString();
                        txtShomareSabt.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShomareSabt").ToString();
                        txtMolahezat_M.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("Molahezat").ToString();
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpMoshakhasat_As.FirstOrDefault(s => s.Id == RowId);
                                if (q1.Pictuer != null)
                                {
                                    MemoryStream ms = new MemoryStream(q1.Pictuer);
                                    pictureEdit1.Image = Image.FromStream(ms);
                                    img = pictureEdit1.Image;
                                }
                                else
                                    pictureEdit1.Image = null;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpAdress)
                {
                    if (gridViewAdress1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewAdress1.FocusedRowHandle;

                        cmbNameAdress.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameAdressId").ToString());
                        cmbNameOstan.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameOstanId").ToString());
                        cmbNameShahrstan.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameShahrstanId").ToString());
                        txtSharhAdress.Text = gridViewAdress1.GetFocusedRowCellValue("SharhAdress").ToString();
                        txtCodePosti.Text = gridViewAdress1.GetFocusedRowCellValue("CodePosti").ToString();
                        txtSandoghPosti.Text = gridViewAdress1.GetFocusedRowCellValue("SandoghPosti").ToString();
                        chkDefaultAdress.Checked = Convert.ToBoolean(gridViewAdress1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_A.Text = gridViewAdress1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTamas)
                {
                    if (gridViewTamas1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewTamas1.FocusedRowHandle;

                        cmbNoeTamas.SelectedIndex = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("IndexNoeTamas").ToString());
                        txtShTamas.Text = gridViewTamas1.GetFocusedRowCellValue("ShTamas").ToString();
                        txtNameTaraf.Text = gridViewTamas1.GetFocusedRowCellValue("NameTaraf").ToString();
                        txtNameGhesmat.Text = gridViewTamas1.GetFocusedRowCellValue("NameGhesmat").ToString();
                        txtShDakheli.Text = gridViewTamas1.GetFocusedRowCellValue("ShDakheli").ToString();
                        chkDefaultShTamas.Checked = Convert.ToBoolean(gridViewTamas1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_T.Text = gridViewTamas1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                {
                    if (gridViewEetebar1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewEetebar1.FocusedRowHandle;

                        txtMablagh.Text = gridViewEetebar1.GetFocusedRowCellValue("Mablagh").ToString();
                        chkEetebarat.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("chkEetebarat"));
                        //chkGharardad.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("chkGharardad"));
                        txtShGharadad.Text = gridViewEetebar1.GetFocusedRowCellValue("ShGharadad").ToString();
                        txtTarikhGharadad.Text = gridViewEetebar1.GetFocusedRowCellValue("TarikhGharadad") != null ? gridViewEetebar1.GetFocusedRowCellValue("TarikhGharadad").ToString() : "";
                        chkDefaultEetebar.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_E.Text = gridViewEetebar1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                {
                    if (gridViewFazaMajazi1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewFazaMajazi1.FocusedRowHandle;

                        cmbNameAdress_F.SelectedIndex = Convert.ToInt32(gridViewFazaMajazi1.GetFocusedRowCellValue("IndexNameAdress"));
                        txtSharhAdress_F.Text = gridViewFazaMajazi1.GetFocusedRowCellValue("SharhAdress").ToString();
                        chkDefaultFazaMajazi.Checked = Convert.ToBoolean(gridViewFazaMajazi1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_F.Text = gridViewFazaMajazi1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                {
                    if (gridViewHesabBanki1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewHesabBanki1.FocusedRowHandle;
                        //FillcmbNameBank();

                        cmbNameBank.EditValue = Convert.ToInt32(gridViewHesabBanki1.GetFocusedRowCellValue("NameBankId"));
                        txtShomareHesab.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareHesab").ToString();
                        txtShomareKart.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareKart").ToString();
                        txtShomareShaba.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareShaba").ToString();
                        txtShomareMoshtari.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                        txtMolahezat_H.Text = gridViewHesabBanki1.GetFocusedRowCellValue("Molahezat").ToString();
                        chkDefaultHesabBanki.Checked = Convert.ToBoolean(gridViewHesabBanki1.GetFocusedRowCellValue("IsDefault"));
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                {
                    if (gridViewTakhfif1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewTakhfif1.FocusedRowHandle;

                        cmbNoeTakhfif.SelectedIndex = Convert.ToInt32(gridViewTakhfif1.GetFocusedRowCellValue("IndexNoeTakhfif"));
                        txtDarsadTakhfif.Text = gridViewTakhfif1.GetFocusedRowCellValue("DarsadTakhfif").ToString();
                        chkTarikh.Checked = Convert.ToBoolean(gridViewTakhfif1.GetFocusedRowCellValue("IsChecked"));
                        txtAzTarikh.Text = gridViewTakhfif1.GetFocusedRowCellValue("AzTarikh") != null ? gridViewTakhfif1.GetFocusedRowCellValue("AzTarikh").ToString() : "";
                        txtTaTarikh.Text = gridViewTakhfif1.GetFocusedRowCellValue("TaTarikh") != null ? gridViewTakhfif1.GetFocusedRowCellValue("TaTarikh").ToString() : "";
                        txtMolahezat_DT.Text = gridViewTakhfif1.GetFocusedRowCellValue("Molahezat").ToString();
                        chkDefaultTakhfif.Checked = Convert.ToBoolean(gridViewTakhfif1.GetFocusedRowCellValue("IsDefault"));
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpPersonel)
                {
                    if (gridViewMPersoneli1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewMPersoneli1.FocusedRowHandle;

                        txtCodPersoneli.Text = gridViewMPersoneli1.GetFocusedRowCellValue("CodPersoneli").ToString();
                        txtTarikhEstekhdam.Text = gridViewMPersoneli1.GetFocusedRowCellValue("TarikhEstekhdam") != null ? gridViewMPersoneli1.GetFocusedRowCellValue("TarikhEstekhdam").ToString() : "";
                        txtTarikhTavalod.Text = gridViewMPersoneli1.GetFocusedRowCellValue("TarikhTavalod") != null ? gridViewMPersoneli1.GetFocusedRowCellValue("TarikhTavalod").ToString() : "";
                        txtNamePedar.Text = gridViewMPersoneli1.GetFocusedRowCellValue("NamePedar").ToString();
                        txtShShenasname.Text = gridViewMPersoneli1.GetFocusedRowCellValue("ShShenasname").ToString();
                        cmbJensiat.SelectedIndex = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("IndexJensiat"));
                        cmbTaahol.SelectedIndex = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("IndexTaahol"));
                        txtShogl.Text = gridViewMPersoneli1.GetFocusedRowCellValue("Shogl").ToString();
                        txtMolahezat_MP.Text = gridViewMPersoneli1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                {
                    if (gridViewSahmSahamdar1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewSahmSahamdar1.FocusedRowHandle;

                        txtTedadSahm.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("TedadSahm").ToString();
                        txtMablaghHarSahm.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("MablaghHarSahm").ToString();
                        txtSumMablagh.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("SumMablagh").ToString();
                        txtMolahezat_SS.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                {
                    if (gridViewDarsadVizitor1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewDarsadVizitor1.FocusedRowHandle;

                        txtMablaghSabet.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("MablaghSabet").ToString();
                        txtDarsadVizitor.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("DarsadVizitor").ToString();
                        chkDefaultDvizitor.Checked = Convert.ToBoolean(gridViewDarsadVizitor1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_DV.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                {
                    if (gridViewDarsadRanande1.RowCount > 0)
                    {
                        En = EnumCED.Edit;
                        InActiveButtons();
                        ActiveControls();
                        EditRowIndex = gridViewDarsadRanande1.FocusedRowHandle;

                        txtMablaghSabet_2.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("MablaghSabet").ToString();
                        txtDarsadRanande.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("DarsadRanande").ToString();
                        chkDefaultDarsadRanande.Checked = Convert.ToBoolean(gridViewDarsadRanande1.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_DR.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpMoshakhasat_A obj = new EpMoshakhasat_A();
                                    obj.Id = Convert.ToInt32(txtId.Text);
                                    obj.NameEkhtesar = txtNameEkhtesar.Text;
                                    obj.NoeFaaliat = txtNoeFaaliat.Text;
                                    obj.ShenaseMelli = txtShenaseMelli.Text;
                                    obj.CodeEghtesadi = txtCodeEghtesadi.Text;
                                    obj.ShomareSabt = txtShomareSabt.Text;
                                    obj.Molahezat = txtMolahezat_M.Text;
                                    if (pictureEdit1.Image != null)
                                    {
                                        MemoryStream ms = new MemoryStream();
                                        img.Save(ms, pictureEdit1.Image.RawFormat);
                                        byte[] myarrey = ms.GetBuffer();
                                        obj.Pictuer = myarrey;
                                    }
                                    else
                                        obj.Pictuer = null;

                                    db.EpMoshakhasat_As.Add(obj);
                                    db.SaveChanges();
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewMoshkhasat1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMoshakhasat_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.NameEkhtesar = txtNameEkhtesar.Text;
                                        q.NoeFaaliat = txtNoeFaaliat.Text;
                                        q.ShenaseMelli = txtShenaseMelli.Text;
                                        q.CodeEghtesadi = txtCodeEghtesadi.Text;
                                        q.ShomareSabt = txtShomareSabt.Text;
                                        q.Molahezat = txtMolahezat_M.Text;
                                        if (pictureEdit1.Image != null)
                                        {
                                            MemoryStream ms = new MemoryStream();
                                            img.Save(ms, pictureEdit1.Image.RawFormat);
                                            byte[] myarrey = ms.GetBuffer();
                                            q.Pictuer = myarrey;
                                        }
                                        else
                                            q.Pictuer = null;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();
                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewMoshkhasat1.RowCount > 0)
                                            gridViewMoshkhasat1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpAdress)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpAdress_A obj = new EpAdress_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.NameAdress = cmbNameAdress.Text;
                                    obj.NameAdressId = Convert.ToInt32(cmbNameAdress.EditValue);
                                    obj.NameOstan = cmbNameOstan.Text;
                                    obj.NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);
                                    obj.NameShahrstan = cmbNameShahrstan.Text;
                                    obj.NameShahrstanId = Convert.ToInt32(cmbNameShahrstan.EditValue);
                                    obj.SharhAdress = txtSharhAdress.Text;
                                    obj.CodePosti = txtCodePosti.Text;
                                    obj.SandoghPosti = txtSandoghPosti.Text;
                                    obj.IsDefault = chkDefaultAdress.Checked;
                                    obj.Molahezat = txtMolahezat_A.Text;

                                    db.EpAdress_As.Add(obj);
                                    db.SaveChanges();
                                    if (chkDefaultAdress.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpAdress_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpAdress_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpAdress_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.NameAdress = cmbNameAdress.Text;
                                        q.NameAdressId = Convert.ToInt32(cmbNameAdress.EditValue);
                                        q.NameOstan = cmbNameOstan.Text;
                                        q.NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);
                                        q.NameShahrstan = cmbNameShahrstan.Text;
                                        q.NameShahrstanId = Convert.ToInt32(cmbNameShahrstan.EditValue);
                                        q.SharhAdress = txtSharhAdress.Text;
                                        q.CodePosti = txtCodePosti.Text;
                                        q.SandoghPosti = txtSandoghPosti.Text;
                                        q.IsDefault = chkDefaultAdress.Checked;
                                        q.Molahezat = txtMolahezat_A.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultAdress.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpAdress_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewAdress1.RowCount > 0)
                                            gridViewAdress1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTamas)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpShTamas_A obj = new EpShTamas_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.NoeTamas = cmbNoeTamas.Text;
                                    obj.IndexNoeTamas = cmbNoeTamas.SelectedIndex;
                                    obj.ShTamas = txtShTamas.Text;
                                    obj.NameTaraf = txtNameTaraf.Text;
                                    obj.NameGhesmat = txtNameGhesmat.Text;
                                    obj.ShDakheli = txtShDakheli.Text;
                                    obj.IsDefault = chkDefaultShTamas.Checked;
                                    obj.Molahezat = txtMolahezat_T.Text;

                                    db.EpShTamas_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultShTamas.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpShTamas_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpShTamas_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpShTamas_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.NoeTamas = cmbNoeTamas.Text;
                                        q.IndexNoeTamas = cmbNoeTamas.SelectedIndex;
                                        q.ShTamas = txtShTamas.Text;
                                        q.NameTaraf = txtNameTaraf.Text;
                                        q.NameGhesmat = txtNameGhesmat.Text;
                                        q.ShDakheli = txtShDakheli.Text;
                                        q.IsDefault = chkDefaultShTamas.Checked;
                                        q.Molahezat = txtMolahezat_T.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultShTamas.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpShTamas_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewTamas1.RowCount > 0)
                                            gridViewTamas1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpEetebarat_A obj = new EpEetebarat_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                    obj.chkEetebarat = chkEetebarat.Checked;
                                    // obj.chkGharardad = chkGharardad.Checked;
                                    obj.ShGharadad = txtShGharadad.Text;
                                    if (!string.IsNullOrEmpty(txtTarikhGharadad.Text))
                                        obj.TarikhGharadad = Convert.ToDateTime(txtTarikhGharadad.Text);
                                    obj.IsDefault = chkDefaultEetebar.Checked;
                                    obj.Molahezat = txtMolahezat_E.Text;

                                    db.EpEetebarat_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultEetebar.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpEetebarat_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpEetebarat_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewEetebar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpEetebarat_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                        q.chkEetebarat = chkEetebarat.Checked;
                                        //  q.chkGharardad = chkGharardad.Checked;
                                        q.ShGharadad = txtShGharadad.Text;
                                        if (!string.IsNullOrEmpty(txtTarikhGharadad.Text))
                                            q.TarikhGharadad = Convert.ToDateTime(txtTarikhGharadad.Text);
                                        q.IsDefault = chkDefaultEetebar.Checked;
                                        q.Molahezat = txtMolahezat_E.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultEetebar.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpEetebarat_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewEetebar1.RowCount > 0)
                                            gridViewEetebar1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpFazaMajazi_A obj = new EpFazaMajazi_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.IndexNameAdress = cmbNameAdress_F.SelectedIndex;
                                    obj.NameAdress = cmbNameAdress_F.Text;
                                    obj.SharhAdress = txtSharhAdress_F.Text;
                                    obj.IsDefault = chkDefaultFazaMajazi.Checked;
                                    obj.Molahezat = txtMolahezat_F.Text;

                                    db.EpFazaMajazi_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultFazaMajazi.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpFazaMajazi_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpFazaMajazi_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewFazaMajazi1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpFazaMajazi_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.IndexNameAdress = cmbNameAdress_F.SelectedIndex;
                                        q.NameAdress = cmbNameAdress_F.Text;
                                        q.SharhAdress = txtSharhAdress_F.Text;
                                        q.IsDefault = chkDefaultFazaMajazi.Checked;
                                        q.Molahezat = txtMolahezat_F.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultFazaMajazi.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpFazaMajazi_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewFazaMajazi1.RowCount > 0)
                                            gridViewFazaMajazi1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpHesabBanki_A obj = new EpHesabBanki_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.NameBankId = Convert.ToInt32(cmbNameBank.EditValue);
                                    obj.NameBank = cmbNameBank.Text;
                                    obj.ShomareHesab = txtShomareHesab.Text;
                                    obj.ShomareKart = txtShomareKart.Text;
                                    obj.ShomareShaba = txtShomareShaba.Text;
                                    obj.ShomareMoshtari = txtShomareMoshtari.Text;
                                    obj.Molahezat = txtMolahezat_H.Text;
                                    obj.IsDefault = chkDefaultHesabBanki.Checked;

                                    db.EpHesabBanki_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultHesabBanki.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpHesabBanki_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpHesabBanki_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewHesabBanki1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpHesabBanki_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.NameBankId = Convert.ToInt32(cmbNameBank.EditValue);
                                        q.NameBank = cmbNameBank.Text;
                                        q.ShomareHesab = txtShomareHesab.Text;
                                        q.ShomareKart = txtShomareKart.Text;
                                        q.ShomareShaba = txtShomareShaba.Text;
                                        q.ShomareMoshtari = txtShomareMoshtari.Text;
                                        q.Molahezat = txtMolahezat_H.Text;
                                        q.IsDefault = chkDefaultHesabBanki.Checked;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultHesabBanki.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpHesabBanki_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewHesabBanki1.RowCount > 0)
                                            gridViewHesabBanki1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpDarsadTakhfif_A obj = new EpDarsadTakhfif_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.IndexNoeTakhfif = cmbNoeTakhfif.SelectedIndex;
                                    obj.NoeTakhfif = cmbNoeTakhfif.Text;
                                    obj.DarsadTakhfif = Convert.ToSingle(txtDarsadTakhfif.Text);
                                    obj.IsChecked = chkTarikh.Checked;
                                    if (!string.IsNullOrEmpty(txtAzTarikh.Text))
                                        obj.AzTarikh = Convert.ToDateTime(txtAzTarikh.Text);
                                    if (!string.IsNullOrEmpty(txtTaTarikh.Text))
                                        obj.TaTarikh = Convert.ToDateTime(txtTaTarikh.Text);
                                    obj.Molahezat = txtMolahezat_DT.Text;
                                    obj.IsDefault = chkDefaultTakhfif.Checked;

                                    db.EpDarsadTakhfif_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultTakhfif.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpDarsadTakhfif_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpDarsadTakhfif_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewTakhfif1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadTakhfif_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.IndexNoeTakhfif = cmbNoeTakhfif.SelectedIndex;
                                        q.NoeTakhfif = cmbNoeTakhfif.Text;
                                        q.DarsadTakhfif = Convert.ToSingle(txtDarsadTakhfif.Text);
                                        q.IsChecked = chkTarikh.Checked;
                                        if (!string.IsNullOrEmpty(txtAzTarikh.Text))
                                            q.AzTarikh = Convert.ToDateTime(txtAzTarikh.Text);
                                        if (!string.IsNullOrEmpty(txtTaTarikh.Text))
                                            q.TaTarikh = Convert.ToDateTime(txtTaTarikh.Text);
                                        q.Molahezat = txtMolahezat_DT.Text;
                                        q.IsDefault = chkDefaultTakhfif.Checked;


                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultTakhfif.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpDarsadTakhfif_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewTakhfif1.RowCount > 0)
                                            gridViewTakhfif1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpPersonel)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpMPersoneli_A obj = new EpMPersoneli_A();
                                    obj.Id = Convert.ToInt32(txtId.Text);
                                    obj.CodPersoneli = Convert.ToInt32(txtCodPersoneli.Text);
                                    obj.NamePedar = txtNamePedar.Text;
                                    obj.ShShenasname = txtShShenasname.Text;
                                    if (!string.IsNullOrEmpty(txtTarikhEstekhdam.Text))
                                        obj.TarikhEstekhdam = Convert.ToDateTime(txtTarikhEstekhdam.Text);
                                    if (!string.IsNullOrEmpty(txtTarikhTavalod.Text))
                                        obj.TarikhTavalod = Convert.ToDateTime(txtTarikhTavalod.Text);
                                    obj.IndexJensiat = cmbJensiat.SelectedIndex;
                                    obj.Jensiat = cmbJensiat.Text;
                                    obj.IndexTaahol = cmbTaahol.SelectedIndex;
                                    obj.Taahol = cmbTaahol.Text;
                                    obj.Shogl = txtShogl.Text;
                                    obj.Molahezat = txtMolahezat_MP.Text;

                                    db.EpMPersoneli_As.Add(obj);
                                    db.SaveChanges();
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMPersoneli_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.CodPersoneli = Convert.ToInt32(txtCodPersoneli.Text);
                                        q.NamePedar = txtNamePedar.Text;
                                        q.ShShenasname = txtShShenasname.Text;
                                        if (!string.IsNullOrEmpty(txtTarikhEstekhdam.Text))
                                            q.TarikhEstekhdam = Convert.ToDateTime(txtTarikhEstekhdam.Text);
                                        if (!string.IsNullOrEmpty(txtTarikhTavalod.Text))
                                            q.TarikhTavalod = Convert.ToDateTime(txtTarikhTavalod.Text);
                                        q.IndexJensiat = cmbJensiat.SelectedIndex;
                                        q.Jensiat = cmbJensiat.Text;
                                        q.IndexTaahol = cmbTaahol.SelectedIndex;
                                        q.Taahol = cmbTaahol.Text;
                                        q.Shogl = txtShogl.Text;
                                        q.Molahezat = txtMolahezat_MP.Text;


                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();
                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewMPersoneli1.RowCount > 0)
                                            gridViewMPersoneli1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpSahmSahamdar_A obj = new EpSahmSahamdar_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.TedadSahm = Convert.ToInt32(txtTedadSahm.Text);
                                    obj.MablaghHarSahm = Convert.ToDecimal(txtMablaghHarSahm.Text.Replace(",", ""));
                                    obj.SumMablagh = Convert.ToDecimal(txtSumMablagh.Text.Replace(",", ""));
                                    obj.Molahezat = txtMolahezat_SS.Text;

                                    db.EpSahmSahamdar_As.Add(obj);
                                    db.SaveChanges();
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewSahmSahamdar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpSahmSahamdar_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.TedadSahm = Convert.ToInt32(txtTedadSahm.Text);
                                        q.MablaghHarSahm = Convert.ToDecimal(txtMablaghHarSahm.Text.Replace(",", ""));
                                        q.SumMablagh = Convert.ToDecimal(txtSumMablagh.Text.Replace(",", ""));
                                        q.Molahezat = txtMolahezat_SS.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();
                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewSahmSahamdar1.RowCount > 0)
                                            gridViewSahmSahamdar1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpDarsadVizitor_A obj = new EpDarsadVizitor_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.MablaghSabet = Convert.ToInt32(txtMablaghSabet.Text.Replace(",", ""));
                                    obj.DarsadVizitor = Convert.ToSingle(txtDarsadVizitor.Text);
                                    obj.IsDefault = chkDefaultDvizitor.Checked;
                                    obj.Molahezat = txtMolahezat_DV.Text;

                                    db.EpDarsadVizitor_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultDvizitor.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpDarsadVizitor_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpDarsadVizitor_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadVizitor1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadVizitor_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.MablaghSabet = Convert.ToInt32(txtMablaghSabet.Text.Replace(",", ""));
                                        q.DarsadVizitor = Convert.ToSingle(txtDarsadVizitor.Text);
                                        q.IsDefault = chkDefaultDvizitor.Checked;
                                        q.Molahezat = txtMolahezat_DV.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultDvizitor.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpDarsadVizitor_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewDarsadVizitor1.RowCount > 0)
                                            gridViewDarsadVizitor1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                {
                    if (En == EnumCED.Create)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    EpDarsadRanande_A obj = new EpDarsadRanande_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.MablaghSabet = Convert.ToInt32(txtMablaghSabet_2.Text.Replace(",", ""));
                                    obj.DarsadRanande = Convert.ToSingle(txtDarsadRanande.Text);
                                    obj.IsDefault = chkDefaultDarsadRanande.Checked;
                                    obj.Molahezat = txtMolahezat_DR.Text;

                                    db.EpDarsadRanande_As.Add(obj);
                                    db.SaveChanges();

                                    if (chkDefaultDarsadRanande.Checked)
                                    {
                                        int _AshkhasId = Convert.ToInt32(txtId.Text);
                                        int _Id = db.EpDarsadRanande_As.Where(f => f.AshkhasId == _AshkhasId).Max(f => f.Id);
                                        var q2 = db.EpDarsadRanande_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != _Id).ToList();
                                        if (q2.Count > 0)
                                        {
                                            foreach (var item in q2)
                                            {
                                                item.IsDefault = false;
                                            }
                                            db.SaveChanges();
                                        }
                                    }

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                    //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    //n1.KeyId = _Code;
                                    //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                    //n1.LevelName = txtName.Text;
                                    //n1.HesabGroupId = q.GroupId;
                                    //n1.HesabColId = q.Id;
                                    //n1.IsActive = chkIsActive.Checked;
                                    //db.EpAllCodingHesabdaris.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    //db.SaveChanges();
                                    btnDisplyActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        if (TextEditValidation())
                        {
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadRanande1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadRanande_As.FirstOrDefault(p => p.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.MablaghSabet = Convert.ToInt32(txtMablaghSabet_2.Text.Replace(",", ""));
                                        q.DarsadRanande = Convert.ToSingle(txtDarsadRanande.Text);
                                        q.IsDefault = chkDefaultDarsadRanande.Checked;
                                        q.Molahezat = txtMolahezat_DR.Text;

                                        /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                        //if (q6.Count > 0)
                                        //{
                                        //    q6.ForEach(item =>
                                        //    {
                                        //        if (CodeBeforeEdit != txtCode.Text)
                                        //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.Code.ToString().Substring(2));
                                        //        if (NameBeforeEdit != txtName.Text)
                                        //            item.ColName = txtName.Text;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q8.Count > 0)
                                        //{
                                        //    q8.ForEach(item =>
                                        //    {
                                        //        if (item.HesabMoinId == 0)
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                        //            if (NameBeforeEdit != txtName.Text)
                                        //                item.LevelName = txtName.Text;
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.KeyId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                        //                + item.ParentId.ToString().Substring(2));
                                        //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //                item.HesabGroupId = _GroupId;
                                        //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //                item.IsActive = chkIsActive.Checked;
                                        //        }
                                        //    });
                                        //}
                                        ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    q9.ForEach(item =>
                                        //    {
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(2));
                                        //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        //            item.HesabGroupId = _GroupId;
                                        //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        //            item.IsActive = chkIsActive.Checked;
                                        //    });
                                        //}
                                        ////////////////////////////////////////////////////////////////////////////////////////
                                        //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        //{
                                        //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                        //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                        //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                        //    if (m != null)
                                        //        m.IsActive = true;
                                        //    if (a1 != null)
                                        //        a1.IsActive = true;
                                        //    //if (a2 != null)
                                        //    //    a2.IsActive = true;
                                        //    if (b1 != null)
                                        //        b1.IsActive = true;
                                        //    //if (b2 != null)
                                        //    //    b2.IsActive = true;
                                        //}

                                        db.SaveChanges();

                                        if (chkDefaultDarsadRanande.Checked)
                                        {
                                            int _AshkhasId = Convert.ToInt32(txtId.Text);
                                            var q2 = db.EpDarsadRanande_As.Where(f => f.AshkhasId == _AshkhasId && f.Id != RowId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                foreach (var item in q2)
                                                {
                                                    item.IsDefault = false;
                                                }
                                                db.SaveChanges();
                                            }
                                        }

                                        btnDisplyActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridViewDarsadRanande1.RowCount > 0)
                                            gridViewDarsadRanande1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled)
            {
                En = EnumCED.Cancel;
                ActiveButtons();
                ClearControls();
                InActiveControls();
                btnCreate.Focus();

            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void xtraTabControl_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnDisplyActiveList_Click(null, null);
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                btnCreate.Enabled = gridViewMoshkhasat1.RowCount == 0 ? true : false;
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
                btnCreate.Enabled = gridViewMPersoneli1.RowCount == 0 ? true : false;
            else
                btnCreate.Enabled = true;

        }

        private void btnAdress_Click(object sender, EventArgs e)
        {
            FrmNameAdress fm = new FrmNameAdress(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();
        }

        private void btnOstan_Click(object sender, EventArgs e)
        {
            FrmNameOstan fm = new FrmNameOstan(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.IsActiveFrmNameOstan = true;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();
        }

        private void btnShahrstan_Click(object sender, EventArgs e)
        {
            FrmNameShahrstan fm = new FrmNameShahrstan(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();
        }

        private void cmbNameOstan_EditValueChanged(object sender, EventArgs e)
        {
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        if (db.EpNameShahrstans.Any())
            //        {
            //            int _NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);
            //            db.EpNameShahrstans.Where(s => s.NameOstanId == _NameOstanId).Load();
            //            epNameShahrstansBindingSource.DataSource = db.EpNameShahrstans.Local.ToBindingList();
            //        }
            //        else
            //        {
            //            epNameShahrstansBindingSource.DataSource = null;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            FillcmbNameShahrstan();
        }

        private void cmbNameAdress_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameAdress.ShowPopup();
            }

        }

        private void cmbNameOstan_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameOstan.ShowPopup();
            }

        }

        private void cmbNameShahrstan_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameShahrstan.ShowPopup();
            }

        }

        private void cmbNoeTamas_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeTamas.ShowPopup();
            }

        }

        private void cmbNameAdress_F_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameAdress_F.ShowPopup();
            }

        }

        private void cmbNamBank_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameBank.ShowPopup();
            }

        }

        private void btnNamBank_Click(object sender, EventArgs e)
        {
            FrmNameBank fm = new FrmNameBank(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();

        }

        private void cmbNoeTakhfif_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeTakhfif.ShowPopup();
            }

        }

        private void chkTarikh_CheckedChanged(object sender, EventArgs e)
        {
            txtAzTarikh.Enabled = txtTaTarikh.Enabled = chkTarikh.Checked ? true : false;
        }

        private void cmbJensiat_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbJensiat.ShowPopup();
            }

        }

        private void cmbTaahol_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbTaahol.ShowPopup();
            }

        }

        private void btnBrowsPictuer_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog XtraOpenFileDialog1 = new XtraOpenFileDialog();
            XtraOpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (XtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(XtraOpenFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                //this.pictureEdit1.Tag = openFileDialog1.FileName;
            }
        }

        private void btnDeletePictuer_Click(object sender, EventArgs e)
        {
            this.pictureEdit1.Image = null;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);

        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewMoshkhasat1.RowCount > 0 ? true : false;
                if (gridViewMoshkhasat1.RowCount > 0)
                {
                    txtNameEkhtesar.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NameEkhtesar").ToString();
                    txtNoeFaaliat.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NoeFaaliat").ToString();
                    txtShenaseMelli.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShenaseMelli").ToString();
                    txtCodeEghtesadi.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("CodeEghtesadi").ToString();
                    txtShomareSabt.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShomareSabt").ToString();
                    txtMolahezat_M.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("Molahezat").ToString();
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpMoshakhasat_As.FirstOrDefault(s => s.Id == RowId);
                            if (q1.Pictuer != null)
                            {
                                MemoryStream ms = new MemoryStream(q1.Pictuer);
                                pictureEdit1.Image = Image.FromStream(ms);
                                img = pictureEdit1.Image;
                            }
                            else
                                pictureEdit1.Image = null;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewAdress1.RowCount > 0 ? true : false;
                if (gridViewAdress1.RowCount > 0)
                {
                    FillcmbNameAdress();
                    FillcmbNameOstan();
                    FillcmbNameShahrstan();
                    cmbNameAdress.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameAdressId").ToString());
                    cmbNameOstan.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameOstanId").ToString());
                    cmbNameShahrstan.EditValue = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("NameShahrstanId").ToString());
                    txtSharhAdress.Text = gridViewAdress1.GetFocusedRowCellValue("SharhAdress").ToString();
                    txtCodePosti.Text = gridViewAdress1.GetFocusedRowCellValue("CodePosti").ToString();
                    txtSandoghPosti.Text = gridViewAdress1.GetFocusedRowCellValue("SandoghPosti").ToString();
                    chkDefaultAdress.Checked = Convert.ToBoolean(gridViewAdress1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_A.Text = gridViewAdress1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewTamas1.RowCount > 0 ? true : false;
                if (gridViewTamas1.RowCount > 0)
                {
                    cmbNoeTamas.SelectedIndex = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("IndexNoeTamas").ToString());
                    txtShTamas.Text = gridViewTamas1.GetFocusedRowCellValue("ShTamas").ToString();
                    txtNameTaraf.Text = gridViewTamas1.GetFocusedRowCellValue("NameTaraf").ToString();
                    txtNameGhesmat.Text = gridViewTamas1.GetFocusedRowCellValue("NameGhesmat").ToString();
                    txtShDakheli.Text = gridViewTamas1.GetFocusedRowCellValue("ShDakheli").ToString();
                    chkDefaultShTamas.Checked = Convert.ToBoolean(gridViewTamas1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_T.Text = gridViewTamas1.GetFocusedRowCellValue("Molahezat").ToString();
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewEetebar1.RowCount > 0 ? true : false;
                if (gridViewEetebar1.RowCount > 0)
                {
                    txtMablagh.Text = gridViewEetebar1.GetFocusedRowCellValue("Mablagh").ToString();
                    chkEetebarat.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("chkEetebarat"));
                    //chkGharardad.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("chkGharardad"));
                    txtShGharadad.Text = gridViewEetebar1.GetFocusedRowCellValue("ShGharadad").ToString();
                    txtTarikhGharadad.Text = gridViewEetebar1.GetFocusedRowCellValue("TarikhGharadad") != null ? gridViewEetebar1.GetFocusedRowCellValue("TarikhGharadad").ToString() : "";
                    chkDefaultEetebar.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_E.Text = gridViewEetebar1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewFazaMajazi1.RowCount > 0 ? true : false;
                if (gridViewFazaMajazi1.RowCount > 0)
                {
                    cmbNameAdress_F.SelectedIndex = Convert.ToInt32(gridViewFazaMajazi1.GetFocusedRowCellValue("IndexNameAdress"));
                    txtSharhAdress_F.Text = gridViewFazaMajazi1.GetFocusedRowCellValue("SharhAdress").ToString();
                    chkDefaultFazaMajazi.Checked = Convert.ToBoolean(gridViewFazaMajazi1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_F.Text = gridViewFazaMajazi1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewHesabBanki1.RowCount > 0 ? true : false;
                if (gridViewHesabBanki1.RowCount > 0)
                {
                    FillcmbNameBank();
                    cmbNameBank.EditValue = Convert.ToInt32(gridViewHesabBanki1.GetFocusedRowCellValue("NameBankId"));
                    txtShomareHesab.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareHesab").ToString();
                    txtShomareKart.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareKart").ToString();
                    txtShomareShaba.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareShaba").ToString();
                    txtShomareMoshtari.Text = gridViewHesabBanki1.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                    txtMolahezat_H.Text = gridViewHesabBanki1.GetFocusedRowCellValue("Molahezat").ToString();
                    chkDefaultHesabBanki.Checked = Convert.ToBoolean(gridViewHesabBanki1.GetFocusedRowCellValue("IsDefault"));
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewTakhfif1.RowCount > 0 ? true : false;
                if (gridViewTakhfif1.RowCount > 0)
                {
                    cmbNoeTakhfif.SelectedIndex = Convert.ToInt32(gridViewTakhfif1.GetFocusedRowCellValue("IndexNoeTakhfif"));
                    txtDarsadTakhfif.Text = gridViewTakhfif1.GetFocusedRowCellValue("DarsadTakhfif").ToString();
                    chkTarikh.Checked = Convert.ToBoolean(gridViewTakhfif1.GetFocusedRowCellValue("IsChecked"));
                    txtAzTarikh.Text = gridViewTakhfif1.GetFocusedRowCellValue("AzTarikh") != null ? gridViewTakhfif1.GetFocusedRowCellValue("AzTarikh").ToString() : "";
                    txtTaTarikh.Text = gridViewTakhfif1.GetFocusedRowCellValue("TaTarikh") != null ? gridViewTakhfif1.GetFocusedRowCellValue("TaTarikh").ToString() : "";
                    txtMolahezat_DT.Text = gridViewTakhfif1.GetFocusedRowCellValue("Molahezat").ToString();
                    chkDefaultTakhfif.Checked = Convert.ToBoolean(gridViewTakhfif1.GetFocusedRowCellValue("IsDefault"));
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewMPersoneli1.RowCount > 0 ? true : false;
                if (gridViewMPersoneli1.RowCount > 0)
                {
                    txtCodPersoneli.Text = gridViewMPersoneli1.GetFocusedRowCellValue("CodPersoneli").ToString();
                    txtTarikhEstekhdam.Text = gridViewMPersoneli1.GetFocusedRowCellValue("TarikhEstekhdam") != null ? gridViewMPersoneli1.GetFocusedRowCellValue("TarikhEstekhdam").ToString() : "";
                    txtTarikhTavalod.Text = gridViewMPersoneli1.GetFocusedRowCellValue("TarikhTavalod") != null ? gridViewMPersoneli1.GetFocusedRowCellValue("TarikhTavalod").ToString() : "";
                    txtNamePedar.Text = gridViewMPersoneli1.GetFocusedRowCellValue("NamePedar").ToString();
                    txtShShenasname.Text = gridViewMPersoneli1.GetFocusedRowCellValue("ShShenasname").ToString();
                    cmbJensiat.SelectedIndex = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("IndexJensiat"));
                    cmbTaahol.SelectedIndex = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("IndexTaahol"));
                    txtShogl.Text = gridViewMPersoneli1.GetFocusedRowCellValue("Shogl").ToString();
                    txtMolahezat_MP.Text = gridViewMPersoneli1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewSahmSahamdar1.RowCount > 0 ? true : false;
                if (gridViewSahmSahamdar1.RowCount > 0)
                {
                    txtTedadSahm.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("TedadSahm").ToString();
                    txtMablaghHarSahm.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("MablaghHarSahm").ToString();
                    txtSumMablagh.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("SumMablagh").ToString();
                    txtMolahezat_SS.Text = gridViewSahmSahamdar1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewDarsadVizitor1.RowCount > 0 ? true : false;
                if (gridViewDarsadVizitor1.RowCount > 0)
                {
                    txtMablaghSabet.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("MablaghSabet").ToString();
                    txtDarsadVizitor.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("DarsadVizitor").ToString();
                    chkDefaultDvizitor.Checked = Convert.ToBoolean(gridViewDarsadVizitor1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_DV.Text = gridViewDarsadVizitor1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewDarsadRanande1.RowCount > 0 ? true : false;
                if (gridViewDarsadRanande1.RowCount > 0)
                {
                    txtMablaghSabet_2.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("MablaghSabet").ToString();
                    txtDarsadRanande.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("DarsadRanande").ToString();
                    chkDefaultDarsadRanande.Checked = Convert.ToBoolean(gridViewDarsadRanande1.GetFocusedRowCellValue("IsDefault"));
                    txtMolahezat_DR.Text = gridViewDarsadRanande1.GetFocusedRowCellValue("Molahezat").ToString();
                }

            }

        }
    }
}