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
        public bool IsActiveList = true;
        public void FillDataGrid()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpListAnbarhas.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epListAnbarhasBindingSource.DataSource = q1;
                            else
                                epListAnbarhasBindingSource.DataSource = null;
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
                            var q = dataContext.EpListAnbarhas.Where(p => p.IsActive == false).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epListAnbarhasBindingSource.DataSource = q;
                            else
                                epListAnbarhasBindingSource.DataSource = null;
                        }
                        else
                            epListAnbarhasBindingSource.DataSource = null;
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
                    var q = db.EpListAnbarhas.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString() != "1000")
                        {
                            txtCode.Text = (MaximumCod + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت تعریف 999 حساب انبار ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از 999 حساب انبار تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 1000 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void FrmListAnbarha_Load(object sender, EventArgs e)
        {
            FillDataGrid();
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
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 0 || Convert.ToInt32(txtCode.Text) >= 1000)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 1000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (cmbNoeAnbar.SelectedIndex==-1)
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
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.EpListAnbarhas.FirstOrDefault(p => p.Code == _Code);
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
                            var q1 = db.EpListAnbarhas.FirstOrDefault(p => p.Id != RowId && p.Code == _Code);
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
                            var q1 = db.EpListAnbarhas.FirstOrDefault(p => p.Name == txtName.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpListAnbarhas.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
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
            FillDataGrid();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
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
               // FillcmbGroupTafzili();
                //cmbListGroupTafzili.EditValue = 1;
                //txtCodeGroupTafzili.Text = "10";
                btnNewCode_Click(null, null);
               // cmbListGroupTafzili.EditValue = 13;
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
                                var q = db.EpListAnbarhas.FirstOrDefault(p => p.Id == RowId);
                                //var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                if (q != null /*&& q8 != null*/)
                                {
                                    db.EpListAnbarhas.Remove(q);
                                    //db.EpAccessLevelCodingHesabdaris.Remove(q8);
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
                                XtraMessageBox.Show("حذف این انبار مقدور نیست \n" +
                                    " زیرا با انبار فوق سند صادر گردیده", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //FillcmbGroupTafzili();

                    //cmbListGroupTafzili.EditValue = 13;
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    //txtCodeGroupTafzili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbNoeAnbar.SelectedIndex= Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeAnbar").ToString());
                    chkMojavezMojodiManfi.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MojavezMojodiManfi"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

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
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q = db.EpListAnbarhas.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    q.Code = Convert.ToInt32(txtCode.Text);
                                    q.Name = txtName.Text;
                                    q.IndexNoeAnbar = cmbNoeAnbar.SelectedIndex;
                                    q.NoeAnbar = cmbNoeAnbar.Text;
                                    q.MojavezMojodiManfi = chkMojavezMojodiManfi.Checked;
                                    q.IsActive = chkIsActive.Checked;
                                    q.SharhHesab = txtSharhHesab.Text;

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

                                    // XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
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
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }


        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
               // FillcmbGroupTafzili();

                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                //txtCodeGroupTafzili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbNoeAnbar.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IndexNoeAnbar").ToString());
                chkMojavezMojodiManfi.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MojavezMojodiManfi"));
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
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
            if (En==EnumCED.Create)
            {
                cmbNoeAnbar.ShowPopup();
            }
        }
    }
}