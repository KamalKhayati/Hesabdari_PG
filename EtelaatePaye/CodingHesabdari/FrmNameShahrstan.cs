/****************************** Ghost.github.io ******************************\
*	Module Name:	btnNameShahrstan.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 13   09:40 ق.ظ
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
using DBHesabdari_TG;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmNameShahrstan : DevExpress.XtraEditors.XtraForm
    {
        FrmEtelaateAshkhas Fm;
        public FrmNameShahrstan(FrmEtelaateAshkhas fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public void FillDataGridNameShahrstan()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    var q1 = dataContext.EpNameShahrstans.ToList();
                    if (q1.Count > 0)
                        epNameShahrstansBindingSource.DataSource = q1;
                    else
                        epNameShahrstansBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameOstan()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpNameOstans.Any())
                    {
                        db.EpNameOstans.Load();
                        epNameOstansBindingSource.DataSource = db.EpNameOstans.Local.ToBindingList();
                    }
                    else
                    {
                        epNameOstansBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmNameShahrstan_Load(object sender, EventArgs e)
        {
            FillDataGridNameShahrstan();
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
            ////////////////// اعتبار سنجی تکس باکس ////////////

            if (string.IsNullOrEmpty(cmbNameOstan.Text))
            {
                XtraMessageBox.Show("لطفاً نام استان را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0")
            {
                XtraMessageBox.Show("لطفاً نام شهرستان را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.EpNameShahrstans.Any())
                            {
                                var q1 = db.EpNameShahrstans.FirstOrDefault(p => p.Name == txtName.Text);
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
                            var q1 = db.EpNameShahrstans.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
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

        private void FrmNameShahrstan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreate_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3 && btnDelete.Enabled == true)
            {
                btnDelete_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F4 && btnEdit.Enabled == true)
            {
                btnEdit_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F5 && btnSave.Enabled == true)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6 && btnCancel.Enabled == true)
            {
                btnCancel_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

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

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            FillDataGridNameShahrstan();
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
            cmbNameOstan.EditValue = 0;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        public void ActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbNameOstan.ReadOnly = false;
                txtName.ReadOnly = false;
            }
        }

        public void InActiveControls()
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                cmbNameOstan.ReadOnly = true;
                txtName.ReadOnly = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            InActiveButtons();
            ClearControls();
            ActiveControls();
            FillcmbNameOstan();
            cmbNameOstan.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("آیا ردیف جاری حذف شود؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EditRowIndex = gridView1.FocusedRowHandle;
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                            var q = db.EpNameShahrstans.FirstOrDefault(p => p.Id == RowId);
                            //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                            if (q != null /*&& q8 != null*/)
                            {
                                db.EpNameShahrstans.Remove(q);
                                //db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                btnDisplyActiveList_Click(null, null);
                                // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات حذف با خطا مواجه شد \n حذف این ردیف مقدور نیست \n" +
                                " جهت حذف ردیف مورد نظر در ابتدا بایستی زیر مجموعه های این ردیف در قسمت آدرس اشخاص حذف شود" +
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
                FillcmbNameOstan();

                cmbNameOstan.EditValue = Convert.ToUInt32(gridView1.GetFocusedRowCellValue("NameOstanId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();

                ActiveControls();
                cmbNameOstan.Focus();
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
                            EpNameShahrstan obj = new EpNameShahrstan();
                            obj.Name = txtName.Text;
                            obj.NameOstan = cmbNameOstan.Text;
                            obj.NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue) ;

                            db.EpNameShahrstans.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                            //var q = db.EpAdressNames.FirstOrDefault(s => s.Code == _Code);
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
                            btnDisplyActiveList_Click(null, null);

                            //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
                            string _Name = txtName.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpNameShahrstans.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Name = txtName.Text;
                                q.NameOstan = cmbNameOstan.Text;
                                q.NameOstanId = Convert.ToInt32(cmbNameOstan.EditValue);

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
                                btnDisplyActiveList_Click(null, null);

                                //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void FrmNameShahrstan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fm.FillcmbNameOstan();
            Fm.FillcmbNameShahrstan();
        }

        private void btnOstan_Click(object sender, EventArgs e)
        {
            FrmNameOstan fm = new FrmNameOstan(this);
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.IsActiveFrmNameSharstan = true;
            fm.ShowDialog();
        }
    }
}