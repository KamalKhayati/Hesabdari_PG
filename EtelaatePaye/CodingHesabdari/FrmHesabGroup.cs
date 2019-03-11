/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabGroup.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 4   12:56 ب.ظ
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
using DBHesabdari_TG;
using System.Data.Entity;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabGroup : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabGroup()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridHesabGroup()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabGroups.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabGroupsBindingSource.DataSource = q1;
                            else
                                epHesabGroupsBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item3 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabGroups.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            epHesabGroupsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabGroupsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabGroupsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabGroups.Where(p => p.IsActive == false).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                epHesabGroupsBindingSource.DataSource = q.ToList();
                            else
                                epHesabGroupsBindingSource.DataSource = null;
                        }
                        else
                            epHesabGroupsBindingSource.DataSource = null;
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
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        var MaximumCod = db.EpHesabGroups.Max(p => p.Code);
                        if (MaximumCod != 9)
                            txtCode.Text = (MaximumCod + 1).ToString();
                        else
                            XtraMessageBox.Show("اعمال محدودیت تعریف 9 حساب گروه ..." + "\n" + "توجه : نمیتوان بیشتر از 9 حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 10 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        int IndexCmbStandardGroupBeforeEdit = 0;
        private void FrmHesabGroup_Load(object sender, EventArgs e)
        {
            FillDataGridHesabGroup();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl3.Visible = true;
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
            if (string.IsNullOrEmpty(txtCode.Text))
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
                            if (db.EpHesabGroups.Any())
                            {
                                int _Code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.EpHesabGroups.FirstOrDefault(p => p.Code == _Code);
                                if (q1 != null)
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
                            int _Code = Convert.ToInt32(txtCode.Text);
                            var q1 = db.EpHesabGroups.FirstOrDefault(p => p.Id != RowId && p.Code == _Code);
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

            //////////////// اعتبار سنجی تکس باکس///////////////////////////////

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
                            if (db.EpHesabGroups.Any())
                            {
                                var q1 = db.EpHesabGroups.FirstOrDefault(p => p.Name == txtName.Text);
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
                            var q1 = db.EpHesabGroups.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
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
                if (cmbStandardGroups.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً از لیست انتخابی گروه مربوطه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cmbNoeHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً نوع حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void FrmHesabGroup_KeyDown(object sender, KeyEventArgs e)
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
            FillDataGridHesabGroup();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabGroup();
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
            cmbStandardGroups.SelectedIndex = -1;
            txtCode.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbNoeHesab.SelectedIndex = -1;
            txtSharhHesab.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbStandardGroups.ReadOnly = false;
                btnNewCode.Enabled = true;
                chkEditCode.ReadOnly = false;
                txtName.ReadOnly = false;
                cmbNoeHesab.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbStandardGroups.ReadOnly = true;
                btnNewCode.Enabled = false;
                chkEditCode.ReadOnly = true;
                txtName.ReadOnly = true;
                cmbNoeHesab.ReadOnly = true;
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
            cmbStandardGroups.Focus();
            btnNewCode_Click(null, null);
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
                            var q = db.EpHesabGroups.FirstOrDefault(p => p.Id == RowId);
                            var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.EpHesabGroups.Remove(q);
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
                IndexCmbStandardGroupBeforeEdit = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexGroupStandard"));
                NameBeforeEdit = gridView1.GetFocusedRowCellValue("Name").ToString();


                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbStandardGroups.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexGroupStandard"));
                cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                if (txtCode.Text == "9")
                    btnNewCode.Enabled = false;
                cmbStandardGroups.Focus();
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
                            EpHesabGroup obj = new EpHesabGroup();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.IsActive = chkIsActive.Checked;
                            obj.IndexGroupStandard = cmbStandardGroups.SelectedIndex;
                            obj.NameGroupStandard = cmbStandardGroups.Text;
                            obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                            obj.NoeHesab = cmbNoeHesab.Text;
                            obj.SharhHesab = txtSharhHesab.Text;
                            db.EpHesabGroups.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q = db.EpHesabGroups.FirstOrDefault(s => s.Code == _code);
                            ////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            n1.KeyId = _code;
                            n1.ParentId = _code;
                            n1.LevelName = txtName.Text;
                            n1.HesabGroupId = q.Id;
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
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabGroups.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.Name = txtName.Text;
                                q.IsActive = chkIsActive.Checked;
                                q.IndexGroupStandard = cmbStandardGroups.SelectedIndex;
                                q.NameGroupStandard = cmbStandardGroups.Text;
                                q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                q.NoeHesab = cmbNoeHesab.Text;
                                q.SharhHesab = txtSharhHesab.Text;

                                ///////////////////////////////متد اصلاح کد و نام مجموعه در لیست حسابهای کل ومعین WillCascadeOnUpdate ///////////////////////

                                /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId).ToList();
                                if (q5.Count > 0)
                                {
                                    q5.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                                + item.Code.ToString().Substring(1));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.GroupName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                var q6 = db.EpHesabMoins.Where(s => s.GroupId == RowId).ToList();
                                if (q6.Count > 0)
                                {
                                    q6.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                                + item.Code.ToString().Substring(1));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.GroupName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                if (q8.Count > 0)
                                {
                                    q8.ForEach(item =>
                                    {
                                        if (item.HesabColId == 0)
                                        {
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(txtCode.Text);
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(txtCode.Text);
                                            if (NameBeforeEdit != txtName.Text)
                                                item.LevelName = txtName.Text;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                        else
                                        {
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                                    + item.KeyId.ToString().Substring(1));
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 1).Replace(item.ParentId.ToString().Substring(0, 1), txtCode.Text)
                                                    + item.ParentId.ToString().Substring(1));
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                    });
                                }
                                /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                if (q9.Count > 0)
                                {
                                    q9.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                                    + item.KeyId.ToString().Substring(1));
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////////////////////////////////////////////////////////////////////////

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

        private void cmbStandardGroups_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbStandardGroups.ShowPopup();
            }
        }

        private void cmbNoeHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeHesab.ShowPopup();
            }

        }

        private void cmbStandardGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStandardGroups.SelectedIndex != -1)
            {
                if (cmbStandardGroups.SelectedIndex == IndexCmbStandardGroupBeforeEdit)
                {
                    txtName.Text = NameBeforeEdit;
                }
                else
                {
                    txtName.Text = cmbStandardGroups.SelectedItem.ToString();
                }
            }
        }

        private void cmbNoeHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoeHesab.Text = (cmbNoeHesab.SelectedIndex == 0 || cmbNoeHesab.SelectedIndex == 2) ? "دائم" : "موقت";

        }

    }
}