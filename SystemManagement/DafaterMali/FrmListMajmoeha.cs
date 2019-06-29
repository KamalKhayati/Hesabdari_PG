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

namespace SystemManagement.DafaterMali
{
    public partial class FrmListMajmoeha : DevExpress.XtraEditors.XtraForm
    {
        public FrmListMajmoeha()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool IsActiveList = true;

        public void FillDataGridListMajmoeha()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsActiveList == true)
                    {
                        var q1 = db.MsMajmoes.Where(s => s.MajmoeIsActive == true).OrderBy(s => s.MajmoeCode).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                msMajmoesBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            //var q2 = q1.Select(s => s.MsMajmoeId).ToList(); ;
                            var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.VahedId == 0 && s.IsActive == true).Select(s => s.MajmoeId).ToList();
                            if (q1.Count > 0)
                            {
                                if (q3.Count > 0)
                                {
                                    q3.ForEach(item3 =>
                                    {
                                        q1.Remove(db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == item3));
                                    });
                                    msMajmoesBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    msMajmoesBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = db.MsMajmoes.Where(p => p.MajmoeIsActive == false).OrderBy(s => s.MajmoeCode).ToList();
                            if (q.Count > 0)
                                msMajmoesBindingSource.DataSource = q;
                            else
                                msMajmoesBindingSource.DataSource = null;
                        }
                        else
                            msMajmoesBindingSource.DataSource = null;
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
                    if (db.MsMajmoes.Any())
                    {
                        var MaximumCod = db.MsMajmoes.Max(p => p.MajmoeCode);
                        txtCode.Text = (MaximumCod + 1).ToString();
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
        bool IsActiveBeforeEdit;
        private void FrmListMajmoeha_Load(object sender, EventArgs e)
        {
            FillDataGridListMajmoeha();
            if (lblUserId.Text == "1")
            {
                chkIsActive.Visible = true;
                labelControl3.Visible = true;
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
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) <= 9)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 9 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            if (db.MsMajmoes.Any())
                            {
                                int _code = Convert.ToInt32(txtCode.Text);
                                var q1 = db.MsMajmoes.Where(p => p.MajmoeCode == _code);
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
                            var q1 = db.MsMajmoes.Where(p => p.MsMajmoeId != RowId && p.MajmoeCode == _code);
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
                            if (db.MsMajmoes.Any())
                            {
                                var q2 = db.MsMajmoes.Where(p => p.MajmoeName == txtName.Text);
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
                            var q2 = db.MsMajmoes.Where(p => p.MsMajmoeId != RowId && p.MajmoeName == txtName.Text);
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

        private void FrmListMajmoeha_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F6 && btnSaveNext.Enabled == true)
            {
                btnSaveNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F7 && btnCancel.Enabled == true)
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
            else if (e.KeyCode == Keys.F10 && btnPrintPreview.Visible == true)
            {
                btnPrintPreview_Click(sender, null);
            }
            else if (e.Alt && e.KeyCode == Keys.N && btnNewCode.Enabled == true)
            {
                btnNewCode_Click(sender, null);
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
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillDataGridListMajmoeha();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillDataGridListMajmoeha();
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

        //private void btnAdvancedSearch_Click(object sender, EventArgs e)
        //{
        //    gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        //}

        //private void btnSharhHesab_Click(object sender, EventArgs e)
        //{
        //    gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
        //}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            En = EnumCED.Create;
            gridControl1.Enabled = false;
            HelpClass1.InActiveButtons(panelControl2);
            HelpClass1.ClearControls(xtraTabPage1);
            HelpClass1.ClearControls(xtraTabPage2);
            HelpClass1.ClearControls(xtraTabPage3);
            HelpClass1.ClearControls(xtraTabPage4);
            HelpClass1.ActiveControls(xtraTabPage1);
            HelpClass1.ActiveControls(xtraTabPage2);
            HelpClass1.ActiveControls(xtraTabPage3);
            HelpClass1.ActiveControls(xtraTabPage4);
            btnNewCode_Click(null, null);
            //txtCode.ReadOnly = true;
            xtraTabControl1.SelectedTabPageIndex = 0;
            txtName.Focus();


        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                            int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString());
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            var q8 = db.MsAccessLevelDafaterMalis.FirstOrDefault(s => s.MajmoeId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.MsMajmoes.Remove(q);
                                db.MsAccessLevelDafaterMalis.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                                if (q4 != null)
                                {
                                    db.MsInfoOthers.Remove(q4);
                                };

                                db.SaveChanges();

                                if (IsActiveList)
                                    btnDisplyActiveList_Click(null, null);
                                else
                                    btnDisplyNotActiveList_Click(null, null);
                                //XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                if (gridView1.RowCount > 0)
                                    gridView1.FocusedRowHandle = EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("حذف رکورد جاری مقدور نیست \n" +
                                " جهت حذف رکورد جاری در ابتدا بایستی زیر مجموعه های رکورد جاری  (در لیست واحد ها ، لیست شعبه ها و لیست دوره ها) حذف گردد" +
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
            if (gridView1.RowCount > 0 && btnEdit.Visible == true)
            {
                gridControl1.Enabled = false;
                EditRowIndex = gridView1.FocusedRowHandle;
                En = EnumCED.Edit;
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ActiveControls(xtraTabPage1);
                HelpClass1.ActiveControls(xtraTabPage2);
                HelpClass1.ActiveControls(xtraTabPage3);
                HelpClass1.ActiveControls(xtraTabPage4);
                xtraTabControl1.SelectedTabPageIndex = 0;

                txtId.Text = gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("MajmoeCode").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("MajmoeName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MajmoeIsActive"));

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
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

                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;
                //txtCode.ReadOnly = true;
                txtName.Focus();
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
                            MsMajmoe obj = new MsMajmoe()
                            {
                                MajmoeCode = Convert.ToInt32(txtCode.Text),
                                MajmoeName = txtName.Text,
                                MajmoeIsActive = chkIsActive.Checked,
                            };
                            db.MsMajmoes.Add(obj);
                            db.SaveChanges();
                            /////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtCode.Text);
                            var q = db.MsMajmoes.FirstOrDefault(s => s.MajmoeCode == _code);
                            MsInfoOther obj2 = new MsInfoOther()
                            {
                                MsMajmoeId = q.MsMajmoeId,
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
                            ////////////////////////////////////// اضافه کردن مجموعه های زنجیره ای به کلاس سطح دسترسی دفاتر مالی ////////////////////
                            MsAccessLevelDafaterMali n1 = new MsAccessLevelDafaterMali();
                            n1.KeyId = _code;
                            n1.ParentId = _code;
                            n1.LevelName = txtName.Text;
                            n1.MajmoeId = q.MsMajmoeId;
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
                            var q = db.MsMajmoes.FirstOrDefault(p => p.MsMajmoeId == RowId);
                            if (q != null)
                            {
                                if (CodeBeforeEdit != txtCode.Text)
                                    q.MajmoeCode = Convert.ToInt32(txtCode.Text);
                                if (NameBeforeEdit != txtName.Text)
                                    q.MajmoeName = txtName.Text;
                                if (IsActiveBeforeEdit != chkIsActive.Checked)
                                    q.MajmoeIsActive = chkIsActive.Checked;
                                /////////////////////////////متد اصلاح کد و نام مجموعه در لیست واحد ها ، شعبه ها و دوره های مالی WillCascadeOnUpdate ///////////////////////

                                ///////////////////////////// WillCascadeOnUpdate : MsVaheds ///////////////////////
                                var q5 = db.MsVaheds.Where(s => s.MsMajmoeId == RowId).ToList();
                                if (q5.Count > 0)
                                {
                                    q5.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.VahedCode = Convert.ToInt32(item.VahedCode.ToString().Substring(0, 2).Replace(item.VahedCode.ToString().Substring(0, 2), txtCode.Text)
                                            + item.VahedCode.ToString().Substring(2));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.MajmoeName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.VahedIsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////// WillCascadeOnUpdate : MsShobes /////////////////////////
                                var q6 = db.MsShobes.Where(s => s.MsMajmoeId == RowId).ToList();
                                if (q6.Count > 0)
                                {
                                    q6.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.ShobeCode = Convert.ToInt32(item.ShobeCode.ToString().Substring(0, 2).Replace(item.ShobeCode.ToString().Substring(0, 2), txtCode.Text)
                                            + item.ShobeCode.ToString().Substring(2));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.MajmoeName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.ShobeIsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////// WillCascadeOnUpdate : MsDoreMalis /////////////////////////
                                var q7 = db.MsDoreMalis.Where(s => s.MsMajmoeId == RowId).ToList();
                                if (q7.Count > 0)
                                {
                                    q7.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.DoreMaliCode = Convert.ToInt32(item.DoreMaliCode.ToString().Substring(0, 2).Replace(item.DoreMaliCode.ToString().Substring(0, 2), txtCode.Text)
                                            + item.DoreMaliCode.ToString().Substring(2));
                                        if (NameBeforeEdit != txtName.Text)
                                            item.MajmoeName = txtName.Text;
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.DoreMaliIsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////////متد اصلاح کد و نام مجموعه در لیست سطح دسترسی به دفاتر مالی  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.MsAccessLevelDafaterMalis.Where(s => s.MajmoeId == RowId).ToList();
                                if (q8.Count > 0)
                                {
                                    q8.ForEach(item =>
                                    {
                                        if (item.VahedId == 0)
                                        {
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(txtCode.Text);
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(txtCode.Text);
                                            if (NameBeforeEdit != txtName.Text)
                                                item.LevelName = txtName.Text;
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                        else
                                        {
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtCode.Text)
                                                + item.KeyId.ToString().Substring(2));
                                            if (CodeBeforeEdit != txtCode.Text)
                                                item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, 2).Replace(item.ParentId.ToString().Substring(0, 2), txtCode.Text)
                                                + item.ParentId.ToString().Substring(2));
                                            if (IsActiveBeforeEdit != chkIsActive.Checked)
                                                item.IsActive = chkIsActive.Checked;
                                        }
                                    });
                                }
                                ///////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و سطح دسترسی لیست دفاتر مالی  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MajmoeId == RowId).ToList();
                                if (q9.Count > 0)
                                {
                                    q9.ForEach(item =>
                                    {
                                        if (CodeBeforeEdit != txtCode.Text)
                                            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, 2).Replace(item.KeyId.ToString().Substring(0, 2), txtCode.Text)
                                            + item.KeyId.ToString().Substring(2));
                                        if (IsActiveBeforeEdit != chkIsActive.Checked)
                                            item.IsActive = chkIsActive.Checked;
                                    });
                                }
                                /////////////////////////////////////////////////////////////////////////////////////////////
                                var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
                                if (q4 != null)
                                {

                                    q4.MsMajmoeId = RowId;
                                    q4.MsCode = Convert.ToInt32(txtCode.Text);
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
                                        MsMajmoeId = RowId,
                                        MsCode = Convert.ToInt32(txtCode.Text),
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

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            //gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
            btnSave_Click(null, null);
            if (En == EnumCED.Save)
                btnCreate_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
                    int _MsMajmoeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsMajmoeId"));
                    var qq1 = db.MsInfoOthers.Where(f => f.MsMajmoeId == _MsMajmoeId).ToList();
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
            if (Convert.ToInt32(txtCode.Text) <= 9)
            {
                XtraMessageBox.Show("کد وارده باید عددی بزرگتر از 9 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                txtId.Text = gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                txtCode.Text = gridView1.GetFocusedRowCellValue("MajmoeCode").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("MajmoeName").ToString();
                chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MajmoeIsActive"));

                int RowId = Convert.ToInt32(txtId.Text);
                using (var db = new MyContext())
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        var q4 = db.MsInfoOthers.FirstOrDefault(s => s.MsMajmoeId == RowId);
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            gridView1_RowClick(null, null);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            gridView1_RowClick(null, null);
        }
    }
}