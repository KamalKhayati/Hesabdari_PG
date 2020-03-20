/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabGroup.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 4   12:56 ب.ظ
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
using DBHesabdari_PG;
using System.Data.Entity;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabGroup : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabGroup()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridHesabGroup()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabGroups.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabGroupsBindingSource.DataSource = q1;
                            else
                                epHesabGroupsBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item3 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabGroups.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            epHesabGroupsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabGroupsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabGroupsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabGroups.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epHesabGroupsBindingSource.DataSource = q;
                            else
                                epHesabGroupsBindingSource.DataSource = null;
                        }
                        else
                            epHesabGroupsBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbTabaghebandiHesabha()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTabaghehs.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (IsActiveList == true)
                        {
                            db.EpHesabTabaghehs.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabTabaghehsBindingSource.DataSource = db.EpHesabTabaghehs.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabTabaghehs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabTabaghehsBindingSource.DataSource = db.EpHesabTabaghehs.Local.ToBindingList();
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
            using (var db = new MyContext())
            {
                try
                {
                    int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabGroups.Where(s => s.TabaghebandiHesabhaId == _TabaghebandiHesabhaId && s.SalId == _SalId).ToList();
                    if (q.Count > 0)
                    {
                        var MaximumCod = q.Max(s => s.Code);
                        if (MaximumCod.ToString().Substring(1) != "99")
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(1);
                        else
                        {
                            XtraMessageBox.Show("اعمال محدودیت تعریف 100 حساب گروه ..." + "\n" + "توجه : نمیتوان بیشتر از 100 حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 100 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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

        private void FrmHesabGroup_Load(object sender, EventArgs e)
        {
            FillDataGridHesabGroup();
            btnCreate.Focus();
            //if (lblUserId.Text == "1")
            //{
            //    chkIsActive.Visible = true;
            //    labelControl3.Visible = true;
            //}
            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        int _UserId = Convert.ToInt32(lblUserId.Text);
            //        var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
            //        if (q1.Count() > 0)
            //        {
            //            //btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010201) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010202) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010203) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtTabaghebandiCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 99)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabGroups.Any())
                            {
                                int _Code = Convert.ToInt32(txtTabaghebandiCode.Text + txtCode.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            int _Code = Convert.ToInt32(txtTabaghebandiCode.Text + txtCode.Text);
                            int _SalId = Convert.ToInt32(lblSalId.Text);
                            var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit.ToString();
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

            //////////////// اعتبار سنجی تکس باکس و کمبوباکس ها///////////////////////////////

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0")
            {
                XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabGroups.Any())
                            {
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Name == txtName.Text && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            int _SalId = Convert.ToInt32(lblSalId.Text);
                            var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Name == txtName.Text && s.SalId == _SalId);
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

            if (En == EnumCED.Create)
            {
                if (cmbNoeHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً نوع حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void FrmHesabGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnDisplyNotActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }
        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            btnNewCode.Enabled = txtCode.Enabled = chkEditCode.Checked ? true : false;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView1);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView1);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView1);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Visible)
            {
                HelpClass1.PrintPreview(gridControl1, gridView1);

            }
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridHesabGroup();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabGroup();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Visible)
            {
                En = EnumCED.Create;
                gridControl1.Enabled = false;
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1);
                HelpClass1.ActiveControls(panelControl1);
                // txtCode.ReadOnly = true;
                // xtraTabControl1.SelectedTabPageIndex = 0;
                //btnNewCode_Click(null, null);
                //txtName.Focus();
                FillcmbTabaghebandiHesabha();
                cmbTabaghebandiHesabha.Focus();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                //var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q8 != null)
                                {
                                    //db.EpHesabGroups.Remove(q);
                                    db.EpAllCodingHesabdaris.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();


                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                    HelpClass1.ClearControls(panelControl1);
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این حساب گروه مقدور نیست \n" +
                                    " جهت حذف این حساب در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
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
        }

        public int EditRowIndex = 0;
        int CodeBeforeEdit = 0;
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        int TabaghebandiHesabhaIdBeforeEdit = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    gridControl1.Enabled = false;
                    EditRowIndex = gridView1.FocusedRowHandle;
                    En = EnumCED.Edit;
                    HelpClass1.InActiveButtons(panelControl2);
                    HelpClass1.ActiveControls(panelControl1);
                    //IndexCmbStandardGroupBeforeEdit = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexGroupStandard"));
                    //NameBeforeEdit = gridView1.GetFocusedRowCellValue("Name").ToString();
                    FillcmbTabaghebandiHesabha();

                    cmbTabaghebandiHesabha.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghebandiHesabhaId").ToString());
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(1);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                    CodeBeforeEdit = Convert.ToInt32(txtTabaghebandiCode.Text + txtCode.Text);
                    NameBeforeEdit = txtName.Text;
                    TabaghebandiHesabhaIdBeforeEdit = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    cmbTabaghebandiHesabha.Focus();
                    //if (txtCode.Text == "9")
                    //    btnNewCode.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (TextEditValidation())
                {
                    if (En == EnumCED.Create)
                    {
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int _Code = Convert.ToInt32(txtTabaghebandiCode.Text + txtCode.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                string _Name = txtName.Text;
                                bool _IsActive = chkIsActive.Checked;
                                int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);

                                EpHesabGroup obj = new EpHesabGroup();
                                obj.SalId = Convert.ToInt32(lblSalId.Text);
                                obj.Code = _Code;
                                obj.Name = _Name;
                                obj.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                obj.TabaghebandiHesabhaName = cmbTabaghebandiHesabha.Text;
                                obj.IsActive = _IsActive;
                                obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                obj.NoeHesab = cmbNoeHesab.Text;
                                obj.SharhHesab = txtSharhHesab.Text;
                                //db.EpHesabGroups.Add(obj);
                                //db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                //var q = db.EpHesabGroups.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                ////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                n1.SalId = Convert.ToInt32(lblSalId.Text);
                                n1.KeyId = _Code;
                                n1.ParentId = Convert.ToInt32(txtTabaghebandiCode.Text);
                                n1.LevelName = _Name;
                                n1.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                n1.IsActive = _IsActive;
                                n1.EpHesabGroup1 = obj;

                                db.EpAllCodingHesabdaris.Add(n1);
                                /////////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                btnLast_Click(null, null);
                                btnCancel_Click(null, null);
                                En = EnumCED.Save;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (En == EnumCED.Edit)
                    {
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int _Code = Convert.ToInt32(txtTabaghebandiCode.Text + txtCode.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                string _Name = txtName.Text;
                                bool _IsActive = chkIsActive.Checked;
                                int RowId = Convert.ToInt32(txtId.Text);
                                int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);

                                var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q != null)
                                {
                                    q.Code = _Code;
                                    q.Name = _Name;
                                    q.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                    q.TabaghebandiHesabhaName = cmbTabaghebandiHesabha.Text;
                                    q.IsActive = _IsActive;
                                    q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                    q.NoeHesab = cmbNoeHesab.Text;
                                    q.SharhHesab = txtSharhHesab.Text;

                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyId = _Code;
                                        q2.ParentId = Convert.ToInt32(txtTabaghebandiCode.Text);
                                        q2.LevelName = _Name;
                                        q2.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                        q2.IsActive = _IsActive;
                                        q2.EpHesabGroup1 = q;

                                        var q3 = db.EpAllCodingHesabdaris.Where(s => s.HesabGroupId == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            q3.ForEach(item =>
                                            {
                                                if (TabaghebandiHesabhaIdBeforeEdit != _TabaghebandiHesabhaId)
                                                    item.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;

                                                if (CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 3).Replace(item.KeyId.ToString().Substring(0, 3), _Code.ToString())
                                                    + item.KeyId.ToString().Substring(3));

                                                    item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 1).Replace(item.ParentId.ToString().Substring(0, 1), txtTabaghebandiCode.Text)
                                                        + item.ParentId.ToString().Substring(1));
                                                }

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            });

                                        }
                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////


                                        /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                        var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId && s.SalId == _SalId).ToList();
                                        if (q5.Count > 0)
                                        {
                                            q5.ForEach(item =>
                                            {
                                                if (TabaghebandiHesabhaIdBeforeEdit != _TabaghebandiHesabhaId)
                                                {
                                                    item.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                                    item.TabaghebandiHesabhaName = cmbTabaghebandiHesabha.Text;
                                                }
                                                if (CodeBeforeEdit != _Code)
                                                    item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 3).Replace(item.Code.ToString().Substring(0, 3), _Code.ToString())
                                                        + item.Code.ToString().Substring(3));
                                                if (NameBeforeEdit != txtName.Text)
                                                    item.GroupName = txtName.Text;
                                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                    item.IsActive = chkIsActive.Checked;
                                            });
                                        }
                                        ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                        var q6 = db.EpHesabMoins.Where(s => s.GroupId == RowId && s.SalId == _SalId).ToList();
                                        if (q6.Count > 0)
                                        {
                                            q6.ForEach(item =>
                                            {
                                                if (TabaghebandiHesabhaIdBeforeEdit != _TabaghebandiHesabhaId)
                                                {
                                                    item.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                                    item.TabaghebandiHesabhaName = cmbTabaghebandiHesabha.Text;
                                                }
                                                if (CodeBeforeEdit != _Code)
                                                    item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 3).Replace(item.Code.ToString().Substring(0, 3), _Code.ToString())
                                                        + item.Code.ToString().Substring(3));
                                                if (NameBeforeEdit != txtName.Text)
                                                    item.GroupName = txtName.Text;
                                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                    item.IsActive = chkIsActive.Checked;
                                            });
                                        }
                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabGroupId == RowId && s.SalId == _SalId).ToList();
                                        if (q9.Count > 0)
                                        {
                                            q9.ForEach(item =>
                                            {
                                                if (TabaghebandiHesabhaIdBeforeEdit != _TabaghebandiHesabhaId)
                                                {
                                                    item.TabaghebandiHesabhaId = _TabaghebandiHesabhaId;
                                                }
                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 3).Replace(item.KeyId.ToString().Substring(0, 3), _Code.ToString())
                                                            + item.KeyId.ToString().Substring(3));
                                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                    item.IsActive = chkIsActive.Checked;
                                            });
                                        }
                                        /////////////////////////////////////////////////////////////////////////////////////////////

                                        db.SaveChanges();
                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView1.RowCount > 0)
                                            gridView1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
                                        En = EnumCED.Save;
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
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            if (btnSaveNext.Enabled)
            {
                //gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
                btnSave_Click(null, null);
                if (En == EnumCED.Save)
                    btnCreate_Click(null, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled)
            {
                gridControl1.Enabled = true;
                En = EnumCED.Cancel;
                HelpClass1.ActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1);
                HelpClass1.InActiveControls(panelControl1);
                btnCreate.Focus();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void cmbNoeHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeHesab.ShowPopup();
            }

        }

        private void cmbNoeHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoeHesab.Text = (cmbNoeHesab.SelectedIndex == 0 || cmbNoeHesab.SelectedIndex == 2) ? "دائم" : "موقت";

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView1_RowCellClick(null, null);

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                FillcmbTabaghebandiHesabha();
                cmbTabaghebandiHesabha.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghebandiHesabhaId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();                      
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(1);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
            }


        }

        private void cmbTabaghebandiHesabha_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghebandiHesabhaId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtTabaghebandiCode.Text = q.Code.ToString();
                        btnNewCode_Click(null, null);
                        cmbNoeHesab.SelectedIndex = q.IndexNoeHesab;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbTabaghebandiHesabha_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbTabaghebandiHesabha.ShowPopup();
            }

        }
    }
}