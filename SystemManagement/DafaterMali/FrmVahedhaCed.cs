/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmVahedhaCed.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   04:12 ب.ظ
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
using HelpClassLibrary;
using DBHesabdari_TG;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.DafaterMali
{
    public partial class FrmVahedhaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmVahedhaList Fm;
        public FrmVahedhaCed(FrmVahedhaList fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public void FillcmbMajmoehaList()
        {
            //var db = new MyContext();
            //db.MsMajmoes.Where(s => s.IsActive == true).LoadAsync().ContinueWith(loadTask =>
            //{
            //    // Bind data to control when loading complete
            //    msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsMajmoes.Any())
                    {
                        if (Fm.isActive == true)
                        {
                            db.MsMajmoes.Where(s => s.MajmoeIsActive == true).Load();
                            msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
                        }
                        else
                        {
                            db.MsMajmoes.Load();
                            msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
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
            if (cmbMajmoehaList.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int MajmoetId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                        var q = db.MsVaheds.Where(s => s.MsMajmoeId == MajmoetId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.VahedCode);
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

        int MajmoeIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmVahedhaCed_Load(object sender, EventArgs e)
        {
            FillcmbMajmoehaList();
            if (Fm.lblUserId.Text == "1")
                chkIsActive.Visible = true;
            if (this.Text != "ایجاد رکورد جدید")
            {
                cmbMajmoehaList.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("MsVahedId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("VahedCode").ToString().Substring(2);
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("VahedName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("VahedIsActive"));

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsVahedId == RowId);
                        if (q4 != null)
                        {
                            if (q4.NoeShakhs == "حقیقی") radioButton1.Checked = true; else radioButton2.Checked = true;
                            txtNoeFaaliat.Text = q4.NoeFaaliat.ToString();
                            txtAdress.Text = q4.Adress.ToString();
                            txtCodePosti.Text = q4.CodePosti.ToString();
                            txtSandoghPosti.Text = q4.SandoghPosti.ToString();
                            txtShomarePlak.Text = q4.ShomarePlak.ToString();
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
                MajmoeIdBeforeEdit = Convert.ToInt32(cmbMajmoehaList.EditValue);
                IsActiveBeforeEdit = chkIsActive.Checked;

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
                if (Fm.En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            MsVahed obj = new MsVahed()
                            {
                                VahedCode = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text),
                                VahedName = txtName.Text,
                                VahedIsActive = chkIsActive.Checked,
                                MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue),
                                MajmoeName = cmbMajmoehaList.Text,
                            };
                            db.MsVaheds.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                            var q = db.MsVaheds.FirstOrDefault(s => s.VahedCode == _code);

                            MsInfoOther obj2 = new MsInfoOther()
                            {
                                MsVahedId = q.MsVahedId,
                                MsCode = _code,
                                MsName = txtName.Text,
                                NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                NoeFaaliat = txtNoeFaaliat.Text,
                                Adress = txtAdress.Text,
                                CodePosti = txtCodePosti.Text,
                                SandoghPosti = txtSandoghPosti.Text,
                                ShomarePlak = txtShomarePlak.Text,
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
                            ////////////////////////////////////// اضافه کردن واحد های تجاری به کلاس سطح دسترسی دفاتر مالی ////////////////////
                            MsAccessLevelDafaterMali n1 = new MsAccessLevelDafaterMali();
                            n1.KeyId = _code;
                            n1.ParentId = Convert.ToInt32(_code.ToString().Substring(0, 2));
                            n1.LevelName = txtName.Text;
                            n1.MajmoeId = q.MsMajmoeId;
                            n1.VahedId = q.MsVahedId;
                            n1.IsActive = chkIsActive.Checked;
                            db.MsAccessLevelDafaterMalis.Add(n1);
                            /////////////////////////////////////////////////////////////////////////////////////
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
                                cmbMajmoehaList.EditValue = Convert.ToInt32(cmbMajmoehaList.EditValue);
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
                else if (Fm.En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            string _MajmoeName = cmbMajmoehaList.Text;
                            int _VahedId = Convert.ToInt32(txtId.Text);
                            string _VahedName = txtName.Text;
                            int _VahedCode = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                            //var q9 = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == _MajmoeId);
                            var q = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == _VahedId);
                            if (q != null)
                            {
                                q.MsMajmoeId = _MajmoeId;
                                q.MajmoeName = _MajmoeName;
                                q.VahedCode = _VahedCode;
                                q.VahedName = _VahedName;
                                q.VahedIsActive = chkIsActive.Checked;
                                /////////////////////////////متد اصلاح کد و نام در لیست شعبه ها و دوره های مالی WillCascadeOnUpdate ///////////////////////

                                /////////////////////////// WillCascadeOnUpdate : MsShobes /////////////////////////
                                var q6 = db.MsShobes.Where(s => s.MsVahedId == _VahedId).ToList();
                                if (q6.Count > 0)
                                {
                                    q6.ForEach(item =>
                                    {
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                            item.MsMajmoeId = _MajmoeId;
                                            item.MajmoeName = _MajmoeName;
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                            item.ShobeCode = Convert.ToInt32(item.ShobeCode.ToString().Substring(0, 2).Replace(item.ShobeCode.ToString().Substring(0, 2), txtMajmoeCode.Text)
                                            + item.ShobeCode.ToString().Substring(2, 2).Replace(item.ShobeCode.ToString().Substring(2, 2), txtCode.Text)
                                            + item.ShobeCode.ToString().Substring(4));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.VahedName = _VahedName;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.ShobeIsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                var q7 = db.MsDoreMalis.Where(s => s.MsVahedId == _VahedId).ToList();
                                if (q7.Count > 0)
                                {
                                    q7.ForEach(item =>
                                    {
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                            item.MsMajmoeId = _MajmoeId;
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                            item.MajmoeName = _MajmoeName;
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                            item.DoreMaliCode = Convert.ToInt32(item.DoreMaliCode.ToString().Substring(0, 2).Replace(item.DoreMaliCode.ToString().Substring(0, 2), txtMajmoeCode.Text)
                                            + item.DoreMaliCode.ToString().Substring(2, 2).Replace(item.DoreMaliCode.ToString().Substring(2, 2), txtCode.Text)
                                            + item.DoreMaliCode.ToString().Substring(4));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.VahedName = _VahedName;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.DoreMaliIsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.MsAccessLevelDafaterMalis.Where(s => s.VahedId == _VahedId).ToList();
                                if (q8.Count > 0)
                                {
                                    q8.ForEach(item =>
                                    {
                                        if (item.ShobeId == 0)
                                        {
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = _VahedCode;
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.ParentId = Convert.ToInt32(txtMajmoeCode.Text);
                                            if (NameBeforeEdit != txtName.Text)
                                                item.LevelName = txtName.Text;
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.MajmoeId = _MajmoeId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                        else
                                        {
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtMajmoeCode.Text)
                                                + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtCode.Text) + item.KeyId.ToString().Substring(4));
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), txtMajmoeCode.Text)
                                                + item.ParentId.ToString().Substring(2, 2).Replace(item.ParentId.ToString().Substring(2, 2), txtCode.Text) + item.ParentId.ToString().Substring(4));
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.MajmoeId = _MajmoeId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                    });
                                }
                                ///////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.VahedId == _VahedId).ToList();
                                if (q9.Count > 0)
                                {
                                    q9.ForEach(item =>
                                    {
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtMajmoeCode.Text)
                                            + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtCode.Text) + item.KeyId.ToString().Substring(4));
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                            item.MajmoeId = _MajmoeId;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////////////////////////////////////////////////////////
                                int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsVahedId == _VahedId);
                                if (q4 != null)
                                {
                                    q4.MsVahedId = _VahedId;
                                    q4.MsCode = _code;
                                    q4.MsName = txtName.Text;
                                    q4.NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی";
                                    q4.NoeFaaliat = txtNoeFaaliat.Text;
                                    q4.Adress = txtAdress.Text;
                                    q4.CodePosti = txtCodePosti.Text;
                                    q4.SandoghPosti = txtSandoghPosti.Text;
                                    q4.ShomarePlak = txtShomarePlak.Text;
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
                                        MsVahedId = _VahedId,
                                        MsCode = _code,
                                        MsName = txtName.Text,
                                        NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                        NoeFaaliat = txtNoeFaaliat.Text,
                                        Adress = txtAdress.Text,
                                        CodePosti = txtCodePosti.Text,
                                        SandoghPosti = txtSandoghPosti.Text,
                                        ShomarePlak = txtShomarePlak.Text,
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
                                ////////////////////////////////////////////////////////////////////////////////////
                                if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                {
                                    int MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                    var m = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == MajmoeId);
                                    var a1 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                    //var a2 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == _VahedId && p.ShobeId == 0);
                                    var b1 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                    //var b2 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == _VahedId && p.ShobeId == 0);
                                    if (m != null)
                                        m.MajmoeIsActive = true;
                                    if (a1 != null)
                                        a1.IsActive = true;
                                    //if (a2 != null)
                                    //    a2.IsActive = true;
                                    if (b1 != null)
                                        b1.IsActive = true;
                                    //if (b2 != null)
                                    //    b2.IsActive = true;
                                }

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
                            var q = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == RowId);
                            var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.VahedId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.MsVaheds.Remove(q);
                                db.MsAccessLevelDafaterMalis.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                                if (q4 != null)
                                {
                                    db.MsInfoOthers.Remove(q4);
                                };

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
                            if (db.MsVaheds.Any())
                            {
                                int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                                var q1 = db.MsVaheds.Where(p => p.VahedCode == _code);
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
                            int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                            var q1 = db.MsVaheds.Where(p => p.MsVahedId != RowId && p.VahedCode == _code);
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

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0" || string.IsNullOrEmpty(cmbMajmoehaList.EditValue.ToString()))
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
                            if (db.MsVaheds.Any())
                            {
                                var q1 = db.MsVaheds.Where(p => p.MsMajmoeId == _MajmoeId && p.VahedName == txtName.Text);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این واحد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.MsVaheds.Where(p => p.MsMajmoeId == _MajmoeId && p.MsVahedId != RowId && p.VahedName == txtName.Text);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این واحد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        int _MajmoeId = 0;
        private void cmbMajmoehaList_EditValueChanged(object sender, EventArgs e)
        {
            _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
            using (var db = new MyContext())
            {
                try
                {
                    int id = Convert.ToInt32(cmbMajmoehaList.EditValue.ToString());
                    var q = db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == id).MajmoeCode;
                    if (q > 0)
                        txtMajmoeCode.Text = q.ToString();

                    btnNewCode_Click(null, null);

                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbMajmoehaList_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbMajmoehaList.ShowPopup();
            }
            else
            {
                cmbMajmoehaList.ClosePopup();
            }
        }
        private void chkSpecificationOther_CheckedChanged(object sender, EventArgs e)
        {
            this.Height = chkSpecificationOther.Checked ? 687 : 296;

        }

        private void FrmVahedhaCed_KeyDown(object sender, KeyEventArgs e)
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
                if (Convert.ToInt32(txtCode.Text) == 0)
                {
                    XtraMessageBox.Show("کد وارده باید عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtShenaseMelli.Properties.MaxLength = radioButton1.Checked ? 10 : 11;
        }
    }

}
