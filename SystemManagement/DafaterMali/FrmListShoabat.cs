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
    public partial class FrmListShoabat : DevExpress.XtraEditors.XtraForm
    {
        public FrmListShoabat()
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

        public void Fillgridview1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = db.MsShobes.Where(s => s.ShobeIsActive == true).OrderBy(s => s.ShobeCode).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                msShobesBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            //var q2 = q1.Select(s => s.MsShobeId).ToList(); ;
                            var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.DoreMaliId == 0 && s.IsActive == true).Select(s => s.ShobeId).ToList();
                            if (q1.Count > 0)
                            {
                                if (q3.Count > 0)
                                {
                                    q3.ForEach(item3 =>
                                    {
                                        q1.Remove(db.MsShobes.FirstOrDefault(s => s.MsShobeId == item3));
                                    });
                                    msShobesBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    msShobesBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = db.MsShobes.Where(p => p.ShobeIsActive == false).OrderBy(s => s.ShobeCode);
                            if (q.ToList().Count() > 0)
                                msShobesBindingSource.DataSource = q.ToList();
                            else
                                msShobesBindingSource.DataSource = null;
                        }
                        else
                            msShobesBindingSource.DataSource = null;
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
            if (cmbVahedhaList.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                        var q = db.MsShobes.Where(s => s.MsVahedId == _VahedId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.ShobeCode);
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(4);
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

        int MajmoeIdBeforeEdit = 0;
        int VahedIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmListShoabat_Load(object sender, EventArgs e)
        {
            Fillgridview1();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl5.Visible = true;
            }
            HelpClass1.InActiveControls(xtraTabPage1);
            HelpClass1.InActiveControls(xtraTabPage2);
            HelpClass1.InActiveControls(xtraTabPage3);
            HelpClass1.InActiveControls(xtraTabPage4);
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
                        if (En == EnumCED.Create)
                        {
                            if (db.MsShobes.Any())
                            {
                                int _code = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                                var q1 = db.MsShobes.Where(p => p.ShobeCode == _code);
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
                            int _code = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                            var q1 = db.MsShobes.Where(p => p.MsShobeId != RowId && p.ShobeCode == _code);
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
                XtraMessageBox.Show("لطفاً نام شعبه را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                        if (En == EnumCED.Create)
                        {
                            if (db.MsShobes.Any())
                            {
                                var q1 = db.MsShobes.Where(p => p.MsVahedId == _VahedId && p.ShobeName == txtName.Text);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این شعبه قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.MsShobes.Where(p => p.MsVahedId == _VahedId && p.MsShobeId != RowId && p.ShobeName == txtName.Text);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این شعبه قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void FrmListShoabat_KeyDown(object sender, KeyEventArgs e)
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
                HelpClass1.ClearControls(xtraTabPage2);
                HelpClass1.ClearControls(xtraTabPage3);
                HelpClass1.ClearControls(xtraTabPage4);
                HelpClass1.ActiveControls(xtraTabPage1);
                HelpClass1.ActiveControls(xtraTabPage2);
                HelpClass1.ActiveControls(xtraTabPage3);
                HelpClass1.ActiveControls(xtraTabPage4);
                //txtCode.ReadOnly = true;
                xtraTabControl1.SelectedTabPageIndex = 0;
                cmbMajmoehaList.Focus();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    if (XtraMessageBox.Show("آیا رکورد انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsShobeId"));
                                var q = db.MsShobes.FirstOrDefault(p => p.MsShobeId == RowId);
                                var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.ShobeId == RowId);
                                if (q != null && q8 != null)
                                {
                                    db.MsShobes.Remove(q);
                                    db.MsAccessLevelDafaterMalis.Remove(q8);
                                    /////////////////////////////////////////////////////////////////////////////
                                    var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsShobeId == RowId);
                                    if (q4 != null)
                                    {
                                        db.MsInfoOthers.Remove(q4);
                                    }
                                    db.SaveChanges();

                                    if (IsActiveList)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);
                                    //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView1.RowCount > 0)
                                        gridView1.FocusedRowHandle = EditRowIndex - 1;
                                    HelpClass1.ClearControls(xtraTabPage1);
                                    HelpClass1.ClearControls(xtraTabPage2);
                                    HelpClass1.ClearControls(xtraTabPage3);
                                    HelpClass1.ClearControls(xtraTabPage4);
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف رکورد جاری مقدور نیست \n" +
                                    " جهت حذف رکورد جاری در ابتدا بایستی زیر مجموعه های رکورد جاری  (در لیست دوره ها) حذف گردد" +
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
                    HelpClass1.ActiveControls(xtraTabPage1);
                    HelpClass1.ActiveControls(xtraTabPage2);
                    HelpClass1.ActiveControls(xtraTabPage3);
                    HelpClass1.ActiveControls(xtraTabPage4);
                    FillcmbMajmoehaList();
                    xtraTabControl1.SelectedTabPageIndex = 0;

                    cmbMajmoehaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                    cmbVahedhaList.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
                    txtVahedCode.Text = gridView1.GetFocusedRowCellValue("ShobeCode").ToString().Substring(0, 4);
                    txtId.Text = gridView1.GetFocusedRowCellValue("MsShobeId").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("ShobeCode").ToString().Substring(4);
                    txtName.Text = gridView1.GetFocusedRowCellValue("ShobeName").ToString();
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("ShobeIsActive"));

                    int RowId = Convert.ToInt32(txtId.Text);
                    using (var db = new MyContext())
                    {
                        try
                        {
                            /////////////////////////////////////////////////////////////////////
                            var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsShobeId == RowId);
                            if (q4 != null)
                            {
                                if (q4.NoeShakhs == "حقیقی") radioButton1.Checked = true; else radioButton2.Checked = true;
                                txtNoeFaaliat.Text = q4.NoeFaaliat.ToString();
                                txtAdress.Text = q4.Adress.ToString();
                                txtCodePosti.Text = q4.CodePosti.ToString();
                                txtSandoghPosti.Text = q4.SandoghPosti.ToString();
                                txtShomarePlak.Text = q4.ShomarePlak.ToString();
                                txtShenaseMelli.Text = q4.ShenaseMelli.ToString();
                                txtCodeSenfee.Text = q4.CodeSenfee.ToString();
                                txtCodeEghtesadi.Text = q4.CodeEghtesadi.ToString();
                                txtTell1.Text = q4.Tell1.ToString();
                                txtTell2.Text = q4.Tell2.ToString();
                                txtTellFax1.Text = q4.TellFax1.ToString();
                                txtTellFax2.Text = q4.TellFax2.ToString();
                                txtMobile1.Text = q4.Mobile1.ToString();
                                txtMobile2.Text = q4.Mobile2.ToString();
                                txtEmail1.Text = q4.Email1.ToString();
                                txtEmail2.Text = q4.Email2.ToString();
                                txtSite.Text = q4.Site.ToString();
                                txtWebLog.Text = q4.WebLog.ToString();
                                txtShabakeEjtemaee1.Text = q4.ShabakeEjtemaee1.ToString();
                                txtShabakeEjtemaee2.Text = q4.ShabakeEjtemaee2.ToString();
                                txtShParvandeMaliati.Text = q4.ShParvandeMaliati.ToString();
                                txtShBimeKargah.Text = q4.ShBimeKargah.ToString();
                            }

                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    VahedIdBeforeEdit = Convert.ToInt32(cmbVahedhaList.EditValue);
                    MajmoeIdBeforeEdit = Convert.ToInt32(cmbMajmoehaList.EditValue);
                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtName.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    // txtCode.ReadOnly = true;
                    cmbMajmoehaList.Focus();
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
                                MsShobe obj = new MsShobe()
                                {
                                    ShobeCode = Convert.ToInt32(txtVahedCode.Text + txtCode.Text),
                                    ShobeName = txtName.Text,
                                    ShobeIsActive = chkIsActive.Checked,
                                    MsMajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue),
                                    MajmoeName = cmbMajmoehaList.Text,
                                    MsVahedId = Convert.ToInt32(cmbVahedhaList.EditValue),
                                    VahedName = cmbVahedhaList.Text,
                                };
                                db.MsShobes.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                int _code = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                                var q = db.MsShobes.FirstOrDefault(s => s.ShobeCode == _code);

                                MsInfoOther obj2 = new MsInfoOther()
                                {
                                    MsShobeId = q.MsShobeId,
                                    MsCode = _code,
                                    MsName = txtName.Text,
                                    NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                    NoeFaaliat = txtNoeFaaliat.Text,
                                    Adress = txtAdress.Text,
                                    CodePosti = txtCodePosti.Text,
                                    SandoghPosti = txtSandoghPosti.Text,
                                    ShomarePlak = txtShomarePlak.Text,
                                    ShenaseMelli = txtShenaseMelli.Text,
                                    CodeSenfee = txtCodeSenfee.Text,
                                    CodeEghtesadi = txtCodeEghtesadi.Text,
                                    Tell1 = txtTell1.Text,
                                    Tell2 = txtTell2.Text,
                                    TellFax1 = txtTellFax1.Text,
                                    TellFax2 = txtTellFax2.Text,
                                    Mobile1 = txtMobile1.Text,
                                    Mobile2 = txtMobile2.Text,
                                    Email1 = txtEmail1.Text,
                                    Email2 = txtEmail2.Text,
                                    Site = txtSite.Text,
                                    WebLog = txtWebLog.Text,
                                    ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text,
                                    ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text,
                                    ShParvandeMaliati = txtShParvandeMaliati.Text,
                                    ShBimeKargah = txtShBimeKargah.Text,
                                };
                                db.MsInfoOthers.Add(obj2);
                                ////////////////////////////////////// اضافه کردن شعبه های تجاری به کلاس سطح دسترسی دفاتر مالی ////////////////////
                                MsAccessLevelDafaterMali n1 = new MsAccessLevelDafaterMali();
                                n1.KeyId = _code;
                                n1.ParentId = Convert.ToInt32(_code.ToString().Substring(0, 4));
                                n1.LevelName = txtName.Text;
                                n1.MajmoeId = q.MsMajmoeId;
                                n1.VahedId = q.MsVahedId;
                                n1.ShobeId = q.MsShobeId;
                                n1.IsActive = chkIsActive.Checked;
                                db.MsAccessLevelDafaterMalis.Add(n1);
                                /////////////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();
                                if (chkIsActive.Checked)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

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
                                int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                string _MajmoeName = cmbMajmoehaList.Text;
                                int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                string _VahedName = cmbVahedhaList.Text;
                                int _ShobeCode = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                                var q = db.MsShobes.FirstOrDefault(p => p.MsShobeId == RowId);
                                if (q != null)
                                {
                                    q.MsMajmoeId = _MajmoeId;
                                    q.MajmoeName = _MajmoeName;
                                    q.MsVahedId = _VahedId;
                                    q.VahedName = _VahedName;
                                    q.ShobeCode = _ShobeCode;
                                    q.ShobeName = txtName.Text;
                                    q.ShobeIsActive = chkIsActive.Checked;
                                    /////////////////////////////متد اصلاح کد و نام مجموعه در لیست دوره های مالی WillCascadeOnUpdate ///////////////////////

                                    /////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                    var q7 = db.MsDoreMalis.Where(s => s.MsShobeId == RowId).ToList();
                                    if (q7.Count > 0)
                                    {
                                        q7.ForEach(item =>
                                        {
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.MsMajmoeId = _MajmoeId;
                                            item.MajmoeName = _MajmoeName;
                                            if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                                item.MsVahedId = _VahedId;
                                            item.VahedName = _VahedName;
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.DoreMaliCode = Convert.ToInt32(item.DoreMaliCode.ToString().Substring(0, 2).Replace(item.DoreMaliCode.ToString().Substring(0, 2), txtVahedCode.Text.Substring(0, 2))
                                                + item.DoreMaliCode.ToString().Substring(2, 2).Replace(item.DoreMaliCode.ToString().Substring(2, 2), txtVahedCode.Text.Substring(2, 2))
                                                + item.DoreMaliCode.ToString().Substring(4, 2).Replace(item.DoreMaliCode.ToString().Substring(4, 2), txtCode.Text)
                                                + item.DoreMaliCode.ToString().Substring(6));
                                            if (NameBeforeEdit != txtName.Text)
                                                item.ShobeName = txtName.Text;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.DoreMaliIsActive = chkIsActive.Checked;
                                        });
                                    }
                                    /////////////////////////////متد اصلاح کد و نام مجموعه در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                    var q8 = db.MsAccessLevelDafaterMalis.Where(s => s.ShobeId == RowId).ToList();
                                    q8.ForEach(item =>
                                    {
                                        if (item.DoreMaliId == 0)
                                        {
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                                item.ParentId = Convert.ToInt32(txtVahedCode.Text);
                                            if (NameBeforeEdit != txtName.Text)
                                                item.LevelName = txtName.Text;
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.MajmoeId = _MajmoeId;
                                            if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                                item.VahedId = _VahedId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                        else
                                        {
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtVahedCode.Text.Substring(0, 2))
                                                + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtVahedCode.Text.Substring(2, 2))
                                                + item.KeyId.ToString().Substring(4, 2).Replace(item.KeyId.ToString().Substring(4, 2), txtCode.Text)
                                                + item.KeyId.ToString().Substring(6));
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), txtVahedCode.Text.Substring(0, 2))
                                                + item.ParentId.ToString().Substring(2, 2).Replace(item.ParentId.ToString().Substring(2, 2), txtVahedCode.Text.Substring(2, 2))
                                                + item.ParentId.ToString().Substring(4, 2).Replace(item.ParentId.ToString().Substring(4, 2), txtCode.Text)
                                                + item.ParentId.ToString().Substring(6));
                                            if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                                item.MajmoeId = _MajmoeId;
                                            if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                                item.VahedId = _VahedId;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;

                                        }
                                    });
                                    ///////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                    var q9 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.ShobeId == RowId).ToList();
                                    q9.ForEach(item =>
                                    {
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue) || VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue) || CodeBeforeEdit != txtCode.Text)
                                            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtVahedCode.Text.Substring(0, 2))
                                            + item.KeyId.ToString().Substring(2, 2).Replace(item.KeyId.ToString().Substring(2, 2), txtVahedCode.Text.Substring(2, 2))
                                            + item.KeyId.ToString().Substring(4, 2).Replace(item.KeyId.ToString().Substring(4, 2), txtCode.Text)
                                            + item.KeyId.ToString().Substring(6));
                                        if (MajmoeIdBeforeEdit != Convert.ToInt32(cmbMajmoehaList.EditValue))
                                            item.MajmoeId = _MajmoeId;
                                        if (VahedIdBeforeEdit != Convert.ToInt32(cmbVahedhaList.EditValue))
                                            item.VahedId = _VahedId;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;

                                    });
                                    /////////////////////////////////////////////////////////////////////////////
                                    int _code = Convert.ToInt32(txtVahedCode.Text + txtCode.Text);
                                    var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsShobeId == RowId);
                                    if (q4 != null)
                                    {
                                        q4.MsShobeId = RowId;
                                        q4.MsCode = _code;
                                        q4.MsName = txtName.Text;
                                        q4.NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی";
                                        q4.NoeFaaliat = txtNoeFaaliat.Text;
                                        q4.Adress = txtAdress.Text;
                                        q4.CodePosti = txtCodePosti.Text;
                                        q4.SandoghPosti = txtSandoghPosti.Text;
                                        q4.ShomarePlak = txtShomarePlak.Text;
                                        q4.ShenaseMelli = txtShenaseMelli.Text;
                                        q4.CodeSenfee = txtCodeSenfee.Text;
                                        q4.CodeEghtesadi = txtCodeEghtesadi.Text;
                                        q4.Tell1 = txtTell1.Text;
                                        q4.Tell2 = txtTell2.Text;
                                        q4.TellFax1 = txtTellFax1.Text;
                                        q4.TellFax2 = txtTellFax2.Text;
                                        q4.Mobile1 = txtMobile1.Text;
                                        q4.Mobile2 = txtMobile2.Text;
                                        q4.Email1 = txtEmail1.Text;
                                        q4.Email2 = txtEmail2.Text;
                                        q4.Site = txtSite.Text;
                                        q4.WebLog = txtWebLog.Text;
                                        q4.ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text;
                                        q4.ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text;
                                        q4.ShParvandeMaliati = txtShParvandeMaliati.Text;
                                        q4.ShBimeKargah = txtShBimeKargah.Text;
                                    }
                                    else
                                    {
                                        MsInfoOther obj2 = new MsInfoOther()
                                        {
                                            MsShobeId = RowId,
                                            MsCode = _code,
                                            MsName = txtName.Text,
                                            NoeShakhs = radioButton1.Checked ? "حقیقی" : "حقوقی",
                                            NoeFaaliat = txtNoeFaaliat.Text,
                                            Adress = txtAdress.Text,
                                            CodePosti = txtCodePosti.Text,
                                            SandoghPosti = txtSandoghPosti.Text,
                                            ShomarePlak = txtShomarePlak.Text,
                                            ShenaseMelli = txtShenaseMelli.Text,
                                            CodeSenfee = txtCodeSenfee.Text,
                                            CodeEghtesadi = txtCodeEghtesadi.Text,
                                            Tell1 = txtTell1.Text,
                                            Tell2 = txtTell2.Text,
                                            TellFax1 = txtTellFax1.Text,
                                            TellFax2 = txtTellFax2.Text,
                                            Mobile1 = txtMobile1.Text,
                                            Mobile2 = txtMobile2.Text,
                                            Email1 = txtEmail1.Text,
                                            Email2 = txtEmail2.Text,
                                            Site = txtSite.Text,
                                            WebLog = txtWebLog.Text,
                                            ShabakeEjtemaee1 = txtShabakeEjtemaee1.Text,
                                            ShabakeEjtemaee2 = txtShabakeEjtemaee2.Text,
                                            ShParvandeMaliati = txtShParvandeMaliati.Text,
                                            ShBimeKargah = txtShBimeKargah.Text,
                                        };
                                        db.MsInfoOthers.Add(obj2);
                                    }
                                    ///////////////////////////////////////////////////////////////////////////
                                    if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                    {
                                        int MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                                        int VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                                        var m = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == MajmoeId);
                                        var v = db.MsVaheds.FirstOrDefault(p => p.MsVahedId == VahedId);
                                        var a1 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                        var a2 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                        //var a3 = db.MsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == RowId && p.DoreMaliId == 0);
                                        var b1 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == 0);
                                        var b2 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == 0);
                                        //var b3 = db.RmsUserBmsAccessLevelDafaterMalis.FirstOrDefault(p => p.MajmoeId == MajmoeId && p.VahedId == VahedId && p.ShobeId == RowId && p.DoreMaliId == 0);
                                        if (m != null)
                                            m.MajmoeIsActive = true;
                                        if (v != null)
                                            v.VahedIsActive = true;
                                        if (a1 != null)
                                            a1.IsActive = true;
                                        if (a2 != null)
                                            a2.IsActive = true;
                                        //if (a3 != null)
                                        //    a3.IsActive = true;
                                        if (b1 != null)
                                            b1.IsActive = true;
                                        if (b2 != null)
                                            b2.IsActive = true;
                                        //if (b3 != null)
                                        //    b3.IsActive = true;
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
                HelpClass1.ClearControls(xtraTabPage1);
                HelpClass1.ClearControls(xtraTabPage2);
                HelpClass1.ClearControls(xtraTabPage3);
                HelpClass1.ClearControls(xtraTabPage4);
                HelpClass1.InActiveControls(xtraTabPage1);
                HelpClass1.InActiveControls(xtraTabPage2);
                HelpClass1.InActiveControls(xtraTabPage3);
                HelpClass1.InActiveControls(xtraTabPage4);

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        public void Fillgridview2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _MsShobeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsShobeId"));
                    var qq1 = db.MsInfoOthers.Where(f => f.MsShobeId == _MsShobeId).ToList();
                    if (qq1.Count > 0)
                    {
                        msInfoOthersBindingSource.DataSource = qq1;
                    }
                    else
                        msInfoOthersBindingSource.DataSource = null;


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
            Fillgridview2();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtShenaseMelli.Properties.MaxLength = radioButton1.Checked ? 10 : 11;

        }

        private void chkIsActive_Leave(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            txtAdress.Focus();
        }

        private void txtTellFax2_Leave(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 2;
            txtSite.Focus();
        }

        private void txtShabakeEjtemaee2_Leave(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 3;
            txtNoeFaaliat.Focus();
        }

        private void txtShBimeKargah_Leave(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void cmbMajmoehaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbVahedhaList();
        }

        private void cmbVahedhaList_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsVaheds.Any())
                    {
                        int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                        var q = db.MsVaheds.FirstOrDefault(s => s.MsVahedId == _VahedId);
                        if (q != null)
                        {
                            txtVahedCode.Text = q.VahedCode.ToString();
                            btnNewCode_Click(null, null);
                        }
                        else
                            txtVahedCode.Text = "";

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
                txtVahedCode.Text = gridView1.GetFocusedRowCellValue("ShobeCode").ToString().Substring(0, 4);
                txtId.Text = gridView1.GetFocusedRowCellValue("MsShobeId").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("ShobeCode").ToString().Substring(4);
                txtName.Text = gridView1.GetFocusedRowCellValue("ShobeName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("ShobeIsActive"));

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsShobeId == RowId);
                        if (q4 != null)
                        {
                            if (q4.NoeShakhs == "حقیقی") radioButton1.Checked = true; else radioButton2.Checked = true;
                            txtNoeFaaliat.Text = q4.NoeFaaliat.ToString();
                            txtAdress.Text = q4.Adress.ToString();
                            txtCodePosti.Text = q4.CodePosti.ToString();
                            txtSandoghPosti.Text = q4.SandoghPosti.ToString();
                            txtShomarePlak.Text = q4.ShomarePlak.ToString();
                            txtShenaseMelli.Text = q4.ShenaseMelli.ToString();
                            txtCodeSenfee.Text = q4.CodeSenfee.ToString();
                            txtCodeEghtesadi.Text = q4.CodeEghtesadi.ToString();
                            txtTell1.Text = q4.Tell1.ToString();
                            txtTell2.Text = q4.Tell2.ToString();
                            txtTellFax1.Text = q4.TellFax1.ToString();
                            txtTellFax2.Text = q4.TellFax2.ToString();
                            txtMobile1.Text = q4.Mobile1.ToString();
                            txtMobile2.Text = q4.Mobile2.ToString();
                            txtEmail1.Text = q4.Email1.ToString();
                            txtEmail2.Text = q4.Email2.ToString();
                            txtSite.Text = q4.Site.ToString();
                            txtWebLog.Text = q4.WebLog.ToString();
                            txtShabakeEjtemaee1.Text = q4.ShabakeEjtemaee1.ToString();
                            txtShabakeEjtemaee2.Text = q4.ShabakeEjtemaee2.ToString();
                            txtShParvandeMaliati.Text = q4.ShParvandeMaliati.ToString();
                            txtShBimeKargah.Text = q4.ShBimeKargah.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}