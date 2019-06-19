/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmGroupTafziliCed.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 17   11:56 ق.ظ
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
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmGroupTafziliCed : DevExpress.XtraEditors.XtraForm
    {
        FrmGroupTafziliList Fm;
        public FrmGroupTafziliCed(FrmGroupTafziliList fm)
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
                    if (db.EpGroupTafzilis.Any())
                    {
                        var MaximumCod = db.EpGroupTafzilis.Max(p => p.Code);
                        if (MaximumCod != 99)
                            txtCode.Text = (MaximumCod + 1).ToString();
                        else
                            XtraMessageBox.Show("اعمال محدودیت تعریف حداکثر 90 حساب گروه تفضیلی ..." + "\n" + "توجه : نمیتوان بیشتر از 90 حساب گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 10 تا 99 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        txtCode.Text = "10";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

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
                            EpGroupTafzili obj = new EpGroupTafzili();
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;
                            db.EpGroupTafzilis.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q = db.EpGroupTafzilis.FirstOrDefault(s => s.Code == _code);
                            //////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            //EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            //n1.KeyId = _code;
                            //n1.ParentId = _code;
                            //n1.LevelName = txtName.Text;
                            //n1.HesabGroupId = q.Id;
                            //n1.IsActive = chkIsActive.Checked;
                            //db.EpAccessLevelCodingHesabdaris.Add(n1);
                            ///////////////////////////////////////////////////////////////////////////////////////
                            //db.SaveChanges();
                            if (chkIsActive.Checked)
                                Fm.btnDisplyActiveList_ItemClick(null, null);
                            else
                                Fm.btnDisplyNotActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateCloseClicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                btnNewCode_Click(null, null);
                                txtName.Text = string.Empty;
                                txtSharhHesab.Text = string.Empty;
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
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpGroupTafzilis.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.Name = txtName.Text;
                                q.IsActive = chkIsActive.Checked;
                                q.SharhHesab = txtSharhHesab.Text;

                                /////////////////////////////////متد اصلاح کد و نام مجموعه در لیست حسابهای کل ومعین WillCascadeOnUpdate ///////////////////////

                                ///////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                //var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId).ToList();
                                //if (q5.Count > 0)
                                //{
                                //    q5.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                //                + item.Code.ToString().Substring(1));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.GroupName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                //var q6 = db.EpHesabMoins.Where(s => s.GroupId == RowId).ToList();
                                //if (q6.Count > 0)
                                //{
                                //    q6.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                //                + item.Code.ToString().Substring(1));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.GroupName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                //var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                //if (q8.Count > 0)
                                //{
                                //    q8.ForEach(item =>
                                //    {
                                //        if (item.HesabColId == 0)
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
                                //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                //                    + item.KeyId.ToString().Substring(1));
                                //            if (CodeBeforeEdit != txtCode.Text)
                                //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 1).Replace(item.ParentId.ToString().Substring(0, 1), txtCode.Text)
                                //                    + item.ParentId.ToString().Substring(1));
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //    });
                                //}
                                ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                //var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                //if (q9.Count > 0)
                                //{
                                //    q9.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                //                    + item.KeyId.ToString().Substring(1));
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ///////////////////////////////////////////////////////////////////////////////////////////////

                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                else
                                    Fm.btnDisplyNotActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                if (Fm.gridView1.RowCount > 0)
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
                            var q = db.EpGroupTafzilis.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.EpGroupTafzilis.Remove(q);
                                //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                else
                                    Fm.btnDisplyNotActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                if (Fm.gridView1.RowCount > 0)
                                    Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد \n حذف این گروه تفضیلی مقدور نیست \n" +
                                " جهت حذف حساب گروه تفضیلی در ابتدا بایستی کلیه ارتباط های این حساب با حسابهای معین حذف گردد" +
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
                            if (db.EpGroupTafzilis.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.EpGroupTafzilis.Where(p => p.Code == _code);
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
                            var q1 = db.EpGroupTafzilis.Where(p => p.Id != RowId && p.Code == _code);
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
                XtraMessageBox.Show("لطفاً نام گروه تفضیلی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.EpGroupTafzilis.Any())
                            {
                                var q2 = db.EpGroupTafzilis.Where(p => p.Name == txtName.Text);
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
                            var q2 = db.EpGroupTafzilis.Where(p => p.Id != RowId && p.Name == txtName.Text);
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

            return true;
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmGroupTafziliCed_Load(object sender, EventArgs e)
        {
            if (Fm.lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl3.Visible = true;
            }

            if (Fm.En == EnumCED.Create)
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = Fm.gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                if (txtCode.Text == "99")
                    btnNewCode.Enabled = false;
            }
        }

        private void FrmGroupTafziliCed_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F11)
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
                if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 99)
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از 9 و کمتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


    }
}