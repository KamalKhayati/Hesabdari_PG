﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabCol.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 4   12:48 ق.ظ
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
    public partial class FrmHesabCol : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabCol()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridHesabCol()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabCols.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabColsBindingSource.DataSource = q1;
                            else
                                epHesabColsBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId == 0 && s.IsActive == true).Select(s => s.HesabColId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabCols.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            epHesabColsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabColsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabColsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabCols.Where(p => p.IsActive == false).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                epHesabColsBindingSource.DataSource = q.ToList();
                            else
                                epHesabColsBindingSource.DataSource = null;
                        }
                        else
                            epHesabColsBindingSource.DataSource = null;
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
                        if (IsActiveList == true)
                        {
                            db.EpHesabGroups.Where(s => s.IsActive == true).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabGroups.Load();
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

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (cmbListHesabGroup.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                       int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                        var q = db.EpHesabCols.Where(s => s.GroupId == _GroupId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(1) != "9")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(1);
                                btnNewCode.Enabled = true;
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 9 حساب کل برای هر حساب گروه ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 9 حساب کل برای هر حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 10 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnNewCode.Enabled = false;
                            }

                        }
                        else
                        {
                            txtCode.Text = "1";
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        int GroupIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit=true;
        private void FrmHesabCol_Load(object sender, EventArgs e)
        {
            FillDataGridHesabCol();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl6.Visible = true;
            }
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
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 9)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 10 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabCols.Any())
                            {
                                int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                var q1 = db.EpHesabCols.FirstOrDefault(p => p.Code == _Code);
                                if (q1!=null)
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
                            int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            var q1 = db.EpHesabCols.FirstOrDefault(p => p.Id != RowId && p.Code == _Code);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit;
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

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0")
            {
                XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabCols.Any())
                            {
                                var q1 = db.EpHesabCols.FirstOrDefault(p => p.Name == txtName.Text);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabCols.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
                            if (q1 != null)
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

            if (En == EnumCED.Create)
            {
                if (cmbMahiatHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void FrmHesabCol_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyNotActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSharhHesab_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnAdvancedSearch_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            {
                btnPrint_Click(sender, null);
            }
            else if (e.Alt && e.KeyCode == Keys.N && btnNewCode.Enabled == true)
            {
                btnNewCode_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = chkEditCode.Checked ? false : true;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            gridView1.MoveNext();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.MovePrev();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            gridView1.MoveFirst();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridHesabCol();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabCol();
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

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        private void btnSharhHesab_Click(object sender, EventArgs e)
        {
            gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
        }

        public void InActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = false;
                }
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        public void ActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = true;
                }
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        public void ClearControls()
        {
            cmbListHesabGroup.EditValue = 0;
            txtGroupCode.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbMahiatHesab.SelectedIndex = -1;
            txtSharhHesab.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbListHesabGroup.ReadOnly = false;
                btnNewCode.Enabled = true;
                chkEditCode.ReadOnly = false;
                txtName.ReadOnly = false;
                cmbMahiatHesab.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbListHesabGroup.ReadOnly = true;
                btnNewCode.Enabled = false;
                chkEditCode.ReadOnly = true;
                txtName.ReadOnly = true;
                cmbMahiatHesab.ReadOnly = true;
                chkIsActive.ReadOnly = true;
                txtSharhHesab.ReadOnly = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            FillcmbHesabGroup();
            cmbListHesabGroup.Focus();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا حساب تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.EpHesabCols.FirstOrDefault(p => p.Id == RowId);
                            var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.EpHesabCols.Remove(q);
                                db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();


                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب کل مقدور نیست \n" +
                                " جهت حذف حساب کل در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
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

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                FillcmbHesabGroup();

                cmbListHesabGroup.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(1);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbMahiatHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup.EditValue);
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                if (txtCode.Text == "9")
                    btnNewCode.Enabled = false;
                txtName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                if (En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            EpHesabCol obj = new EpHesabCol();
                            obj.Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.IsActive = chkIsActive.Checked;
                            obj.GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                            obj.GroupName = cmbListHesabGroup.Text;
                            obj.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                            obj.MahiatHesab = cmbMahiatHesab.Text;
                            obj.SharhHesab = txtSharhHesab.Text;

                            db.EpHesabCols.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            var q = db.EpHesabCols.FirstOrDefault(s => s.Code == _code);
                            ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            n1.KeyId = _code;
                            n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                            n1.LevelName = txtName.Text;
                            n1.HesabGroupId = q.GroupId;
                            n1.HesabColId = q.Id;
                            n1.IsActive = chkIsActive.Checked;
                            db.EpAccessLevelCodingHesabdaris.Add(n1);
                            /////////////////////////////////////////////////////////////////////////////////////
                            db.SaveChanges();
                            if (chkIsActive.Checked)
                                btnDisplyActiveList_Click(null, null);
                            else
                                btnDisplyNotActiveList_Click(null, null);

                            XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            gridView1.MoveLast();
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
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
                            int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                            int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            string _GroupName = cmbListHesabGroup.Text;
                            string _Name = txtName.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabCols.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = _Code;
                                q.Name = _Name;
                                q.GroupId = _GroupId;
                                q.GroupName = _GroupName;
                                q.IsActive = chkIsActive.Checked;
                                q.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                q.MahiatHesab = cmbMahiatHesab.Text;
                                q.SharhHesab = txtSharhHesab.Text;

                                ///////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                if (q6.Count > 0)
                                {
                                    q6.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                                + item.Code.ToString().Substring(2));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.ColName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                if (q8.Count > 0)
                                {
                                    q8.ForEach(item =>
                                    {
                                        if (item.HesabMoinId == 0)
                                        {
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                            if (NameBeforeEdit != txtName.Text)
                                                item.LevelName = txtName.Text;
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                item.HesabGroupId = _GroupId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                        else
                                        {
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                                + item.KeyId.ToString().Substring(2));
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                                + item.ParentId.ToString().Substring(2));
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                item.HesabGroupId = _GroupId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                    });
                                }
                                /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                if (q9.Count > 0)
                                {
                                    q9.ForEach(item =>
                                    {
                                        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                            + item.KeyId.ToString().Substring(2));
                                        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                            item.HesabGroupId = _GroupId;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                //////////////////////////////////////////////////////////////////////////////////////
                                if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                {
                                    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                    var a1 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //var a2 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    var b1 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //var b2 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    if (m != null)
                                        m.IsActive = true;
                                    if (a1 != null)
                                        a1.IsActive = true;
                                    //if (a2 != null)
                                    //    a2.IsActive = true;
                                    if (b1 != null)
                                        b1.IsActive = true;
                                    //if (b2 != null)
                                    //    b2.IsActive = true;
                                }

                                db.SaveChanges();
                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            ActiveButtons();
            ClearControls();
            InActiveControls();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListHesabGroup.ShowPopup();
            }
            else
            {
                cmbListHesabGroup.ClosePopup();
            }

        }

        private void cmbMahiatHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbMahiatHesab.ShowPopup();
            }

        }

        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                    var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId);
                    if (q!=null)
                        txtGroupCode.Text = q.Code.ToString();

                    btnNewCode_Click(null, null);

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