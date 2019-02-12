/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabGroupCed.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 7   10:45 ب.ظ
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
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabGroupCed : DevExpress.XtraEditors.XtraForm
    {
        FrmHesabGroupList Fm;
        public FrmHesabGroupCed(FrmHesabGroupList fm)
        {
            InitializeComponent();
            Fm = fm;
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
                            XtraMessageBox.Show("اعمال محدودیت تعریف 9 حساب گروه ..." + "\n" + "توجه : نمیتوان بیشتر از 9 حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 1 تا 9 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateCloseClicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                btnNewCode_Click(null, null);
                                cmbStandardGroups.EditValue = string.Empty;
                                txtName.Text = string.Empty;
                                cmbNoeHesab.EditValue = string.Empty;
                                txtSharhHesab.Text = string.Empty;
                                cmbStandardGroups.Focus();
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

                                ///////////////////////////////متد اصلاح کد و نام مجموعه در لیست واحد ها ، شعبه ها و دوره های مالی WillCascadeOnUpdate ///////////////////////

                                /////////////////////////////// WillCascadeOnUpdate : MsVaheds ///////////////////////
                                //var q5 = db.MsVaheds.Where(s => s.MsMajmoeId == RowId).ToList();
                                //if (q5.Count > 0)
                                //{
                                //    q5.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.VahedCode = Convert.ToInt32(item.VahedCode.ToString().Substring(0, 2).Replace(item.VahedCode.ToString().Substring(0, 2), txtCode.Text)
                                //            + item.VahedCode.ToString().Substring(2));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.MajmoeName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.VahedIsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////// WillCascadeOnUpdate : MsShobes /////////////////////////
                                //var q6 = db.MsShobes.Where(s => s.MsMajmoeId == RowId).ToList();
                                //if (q6.Count > 0)
                                //{
                                //    q6.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.ShobeCode = Convert.ToInt32(item.ShobeCode.ToString().Substring(0, 2).Replace(item.ShobeCode.ToString().Substring(0, 2), txtCode.Text)
                                //            + item.ShobeCode.ToString().Substring(2));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.MajmoeName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.ShobeIsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                //var q7 = db.MsDoreMalis.Where(s => s.MsMajmoeId == RowId).ToList();
                                //if (q7.Count > 0)
                                //{
                                //    q7.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.DoreMaliCode = Convert.ToInt32(item.DoreMaliCode.ToString().Substring(0, 2).Replace(item.DoreMaliCode.ToString().Substring(0, 2), txtCode.Text)
                                //            + item.DoreMaliCode.ToString().Substring(2));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.MajmoeName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.DoreMaliIsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////////متد اصلاح کد و نام مجموعه در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                //var q8 = db.MsAccessLevelDafaterMalis.Where(s => s.MajmoeId == RowId).ToList();
                                //if (q8.Count > 0)
                                //{
                                //    q8.ForEach(item =>
                                //    {
                                //        if (item.VahedId == 0)
                                //        {
                                //            if (CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(txtCode.Text);
                                //            if (CodeBeforeEdit != txtCode.Text)
                                //                item.ParentId = Convert.ToInt32(txtCode.Text);
                                //            if (NameBeforeEdit != txtName.Text)
                                //                item.LevelName = txtName.Text;
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //        else
                                //        {
                                //            if (CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtCode.Text)
                                //                + item.KeyId.ToString().Substring(2));
                                //            if (CodeBeforeEdit != txtCode.Text)
                                //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), txtCode.Text)
                                //                + item.ParentId.ToString().Substring(2));
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //    });
                                //}
                                /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                //var q9 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MajmoeId == RowId).ToList();
                                //if (q9.Count > 0)
                                //{
                                //    q9.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtCode.Text)
                                //            + item.KeyId.ToString().Substring(2));
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                /////////////////////////////////////////////////////////////////////////////////////////////

                                db.SaveChanges();

                                Fm.btnDisplyActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            var q = db.EpHesabGroups.FirstOrDefault(p => p.Id == RowId);
                            var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.EpHesabGroups.Remove(q);
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
                                " جهت حذف رکورد جاری در ابتدا بایستی زیر مجموعه های رکورد جاری  (در لیست واحد ها ، لیست شعبه ها و لیست دوره ها) حذف گردد" +
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
            ///////////////// اعتبار سنجی کد////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.EpHesabGroups.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.EpHesabGroups.Where(p => p.Code == _code);
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
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q1 = db.EpHesabGroups.Where(p => p.Id != RowId && p.Code == _code);
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
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabGroups.Any())
                            {
                                var q2 = db.EpHesabGroups.Where(p => p.Name == txtName.Text);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q2 = db.EpHesabGroups.Where(p => p.Id != RowId && p.Name == txtName.Text);
                            if (q2.Any())
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
                if (cmbStandardGroups.Text==string.Empty)
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

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmHesabGroupCed_Load(object sender, EventArgs e)
        {
            if (Fm.lblUserId.Text == "1")
                chkIsActive.Visible = true;

            if (Fm.En == EnumCED.Create)
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbStandardGroups.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexGroupStandard"));
                cmbNoeHesab.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = Fm.gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                if (txtCode.Text == "9")
                    btnNewCode.Enabled = false;
            }
        }

        private void FrmHesabGroupCed_KeyDown(object sender, KeyEventArgs e)
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
                if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 9)
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 10 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Fm.En == EnumCED.Create)
                    {
                        btnNewCode_Click(null, null);
                    }
                    else
                    {
                        txtCode.Text = CodeBeforeEdit;
                    }
                }
            }
        }

        private void cmbStandardGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = cmbStandardGroups.SelectedItem.ToString();
        }

        private void cmbNoeHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoeHesab.Text = (cmbNoeHesab.SelectedIndex == 0 || cmbNoeHesab.SelectedIndex == 2) ? "دائم" : "موقت";

        }

        private void cmbNoeHesab_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbNoeHesab.ShowPopup();
            }
        }

        private void cmbStandardGroups_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbStandardGroups.ShowPopup();
            }
        }
    }
}