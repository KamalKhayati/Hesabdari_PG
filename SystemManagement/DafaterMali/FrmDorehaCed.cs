/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmDoreMaliCed.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   04:07 ب.ظ
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
using System.Data.Entity;
using System.Globalization;

namespace EtelaatePaye.DafaterMali
{
    public partial class FrmDorehaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmDorehaList Fm;
        public FrmDorehaCed(FrmDorehaList fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        int _ShobeId = 0;
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
        public void FillcmbVahedhaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsVaheds.Any())
                    {
                        if (Fm.isActive == true)
                        {
                            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            db.MsVaheds.Where(s => s.VahedIsActive == true && s.MsMajmoeId == _MajmoeId).Load();
                            msVahedsBindingSource.DataSource = db.MsVaheds.Local.ToBindingList();
                        }
                        else
                        {
                            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            db.MsVaheds.Where(s => s.MsMajmoeId == _MajmoeId).Load();
                            msVahedsBindingSource.DataSource = db.MsVaheds.Local.ToBindingList();
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
        public void FillcmbShobehaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsShobes.Any())
                    {
                        if (Fm.isActive == true)
                        {
                            int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                            db.MsShobes.Where(s => s.ShobeIsActive == true && s.MsVahedId == _VahedId).Load();
                            msShobesBindingSource.DataSource = db.MsShobes.Local.ToBindingList();
                        }
                        else
                        {
                            int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                            db.MsShobes.Where(s => s.MsVahedId == _VahedId).Load();
                            msShobesBindingSource.DataSource = db.MsShobes.Local.ToBindingList();
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
        public void FilltxtShobeCode()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (msShobesBindingSource.DataSource != null)
                    {
                        var q = db.MsShobes.FirstOrDefault(s => s.MsShobeId == _ShobeId);
                        if (q != null)
                            txtShobeCode.Text = q.ShobeCode.ToString();

                        btnNewCode_Click(null, null);
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
            if (cmbShobeList.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.MsDoreMalis.Where(s => s.MsShobeId == _ShobeId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.DoreMaliCode);
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(6);
                        }
                        else
                        {
                            txtCode.Text = "001";
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
        int VahedIdBeforeEdit = 0;
        int ShobeIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        int RowId = 0;
        private void FrmDorehaCed_Load(object sender, EventArgs e)
        {
            FillcmbMajmoehaList();
            if (Fm.lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                chkDoreIsClose.Visible = true;
            }
            if (this.Text != "ایجاد رکورد جدید")
            {
                cmbMajmoehaList.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                cmbVahedhaList.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
                cmbShobeList.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("MsShobeId").ToString());
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("MsDoreMaliId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("DoreMaliCode").ToString().Substring(6);
                txtDoreMali.Text = Fm.gridView1.GetFocusedRowCellValue("DoreMali").ToString();
                txtStartDore.EditValue = Fm.gridView1.GetFocusedRowCellValue("StartDoreMali").ToString().Substring(0, 10);
                txtEndDore.EditValue = Fm.gridView1.GetFocusedRowCellValue("EndDoreMali").ToString().Substring(0, 10);
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("DoreMaliIsActive"));
                chkDoreIsClose.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("DoreIsClose"));
                txtMaliat.Text = Fm.gridView1.GetFocusedRowCellValue("Maliat").ToString();
                txtAvarez.Text = Fm.gridView1.GetFocusedRowCellValue("Avarez").ToString();

                txtDoreMali.ReadOnly = false;
                RowId = Convert.ToInt32(txtId.Text);

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtDoreMali.Text;
                MajmoeIdBeforeEdit = Convert.ToInt32(cmbMajmoehaList.EditValue);
                VahedIdBeforeEdit = Convert.ToInt32(cmbVahedhaList.EditValue);
                IsActiveBeforeEdit = chkIsActive.Checked;

            }
            else
            {
                HelpClass1.SetCurrentYear(txtDoreMali);
                txtStartDore.Text = txtDoreMali.Text + "/" + "01/01";
                txtEndDore.Text = txtDoreMali.Text + "/" + "12/29";
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
                            MsDoreMali obj = new MsDoreMali();
                            obj.DoreMaliCode = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                            obj.DoreMali = Convert.ToInt32(txtDoreMali.Text);
                            obj.StartDoreMali = Convert.ToDateTime(txtStartDore.Text);
                            obj.EndDoreMali = Convert.ToDateTime(txtEndDore.Text);
                            obj.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            obj.MajmoeName = cmbMajmoehaList.Text;
                            obj.MsVahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                            obj.VahedName = cmbVahedhaList.Text;
                            obj.MsShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                            obj.ShobeName = cmbShobeList.Text;
                            obj.DoreMaliIsActive = chkIsActive.Checked;
                            obj.DoreIsClose = chkDoreIsClose.Checked;
                            obj.Maliat = Convert.ToSingle(txtMaliat.Text.Replace('/', '.') != "" ? txtMaliat.Text.Replace('/', '.') : "0");
                            obj.Avarez = Convert.ToSingle(txtAvarez.Text.Replace('/', '.') != "" ? txtAvarez.Text.Replace('/', '.') : "0");
                            db.MsDoreMalis.Add(obj);
                            db.SaveChanges();
                            ////////////////////////////////////// اضافه کردن دوره های مالی به کلاس سطح دسترسی دفاتر مالی ////////////////////
                            int _code = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                            var q = db.MsDoreMalis.FirstOrDefault(s => s.DoreMaliCode == _code);

                            MsAccessLevelDafaterMali n1 = new MsAccessLevelDafaterMali();
                            n1.KeyId = _code;
                            n1.ParentId = Convert.ToInt32(_code.ToString().Substring(0, 6));
                            n1.LevelName = txtDoreMali.Text;
                            n1.MajmoeId = q.MsMajmoeId;
                            n1.VahedId = q.MsVahedId;
                            n1.ShobeId = q.MsShobeId;
                            n1.DoreMaliId = q.MsDoreMaliId;
                            n1.IsActive = chkIsActive.Checked;
                            db.MsAccessLevelDafaterMalis.Add(n1);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////

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
                                //txtDoreMali.Text = "";
                                //txtStartDore.Text = "";
                                //txtEndDore.Text = "";
                                chkDoreIsClose.Checked = false;
                                txtMaliat.Text = "";
                                txtAvarez.Text = "";
                                txtDoreMali.Focus();
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
                            //string _m= txtMaliat.Text.ToString();
                            //string _a = txtMaliat.Text.ToString();
                            //float _M = (float)_m;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.MsDoreMalis.FirstOrDefault(p => p.MsDoreMaliId == RowId);
                            if (q != null)
                            {
                                q.DoreMaliCode = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                q.DoreMali = Convert.ToInt32(txtDoreMali.Text);
                                q.StartDoreMali = Convert.ToDateTime(txtStartDore.Text);
                                q.EndDoreMali = Convert.ToDateTime(txtEndDore.Text);
                                q.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                q.MajmoeName = cmbMajmoehaList.Text;
                                q.MsVahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                q.VahedName = cmbVahedhaList.Text;
                                q.MsShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                q.ShobeName = cmbShobeList.Text;
                                q.DoreMaliIsActive = chkIsActive.Checked;
                                q.DoreIsClose = chkDoreIsClose.Checked;
                                q.Maliat = Convert.ToSingle(txtMaliat.Text.Replace('/', '.') != "" ? txtMaliat.Text.Replace('/', '.') : "0");
                                q.Avarez = Convert.ToSingle(txtAvarez.Text.Replace('/', '.') != "" ? txtAvarez.Text.Replace('/', '.') : "0");
                                /////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                                if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue)|| ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                    q8.KeyId = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue)|| ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue) )
                                    q8.ParentId = Convert.ToInt32(txtShobeCode.Text);
                                if (NameBeforeEdit != txtDoreMali.Text)
                                    q8.LevelName = txtDoreMali.Text;
                                if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                    q8.MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                    q8.VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                if (ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue))
                                    q8.ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    q8.IsActive = chkIsActive.Checked;
                                ///////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                                if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                    q9.KeyId = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                    q9.MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                    q9.VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                if (ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue))
                                    q9.ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    q9.IsActive = chkIsActive.Checked;
                                /////////////////////////////////////////////////////////////////////////////
                                if (IsActiveBeforeEdit==false && chkIsActive.Checked == true)
                                {
                                    int MajmoeId= Convert.ToInt32(cmbMajmoehaList.EditValue);
                                    int VahedId= Convert.ToInt32(cmbVahedhaList.EditValue);
                                    int ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                    var m = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == MajmoeId);
                                    var v = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == VahedId);
                                    var s = db.MsShobes.FirstOrDefault(p => p.MsShobeId == ShobeId);
                                    var a1 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                    var a2 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                    var a3 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == 0);
                                    //var a4 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == RowId);
                                    var b1 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                    var b2 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                    var b3 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == 0);
                                    //var b4 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == RowId);
                                    if (m != null)
                                        m.MajmoeIsActive = true;
                                    if (v != null)
                                        v.VahedIsActive = true;
                                    if (s != null)
                                        s.ShobeIsActive = true;
                                    if (a1 != null)
                                        a1.IsActive = true;
                                    if (a2 != null)
                                        a2.IsActive = true;
                                    if (a3 != null)
                                        a3.IsActive = true;
                                    //if (a4 != null)
                                    //    a4.IsActive = true;
                                    if (b1 != null)
                                        b1.IsActive = true;
                                    if (b2 != null)
                                        b2.IsActive = true;
                                    if (b3 != null)
                                        b3.IsActive = true;
                                    //if (b4 != null)
                                    //    b4.IsActive = true;
                                }
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
                    int RowId = Convert.ToInt32(txtId.Text);
                    using (var db = new MyContext())
                    {
                        try
                        {
                            var q = db.MsDoreMalis.FirstOrDefault(p => p.MsDoreMaliId == RowId);
                            var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.MsDoreMalis.Remove(q);
                                db.MsAccessLevelDafaterMalis.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                if (XtraMessageBox.Show("در صورت وجود اطلاعات در سال مالی انتخابی کلیه اطلاعات سال مالی فوق از سیستم حذف خواهد شد و قابل برگشت نمی باشد", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    db.SaveChanges();
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                    XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    this.Close();
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
            else if (Convert.ToInt32(txtCode.Text) == 0)
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

                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _code = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.MsDoreMalis.Any())
                            {
                                var q1 = db.MsDoreMalis.Where(p => p.DoreMaliCode == _code);
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
                            var q1 = db.MsDoreMalis.Where(p => p.MsDoreMaliId != RowId && p.DoreMaliCode == _code);
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
            if (string.IsNullOrEmpty(txtDoreMali.Text) || Convert.ToInt32(txtDoreMali.Text) < 1397)
            {
                XtraMessageBox.Show("دوره مالی باید بیشتر از 1396 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbMajmoehaList.EditValue.ToString()) || string.IsNullOrEmpty(cmbVahedhaList.EditValue.ToString()) || string.IsNullOrEmpty(cmbShobeList.EditValue.ToString()))
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
                        int _DoreMali = Convert.ToInt32(txtDoreMali.Text);
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.MsDoreMalis.Any())
                            {
                                var q1 = db.MsDoreMalis.Where(p => p.MsShobeId == _ShobeId && p.DoreMali == _DoreMali);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این دوره قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            var q1 = db.MsDoreMalis.Where(p => p.MsShobeId == _ShobeId && p.MsDoreMaliId != RowId && p.DoreMali == _DoreMali);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این دوره قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtDoreMali.Text = nameBeforeEdit;
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

        private void cmbMajmoehaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbVahedhaList();
        }

        private void cmbVahedhaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbShobehaList();
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

        private void cmbVahedhaList_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbVahedhaList.ShowPopup();
            }
            else
            {
                cmbVahedhaList.ClosePopup();
            }

        }

        private void cmbShobehaList_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbShobeList.ShowPopup();
            }
            else
            {
                cmbShobeList.ClosePopup();
            }

        }

        private void FrmDorehaCed_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbShobeList_EditValueChanged(object sender, EventArgs e)
        {
            _ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
            FilltxtShobeCode();
        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = chkEditCode.Checked ? false : true;

        }

        private void txtDoreMali_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDoreMali.Text) || Convert.ToInt32(txtDoreMali.Text) < 1397)
            {
                XtraMessageBox.Show("دوره مالی باید بیشتر از 1396 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoreMali.Focus();
                return;
            }
            txtStartDore.Text = txtDoreMali.Text + "/" + "01/01";
            txtEndDore.Text = txtDoreMali.Text + "/" + "12/29";

        }
    }
}