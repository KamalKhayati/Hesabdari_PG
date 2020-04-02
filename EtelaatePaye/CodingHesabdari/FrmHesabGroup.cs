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
                    btnDelete.Enabled = btnEdit.Enabled = false;
                    _SalId = Convert.ToInt32(lblSalId.Text);
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

                        gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
                        // gridView1.Appearance.Row.ForeColor = Color.Black;
                        HelpClass1.ClearControls(panelControl1);

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

                        gridView1.Appearance.HeaderPanel.ForeColor = Color.Red;
                        //  gridView1.Appearance.Row.ForeColor = Color.Red;
                        HelpClass1.ClearControls(panelControl1);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbHesabTabagheh()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabTabaghehs.Any())
                    {
                        _SalId = Convert.ToInt32(lblSalId.Text);
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
                       // cmbHesabTabagheh.EditValue = 0;
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
                    _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabGroups.Where(s => s.TabaghehId == _HesabTabaghehId && s.SalId == _SalId).ToList();
                    if (q.Count > 0)
                    {
                        var MaximumCode = q.Max(s => s.Code);
                        if (MaximumCode.ToString().Substring(_HesabTabaghehCarakter) != _HesabGroupMaxCode)
                            txtCode.Text = (MaximumCode + 1).ToString().Substring(_HesabTabaghehCarakter);
                        else
                        {
                            XtraMessageBox.Show("اعمال محدودیت تعریف " + _HesabGroupMaxCode + " حساب گروه ..." + "\n" + "توجه : نمیتوان بیشتر از " + _HesabGroupMaxCode + " حساب گروه تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chkEditCode.Checked = true;
                        }
                    }
                    else
                    {
                        txtCode.Text = _HesabGroupMinCode;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int _HesabTabaghehCarakter = 0;
        int _HesabGroupCarakter = 0;
        string _HesabGroupMinCode = "";
        string _HesabGroupMaxCode = "";

        int _SalId = 0;
        int _Code = 0;
        string _Name = "";
        bool _IsActive = true;
        string _SharhHesab = "";
        int _LevelNamber = 0;
        int _HesabTabaghehId = 0;

        private void FrmHesabGroup_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            FillDataGridHesabGroup();
            FillcmbHesabTabagheh();
            btnCreate.Focus();
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpTanzimatCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId);
                    if (q != null)
                    {
                        _HesabTabaghehCarakter = q.HesabTabaghehCarakter;
                        _HesabGroupCarakter = q.HesabGroupCarakter;
                        _HesabGroupMinCode = q.HesabGroupMinCode;
                        _HesabGroupMaxCode = q.HesabGroupMaxCode;

                        txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        txtCode.Properties.Mask.EditMask = _HesabGroupCarakter == 1 ? "0" : "00";
                        txtCode.Properties.MaxLength = _HesabGroupCarakter;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
             _SalId = Convert.ToInt32(lblSalId.Text);
             _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);
             _Code = Convert.ToInt32(txtTabaghehCode.Text + txtCode.Text);
             _Name = txtName.Text.Trim();
             _IsActive = chkIsActive.Checked;
            _SharhHesab = txtSharhHesab.Text.Trim();
            _LevelNamber = 2;

            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtTabaghehCode.Text) || Convert.ToInt32(cmbHesabTabagheh.EditValue)==0)
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_HesabGroupMaxCode))
            {
                XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabGroupMinCode + " تا " + _HesabGroupMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter);
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

            if (string.IsNullOrEmpty(cmbHesabTabagheh.Text))
            {
                XtraMessageBox.Show("لطفاً حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(_Name) || _Name == "0")
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
                                var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId);
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
                            var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId);
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

            if (En == EnumCED.Create || En == EnumCED.Edit)
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

                //FillcmbHesabTabagheh();
                cmbHesabTabagheh.Focus();

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
                                _SalId = Convert.ToInt32(lblSalId.Text);
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
        int HesabTabaghehIdBeforeEdit = 0;
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

                   // FillcmbHesabTabagheh();

                    cmbHesabTabagheh.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghehId").ToString());
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtTabaghehCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                    CodeBeforeEdit = Convert.ToInt32(txtTabaghehCode.Text + txtCode.Text);
                    NameBeforeEdit = txtName.Text.Trim();
                    HesabTabaghehIdBeforeEdit = Convert.ToInt32(cmbHesabTabagheh.EditValue);
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    cmbHesabTabagheh.Focus();
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
                                EpHesabGroup obj = new EpHesabGroup();
                                obj.SalId = Convert.ToInt32(lblSalId.Text);
                                obj.Code = _Code;
                                obj.Name = _Name;
                                obj.TabaghehId = _HesabTabaghehId;
                                //obj.TabaghehName = cmbHesabTabagheh.Text;
                                obj.IsActive = _IsActive;
                                obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                obj.NoeHesab = cmbNoeHesab.Text;
                                obj.SharhHesab = _SharhHesab;

                                //var qq = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                                //qq.EpHesabGroups.Add(obj);

                                //EpHesabTabagheh obj1 = new EpHesabTabagheh();
                                //obj1.EpHesabGroups.Add(obj);
                                //db.EpHesabGroups.Add(obj);
                                //db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                //var q = db.EpHesabGroups.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                ////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                n1.SalId = Convert.ToInt32(lblSalId.Text);
                                n1.KeyCode = _Code;
                                n1.ParentCode = Convert.ToInt32(txtTabaghehCode.Text);
                                n1.LevelName = _Name;
                                //n1.HesabTabaghehId = _HesabTabaghehId;
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
                                int RowId = Convert.ToInt32(txtId.Text);
                                ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                var q6 = db.EpHesabMoins.Where(s => s.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                if (q6.Count > 0)
                                {
                                    foreach (var item in q6)
                                    {
                                        if (CodeBeforeEdit != _Code)
                                            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                + item.Code.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                        if (IsActiveBeforeEdit != _IsActive)
                                            item.IsActive = _IsActive;
                                    }
                                }
                                /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId && s.SalId == _SalId).ToList();
                                if (q5.Count > 0)
                                {
                                    foreach (var item in q5)
                                    {
                                        if (CodeBeforeEdit != _Code)
                                            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                + item.Code.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                        if (IsActiveBeforeEdit != _IsActive)
                                            item.IsActive = _IsActive;

                                        foreach (var item1 in q6)
                                        {
                                            if (item1.ColId == item.Id)
                                                item.EpHesabMoins.Append(item1);
                                        }
                                    }
                                }
                                //////////////////////////////////////////////////////
                                var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                if (q != null)
                                {
                                    q.Code = _Code;
                                    q.Name = _Name;
                                    q.TabaghehId = _HesabTabaghehId;
                                    q.IsActive = _IsActive;
                                    q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                    q.NoeHesab = cmbNoeHesab.Text;
                                    q.SharhHesab = _SharhHesab;
                                    q.EpHesabCols = q5;
                                }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(txtTabaghehCode.Text);
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpHesabGroup1 = q;

                                        var q3 = db.EpAllCodingHesabdaris.Where(s => s.EpHesabCol1.GroupId == RowId || s.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter+_HesabGroupCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter+_HesabGroupCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                                }

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }

                                        }

                                    /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                    var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                               s.EpAllCodingHesabdari1.Id == RowId
                                            || s.EpAllCodingHesabdari1.EpHesabCol1.GroupId == RowId
                                            || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q9.Count > 0)
                                        {
                                            foreach (var item in q9)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter+_HesabGroupCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter+_HesabGroupCarakter), _Code.ToString())
                                                            + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        {
                                            var T = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                                            var A = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                                            var U = db.RmsUserBallCodingHesabdaris.FirstOrDefault(s => s.CodingHesabdariId == _HesabTabaghehId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (A != null)
                                                A.IsActive = true;
                                            if (U != null)
                                                U.IsActive = true;
                                        }


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
              //  FillcmbHesabTabagheh();
                cmbHesabTabagheh.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TabaghehId").ToString());
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();                      
                txtTabaghehCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0,_HesabTabaghehCarakter);
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter);
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeHesab"));
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                btnDelete.Enabled = btnEdit.Enabled = true;
            }
            else
                btnDelete.Enabled = btnEdit.Enabled = false;
        }

        private void cmbHesabTabagheh_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _HesabTabaghehId = Convert.ToInt32(cmbHesabTabagheh.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtTabaghehCode.Text = q.Code.ToString();
                        cmbNoeHesab.SelectedIndex = q.IndexNoeHesab;
                        if (En == EnumCED.Edit)
                            if (_HesabTabaghehId != HesabTabaghehIdBeforeEdit)
                            {
                                btnNewCode_Click(null, null);
                            }
                            else
                                txtCode.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehId);

                        else
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

        private void cmbHesabTabagheh_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTabagheh.ShowPopup();
            }
        }

        private void btnReloadHesabTabagheh_Click(object sender, EventArgs e)
        {
            FillcmbHesabTabagheh();
        }
    }
}