﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmAnbarsName.cs
*	Project:		Hesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 17   04:17 ب.ظ
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
using DBHesabdari_PG;


namespace Hesabdari_PG.Forms.Ap.AnbarKala
{
    public partial class FrmAnbarhaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmAnbarhaList Fm;
        public FrmAnbarhaCed()
        {
            InitializeComponent();
        }
        public FrmAnbarhaCed(FrmAnbarhaList fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        private void FrmAnbarhaCed_Load(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
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

        bool btnCreateClose_Clicked = true;
        private void btnCreateClose_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                if (Fm.En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            ApAnbar obj = new ApAnbar()
                            {
                                AnbarCode = Convert.ToInt32(txtCode.Text),
                                AnbarName = txtName.Text,
                                AnbarIsActive = chkIsActive.Checked
                            };
                            db.ApAnbars.Add(obj);
                            db.SaveChanges();
                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Fm.gridView1.MoveLast();
                            if (btnCreateClose_Clicked)
                                this.Close();
                            else
                            {
                                btnNewCode_Click(null, null);
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
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.ApAnbars.FirstOrDefault(p => p.ApAnbarId == RowId);
                            if (q != null)
                            {
                                q.AnbarCode = Convert.ToInt32(txtCode.Text);
                                q.AnbarName = txtName.Text;
                                q.AnbarIsActive = Convert.ToBoolean(chkIsActive.Checked);

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
                            var q = db.ApAnbars.FirstOrDefault(p => p.ApAnbarId == RowId);
                            if (q != null)
                            {
                                q.AnbarCode = Convert.ToInt32(txtCode.Text);
                                q.AnbarName = txtName.Text;
                                q.AnbarIsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.ApAnbars.Remove(q);
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
                    if (db.ApAnbars.Any())
                    {
                        var MaximumCod = db.ApAnbars.Max(p => p.AnbarCode);
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
            if (txtCode.Text == string.Empty || txtCode.Text == "0")
            {
                XtraMessageBox.Show("لطفاً کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            /////////////////////////////////////////////

            if (txtName.Text == string.Empty || txtName.Text == "0")
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
                            if (db.ApAnbars.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.ApAnbars.Where(p => p.AnbarCode == _code);
                                var q2 = db.ApAnbars.Where(p => p.AnbarName.Contains(txtName.Text));
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
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q1 = db.ApAnbars.Where(p => p.ApAnbarId != RowId && p.AnbarCode == _code);
                            var q2 = db.ApAnbars.Where(p => p.ApAnbarId != RowId && p.AnbarName.Contains(txtName.Text));
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

    }
}