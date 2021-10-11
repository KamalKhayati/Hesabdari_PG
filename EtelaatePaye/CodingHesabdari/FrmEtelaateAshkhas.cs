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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmEtelaateAshkhas : DevExpress.XtraEditors.XtraForm
    {
        public FrmEtelaateAshkhas()
        {
            InitializeComponent();
        }

        public EnumCED En = EnumCED.None;

        int _SalId = 0;
        //public int _levelNamber = 0;
        int _TabaghehIndex = 0;
        public int _GroupTafsiliId = 0;
        int Before_GroupTafsili_EditValueChanged = 0;
        public int _AshkhasId = 0;
        string _SelectedTabPage = string.Empty;
        public int EditRowIndex = 0;
        Image img;


        GridControl gridControl;
        GridView gridView;
        LookUpEdit cmmbGroupTafsili;
        SimpleButton btnReloadGroupTafsili;
        TextEdit textCode;
        TextEdit txtGroupCode;
        CheckEdit chkEditCode;
        SimpleButton btnNewCode;
        TextEdit txtIndex;
        TextEdit textId;
        TextEdit txtName;
        TextEdit txtTarikhEjad;
        CheckEdit chkIsActive;
        TextEdit txtSharh;
        PanelControl PanelControl_1;
        PanelControl PanelControl_2;

        public void FillcmbGroupTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    var q = db.EpAllGroupTafsilis.Where(s => s.SalId == _SalId && s.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex
                    || s.EpGroupTafsiliLevel2.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex
                    || s.EpGroupTafsiliLevel3.EpGroupTafsiliLevel2.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex).OrderBy(s => s.KeyCode).ToList();
                    cmbGroupTafsili.Properties.DataSource = q.Count > 0 ? q : null;
                    cmbGroupTafsili.EditValue = _GroupTafsiliId;
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
            cmbGroupTafsili_EditValueChanged(null, null);
            FillDataGridView();
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        _SalId = Convert.ToInt32(lblSalId.Text);
            //        btnDelete.Enabled = btnEdit.Enabled = false;
            //        if (Convert.ToInt32(cmbGroupTafsili.EditValue) != 0)
            //        {
            //            int _GroupTafsiliId = Convert.ToInt32(cmbGroupTafsili.EditValue);
            //            var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId && s.LevelNumber == _levelNamber && s.GroupTafsiliId == _GroupTafsiliId).OrderBy(s => s.Code).ToList();
            //            epHesabTafsiliAshkhassBindingSource.DataSource = q.Count > 0 ? q : null;
            //        }
            //        else if (Convert.ToInt32(cmbGroupTafsili.EditValue) == 0)
            //        {
            //            // int _GroupTafsiliId = Convert.ToInt32(cmbGroupTafsili.EditValue);
            //            var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId && s.LevelNumber == _levelNamber).OrderBy(s => s.Code).ToList();
            //            epHesabTafsiliAshkhassBindingSource.DataSource = q.Count > 0 ? q : null;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }
        private void FrmEtelaateAshkhas_Load(object sender, EventArgs e)
        {
            FillcmbGroupTafsili();
            FillcmbTafsiliAshkhas();
            gridControl = gridControlMoshkhasat1;
            gridView = gridViewMoshkhasat1;
            txtIndex = txtIndex_Moshakhasat;
            PanelControl_1 = panelControl_Buttons;
            PanelControl_2 = panelControl_Moshakhasat;
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            if (Convert.ToInt32(cmbTafsiliAshkhas.EditValue) != 0)
                btnCreate.Enabled = gridView.RowCount == 0 ? true : false;

            _TabaghehIndex = 0;
            _SalId = Convert.ToInt32(lblSalId.Text);
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
            if (btnClose.Enabled)
            {
                this.Close();

            }
        }
        private void cmbGroupTafsili_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _GroupTafsiliId = Convert.ToInt32(cmbGroupTafsili.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    if (_GroupTafsiliId != 0)
                    {
                        var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId && s.GroupTafsiliId == _GroupTafsiliId).OrderBy(s => s.Code).ToList();
                        epHesabTafsiliAshkhassBindingSource.DataSource = q.Count > 0 ? q : null;
                    }
                    else
                    {
                        var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        epHesabTafsiliAshkhassBindingSource.DataSource = q.Count > 0 ? q : null;
                    }
                    cmbTafsiliAshkhas.EditValue = _AshkhasId;
                    btnCreate.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
                        tpPersonel.PageVisible = q.IsPersonel;
                        tpSahmSahamdar.PageVisible = q.IsSahamdar;
                        tpDarsadVizitor.PageVisible = q.IsVizitor;
                        tpDarsadRanande.PageVisible = q.IsRanande;
                        btnCreate.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
                    }
                    else
                    {
                        tpPersonel.PageVisible = false;
                        tpSahmSahamdar.PageVisible = false;
                        tpDarsadVizitor.PageVisible = false;
                        tpDarsadRanande.PageVisible = false;
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
                        _AshkhasId = Convert.ToInt32(txtId.Text);
                        var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id == _AshkhasId);
                        if (q != null)
                        {
                            labelControl5.Text = q.IsHaghighi == true ? "نام اختصار" : "نام مدیر عامل";
                            //labelControl18.Text = q.IsHaghighi == true ? "کد ملی" : "شناسه ملی";
                            //txtShenaseMelli.Properties.MaxLength = q.IsHaghighi == true ? 11 : 11;
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
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            if (Convert.ToInt32(cmbTafsiliAshkhas.EditValue) != 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _AshkhasId = Convert.ToInt32(txtId.Text);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        //////////////////////////////epMoshakhasat_AsBindingSource//////////////////////////////
                        var q1 = db.EpMoshakhasat_As.Where(s => s.SalId == _SalId && s.Id == _AshkhasId).OrderBy(s => s.Id).ToList();
                        epMoshakhasat_AsBindingSource.DataSource = q1.Count > 0 ? q1 : null;
                        //////////////////////////////epAdress_AsBindingSource//////////////////////////////
                        var q2 = db.EpAdress_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epAdress_AsBindingSource.DataSource = q2.Count > 0 ? q2 : null;
                        //////////////////////////////epShTamas_AsBindingSource//////////////////////////////
                        var q3 = db.EpShTamas_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epShTamas_AsBindingSource.DataSource = q3.Count > 0 ? q3 : null;
                        //////////////////////////////epEetebarat_AsBindingSource//////////////////////////////
                        var q4 = db.EpEetebarat_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epEetebarat_AsBindingSource.DataSource = q4.Count > 0 ? q4 : null;
                        //////////////////////////////epFazaMajazi_AsBindingSource//////////////////////////////
                        var q5 = db.EpFazaMajazi_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epFazaMajazi_AsBindingSource.DataSource = q5.Count > 0 ? q5 : null;
                        //////////////////////////////epHesabBanki_AsBindingSource//////////////////////////////
                        var q6 = db.EpHesabBanki_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epHesabBanki_AsBindingSource.DataSource = q6.Count > 0 ? q6 : null;
                        //////////////////////////////epDarsadTakhfif_AsBindingSource//////////////////////////////
                        var q7 = db.EpDarsadTakhfif_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epDarsadTakhfif_AsBindingSource.DataSource = q7.Count > 0 ? q7 : null;
                        //////////////////////////////epMPersoneli_AsBindingSource//////////////////////////////
                        var q8 = db.EpMPersoneli_As.Where(s => s.SalId == _SalId && s.Id == _AshkhasId).OrderByDescending(s => s.Id).ToList();
                        epMPersoneli_AsBindingSource.DataSource = q8.Count > 0 ? q8 : null;
                        //////////////////////////////epSahmSahamdar_AsBindingSource//////////////////////////////
                        var q9 = db.EpSahmSahamdar_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.Id).ToList();
                        epSahmSahamdar_AsBindingSource.DataSource = q9.Count > 0 ? q9 : null;
                        //////////////////////////////epDarsadVizitor_AsBindingSource//////////////////////////////
                        var q10 = db.EpDarsadVizitor_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epDarsadVizitor_AsBindingSource.DataSource = q10.Count > 0 ? q10 : null;
                        //////////////////////////////epDarsadRanande_AsBindingSource//////////////////////////////
                        var q11 = db.EpDarsadRanande_As.Where(s => s.SalId == _SalId && s.AshkhasId == _AshkhasId).OrderByDescending(s => s.IsDefault).ToList();
                        epDarsadRanande_AsBindingSource.DataSource = q11.Count > 0 ? q11 : null;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                    var q = db.EpNameAdresss.Where(s => s.SalId == _SalId).ToList();
                    epAdressNamesBindingSource.DataSource = q.Count > 0 ? q : null;
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
                    var q = db.EpNameOstans.Where(s => s.SalId == _SalId).ToList();
                    epNameOstansBindingSource.DataSource = q.Count > 0 ? q : null;
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
                    if (Convert.ToInt32(cmbNameOstan.EditValue) != 0)
                    {
                        int _NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);
                        var q = db.EpNameShahrstans.Where(s => s.SalId == _SalId && s.NameOstanId == _NameOstanId).ToList();
                        epNameShahrstansBindingSource.DataSource = q.Count > 0 ? q : null;
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
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpNameBanks.Where(s => s.SalId == _SalId).ToList();
                    epNameBanksBindingSource.DataSource = q.Count > 0 ? q : null;
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
                            if (string.IsNullOrEmpty(txtNameEkhtesar.Text.Trim()) && string.IsNullOrEmpty(txtNoeFaaliat.Text.Trim())
                                && string.IsNullOrEmpty(txtShenaseMelli.Text.Trim()) && string.IsNullOrEmpty(txtCodeEghtesadi.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareSabt.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_M.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                var q1 = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.ShenaseMelli == txtShenaseMelli.Text.Trim());
                                var q2 = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.CodeEghtesadi == txtCodeEghtesadi.Text.Trim());
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد/شناسه ملی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                    return false;
                                }
                                if (q2 != null)
                                {
                                    XtraMessageBox.Show("این کداقتصادی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(txtNameEkhtesar.Text.Trim()) && string.IsNullOrEmpty(txtNoeFaaliat.Text.Trim())
                                && string.IsNullOrEmpty(txtShenaseMelli.Text.Trim()) && string.IsNullOrEmpty(txtCodeEghtesadi.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareSabt.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_M.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                return false;
                            }
                            else
                            {
                                _AshkhasId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.Id != _AshkhasId && s.ShenaseMelli == txtShenaseMelli.Text.Trim());
                                var q2 = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.Id != _AshkhasId && s.CodeEghtesadi == txtCodeEghtesadi.Text.Trim());
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد/شناسه ملی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
                                    //xtraTabControl.SelectedTabPage = tpMoshakhasat;
                                    return false;
                                }
                                if (q2 != null)
                                {
                                    XtraMessageBox.Show("این کداقتصادی قبلاً برای شخص دیگری استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // xtraTabControl.SelectedTabPage = tpMoshakhasat;
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
                            if (string.IsNullOrEmpty(cmbNameAdress.Text.Trim()) && string.IsNullOrEmpty(cmbNameOstan.Text.Trim())
                                && string.IsNullOrEmpty(cmbNameShahrstan.Text.Trim()) && string.IsNullOrEmpty(txtSharhAdress.Text.Trim())
                                && string.IsNullOrEmpty(txtCodePosti.Text.Trim()) && string.IsNullOrEmpty(txtSandoghPosti.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_A.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                if (db.EpAdress_As.Any())
                                {
                                    var q1 = db.EpAdress_As.FirstOrDefault(s => s.SalId == _SalId && s.CodePosti == txtCodePosti.Text);
                                    var q2 = db.EpAdress_As.FirstOrDefault(s => s.SalId == _SalId && s.SandoghPosti == txtSandoghPosti.Text);
                                    if (q1 != null)
                                    {
                                        if (XtraMessageBox.Show("این کد پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            //xtraTabControl.SelectedTabPage = tpAdress;
                                            return false;
                                        }

                                    }
                                    if (q2 != null)
                                    {
                                        if (XtraMessageBox.Show("این صندوق پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            //xtraTabControl.SelectedTabPage = tpAdress;
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(cmbNameAdress.Text.Trim()) && string.IsNullOrEmpty(cmbNameOstan.Text.Trim())
                                && string.IsNullOrEmpty(cmbNameShahrstan.Text.Trim()) && string.IsNullOrEmpty(txtSharhAdress.Text.Trim())
                                && string.IsNullOrEmpty(txtCodePosti.Text.Trim()) && string.IsNullOrEmpty(txtSandoghPosti.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_A.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // xtraTabControl.SelectedTabPage = tpAdress;
                                return false;
                            }
                            else
                            {
                                int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                var q1 = db.EpAdress_As.FirstOrDefault(s => s.SalId == _SalId && s.Id != RowId && s.CodePosti == txtCodePosti.Text);
                                var q2 = db.EpAdress_As.FirstOrDefault(s => s.SalId == _SalId && s.Id != RowId && s.SandoghPosti == txtSandoghPosti.Text);
                                if (q1 != null)
                                {
                                    if (XtraMessageBox.Show("این کد پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        //xtraTabControl.SelectedTabPage = tpAdress;
                                        return false;
                                    }

                                }
                                if (q2 != null)
                                {
                                    if (XtraMessageBox.Show("این صندوق پستی قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        //xtraTabControl.SelectedTabPage = tpAdress;
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
                            if (string.IsNullOrEmpty(cmbNoeTamas.Text.Trim()) && string.IsNullOrEmpty(txtShTamas.Text.Trim()) && string.IsNullOrEmpty(txtNameTaraf.Text.Trim()) && string.IsNullOrEmpty(txtNameGhesmat.Text.Trim())
                                && string.IsNullOrEmpty(txtShDakheli.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_T.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            else
                            {
                                if (db.EpShTamas_As.Any())
                                {
                                    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.SalId == _SalId && s.ShTamas == txtShTamas.Text);
                                    if (q1 != null)
                                    {
                                        if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            //xtraTabControl.SelectedTabPage = tpTamas;
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            if (string.IsNullOrEmpty(cmbNoeTamas.Text.Trim()) && string.IsNullOrEmpty(txtShTamas.Text.Trim()) && string.IsNullOrEmpty(txtNameTaraf.Text.Trim()) && string.IsNullOrEmpty(txtNameGhesmat.Text.Trim())
                                && string.IsNullOrEmpty(txtShDakheli.Text.Trim()) && string.IsNullOrEmpty(txtMolahezat_T.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpTamas;
                                return false;
                            }
                            else
                            {
                                int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                                var q1 = db.EpShTamas_As.FirstOrDefault(s => s.SalId == _SalId && s.Id != RowId && s.ShTamas == txtShTamas.Text);
                                if (q1 != null)
                                {
                                    if (XtraMessageBox.Show("این شماره تماس قبلاً برای شخص دیگری استفاده شده است" + "\n" + "آیا اطلاعات ذخیره شود؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        //xtraTabControl.SelectedTabPage = tpTamas;
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtMablagh.Text.Trim())
                                && string.IsNullOrEmpty(txtShGharadad.Text.Trim())
                                && string.IsNullOrEmpty(txtTaEngheza_E.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(txtMablagh.Text.Trim())
                                && string.IsNullOrEmpty(txtShGharadad.Text.Trim())
                                && string.IsNullOrEmpty(txtTaEngheza_E.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpEetebarat;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(cmbNameAdress_F.Text.Trim())
                                && string.IsNullOrEmpty(txtSharhAdress_F.Text.Trim())
                                && string.IsNullOrEmpty(txtMolahezat_F.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(cmbNameAdress_F.Text.Trim())
                                && string.IsNullOrEmpty(txtSharhAdress_F.Text.Trim())
                                && string.IsNullOrEmpty(txtMolahezat_F.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpFazaMajazi;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtShomareHesab.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareKart.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareShaba.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareMoshtari.Text.Trim())
                                && string.IsNullOrEmpty(txtMolahezat_H.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            else if ((!string.IsNullOrEmpty(txtShomareHesab.Text.Trim())
                                || !string.IsNullOrEmpty(txtShomareKart.Text.Trim())
                                || !string.IsNullOrEmpty(txtShomareShaba.Text.Trim())
                                || !string.IsNullOrEmpty(txtShomareMoshtari.Text.Trim())
                                || !string.IsNullOrEmpty(txtMolahezat_H.Text.Trim()))
                                && string.IsNullOrEmpty(cmbNameBank.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً نام بانک را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(txtShomareHesab.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareKart.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareShaba.Text.Trim())
                                && string.IsNullOrEmpty(txtShomareMoshtari.Text.Trim())
                                && string.IsNullOrEmpty(txtMolahezat_H.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            //if (string.IsNullOrEmpty(txtDarsadTakhfifRadifi.Text.Trim()))
                            //{
                            //    XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    //btnCancel_Click(null, null);
                            //    return false;
                            //}
                            if ((string.IsNullOrEmpty(txtDarsadTakhfifRadifi.Text.Trim()) || txtDarsadTakhfifRadifi.Text.Trim() == "0") && (string.IsNullOrEmpty(txtDarsadTakhfifJamei.Text.Trim()) || txtDarsadTakhfifJamei.Text.Trim() == "0"))
                            {
                                XtraMessageBox.Show("لطفاً درصد تخفیف را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpTakhfif;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if ((string.IsNullOrEmpty(txtDarsadTakhfifRadifi.Text.Trim()) || txtDarsadTakhfifRadifi.Text.Trim() == "0") && (string.IsNullOrEmpty(txtDarsadTakhfifJamei.Text.Trim()) || txtDarsadTakhfifJamei.Text.Trim() == "0"))
                            {
                                XtraMessageBox.Show("لطفاً درصد تخفیف را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpHesabBanki;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if ((!string.IsNullOrEmpty(txtCodPersoneli.Text.Trim())
                                || !string.IsNullOrEmpty(txtTarikhEstekhdam.Text.Trim())
                                || !string.IsNullOrEmpty(txtNamePedar.Text.Trim())
                                || !string.IsNullOrEmpty(txtShShenasname.Text.Trim())
                                || !string.IsNullOrEmpty(txtTarikhTavalod.Text.Trim())
                                || !string.IsNullOrEmpty(txtShogl.Text.Trim())
                                || !string.IsNullOrEmpty(txtMolahezat_MP.Text.Trim()))
                               && string.IsNullOrEmpty(cmbJensiat.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً جنسیت را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            if ((!string.IsNullOrEmpty(txtCodPersoneli.Text.Trim())
                                || !string.IsNullOrEmpty(txtTarikhEstekhdam.Text.Trim())
                                || !string.IsNullOrEmpty(txtNamePedar.Text.Trim())
                                || !string.IsNullOrEmpty(txtShShenasname.Text.Trim())
                                || !string.IsNullOrEmpty(txtTarikhTavalod.Text.Trim())
                                || !string.IsNullOrEmpty(txtShogl.Text.Trim())
                                || !string.IsNullOrEmpty(txtMolahezat_MP.Text.Trim()))
                               && string.IsNullOrEmpty(cmbTaahol.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً وضعیت تأهل را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtCodPersoneli.Text.Trim())
                                     && string.IsNullOrEmpty(txtTarikhEstekhdam.Text.Trim())
                                     && string.IsNullOrEmpty(txtNamePedar.Text.Trim())
                                     && string.IsNullOrEmpty(txtShShenasname.Text.Trim())
                                     && string.IsNullOrEmpty(txtTarikhTavalod.Text.Trim())
                                     && string.IsNullOrEmpty(txtShogl.Text.Trim())
                                     && string.IsNullOrEmpty(txtMolahezat_MP.Text.Trim())
                                     && string.IsNullOrEmpty(cmbTaahol.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(txtCodPersoneli.Text.Trim())
                                     && string.IsNullOrEmpty(txtTarikhEstekhdam.Text.Trim())
                                     && string.IsNullOrEmpty(txtNamePedar.Text.Trim())
                                     && string.IsNullOrEmpty(txtShShenasname.Text.Trim())
                                     && string.IsNullOrEmpty(txtTarikhTavalod.Text.Trim())
                                     && string.IsNullOrEmpty(txtShogl.Text.Trim())
                                     && string.IsNullOrEmpty(txtMolahezat_MP.Text.Trim())
                                     && string.IsNullOrEmpty(cmbTaahol.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpPersonel;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if ((!string.IsNullOrEmpty(txtTedadSahm.Text.Trim())
                                || !string.IsNullOrEmpty(txtMablaghHarSahm.Text.Trim()))
                               && string.IsNullOrEmpty(txtSumMablagh.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً جمع مبلغ سهام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtTedadSahm.Text.Trim())
                                     && string.IsNullOrEmpty(txtMablaghHarSahm.Text.Trim())
                                     && string.IsNullOrEmpty(txtSumMablagh.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //btnCancel_Click(null, null);
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if ((!string.IsNullOrEmpty(txtTedadSahm.Text.Trim())
                                || !string.IsNullOrEmpty(txtMablaghHarSahm.Text.Trim()))
                               && string.IsNullOrEmpty(txtSumMablagh.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً جمع مبلغ سهام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            else if (string.IsNullOrEmpty(txtTedadSahm.Text.Trim())
                                     && string.IsNullOrEmpty(txtMablaghHarSahm.Text.Trim())
                                     && string.IsNullOrEmpty(txtSumMablagh.Text.Trim()))
                            {
                                XtraMessageBox.Show("هیچگونه اطلاعاتی برای ذخیره وارد نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // xtraTabControl.SelectedTabPage = tpSahmSahamdar;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtDarsadVizitor.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً درصد ویزیتور را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpDarsadVizitor;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(txtDarsadVizitor.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً درصد ویزیتور را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpDarsadVizitor;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            _AshkhasId = Convert.ToInt32(cmbTafsiliAshkhas.EditValue);
                            if (string.IsNullOrEmpty(txtDarsadRanande.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً درصد راننده را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpDarsadRanande;
                                return false;
                            }
                            //else
                            //{
                            //    if (db.EpEetebarat_As.Any())
                            //    {
                            //        var q1 = db.EpEetebarat_As.FirstOrDefault(s => s.ShGharadad == txtShGharadad.Text && s.AshkhasId==_AshkhasId);
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
                            if (string.IsNullOrEmpty(txtDarsadRanande.Text.Trim()))
                            {
                                XtraMessageBox.Show("لطفاً درصد راننده را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //xtraTabControl.SelectedTabPage = tpDarsadRanande;
                                return false;
                            }
                            //else
                            //{
                            //    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                            //    var q1 = db.EpShTamas_As.FirstOrDefault(s => s.Id != RowId && s.ShTamas == txtShTamas.Text);
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
            //else if (e.KeyCode == Keys.F7)
            //{
            //    btnCancel_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F8)
            //{
            //    btnDisplyList_Click(sender, null);
            //}
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
            HelpClass1.MoveLast(gridView);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView);
        }

        public void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGridView();
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

        public void ActiveControls()
        {
            panelControl1.Enabled = false;
            gridControl.Enabled = false;
            PanelControl_2.Enabled = true;
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
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                cmbNoeTamas.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                chkEetebarat.Checked = true;
                txtMablagh.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                cmbNameAdress_F.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                FillcmbNameBank();
                cmbNameBank.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                txtDarsadTakhfifRadifi.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                txtCodPersoneli.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                txtTedadSahm.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                txtMablaghSabet.Focus();
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                txtMablaghSabet_2.Focus();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                En = EnumCED.Create;
                HelpClass1.InActiveButtons(PanelControl_1);
                HelpClass1.ClearControls(PanelControl_2);
                ActiveControls();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا ردیف انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id").ToString());
                                if (_SelectedTabPage == "tpMoshakhasat")
                                {
                                    var q = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpMoshakhasat_As.Remove(q);
                                        db.SaveChanges();
                                        btnCreate.Enabled = true;
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpAdress")
                                {
                                    var q = db.EpAdress_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpAdress_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpTamas")
                                {
                                    var q = db.EpShTamas_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpShTamas_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpFazaMajazi")
                                {
                                    var q = db.EpFazaMajazi_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpFazaMajazi_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpHesabBanki")
                                {
                                    var q = db.EpHesabBanki_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpHesabBanki_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpEetebarat")
                                {
                                    var q = db.EpEetebarat_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpEetebarat_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpTakhfif")
                                {
                                    var q = db.EpDarsadTakhfif_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpDarsadTakhfif_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpPersonel")
                                {
                                    var q = db.EpMPersoneli_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpMPersoneli_As.Remove(q);
                                        db.SaveChanges();
                                        btnCreate.Enabled = true;
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpSahmSahamdar")
                                {
                                    var q = db.EpSahmSahamdar_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpSahmSahamdar_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpDarsadVizitor")
                                {
                                    var q = db.EpDarsadVizitor_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpDarsadVizitor_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else if (_SelectedTabPage == "tpDarsadRanande")
                                {
                                    var q = db.EpDarsadRanande_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                    if (q != null)
                                    {
                                        db.EpDarsadRanande_As.Remove(q);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                FillDataGridView();
                                HelpClass1.ClearControls(PanelControl_2);
                                if (gridView.RowCount > 0)
                                    gridView.FocusedRowHandle = EditRowIndex - 1;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (gridView.RowCount > 0)
                {
                    En = EnumCED.Edit;
                    HelpClass1.InActiveButtons(PanelControl_1);
                    ActiveControls();
                    // EditRowIndex = gridView.FocusedRowHandle;

                    #region MyRegion
                    //if (_SelectedTabPage == "tpMoshakhasat")
                    //{

                    //    txtNameEkhtesar.Text = gridView.GetFocusedRowCellValue("NameEkhtesar").ToString();
                    //    txtNoeFaaliat.Text = gridView.GetFocusedRowCellValue("NoeFaaliat").ToString();
                    //    txtShenaseMelli.Text = gridView.GetFocusedRowCellValue("ShenaseMelli").ToString();
                    //    txtCodeEghtesadi.Text = gridView.GetFocusedRowCellValue("CodeEghtesadi").ToString();
                    //    txtShomareSabt.Text = gridView.GetFocusedRowCellValue("ShomareSabt").ToString();
                    //    txtMolahezat_M.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //    using (var db = new MyContext())
                    //    {
                    //        try
                    //        {
                    //            int RowId = Convert.ToInt32(txtId.Text);
                    //            var q1 = db.EpMoshakhasat_As.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                    //            if (q1.Pictuer != null)
                    //            {
                    //                MemoryStream ms = new MemoryStream(q1.Pictuer);
                    //                pictureEdit1.Image = Image.FromStream(ms);
                    //                img = pictureEdit1.Image;
                    //            }
                    //            else
                    //                pictureEdit1.Image = null;
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }
                    //    }

                    //}
                    //else if (_SelectedTabPage == "tpAdress")
                    //{

                    //    cmbNameAdress.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameAdressId").ToString());
                    //    cmbNameOstan.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameOstanId").ToString());
                    //    cmbNameShahrstan.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameShahrstanId").ToString());
                    //    txtSharhAdress.Text = gridView.GetFocusedRowCellValue("SharhAdress").ToString();
                    //    txtCodePosti.Text = gridView.GetFocusedRowCellValue("CodePosti").ToString();
                    //    txtSandoghPosti.Text = gridView.GetFocusedRowCellValue("SandoghPosti").ToString();
                    //    chkDefaultAdress.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_A.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpTamas")
                    //{

                    //    cmbNoeTamas.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNoeTamas").ToString());
                    //    txtShTamas.Text = gridView.GetFocusedRowCellValue("ShTamas").ToString();
                    //    txtNameTaraf.Text = gridView.GetFocusedRowCellValue("NameTaraf").ToString();
                    //    txtNameGhesmat.Text = gridView.GetFocusedRowCellValue("NameGhesmat").ToString();
                    //    txtShDakheli.Text = gridView.GetFocusedRowCellValue("ShDakheli").ToString();
                    //    chkDefaultShTamas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_T.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpEetebarat")
                    //{

                    //    txtMablagh.Text = gridView.GetFocusedRowCellValue("Mablagh").ToString();
                    //    chkEetebarat.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("chkEetebarat"));
                    //    //chkGharardad.Checked = Convert.ToBoolean(gridViewEetebar1.GetFocusedRowCellValue("chkGharardad"));
                    //    txtShGharadad.Text = gridView.GetFocusedRowCellValue("ShGharadad").ToString();
                    //    txtTarikhGharadad.Text = gridView.GetFocusedRowCellValue("TarikhGharadad") != null ? gridView.GetFocusedRowCellValue("TarikhGharadad").ToString() : "";
                    //    chkDefaultEetebar.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_E.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpFazaMajazi")
                    //{

                    //    cmbNameAdress_F.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNameAdress"));
                    //    txtSharhAdress_F.Text = gridView.GetFocusedRowCellValue("SharhAdress").ToString();
                    //    chkDefaultFazaMajazi.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_F.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpHesabBanki")
                    //{
                    //    cmbNameBank.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameBankId"));
                    //    txtShomareHesab.Text = gridView.GetFocusedRowCellValue("ShomareHesab").ToString();
                    //    txtShomareKart.Text = gridView.GetFocusedRowCellValue("ShomareKart").ToString();
                    //    txtShomareShaba.Text = gridView.GetFocusedRowCellValue("ShomareShaba").ToString();
                    //    txtShomareMoshtari.Text = gridView.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                    //    txtMolahezat_H.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //    chkDefaultHesabBanki.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //}
                    //else if (_SelectedTabPage == "tpTakhfif")
                    //{

                    //    cmbNoeTakhfif.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNoeTakhfif"));
                    //    txtDarsadTakhfif.Text = gridView.GetFocusedRowCellValue("DarsadTakhfif").ToString();
                    //    chkTarikh.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsChecked"));
                    //    txtAzTarikh.Text = gridView.GetFocusedRowCellValue("AzTarikh") != null ? gridView.GetFocusedRowCellValue("AzTarikh").ToString() : "";
                    //    txtTaTarikh.Text = gridView.GetFocusedRowCellValue("TaTarikh") != null ? gridView.GetFocusedRowCellValue("TaTarikh").ToString() : "";
                    //    txtMolahezat_DT.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //    chkDefaultTakhfif.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //}
                    //else if (_SelectedTabPage == "tpPersonel")
                    //{

                    //    txtCodPersoneli.Text = gridView.GetFocusedRowCellValue("CodPersoneli").ToString();
                    //    txtTarikhEstekhdam.Text = gridView.GetFocusedRowCellValue("TarikhEstekhdam") != null ? gridView.GetFocusedRowCellValue("TarikhEstekhdam").ToString() : "";
                    //    txtTarikhTavalod.Text = gridView.GetFocusedRowCellValue("TarikhTavalod") != null ? gridView.GetFocusedRowCellValue("TarikhTavalod").ToString() : "";
                    //    txtNamePedar.Text = gridView.GetFocusedRowCellValue("NamePedar").ToString();
                    //    txtShShenasname.Text = gridView.GetFocusedRowCellValue("ShShenasname").ToString();
                    //    cmbJensiat.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexJensiat"));
                    //    cmbTaahol.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexTaahol"));
                    //    txtShogl.Text = gridView.GetFocusedRowCellValue("Shogl").ToString();
                    //    txtMolahezat_MP.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpSahmSahamdar")
                    //{

                    //    txtTedadSahm.Text = gridView.GetFocusedRowCellValue("TedadSahm").ToString();
                    //    txtMablaghHarSahm.Text = gridView.GetFocusedRowCellValue("MablaghHarSahm").ToString();
                    //    txtSumMablagh.Text = gridView.GetFocusedRowCellValue("SumMablagh").ToString();
                    //    txtMolahezat_SS.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpDarsadVizitor")
                    //{

                    //    txtMablaghSabet.Text = gridView.GetFocusedRowCellValue("MablaghSabet").ToString();
                    //    txtDarsadVizitor.Text = gridView.GetFocusedRowCellValue("DarsadVizitor").ToString();
                    //    chkDefaultDvizitor.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_DV.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}
                    //else if (_SelectedTabPage == "tpDarsadRanande")
                    //{

                    //    txtMablaghSabet_2.Text = gridView.GetFocusedRowCellValue("MablaghSabet").ToString();
                    //    txtDarsadRanande.Text = gridView.GetFocusedRowCellValue("DarsadRanande").ToString();
                    //    chkDefaultDarsadRanande.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    //    txtMolahezat_DR.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    //}

                    #endregion
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (TextEditValidation())
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpMoshakhasat_A obj = new EpMoshakhasat_A();
                                    obj.Id = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpMoshakhasat_As.Any() ? db.EpMoshakhasat_As.Max(s => s.Code) + 1 : 1;
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
                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewMoshkhasat1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMoshakhasat_As.FirstOrDefault(s => s.Id == RowId);
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

                                        db.SaveChanges();
                                        btnDisplyList_Click(null, null);

                                        if (gridViewMoshkhasat1.RowCount > 0)
                                            gridViewMoshkhasat1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpAdress)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpAdress_A obj = new EpAdress_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpAdress_As.Any() ? db.EpAdress_As.Max(s => s.Code) + 1 : 1;
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
                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewAdress1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpAdress_As.FirstOrDefault(s => s.Id == RowId);
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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewAdress1.RowCount > 0)
                                            gridViewAdress1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpTamas)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpShTamas_A obj = new EpShTamas_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpShTamas_As.Any() ? db.EpShTamas_As.Max(s => s.Code) + 1 : 1;
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewTamas1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpShTamas_As.FirstOrDefault(s => s.Id == RowId);
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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewTamas1.RowCount > 0)
                                            gridViewTamas1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                            {
                                if (string.IsNullOrEmpty(txtTaEngheza_E.Text.Trim()))
                                {
                                    XtraMessageBox.Show("لطفاً تاریخ انقضای قرارداد مشخص شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //btnCancel_Click(null, null);
                                    return;
                                }

                                if (En == EnumCED.Create)
                                {
                                    EpEetebarat_A obj = new EpEetebarat_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpEetebarat_As.Any() ? db.EpEetebarat_As.Max(s => s.Code) + 1 : 1;
                                    obj.Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                    obj.chkEetebarat = chkEetebarat.Checked;
                                    // obj.chkGharardad = chkGharardad.Checked;
                                    obj.ShGharadad = txtShGharadad.Text;
                                    //if (!string.IsNullOrEmpty(txtAzTarikh_E.Text))
                                    obj.TaEngheza = Convert.ToDateTime(txtTaEngheza_E.Text);
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewEetebar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpEetebarat_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.Mablagh = Convert.ToDecimal(txtMablagh.Text.Replace(",", ""));
                                        q.chkEetebarat = chkEetebarat.Checked;
                                        //  q.chkGharardad = chkGharardad.Checked;
                                        q.ShGharadad = txtShGharadad.Text;
                                        //if (!string.IsNullOrEmpty(txtAzTarikh_E.Text))
                                        q.TaEngheza = Convert.ToDateTime(txtTaEngheza_E.Text);
                                        q.IsDefault = chkDefaultEetebar.Checked;
                                        q.Molahezat = txtMolahezat_E.Text;

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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewEetebar1.RowCount > 0)
                                            gridViewEetebar1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpFazaMajazi_A obj = new EpFazaMajazi_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpFazaMajazi_As.Any() ? db.EpFazaMajazi_As.Max(s => s.Code) + 1 : 1;
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewFazaMajazi1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpFazaMajazi_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.IndexNameAdress = cmbNameAdress_F.SelectedIndex;
                                        q.NameAdress = cmbNameAdress_F.Text;
                                        q.SharhAdress = txtSharhAdress_F.Text;
                                        q.IsDefault = chkDefaultFazaMajazi.Checked;
                                        q.Molahezat = txtMolahezat_F.Text;

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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewFazaMajazi1.RowCount > 0)
                                            gridViewFazaMajazi1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpHesabBanki_A obj = new EpHesabBanki_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpHesabBanki_As.Any() ? db.EpHesabBanki_As.Max(s => s.Code) + 1 : 1;
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewHesabBanki1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpHesabBanki_As.FirstOrDefault(s => s.Id == RowId);
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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewHesabBanki1.RowCount > 0)
                                            gridViewHesabBanki1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                            {
                                if (string.IsNullOrEmpty(txtAzTarikh.Text.Trim()) || string.IsNullOrEmpty(txtTaTarikh.Text.Trim()))
                                {
                                    XtraMessageBox.Show("لطفاً محدوده تاریخ تخفیف مشخص شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //btnCancel_Click(null, null);
                                    return;
                                }

                                if (En == EnumCED.Create)
                                {
                                    EpDarsadTakhfif_A obj = new EpDarsadTakhfif_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpDarsadTakhfif_As.Any() ? db.EpDarsadTakhfif_As.Max(s => s.Code) + 1 : 1;
                                    obj.DarsadTakhfifRadifi = !string.IsNullOrEmpty(txtDarsadTakhfifRadifi.Text)? Convert.ToSingle(txtDarsadTakhfifRadifi.Text) :0;
                                    obj.DarsadTakhfifJamei = !string.IsNullOrEmpty(txtDarsadTakhfifJamei.Text) ? Convert.ToSingle(txtDarsadTakhfifJamei.Text):0;
                                    obj.IsChecked = chkTarikh.Checked;
                                    //if (!string.IsNullOrEmpty(txtAzTarikh.Text))
                                    obj.AzTarikh = Convert.ToDateTime(txtAzTarikh.Text);
                                    //if (!string.IsNullOrEmpty(txtTaTarikh.Text))
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
                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewTakhfif1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadTakhfif_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.DarsadTakhfifRadifi = !string.IsNullOrEmpty(txtDarsadTakhfifRadifi.Text) ? Convert.ToSingle(txtDarsadTakhfifRadifi.Text) : 0;
                                        q.DarsadTakhfifJamei = !string.IsNullOrEmpty(txtDarsadTakhfifJamei.Text) ? Convert.ToSingle(txtDarsadTakhfifJamei.Text) : 0;
                                        q.IsChecked = chkTarikh.Checked;
                                        //if (!string.IsNullOrEmpty(txtAzTarikh.Text))
                                        q.AzTarikh = Convert.ToDateTime(txtAzTarikh.Text);
                                        //if (!string.IsNullOrEmpty(txtTaTarikh.Text))
                                        q.TaTarikh = Convert.ToDateTime(txtTaTarikh.Text);
                                        q.Molahezat = txtMolahezat_DT.Text;
                                        q.IsDefault = chkDefaultTakhfif.Checked;


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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewTakhfif1.RowCount > 0)
                                            gridViewTakhfif1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpPersonel)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpMPersoneli_A obj = new EpMPersoneli_A();
                                    obj.Id = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpMPersoneli_As.Any() ? db.EpMPersoneli_As.Max(s => s.Code) + 1 : 1;
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
                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewMPersoneli1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpMPersoneli_As.FirstOrDefault(s => s.Id == RowId);
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

                                        db.SaveChanges();
                                        btnDisplyList_Click(null, null);

                                        if (gridViewMPersoneli1.RowCount > 0)
                                            gridViewMPersoneli1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpSahmSahamdar_A obj = new EpSahmSahamdar_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpSahmSahamdar_As.Any() ? db.EpSahmSahamdar_As.Max(s => s.Code) + 1 : 1;
                                    obj.TedadSahm = Convert.ToInt32(txtTedadSahm.Text);
                                    obj.MablaghHarSahm = Convert.ToDecimal(txtMablaghHarSahm.Text.Replace(",", ""));
                                    obj.SumMablagh = Convert.ToDecimal(txtSumMablagh.Text.Replace(",", ""));
                                    obj.Molahezat = txtMolahezat_SS.Text;

                                    db.EpSahmSahamdar_As.Add(obj);
                                    db.SaveChanges();
                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewSahmSahamdar1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpSahmSahamdar_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.TedadSahm = Convert.ToInt32(txtTedadSahm.Text);
                                        q.MablaghHarSahm = Convert.ToDecimal(txtMablaghHarSahm.Text.Replace(",", ""));
                                        q.SumMablagh = Convert.ToDecimal(txtSumMablagh.Text.Replace(",", ""));
                                        q.Molahezat = txtMolahezat_SS.Text;

                                        db.SaveChanges();
                                        btnDisplyList_Click(null, null);

                                        if (gridViewSahmSahamdar1.RowCount > 0)
                                            gridViewSahmSahamdar1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpDarsadVizitor_A obj = new EpDarsadVizitor_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpDarsadVizitor_As.Any() ? db.EpDarsadVizitor_As.Max(s => s.Code) + 1 : 1;
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadVizitor1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadVizitor_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.MablaghSabet = Convert.ToInt32(txtMablaghSabet.Text.Replace(",", ""));
                                        q.DarsadVizitor = Convert.ToSingle(txtDarsadVizitor.Text);
                                        q.IsDefault = chkDefaultDvizitor.Checked;
                                        q.Molahezat = txtMolahezat_DV.Text;

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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewDarsadVizitor1.RowCount > 0)
                                            gridViewDarsadVizitor1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                            {
                                if (En == EnumCED.Create)
                                {
                                    EpDarsadRanande_A obj = new EpDarsadRanande_A();
                                    obj.AshkhasId = Convert.ToInt32(txtId.Text);
                                    obj.SalId = _SalId;
                                    obj.Code = db.EpDarsadRanande_As.Any() ? db.EpDarsadRanande_As.Max(s => s.Code) + 1 : 1;
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

                                    btnDisplyList_Click(null, null);

                                    btnCancel_Click(null, null);
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (En == EnumCED.Edit)
                                {
                                    int RowId = Convert.ToInt32(gridViewDarsadRanande1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpDarsadRanande_As.FirstOrDefault(s => s.Id == RowId);
                                    if (q != null)
                                    {
                                        q.AshkhasId = Convert.ToInt32(txtId.Text);
                                        q.MablaghSabet = Convert.ToInt32(txtMablaghSabet_2.Text.Replace(",", ""));
                                        q.DarsadRanande = Convert.ToSingle(txtDarsadRanande.Text);
                                        q.IsDefault = chkDefaultDarsadRanande.Checked;
                                        q.Molahezat = txtMolahezat_DR.Text;

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

                                        btnDisplyList_Click(null, null);

                                        if (gridViewDarsadRanande1.RowCount > 0)
                                            gridViewDarsadRanande1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            En = EnumCED.Cancel;
            HelpClass1.ActiveButtons(PanelControl_1);
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat || xtraTabControl.SelectedTabPage == tpPersonel)
                btnCreate.Enabled = gridView.RowCount == 0 ? true : false;
            HelpClass1.ClearControls(PanelControl_2);
            PanelControl_2.Enabled = false;
            panelControl1.Enabled = true;
            gridControl.Enabled = true;
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            btnCreate.Focus();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void xtraTabControl_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnCancel_Click(null, null);
            }
        }

        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
            {
                gridControl = gridControlMoshkhasat1;
                gridView = gridViewMoshkhasat1;
                PanelControl_2 = panelControl_Moshakhasat;
                btnCreate.Enabled = gridView.RowCount == 0 ? true : false;
                txtIndex = txtIndex_Moshakhasat;
            }
            else if (xtraTabControl.SelectedTabPage == tpAdress)
            {
                gridControl = gridControlAdress1;
                gridView = gridViewAdress1;
                PanelControl_2 = panelControl_Adress;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_Adress;
            }
            else if (xtraTabControl.SelectedTabPage == tpTamas)
            {
                gridControl = gridControlTamas1;
                gridView = gridViewTamas1;
                PanelControl_2 = panelControl_Tamas;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_ShomareTamas;
            }
            else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
            {
                gridControl = gridControlFazaMajazi1;
                gridView = gridViewFazaMajazi1;
                PanelControl_2 = panelControl_FazaMajazi;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_FazaMajazi;
            }
            else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
            {
                gridControl = gridControlHesabBanki1;
                gridView = gridViewHesabBanki1;
                PanelControl_2 = panelControl_HesabBanki;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_HesabhaBanki;
            }
            else if (xtraTabControl.SelectedTabPage == tpEetebarat)
            {
                gridControl = gridControlEetebar1;
                gridView = gridViewEetebar1;
                PanelControl_2 = panelControl_Eetebarat;
                HelpClass1.DateTimeMask(txtTaEngheza_E);
                btnCreate.Enabled = true;
                txtIndex = txtIndex_EtebarFroosh;
            }
            else if (xtraTabControl.SelectedTabPage == tpTakhfif)
            {
                gridControl = gridControlTakhfif1;
                gridView = gridViewTakhfif1;
                PanelControl_2 = panelControl_Takhfif;
                HelpClass1.DateTimeMask(txtAzTarikh);
                HelpClass1.DateTimeMask(txtTaTarikh);
                btnCreate.Enabled = true;
                txtIndex = txtIndex_DarsadeTakhfif;
            }
            else if (xtraTabControl.SelectedTabPage == tpPersonel)
            {
                gridControl = gridControlMPersoneli1;
                gridView = gridViewMPersoneli1;
                PanelControl_2 = panelControl_MPersoneli;
                HelpClass1.DateTimeMask(txtTarikhEstekhdam);
                HelpClass1.DateTimeMask(txtTarikhTavalod);
                btnCreate.Enabled = gridView.RowCount == 0 ? true : false;
                txtIndex = txtIndex_MoshakhasatPersoneli;
            }
            else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
            {
                gridControl = gridControlSahmSahamdar1;
                gridView = gridViewSahmSahamdar1;
                PanelControl_2 = panelControl_SahmSahamdar;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_SahmSahamdar;
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
            {
                gridControl = gridControlDarsadVizitor1;
                gridView = gridViewDarsadVizitor1;
                PanelControl_2 = panelControl_DarsadVizitor;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_DarsadeVizitor;
            }
            else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
            {
                gridControl = gridControlDarsadRanande1;
                gridView = gridViewDarsadRanande1;
                PanelControl_2 = panelControl_DarsadRanande;
                btnCreate.Enabled = true;
                txtIndex = txtIndex_DarsadeRanande;
            }
            _SelectedTabPage = xtraTabControl.SelectedTabPage.Name;
            FillDataGridView();
            gridView.FocusedRowHandle = !string.IsNullOrEmpty(txtIndex.Text) ? Convert.ToInt32(txtIndex.Text) : 0;
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
            try
            {
                if (gridView.RowCount > 0)
                {
                    txtIndex.Text = gridView.FocusedRowHandle.ToString();

                    if (xtraTabControl.SelectedTabPage == tpMoshakhasat)
                    {
                        txtNameEkhtesar.Text = gridView.GetFocusedRowCellValue("NameEkhtesar").ToString();
                        txtNoeFaaliat.Text = gridView.GetFocusedRowCellValue("NoeFaaliat").ToString();
                        txtShenaseMelli.Text = gridView.GetFocusedRowCellValue("ShenaseMelli").ToString();
                        txtCodeEghtesadi.Text = gridView.GetFocusedRowCellValue("CodeEghtesadi").ToString();
                        txtShomareSabt.Text = gridView.GetFocusedRowCellValue("ShomareSabt").ToString();
                        txtMolahezat_M.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
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
                    else if (xtraTabControl.SelectedTabPage == tpAdress)
                    {
                        FillcmbNameAdress();
                        FillcmbNameOstan();
                        // FillcmbNameShahrstan();
                        cmbNameAdress.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameAdressId").ToString());
                        cmbNameOstan.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameOstanId").ToString());
                        cmbNameShahrstan.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameShahrstanId").ToString());
                        txtSharhAdress.Text = gridView.GetFocusedRowCellValue("SharhAdress").ToString();
                        txtCodePosti.Text = gridView.GetFocusedRowCellValue("CodePosti").ToString();
                        txtSandoghPosti.Text = gridView.GetFocusedRowCellValue("SandoghPosti").ToString();
                        chkDefaultAdress.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_A.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpTamas)
                    {
                        cmbNoeTamas.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNoeTamas").ToString());
                        txtShTamas.Text = gridView.GetFocusedRowCellValue("ShTamas").ToString();
                        txtNameTaraf.Text = gridView.GetFocusedRowCellValue("NameTaraf").ToString();
                        txtNameGhesmat.Text = gridView.GetFocusedRowCellValue("NameGhesmat").ToString();
                        txtShDakheli.Text = gridView.GetFocusedRowCellValue("ShDakheli").ToString();
                        chkDefaultShTamas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_T.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpEetebarat)
                    {
                        txtMablagh.Text = gridView.GetFocusedRowCellValue("Mablagh").ToString();
                        chkEetebarat.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("chkEetebarat"));
                        //chkGharardad.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("chkGharardad"));
                        txtShGharadad.Text = gridView.GetFocusedRowCellValue("ShGharadad").ToString();
                        txtTaEngheza_E.Text = gridView.GetFocusedRowCellValue("TaTarikh") != null ? gridView.GetFocusedRowCellValue("TaTarikh").ToString() : "";
                        chkDefaultEetebar.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_E.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpFazaMajazi)
                    {
                        cmbNameAdress_F.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNameAdress"));
                        txtSharhAdress_F.Text = gridView.GetFocusedRowCellValue("SharhAdress").ToString();
                        chkDefaultFazaMajazi.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_F.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpHesabBanki)
                    {
                        FillcmbNameBank();
                        cmbNameBank.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameBankId"));
                        txtShomareHesab.Text = gridView.GetFocusedRowCellValue("ShomareHesab").ToString();
                        txtShomareKart.Text = gridView.GetFocusedRowCellValue("ShomareKart").ToString();
                        txtShomareShaba.Text = gridView.GetFocusedRowCellValue("ShomareShaba").ToString();
                        txtShomareMoshtari.Text = gridView.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                        txtMolahezat_H.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                        chkDefaultHesabBanki.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    }
                    else if (xtraTabControl.SelectedTabPage == tpTakhfif)
                    {
                        txtDarsadTakhfifRadifi.Text = gridView.GetFocusedRowCellValue("DarsadTakhfifRadifi").ToString();
                        txtDarsadTakhfifJamei.Text = gridView.GetFocusedRowCellValue("DarsadTakhfifJamei").ToString();
                        chkTarikh.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsChecked"));
                        txtAzTarikh.Text = gridView.GetFocusedRowCellValue("AzTarikh") != null ? gridView.GetFocusedRowCellValue("AzTarikh").ToString() : "";
                        txtTaTarikh.Text = gridView.GetFocusedRowCellValue("TaTarikh") != null ? gridView.GetFocusedRowCellValue("TaTarikh").ToString() : "";
                        txtMolahezat_DT.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                        chkDefaultTakhfif.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                    }
                    else if (xtraTabControl.SelectedTabPage == tpPersonel)
                    {
                        txtCodPersoneli.Text = gridView.GetFocusedRowCellValue("CodPersoneli").ToString();
                        txtTarikhEstekhdam.Text = gridView.GetFocusedRowCellValue("TarikhEstekhdam") != null ? gridView.GetFocusedRowCellValue("TarikhEstekhdam").ToString() : "";
                        txtTarikhTavalod.Text = gridView.GetFocusedRowCellValue("TarikhTavalod") != null ? gridView.GetFocusedRowCellValue("TarikhTavalod").ToString() : "";
                        txtNamePedar.Text = gridView.GetFocusedRowCellValue("NamePedar").ToString();
                        txtShShenasname.Text = gridView.GetFocusedRowCellValue("ShShenasname").ToString();
                        cmbJensiat.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexJensiat"));
                        cmbTaahol.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexTaahol"));
                        txtShogl.Text = gridView.GetFocusedRowCellValue("Shogl").ToString();
                        txtMolahezat_MP.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpSahmSahamdar)
                    {
                        txtTedadSahm.Text = gridView.GetFocusedRowCellValue("TedadSahm").ToString();
                        txtMablaghHarSahm.Text = gridView.GetFocusedRowCellValue("MablaghHarSahm").ToString();
                        txtSumMablagh.Text = gridView.GetFocusedRowCellValue("SumMablagh").ToString();
                        txtMolahezat_SS.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpDarsadVizitor)
                    {
                        txtMablaghSabet.Text = gridView.GetFocusedRowCellValue("MablaghSabet").ToString();
                        txtDarsadVizitor.Text = gridView.GetFocusedRowCellValue("DarsadVizitor").ToString();
                        chkDefaultDvizitor.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_DV.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    else if (xtraTabControl.SelectedTabPage == tpDarsadRanande)
                    {
                        txtMablaghSabet_2.Text = gridView.GetFocusedRowCellValue("MablaghSabet").ToString();
                        txtDarsadRanande.Text = gridView.GetFocusedRowCellValue("DarsadRanande").ToString();
                        chkDefaultDarsadRanande.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                        txtMolahezat_DR.Text = gridView.GetFocusedRowCellValue("Molahezat").ToString();
                    }
                    if (En != EnumCED.Edit)
                        btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
                }

            }
            catch (Exception)
            {
            }
        }

        private void btnReloadGroupTafsili_Ashkhas_Click(object sender, EventArgs e)
        {
            FillcmbGroupTafsili();
            cmbGroupTafsili.EditValue = 0;
            cmbTafsiliAshkhas.EditValue = 0;
        }

        private void btnReloadHesabTafsili_Ashkhas_Click(object sender, EventArgs e)
        {
            FillcmbTafsiliAshkhas();
            cmbTafsiliAshkhas.EditValue = 0;
        }

        private void cmbGroupTafsili_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void cmbTafsiliAshkhas_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void txtMablaghHarSahm_EditValueChanged(object sender, EventArgs e)
        {
            txtSumMablagh.Text = (Convert.ToInt32(txtTedadSahm.Text.Trim()) * Convert.ToInt32(txtMablaghHarSahm.Text.Trim())).ToString();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void cmbLookupEdit_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            HelpClass1._IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }

        private void chkEetebarat_CheckedChanged(object sender, EventArgs e)
        {
            chkEetebarat.Text = chkEetebarat.Checked ? "مبلغ اعتبار با احتساب مانده بدهی + مبلغ فاکتور + جمع چکهای سررسید نشده می باشد" : "مبلغ اعتبار با احتساب مانده بدهی + مبلغ فاکتور می باشد";

        }
    }
}