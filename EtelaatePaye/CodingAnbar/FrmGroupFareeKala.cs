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
    public partial class FrmGroupFareeKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmGroupFareeKala()
        {
            InitializeComponent();
        }

        private void btnVahedKala_Click(object sender, EventArgs e)
        {
            FrmVahedKala fm = new FrmVahedKala(this);
            //fm.MdiParent = this;
            //fm.lblUserId.Text = txtUserId.Caption;
            //fm.lblUserName.Text = txtUserName.Caption;
            fm.ShowDialog();
        }

        public void FillcmbVahedKala()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpVahedKalas.Any())
                    {
                        db.EpVahedKalas.Load();
                        epVahedKalasBindingSource.DataSource = db.EpVahedKalas.Local.ToBindingList();
                    }
                    else
                    {
                        epVahedKalasBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbGroupAsli()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (cmbDasteBandi.SelectedIndex == 0)
                    {
                        var q = db.EpGroupAsliKalas.Where(f => f.DasteBandiIndex == 0).OrderBy(f => f.Code).ToList();
                        if (q.Count > 0)
                            epGroupAsliKalasBindingSource.DataSource = q;
                        else
                            epGroupAsliKalasBindingSource.DataSource = null;
                    }
                    else if (cmbDasteBandi.SelectedIndex == 1)
                    {
                        var q = db.EpGroupAsliKalas.Where(f => f.DasteBandiIndex == 1).OrderBy(f => f.Code).ToList();
                        if (q.Count > 0)
                            epGroupAsliKalasBindingSource.DataSource = q;
                        else
                            epGroupAsliKalasBindingSource.DataSource = null;
                    }
                    else if (cmbDasteBandi.SelectedIndex == 2)
                    {
                        var q = db.EpGroupAsliKalas.Where(f => f.DasteBandiIndex == 2).OrderBy(f => f.Code).ToList();
                        if (q.Count > 0)
                            epGroupAsliKalasBindingSource.DataSource = q;
                        else
                            epGroupAsliKalasBindingSource.DataSource = null;
                    }
                    else if (cmbDasteBandi.SelectedIndex == 3)
                    {
                        var q = db.EpGroupAsliKalas.Where(f => f.DasteBandiIndex == 3).OrderBy(f => f.Code).ToList();
                        if (q.Count > 0)
                            epGroupAsliKalasBindingSource.DataSource = q;
                        else
                            epGroupAsliKalasBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
                        if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                        {
                            var q1 = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == true && s.DasteBandiIndex == 0).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    gridControl1.DataSource = q1;
                                else
                                    gridControl1.DataSource = null;
                            }
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
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                        {
                            var q1 = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == true && s.DasteBandiIndex == 1).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    gridControl2.DataSource = q1;
                                else
                                    gridControl2.DataSource = null;
                            }
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
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                        {
                            var q1 = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == true && s.DasteBandiIndex == 2).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    gridControl3.DataSource = q1;
                                else
                                    gridControl3.DataSource = null;
                            }
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
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                        {
                            var q1 = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == true && s.DasteBandiIndex == 3).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    gridControl4.DataSource = q1;
                                else
                                    gridControl4.DataSource = null;
                            }
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
                    }
                    else
                    {
                        if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == false && s.DasteBandiIndex == 0).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    gridControl1.DataSource = q;
                                else
                                    gridControl1.DataSource = null;
                            }
                            else
                                gridControl1.DataSource = null;

                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == false && s.DasteBandiIndex == 1).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    gridControl2.DataSource = q;
                                else
                                    gridControl2.DataSource = null;
                            }
                            else
                                gridControl2.DataSource = null;

                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == false && s.DasteBandiIndex == 2).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    gridControl3.DataSource = q;
                                else
                                    gridControl3.DataSource = null;
                            }
                            else
                                gridControl3.DataSource = null;

                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupFareeKalas.Where(s => s.IsActive == false && s.DasteBandiIndex == 3).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    gridControl4.DataSource = q;
                                else
                                    gridControl4.DataSource = null;
                            }
                            else
                                gridControl4.DataSource = null;

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
                    int _GroupAsliId = Convert.ToInt32(cmbGroupAsli.EditValue);
                        var q = db.EpGroupFareeKalas.Where(f => f.GroupAsliId== _GroupAsliId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(4) != "9999")
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(4);
                            }
                            else
                            {
                                if (En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 10000 حساب گروه ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 10000 حساب گروه تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین صفر تا 10000 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = "0001";
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
        private void FrmGroupFareeKala_Load(object sender, EventArgs e)
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

        private bool Validation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text) || txtCode.Text=="0000")
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //else if (Convert.ToInt32(txtCode.Text) <= 100 || Convert.ToInt32(txtCode.Text) >= 1000)
            //{
            //    XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از 100 و کمتر از 1000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCode.Focus();
            //    return false;
            //}
            else if (Convert.ToInt32(cmbVahedKala.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً واحد گروه فرعی را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVahedKala.Focus();
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _Code = Convert.ToInt32(txtCodeGroup.Text + txtCode.Text);
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.EpGroupFareeKalas.FirstOrDefault(p => p.Code == _Code);
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
                            var q1 = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id != RowId && p.Code == _Code);
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
                XtraMessageBox.Show("لطفاً نام گروه فرعی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var q1 = db.EpGroupFareeKalas.FirstOrDefault(p => p.Name == txtName.Text);
                            if (q1 != null)
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id != RowId && p.Name == txtName.Text);
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

        private void FrmGroupFareeKala_KeyDown(object sender, KeyEventArgs e)
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
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                HelpClass1.MoveLast(gridView1);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                HelpClass1.MoveLast(gridView2);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                HelpClass1.MoveLast(gridView3);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                HelpClass1.MoveLast(gridView4);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                HelpClass1.MoveNext(gridView1);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                HelpClass1.MoveNext(gridView2);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                HelpClass1.MoveNext(gridView3);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                HelpClass1.MoveNext(gridView4);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                HelpClass1.MovePrev(gridView1);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                HelpClass1.MovePrev(gridView2);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                HelpClass1.MovePrev(gridView3);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                HelpClass1.MovePrev(gridView4);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                HelpClass1.MoveFirst(gridView1);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                HelpClass1.MoveFirst(gridView2);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                HelpClass1.MoveFirst(gridView3);
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                HelpClass1.MoveFirst(gridView4);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Visible)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                    HelpClass1.PrintPreview(gridControl1, gridView1);
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                    HelpClass1.PrintPreview(gridControl2, gridView2);
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                    HelpClass1.PrintPreview(gridControl3, gridView3);
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                    HelpClass1.PrintPreview(gridControl4, gridView4);

            }
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

        private void gridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_Click(null, null);
            }

        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Visible)
            {
                En = EnumCED.Create;
                xtraTabControl1.Enabled = false;
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1);
                HelpClass1.ActiveControls(panelControl1);
                FillcmbVahedKala();
                //cmbListGroupTafzili.EditValue = 1;
                //txtCodeGroupTafzili.Text = "10";
                //btnNewCode_Click(null, null);
                // cmbListGroupTafzili.EditValue = 13;
                cmbDasteBandi.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    if (gridView1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpGroupFareeKalas.Remove(q);
                                        //db.AllCodingHesabdaris.Remove(q8);
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
                                    XtraMessageBox.Show("حذف این  گروه اصلی مقدور نیست \n" +
                                        " جهت حذف گروه مورد نظر در ابتدا بایستی زیر مجموعه های این گروه در گروه فرعی  ونام کالاها حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                {
                    if (gridView2.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView2.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpGroupFareeKalas.Remove(q);
                                        //db.AllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl1);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این  گروه اصلی مقدور نیست \n" +
                                        " جهت حذف گروه مورد نظر در ابتدا بایستی زیر مجموعه های این گروه در گروه فرعی  ونام کالاها حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                {
                    if (gridView3.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView3.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpGroupFareeKalas.Remove(q);
                                        //db.AllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView3.RowCount > 0)
                                            gridView3.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl1);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این  گروه اصلی مقدور نیست \n" +
                                        " جهت حذف گروه مورد نظر در ابتدا بایستی زیر مجموعه های این گروه در گروه فرعی  ونام کالاها حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                {
                    if (gridView4.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView4.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView4.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int RowId = Convert.ToInt32(gridView4.GetFocusedRowCellValue("Id").ToString());
                                    var q = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id == RowId);
                                    //var q8 = db.AllCodingHesabdaris.FirstOrDefault(s => s.HesabColId == RowId);
                                    if (q != null /*&& q8 != null*/)
                                    {
                                        db.EpGroupFareeKalas.Remove(q);
                                        //db.AllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView4.RowCount > 0)
                                            gridView4.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl1);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این  گروه اصلی مقدور نیست \n" +
                                        " جهت حذف گروه مورد نظر در ابتدا بایستی زیر مجموعه های این گروه در گروه فرعی  ونام کالاها حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        public int EditRowIndex = 0;
        public int BefourEditIndexDasteBandi = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Visible)
            {
                BefourEditIndexDasteBandi = cmbDasteBandi.SelectedIndex;
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    if (gridView1.RowCount > 0)
                    {
                        xtraTabControl1.Enabled = false;
                        EditRowIndex = gridView1.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl2);
                        HelpClass1.ActiveControls(panelControl1);
                        FillcmbVahedKala();

                        cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("DasteBandiIndex"));
                        cmbGroupAsli.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupAsliId"));
                        txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                        txtCodeGroup.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                        txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(4);
                        txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VahedKalaId"));
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
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                {
                    if (gridView2.RowCount > 0)
                    {
                        xtraTabControl1.Enabled = false;
                        EditRowIndex = gridView2.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl2);
                        HelpClass1.ActiveControls(panelControl1);
                        FillcmbVahedKala();

                        cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView2.GetFocusedRowCellValue("DasteBandiIndex"));
                        cmbGroupAsli.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("GroupAsliId"));
                        txtId.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
                        txtCodeGroup.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                        txtCode.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(4);
                        txtName.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("VahedKalaId"));
                        chkIsActive.Checked = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab.Text = gridView2.GetFocusedRowCellValue("SharhHesab").ToString();

                        CodeBeforeEdit = txtCode.Text;
                        NameBeforeEdit = txtName.Text;
                        IsActiveBeforeEdit = chkIsActive.Checked;
                        //if (txtCode.Text == "99999")
                        //    btnNewCode.Enabled = false;
                        txtName.Focus();
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                {
                    if (gridView3.RowCount > 0)
                    {
                        xtraTabControl1.Enabled = false;
                        EditRowIndex = gridView3.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl2);
                        HelpClass1.ActiveControls(panelControl1);
                        FillcmbVahedKala();

                        cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView3.GetFocusedRowCellValue("DasteBandiIndex"));
                        cmbGroupAsli.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("GroupAsliId"));
                        txtId.Text = gridView3.GetFocusedRowCellValue("Id").ToString();
                        txtCodeGroup.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                        txtCode.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(4);
                        txtName.Text = gridView3.GetFocusedRowCellValue("Name").ToString();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("VahedKalaId"));
                        chkIsActive.Checked = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab.Text = gridView3.GetFocusedRowCellValue("SharhHesab").ToString();

                        CodeBeforeEdit = txtCode.Text;
                        NameBeforeEdit = txtName.Text;
                        IsActiveBeforeEdit = chkIsActive.Checked;
                        //if (txtCode.Text == "99999")
                        //    btnNewCode.Enabled = false;
                        txtName.Focus();
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                {
                    if (gridView4.RowCount > 0)
                    {
                        xtraTabControl1.Enabled = false;
                        EditRowIndex = gridView4.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl2);
                        HelpClass1.ActiveControls(panelControl1);
                        FillcmbVahedKala();

                        cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView4.GetFocusedRowCellValue("DasteBandiIndex"));
                        cmbGroupAsli.EditValue = Convert.ToInt32(gridView4.GetFocusedRowCellValue("GroupAsliId"));
                        txtId.Text = gridView4.GetFocusedRowCellValue("Id").ToString();
                        txtCodeGroup.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                        txtCode.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(4);
                        txtName.Text = gridView4.GetFocusedRowCellValue("Name").ToString();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView4.GetFocusedRowCellValue("VahedKalaId"));
                        chkIsActive.Checked = Convert.ToBoolean(gridView4.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab.Text = gridView4.GetFocusedRowCellValue("SharhHesab").ToString();

                        CodeBeforeEdit = txtCode.Text;
                        NameBeforeEdit = txtName.Text;
                        IsActiveBeforeEdit = chkIsActive.Checked;
                        //if (txtCode.Text == "99999")
                        //    btnNewCode.Enabled = false;
                        txtName.Focus();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (Validation())
                {
                    if (En == EnumCED.Create)
                    {
                        using (var db = new MyContext())
                        {
                            try
                            {
                                EpGroupFareeKala obj = new EpGroupFareeKala();
                                obj.DasteBandiIndex = cmbDasteBandi.SelectedIndex;
                                obj.DasteBandiName = cmbDasteBandi.Text;
                                obj.GroupAsliId = Convert.ToInt32(cmbGroupAsli.EditValue);
                                obj.GroupAsliName = cmbGroupAsli.Text;
                                obj.Code = Convert.ToInt32(txtCodeGroup.Text + txtCode.Text);
                                obj.Name = txtName.Text;
                                obj.VahedKalaId = Convert.ToInt32(cmbVahedKala.EditValue);
                                obj.VahedKalaName = cmbVahedKala.Text;
                                obj.IsActive = chkIsActive.Checked;
                                obj.SharhHesab = txtSharhHesab.Text;

                                db.EpGroupFareeKalas.Add(obj);
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafziliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafziliSandoghs.FirstOrDefault(s => s.Code == _Code);
                                //////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                //AllCodingHesabdari n1 = new AllCodingHesabdari();
                                //n1.KeyId = _Code;
                                //n1.ParentId = Convert.ToInt32(txtGroupCode.Text);
                                //n1.LevelName = txtName.Text;
                                //n1.HesabGroupId = q.GroupId;
                                //n1.HesabColId = q.Id;
                                //n1.IsActive = chkIsActive.Checked;
                                //db.AllCodingHesabdaris.Add(n1);
                                ///////////////////////////////////////////////////////////////////////////////////////
                                //db.SaveChanges();
                                xtraTabControl1.SelectedTabPageIndex = cmbDasteBandi.SelectedIndex;
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
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                var q = db.EpGroupFareeKalas.FirstOrDefault(p => p.Id == RowId);
                                if (q != null)
                                {
                                    q.DasteBandiIndex = cmbDasteBandi.SelectedIndex;
                                    q.DasteBandiName = cmbDasteBandi.Text;
                                    q.GroupAsliId = Convert.ToInt32(cmbGroupAsli.EditValue);
                                    q.GroupAsliName = cmbGroupAsli.Text;
                                    q.Code = Convert.ToInt32(txtCodeGroup.Text + txtCode.Text);
                                    q.Name = txtName.Text;
                                    q.VahedKalaId = Convert.ToInt32(cmbVahedKala.EditValue);
                                    q.VahedKalaName = cmbVahedKala.Text;
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
                                    //var q8 = db.AllCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.HesabColId == RowId).ToList();
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
                                    //    var a1 = db.AllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var a2 = db.AllCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
                                    //    var b1 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    //    //var b2 = db.RmsUserBallCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == RowId && p.HesabMoinId == 0);
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
                                    xtraTabControl1.SelectedTabPageIndex = cmbDasteBandi.SelectedIndex;
                                    if (IsActiveBeforeEdit)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    // XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (cmbDasteBandi.SelectedIndex == BefourEditIndexDasteBandi)
                                    {
                                        if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                                        {
                                            if (gridView1.RowCount > 0)
                                                gridView1.FocusedRowHandle = EditRowIndex;
                                        }
                                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
                                        {
                                            if (gridView2.RowCount > 0)
                                                gridView2.FocusedRowHandle = EditRowIndex;
                                        }
                                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                                        {
                                            if (gridView3.RowCount > 0)
                                                gridView3.FocusedRowHandle = EditRowIndex;
                                        }
                                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                                        {
                                            if (gridView4.RowCount > 0)
                                                gridView4.FocusedRowHandle = EditRowIndex;
                                        }
                                    }
                                    else
                                        btnLast_Click(null, null);

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
                xtraTabControl1.Enabled = true;
                En = EnumCED.Cancel;
                HelpClass1.ActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1);
                HelpClass1.InActiveControls(panelControl1);
                btnCreate.Focus();
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = gridView1.RowCount > 0 ? true : false;
        }


        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (gridView1.RowCount > 0)
                {
                    FillcmbVahedKala();

                    cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("DasteBandiIndex"));
                    cmbGroupAsli.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupAsliId"));
                    txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                    txtCodeGroup.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                    txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(4);
                    txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                    cmbVahedKala.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("VahedKalaId"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                if (gridView2.RowCount > 0)
                {
                    FillcmbVahedKala();

                    cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView2.GetFocusedRowCellValue("DasteBandiIndex"));
                    cmbGroupAsli.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("GroupAsliId"));
                    txtId.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
                    txtCodeGroup.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                    txtCode.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(4);
                    txtName.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                    cmbVahedKala.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("VahedKalaId"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView2.GetFocusedRowCellValue("SharhHesab").ToString();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                if (gridView3.RowCount > 0)
                {
                    FillcmbVahedKala();

                    cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView3.GetFocusedRowCellValue("DasteBandiIndex"));
                    cmbGroupAsli.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("GroupAsliId"));
                    txtId.Text = gridView3.GetFocusedRowCellValue("Id").ToString();
                    txtCodeGroup.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                    txtCode.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(4);
                    txtName.Text = gridView3.GetFocusedRowCellValue("Name").ToString();
                    cmbVahedKala.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("VahedKalaId"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView3.GetFocusedRowCellValue("SharhHesab").ToString();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            {
                if (gridView4.RowCount > 0)
                {
                    FillcmbVahedKala();

                    cmbDasteBandi.SelectedIndex = Convert.ToInt32(gridView4.GetFocusedRowCellValue("DasteBandiIndex"));
                    cmbGroupAsli.EditValue = Convert.ToInt32(gridView4.GetFocusedRowCellValue("GroupAsliId"));
                    txtId.Text = gridView4.GetFocusedRowCellValue("Id").ToString();
                    txtCodeGroup.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(0, 4);
                    txtCode.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(4);
                    txtName.Text = gridView4.GetFocusedRowCellValue("Name").ToString();
                    cmbVahedKala.EditValue = Convert.ToInt32(gridView4.GetFocusedRowCellValue("VahedKalaId"));
                    chkIsActive.Checked = Convert.ToBoolean(gridView4.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab.Text = gridView4.GetFocusedRowCellValue("SharhHesab").ToString();
                }
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);
        }

        private void gridView_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_RowCellClick(null, null);

        }

        private void cmbVahedKala_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedKala.ShowPopup();
            }
        }

        private void cmbDasteBandi_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbDasteBandi.ShowPopup();
            }

        }

        private void cmbDasteBandi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillcmbGroupAsli();
        }

        //private void txtCode_Leave(object sender, EventArgs e)
        //{
        //    if (cmbDasteBandi.SelectedIndex == 0)
        //    {
        //        if (Convert.ToInt32(txtCode.Text) > 1000 && Convert.ToInt32(txtCode.Text) < 3000)
        //            return;
        //        else
        //        {
        //            XtraMessageBox.Show("کد وارد شده بایستی عدد بین 1000 تا 3000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtCode.Focus();
        //        }
        //    }
        //    else if (cmbDasteBandi.SelectedIndex == 1)
        //    {
        //        if (Convert.ToInt32(txtCode.Text) > 3000 && Convert.ToInt32(txtCode.Text) < 5000)
        //            return;
        //        else
        //        {
        //            XtraMessageBox.Show("کد وارد شده بایستی عدد بین 3000 تا 5000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtCode.Focus();
        //        }
        //    }
        //    else if (cmbDasteBandi.SelectedIndex == 2)
        //    {
        //        if (Convert.ToInt32(txtCode.Text) > 5000 && Convert.ToInt32(txtCode.Text) < 7000)
        //            return;
        //        else
        //        {
        //            XtraMessageBox.Show("کد وارد شده بایستی عدد بین 5000 تا 7000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtCode.Focus();
        //        }
        //    }
        //    else if (cmbDasteBandi.SelectedIndex == 3)
        //    {
        //        if (Convert.ToInt32(txtCode.Text) > 7000 && Convert.ToInt32(txtCode.Text) < 9000)
        //            return;
        //        else
        //        {
        //            XtraMessageBox.Show("کد وارد شده بایستی عدد بین 7000 تا 9000 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtCode.Focus();
        //        }
        //    }

        //}

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            FillDataGrid();
        }

        private void cmbGroupAsli_EditValueChanged(object sender, EventArgs e)
        {
            int GroupAsliId = Convert.ToInt32(cmbGroupAsli.EditValue);
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpGroupAsliKalas.FirstOrDefault(f => f.Id == GroupAsliId);
                    if (q!=null)
                    {
                        cmbVahedKala.EditValue = q.VahedKalaId;
                        txtCodeGroup.Text = q.Code.ToString();
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

        private void cmbGroupAsli_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupAsli.ShowPopup();
            }

        }
    }
}