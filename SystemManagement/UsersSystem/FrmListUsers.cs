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
using DBHesabdari_PG.Models.Ms.SystemUsers;

namespace SystemManagement.UsersSystem
{
    public partial class FrmListUsers : DevExpress.XtraEditors.XtraForm
    {
        public FrmListUsers()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void Fillgridview1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        if (lblUserId.Text == "1")
                        {
                            db.MsUsers.Where(p => p.UserIsActive == true).OrderBy(s => s.UserCode).Load();
                            msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            db.MsUsers.Where(p => p.UserIsActive == true && p.MsUserId == _UserId).OrderBy(s => s.UserCode).Load();
                            msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            db.MsUsers.Where(p => p.UserIsActive == false).OrderBy(s => s.UserCode).Load();
                            msUsersBindingSource.DataSource = db.MsUsers.Local.ToBindingList(); ;
                        }
                        else
                        {
                            msUsersBindingSource.DataSource = null;
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
                    if (db.MsUsers.Any())
                    {
                        var MaximumCod = db.MsUsers.Max(p => p.UserCode);
                        txtCode.Text = (MaximumCod + 1).ToString();
                    }
                    else
                    {
                        txtCode.Text = "101";
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
        string ShenaseBeforEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmListUsers_Load(object sender, EventArgs e)
        {
            Fillgridview1();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl5.Visible = true;
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
            ///////////////// اعتبار سنجی کد////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 100)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.MsUsers.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.MsUsers.Where(p => p.UserCode == _code);
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
                            var q1 = db.MsUsers.Where(p => p.MsUserId != RowId && p.UserCode == _code);
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
                XtraMessageBox.Show("لطفاً نام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtShenase.Text) || txtShenase.Text == "0")
            {
                XtraMessageBox.Show("لطفاً شناسه کاربری را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "0")
            {
                XtraMessageBox.Show("لطفاً پسورد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.MsUsers.Any())
                            {
                                var q2 = db.MsUsers.Where(p => p.Name == txtName.Text);
                                var q3 = db.MsUsers.Where(p => p.Shenase == txtShenase.Text);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("کاربر مورد نظر قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                                if (q3.Any())
                                {
                                    XtraMessageBox.Show("این شناسه کاربری قبلاً استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtShenase.Text = "";
                                    txtShenase.Focus();
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q2 = db.MsUsers.Where(p => p.MsUserId != RowId && p.Name == txtName.Text);
                            var q3 = db.MsUsers.Where(p => p.MsUserId != RowId && p.Shenase == txtShenase.Text);
                            if (q2.Any())
                            {
                                XtraMessageBox.Show("کاربر مورد نظر قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                txtName.Focus();
                                return false;
                            }
                            if (q3.Any())
                            {
                                XtraMessageBox.Show("این شناسه کاربری قبلاً استفاده شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                txtShenase.Text = "";
                                txtShenase.Focus();
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

        private void FrmListUsers_KeyDown(object sender, KeyEventArgs e)
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
            if(btnPrintPreview.Visible)
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
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ClearControls(xtraTabPage1);
                HelpClass1.ActiveControls(xtraTabPage1);
                btnNewCode_Click(null, null);
                txtName.Focus();

            }        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    if (XtraMessageBox.Show("آیا کاربر انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EditRowIndex = gridView1.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsUserId"));
                                var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == RowId);
                                if (q != null)
                                {
                                    if (q.MsUserId == 1)
                                    {
                                        XtraMessageBox.Show("کاربر فوق سیستمی است لذا قابل حذف نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        return;
                                    }
                                    else
                                    {
                                        db.MsUsers.Remove(q);
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
                    // xtraTabControl1.SelectedTabPageIndex = 0;

                    txtId.Text = gridView1.GetFocusedRowCellValue("MsUserId").ToString();
                    txtCode.Text = gridView1.GetFocusedRowCellValue("UserCode").ToString();
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    txtShenase.Text = gridView1.GetFocusedRowCellValue("Shenase").ToString();
                    txtPassword.Text = gridView1.GetFocusedRowCellValue("Password").ToString();
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("UserIsActive"));

                    if (txtName.Text == "مدیر سیستم")
                    {
                        chkEditCode.Enabled = false;
                        txtName.Enabled = false;
                        chkIsActive.Enabled = false;
                        labelControl5.Enabled = false;
                    }
                    else
                    {
                        chkEditCode.Enabled = true;
                        txtName.Enabled = true;
                        chkIsActive.Enabled = true;
                        labelControl5.Enabled = true;

                    }
                    CodeBeforeEdit = txtCode.Text;
                    NameBeforeEdit = txtName.Text;
                    ShenaseBeforEdit = txtShenase.Text;
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    txtName.Focus();

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
                                MsUser obj = new MsUser()
                                {
                                    UserCode = Convert.ToInt32(txtCode.Text),
                                    Name = txtName.Text,
                                    Shenase = txtShenase.Text,
                                    Password = txtPassword.Text,
                                    UserIsActive = chkIsActive.Checked,
                                };
                                db.MsUsers.Add(obj);
                                db.SaveChanges();
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
                                var q = db.MsUsers.FirstOrDefault(p => p.MsUserId == RowId);
                                if (q != null)
                                {
                                    q.UserCode = Convert.ToInt32(txtCode.Text);
                                    q.Name = txtName.Text;
                                    q.Shenase = txtShenase.Text;
                                    q.Password = txtPassword.Text;
                                    q.UserIsActive = Convert.ToBoolean(chkIsActive.Checked);

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
                if (Convert.ToInt32(txtCode.Text) <= 100)
                {
                    XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtId.Text = gridView1.GetFocusedRowCellValue("MsUserId").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("UserCode").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                txtShenase.Text = gridView1.GetFocusedRowCellValue("Shenase").ToString();
                txtPassword.Text = gridView1.GetFocusedRowCellValue("Password").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("UserIsActive"));
            }


        }
    }
}