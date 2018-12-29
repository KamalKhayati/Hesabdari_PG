/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmSaveMojtamaha.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 20   10:52 ب.ظ
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
using Hesabdari_TG_N1_V1.Models;
using Hesabdari_TG_N1_V1.Models.MS.DafaterMali;
using Hesabdari_TG_N1_V1.HelpClass;
using System.Data.Entity;

namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    public partial class FrmMajmoehaCed : DevExpress.XtraEditors.XtraForm
    {
        FrmMajmoehaList Fm;
        public FrmMajmoehaCed()
        {
            InitializeComponent();
        }

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
                            MsMajmoe obj = new MsMajmoe()
                            {
                                MajmoeCode = Convert.ToInt32(txtCode.Text),
                                MajmoeName = txtName.Text,
                                MajmoeIsActive = chkIsActive.Checked
                            };
                            db.MsMajmoes.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q = db.MsMajmoes.FirstOrDefault(s => s.MajmoeCode == _code);

                            if (msUsersBindingSource.DataSource != null)
                            {
                                var CheckedList = chkcmbPermissiveUsers.Properties.GetItems().GetCheckedValues();
                                if (CheckedList != null)
                                {
                                    foreach (var item in CheckedList)
                                    {
                                        RmsMajmoehaBmsUserha obj1 = new RmsMajmoehaBmsUserha();
                                        obj1.MsMajmoeId = q.MsMajmoeId;
                                        obj1.MajmoeName = q.MajmoeName;
                                        obj1.MsUserId = Convert.ToInt32(item.ToString());
                                        int id = Convert.ToInt32(item.ToString());
                                        var q1 = db.MsUsers.FirstOrDefault(s => s.MsUserId == id);
                                        obj1.UserName = q1.UserName;
                                        db.RmsMajmoehaBmsUserhas.Add(obj1);
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
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            if (q != null)
                            {
                                q.MajmoeCode = Convert.ToInt32(txtCode.Text);
                                q.MajmoeName = txtName.Text;
                                q.MajmoeIsActive = Convert.ToBoolean(chkIsActive.Checked);

                                db.SaveChanges();

                                /////////////////////////////////////////////////////////////////////////////////////
                                var q1 = db.RmsMajmoehaBmsUserhas.Where(s => s.MsMajmoeId == RowId).ToList();
                                if (q1.Count > 0)
                                {
                                    db.RmsMajmoehaBmsUserhas.RemoveRange(q1);
                                    db.SaveChanges();
                                }
                                //////////////////////////////////////////////
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q2 = db.MsMajmoes.FirstOrDefault(s => s.MajmoeCode == _code);

                                if (msUsersBindingSource.DataSource != null)
                                {
                                    var CheckedList = chkcmbPermissiveUsers.Properties.GetItems().GetCheckedValues();
                                    if (CheckedList != null)
                                    {
                                        foreach (var item in CheckedList)
                                        {
                                            RmsMajmoehaBmsUserha obj1 = new RmsMajmoehaBmsUserha();
                                            obj1.MsMajmoeId = Convert.ToInt32(txtId.Text); ;
                                            obj1.MajmoeName = txtName.Text;
                                            obj1.MsUserId = Convert.ToInt32(item.ToString());
                                            int id = Convert.ToInt32(item.ToString());
                                            var q3 = db.MsUsers.FirstOrDefault(s => s.MsUserId == id);
                                            obj1.UserName = q3.UserName;
                                            db.RmsMajmoehaBmsUserhas.Add(obj1);
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
                            var q1 = db.RmsMajmoehaBmsUserhas.Where(s => s.MsMajmoeId == RowId).ToList();
                            if (q1.Count > 0)
                            {
                                db.RmsMajmoehaBmsUserhas.RemoveRange(q1);
                                db.SaveChanges();
                            }
                            //////////////////////////////////////////////////////////////////////////////////
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            if (q != null)
                            {
                                q.MajmoeCode = Convert.ToInt32(txtCode.Text);
                                q.MajmoeName = txtName.Text;
                                q.MajmoeIsActive = Convert.ToBoolean(chkIsActive.Checked);
                                db.MsMajmoes.Remove(q);
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
                                var q2 = db.MsMajmoes.Where(p => p.MajmoeName.Contains(txtName.Text));
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
                            var q2 = db.MsMajmoes.Where(p => p.MsMajmoeId != RowId && p.MajmoeName.Contains(txtName.Text));
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
            FillchkcmbPermissiveUsers();

            if (this.Text == "ایجاد رکورد جدید")
            {
                btnNewCode_Click(null, null);
            }
            else
            {
                txtId.Text =Fm.gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("MajmoeCode").ToString();
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("MajmoeName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("MajmoeIsActive"));

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.RmsMajmoehaBmsUserhas.Where(s => s.MsMajmoeId == RowId).Select(s=>s.MsUserId).ToList();

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

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            HelpClass1.EnterReplaceTab(e);

        }

        public void FillchkcmbPermissiveUsers()
        {
            using (var db = new MyContext())
            {
                try
                {
                    // This line of code is generated by Data Source Configuration Wizard
                    // Call the Load method to get the data for the given DbSet from the database.
                    if (db.MsUsers.Any())
                    {
                        db.MsUsers.Where(s => s.UserIsActive == true).Load();
                        // This line of code is generated by Data Source Configuration Wizard
                        msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList();

                        // This line of code is generated by Data Source Configuration Wizard
                        // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
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

    }
}