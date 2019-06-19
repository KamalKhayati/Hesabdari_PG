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

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmEtelaateAshkhas : DevExpress.XtraEditors.XtraForm
    {
        public FrmEtelaateAshkhas()
        {
            InitializeComponent();
        }

        public EnumCED En = EnumCED.Save;
        public bool IsActiveList = true;
        public void FillcmbGroupTafzili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafzilis.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafzilis.Where(s => s.IsActive == true && s.Id == 3 || s.Id == 4).Load();
                            epGroupTafzilisBindingSource.DataSource = db.EpGroupTafzilis.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafzilis.Where(s => s.Id == 3 || s.Id == 4).Load();
                            epGroupTafzilisBindingSource.DataSource = db.EpGroupTafzilis.Local.ToBindingList();
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
        public void FillcmbTafziliAshkhas()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTafziliAshkhass.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpHesabTafziliAshkhass.Where(s => s.IsActive == true).Load();
                            epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabTafziliAshkhass.Load();
                            epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
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
            FillcmbGroupTafzili();
            FillcmbTafziliAshkhas();
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
        private void cmbGroupTafzili_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbGroupTafzili.EditValue) == 3)
            {

                using (var db = new MyContext())
                {
                    try
                    {
                        if (db.EpHesabTafziliAshkhass.Any())
                        {
                            if (IsActiveList == true)
                            {
                                db.EpHesabTafziliAshkhass.Where(s => s.IsActive == true && s.GroupTafziliId == 3).Load();
                                epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
                            }
                            else
                            {
                                db.EpHesabTafziliAshkhass.Where(s => s.GroupTafziliId == 3).Load();
                                epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
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
            else if (Convert.ToInt32(cmbGroupTafzili.EditValue) == 4)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (db.EpHesabTafziliAshkhass.Any())
                        {
                            if (IsActiveList == true)
                            {
                                db.EpHesabTafziliAshkhass.Where(s => s.IsActive == true && s.GroupTafziliId == 4).Load();
                                epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
                            }
                            else
                            {
                                db.EpHesabTafziliAshkhass.Where(s => s.GroupTafziliId == 4).Load();
                                epHesabTafziliAshkhassBindingSource.DataSource = db.EpHesabTafziliAshkhass.Local.ToBindingList();
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
            txtGroupTafziliId.Text = cmbGroupTafzili.EditValue.ToString();
        }
        private void cmbTafziliAshkhas_EditValueChanged(object sender, EventArgs e)
        {
            txtId.Text = cmbTafziliAshkhas.EditValue.ToString();
            FillDataGridView();
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTafziliAshkhass.Any())
                    {
                        int AshkhasId = Convert.ToInt32(txtId.Text);
                        var q = db.EpHesabTafziliAshkhass.FirstOrDefault(s => s.Id == AshkhasId);
                        if (q != null)
                        {
                            if (q.GroupTafziliId == 3)
                            {
                                labelControl5.Text = "نام اختصار";
                                labelControl18.Text = "کد ملی";
                            }
                            else
                            {
                                labelControl5.Text = "نام مدیر عامل";
                                labelControl18.Text = "شناسه ملی";

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
            if (Convert.ToInt32(cmbTafziliAshkhas.EditValue) != 0)
            {
                if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                {
                    using (var dataContext = new MyContext())
                    {
                        try
                        {
                            int AshkhasId = Convert.ToInt32(txtId.Text);
                            var q1 = dataContext.EpMoshakhasat_As.Where(s => s.Id == AshkhasId).OrderBy(s => s.Id).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q1.Count > 0)
                                epMoshakhasat_AsBindingSource.DataSource = q1;
                            else
                                epMoshakhasat_AsBindingSource.DataSource = null;
                            //}
                            //else
                            //{
                            //    int _UserId = Convert.ToInt32(lblUserId.Text);
                            //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                            //    if (q1.Count > 0)
                            //    {
                            //        if (q2.Count > 0)
                            //        {
                            //            q2.ForEach(item2 =>
                            //            {
                            //                q1.Remove(dataContext.EpHesabTafziliAshkhass.FirstOrDefault(s => s.Id == item2));
                            //            });
                            //            EpHesabTafziliAshkhassBindingSource.DataSource = q1;
                            //        }
                            //        else
                            //        {
                            //            EpHesabTafziliAshkhassBindingSource.DataSource = q1;
                            //        }
                            //    }
                            //    else
                            //        EpHesabTafziliAshkhassBindingSource.DataSource = null;
                            //}
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (xtraTabControl.SelectedTabPage == tpAdress)
                {
                    using (var dataContext = new MyContext())
                    {
                        try
                        {
                            int AshkhasId = Convert.ToInt32(txtId.Text);
                            var q1 = dataContext.EpAdress_As.Where(s => s.AshkhasId == AshkhasId).OrderBy(s => s.Id).ToList();
                            //if (lblUserId.Text == "1")
                            //{
                            if (q1.Count > 0)
                                epAdress_AsBindingSource.DataSource = q1;
                            else
                                epAdress_AsBindingSource.DataSource = null;
                            //}
                            //else
                            //{
                            //    int _UserId = Convert.ToInt32(lblUserId.Text);
                            //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                            //    if (q1.Count > 0)
                            //    {
                            //        if (q2.Count > 0)
                            //        {
                            //            q2.ForEach(item2 =>
                            //            {
                            //                q1.Remove(dataContext.EpHesabTafziliAshkhass.FirstOrDefault(s => s.Id == item2));
                            //            });
                            //            EpHesabTafziliAshkhassBindingSource.DataSource = q1;
                            //        }
                            //        else
                            //        {
                            //            EpHesabTafziliAshkhassBindingSource.DataSource = q1;
                            //        }
                            //    }
                            //    else
                            //        EpHesabTafziliAshkhassBindingSource.DataSource = null;
                            //}
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                ActiveButtons();
            }
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
                        db.EpNameShahrstans.Load();
                        epNameShahrstansBindingSource.DataSource = db.EpNameShahrstans.Local.ToBindingList();
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
                                InActiveControls();
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
                                InActiveControls();
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
            return true;
        }

        private void FrmEtelaateAshkhas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled == true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            //else if (e.KeyCode == Keys.F8)
            //{
            //    btnDisplyNotActiveList_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F9)
            //{
            //    btnMolahezat_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F10)
            //{
            //    btnAdvancedSearch_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F11)
            //{
            //    btnPrintPreview_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            //{
            //    btnPrint_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridViewMoshkhasat1.MoveLast();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridViewAdress1.MoveLast();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridViewMoshkhasat1.MoveNext();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridViewAdress1.MoveNext();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridViewMoshkhasat1.MovePrev();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridViewAdress1.MovePrev();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridViewMoshkhasat1.MoveFirst();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridViewAdress1.MoveFirst();
            }
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                IsActiveList = true;
                FillDataGridView();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                IsActiveList = true;
                FillDataGridView();
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
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled
                    = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled
                    = btnFirst.Enabled = false;

                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
        public void ActiveButtons()
        {
            if (Convert.ToInt32(cmbTafziliAshkhas.EditValue) != 0)
            {
                if (En == EnumCED.Create || En == EnumCED.Edit || En == EnumCED.Save || En == EnumCED.Cancel)
                {
                    if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                    {
                        btnDelete.Enabled = btnEdit.Enabled = true;
                        btnCreate.Enabled = gridViewMoshkhasat1.RowCount == 0 ? true : false;
                        btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = epMoshakhasat_AsBindingSource.DataSource != null ? true : false;
                    }
                    else if (xtraTabControl.SelectedTabPage == tpAdress)
                    {
                        btnCreate.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
                        btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = epAdress_AsBindingSource.DataSource != null ? true : false;
                    }
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                }
            }
        }

        public void ClearControls()
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                txtNameEkhtesar.Text = string.Empty;
                txtNoeFaaliat.Text = string.Empty;
                txtShenaseMelli.Text = string.Empty;
                txtCodeEghtesadi.Text = string.Empty;
                txtShomareSabt.Text = string.Empty;
                txtMolahezat_M.Text = string.Empty;
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                cmbNameAdress.EditValue = 0;
                cmbNameOstan.EditValue = 0;
                cmbNameShahrstan.EditValue = 0;
                txtSharhAdress.Text = string.Empty;
                txtCodePosti.Text = string.Empty;
                txtSandoghPosti.Text = string.Empty;
                txtMolahezat_A.Text = string.Empty;
                chkDefaultAdress.Checked = false;
            }
        }

        public void ActiveControls()
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                if (En == EnumCED.Create || En == EnumCED.Edit)
                {
                    txtNameEkhtesar.ReadOnly = false;
                    txtNoeFaaliat.ReadOnly = false;
                    txtShenaseMelli.ReadOnly = false;
                    txtCodeEghtesadi.ReadOnly = false;
                    txtShomareSabt.ReadOnly = false;
                    txtMolahezat_M.ReadOnly = false;
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                if (En == EnumCED.Create || En == EnumCED.Edit)
                {
                    cmbNameAdress.ReadOnly = false;
                    cmbNameOstan.ReadOnly = false;
                    cmbNameShahrstan.ReadOnly = false;
                    txtSharhAdress.ReadOnly = false;
                    txtCodePosti.ReadOnly = false;
                    txtSandoghPosti.ReadOnly = false;
                    txtMolahezat_A.ReadOnly = false;
                    chkDefaultAdress.ReadOnly = false;
                    btnAdress.Enabled = true;
                    btnOstan.Enabled = true;
                    btnShahrstan.Enabled = true;
                }
            }
        }

        public void InActiveControls()
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                if (En == EnumCED.Create || En == EnumCED.Edit)
                {
                    txtNameEkhtesar.ReadOnly = true;
                    txtNoeFaaliat.ReadOnly = true;
                    txtShenaseMelli.ReadOnly = true;
                    txtCodeEghtesadi.ReadOnly = true;
                    txtShomareSabt.ReadOnly = true;
                    txtMolahezat_M.ReadOnly = true;
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                if (En == EnumCED.Create || En == EnumCED.Edit)
                {
                    cmbNameAdress.ReadOnly = true;
                    cmbNameOstan.ReadOnly = true;
                    cmbNameShahrstan.ReadOnly = true;
                    txtSharhAdress.ReadOnly = true;
                    txtCodePosti.ReadOnly = true;
                    txtSandoghPosti.ReadOnly = true;
                    txtMolahezat_A.ReadOnly = true;
                    chkDefaultAdress.ReadOnly = true;
                    btnAdress.Enabled = false ;
                    btnOstan.Enabled = false;
                    btnShahrstan.Enabled = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                txtNameEkhtesar.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                FillcmbNameAdress();
                FillcmbNameOstan();
                FillcmbNameShahrstan();
                cmbNameAdress.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                if (gridViewMoshkhasat1.SelectedRowsCount > 0)
                {
                    if (XtraMessageBox.Show("آیا ردیف جاری حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridViewMoshkhasat1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridViewMoshkhasat1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpMoshakhasat_As.FirstOrDefault(p => p.Id == RowId);
                                //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                if (q != null /*&& q8 != null*/)
                                {
                                    db.EpMoshakhasat_As.Remove(q);
                                    //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyActiveList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridViewMoshkhasat1.RowCount > 0)
                                        gridViewMoshkhasat1.FocusedRowHandle = EditRowIndex - 1;
                                    btnCreate.Enabled = gridViewMoshkhasat1.RowCount == 0 ? true : false;

                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                    " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                    "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (gridViewAdress1.SelectedRowsCount > 0)
                {
                    if (XtraMessageBox.Show("آیا ردیف جاری حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridViewAdress1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpAdress_As.FirstOrDefault(p => p.Id == RowId);
                                //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                if (q != null /*&& q8 != null*/)
                                {
                                    db.EpAdress_As.Remove(q);
                                    //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyActiveList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridViewAdress1.RowCount > 0)
                                        gridViewAdress1.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                    " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                    "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                if (gridViewMoshkhasat1.SelectedRowsCount > 0 && btnEdit.Visible == true)
                {
                    gridControlMoshkhasat1.Enabled = false;
                    EditRowIndex = gridViewMoshkhasat1.FocusedRowHandle;

                    txtNameEkhtesar.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NameEkhtesar").ToString();
                    txtNoeFaaliat.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("NoeFaaliat").ToString();
                    txtShenaseMelli.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShenaseMelli").ToString();
                    txtCodeEghtesadi.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("CodeEghtesadi").ToString();
                    txtShomareSabt.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("ShomareSabt").ToString();
                    txtMolahezat_M.Text = gridViewMoshkhasat1.GetFocusedRowCellValue("Molahezat").ToString();

                    En = EnumCED.Edit;
                    InActiveButtons();
                    ActiveControls();
                    txtNameEkhtesar.Focus();
                }
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                if (gridViewAdress1.SelectedRowsCount > 0 && btnEdit.Visible == true)
                {
                    gridControlAdress1.Enabled = false;
                    EditRowIndex = gridViewAdress1.FocusedRowHandle;
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

                    En = EnumCED.Edit;
                    InActiveButtons();
                    ActiveControls();
                    cmbNameAdress.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                                db.EpMoshakhasat_As.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafziliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                //EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                                //n1.KeyId = _Code;
                                //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //n1.LevelName = txtName.Text;
                                //n1.HesabGroupId = q.GroupId;
                                //n1.HesabColId = q.Id;
                                //n1.IsActive = chkIsActive.Checked;
                                //db.EpAccessLevelCodingHesabdaris.Add(n1);
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //db.SaveChanges();
                                btnDisplyActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                gridViewMoshkhasat1.MoveLast();
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
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
                                    //var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //    var a1 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var a2 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    //    var b1 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var b2 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
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
                                    gridControlMoshkhasat1.Enabled = true;
                                    ActiveButtons();
                                    ClearControls();
                                    InActiveControls();
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
            if (xtraTabControl.SelectedTabPage == tpAdress)
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
                                obj.NameAdressId = Convert.ToInt32(cmbNameAdress.EditValue) ;
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
                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafziliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                //EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                                //n1.KeyId = _Code;
                                //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //n1.LevelName = txtName.Text;
                                //n1.HesabGroupId = q.GroupId;
                                //n1.HesabColId = q.Id;
                                //n1.IsActive = chkIsActive.Checked;
                                //db.EpAccessLevelCodingHesabdaris.Add(n1);
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //db.SaveChanges();
                                btnDisplyActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                gridViewAdress1.MoveLast();
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
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
                                    //var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //    var a1 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var a2 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    //    var b1 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var b2 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
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
                                    if (gridViewAdress1.RowCount > 0)
                                        gridViewAdress1.FocusedRowHandle = EditRowIndex;
                                    gridControlAdress1.Enabled = true;
                                    ActiveButtons();
                                    ClearControls();
                                    InActiveControls();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActiveButtons();
            ClearControls();
            InActiveControls();
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridControlMoshkhasat1.Enabled = true;
            }
            if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridControlAdress1.Enabled = true;
            }
            En = EnumCED.Cancel;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewMoshkhasat1.RowCount > 0 ? true : false;
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                btnDelete.Enabled = btnEdit.Enabled = gridViewAdress1.RowCount > 0 ? true : false;
            }

        }

        private void xtraTabControl_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnDisplyActiveList_Click(null, null);
        }

        private void btnAdress_Click(object sender, EventArgs e)
        {
            FrmNameAdress fm = new FrmNameAdress(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.ShowDialog();
        }

        private void btnOstan_Click(object sender, EventArgs e)
        {
            FrmNameOstan fm = new FrmNameOstan(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.IsActiveFrmNameOstan = true;
            fm.ShowDialog();
        }

        private void btnShahrstan_Click(object sender, EventArgs e)
        {
            FrmNameShahrstan fm = new FrmNameShahrstan(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.ShowDialog();
        }

        private void cmbNameOstan_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpNameShahrstans.Any())
                    {
                        int _NameOstanId= Convert.ToInt32(cmbNameOstan.EditValue);
                        db.EpNameShahrstans.Where(s=>s.NameOstanId== _NameOstanId).Load();
                        epNameShahrstansBindingSource.DataSource = db.EpNameShahrstans.Local.ToBindingList();
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
    }
}