﻿/****************************** Ghost.github.io ******************************\
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

namespace SystemManagement.UsersSystem
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
        private void FrmUsersCed_Load(object sender, EventArgs e)
        {
            if (this.Text == "ایجاد رکورد جدید")
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("MsUserId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("UserCode").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("UserName").ToString();
                txtUserName.Text = Fm.gridView1.GetFocusedRowCellValue("UserNam").ToString();
                txtPassword.Text = Fm.gridView1.GetFocusedRowCellValue("UserPassword").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("UserIsActive"));

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
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
                if (this.Text == "ایجاد رکورد جدید")
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            MsUser obj = new MsUser()
                            {
                                UserCode = Convert.ToInt32(txtCode.Text),
                                UserName = txtName.Text,
                                UserNam = txtUserName.Text,
                                UserPassword = txtPassword.Text,
                                UserIsActive = chkIsActive.Checked
                            };
                            db.MsUsers.Add(obj);
                            db.SaveChanges();
                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateClose_Clicked)
                                this.Close();
                            else
                            {
                                btnNewCode_Click(null, null);
                                txtName.Text = "";
                                txtUserName.Text = "";
                                txtPassword.Text = "";
                                txtName.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (this.Text == "ویرایش رکورد جاری")
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
                                q.UserName = txtName.Text;
                                q.UserNam = txtUserName.Text;
                                q.UserPassword = txtPassword.Text;
                                q.UserIsActive = Convert.ToBoolean(chkIsActive.Checked);

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
                else if (this.Text == "حذف رکورد جاری")
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
                                q.UserName = txtName.Text;
                                q.UserNam = txtUserName.Text;
                                q.UserPassword = txtPassword.Text;
                                q.UserIsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.MsUsers.Remove(q);
                                db.SaveChanges();
                                Fm.btnDisplyActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex - 1;
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
                if (this.Text == "ایجاد رکورد جدید")
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
                        if (this.Text == "ایجاد رکورد جدید")
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
                        else if (this.Text == "ویرایش رکورد جاری")
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

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) || txtName.Text == "0")
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
                        if (this.Text == "ایجاد رکورد جدید")
                        {
                            if (db.MsUsers.Any())
                            {
                                var q2 = db.MsUsers.Where(p => p.UserName.Contains(txtName.Text));
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (this.Text == "ویرایش رکورد جاری")
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q2 = db.MsUsers.Where(p => p.MsUserId != RowId && p.UserName.Contains(txtName.Text));
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

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.EnterReplaceTab(e);
        }
    }

}
