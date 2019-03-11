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
using System.Data.Entity;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabTafziliSandogh : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabTafziliSandogh()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;
        public void FillDataGridTafziliSandogh()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabTafziliSandoghs.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabTafziliSandoghsBindingSource.DataSource = q1;
                            else
                                epHesabTafziliSandoghsBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabTafziliSandoghs.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            epHesabTafziliSandoghsBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epHesabTafziliSandoghsBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epHesabTafziliSandoghsBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabTafziliSandoghs.Where(p => p.IsActive == false).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                epHesabTafziliSandoghsBindingSource.DataSource = q.ToList();
                            else
                                epHesabTafziliSandoghsBindingSource.DataSource = null;
                        }
                        else
                            epHesabTafziliSandoghsBindingSource.DataSource = null;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbGroupTafzili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafzilis.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafzilis.Where(s => s.IsActive == true).Load();
                            epGroupTafzilisBindingSource.DataSource = db.EpGroupTafzilis.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafzilis.Load();
                            epGroupTafzilisBindingSource.DataSource = db.EpGroupTafzilis.Local.ToBindingList();
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
                    var q = db.EpHesabTafziliSandoghs.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString().Substring(2) != "99999")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                            btnNewCode.Enabled = true;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 99999 حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از 99999 حساب تفضیلی برای هر گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 1 تا 99999 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnNewCode.Enabled = false;
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
        bool IsActiveBeforeEdit=true;
        private void FrmHesabTafziliSandogh_Load(object sender, EventArgs e)
        {
            FillDataGridTafziliSandogh();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl6.Visible = true;
            }
            //labelControl1.Text = "کد صندوق";
            //labelControl2.Text = "نام صندوق";
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
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtCodeGroupTafzili.Text))
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
                        int _Code = Convert.ToInt32(txtCodeGroupTafzili.Text + txtCode.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabTafziliSandoghs.Any())
                            {
                                var q1 = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Code == _Code);
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
                        if (En == EnumCED.Create)
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
                        else if (En == EnumCED.Edit)
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

        private void FrmHesabTafziliSandogh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled==true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null );
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null );
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnDisplyNotActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnSharhHesab_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnAdvancedSearch_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12 && btnPrint.Enabled == true)
            {
                btnPrint_Click(sender, null);
            }
            else if (e.Alt && e.KeyCode == Keys.N && btnNewCode.Enabled == true)
            {
                btnNewCode_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = chkEditCode.Checked ? false : true;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            gridView1.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            gridView1.MoveNext();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            gridView1.MovePrev();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            gridView1.MoveFirst();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridTafziliSandogh();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridTafziliSandogh();
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

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        private void btnSharhHesab_Click(object sender, EventArgs e)
        {
            gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
        }

        public void InActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = false;
                }
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = true;
            }
        }

        public void ActiveButtons()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                foreach (SimpleButton item in panelControl2.Controls)
                {
                    item.Enabled = true;
                }
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        public void ClearControls()
        {
            cmbListGroupTafzili.EditValue = 0;
            txtCodeGroupTafzili.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNameMasol.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtSharhHesab.Text = string.Empty;
            epGroupTafzilisBindingSource.DataSource = null;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnNewCode.Enabled = true;
                chkEditCode.ReadOnly = false;
                txtName.ReadOnly = false;
                txtNameMasol.ReadOnly = false;
                txtStartDate.ReadOnly = false;
                chkIsActive.ReadOnly = false;
                txtSharhHesab.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnNewCode.Enabled = false;
                chkEditCode.ReadOnly = true;
                txtName.ReadOnly = true;
                txtNameMasol.ReadOnly = true;
                txtStartDate.ReadOnly = true;
                chkIsActive.ReadOnly = true;
                txtSharhHesab.ReadOnly = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            FillcmbGroupTafzili();
            cmbListGroupTafzili.EditValue = 1;
            txtCodeGroupTafzili.Text = "10";
            ActiveControls();
            btnNewCode_Click(null, null);
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا حساب تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.EpHesabTafziliSandoghs.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.EpHesabTafziliSandoghs.Remove(q);
                                //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این حساب تفضیلی مقدور نیست \n" +
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

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                InActiveButtons();
                FillcmbGroupTafzili();

                cmbListGroupTafzili.EditValue = 1;
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCodeGroupTafzili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                txtNameMasol.Text = gridView1.GetFocusedRowCellValue("NameMasol").ToString();
                txtStartDate.EditValue = gridView1.GetFocusedRowCellValue("StartDate").ToString().Substring(0, 10);
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                ActiveControls();
                if (txtCode.Text == "99999")
                    btnNewCode.Enabled = false;
                txtName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                if (En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            EpHesabTafziliSandogh obj = new EpHesabTafziliSandogh();
                            obj.Code = Convert.ToInt32(txtCodeGroupTafzili.Text + txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.NameMasol = txtNameMasol.Text;
                            obj.StartDate = Convert.ToDateTime(txtStartDate.Text);
                            obj.IsActive = chkIsActive.Checked;
                            obj.SharhHesab = txtSharhHesab.Text;
                            obj.GroupTafziliId = Convert.ToInt32(cmbListGroupTafzili.EditValue);

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
                                btnDisplyActiveList_Click(null, null);
                            else
                                btnDisplyNotActiveList_Click(null, null);

                            XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            gridView1.MoveLast();
                            ActiveButtons();
                            ClearControls();
                            InActiveControls();
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
                            int _Code = Convert.ToInt32(txtCodeGroupTafzili.Text + txtCode.Text);
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
                                q.GroupTafziliId = Convert.ToInt32(cmbListGroupTafzili.EditValue);

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
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex;
                                gridControl1.Enabled = true;
                                ActiveButtons();
                                ClearControls();
                                InActiveControls();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            ActiveButtons();
            ClearControls();
            InActiveControls();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }
    }
}