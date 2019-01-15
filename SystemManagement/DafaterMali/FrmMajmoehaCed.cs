﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmMajmoehaCed.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   03:53 ب.ظ
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
using System.Data.Entity;
using DBHesabdari_TG;
using System.Data.Entity.Infrastructure;

namespace SystemManagement.DafaterMali
{

    public partial class FrmMajmoehaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmMajmoehaList Fm;
        public FrmMajmoehaCed(FrmMajmoehaList fm)
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
                    if (db.MsMajmoes.Any())
                    {
                        var MaximumCod = db.MsMajmoes.Max(p => p.MajmoeCode);
                        txtCode.Text = (MaximumCod + 1).ToString();
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

        private void btnCreateNext_Click(object sender, EventArgs e)
        {
            btnCreateClose_Clicked = false;
            btnCreateClose_Click(null, null);
            btnCreateClose_Clicked = true;

        }

        bool btnCreateClose_Clicked = true;
        private void btnCreateClose_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                btnCreateClose.Enabled = false;
                btnCreateNext.Enabled = false;
                if (this.Text == "ایجاد رکورد جدید")
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            MsMajmoe obj = new MsMajmoe()
                            {
                                MajmoeCode = Convert.ToInt32(txtCode.Text),
                                MajmoeName = txtName.Text,
                                MajmoeIsActive = chkIsActive.Checked,
                            };
                            db.MsMajmoes.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q = db.MsMajmoes.FirstOrDefault(s => s.MajmoeCode == _code);
                            MsInfoOther obj2 = new MsInfoOther()
                            {
                                MsMajmoeId = q.MsMajmoeId,
                                MsCode = _code,
                                MsName = txtName.Text,
                                NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                NoeFaaliat = txtNoeFaaliat.Text,
                                Adress = txtAdress.Text,
                                CodePosti = txtCodePosti.Text,
                                SandoghPosti = txtSandoghPosti.Text,
                                ShomarePlak = txtShomarePlak.Text,
                                ShomareSabt = txtShomareSabt.Text,
                                CodeMelli = txtCodeMelli.Text,
                                ShenaseMelli = txtShenaseMelli.Text,
                                CodeSenfee = txtCodeSenfee.Text,
                                CodeEghtesadi = txtCodeEghtesadi.Text,
                                Tell1 = txtTell1.Text,
                                Tell2 = txtTell2.Text,
                                TellFax1 = txtTellFax1.Text,
                                TellFax2 = txtTellFax2.Text,
                                Mobile1 = txtMobile1.Text,
                                Mobile2 = txtMobile2.Text,
                                Email1 = txtEmail1.Text,
                                Email2 = txtEmail2.Text,
                                Site = txtSite.Text,
                                WebLog = txtWebLog.Text,
                                ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text,
                                ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text,
                                ShParvandeMaliati = txtShParvandeMaliati.Text,
                                ShBimeKargah = txtShBimeKargah.Text,
                            };
                            db.MsInfoOthers.Add(obj2);
                            db.SaveChanges();

                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateClose_Clicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                btnNewCode_Click(null, null);
                                txtName.Text = "";
                                HelpClass1.ClearTextEditControlsText(xtraScrollableControl1);
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
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            if (q != null)
                            {
                                q.MajmoeCode = Convert.ToInt32(txtCode.Text);
                                q.MajmoeName = txtName.Text;
                                q.MajmoeIsActive = Convert.ToBoolean(chkIsActive.Checked);

                                /////////////////////////////متد اصلاح کد و نام مجموعه در زیر شاخه های بالاتر WillCascadeOnUpdate ///////////////////////
                                if (CodeBeforeEdit != txtCode.Text || NameBeforeEdit != txtName.Text)
                                {
                                    ///////////////////////////// WillCascadeOnUpdate : MsVaheds ///////////////////////
                                    var q5 = db.MsVaheds.Where(s => s.MsMajmoeId == RowId).ToList();
                                    if (q5.Count > 0)
                                    {
                                        foreach (var item in q5)
                                        {
                                            string a = item.VahedCode.ToString().Substring(0, 2);
                                            string b = item.VahedCode.ToString().Substring(2, 2);
                                            string _txtName = item.MajmoeName.ToString();

                                            if (a != txtCode.Text || _txtName != txtName.Text)
                                            {
                                                item.VahedCode = Convert.ToInt32(txtCode.Text + b);
                                                item.MajmoeName = txtName.Text;
                                            }
                                        }
                                    }
                                    /////////////////////////// WillCascadeOnUpdate : MsShobes /////////////////////////
                                    var q6 = db.MsShobes.Where(s => s.MsMajmoeId == RowId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            string a = item.ShobeCode.ToString().Substring(0, 2);
                                            string b = item.ShobeCode.ToString().Substring(2, 4);
                                            string _txtName = item.MajmoeName.ToString();

                                            if (a != txtCode.Text || _txtName != txtName.Text)
                                            {
                                                item.ShobeCode = Convert.ToInt32(txtCode.Text + b);
                                                item.MajmoeName = txtName.Text;
                                            }
                                        }
                                    }
                                    /////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                    var q7 = db.MsDoreMalis.Where(s => s.MsMajmoeId == RowId).ToList();
                                    if (q7.Count > 0)
                                    {
                                        foreach (var item in q7)
                                        {
                                            string a = item.DoreMaliCode.ToString().Substring(0, 2);
                                            string b = item.DoreMaliCode.ToString().Substring(2, 7);
                                            string _txtName = item.MajmoeName.ToString();

                                            if (a != txtCode.Text || _txtName != txtName.Text)
                                            {
                                                item.DoreMaliCode = Convert.ToInt32(txtCode.Text + b);
                                                item.MajmoeName = txtName.Text;
                                            }
                                        }
                                    }
                                }
                                /////////////////////////////////////////////////////////////////////////////
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                                if (q4 != null)
                                {

                                    q4.MsMajmoeId = RowId;
                                    q4.MsCode = Convert.ToInt32(txtCode.Text);
                                    q4.MsName = txtName.Text;
                                    q4.NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی";
                                    q4.NoeFaaliat = txtNoeFaaliat.Text;
                                    q4.Adress = txtAdress.Text;
                                    q4.CodePosti = txtCodePosti.Text;
                                    q4.SandoghPosti = txtSandoghPosti.Text;
                                    q4.ShomarePlak = txtShomarePlak.Text;
                                    q4.ShomareSabt = txtShomareSabt.Text;
                                    q4.CodeMelli = txtCodeMelli.Text;
                                    q4.ShenaseMelli = txtShenaseMelli.Text;
                                    q4.CodeSenfee = txtCodeSenfee.Text;
                                    q4.CodeEghtesadi = txtCodeEghtesadi.Text;
                                    q4.Tell1 = txtTell1.Text;
                                    q4.Tell2 = txtTell2.Text;
                                    q4.TellFax1 = txtTellFax1.Text;
                                    q4.TellFax2 = txtTellFax2.Text;
                                    q4.Mobile1 = txtMobile1.Text;
                                    q4.Mobile2 = txtMobile2.Text;
                                    q4.Email1 = txtEmail1.Text;
                                    q4.Email2 = txtEmail2.Text;
                                    q4.Site = txtSite.Text;
                                    q4.WebLog = txtWebLog.Text;
                                    q4.ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text;
                                    q4.ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text;
                                    q4.ShParvandeMaliati = txtShParvandeMaliati.Text;
                                    q4.ShBimeKargah = txtShBimeKargah.Text;
                                }
                                else
                                {
                                    MsInfoOther obj2 = new MsInfoOther()
                                    {
                                        MsMajmoeId = RowId,
                                        MsCode = Convert.ToInt32(txtCode.Text),
                                        MsName = txtName.Text,
                                        NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                        NoeFaaliat = txtNoeFaaliat.Text,
                                        Adress = txtAdress.Text,
                                        CodePosti = txtCodePosti.Text,
                                        SandoghPosti = txtSandoghPosti.Text,
                                        ShomarePlak = txtShomarePlak.Text,
                                        ShomareSabt = txtShomareSabt.Text,
                                        CodeMelli = txtCodeMelli.Text,
                                        ShenaseMelli = txtShenaseMelli.Text,
                                        CodeSenfee = txtCodeSenfee.Text,
                                        CodeEghtesadi = txtCodeEghtesadi.Text,
                                        Tell1 = txtTell1.Text,
                                        Tell2 = txtTell2.Text,
                                        TellFax1 = txtTellFax1.Text,
                                        TellFax2 = txtTellFax2.Text,
                                        Mobile1 = txtMobile1.Text,
                                        Mobile2 = txtMobile2.Text,
                                        Email1 = txtEmail1.Text,
                                        Email2 = txtEmail2.Text,
                                        Site = txtSite.Text,
                                        WebLog = txtWebLog.Text,
                                        ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text,
                                        ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text,
                                        ShParvandeMaliati = txtShParvandeMaliati.Text,
                                        ShBimeKargah = txtShBimeKargah.Text,
                                    };
                                    db.MsInfoOthers.Add(obj2);

                                }

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
                else if (this.Text == "حذف رکورد جاری")
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            if (q != null)
                            {
                                //////////////////////////////////////////////////////////////////////////////////
                                //q.MajmoeCode = Convert.ToInt32(txtCode.Text);
                                //q.MajmoeName = txtName.Text;
                                //q.MajmoeIsActive = Convert.ToBoolean(chkIsActive.Checked);
                                //q.PermissiveUsers = chkcmbPermissiveUsers.Text;

                                db.MsMajmoes.Remove(q);

                                /////////////////////////////////////////////////////////////////////////////
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                                if (q4 != null)
                                {
                                    //q4.MsMajmoeId = Convert.ToInt32(txtId.Text);
                                    //q4.MsCode = Convert.ToInt32(txtCode.Text);
                                    //q4.MsName = txtName.Text;
                                    //q4.NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی";
                                    //q4.NoeFaaliat = txtNoeFaaliat.Text;
                                    //q4.Adress = txtAdress.Text;
                                    //q4.CodePosti = txtCodePosti.Text;
                                    //q4.SandoghPosti = txtSandoghPosti.Text;
                                    //q4.ShomarePlak = txtShomarePlak.Text;
                                    //q4.ShomareSabt = txtShomareSabt.Text;
                                    //q4.CodeMelli = txtCodeMelli.Text;
                                    //q4.ShenaseMelli = txtShenaseMelli.Text;
                                    //q4.CodeSenfee = txtCodeSenfee.Text;
                                    //q4.CodeEghtesadi = txtCodeEghtesadi.Text;
                                    //q4.Tell1 = txtTell1.Text;
                                    //q4.Tell2 = txtTell2.Text;
                                    //q4.TellFax1 = txtTellFax1.Text;
                                    //q4.TellFax2 = txtTellFax2.Text;
                                    //q4.Mobile1 = txtMobile1.Text;
                                    //q4.Mobile2 = txtMobile2.Text;
                                    //q4.Email1 = txtEmail1.Text;
                                    //q4.Email2 = txtEmail2.Text;
                                    //q4.Site = txtSite.Text;
                                    //q4.WebLog = txtWebLog.Text;
                                    //q4.ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text;
                                    //q4.ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text;
                                    //q4.ShParvandeMaliati = txtShParvandeMaliati.Text;
                                    //q4.ShBimeKargah = txtShBimeKargah.Text;
                                    db.MsInfoOthers.Remove(q4);
                                };

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
            else if (Convert.ToInt32(txtCode.Text) <= 9)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 9 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.MsMajmoes.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.MsMajmoes.Where(p => p.MajmoeCode == _code);
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
                            var q1 = db.MsMajmoes.Where(p => p.MsMajmoeId != RowId && p.MajmoeCode == _code);
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
                            if (db.MsMajmoes.Any())
                            {
                                var q2 = db.MsMajmoes.Where(p => p.MajmoeName == txtName.Text);
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
                            var q2 = db.MsMajmoes.Where(p => p.MsMajmoeId != RowId && p.MajmoeName == txtName.Text);
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
        private void FrmMajmoehaCed_Load(object sender, EventArgs e)
        {
            if (this.Text == "ایجاد رکورد جدید")
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("MajmoeCode").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("MajmoeName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("MajmoeIsActive"));

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                        if (q4 != null)
                        {
                            if (q4.NoeShakhs == "حقیقی") radioButton1.Checked = true; else radioButton2.Checked = true;
                            txtNoeFaaliat.Text = q4.NoeFaaliat.ToString();
                            txtAdress.Text = q4.Adress.ToString();
                            txtCodePosti.Text = q4.CodePosti.ToString();
                            txtSandoghPosti.Text = q4.SandoghPosti.ToString();
                            txtShomarePlak.Text = q4.ShomarePlak.ToString();
                            txtShomareSabt.Text = q4.ShomareSabt.ToString();
                            txtCodeMelli.Text = q4.CodeMelli.ToString();
                            txtShenaseMelli.Text = q4.ShenaseMelli.ToString();
                            txtCodeSenfee.Text = q4.CodeSenfee.ToString();
                            txtCodeEghtesadi.Text = q4.CodeEghtesadi.ToString();
                            txtTell1.Text = q4.Tell1.ToString();
                            txtTell2.Text = q4.Tell2.ToString();
                            txtTellFax1.Text = q4.TellFax1.ToString();
                            txtTellFax2.Text = q4.TellFax2.ToString();
                            txtMobile1.Text = q4.Mobile1.ToString();
                            txtMobile2.Text = q4.Mobile2.ToString();
                            txtEmail1.Text = q4.Email1.ToString();
                            txtEmail2.Text = q4.Email2.ToString();
                            txtSite.Text = q4.Site.ToString();
                            txtWebLog.Text = q4.WebLog.ToString();
                            txtShabakeEjtemaee1.Text = q4.ShabakeEjtemaee1.ToString();
                            txtShabakeEjtemaee2.Text = q4.ShabakeEjtemaee2.ToString();
                            txtShParvandeMaliati.Text = q4.ShParvandeMaliati.ToString();
                            txtShBimeKargah.Text = q4.ShBimeKargah.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
            }
        }
        private void chkSpecificationOther_CheckedChanged(object sender, EventArgs e)
        {
            this.Height = chkInformationOther.Checked ? 679 : 259;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtShomarePlak.Enabled = true;
                txtCodeMelli.Enabled = true;
                txtCodeSenfee.Enabled = true;
                txtShomareSabt.Enabled = false;
                txtShenaseMelli.Enabled = false;
                txtCodeEghtesadi.Enabled = false;
            }
            else
            {
                txtShomarePlak.Enabled = false;
                txtCodeMelli.Enabled = false;
                txtCodeSenfee.Enabled = false;
                txtShomareSabt.Enabled = true;
                txtShenaseMelli.Enabled = true;
                txtCodeEghtesadi.Enabled = true;

            }

        }

        private void FrmMajmoehaCed_KeyDown(object sender, KeyEventArgs e)
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
            if (Convert.ToInt32(txtCode.Text) <= 9)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 9 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.Text == "ایجاد رکورد جدید")
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

