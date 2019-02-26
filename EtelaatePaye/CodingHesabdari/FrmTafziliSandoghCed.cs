/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabTafziliCed.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 21   10:10 ق.ظ
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
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmTafziliSandoghCed : DevExpress.XtraEditors.XtraForm
    {
        FrmTafziliSandoghList Fm;
        public FrmTafziliSandoghCed(FrmTafziliSandoghList fm)
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
                    var q = db.EpHesabTafziliSandoghs.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString().Substring(2) != "99999")
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                        else
                        {
                            if (Fm.En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 99999 حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از 99999 حساب تفضیلی برای هر گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 1 تا 99999 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "00001";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmTafziliSandoghCed_Load(object sender, EventArgs e)
        {
            if (Fm.lblUserId.Text == "1")
                chkIsActive.Visible = true;

            if (Fm.En == EnumCED.Create)
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCodeGroupTafziliSandogh.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0,2);
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                txtNameMasol.Text = Fm.gridView1.GetFocusedRowCellValue("NameMasol").ToString();
                txtStartDate.EditValue = Fm.gridView1.GetFocusedRowCellValue("StartDate").ToString().Substring(0, 10);
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = Fm.gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                if (txtCode.Text == "99999")
                    btnNewCode.Enabled = false;

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
                            EpHesabTafziliSandogh obj = new EpHesabTafziliSandogh();
                            obj.Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.NameMasol = txtNameMasol.Text;
                            obj.StartDate = Convert.ToDateTime(txtStartDate.Text);
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;

                            db.EpHesabTafziliSandoghs.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            //var q = db.EpHesabTafziliSandoghs.FirstOrDefault(s => s.Code == _Code);
                            //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            //EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            //n1.KeyId = _Code;
                            //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                            //n1.LevelName = txtName.Text;
                            //n1.HesabGroupId = q.GroupId;
                            //n1.HesabColId = q.Id;
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
                                txtSharhHesab.Text = string.Empty;
                                txtName.Text = string.Empty;
                                txtNameMasol.Text = string.Empty;
                                txtStartDate.Text = string.Empty;
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
                            int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            string _Name = txtName.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = _Code;
                                q.Name = _Name;
                                q.NameMasol = txtNameMasol.Text;
                                q.StartDate = Convert.ToDateTime(txtStartDate.Text);
                                q.IsActive = chkIsActive.Checked;
                                q.SharhHesab = txtSharhHesab.Text;

                                /////////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                //var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId).ToList();
                                //if (q6.Count > 0)
                                //{
                                //    q6.ForEach(item =>
                                //    {
                                //        if (CodeBeforeEdit != txtCode.Text)
                                //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 2).Replace(item.Code.ToString().Substring(0, 2), _Code.ToString())
                                //                + item.Code.ToString().Substring(2));
                                //        if (NameBeforeEdit != txtName.Text)
                                //            item.ColName = txtName.Text;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                //var q8 = db.EpAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                //if (q8.Count > 0)
                                //{
                                //    q8.ForEach(item =>
                                //    {
                                //        if (item.HesabMoinId == 0)
                                //        {
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //            if (NameBeforeEdit != txtName.Text)
                                //                item.LevelName = txtName.Text;
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.HesabGroupId = _GroupId;
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //        else
                                //        {
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                //                + item.KeyId.ToString().Substring(2));
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), _Code.ToString())
                                //                + item.ParentId.ToString().Substring(2));
                                //            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //                item.HesabGroupId = _GroupId;
                                //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //                item.IsActive = chkIsActive.Checked;
                                //        }
                                //    });
                                //}
                                ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                //var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                //if (q9.Count > 0)
                                //{
                                //    q9.ForEach(item =>
                                //    {
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), _Code.ToString())
                                //            + item.KeyId.ToString().Substring(2));
                                //        if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                //            item.HesabGroupId = _GroupId;
                                //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                //            item.IsActive = chkIsActive.Checked;
                                //    });
                                //}
                                ////////////////////////////////////////////////////////////////////////////////////////
                                //if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                //{
                                //    var m = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                //    var a1 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                //    //var a2 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                //    var b1 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                //    //var b2 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                //    if (m != null)
                                //        m.IsActive = true;
                                //    if (a1 != null)
                                //        a1.IsActive = true;
                                //    //if (a2 != null)
                                //    //    a2.IsActive = true;
                                //    if (b1 != null)
                                //        b1.IsActive = true;
                                //    //if (b2 != null)
                                //    //    b2.IsActive = true;
                                //}

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
                            var q = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.EpHesabTafziliSandoghs.Remove(q);
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
                            XtraMessageBox.Show("عملیات با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
                                " جهت حذف حساب تفضیلی در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
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
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 99999)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 100000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabTafziliSandoghs.Any())
                            {
                                var q1 = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Code == _Code);
                                if (q1!=null)
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
                            var q1 = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Id != RowId && p.Code == _Code);
                            if (q1 != null)
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

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0")
            {
                XtraMessageBox.Show("لطفاً نام حساب تفضیلی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.EpHesabTafziliSandoghs.Any())
                            {
                                var q1 = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Name == txtName.Text);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
                            if (q1 != null)
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

        private void FrmTafziliSandoghCed_KeyDown(object sender, KeyEventArgs e)
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