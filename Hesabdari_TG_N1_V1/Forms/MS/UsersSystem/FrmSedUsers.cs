/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmSedKarbaran.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 22   02:30 ق.ظ
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
using Hesabdari_TG_N1_V1.HelpClass;
using Hesabdari_TG_N1_V1.Models;
using Hesabdari_TG_N1_V1.Models.MS.UsersSystem;

namespace Hesabdari_TG_N1_V1.Forms.MS.UsersSystem
{
    public partial class FrmSedUsers : DevExpress.XtraEditors.XtraForm
    {
        FrmListUsers Fm;
        public FrmSedUsers()
        {
            InitializeComponent();
        }
        public FrmSedUsers(FrmListUsers fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        private void FrmSedAnbarha_Load(object sender, EventArgs e)
        {
            if (this.Text == "ثبت رکورد جدید")
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool btnSaveClose_Clicked = false;
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (ValidationTextEdit())
            {
                if (this.Text == "ثبت رکورد جدید")
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            MsUser obj = new MsUser()
                            {
                                Code = Convert.ToInt32(txtCode.Text),
                                Name = txtName.Text,
                                UserName = txtUserName.Text,
                                Password = txtPassword.Text,
                                IsActive = chkIsActive.Checked
                            };
                            db.MsUsers.Add(obj);
                            db.SaveChanges();
                            if (chkIsActive.Checked)
                                Fm.btnDisplyListActive_ItemClick(null, null);
                            else
                                Fm.btnDisplyListNotActive_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnSaveClose_Clicked)
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
                            int IdRow = Convert.ToInt32(txtId.Text);
                            var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == IdRow);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.Name = txtName.Text;
                                q.UserName = txtUserName.Text;
                                q.Password = txtPassword.Text;
                                q.IsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    Fm.btnDisplyListActive_ItemClick(null, null);
                                else
                                    Fm.btnDisplyListNotActive_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                Fm.gridView1.FocusedRowHandle = HelpClass.HelpClass1.EditRowIndex;
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
                            int IdRow = Convert.ToInt32(txtId.Text);
                            var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == IdRow);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtCode.Text);
                                q.Name = txtName.Text;
                                q.UserName = txtUserName.Text;
                                q.Password = txtPassword.Text;
                                q.IsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.MsUsers.Remove(q);
                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    Fm.btnDisplyListActive_ItemClick(null, null);
                                else
                                    Fm.btnDisplyListNotActive_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                Fm.gridView1.FocusedRowHandle = HelpClass.HelpClass1.EditRowIndex - 1;
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
                        var MaximumCod = db.MsUsers.Max(p => p.Code);
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

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            btnSaveClose_Click(null, null);
        }
        private bool ValidationTextEdit()
        {
            if (txtCode.Text == string.Empty || txtCode.Text == "0")
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 100)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.Text == "ثبت رکورد جدید")
                {
                    btnNewCode_Click(null, null);
                }
                else
                {
                    txtCode.Text = CodeBeforeEdit;
                }

                return false;
            }

            /////////////////////////////////////////////

            if (txtName.Text == string.Empty || txtUserName.Text == string.Empty || txtPassword.Text == string.Empty || txtName.Text == "0")
            {
                XtraMessageBox.Show("لطفا اطلاعات را کامل وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (this.Text == "ثبت رکورد جدید")
                        {
                            if (db.MsUsers.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.MsUsers.Where(p => p.Code == _code);
                                var q2 = db.MsUsers.Where(p => p.Name.Contains(txtName.Text));
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                                else if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (this.Text == "ویرایش رکورد جاری")
                        {
                            int IdRow = Convert.ToInt32(txtId.Text);
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q1 = db.MsUsers.Where(p => p.MsUserId != IdRow && p.Code == _code);
                            var q2 = db.MsUsers.Where(p => p.MsUserId != IdRow && p.Name.Contains(txtName.Text));
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit;
                                return false;
                            }
                            else if (q2.Any())
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