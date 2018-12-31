﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmVahedhaCed.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 21   12:04 ق.ظ
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
using Hesabdari_TG_N1_V1.Models;
using Hesabdari_TG_N1_V1.HelpClass;
using Hesabdari_TG_N1_V1.Models.MS.DafaterMali;

namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    public partial class FrmVahedhaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmVahedhaList Fm;
        public FrmVahedhaCed()
        {
            InitializeComponent();
        }
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
                        // This line of code is generated by Data Source Configuration Wizard
                        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
                        db.MsMajmoes.Where(s => s.MajmoeIsActive == true).Load();
                        // Bind data to control when loading complete
                        msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillchkcmbPermissiveUsers()
        {
            using (var db = new MyContext())
            {
                try
                {
                    // This line of code is generated by Data Source Configuration Wizard
                    if (db.MsUsers.Any())
                    {
                        // This line of code is generated by Data Source Configuration Wizard
                        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
                        db.MsUsers.Where(s => s.UserIsActive == true).Load();
                        // Bind data to control when loading complete
                        msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
                        //db.MsUsers.Where(s => s.IsActive == true).LoadAsync().ContinueWith(loadTask =>
                        //{
                        //    // Bind data to control when loading complete
                        //    msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
                        //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #region
            // Add check items to the control's dropdown.
            //string[] itemValues = new string[] 
            //{
            //  "Circle", "Rectangle", "Ellipse",
            //  "Triangle", "Square"
            //};
            //foreach (string value in itemValues)
            // checkedComboBoxEdit1.Properties.Items.Add(value, CheckState.Unchecked, true);
            // Set the edit value.
            //checkedComboBoxEdit1.SetEditValue("Circle; Ellipse");
            // Disable the Circle item.
            //checkedComboBoxEdit1.Properties.Items["Circle"].Enabled = false;
            #endregion

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
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(3);
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

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        private void FrmVahedhaCed_Load(object sender, EventArgs e)
        {
            FillcmbMajmoehaList();
            FillchkcmbPermissiveUsers();

            if (this.Text != "ایجاد رکورد جدید")
            {
                cmbMajmoehaList.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                txtId.Text =  Fm.gridView1.GetFocusedRowCellValue("MsVahedId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("VahedCode").ToString().Substring(3);
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("VahedName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("VahedIsActive"));

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.RmsVahedhaBmsUserhas.Where(s => s.MsVahedId == RowId).Select(s => s.MsUserId).ToList();

                        string CheckedItems = string.Empty;
                        foreach (var item in q)
                            CheckedItems += item.ToString() + ",";

                        chkcmbPermissiveUsers.SetEditValue(CheckedItems);

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                if (this.Text == "ایجاد رکورد جدید")
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
                                PermissiveUsers=chkcmbPermissiveUsers.Text,
                            };
                            db.MsVaheds.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                            var q = db.MsVaheds.FirstOrDefault(s => s.VahedCode == _code);

                            if (msUsersBindingSource.DataSource != null)
                            {
                                var CheckedList = chkcmbPermissiveUsers.Properties.GetItems().GetCheckedValues();
                                if (CheckedList != null)
                                {
                                    foreach (var item in CheckedList)
                                    {
                                        RmsVahedhaBmsUserha obj1 = new RmsVahedhaBmsUserha();
                                        obj1.MsVahedId = q.MsVahedId;
                                        obj1.VahedName = q.VahedName;
                                        obj1.MsUserId = Convert.ToInt32(item.ToString());
                                        int id = Convert.ToInt32(item.ToString());
                                        var q1 = db.MsUsers.FirstOrDefault(s => s.MsUserId == id);
                                        obj1.UserName = q1.UserName;
                                        db.RmsVahedhaBmsUserhas.Add(obj1);
                                    }
                                    db.SaveChanges();

                                }
                            }
                            Fm.btnDisplyActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateClose_Clicked)
                                this.Close();
                            else
                            {
                                cmbMajmoehaList.EditValue = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                btnNewCode_Click(null, null);
                                txtName.Text = "";
                                chkcmbPermissiveUsers.SetEditValue("");
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
                            var q = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == RowId);
                            if (q != null)
                            {
                                q.VahedCode = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text);
                                q.VahedName = txtName.Text;
                                q.VahedIsActive = chkIsActive.Checked;
                                q.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                q.MajmoeName = cmbMajmoehaList.Text;
                                q.PermissiveUsers = chkcmbPermissiveUsers.Text;

                                db.SaveChanges();

                                /////////////////////////////////////////////////////////////////////////////////////
                                var q1 = db.RmsVahedhaBmsUserhas.Where(s => s.MsVahedId == RowId).ToList();
                                if (q1.Count > 0)
                                {
                                    db.RmsVahedhaBmsUserhas.RemoveRange(q1);
                                    db.SaveChanges();
                                }
                                //////////////////////////////////////////////

                                if (msUsersBindingSource.DataSource != null)
                                {
                                    var CheckedList = chkcmbPermissiveUsers.Properties.GetItems().GetCheckedValues();
                                    if (CheckedList != null)
                                    {
                                        foreach (var item in CheckedList)
                                        {
                                            RmsVahedhaBmsUserha obj1 = new RmsVahedhaBmsUserha();
                                            obj1.MsVahedId = q.MsVahedId;
                                            obj1.VahedName = q.VahedName;
                                            obj1.MsUserId = Convert.ToInt32(item.ToString());
                                            int id = Convert.ToInt32(item.ToString());
                                            var q2 = db.MsUsers.FirstOrDefault(s => s.MsUserId == id);
                                            obj1.UserName = q2.UserName;
                                            db.RmsVahedhaBmsUserhas.Add(obj1);
                                        }
                                        db.SaveChanges();

                                    }
                                }
                                Fm.btnDisplyActiveList_ItemClick(null, null);
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
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.RmsVahedhaBmsUserhas.Where(s => s.MsVahedId == RowId).ToList();
                            if (q1.Count > 0)
                            {
                                db.RmsVahedhaBmsUserhas.RemoveRange(q1);
                                db.SaveChanges();
                            }
                            //////////////////////////////////////////////////////////////////////////////////
                            var q = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == RowId);
                            if (q != null)
                            {
                                q.VahedCode = Convert.ToInt32(txtMajmoeCode.Text + txtCode.Text.ToString());
                                q.VahedName = txtName.Text;
                                q.VahedIsActive = chkIsActive.Checked;
                                q.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                q.MajmoeName = cmbMajmoehaList.Text;
                                q.PermissiveUsers = chkcmbPermissiveUsers.Text;

                                db.MsVaheds.Remove(q);
                                db.SaveChanges();

                                //////////////////////////////////////////////////////////////////////////////////

                                Fm.btnDisplyActiveList_ItemClick(null, null);
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
                        else if (this.Text == "ویرایش رکورد جاری")
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
                        if (this.Text == "ایجاد رکورد جدید")
                        {
                            if (db.MsVaheds.Any())
                            {
                                var q1 = db.MsVaheds.Where(p => p.VahedName.Contains(txtName.Text));
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (this.Text == "ویرایش رکورد جاری")
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.MsVaheds.Where(p => p.MsVahedId != RowId && p.VahedName.Contains(txtName.Text));
                            if (q1.Any())
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

        private void cmbListMajmoeha_EditValueChanged(object sender, EventArgs e)
        {
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            HelpClass1.TextBoxFormatDesign_000(txtCode);
        }

    }
}