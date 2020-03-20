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
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System.Data.Entity;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmListGroupTafzili : DevExpress.XtraEditors.XtraForm
    {
        public FrmListGroupTafzili()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillGroupTafziliList()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = dataContext.EpGroupTafzilis.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epGroupTafzilisBindingSource.DataSource = q1;
                            else
                                epGroupTafzilisBindingSource.DataSource = null;
                        }
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
                        //                q1.Remove(dataContext.EpGroupTafzilis.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            epGroupTafzilisBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epGroupTafzilisBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epGroupTafzilisBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpGroupTafzilis.Where(p => p.IsActive == false).OrderBy(s => s.Code).ToList();
                            if (q.Count > 0)
                                epGroupTafzilisBindingSource.DataSource = q;
                            else
                                epGroupTafzilisBindingSource.DataSource = null;
                        }
                        else
                            epGroupTafzilisBindingSource.DataSource = null;
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
                    if (db.EpGroupTafzilis.Any())
                    {
                        var MaximumCod = db.EpGroupTafzilis.Max(p => p.Code);
                        if (MaximumCod != 99)
                            txtCode.Text = (MaximumCod + 1).ToString();
                        else
                            XtraMessageBox.Show("اعمال محدودیت تعریف حداکثر 90 حساب گروه تفضیلی ..." + "\n" + "توجه : نمیتوان بیشتر از 90 حساب گروه تفضیلی تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 10 تا 100 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        txtCode.Text = "10";
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
        private void FrmListGroupTafzili_Load(object sender, EventArgs e)
        {
            FillGroupTafziliList();
            btnCreate.Focus();
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
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) < 10 || Convert.ToInt32(txtCode.Text) > 99)
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از 9 و کمتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.EpGroupTafzilis.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.EpGroupTafzilis.Where(p => p.Code == _code);
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
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q1 = db.EpGroupTafzilis.Where(p => p.Id != RowId && p.Code == _code);
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
                            if (db.EpGroupTafzilis.Any())
                            {
                                var q2 = db.EpGroupTafzilis.Where(p => p.Name == txtName.Text);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q2 = db.EpGroupTafzilis.Where(p => p.Id != RowId && p.Name == txtName.Text);
                            if (q2.Any())
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

        private void FrmListGroupTafzili_KeyDown(object sender, KeyEventArgs e)
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
            FillGroupTafziliList();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillGroupTafziliList();
        }

        //private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        btnEdit_Click(null, null);
        //    }
        //}

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
                btnNewCode_Click(null, null);
                txtName.Focus();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا گروه تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpGroupTafzilis.FirstOrDefault(p => p.Id == RowId);
                                //var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.HesabGroupId == RowId);
                                if (q != null /*&& q8 != null*/)
                                {
                                    db.EpGroupTafzilis.Remove(q);
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
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این گروه تفضیلی مقدور نیست \n" +
                                    " جهت حذف حساب گروه تفضیلی در ابتدا بایستی کلیه ارتباط های این حساب با حسابهای معین و حسابهای تفضیلی حذف گردد" +
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
                    HelpClass1.ActiveControls(panelControl1);
                    NameBeforeEdit = gridView1.GetFocusedRowCellValue("Name").ToString();


                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab") != null ? gridView1.GetFocusedRowCellValue("SharhHesab").ToString() :"";

                    CodeBeforeEdit = txtCode.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    //if (txtCode.Text == "9")
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
                                EpGroupTafzili obj = new EpGroupTafzili();
                                obj.Code = Convert.ToInt32(txtCode.Text);
                                obj.Name = txtName.Text;
                                obj.IsActive = chkIsActive.Checked;
                                obj.SharhHesab = txtSharhHesab.Text;
                                db.EpGroupTafzilis.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q = db.EpGroupTafzilis.FirstOrDefault(s => s.Code == _code);
                                //////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                //EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                //n1.KeyId = _code;
                                //n1.ParentId = _code;
                                //n1.LevelName = txtName.Text;
                                //n1.HesabGroupId = q.Id;
                                //n1.IsActive = chkIsActive.Checked;
                                //db.EpAllCodingHesabdaris.Add(n1);
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //db.SaveChanges();
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
                                var q = db.EpGroupTafzilis.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    q.Code = Convert.ToInt32(txtCode.Text);
                                    q.Name = txtName.Text;
                                    q.IsActive = chkIsActive.Checked;
                                    q.SharhHesab = txtSharhHesab.Text;

                                    /////////////////////////////////متد اصلاح کد و نام مجموعه در لیست حسابهای کل ومعین WillCascadeOnUpdate ///////////////////////

                                    ///////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                    //var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId).ToList();
                                    //if (q5.Count > 0)
                                    //{
                                    //    q5.ForEach(item =>
                                    //    {
                                    //        if (CodeBeforeEdit != txtCode.Text)
                                    //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                    //                + item.Code.ToString().Substring(1));
                                    //        if (NameBeforeEdit != txtName.Text)
                                    //            item.GroupName = txtName.Text;
                                    //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    //            item.IsActive = chkIsActive.Checked;
                                    //    });
                                    //}
                                    /////////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    //var q6 = db.EpHesabMoins.Where(s => s.GroupId == RowId).ToList();
                                    //if (q6.Count > 0)
                                    //{
                                    //    q6.ForEach(item =>
                                    //    {
                                    //        if (CodeBeforeEdit != txtCode.Text)
                                    //            item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, 1).Replace(item.Code.ToString().Substring(0, 1), txtCode.Text)
                                    //                + item.Code.ToString().Substring(1));
                                    //        if (NameBeforeEdit != txtName.Text)
                                    //            item.GroupName = txtName.Text;
                                    //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    //            item.IsActive = chkIsActive.Checked;
                                    //    });
                                    //}
                                    /////////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    //var q8 = db.EpAllCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                    //if (q8.Count > 0)
                                    //{
                                    //    q8.ForEach(item =>
                                    //    {
                                    //        if (item.HesabColId == 0)
                                    //        {
                                    //            if (CodeBeforeEdit != txtCode.Text)
                                    //                item.KeyId = Convert.ToInt32(txtCode.Text);
                                    //            if (CodeBeforeEdit != txtCode.Text)
                                    //                item.ParentId = Convert.ToInt32(txtCode.Text);
                                    //            if (NameBeforeEdit != txtName.Text)
                                    //                item.LevelName = txtName.Text;
                                    //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    //                item.IsActive = chkIsActive.Checked;
                                    //        }
                                    //        else
                                    //        {
                                    //            if (CodeBeforeEdit != txtCode.Text)
                                    //                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                    //                    + item.KeyId.ToString().Substring(1));
                                    //            if (CodeBeforeEdit != txtCode.Text)
                                    //                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 1).Replace(item.ParentId.ToString().Substring(0, 1), txtCode.Text)
                                    //                    + item.ParentId.ToString().Substring(1));
                                    //            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    //                item.IsActive = chkIsActive.Checked;
                                    //        }
                                    //    });
                                    //}
                                    ///////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                    //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabGroupId == RowId).ToList();
                                    //if (q9.Count > 0)
                                    //{
                                    //    q9.ForEach(item =>
                                    //    {
                                    //        if (CodeBeforeEdit != txtCode.Text)
                                    //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 1).Replace(item.KeyId.ToString().Substring(0, 1), txtCode.Text)
                                    //                    + item.KeyId.ToString().Substring(1));
                                    //        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    //            item.IsActive = chkIsActive.Checked;
                                    //    });
                                    //}
                                    ///////////////////////////////////////////////////////////////////////////////////////////////

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

        //private void gridView1_DoubleClick(object sender, EventArgs e)
        //{
        //    btnEdit_Click(null, null);
        //}

        //private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        //}

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
                txtId.Text = gridView1.GetFocusedRowCellDisplayText("Id");
                txtCode.Text = gridView1.GetFocusedRowCellDisplayText("Code");
                txtName.Text = gridView1.GetFocusedRowCellDisplayText("Name");
                txtStartCode.Text = gridView1.GetFocusedRowCellDisplayText("StartCode");
                txtEndCode.Text = gridView1.GetFocusedRowCellDisplayText("EndCode");
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = gridView1.GetFocusedRowCellDisplayText("SharhHesab");
            }


        }
    }
}