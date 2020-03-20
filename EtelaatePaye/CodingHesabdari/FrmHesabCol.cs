/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabCol.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 4   12:48 ق.ظ
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
using DBHesabdari_PG;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabCol : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabCol()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridHesabCol()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabCols.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabColsBindingSource.DataSource = q1;
                            else
                                epHesabColsBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId == 0 && s.IsActive == true).Select(s => s.HesabColId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabCols.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            epHesabColsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabColsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabColsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabCols.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epHesabColsBindingSource.DataSource = q;
                            else
                                epHesabColsBindingSource.DataSource = null;
                        }
                        else
                            epHesabColsBindingSource.DataSource = null;
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
                    if (db.EpTabaghebandiHesabhas.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (IsActiveList == true)
                        {
                            db.EpTabaghebandiHesabhas.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epTabaghebandiHesabhasBindingSource.DataSource = db.EpTabaghebandiHesabhas.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpTabaghebandiHesabhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epTabaghebandiHesabhasBindingSource.DataSource = db.EpTabaghebandiHesabhas.Local.ToBindingList();
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
        public void FillcmbHesabGroup()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);

                        if (IsActiveList == true)
                        {
                            db.EpHesabGroups.Where(s => s.IsActive == true && s.TabaghebandiHesabhaId == _TabaghebandiHesabhaId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabGroups.Where(s => s.TabaghebandiHesabhaId == _TabaghebandiHesabhaId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
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
            if (cmbListHesabGroup.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _TabaghebandiHesabhaId = Convert.ToInt32(cmbTabaghebandiHesabha.EditValue);
                        int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                        int _SalId = Convert.ToInt32(lblSalId.Text);

                        var q = db.EpHesabCols.Where(s => s.GroupId == _GroupId && s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString().Substring(3) != "99")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(3);
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                {
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 100 حساب کل برای هر حساب گروه ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 100 حساب کل برای هر حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 100 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
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

        }

        int GroupIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        private void FrmHesabCol_Load(object sender, EventArgs e)
        {
            FillDataGridHesabCol();
            btnCreate.Focus();
            //if (lblUserId.Text == "1")
            //{
            //    chkIsActive.Visible = true;
            //    labelControl6.Visible = true;
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
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text))
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
                            if (db.EpHesabCols.Any())
                            {
                                int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q1 = db.EpHesabCols.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
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
                            int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                            int _SalId = Convert.ToInt32(lblSalId.Text);
                            var q1 = db.EpHesabCols.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
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
                            if (db.EpHesabCols.Any())
                            {
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q1 = db.EpHesabCols.FirstOrDefault(s => s.Name == txtName.Text && s.SalId == _SalId);
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
                            var q1 = db.EpHesabCols.FirstOrDefault(s => s.Id != RowId && s.Name == txtName.Text && s.SalId == _SalId);
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
                if (cmbMahiatHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void FrmHesabCol_KeyDown(object sender, KeyEventArgs e)
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
                HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridHesabCol();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridHesabCol();
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
                FillcmbHesabGroup();
                cmbListHesabGroup.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب کل انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q = db.EpHesabCols.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                var q8 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId && s.SalId == _SalId);
                                if (q != null && q8 != null)
                                {
                                    db.EpHesabCols.Remove(q);
                                    db.AllCodingHesabdaris.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();


                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);
                                    //XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                    HelpClass1.ClearControls(panelControl1);
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این حساب کل مقدور نیست \n" +
                                    " جهت حذف حساب کل در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
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
                    FillcmbHesabGroup();

                    cmbListHesabGroup.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupId").ToString());
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbMahiatHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtName.Text;
                    GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup.EditValue);
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    HelpClass1.ActiveControls(panelControl1);
                    cmbListHesabGroup.Focus();
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
                                EpHesabCol obj = new EpHesabCol();
                                obj.SalId = Convert.ToInt32(lblSalId.Text);
                                obj.Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                obj.Name = txtName.Text;
                                obj.IsActive = chkIsActive.Checked;
                                obj.GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                obj.GroupName = cmbListHesabGroup.Text;
                                obj.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                obj.MahiatHesab = cmbMahiatHesab.Text;
                                obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                obj.NoeHesab = cmbNoeHesab.Text;
                                obj.SharhHesab = txtSharhHesab.Text;

                                db.EpHesabCols.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                int _code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                var q = db.EpHesabCols.FirstOrDefault(s => s.Code == _code && s.SalId == _SalId);
                                ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                AllCodingHesabdari n1 = new AllCodingHesabdari();
                                n1.SalId = Convert.ToInt32(lblSalId.Text);
                                n1.KeyId = _code;
                                n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                n1.LevelName = txtName.Text;
                                n1.HesabGroupId = q.GroupId;
                                n1.HesabColId = q.Id;
                                n1.IsActive = chkIsActive.Checked;
                                db.AllCodingHesabdaris.Add(n1);
                                /////////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                               // XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
                                int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                int _Code = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                string _GroupName = cmbListHesabGroup.Text;
                                string _Name = txtName.Text;
                                int RowId = Convert.ToInt32(txtId.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q = db.EpHesabCols.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q != null)
                                {
                                    q.Code = _Code;
                                    q.Name = _Name;
                                    q.GroupId = _GroupId;
                                    q.GroupName = _GroupName;
                                    q.IsActive = chkIsActive.Checked;
                                    q.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                    q.MahiatHesab = cmbMahiatHesab.Text;
                                    q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                    q.NoeHesab = cmbNoeHesab.Text;
                                    q.SharhHesab = txtSharhHesab.Text;

                                    ///////////////////////////////متد اصلاح کد و نام در لیست حساب معین WillCascadeOnUpdate ///////////////////////

                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpHesabMoins.Where(s => s.ColId == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        q6.ForEach(item =>
                                        {
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 4).Replace(item.Code.ToString().Substring(0, 4), _Code.ToString())
                                                    + item.Code.ToString().Substring(4));
                                            if (NameBeforeEdit != txtName.Text)
                                                item.ColName = txtName.Text;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        });
                                    }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q8 = db.AllCodingHesabdaris.Where(s => s.HesabColId == RowId && s.SalId == _SalId).ToList();
                                    if (q8.Count > 0)
                                    {
                                        q8.ForEach(item =>
                                        {
                                            if (item.HesabMoinId == 0)
                                            {
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                    item.KeyId = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                    item.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                                if (NameBeforeEdit != txtName.Text)
                                                    item.LevelName = txtName.Text;
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                    item.HesabGroupId = _GroupId;
                                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                    item.IsActive = chkIsActive.Checked;
                                            }
                                            else
                                            {
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                    item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 4).Replace(item.KeyId.ToString().Substring(0, 4), _Code.ToString())
                                                    + item.KeyId.ToString().Substring(4));
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                    item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 4).Replace(item.ParentId.ToString().Substring(0, 4), _Code.ToString())
                                                    + item.ParentId.ToString().Substring(4));
                                                if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                    item.HesabGroupId = _GroupId;
                                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                    item.IsActive = chkIsActive.Checked;
                                            }
                                        });
                                    }
                                    /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                    var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
                                    if (q9.Count > 0)
                                    {
                                        q9.ForEach(item =>
                                        {
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 4).Replace(item.KeyId.ToString().Substring(0, 4), _Code.ToString())
                                                + item.KeyId.ToString().Substring(4));
                                            if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                                item.HesabGroupId = _GroupId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        });
                                    }
                                    //////////////////////////////////////////////////////////////////////////////////////
                                    if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                    {
                                        var m = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId);
                                        var a1 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == _GroupId && s.HesabColId == 0 && s.SalId == _SalId);
                                        //var a2 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == _GroupId && s.HesabColId == RowId && s.HesabMoinId == 0);
                                        var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == _GroupId && s.HesabColId == 0 && s.SalId == _SalId);
                                        //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == _GroupId && s.HesabColId == RowId && s.HesabMoinId == 0);
                                        if (m != null)
                                            m.IsActive = true;
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
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                  //  XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex;
                                    btnCancel_Click(null, null);
                                    En = EnumCED.Save;
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

        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListHesabGroup.ShowPopup();
            }
        }

        private void cmbMahiatHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbMahiatHesab.ShowPopup();
            }

        }

        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtGroupCode.Text = q.Code.ToString();
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
                FillcmbHesabGroup();

                cmbListHesabGroup.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbMahiatHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

            }


        }

        private void cmbNoeHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoeHesab.Text = (cmbNoeHesab.SelectedIndex == 0 || cmbNoeHesab.SelectedIndex == 2) ? "دائم" : "موقت";
        }
    }
}