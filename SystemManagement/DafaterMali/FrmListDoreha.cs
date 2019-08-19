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
using DBHesabdari_PG.Models.Ms.DafaterMali;
using DBHesabdari_PG.Models.Ms.SystemUsers;

namespace SystemManagement.DafaterMali
{
    public partial class FrmListDoreha : DevExpress.XtraEditors.XtraForm
    {
        public FrmListDoreha()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

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
                        if (IsActiveList == true)
                        {
                            db.MsMajmoes.Where(s => s.MajmoeIsActive == true).Load();
                            msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
                        }
                        else
                        {
                            db.MsMajmoes.Load();
                            msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
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

        public void FillcmbVahedhaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsVaheds.Any())
                    {
                        if (IsActiveList == true)
                        {
                            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            db.MsVaheds.Where(s => s.VahedIsActive == true && s.MsMajmoeId == _MajmoeId).Load();
                            msVahedsBindingSource.DataSource = db.MsVaheds.Local.ToBindingList();
                        }
                        else
                        {
                            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                            db.MsVaheds.Where(s => s.MsMajmoeId == _MajmoeId).Load();
                            msVahedsBindingSource.DataSource = db.MsVaheds.Local.ToBindingList();
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

        public void FillcmbShobehaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsShobes.Any())
                    {
                        if (IsActiveList == true)
                        {
                            int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                            db.MsShobes.Where(s => s.ShobeIsActive == true && s.MsVahedId == _VahedId).Load();
                            msShobesBindingSource.DataSource = db.MsShobes.Local.ToBindingList();
                        }
                        else
                        {
                            int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                            db.MsShobes.Where(s => s.MsVahedId == _VahedId).Load();
                            msShobesBindingSource.DataSource = db.MsShobes.Local.ToBindingList();
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

        public void Fillgridview1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = db.MsDoreMalis.Where(s => s.DoreMaliIsActive == true).OrderBy(s => s.DoreMaliCode).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                msDoreMalisBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            //var q2 = q1.Select(s => s.MsDoreMaliId).ToList(); ;
                            var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.DoreMaliId > 0 && s.IsActive == true).Select(s => s.DoreMaliId).ToList();
                            if (q1.Count > 0)
                            {
                                if (q3.Count > 0)
                                {
                                    q3.ForEach(item3 =>
                                    {
                                        q1.Remove(db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == item3));
                                    });
                                    msDoreMalisBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    msDoreMalisBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = db.MsDoreMalis.Where(p => p.DoreMaliIsActive == false).OrderBy(s => s.DoreMaliCode);
                            if (q.ToList().Count() > 0)
                                msDoreMalisBindingSource.DataSource = q.ToList();
                            else
                                msDoreMalisBindingSource.DataSource = null;
                        }
                        else
                            msDoreMalisBindingSource.DataSource = null;
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
            if (cmbShobeList.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                        var q = db.MsDoreMalis.Where(s => s.MsShobeId == _ShobeId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.DoreMaliCode);
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(6);
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

        int MajmoeIdBeforeEdit = 0;
        int VahedIdBeforeEdit = 0;
        int ShobeIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmListDoreha_Load(object sender, EventArgs e)
        {
            Fillgridview1();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl5.Visible = true;
                chkDoreIsClose.Visible = true;
            }
            HelpClass1.InActiveControls(xtraTabPage1);
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
            int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
            ///////////////// اعتبار سنجی کد////////////////////////////////////
            if (string.IsNullOrEmpty(cmbMajmoehaList.Text))
            {
                XtraMessageBox.Show("لطفاً نام مجموعه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbVahedhaList.Text))
            {
                XtraMessageBox.Show("لطفاً نام واحد را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbShobeList.Text))
            {
                XtraMessageBox.Show("لطفاً نام شعبه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 0)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (En == EnumCED.Create)
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
                        int _code = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.MsDoreMalis.Any())
                            {
                                var q1 = db.MsDoreMalis.Where(p => p.DoreMaliCode == _code);
                                if (q1.Any())
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
                            var q1 = db.MsDoreMalis.Where(p => p.MsDoreMaliId != RowId && p.DoreMaliCode == _code);
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

            if (string.IsNullOrEmpty(txtDoreMali.Text) || Convert.ToInt32(txtDoreMali.Text) <= 1396)
            {
                XtraMessageBox.Show("دوره مالی باید بیشتر از 1396 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                        int _DoreMali = Convert.ToInt32(txtDoreMali.Text);
                        if (En == EnumCED.Create)
                        {
                            if (db.MsDoreMalis.Any())
                            {
                                var q1 = db.MsDoreMalis.Where(p => p.MsShobeId == _ShobeId && p.DoreMali == _DoreMali);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این دوره قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.MsDoreMalis.Where(p => p.MsShobeId == _ShobeId && p.MsDoreMaliId != RowId && p.DoreMali == _DoreMali);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این دوره قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtDoreMali.Text = nameBeforeEdit;
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

        private void FrmListDoreha_KeyDown(object sender, KeyEventArgs e)
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

            }        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            Fillgridview1();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            Fillgridview1();
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
                FillcmbMajmoehaList();
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ClearControls(xtraTabPage1);
                HelpClass1.ActiveControls(xtraTabPage1);
                // txtCode.ReadOnly = true;
                // xtraTabControl1.SelectedTabPageIndex = 0;
                cmbMajmoehaList.Focus();

            }        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    if (XtraMessageBox.Show("آیا دوره مالی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsDoreMaliId"));
                                var q = db.MsDoreMalis.FirstOrDefault(p => p.MsDoreMaliId == RowId);
                                var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                                if (q != null && q8 != null)
                                {
                                    db.MsDoreMalis.Remove(q);
                                    db.MsAccessLevelDafaterMalis.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    if (XtraMessageBox.Show("در صورت وجود اطلاعات در سال مالی انتخابی کلیه اطلاعات سال مالی فوق حذف خواهد شد و قابل برگشت نمی باشد \n آیا برای حذف مطمئن هستید؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        db.SaveChanges();

                                        if (IsActiveList)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView1.RowCount > 0)
                                            gridView1.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(xtraTabPage1);
                                    }
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //catch (DbUpdateException)
                            //{
                            //    XtraMessageBox.Show("حذف رکورد جاری مقدور نیست \n" +
                            //        " جهت حذف رکورد جاری در ابتدا بایستی زیر مجموعه های رکورد جاری  (در لیست دوره ها) حذف گردد" +
                            //        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

            }        }

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
                    HelpClass1.ActiveControls(xtraTabPage1);
                    FillcmbMajmoehaList();
                    // xtraTabControl1.SelectedTabPageIndex = 0;

                    cmbMajmoehaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                    cmbVahedhaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
                    cmbShobeList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsShobeId").ToString());
                    txtShobeCode.Text = gridView1.GetFocusedRowCellValue("DoreMaliCode").ToString().Substring(0, 6);
                    txtId.Text = gridView1.GetFocusedRowCellValue("MsDoreMaliId").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("DoreMaliCode").ToString().Substring(6);
                    txtDoreMali.Text = gridView1.GetFocusedRowCellValue("DoreMali").ToString();
                    txtStartDore.EditValue = gridView1.GetFocusedRowCellValue("StartDoreMali").ToString().Substring(0, 10);
                    txtEndDore.EditValue = gridView1.GetFocusedRowCellValue("EndDoreMali").ToString().Substring(0, 10);
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("DoreMaliIsActive"));
                    chkDoreIsClose.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("DoreIsClose"));
                    txtMaliat.Text = gridView1.GetFocusedRowCellValue("Maliat").ToString();
                    txtAvarez.Text = gridView1.GetFocusedRowCellValue("Avarez").ToString();

                    txtDoreMali.ReadOnly = false;

                    MajmoeIdBeforeEdit = Convert.ToInt32(cmbMajmoehaList.EditValue);
                    VahedIdBeforeEdit = Convert.ToInt32(cmbVahedhaList.EditValue);
                    ShobeIdBeforeEdit = Convert.ToInt32(cmbShobeList.EditValue);
                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtDoreMali.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    // txtCode.ReadOnly = true;
                    cmbMajmoehaList.Focus();
                }

            }        }

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
                                MsDoreMali obj = new MsDoreMali();
                                obj.DoreMaliCode = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                obj.DoreMali = Convert.ToInt32(txtDoreMali.Text);
                                obj.StartDoreMali = Convert.ToDateTime(txtStartDore.Text);
                                obj.EndDoreMali = Convert.ToDateTime(txtEndDore.Text);
                                obj.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                obj.MajmoeName = cmbMajmoehaList.Text;
                                obj.MsVahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                obj.VahedName = cmbVahedhaList.Text;
                                obj.MsShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                obj.ShobeName = cmbShobeList.Text;
                                obj.DoreMaliIsActive = chkIsActive.Checked;
                                obj.DoreIsClose = chkDoreIsClose.Checked;
                                obj.Maliat = Convert.ToSingle(txtMaliat.Text.Replace('/', '.') != "" ? txtMaliat.Text.Replace('/', '.') : "0");
                                obj.Avarez = Convert.ToSingle(txtAvarez.Text.Replace('/', '.') != "" ? txtAvarez.Text.Replace('/', '.') : "0");
                                db.MsDoreMalis.Add(obj);
                                db.SaveChanges();
                                ////////////////////////////////////// اضافه کردن دوره های مالی به کلاس سطح دسترسی دفاتر مالی ////////////////////
                                int _code = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                var q = db.MsDoreMalis.FirstOrDefault(s => s.DoreMaliCode == _code);

                                MsAccessLevelDafaterMali n1 = new MsAccessLevelDafaterMali();
                                n1.KeyId = _code;
                                n1.ParentId = Convert.ToInt32(_code.ToString().Substring(0, 6));
                                n1.LevelName = txtDoreMali.Text;
                                n1.MajmoeId = q.MsMajmoeId;
                                n1.VahedId = q.MsVahedId;
                                n1.ShobeId = q.MsShobeId;
                                n1.DoreMaliId = q.MsDoreMaliId;
                                n1.IsActive = chkIsActive.Checked;
                                db.MsAccessLevelDafaterMalis.Add(n1);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                btnLast_Click(null, null);
                                En = EnumCED.Save;
                                btnCancel_Click(null, null);

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
                                var q = db.MsDoreMalis.FirstOrDefault(p => p.MsDoreMaliId == RowId);
                                if (q != null)
                                {
                                    q.DoreMaliCode = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                    q.DoreMali = Convert.ToInt32(txtDoreMali.Text);
                                    q.StartDoreMali = Convert.ToDateTime(txtStartDore.Text);
                                    q.EndDoreMali = Convert.ToDateTime(txtEndDore.Text);
                                    q.MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                    q.MajmoeName = cmbMajmoehaList.Text;
                                    q.MsVahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                    q.VahedName = cmbVahedhaList.Text;
                                    q.MsShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                    q.ShobeName = cmbShobeList.Text;
                                    q.DoreMaliIsActive = chkIsActive.Checked;
                                    q.DoreIsClose = chkDoreIsClose.Checked;
                                    q.Maliat = Convert.ToSingle(txtMaliat.Text.Replace('/', '.') != "" ? txtMaliat.Text.Replace('/', '.') : "0");
                                    q.Avarez = Convert.ToSingle(txtAvarez.Text.Replace('/', '.') != "" ? txtAvarez.Text.Replace('/', '.') : "0");
                                    /////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                    var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                                    if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        q8.KeyId = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                    if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue))
                                        q8.ParentId = Convert.ToInt32(txtShobeCode.Text);
                                    if (NameBeforeEdit != txtDoreMali.Text)
                                        q8.LevelName = txtDoreMali.Text;
                                    if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                        q8.MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                    if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                        q8.VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                    if (ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue))
                                        q8.ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                    if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        q8.IsActive = chkIsActive.Checked;
                                    ///////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                    var q9 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(s => s.DoreMaliId == RowId);
                                    if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        q9.KeyId = Convert.ToInt32(txtShobeCode.Text + txtCode.Text);
                                    if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                        q9.MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                    if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                        q9.VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                    if (ShobeIdBeforeEdit != Convert.ToInt32(cmbShobeList.EditValue))
                                        q9.ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                    if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        q9.IsActive = chkIsActive.Checked;
                                    /////////////////////////////////////////////////////////////////////////////
                                    if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                    {
                                        int MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                        int VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                        int ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                                        var m = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == MajmoeId);
                                        var v = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == VahedId);
                                        var s = db.MsShobes.FirstOrDefault(p => p.MsShobeId == ShobeId);
                                        var a1 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                        var a2 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                        var a3 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == 0);
                                        //var a4 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == RowId);
                                        var b1 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                        var b2 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                        var b3 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == 0);
                                        //var b4 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == ShobeId && p.DoreMaliId == RowId);
                                        if (m != null)
                                            m.MajmoeIsActive = true;
                                        if (v != null)
                                            v.VahedIsActive = true;
                                        if (s != null)
                                            s.ShobeIsActive = true;
                                        if (a1 != null)
                                            a1.IsActive = true;
                                        if (a2 != null)
                                            a2.IsActive = true;
                                        if (a3 != null)
                                            a3.IsActive = true;
                                        //if (a4 != null)
                                        //    a4.IsActive = true;
                                        if (b1 != null)
                                            b1.IsActive = true;
                                        if (b2 != null)
                                            b2.IsActive = true;
                                        if (b3 != null)
                                            b3.IsActive = true;
                                        //if (b4 != null)
                                        //    b4.IsActive = true;
                                    }
                                    db.SaveChanges();

                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);
                                    //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex;

                                    En = EnumCED.Save;
                                    btnCancel_Click(null, null);

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

            }        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            if (btnSaveNext.Enabled)
            {
                //gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
                btnSave_Click(null, null);
                if (En == EnumCED.Save)
                    btnCreate_Click(null, null);

            }        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled)
            {
                gridControl1.Enabled = true;
                HelpClass1.ActiveButtons(panelControl2);
                HelpClass1.ClearControls(xtraTabPage1);
                HelpClass1.InActiveControls(xtraTabPage1);

            }        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                if (Convert.ToInt32(txtCode.Text) <= 0)
                {
                    XtraMessageBox.Show("کد وارده باید عددی بزرگتر از صفر باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (En == EnumCED.Create)
                    {
                        btnNewCode_Click(null, null);
                    }
                    else
                    {
                        txtCode.Text = CodeBeforeEdit;
                    }
                }
            }
        }

        private void cmbMajmoehaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbVahedhaList();
        }

        private void cmbVahedhaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbShobehaList();
        }

        private void cmbShobeList_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _ShobeId = Convert.ToInt32(cmbShobeList.EditValue);
                    if (msShobesBindingSource.DataSource != null)
                    {
                        var q = db.MsShobes.FirstOrDefault(s => s.MsShobeId == _ShobeId);
                        if (q != null)
                        {
                            txtShobeCode.Text = q.ShobeCode.ToString();
                            btnNewCode_Click(null, null);
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

        private void cmbMajmoehaList_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbMajmoehaList.ShowPopup();
            }
        }

        private void cmbVahedhaList_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedhaList.ShowPopup();
            }
        }

        private void cmbShobeList_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbShobeList.ShowPopup();
            }
        }

        private void chkIsActive_Leave(object sender, EventArgs e)
        {
            btnSave.Focus();
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
                FillcmbMajmoehaList();

                cmbMajmoehaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                cmbVahedhaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
                cmbShobeList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsShobeId").ToString());
                txtShobeCode.Text = gridView1.GetFocusedRowCellValue("DoreMaliCode").ToString().Substring(0, 6);
                txtId.Text = gridView1.GetFocusedRowCellValue("MsDoreMaliId").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("DoreMaliCode").ToString().Substring(6);
                txtDoreMali.Text = gridView1.GetFocusedRowCellValue("DoreMali").ToString();
                txtStartDore.EditValue = gridView1.GetFocusedRowCellValue("StartDoreMali").ToString().Substring(0, 10);
                txtEndDore.EditValue = gridView1.GetFocusedRowCellValue("EndDoreMali").ToString().Substring(0, 10);
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("DoreMaliIsActive"));
                chkDoreIsClose.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("DoreIsClose"));
                txtMaliat.Text = gridView1.GetFocusedRowCellValue("Maliat").ToString();
                txtAvarez.Text = gridView1.GetFocusedRowCellValue("Avarez").ToString();

            }


        }
    }
}
