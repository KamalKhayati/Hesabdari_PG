/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmLogin.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 13   02:27 ق.ظ
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

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsUsers.FirstOrDefault(f => f.Name == txtName.Text && f.Password == txtPassword.Text);
                    if (q != null)
                    {
                        this.Close();
                        //var q1 = db.RmsUserhaBmsAccessLevelMenuhas.Where(s => s.MsUserId == q.MsUserId).ToList();
                        //if (q1.Count==0)
                        //{
                        //    XtraMessageBox.Show("برای این کاربر هیچگونه سطح دسترسی تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        //{
                        //    Application.OpenForms[i].Close();
                        //}
                        //return;
                        //}
                        FrmMain fm = new FrmMain();
                        fm.txtUserId.Caption = q.MsUserId.ToString();
                        fm.txtUserName.Caption = q.UserName.ToString();
                        fm.Show();

                    }
                    else
                    {
                        XtraMessageBox.Show("رمز عبور اشتباه است",
                                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblSystemDate.Text = DateTime.Now.ToString().Substring(0, 10);

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        string _Name = txtName.Text;
                        var q = db.MsUsers.FirstOrDefault(f => f.Name == _Name);
                        if (q != null)
                        {
                            lblUserName.Visible = true;
                            lblUserName.Text = q.UserName;
                        }
                        else
                        {
                            XtraMessageBox.Show("شناسه کاربری اشتباه است",
                                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Text = "";
                            txtName.Focus();
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
    }
}