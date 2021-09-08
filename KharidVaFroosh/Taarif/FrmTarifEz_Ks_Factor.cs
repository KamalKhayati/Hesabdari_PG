﻿using System;
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
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using HelpClassLibrary;
using DBHesabdari_PG.Models.FK.Taarif;
using DevExpress.XtraGrid.Views.Grid;

namespace KharidVaFroosh.Taarif
{
    public partial class FrmTarifEz_Ks_Factor : DevExpress.XtraEditors.XtraForm
    {
        public FrmTarifEz_Ks_Factor()
        {
            InitializeComponent();
            //// This line of code is generated by Data Source Configuration Wizard
            //// Instantiate a new DBContext
            //DBHesabdari_PG.MyContext dbContext = new DBHesabdari_PG.MyContext();
            //// Call the Load method to get the data for the given DbSet from the database.
            //dbContext.FKTarifEz_Ks_Factors.Load();
            //// This line of code is generated by Data Source Configuration Wizard
            //fKTarifEz_Ks_FactorsBindingSource.DataSource = dbContext.FKTarifEz_Ks_Factors.Local.ToBindingList();
        }

        EnumCED En = EnumCED.None;
        int _Id = 0;
        int _SalId = 0;
        int _Code = 0;
        string _Name = "";
        byte _NoeEz_KsIndex = 0;
        string _NoeEz_KsName = "";
        bool _IsActive = true;
        string _SharhHesab = "";

        int EditRowIndex = 0;
        int _CodeBeforeEdit = 0;
        string _NameBeforeEdit = "";
        bool _IsActiveBeforeEdit = true;

        //XtraTabPage objXtraTabPage;
        //GridControl objGridControl = null;

        private void FrmTarifEz_Ks_Factor_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtCode.Properties.Mask.EditMask = "000";
            txtCode.Properties.MaxLength = 100;
            xtraTabControl1_SelectedPageChanged(null, null);
        }

        private void FrmTarifEz_Ks_Factor_Shown(object sender, EventArgs e)
        {
            btnCreate.Focus();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _NoeEz_KsIndex = Convert.ToByte(xtraTabControl1.SelectedTabPageIndex +3);
            _NoeEz_KsName = xtraTabControl1.SelectedTabPage.Name;
            //objXtraTabPage = new XtraTabPage();
            //objGridControl = new GridControl();
            //objXtraTabPage = xtraTabControl1.SelectedTabPage;
            xtraTabControl1.SelectedTabPage.Controls.Add(gridControl_1);
            btnDelete.Enabled = btnEdit.Enabled = false;
            btnDisplyList_Click(null, null);
            btnCancel_Click(null, null);
        }

        public void fillGridView1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                    var q = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex).OrderBy(s => s.Code).ToList();
                    fKTarifEz_Ks_FactorsBindingSource.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            fillGridView1();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                En = EnumCED.Create;
                HelpClass1.ActiveControls(panelControl2);
                HelpClass1.ClearControls(panelControl2);
                HelpClass1.InActiveButtons(panelControl_Button);
                gridControl_1.Enabled = false;
                chkIsActive.Checked = true;
                btnNewCode_Click(null, null);

                txtName.Focus();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView_1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا رکورد مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        _IsActiveBeforeEdit = Convert.ToBoolean(gridView_1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView_1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int RowId = Convert.ToInt32(gridView_1.GetFocusedRowCellValue("Id").ToString());

                                var q = db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex && s.Id == RowId);
                                if (q != null)
                                {
                                    db.FKTarifEz_Ks_Factors.Remove(q);
                                    db.SaveChanges();

                                    HelpClass1.ClearControls(panelControl2);
                                    btnDisplyList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView_1.RowCount > 0)
                                        gridView_1.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //catch (DbUpdateException)
                            //{
                            //    if (_SelectedTabPage != "xtraTabPage_NameKala")
                            //    {
                            //        XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                            //    " جهت حذف حساب بایستی در ابتدا زیرمجموعه های این حساب حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    }
                            //    else
                            //        XtraMessageBox.Show("حذف این حساب مقدور نیست \n" + " زیرا با حساب فوق سند صادر گردیده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (gridView_1.RowCount > 0)
                {
                    gridControl_1.Enabled = false;
                    EditRowIndex = gridView_1.FocusedRowHandle;
                    En = EnumCED.Edit;

                    gridView_1_RowCellClick(null, null);

                    _CodeBeforeEdit = Convert.ToInt32(txtCode.Text);
                    _NameBeforeEdit = txtName.Text;
                    _IsActiveBeforeEdit = chkIsActive.Checked;

                    HelpClass1.InActiveButtons(panelControl_Button);
                    HelpClass1.ActiveControls(panelControl2);
                    txtName.Focus();
                }
            }

        }

        private void gridView_1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView_1.RowCount > 0)
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _Id = Convert.ToInt32(gridView_1.GetFocusedRowCellValue("Id").ToString());
                    txtCode.Text = gridView_1.GetFocusedRowCellValue("Code").ToString();
                    txtName.Text = gridView_1.GetFocusedRowCellValue("Name").ToString();
                    chkIsActive.Checked = Convert.ToBoolean(gridView_1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView_1.GetFocusedRowCellValue("SharhHesab") != null ? gridView_1.GetFocusedRowCellValue("SharhHesab").ToString() : "";
                    //cmbVahedKala.EditValue = 0;

                }
                if (En != EnumCED.Edit)
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           // if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                gridControl_1.Enabled = true;
                En = EnumCED.Cancel;
                HelpClass1.ActiveButtons(panelControl_Button);
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                _NameBeforeEdit = string.Empty;
                _CodeBeforeEdit = 0;
                HelpClass1.ClearControls(panelControl2);
                HelpClass1.InActiveControls(panelControl2);
                btnCreate.Focus();

            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView_1);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView_1);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView_1);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView_1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Enabled)
            {
                this.Close();

            }
        }

        private void FrmTarifEz_Ks_Factor_KeyDown(object sender, KeyEventArgs e)
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
            //else if (e.KeyCode == Keys.F7)
            //{
            //    btnCancel_Click(sender, null);
            //}
            //else if (e.KeyCode == Keys.F8)
            //{
            //    btnDisplyList_Click(sender, null);
            //}
            else if (e.KeyCode == Keys.F10)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }


        private bool TextEditValidation()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _Name = txtName.Text.Trim();
                    _IsActive = chkIsActive.Checked;
                    _SharhHesab = txtSharhHesab.Text.Trim();
                    _NoeEz_KsIndex = Convert.ToByte(xtraTabControl1.SelectedTabPageIndex +3);
                    _NoeEz_KsName = xtraTabControl1.SelectedTabPage.Name;
                    _Code = !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtCode.Text) : 0;

                    if (string.IsNullOrEmpty(_Code.ToString()))
                    {
                        XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                    {
                        XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtName.Focus();
                        return false;
                    }
                    else
                    {
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnNewCode_Click(null, null);
                                return false;

                            }
                            else if (db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex) != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtName.Focus();
                                return false;
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(gridView_1.GetFocusedRowCellValue("Id").ToString());
                            var q1 = db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // txtCode.Text = CodeBeforeEdit;
                                _Code = _CodeBeforeEdit;
                                return false;
                            }
                            else if (db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex) != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtName.Focus();
                                return false;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (TextEditValidation())
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (En == EnumCED.Create)
                            {
                                FKTarifEz_Ks_Factor obj = new FKTarifEz_Ks_Factor();
                                obj.SalId = _SalId;
                                obj.Code = _Code;
                                obj.Name = _Name;
                                obj.NoeEz_KsIndex = _NoeEz_KsIndex;
                                obj.NoeEz_KsName = _NoeEz_KsName;
                                obj.IsActive = _IsActive;
                                obj.SharhHesab = _SharhHesab;
                                db.FKTarifEz_Ks_Factors.Add(obj);
                                /////////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                btnCancel_Click(null, null);
                                fillGridView1();

                                //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                btnLast_Click(null, null);
                                En = EnumCED.Save;


                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(gridView_1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex);
                                if (q != null)
                                {
                                    q.Code = _Code;
                                    q.Name = _Name;
                                    q.IsActive = _IsActive;
                                    //q.NoeEz_KsIndex = _NoeEz_KsIndex;
                                    //q.NoeEz_KsName = _NoeEz_KsName;
                                    q.SharhHesab = _SharhHesab;
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    fillGridView1();

                                    //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView_1.RowCount > 0)
                                        gridView_1.FocusedRowHandle = EditRowIndex;
                                    En = EnumCED.Save;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == _NoeEz_KsIndex).OrderBy(s => s.Code).ToList();
                    if (q.Count > 0)
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        txtCode.Text = (MaximumCod + 1).ToString();
                    }
                    else
                        txtCode.Text = "1";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gridView_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView_1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_1_RowCellClick(null, null);

        }

        private void gridView_1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_1_RowCellClick(null, null);

        }

        private void gridView_1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            HelpClass1.gridView_RowCellStyle(sender, e);

        }

        private void gridView_1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            HelpClass1.CustomDrawRowIndicator(sender, e, view);

        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            btnNewCode.Enabled = txtCode.Enabled = chkEditCode.Checked ? true : false;

        }
    }
}