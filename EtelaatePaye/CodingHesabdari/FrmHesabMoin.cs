/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabMoin.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 3   11:13 ق.ظ
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
using DBHesabdari_PG;
using System.Data.Entity;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DBHesabdari_PG.Models.Ms.ActiveSystem;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabMoin : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabMoin()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;
        MyContext db1 = new MyContext();
        public void FillDataGridHesabMoin()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabMoins.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabMoinsBindingSource.DataSource = q1;
                            else
                                epHesabMoinsBindingSource.DataSource = null;
                        }
                        gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
                        //  gridView1.Appearance.Row.ForeColor = Color.Black;
                        HelpClass1.ClearControls(xtraTabPage1);
                        chkListBoxLevel1.UnCheckAll();
                        chkListBoxActiveSystem.UnCheckAll();
                        epSharhStandardMoinsBindingSource.Clear();

                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBEpAllCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabMoins.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            epHesabMoinsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabMoinsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabMoinsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabMoins.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epHesabMoinsBindingSource.DataSource = q;
                            else
                                epHesabMoinsBindingSource.DataSource = null;
                        }
                        else
                            epHesabMoinsBindingSource.DataSource = null;

                        gridView1.Appearance.HeaderPanel.ForeColor = Color.Red;
                        // gridView1.Appearance.Row.ForeColor = Color.Red;
                        HelpClass1.ClearControls(xtraTabPage1);
                        chkListBoxLevel1.UnCheckAll();
                        chkListBoxActiveSystem.UnCheckAll();
                        epSharhStandardMoinsBindingSource.Clear();

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbHesabTabagheh()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTabaghehs.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (IsActiveList == true)
                        {
                            db.EpHesabTabaghehs.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabTabaghehsBindingSource.DataSource = db.EpHesabTabaghehs.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabTabaghehs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabTabaghehsBindingSource.DataSource = db.EpHesabTabaghehs.Local.ToBindingList();
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

        public void FillcmbHesabGroup()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        int _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);

                        if (IsActiveList == true)
                        {
                            db.EpHesabGroups.Where(s => s.IsActive == true && s.TabaghehId == _HesabTabaghehId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabGroups.Where(s => s.TabaghehId == _HesabTabaghehId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
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

        public void FillcmbHesabCol()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabCols.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                        if (IsActiveList == true)
                        {
                            db.EpHesabCols.Where(s => s.IsActive == true && s.SalId == _SalId && s.GroupId == _GroupId).OrderBy(s => s.Code).Load();
                            epHesabColsBindingSource.DataSource = db.EpHesabCols.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabCols.Where(s => s.SalId == _SalId && s.GroupId == _GroupId).OrderBy(s => s.Code).Load();
                            epHesabColsBindingSource.DataSource = db.EpHesabCols.Local.ToBindingList();
                        }
                       // cmbListHesabCol.EditValue = 0;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridSharhStandard()
        {
            //using (var db = new MyContext())
            //{
            try
            {
                db1 = new MyContext();
                if (db1.EpSharhStandardMoins.Any())
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    int RowId = Convert.ToInt32(txtId.Text);
                    db1.EpSharhStandardMoins.Where(s => s.MoinId == RowId && s.SalId == _SalId).OrderBy(s => s.Id).Load();
                    epSharhStandardMoinsBindingSource.DataSource = db1.EpSharhStandardMoins.Local.ToBindingList();
                }
                //else
                //    epSharhStandardMoinsBindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}

        }
        public void FillListBoxActiveSystem()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsActiveSystems.Any())
                    {
                        db.MsActiveSystems.Where(s => s.IsActive == true).OrderBy(s => s.Code).Load();
                        msActiveSystemsBindingSource.DataSource = db.MsActiveSystems.Local.ToBindingList();
                    }
                    else
                        msActiveSystemsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillListBoxGroupTafsiliLevel1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafsiliLevel1s.Any())
                    {
                        //int _SalId = Convert.ToInt32(lblSalId.Text);
                        db.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true).OrderBy(s => s.Code).Load();
                        epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                    }
                    else
                        epGroupTafsiliLevel1sBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        int _ColId = 0;
        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (cmbListHesabCol.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _ColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpHesabMoins.Where(s => s.ColId == _ColId && s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter) != _HesabMoinMaxCode)
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                                //btnNewCode.Enabled = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف" + _HesabMoinMaxCode + "حساب معین ..." + "\n" + "توجه : نمیتوان بیشتر از" + _HesabMoinMaxCode + "حساب معین تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode.Text = _HesabMoinMinCode;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        int HesabTabaghehIdBeforeEdit = 0;
        int HesabGroupIdBeforeEdit = 0;
        int HesabColIdBeforeEdit = 0;
        int CodeBeforeEdit = 0;
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;

        int _HesabTabaghehCarakter = 0;
        int _HesabGroupCarakter = 0;
        int _HesabColCarakter = 0;
        int _HesabMoinCarakter = 0;
        string _HesabMoinMinCode = "";
        string _HesabMoinMaxCode = "";

        private void FrmHesabMoin_Load(object sender, EventArgs e)
        {
            FillDataGridHesabMoin();
            HelpClass1.InActiveControls(xtraTabPage1);
            HelpClass1.InActiveControls(xtraTabPage2);
            HelpClass1.InActiveControls(xtraTabPage3);
            HelpClass1.InActiveControls(xtraTabPage4);
            FillcmbHesabTabagheh();
            FillListBoxGroupTafsiliLevel1();
            FillListBoxActiveSystem();
            btnCreate.Focus();

            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpTanzimatCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId);
                    if (q != null)
                    {
                        _HesabTabaghehCarakter = q.HesabTabaghehCarakter;
                        _HesabGroupCarakter = q.HesabGroupCarakter;
                        _HesabColCarakter = q.HesabColCarakter;
                        _HesabMoinCarakter = q.HesabMoinCarakter;

                        _HesabMoinMinCode = q.HesabMoinMinCode;
                        _HesabMoinMaxCode = q.HesabMoinMaxCode;

                        txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        txtCode.Properties.Mask.EditMask = _HesabMoinCarakter == 1 ? "0" : _HesabMoinCarakter == 2 ? "00" : "000";
                        txtCode.Properties.MaxLength = _HesabMoinCarakter;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //FillListBoxLevel1();
            //FillListBoxActiveSystem();
            //chkListBoxActiveSystem.CheckAll();
            //if (lblUserId.Text == "1")
            //{
            //    chkIsActive.Visible = true;
            //    labelControl5.Visible = true;
            //}
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

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtColCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_HesabMoinMaxCode))
            {
                XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabMoinMinCode + " تا " + _HesabMoinMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        int _Code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabMoins.Any())
                            {
                                var q1 = db.EpHesabMoins.Where(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabMoins.Where(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            ////////////////// اعتبار سنجی تکس باکس و کمبوباکس ها////////////

            if (string.IsNullOrEmpty(cmbHesabTabagheh.Text))
            {
                XtraMessageBox.Show("لطفاً حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(cmbListHesabGroup.Text))
            {
                XtraMessageBox.Show("لطفاً حساب گروه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbListHesabCol.Text))
            {
                XtraMessageBox.Show("لطفاً حساب کل را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Trim() == "0")
            {
                XtraMessageBox.Show("لطفاً نام حساب معین را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabMoins.Any())
                            {
                                var q1 = db.EpHesabMoins.Where(s => s.Name == txtName.Text.Trim() && s.SalId == _SalId);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabMoins.Where(s => s.Id != RowId && s.Name == txtName.Text.Trim() && s.SalId == _SalId);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                if (cmbMahiatHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void FrmHesabMoin_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F6)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnDisplyNotActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }
        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            btnNewCode.Enabled = txtCode.Enabled = chkEditCode.Checked ? true : false;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView1);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView1);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView1);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Visible)
                HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridHesabMoin();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabMoin();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void cmbHesabTabagheh_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabGroup();
            cmbListHesabGroup.EditValue = 0;
            txtColCode.Text = txtCode.Text = string.Empty;
        }
        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabCol();
            cmbListHesabCol.EditValue = 0;
            txtColCode.Text = txtCode.Text = string.Empty;
        }

        private void cmbListHesabCol_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _ColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabCols.FirstOrDefault(s => s.Id == _ColId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtColCode.Text = q.Code.ToString();
                        cmbMahiatHesab.SelectedIndex = q.IndexMahiatHesab;
                        if (En == EnumCED.Edit)
                            if (_ColId != HesabColIdBeforeEdit)
                            {
                                btnNewCode_Click(null, null);
                            }
                            else
                                txtCode.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);

                        else
                            btnNewCode_Click(null, null);
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbListHesabTabagheh_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTabagheh.ShowPopup();
            }
        }
        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListHesabGroup.ShowPopup();
            }
        }

        private void cmbListHesabCol_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListHesabCol.ShowPopup();
            }
        }

        private void cmbMahiatHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbMahiatHesab.ShowPopup();
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Visible)
            {
                En = EnumCED.Create;
                gridControl1.Enabled = false;
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ActiveControls(xtraTabPage1);
                HelpClass1.ActiveControls(xtraTabPage2);
                HelpClass1.ActiveControls(xtraTabPage3);
                HelpClass1.ActiveControls(xtraTabPage4);
                HelpClass1.ClearControls(xtraTabPage1);
                HelpClass1.ClearControls(xtraTabPage2);
                HelpClass1.ClearControls(xtraTabPage3);
                HelpClass1.ClearControls(xtraTabPage4);
                //HelpClass1.ClearControls(xtraTabPage1);
                //epHesabGroupsBindingSource.DataSource = null;
                //epHesabColsBindingSource.DataSource = null;
                //epSharhStandardMoinsBindingSource.Clear();
                //epGroupTafsiliLevel1sBindingSource.DataSource = null;
                //msActiveSystemsBindingSource.DataSource = null;

                //FillListBoxGroupTafsiliLevel1();

                xtraTabControl3.SelectedTabPageIndex = 1;
                chkListBoxLevel1.UnCheckAll();

                //FillListBoxActiveSystem();

                xtraTabControl3.SelectedTabPageIndex = 2;
                chkListBoxActiveSystem.CheckAll();

                epSharhStandardMoinsBindingSource.Clear();

                //db1 = new MyContext();

                //FillcmbHesabTabagheh();
                xtraTabControl3.SelectedTabPageIndex = 0;
                cmbHesabTabagheh.Focus();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب معین انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                //var q = db.EpHesabMoins.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q8 != null)
                                {
                                    // db.EpHesabMoins.Remove(q);
                                    db.EpAllCodingHesabdaris.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                    HelpClass1.ClearControls(xtraTabPage1);
                                    chkListBoxLevel1.UnCheckAll();
                                    chkListBoxActiveSystem.UnCheckAll();
                                    //epSharhStandardMoinsBindingSource.Clear();
                                    //db1.Dispose();
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این حساب معین مقدور نیست \n" +
                                    " جهت حذف حساب معین در ابتدا بایستی ارتباط این حساب با سایر سطوح تفضیلی قطع گردد" +
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
            if (btnEdit.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    gridControl1.Enabled = false;
                    EditRowIndex = gridView1.FocusedRowHandle;
                    En = EnumCED.Edit;
                    HelpClass1.InActiveButtons(panelControl2);
                    HelpClass1.ActiveControls(xtraTabPage1);
                    HelpClass1.ActiveControls(xtraTabPage2);
                    HelpClass1.ActiveControls(xtraTabPage3);
                    HelpClass1.ActiveControls(xtraTabPage4);
                    // HelpClass1.ClearControls(xtraTabPage1);

                   // FillcmbHesabTabagheh();
                    //FillcmbHesabColList();

                    cmbHesabTabagheh.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghehId").ToString());
                    cmbListHesabGroup.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupId").ToString());
                    cmbListHesabCol.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ColId").ToString());
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtColCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbMahiatHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                    HesabGroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup.EditValue);
                    HesabColIdBeforeEdit = Convert.ToInt32(cmbListHesabCol.EditValue);
                    CodeBeforeEdit = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                    NameBeforeEdit = txtName.Text.Trim();
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    cmbHesabTabagheh.Focus();


                    FillDataGridSharhStandard();

                    using (var db = new MyContext())
                    {
                        try
                        {
                            FillListBoxActiveSystem();
                            xtraTabControl3.SelectedTabPageIndex = 2;
                            chkListBoxActiveSystem.CheckAll();
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.RMsActiveSystemBEpHesabMoins.Where(f => f.MoinId == RowId).Select(f => f.ActiveSystemId).ToList();
                            if (q.Count > 0)
                            {
                                if (chkListBoxActiveSystem.DataSource != null)
                                {
                                    foreach (var item in q)
                                    {
                                        for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                        {
                                            if (Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i)) == item)

                                                chkListBoxActiveSystem.SetItemCheckState(i, CheckState.Unchecked);
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////////////////////
                            FillListBoxGroupTafsiliLevel1();
                            xtraTabControl3.SelectedTabPageIndex = 1;
                            var q1 = db.REpHesabMoinBEpGroupTafsiliLevel1s.Where(f => f.MoinId == RowId && f.NumberLevel == 1).Select(f => f.GroupTafsiliId).ToList();
                            if (q1.Count > 0)
                            {
                                if (chkListBoxLevel1.DataSource != null)
                                {
                                    foreach (var item in q1)
                                    {
                                        for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                        {
                                            if (Convert.ToInt32(chkListBoxLevel1.GetItemValue(i)) == item)

                                                chkListBoxLevel1.SetItemCheckState(i, CheckState.Checked);
                                        }
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
                    xtraTabControl3.SelectedTabPageIndex = 0;
                    cmbListHesabGroup.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (TextEditValidation())
                {
                    if (En == EnumCED.Create)
                    {
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int _Code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                string _Name = txtName.Text.Trim();
                                bool _IsActive = chkIsActive.Checked;
                                int _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);
                                int _HesabGroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                int _HesabColId = Convert.ToInt32(cmbListHesabCol.EditValue);

                                EpHesabMoin obj = new EpHesabMoin();
                                obj.SalId = _SalId;
                                obj.Code = _Code;
                                obj.Name = _Name;
                                obj.IsActive = _IsActive;
                                obj.TabaghehId = _HesabTabaghehId;
                                obj.TabaghehName = cmbHesabTabagheh.Text;
                                obj.GroupId = _HesabGroupId;
                                obj.GroupName = cmbListHesabGroup.Text;
                                obj.ColId = _HesabColId;
                                obj.ColName = cmbListHesabCol.Text;
                                obj.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                obj.MahiatHesab = cmbMahiatHesab.Text;
                                obj.SharhHesab = txtSharhHesab.Text;

                                List<EpSharhStandardMoin> obj01 = new List<EpSharhStandardMoin>();

                                for (int i = 0; i < gridView2.RowCount; i++)
                                {
                                    EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                    obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                    obj1.Name = gridView2.GetRowCellDisplayText(i, "Name");
                                    //obj1.MoinCode = _Code;
                                    obj01.Add(obj1);
                                }
                                obj.EpSharhStandardMoins = obj01;

                                List<RMsActiveSystemBEpHesabMoin> obj02 = new List<RMsActiveSystemBEpHesabMoin>();
                                for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                {
                                    if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                    {
                                        int _ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));

                                        RMsActiveSystemBEpHesabMoin obj1 = new RMsActiveSystemBEpHesabMoin();
                                        obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                        obj1.ActiveSystemId = _ActiveSystemId;
                                        obj1.ActiveSystemCode = db.MsActiveSystems.FirstOrDefault(f => f.Id == _ActiveSystemId).Code;
                                        //obj1.MoinCode = _Code;
                                        obj02.Add(obj1);
                                    }
                                }
                                obj.RMsActiveSystemBEpHesabMoins = obj02;

                                List<REpHesabMoinBEpGroupTafsiliLevel1> obj03 = new List<REpHesabMoinBEpGroupTafsiliLevel1>();
                                for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                {
                                    if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));

                                        REpHesabMoinBEpGroupTafsiliLevel1 obj1 = new REpHesabMoinBEpGroupTafsiliLevel1();
                                        obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                        obj1.GroupTafsiliId = _GroupTafsiliId;
                                        obj1.GroupTafsiliCode = db.EpGroupTafsiliLevel1s.FirstOrDefault(f => f.Id == _GroupTafsiliId).Code;
                                        obj1.NumberLevel = 1;
                                        //obj1.MoinCode = _Code;
                                        obj03.Add(obj1);
                                    }
                                }
                                obj.REpHesabMoinBEpGroupTafsiliLevel1s = obj03;

                                string ActiveSystem = string.Empty;
                                for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                {
                                    if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                    }
                                }
                                obj.SelectedActivesystem = ActiveSystem;

                                string GroupTafsili = string.Empty;
                                for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                {
                                    if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        GroupTafsili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                    }
                                }
                                obj.SelectedGroupTafsiliLevel1 = GroupTafsili;

                                ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                n1.SalId = _SalId;
                                n1.KeyCode = _Code;
                                n1.ParentCode = Convert.ToInt32(txtColCode.Text);
                                n1.LevelName = _Name;
                                n1.HesabTabaghehId = _HesabTabaghehId;
                                n1.HesabGroupId = _HesabGroupId;
                                n1.HesabColId = _HesabColId;
                                n1.IsActive = _IsActive;
                                n1.EpHesabMoin1 = obj;

                                db.EpAllCodingHesabdaris.Add(n1);

                                db.SaveChanges();
                                ////////////////////////////////////////////////////////////////////////////////////////
                                //var q = db.EpHesabMoins.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                //int RowId = q.Id;
                                //for (int i = 0; i < gridView2.RowCount; i++)
                                //{
                                //    EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                //    obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                //    //obj1.Code = db.EpSharhStandardMoins.Any() ? db.EpSharhStandardMoins.Max(f => f.Code) + 1 : 1;
                                //    obj1.Name = gridView2.GetRowCellDisplayText(i, "Name");
                                //    obj1.MoinId = RowId;
                                //    obj1.MoinCode = _Code;
                                //    db.EpSharhStandardMoins.Add(obj1);
                                //    db.SaveChanges();
                                //}
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //////////////////////////////////////////////////////////////////////////////////////
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                //{
                                //    if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                //    {
                                //        int _ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));

                                //        RMsActiveSystemBEpHesabMoin obj1 = new RMsActiveSystemBEpHesabMoin();
                                //        obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                //        obj1.ActiveSystemId = _ActiveSystemId;
                                //        obj1.ActiveSystemCode = db.MsActiveSystems.FirstOrDefault(f => f.Id == _ActiveSystemId).Code;
                                //        obj1.MoinId = RowId;
                                //        obj1.MoinCode = _Code;
                                //        db.RMsActiveSystemBEpHesabMoins.Add(obj1);
                                //        db.SaveChanges();
                                //    }
                                //}
                                ///////////////////////////////////////////////////////////////////////////////////////
                                ///////////////////////////////////////////////////////////////////////////////////////
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                //{
                                //    if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                //    {
                                //        int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));

                                //        REpHesabMoinBEpGroupTafsiliLevel1 obj1 = new REpHesabMoinBEpGroupTafsiliLevel1();
                                //        obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                //        obj1.GroupTafsiliId = _GroupTafsiliId;
                                //        obj1.GroupTafsiliCode = db.EpGroupTafsiliLevel1s.FirstOrDefault(f => f.Id == _GroupTafsiliId).Code;
                                //        obj1.NumberLevel = 1;
                                //        obj1.MoinId = RowId;
                                //        obj1.MoinCode = _Code;
                                //        db.REpHesabMoinBEpGroupTafsiliLevel1s.Add(obj1);
                                //    }
                                //}
                                ///////////////////////////////////////////////////////////////////////////////////////
                                /////////////////////////////////////////////////////////////////////////////////////
                                /////////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                btnLast_Click(null, null);
                                btnCancel_Click(null, null);
                                En = EnumCED.Save;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);
                                string _HesabTabaghehName = cmbHesabTabagheh.Text;
                                int _HesabGroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                string _HesabGroupName = cmbListHesabGroup.Text;
                                int _HesabColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                                string _HesabColName = cmbListHesabCol.Text;

                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                int _Code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                string _Name = txtName.Text.Trim();
                                bool _IsActive = chkIsActive.Checked;
                                int RowId = Convert.ToInt32(txtId.Text);

                                var q = db.EpHesabMoins.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q != null)
                                {
                                    q.Code = _Code;
                                    q.Name = _Name;
                                    q.TabaghehId = _HesabTabaghehId;
                                    q.TabaghehName = cmbHesabTabagheh.Text;
                                    q.GroupId = _HesabGroupId;
                                    q.GroupName = _HesabGroupName;
                                    q.ColId = _HesabColId;
                                    q.ColName = _HesabColName;
                                    q.IsActive = _IsActive;
                                    q.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                    q.MahiatHesab = cmbMahiatHesab.Text;
                                    q.SharhHesab = txtSharhHesab.Text;

                                    string ActiveSystem = string.Empty;
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    q.SelectedActivesystem = ActiveSystem;

                                    string GroupTafsili = string.Empty;
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            GroupTafsili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    q.SelectedGroupTafsiliLevel1 = GroupTafsili;
                                    ////////////////////////////////////////////////////////////////////////////////
                                    var q1 = db.EpSharhStandardMoins.Where(s => s.MoinId == RowId && s.SalId == _SalId).ToList();
                                    if (q1.Count > 0)
                                    {
                                        db.EpSharhStandardMoins.RemoveRange(q1);
                                    }

                                    List<EpSharhStandardMoin> obj01 = new List<EpSharhStandardMoin>();
                                    for (int i = 0; i < gridView2.RowCount; i++)
                                    {
                                        EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                        obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                        //obj1.Code = db.EpSharhStandardMoins.Any() ? db.EpSharhStandardMoins.Max(f => f.Code) + 1 : 1;
                                        obj1.Name = gridView2.GetRowCellDisplayText(i, "Name");
                                        //obj1.MoinId = RowId;
                                        //obj1.MoinCode = _Code;
                                        //db.EpSharhStandardMoins.Add(obj1);
                                        obj01.Add(obj1);
                                    }
                                    q.EpSharhStandardMoins = obj01;

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    var q2 = db.RMsActiveSystemBEpHesabMoins.Where(s => s.MoinId == RowId && s.SalId == _SalId).ToList();
                                    if (q2.Count > 0)
                                    {
                                        db.RMsActiveSystemBEpHesabMoins.RemoveRange(q2);
                                    }

                                    List<RMsActiveSystemBEpHesabMoin> obj02 = new List<RMsActiveSystemBEpHesabMoin>();
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                        {
                                            int _ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));

                                            RMsActiveSystemBEpHesabMoin obj1 = new RMsActiveSystemBEpHesabMoin();
                                            obj1.SalId = _SalId;
                                            obj1.ActiveSystemId = _ActiveSystemId;
                                            obj1.ActiveSystemCode = db.MsActiveSystems.FirstOrDefault(f => f.Id == _ActiveSystemId).Code;
                                            //obj1.MoinId = RowId;
                                            //obj1.MoinCode = _Code;
                                            //db.RMsActiveSystemBEpHesabMoins.Add(obj1);
                                            obj02.Add(obj1);
                                        }
                                    }
                                    q.RMsActiveSystemBEpHesabMoins = obj02;
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    var q3 = db.REpHesabMoinBEpGroupTafsiliLevel1s.Where(s => s.MoinId == RowId && s.NumberLevel == 1 && s.SalId == _SalId).ToList();
                                    if (q3.Count > 0)
                                    {
                                        db.REpHesabMoinBEpGroupTafsiliLevel1s.RemoveRange(q3);
                                    }

                                    List<REpHesabMoinBEpGroupTafsiliLevel1> obj03 = new List<REpHesabMoinBEpGroupTafsiliLevel1>();
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));

                                            REpHesabMoinBEpGroupTafsiliLevel1 obj1 = new REpHesabMoinBEpGroupTafsiliLevel1();
                                            obj1.SalId = _SalId;
                                            obj1.GroupTafsiliId = _GroupTafsiliId;
                                            obj1.GroupTafsiliCode = db.EpGroupTafsiliLevel1s.FirstOrDefault(f => f.Id == _GroupTafsiliId).Code;
                                            obj1.NumberLevel = 1;
                                            //obj1.MoinId = RowId;
                                            //obj1.MoinCode = _Code;
                                            //db.REpHesabMoinBEpGroupTafsiliLevel1s.Add(obj1);
                                            obj03.Add(obj1);
                                        }
                                    }
                                    q.REpHesabMoinBEpGroupTafsiliLevel1s = obj03;
                                    /////////////////////////////// متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q10 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q10.KeyCode = _Code;
                                        q10.ParentCode = Convert.ToInt32(txtColCode.Text);
                                        q10.LevelName = _Name;
                                        q10.HesabTabaghehId = _HesabTabaghehId;
                                        q10.HesabGroupId = _HesabGroupId;
                                        q10.HesabColId = _HesabColId;
                                        q10.IsActive = _IsActive;
                                        q10.EpHesabMoin1 = q;

                                        //var q3 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId && s.SalId == _SalId).ToList();
                                        //if (q3.Count > 0)
                                        //{
                                        //    foreach (var item in q3)
                                        //    {
                                        //        if (HesabTabaghehIdBeforeEdit != _HesabTabaghehId)
                                        //            item.HesabTabaghehId = _HesabTabaghehId;

                                        //        if (HesabGroupIdBeforeEdit != _HesabGroupId)
                                        //            item.HesabGroupId = _HesabGroupId;

                                        //        if (CodeBeforeEdit != _Code)
                                        //        {
                                        //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter+_HesabMoinCarakter).Replace(item.KeyId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter+_HesabMoinCarakter), _Code.ToString())
                                        //            + item.KeyId.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));

                                        //            item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter).Replace(item.ParentId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter),_Code.ToString())
                                        //                + item.ParentId.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter));
                                        //        }

                                        //        if (IsActiveBeforeEdit != _IsActive)
                                        //            item.IsActive = _IsActive;
                                        //    }


                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabMoinId == RowId && s.SalId == _SalId).ToList();

                                        if (q9.Count > 0)
                                        {

                                            foreach (var item in q9)
                                            {
                                                if (HesabTabaghehIdBeforeEdit != _HesabTabaghehId)
                                                {
                                                    item.HesabTabaghehId = _HesabTabaghehId;
                                                }
                                                if (HesabGroupIdBeforeEdit != _HesabGroupId)
                                                {
                                                    item.HesabGroupId = _HesabGroupId;
                                                }
                                                if (HesabColIdBeforeEdit != _HesabColId)
                                                {
                                                    item.HesabColId = _HesabColId;
                                                }

                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoinCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoinCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoinCarakter));

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        {
                                            var T = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                                            var G = db.EpHesabGroups.FirstOrDefault(s => s.Id == _HesabGroupId && s.SalId == _SalId);
                                            var C = db.EpHesabCols.FirstOrDefault(s => s.Id == _HesabColId && s.SalId == _SalId);
                                            var A = db.EpAllCodingHesabdaris.Where(s => s.Id == _HesabTabaghehId || s.Id == _HesabGroupId || s.Id == _HesabColId && s.SalId == _SalId);
                                            var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _HesabTabaghehId || s.CodingHesabdariId == _HesabGroupId || s.CodingHesabdariId == _HesabColId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (G != null)
                                                G.IsActive = true;
                                            if (C != null)
                                                C.IsActive = true;
                                            foreach (var item in A)
                                                item.IsActive = true;
                                            foreach (var item in U)
                                                item.IsActive = true;
                                        }

                                        db.SaveChanges();
                                    }

                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex;
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

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            if (btnSaveNext.Enabled)
            {
                //gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
                btnSave_Click(null, null);
                if (En == EnumCED.Save)
                    btnCreate_Click(null, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled)
            {
                gridControl1.Enabled = true;
                HelpClass1.ActiveButtons(panelControl2);
                HelpClass1.InActiveControls(xtraTabPage1);
                HelpClass1.InActiveControls(xtraTabPage2);
                HelpClass1.InActiveControls(xtraTabPage3);
                HelpClass1.InActiveControls(xtraTabPage4);
                HelpClass1.ClearControls(xtraTabPage1);
                //epHesabGroupsBindingSource.DataSource = null;
                //epHesabColsBindingSource.DataSource = null;
                //epGroupTafsiliLevel1sBindingSource.DataSource = null;
                //msActiveSystemsBindingSource.DataSource = null;
                chkListBoxLevel1.UnCheckAll();
                chkListBoxActiveSystem.UnCheckAll();
                epSharhStandardMoinsBindingSource.Clear();
                //db1.Dispose();
                // epSharhStandardMoinsBindingSource.cle;
                btnCreate.Focus();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }


        private void FrmHesabMoin_FormClosing(object sender, FormClosingEventArgs e)
        {
            db1.Dispose();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);

        }

        int _Index = 0;

        private void xtraTabControl3_MouseClick(object sender, MouseEventArgs e)
        {
            _Index = xtraTabControl3.SelectedTabPageIndex;

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //  HelpClass1.ClearControls(xtraTabPage1);
               // FillcmbHesabTabagheh();
                cmbHesabTabagheh.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghehId").ToString());
                cmbListHesabGroup.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupId").ToString());
                cmbListHesabCol.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ColId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtColCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbMahiatHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                FillDataGridSharhStandard();

                using (var db = new MyContext())
                {
                    try
                    {
                        FillListBoxActiveSystem();
                        xtraTabControl3.SelectedTabPageIndex = 2;
                        chkListBoxActiveSystem.CheckAll();
                        int RowId = Convert.ToInt32(txtId.Text);
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.RMsActiveSystemBEpHesabMoins.Where(f => f.MoinId == RowId && f.SalId == _SalId).Select(f => f.ActiveSystemId).ToList();
                        if (q.Count > 0)
                        {
                            if (chkListBoxActiveSystem.DataSource != null)
                            {
                                foreach (var item in q)
                                {
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i)) == item)

                                            chkListBoxActiveSystem.SetItemCheckState(i, CheckState.Unchecked);
                                    }
                                }
                            }
                        }
                        ////////////////////////////////////////////////////////////////
                        FillListBoxGroupTafsiliLevel1();
                        xtraTabControl3.SelectedTabPageIndex = 1;
                        var q1 = db.REpHesabMoinBEpGroupTafsiliLevel1s.Where(f => f.MoinId == RowId && f.NumberLevel == 1 && f.SalId == _SalId).Select(f => f.GroupTafsiliId).ToList();
                        if (q1.Count > 0)
                        {
                            if (chkListBoxLevel1.DataSource != null)
                            {
                                foreach (var item in q1)
                                {
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (Convert.ToInt32(chkListBoxLevel1.GetItemValue(i)) == item)

                                            chkListBoxLevel1.SetItemCheckState(i, CheckState.Checked);
                                    }

                                }
                            }
                        }
                        xtraTabControl3.SelectedTabPageIndex = _Index;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                btnDelete.Enabled = btnEdit.Enabled = true;
            }
            else
                btnDelete.Enabled = btnEdit.Enabled = false;
        }
        private void ReloadHesabTabagheh_Click(object sender, EventArgs e)
        {
            FillcmbHesabTabagheh();
        }

        private void ReloadHesabGroup_Click(object sender, EventArgs e)
        {
            FillcmbHesabGroup();
        }
        private void ReloadHesabCol_Click(object sender, EventArgs e)
        {
            FillcmbHesabCol();
        }
    }
}