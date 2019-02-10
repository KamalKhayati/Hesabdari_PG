/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabColCed.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 9   06:10 ب.ظ
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
using DBHesabdari_TG;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabColCed : DevExpress.XtraEditors.XtraForm
    {
        FrmHesabColList Fm;
        public FrmHesabColCed(FrmHesabColList fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        public void FillcmbHesabGroupList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        if (Fm.isActive == true)
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
                        var q = db.EpHesabCols.Where(s => s.GroupId == _GroupId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                        }
                        else
                        {
                            txtCode.Text = "01";
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
        bool IsActiveBeforeEdit;
        private void FrmHesabColCed_Load(object sender, EventArgs e)
        {
            FillcmbHesabGroupList();
            if (Fm.lblUserId.Text == "1")
                chkIsActive.Visible = true;
            if (this.Text != "ایجاد رکورد جدید")
            {
                cmbListHesabGroup.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("GroupId").ToString());
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsActive"));
                switch (Fm.gridView1.GetFocusedRowCellValue("MahiatHesab").ToString())
                {
                    case "بدهکار": { rdbBed.Checked = true; break; }
                    case "بستانکار": { rdbBes.Checked = true; break; }
                    case "بد / بس": { rdbBedVBes.Checked = true; break; }
                }
                txtSharhHesab.Text = Fm.gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup.EditValue);
                IsActiveBeforeEdit = chkIsActive.Checked;
            }
        }

        private void btnCreateNext_Click(object sender, EventArgs e)
        {
            btnCreateCloseClicked = false;
            btnCreateClose_Click(null, null);
            btnCreateCloseClicked = true;
        }

        bool btnCreateCloseClicked = true;
        private void btnCreateClose_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                btnCreateClose.Enabled = false;
                btnCreateNext.Enabled = false;
                if (Fm.En == EnumCED.Create)
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
                            obj.MahiatHesab = rdbBed.Checked ? "بدهکار" : rdbBes.Checked ? "بستانکار" : "بد / بس";
                            obj.SharhHesab = txtSharhHesab.Text;

                            db.EpHesabCols.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            var q = db.EpHesabCols.FirstOrDefault(s => s.Code == _code);
                            ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            n1.KeyId = _code;
                            n1.ParentId = Convert.ToInt32(_code.ToString().Substring(0, 2));
                            n1.LevelName = txtName.Text;
                            n1.HesabGroupId = q.GroupId;
                            n1.HesabColId = q.Id;
                            n1.IsActive = chkIsActive.Checked;
                            db.EpAccessLevelCodingHesabdaris.Add(n1);
                            /////////////////////////////////////////////////////////////////////////////////////
                            db.SaveChanges();
                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateCloseClicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                cmbListHesabGroup.EditValue = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                btnNewCode_Click(null, null);
                                txtSharhHesab.Text = "";
                                rdbBed.Checked = rdbBes.Checked = rdbBedVBes.Checked = false;
                                txtName.Text = "";
                                txtName.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (Fm.En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                            string _GroupName = cmbListHesabGroup.Text;
                            string _Name = txtName.Text;
                            int _Id = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabCols.FirstOrDefault(p => p.Id == _Id);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                q.Name = _Name;
                                q.GroupId = _GroupId;
                                q.GroupName = _GroupName;
                                q.IsActive = chkIsActive.Checked;
                                q.MahiatHesab = rdbBed.Checked ? "بدهکار" : rdbBes.Checked ? "بستانکار" : "بد / بس";
                                q.SharhHesab = txtSharhHesab.Text;

                                ///////////////////////////////متد اصلاح کد و نام در لیست شعبه ها و دوره های مالی WillCascadeOnUpdate ///////////////////////

                                ///////////////////////////// WillCascadeOnUpdate : MsShobes /////////////////////////
                                //var q6 = db.MsShobes.Where(s => s.Id == _Id).ToList();
                                //if (q6.Count > 0)
                                //{
                                //    q6.ForEach(item =>
                                //    {
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.GroupId = _GroupId;
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.GroupName = _GroupName;
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //            item.ShobeCode = Convert.ToInt32(item.ShobeCode.ToString().Substring(0, 2).Replace(item.ShobeCode.ToString().Substring(0, 2), txtGroupCode.Text)
                                //            + item.ShobeCode.ToString().Substring(2, 2).Replace(item.ShobeCode.ToString().Substring(2, 2), txtCode.Text)
                                //            + item.ShobeCode.ToString().Substring(4));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.Name = _Name;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.ShobeIsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                //var q7 = db.MsDoreMalis.Where(s => s.Id == _Id).ToList();
                                //if (q7.Count > 0)
                                //{
                                //    q7.ForEach(item =>
                                //    {
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.GroupId = _GroupId;
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.GroupName = _GroupName;
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //            item.DoreMaliCode = Convert.ToInt32(item.DoreMaliCode.ToString().Substring(0, 2).Replace(item.DoreMaliCode.ToString().Substring(0, 2), txtGroupCode.Text)
                                //            + item.DoreMaliCode.ToString().Substring(2, 2).Replace(item.DoreMaliCode.ToString().Substring(2, 2), txtCode.Text)
                                //            + item.DoreMaliCode.ToString().Substring(4));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.Name = _Name;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.DoreMaliIsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                //var q8 = db.MsAccessLevelDafaterMalis.Where(s => s.VahedId == _Id).ToList();
                                //if (q8.Count > 0)
                                //{
                                //    q8.ForEach(item =>
                                //    {
                                //        if (item.ShobeId == 0)
                                //        {
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //            if (NameBeforeEdit != txtName.Text)
                                //                item.LevelName = txtName.Text;
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.MajmoeId = _GroupId;
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //        else
                                //        {
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtGroupCode.Text)
                                //                + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtCode.Text) + item.KeyId.ToString().Substring(4));
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), txtGroupCode.Text)
                                //                + item.ParentId.ToString().Substring(2, 2).Replace(item.ParentId.ToString().Substring(2, 2), txtCode.Text) + item.ParentId.ToString().Substring(4));
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.MajmoeId = _GroupId;
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //    });
                                //}
                                /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                //var q9 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.VahedId == _Id).ToList();
                                //if (q9.Count > 0)
                                //{
                                //    q9.ForEach(item =>
                                //    {
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtGroupCode.Text)
                                //            + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtCode.Text) + item.KeyId.ToString().Substring(4));
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.MajmoeId = _GroupId;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                //////////////////////////////////////////////////////////////////////////////////////
                                //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                //{
                                //    int MajmoeId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                //    var m = db.MsMajmoes.FirstOrDefault(p => p.GroupId == MajmoeId);
                                //    var a1 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                //    var a2 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == _Id && p.ShobeId == 0);
                                //    var b1 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                //    var b2 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == _Id && p.ShobeId == 0);
                                //    if (m != null)
                                //        m.MajmoeIsActive = true;
                                //    if (a1 != null)
                                //        a1.IsActive = true;
                                //    if (a2 != null)
                                //        a2.IsActive = true;
                                //    if (b1 != null)
                                //        b1.IsActive = true;
                                //    if (b2 != null)
                                //        b2.IsActive = true;
                                //}

                                db.SaveChanges();

                                Fm.btnDisplyActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex;
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
                else if (Fm.En == EnumCED.Delete)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabCols.FirstOrDefault(p => p.Id == RowId);
                            var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.EpHesabCols.Remove(q);
                                db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                Fm.btnDisplyActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد \n حذف رکورد جاری مقدور نیست \n" +
                                " جهت حذف رکورد جاری در ابتدا بایستی زیر مجموعه های رکورد جاری  (در لیست شعبه هاو لیست دوره ها) حذف گردد" +
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
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabCols.Any())
                            {
                                int _code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                var q1 = db.EpHesabCols.Where(p => p.Code == _code);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            int _code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            var q1 = db.EpHesabCols.Where(p => p.Id != RowId && p.Code == _code);
                            if (q1.Any())
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

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0" || string.IsNullOrEmpty(cmbListHesabGroup.EditValue.ToString()))
            {
                XtraMessageBox.Show("لطفاً اطلاعات را کامل وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabCols.Any())
                            {
                                var q1 = db.EpHesabCols.Where(p => p.Name == txtName.Text);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabCols.Where(p => p.Id != RowId && p.Name == txtName.Text);
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

            if (Fm.En == EnumCED.Create)
            {
                if (rdbBed.Checked == false && rdbBes.Checked == false && rdbBedVBes.Checked == false)
                {
                    XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        int _GroupId = 0;
        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                    var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId).Code;
                    if (q > 0)
                        txtGroupCode.Text = q.ToString();

                    btnNewCode_Click(null, null);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbListHesabGroup.ShowPopup();
            }
            else
            {
                cmbListHesabGroup.ClosePopup();
            }
        }

        private void FrmHesabColCed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreateClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnCreateNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnNewCode_Click(sender, null);
            }

        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = chkEditCode.Checked ? false : true;

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                if (Convert.ToInt32(txtCode.Text) == 0)
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Fm.En == EnumCED.Create)
                    {
                        btnNewCode_Click(null, null);
                    }
                    else
                    {
                        txtCode.Text = CodeBeforeEdit;
                    }
                    txtCode.Focus();
                }
            }
        }
    }
}