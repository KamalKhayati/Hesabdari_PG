/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmUsersCed.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   03:48 ب.ظ
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
using HelpClassLibrary;
using DBHesabdari_TG;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.UsersSystem
{
    public partial class FrmUsersCed : DevExpress.XtraEditors.XtraForm
    {
        FrmUsersList Fm;
        public FrmUsersCed(FrmUsersList fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        string UserNameBeforEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmUsersCed_Load(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("MsUserId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("UserCode").ToString();
                txtUserName.Text = Fm.gridView1.GetFocusedRowCellValue("UserName").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                txtPassword.Text = Fm.gridView1.GetFocusedRowCellValue("Password").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("UserIsActive"));

                if (txtUserName.Text == "مدیر سیستم")
                {
                    chkEditCode.Visible = false;
                    btnNewCode.Visible = false;
                    txtUserName.ReadOnly = true;
                    chkIsActive.Visible = false;
                }
                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtUserName.Text;
                UserNameBeforEdit = txtUserName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool btnCreateClose_Clicked = true;
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
                            MsUser obj = new MsUser()
                            {
                                UserCode = Convert.ToInt32(txtCode.Text),
                                UserName = txtUserName.Text,
                                Name = txtName.Text,
                                Password = txtPassword.Text,
                                UserIsActive = chkIsActive.Checked,
                            };
                            db.MsUsers.Add(obj);
                            db.SaveChanges();
                            if (chkIsActive.Checked)
                                Fm.btnDisplyActiveList_ItemClick(null, null);
                            else
                                Fm.btnDisplyNotActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateClose_Clicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                btnNewCode_Click(null, null);
                                txtUserName.Text = "";
                                txtName.Text = "";
                                txtPassword.Text = "";
                                txtUserName.Focus();
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
                            var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == RowId);
                            if (q != null)
                            {
                                q.UserCode = Convert.ToInt32(txtCode.Text);
                                q.UserName = txtUserName.Text;
                                q.Name = txtName.Text;
                                q.Password = txtPassword.Text;
                                q.UserIsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.SaveChanges();
                                if (IsActiveBeforeEdit)
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                else
                                    Fm.btnDisplyNotActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
                            var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == RowId);
                            if (q != null)
                            {
                                if (q.UserName == "مدیر سیستم")
                                {
                                    XtraMessageBox.Show("نام کاربر مدیر سیستم قابل حذف نیست فقط میتوان شناسه کاربری و رمز عبور را ویرایش نمود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    return;
                                }
                                else
                                {
                                    //q.UserCode = Convert.ToInt32(txtCode.Text);
                                    //q.UserName = txtUserName.Text;
                                    //q.Name = txtName.Text;
                                    //q.Password = txtPassword.Text;
                                    //q.UserIsActive = Convert.ToBoolean(chkIsActive.Checked);
                                    //q.DoreMali = Convert.ToInt32(Fm.lblSelectDoreMali.Text);

                                    db.MsUsers.Remove(q);
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

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsUsers.Any())
                    {
                        var MaximumCod = db.MsUsers.Max(p => p.UserCode);
                        txtCode.Text = (MaximumCod + 1).ToString();
                    }
                    else
                    {
                        txtCode.Text = "101";
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
            btnCreateClose_Clicked = false;
            btnCreateClose_Click(null, null);
            btnCreateClose_Clicked = true;
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 100)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Fm.En == EnumCED.Create)
                {
                    btnNewCode_Click(null, null);
                }
                else
                {
                    txtCode.Text = CodeBeforeEdit;
                }

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
                            if (db.MsUsers.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.MsUsers.Where(p => p.UserCode == _code);
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
                            var q1 = db.MsUsers.Where(p => p.MsUserId != RowId && p.UserCode == _code);
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

            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text) || txtUserName.Text == "0" || txtName.Text == "0" || txtPassword.Text == "0")
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
                            if (db.MsUsers.Any())
                            {
                                var q2 = db.MsUsers.Where(p => p.UserName == txtUserName.Text);
                                var q3 = db.MsUsers.Where(p => p.Name == txtName.Text);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("کاربر مورد نظر قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtUserName.Focus();
                                    return false;
                                }
                                if (q3.Any())
                                {
                                    XtraMessageBox.Show("این شناسه کاربری قبلاً استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Text = "";
                                    txtName.Focus();
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q2 = db.MsUsers.Where(p => p.MsUserId != RowId && p.UserName == txtUserName.Text);
                            var q3 = db.MsUsers.Where(p => p.MsUserId != RowId && p.Name == txtName.Text);
                            if (q2.Any())
                            {
                                XtraMessageBox.Show("کاربر مورد نظر قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                txtUserName.Focus();
                                return false;
                            }
                            if (q3.Any())
                            {
                                XtraMessageBox.Show("این شناسه کاربری قبلاً استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                txtName.Text = "";
                                txtName.Focus();
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


        private void FrmUsersCed_KeyDown(object sender, KeyEventArgs e)
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
    }

}
