/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabTafsiliAshkhas.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 7   11:22 ق.ظ
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
    public partial class FrmHesabTafsiliAshkhas : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabTafsiliAshkhas()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;
        public void FillDataGridTafsiliAshkhas()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpHesabTafsiliAshkhass.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabTafsiliAshkhassBindingSource.DataSource = q1;
                            else
                                epHesabTafsiliAshkhassBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBEpAllCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            EpHesabTafsiliAshkhassBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            EpHesabTafsiliAshkhassBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        EpHesabTafsiliAshkhassBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabTafsiliAshkhass.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epHesabTafsiliAshkhassBindingSource.DataSource = q;
                            else
                                epHesabTafsiliAshkhassBindingSource.DataSource = null;
                        }
                        else
                            epHesabTafsiliAshkhassBindingSource.DataSource = null;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbGroupTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafsiliLevel1s.Any())
                    {
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true && s.Id == 20 || s.Id == 25 || s.Id == 30 || s.Id == 35 || s.Id == 40).Load();
                            epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.Id == 20 || s.Id == 25 || s.Id == 30 || s.Id == 35 || s.Id == 40).Load();
                            epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
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
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 20 && s.SalId == _SalId).ToList();
                    var q1 = db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 25 && s.SalId == _SalId).ToList();
                    var q2 = db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 30 && s.SalId == _SalId).ToList();
                    var q3 = db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 35 && s.SalId == _SalId).ToList();
                    var q4 = db.EpHesabTafsiliAshkhass.Where(s => s.GroupTafsiliId == 40 && s.SalId == _SalId).ToList();
                    if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 20)
                    {
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(2) != "99999")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 100000 حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 100000 حساب تفضیلی برای هر گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 100000 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = "00001";
                        }
                    }
                    else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 25)
                    {
                        if (q1.Count > 0)
                        {
                            var MaximumCod = q1.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(2) != "99999")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                                btnNewCode.Enabled = true;
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 100000 حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 100000 حساب تفضیلی برای هر گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 100000 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnNewCode.Enabled = false;
                            }
                        }
                        else
                        {
                            txtCode.Text = "00001";
                        }
                    }
                    else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 30)
                    {
                        if (q1.Count > 0)
                        {
                            var MaximumCod = q1.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(2) != "99999")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                                btnNewCode.Enabled = true;
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 100000 حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 100000 حساب تفضیلی برای هر گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 100000 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnNewCode.Enabled = false;
                            }
                        }
                        else
                        {
                            txtCode.Text = "00001";
                        }
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
        bool IsActiveBeforeEdit = true;
        private void FrmHesabTafsiliAshkhas_Load(object sender, EventArgs e)
        {
            FillDataGridTafsiliAshkhas();
            //if (lblUserId.Text == "1")
            //{
            //    chkIsActive.Visible = true;
            //    labelControl6.Visible = true;
            //}
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
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtCodeGroupTafsili.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 999999)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 1000000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabTafsiliAshkhass.Any())
                            {
                                var q1 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
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
                            var q1 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
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
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.EpHesabTafsiliAshkhass.Any())
                            {
                                var q1 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Name == txtName.Text && s.SalId == _SalId);
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
                            var q1 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id != RowId && s.Name == txtName.Text && s.SalId == _SalId);
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

        private void FrmHesabTafsiliAshkhas_KeyDown(object sender, KeyEventArgs e)
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
            FillDataGridTafsiliAshkhas();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridTafsiliAshkhas();
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
                HelpClass1.ClearControls(panelControl6);
                HelpClass1.ActiveControls(panelControl1);
                FillcmbGroupTafsili();
                cmbListGroupTafsili.Focus();
            }
            //btnNewCode_Click(null, null);
            //cmbListGroupTafsili.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب تفضیلی مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpAllHesabTafsilis.FirstOrDefault(p => p.SalId == _SalId && p.Id == RowId);
                                //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(p => p.Id == RowId );
                                //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                if (q != null /*&& q8 != null*/)
                                {
                                    db.EpAllHesabTafsilis.Remove(q);
                                    //db.EpAllCodingHesabdaris.Remove(q8);
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
                                    HelpClass1.ClearControls(panelControl6);
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این حساب تفضیلی مقدور نیست \n" +
                                    " زیرا با حساب تفضیلی فوق سند صادر گردیده", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    HelpClass1.ActiveControls(panelControl1);
                    //HelpClass1.ActiveControls(panelControl6);
                    FillcmbGroupTafsili();

                    cmbListGroupTafsili.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupTafsiliId")); ;
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCodeGroupTafsili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    txtTarikhEjad.Text = gridView1.GetFocusedRowCellValue("TarikhEjad") != null ? gridView1.GetFocusedRowCellValue("TarikhEjad").ToString().Substring(0, 10) : "";
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                    chkPersonel.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsPersonel"));
                    chkSahamdar.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsSahamdar"));
                    chkVizitor.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsVizitor"));
                    chkRanande.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsRanande"));

                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtName.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    //if (txtCode.Text == "99999")
                    //    btnNewCode.Enabled = false;
                    cmbListGroupTafsili.Focus();
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
                                EpHesabTafsiliAshkhas obj = new EpHesabTafsiliAshkhas();
                                obj.SalId = Convert.ToInt32(lblSalId.Text);
                                obj.Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                                obj.Name = txtName.Text;
                                if (!string.IsNullOrEmpty(txtTarikhEjad.Text))
                                    obj.TarikhEjad = Convert.ToDateTime(txtTarikhEjad.Text);
                                obj.IsActive = chkIsActive.Checked;
                                obj.SharhHesab = txtSharhHesab.Text;
                                obj.GroupTafsiliName = cmbListGroupTafsili.Text;
                                obj.GroupTafsiliId = Convert.ToInt32(cmbListGroupTafsili.EditValue);
                                obj.IsPersonel = chkPersonel.Checked;
                                obj.IsSahamdar = chkSahamdar.Checked;
                                obj.IsVizitor = chkVizitor.Checked;
                                obj.IsRanande = chkRanande.Checked;

                                //////////////////////////////////////////////////////////////

                                EpAllHesabTafsili obj1 = new EpAllHesabTafsili();
                                obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                obj1.Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                                obj1.Name = txtName.Text;
                                obj1.GroupTafsiliId = Convert.ToInt32(cmbListGroupTafsili.EditValue); ;
                                obj1.IsActive = chkIsActive.Checked;
                                obj1.SharhHesab = txtSharhHesab.Text;
                                obj1.EpHesabTafsiliAshkhas1 = obj;
                                db.EpAllHesabTafsilis.Add(obj1);
                                db.SaveChanges();

                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
                                //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                //n1.KeyId = _Code;
                                //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //n1.LevelName = txtName.Text;
                                //n1.HesabGroupId = q.GroupId;
                                //n1.HesabColId = q.Id;
                                //n1.IsActive = chkIsActive.Checked;
                                //db.EpAllCodingHesabdaris.Add(n1);
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //db.SaveChanges();
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);

                                if (XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد" + "\n" + "آیا مایلید اطلاعات بیشتری برای این حساب تفضیلی تعریف کنید ؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
                                    //fm.MdiParent = this;
                                    fm.lblUserId.Text = lblUserId.Text;
                                    fm.lblUserName.Text = lblUserName.Text;
                                    fm.lblSalId.Text = lblSalId.Text;
                                    fm.lblSalMali.Text = lblSalMali.Text;
                                    // ActiveForm(fm);
                                    fm.cmbGroupTafsili.EditValue = Convert.ToInt32(cmbListGroupTafsili.EditValue);
                                    int _Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                                    int _SalId = Convert.ToInt32(lblSalId.Text);
                                    var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q != null)
                                        fm.cmbTafsiliAshkhas.EditValue = q.Id;
                                    fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
                                    fm.ShowDialog();
                                }

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
                                int _Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                                string _Name = txtName.Text;
                                int RowId = Convert.ToInt32(txtId.Text);
                                int _SalId = Convert.ToInt32(lblSalId.Text);
                                var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q != null)
                                {
                                    q.Code = Convert.ToInt32(txtCodeGroupTafsili.Text + txtCode.Text);
                                    q.Name = txtName.Text;
                                    if (!string.IsNullOrEmpty(txtTarikhEjad.Text))
                                        q.TarikhEjad = Convert.ToDateTime(txtTarikhEjad.Text);
                                    q.IsActive = chkIsActive.Checked;
                                    q.SharhHesab = txtSharhHesab.Text;
                                    q.GroupTafsiliName = cmbListGroupTafsili.Text;
                                    q.GroupTafsiliId = Convert.ToInt32(cmbListGroupTafsili.EditValue);
                                    q.IsPersonel = chkPersonel.Checked;
                                    q.IsSahamdar = chkSahamdar.Checked;
                                    q.IsVizitor = chkVizitor.Checked;
                                    q.IsRanande = chkRanande.Checked;

                                    //////////////////////////////////////////////////////////////////////////
                                    ///
                                    var q1 = db.EpAllHesabTafsilis.FirstOrDefault(f => f.SalId == _SalId && f.Id == RowId);
                                    if (q1 != null)
                                    {
                                        q1.Code = _Code;
                                        q1.Name = txtName.Text;
                                        q1.GroupTafsiliId = Convert.ToInt32(cmbListGroupTafsili.EditValue);
                                        q1.IsActive = chkIsActive.Checked;
                                        //q1.IsDefault = chkIsDefault.Checked;
                                        q1.SharhHesab = txtSharhHesab.Text;
                                    }
                                    db.SaveChanges();

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
                                    //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //var q9 = db.RmsUserBEpAllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //    var a1 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var a2 = db.EpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    //    var b1 = db.RmsUserBEpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var b2 = db.RmsUserBEpAllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
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

                                    //db.SaveChanges();
                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد" + "\n" + "آیا مایلید اطلاعات دیگری برای این حساب تفضیلی تعریف کنید ؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
                                        //fm.MdiParent = this;
                                        fm.lblUserId.Text = lblUserId.Text;
                                        fm.lblUserName.Text = lblUserName.Text;
                                        fm.lblSalId.Text = lblSalId.Text;
                                        fm.lblSalMali.Text = lblSalMali.Text;
                                        // ActiveForm(fm);
                                        fm.cmbGroupTafsili.EditValue = Convert.ToInt32(cmbListGroupTafsili.EditValue);
                                        fm.cmbTafsiliAshkhas.EditValue = Convert.ToInt32(txtId.Text);
                                        fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
                                        fm.ShowDialog();
                                    }

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
                En = EnumCED.Cancel;
                HelpClass1.ActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1);
                HelpClass1.ClearControls(panelControl6);
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
            // gridView1_RowClick(null, null);
        }

        private void cmbListGroupTafsili_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 20)
            {
                txtCodeGroupTafsili.Text = "20";
                btnNewCode_Click(null, null);
                chkPersonel.Enabled = chkPersonel.Checked = false;
                chkSahamdar.Enabled = chkSahamdar.Checked = false;
            }
            else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 25)
            {
                txtCodeGroupTafsili.Text = "25";
                btnNewCode_Click(null, null);
                chkPersonel.Enabled = chkPersonel.Checked = false;
                chkSahamdar.Enabled = chkSahamdar.Checked = false;
            }
            else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 30)
            {
                txtCodeGroupTafsili.Text = "30";
                btnNewCode_Click(null, null);
                chkPersonel.Enabled = chkPersonel.Checked = false;
                chkSahamdar.Enabled = chkSahamdar.Checked = false;
            }
            else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 35)
            {
                txtCodeGroupTafsili.Text = "35";
                btnNewCode_Click(null, null);
                chkPersonel.Enabled = chkPersonel.Checked = true;
                chkSahamdar.Enabled = true;
                chkSahamdar.Checked = false;
            }
            else if (Convert.ToInt32(cmbListGroupTafsili.EditValue) == 40)
            {
                txtCodeGroupTafsili.Text = "40";
                btnNewCode_Click(null, null);
                chkPersonel.Enabled = true;
                chkPersonel.Checked = false;
                chkSahamdar.Enabled = chkSahamdar.Checked = true;
            }

        }

        private void cmbListGroupTafsili_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListGroupTafsili.ShowPopup();
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

        private void btnJoziatAshkhas_Click(object sender, EventArgs e)
        {
            FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            // ActiveForm(fm);
            fm.cmbGroupTafsili.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupTafsiliId"));
            fm.cmbTafsiliAshkhas.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
            fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
            fm.ShowDialog();

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                FillcmbGroupTafsili();

                cmbListGroupTafsili.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupTafsiliId"));
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCodeGroupTafsili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                txtTarikhEjad.Text = gridView1.GetFocusedRowCellValue("TarikhEjad") != null ? gridView1.GetFocusedRowCellValue("TarikhEjad").ToString().Substring(0, 10) : "";
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                chkPersonel.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsPersonel"));
                chkSahamdar.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsSahamdar"));
                chkVizitor.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsVizitor"));
                chkRanande.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsRanande"));
            }

        }
    }
}