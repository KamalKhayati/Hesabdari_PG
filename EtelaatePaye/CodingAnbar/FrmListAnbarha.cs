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
using DBHesabdari_PG.Models.EP.CodingAnbar;

namespace EtelaatePaye.CodingAnbar
{
    public partial class FrmListAnbarha : DevExpress.XtraEditors.XtraForm
    {
        public FrmListAnbarha()
        {
            InitializeComponent();
        }

        public EnumCED En;
        int _SalId = 0;
        public void FillDataGrid()
        {
            using (var db = new MyContext())
            {
                try
                {
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    if (lblUserId.Text == "1")
                        epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;
                    //else
                    //{
                    //    int _UserId = Convert.ToInt32(lblUserId.Text);
                    //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                    //    if (q1.Count > 0)
                    //    {
                    //        if (q2.Count > 0)
                    //        {
                    //            q2.ForEach(item2 =>
                    //            {
                    //                q1.Remove(dataContext.EpHesabTafsiliSandoghs.FirstOrDefault(s => s.Id == item2));
                    //            });
                    //            epHesabTafsiliSandoghsBindingSource.DataSource = q1;
                    //        }
                    //        else
                    //        {
                    //            epHesabTafsiliSandoghsBindingSource.DataSource = q1;
                    //        }
                    //    }
                    //    else
                    //        epHesabTafsiliSandoghsBindingSource.DataSource = null;
                    //}
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
                    var q = db.EpListAnbarhas.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(s => s.Code);
                        if (MaximumCod.ToString() != _CodeAnbarMaxCode)
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            XtraMessageBox.Show("اعمال محدودیت تعریف" + _CodeAnbarMaxCode + "حساب انبار ..." + "\n" + "توجه : نمیتوان بیشتر از" + _CodeAnbarMaxCode + "حساب انبار تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chkEditCode.Checked = true;
                        }

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

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        int _CodeAnbarCarakter = 0;
        string _CodeAnbarMinCode = "";
        string _CodeAnbarMaxCode = "";

        private void FrmListAnbarha_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            FillDataGrid();
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpTanzimatAnbarVKalas.FirstOrDefault(s => s.SalId == _SalId);
                    if (q != null)
                    {
                        _CodeAnbarCarakter = q.CodeAnbarCarakter;

                        _CodeAnbarMinCode = q.CodeAnbarMinCode;
                        _CodeAnbarMaxCode = q.CodeAnbarMaxCode;
                        txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        txtCode.Properties.Mask.EditMask = "000";
                        txtCode.Properties.MaxLength = _CodeAnbarCarakter;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            En = EnumCED.None;
            btnCreate.Focus();

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
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) < Convert.ToInt32(_CodeAnbarMinCode) || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_CodeAnbarMaxCode))
            {
                XtraMessageBox.Show("کد وارده بایستی عددی از " + _CodeAnbarMinCode + " تا " + _CodeAnbarMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (cmbNoeAnbar.SelectedIndex == -1)
            {
                XtraMessageBox.Show("لطفا نوع انبار را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNoeAnbar.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _Code = Convert.ToInt32(txtCode.Text);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _Code);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnNewCode_Click(null, null);
                                return false;
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id != RowId && s.Code == _Code);
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
                XtraMessageBox.Show("لطفاً نام انبار را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
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
                            var q1 = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Name == txtName.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtName.Focus();
                                return false;
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id != RowId && s.Name == txtName.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtName.Focus();
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

        private void FrmListAnbarha_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplyList_Click(sender, null);
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

        public void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillDataGrid();
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
                // FillcmbGroupTafsili();
                //cmbListGroupTafsili.EditValue = 1;
                //txtCodeGroupTafsili.Text = "10";
                btnNewCode_Click(null, null);
                // cmbListGroupTafsili.EditValue = 13;
                chkIsActive.Checked = true;
                txtName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا انبار فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                if (q != null)
                                {
                                    db.EpListAnbarhas.Remove(q);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyList_Click(null, null);
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
                                XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                                    " زیرا با حساب فوق سند صادر گردیده", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    gridView1_RowCellClick(null, null);
                    ////cmbListGroupTafsili.EditValue = 13;
                    //txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    ////txtCodeGroupTafsili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                    //txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                    //txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    //cmbNoeAnbar.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeAnbar").ToString());
                    //chkMojavezMojodiManfi.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MojavezMojodiManfi"));
                    //chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    //txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtName.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    //if (txtCode.Text == "99999")
                    //    btnNewCode.Enabled = false;
                    txtName.Focus();
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
                                EpListAnbarha obj = new EpListAnbarha();
                                obj.SalId = Convert.ToInt32(lblSalId.Text);
                                obj.Code = Convert.ToInt32(txtCode.Text);
                                obj.Name = txtName.Text;
                                obj.IndexNoeAnbar = cmbNoeAnbar.SelectedIndex;
                                obj.NoeAnbar = cmbNoeAnbar.Text;
                                obj.MojavezMojodiManfi = chkMojavezMojodiManfi.Checked;
                                obj.IsActive = chkIsActive.Checked;
                                obj.SharhHesab = txtSharhHesab.Text;

                                db.EpListAnbarhas.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafsiliSandoghs.FirstOrDefault(s => s.Code == _Code);
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
                                btnCancel_Click(null, null);
                                btnDisplyList_Click(null, null);
                                // XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                btnLast_Click(null, null);
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
                                var q = db.EpListAnbarhas.FirstOrDefault(s => s.Id == RowId);
                                if (q != null)
                                {
                                    q.Code = Convert.ToInt32(txtCode.Text);
                                    q.Name = txtName.Text;
                                    q.IndexNoeAnbar = cmbNoeAnbar.SelectedIndex;
                                    q.NoeAnbar = cmbNoeAnbar.Text;
                                    q.MojavezMojodiManfi = chkMojavezMojodiManfi.Checked;
                                    q.IsActive = chkIsActive.Checked;
                                    q.SharhHesab = txtSharhHesab.Text;

                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    btnDisplyList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex;
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    // FillcmbGroupTafsili();

                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    //txtCodeGroupTafsili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbNoeAnbar.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeAnbar").ToString());
                    chkMojavezMojodiManfi.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MojavezMojodiManfi"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                    if (En != EnumCED.Edit)
                        btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
                }
            }
            catch (Exception)
            {
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

        private void cmbNoeAnbar_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeAnbar.ShowPopup();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            HelpClass1.gridView_RowCellStyle(sender, e);
        }
    }
}