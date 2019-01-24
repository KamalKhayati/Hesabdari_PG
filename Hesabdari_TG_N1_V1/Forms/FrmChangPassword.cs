/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmChangPassword.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 24   03:01 ب.ظ
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

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmChangPassword : DevExpress.XtraEditors.XtraForm
    {
        public FrmChangPassword()
        {
            InitializeComponent();
        }
        int _UserId = 0;
        private void FrmChangPassword_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _UserId = Convert.ToInt32(lblUserId.Text);
                    var q = db.MsUsers.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                    {
                        txtCode.Text = q.UserCode.ToString();
                        txtUserName.Text = q.UserName.ToString();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsUsers.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                    {
                        if (txtNewName.Text != "" && txtNewPassword.Text != "" && txtNewName.Text != "0" && txtNewPassword.Text != "0")
                        {
                            q.Name = txtNewName.Text;
                            q.Password = txtNewPassword.Text;
                            db.SaveChanges();
                            XtraMessageBox.Show("تغییر شناسه کاربری و رمز عبور با موفقیت انجام شد",
                                          "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else 
                        {

                            XtraMessageBox.Show("لطفاً شناسه کاربری و رمز عبور جدید را وارد کنید",
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNewName.Focus();
                        }
                    }
                    else
                        XtraMessageBox.Show("کاربر جاری در بانک اطلاعاتی یافت نشد",
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsUsers.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                    {
                        if (q.Name == txtName.Text && q.Password == txtPassword.Text)
                        {
                            txtName.ReadOnly = true;
                            txtPassword.ReadOnly = true;
                            panelControl3.Enabled = true;
                            txtNewName.Focus();
                        }
                        else
                        {
                            XtraMessageBox.Show("رمز عبور فعلی اشتباه است",
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Text = "";
                            txtPassword.Focus();
                        }
                    }
                    else
                        XtraMessageBox.Show("کاربر جاری در بانک اطلاعاتی یافت نشد",
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtNewName_EditValueChanged(object sender, EventArgs e)
        {
            btnSaveClose.Enabled = true;
        }

        private void txtNewName_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int RowId = Convert.ToInt32(lblUserId.Text);
                    var q3 = db.MsUsers.Where(p => p.MsUserId != RowId && p.Name == txtNewName.Text);
                    if (q3.Any())
                    {
                        XtraMessageBox.Show("این شناسه کاربری قبلاً استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //txtName.Text = nameBeforeEdit;
                        txtNewName.Text="";
                        txtNewName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    string _Name = txtName.Text;
                    var q = db.MsUsers.FirstOrDefault(f =>f.MsUserId==_UserId && f.Name == _Name);
                    if (q == null)
                    {
                        XtraMessageBox.Show("شناسه کاربری فعلی اشتباه است",
                                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtName.Text = "";
                        txtName.Focus();
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