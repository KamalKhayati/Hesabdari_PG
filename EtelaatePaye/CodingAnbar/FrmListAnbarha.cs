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
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using EtelaatePaye.CodingHesabdari;

namespace EtelaatePaye.CodingAnbar
{
    public partial class FrmListAnbarha : DevExpress.XtraEditors.XtraForm
    {
        public FrmListAnbarha()
        {
            InitializeComponent();
        }

        public EnumCED En = EnumCED.None;
        int _SalId = 0;
        public void FillDataGrid()
        {
            MyContext dbContext = new MyContext();
            dbContext.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).LoadAsync().ContinueWith(loadTask =>
            {
                epListAnbarhasBindingSource.DataSource = dbContext.EpListAnbarhas.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

            #region MyRegion

            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            //        _SalId = Convert.ToInt32(lblSalId.Text);


            //        var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
            //        //foreach (var item in q1)
            //        //{
            //        //    //List<int> List1 = null;
            //        //    IList<int> List1 = new List<int>();
            //        //    //Array List2 = null;
            //        //    string _Id1 = String.Empty;
            //        //    if (item.TabagheKalaId != null)
            //        //    {
            //        //        char[] item1 = item.TabagheKalaId.ToArray();
            //        //        //string _Id = string.Empty;
            //        //        for (int i = 0; i < item1.Count(); i++)
            //        //        {
            //        //            if (i == 0)
            //        //            {
            //        //                _Id1 = _Id1 + item1[i].ToString();
            //        //            }
            //        //            else
            //        //            {
            //        //                if (item1[i] == ',')
            //        //                {
            //        //                    int _Id2 = Convert.ToInt32(_Id1);
            //        //                    List1.Add(_Id2);
            //        //                    _Id1 = String.Empty;
            //        //                }
            //        //                else
            //        //                {
            //        //                    _Id1 = _Id1 + item1[i].ToString();
            //        //                }

            //        //            }
            //        //        }

            //        //        string _KalaId = String.Empty;
            //        //        foreach (var item2 in List1)
            //        //        {
            //        //            _KalaId += db.EpTabaghehKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == item2).Name + ",";
            //        //        }
            //        //        item.TabagheKalaIdName_NM = _KalaId;
            //        //    }
            //        //}

            //        if (lblUserId.Text == "1")
            //        epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;
            //        //else
            //        //{
            //        //    int _UserId = Convert.ToInt32(lblUserId.Text);
            //        //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 ).Select(s => s.HesabMoinId).ToList();

            //        //    if (q1.Count > 0)
            //        //    {
            //        //        if (q2.Count > 0)
            //        //        {
            //        //            q2.ForEach(item2 =>
            //        //            {
            //        //                q1.Remove(dataContext.EpHesabTafsiliSandoghs.FirstOrDefault(s => s.Id == item2));
            //        //            });
            //        //            epHesabTafsiliSandoghsBindingSource.DataSource = q1;
            //        //        }
            //        //        else
            //        //        {
            //        //            epHesabTafsiliSandoghsBindingSource.DataSource = q1;
            //        //        }
            //        //    }
            //        //    else
            //        //        epHesabTafsiliSandoghsBindingSource.DataSource = null;
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
        }


        private void btnNewCode_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    if (q.Count > 0)
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
            xtraTabControl1.SelectedTabPageIndex = 1;
            xtraTabControl1.SelectedTabPageIndex = 0;

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
            if (btnClose.Enabled)
            {
                this.Close();

            }
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
            else if (Convert.ToInt32(cmbHesabMoin.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفا حساب معین را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabMoin.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili1.EditValue) == 0 && cmbHesabTafsili1.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفا حساب تفصیلی سطح یک را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili1.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili2.EditValue) == 0 && cmbHesabTafsili2.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفا حساب تفصیلی سطح دو را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili2.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbHesabTafsili3.EditValue) == 0 && cmbHesabTafsili3.ReadOnly == false)
            {
                XtraMessageBox.Show("لطفا حساب تفصیلی سطح سه را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHesabTafsili3.Focus();
                return false;
            }
            else if (cmbTabagheKala.EditValue == null || string.IsNullOrEmpty(cmbTabagheKala.EditValue.ToString()) || cmbTabagheKala.Text == "")
            {
                XtraMessageBox.Show("لطفاً ارتباط انبار با طبقه کالا را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                xtraTabControl1.SelectedTabPageIndex = 2;
                cmbTabagheKala.Focus();
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
            if (btnCreate.Enabled)
            {

                En = EnumCED.Create;
                gridControl1.Enabled = false;
                FillCmbHesabMoin();
                FillCmbTabagheKala();
                HelpClass1.InActiveButtons(panelControl2);
                HelpClass1.ClearControls(panelControl1_1);
                HelpClass1.ClearControls(panelControl1_2);
                HelpClass1.ClearControls(panelControl1_3);
                HelpClass1.ActiveControls(panelControl1_1);
                HelpClass1.ActiveControls(panelControl1_2);
                HelpClass1.ActiveControls(panelControl1_3);
                //cmbListGroupTafsili.EditValue = 1;
                //txtCodeGroupTafsili.Text = "10";
                cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                xtraTabControl1.SelectedTabPageIndex = 0;
                btnNewCode_Click(null, null);
                // cmbListGroupTafsili.EditValue = 13;
                chkIsActive.Checked = true;
                txtName.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (gridView1.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا انبار فوق حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
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
                                    HelpClass1.ClearControls(panelControl1_1);
                                    HelpClass1.ClearControls(panelControl1_2);
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
        IEnumerable<object> CheckedItemsBeforeEdit;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (gridView1.RowCount > 0)
                {
                    gridControl1.Enabled = false;
                    EditRowIndex = gridView1.FocusedRowHandle;
                    En = EnumCED.Edit;
                    HelpClass1.InActiveButtons(panelControl2);
                    HelpClass1.ActiveControls(panelControl1_1);
                    HelpClass1.ActiveControls(panelControl1_2);
                    HelpClass1.ActiveControls(panelControl1_3);

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
                    //CheckedItemsBeforeEdit = gridView1.GetFocusedRowCellValue("TabagheKalaId").ToString();
                    //if (txtCode.Text == "99999")
                    //    btnNewCode.Enabled = false;
                    cmbHesabTafsili1.ShowPopup();
                    cmbHesabTafsili1.ClosePopup();
                    cmbHesabTafsili2.ShowPopup();
                    cmbHesabTafsili2.ClosePopup();
                    cmbHesabTafsili3.ShowPopup();
                    cmbHesabTafsili3.ClosePopup();
                    //xtraTabControl1.SelectedTabPageIndex = 1;
                    //cmbTabagheKala.ShowPopup();
                    //cmbTabagheKala.ClosePopup();
                    //xtraTabControl1.SelectedTabPageIndex = 0;
                    if (gridView1.GetFocusedRowCellValue("TabagheKalaId") != null)
                        cmbTabagheKala.SetEditValue(gridView1.GetFocusedRowCellValue("TabagheKalaId"));

                    CheckedItemsBeforeEdit = cmbTabagheKala.Properties.GetItems().GetCheckedValues();
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
                                obj.MoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                var qq = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupName == "سایر");
                                obj.TafsiliId1 = Convert.ToInt32(cmbHesabTafsili1.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili1.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 1 && s.Name == "سایر 1").Id;
                                obj.TafsiliId2 = Convert.ToInt32(cmbHesabTafsili2.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili2.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 2 && s.Name == "سایر 2").Id;
                                obj.TafsiliId3 = Convert.ToInt32(cmbHesabTafsili3.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili3.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 3 && s.Name == "سایر 3").Id;

                                if (cmbTabagheKala.EditValue != null && cmbTabagheKala.EditValue.ToString() != "")
                                {
                                    //obj.TabagheKalaIdName = cmbTabagheKala.Text;

                                    string CheckedItems = string.Empty;
                                    var CheckedList = cmbTabagheKala.Properties.GetItems().GetCheckedValues();
                                    List<R_EpListAnbarha_B_EpTabaghehKala> obj03 = new List<R_EpListAnbarha_B_EpTabaghehKala>();
                                    if (CheckedList.Count > 0)
                                    {
                                        foreach (var item in CheckedList)
                                        {
                                            CheckedItems += item.ToString() + ",";

                                            R_EpListAnbarha_B_EpTabaghehKala obj1 = new R_EpListAnbarha_B_EpTabaghehKala();
                                            obj1.SalId = _SalId;
                                            //obj1.AnbarhId = _AnbarId;
                                            obj1.TabagheKalaId = Convert.ToInt32(item);
                                            obj03.Add(obj1);

                                        }
                                        obj.TabagheKalaId = CheckedItems;
                                        obj.TabagheKalaName = cmbTabagheKala.Text;
                                        obj.R_EpListAnbarha_B_EpTabaghehKalas = obj03;
                                    }
                                }

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
                                    q.MoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                    //q.TafsiliId1 = Convert.ToInt32(cmbHesabTafsili1.EditValue);
                                    //q.TafsiliId2 = Convert.ToInt32(cmbHesabTafsili2.EditValue);
                                    //q.TafsiliId3 = Convert.ToInt32(cmbHesabTafsili3.EditValue);
                                    var qq = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupName == "سایر");
                                    q.TafsiliId1 = Convert.ToInt32(cmbHesabTafsili1.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili1.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 1 && s.Name == "سایر 1").Id;
                                    q.TafsiliId2 = Convert.ToInt32(cmbHesabTafsili2.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili2.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 2 && s.Name == "سایر 2").Id;
                                    q.TafsiliId3 = Convert.ToInt32(cmbHesabTafsili3.EditValue) > 0 ? Convert.ToInt32(cmbHesabTafsili3.EditValue) : qq.FirstOrDefault(s => s.LevelNumber == 3 && s.Name == "سایر 3").Id;

                                    //cmbTabagheKala.ShowPopup();
                                    //cmbTabagheKala.ClosePopup();

                                    if (!string.IsNullOrEmpty(cmbTabagheKala.Text))
                                    {
                                        //q.TaminKonandeName = cmbTabagheKala.Text;

                                        string CheckedItems = string.Empty;
                                        var CheckedList = cmbTabagheKala.Properties.GetItems().GetCheckedValues();
                                        List<R_EpListAnbarha_B_EpTabaghehKala> obj03 = new List<R_EpListAnbarha_B_EpTabaghehKala>();

                                        var q3 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.AnbarhId == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            db.R_EpListAnbarha_B_EpTabaghehKalas.RemoveRange(q3);
                                        }

                                        if (CheckedList.Count > 0)
                                        {
                                            foreach (var item in CheckedList)
                                            {
                                                CheckedItems += item.ToString() + ",";

                                                R_EpListAnbarha_B_EpTabaghehKala obj1 = new R_EpListAnbarha_B_EpTabaghehKala();
                                                obj1.SalId = _SalId;
                                                //obj1.AnbarhId = _AnbarId;
                                                obj1.TabagheKalaId = Convert.ToInt32(item);
                                                obj03.Add(obj1);
                                            }
                                        }
                                        else
                                            CheckedItems = string.Empty;

                                        q.TabagheKalaId = CheckedItems;
                                        q.TabagheKalaName = cmbTabagheKala.Text;
                                        q.R_EpListAnbarha_B_EpTabaghehKalas = obj03;

                                    }

                                    if (cmbTabagheKala.EditValue != null)
                                    {
                                        int _AnbarId = Convert.ToInt32(txtId.Text);
                                        var CheckedList = cmbTabagheKala.Properties.GetItems().GetCheckedValues();
                                        if (CheckedItemsBeforeEdit.Count() > 0)
                                        {
                                            foreach (var TabagheKalaId in CheckedItemsBeforeEdit)
                                            {
                                                if (!CheckedList.Contains(TabagheKalaId))
                                                {
                                                    int _TabagheKalaId = Convert.ToInt32(TabagheKalaId);
                                                    string _TabagheKalaName = db.EpTabaghehKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _TabagheKalaId).Name;
                                                    //var q2 = db.EpTabaghehKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _Item1).Code;
                                                    var q4 = db.AmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AnbarId).Select(s => s.KalaId).Distinct().ToList();
                                                    if (q4.Count > 0)
                                                        foreach (var KalaId in q4)
                                                        {
                                                            var q3 = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == KalaId).EpGroupFareeKala1.EpGroupAsliKala1.TabaghehId;
                                                            if (q3 == _TabagheKalaId)
                                                            {
                                                                // XtraMessageBox.Show("ویرایش طبقه " + _TabagheKalaName + " مقدور نیست زیرا قبلاً توسط" + txtName.Text + " سند صادر شده",
                                                                // "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                                XtraMessageBox.Show("ویرایش طبقه " + _TabagheKalaName + " مقدور نیست زیرا با کالاهای زیر گروه این طبقه و با " + txtName.Text + " قبلاً سند صادر شده است",
                                                                                     "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                return;
                                                            }
                                                        }

                                                }
                                            }
                                        }
                                    }


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
            gridControl1.Enabled = true;
            En = EnumCED.Cancel;
            HelpClass1.ActiveButtons(panelControl2);
            HelpClass1.ClearControls(panelControl1_1);
            HelpClass1.ClearControls(panelControl1_2);
            HelpClass1.ClearControls(panelControl1_3);
            HelpClass1.InActiveControls(panelControl1_1);
            HelpClass1.InActiveControls(panelControl1_2);
            HelpClass1.InActiveControls(panelControl1_3);
            //cmbHesabMoin.EditValue = cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = null;
            //epHesabMoin1sBindingSource.DataSource = epHesabTafsiliAnbarhasBindingSource.DataSource = null;
            btnCreate.Focus();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {

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
                    try
                    {
                        FillCmbHesabMoin();
                        cmbHesabMoin.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MoinId").ToString());
                        // cmbHesabTafsili1.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TafsiliId").ToString());
                        int s1 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TafsiliId1").ToString());
                        int s2 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TafsiliId2").ToString());
                        int s3 = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TafsiliId3").ToString());
                        cmbHesabTafsili1.Text = new MyContext().EpAllHesabTafsilis.FirstOrDefault(s => s.Id == s1).Name;
                        cmbHesabTafsili2.Text = new MyContext().EpAllHesabTafsilis.FirstOrDefault(s => s.Id == s2).Name;
                        cmbHesabTafsili3.Text = new MyContext().EpAllHesabTafsilis.FirstOrDefault(s => s.Id == s3).Name;
                    }
                    catch (Exception es)
                    {
                        XtraMessageBox.Show("خطا در ارتباط انبار با کدینگ حسابداری" + "\n" + es.Message,
                                       "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    FillCmbTabagheKala();
                    if (gridView1.GetFocusedRowCellValue("TabagheKalaId") != null)
                        cmbTabagheKala.SetEditValue(gridView1.GetFocusedRowCellValue("TabagheKalaId"));
                    else
                        cmbTabagheKala.SetEditValue(0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                               "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void cmbHesabMoin_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void cmbHesabTafsili_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void cmbHesabMoin_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabMoin.ShowPopup();
            }
            memoEdit1.Text = "در این قسمت با توجه به نوع انبار ، حساب معین موجودی مواد ، کالا و یا محصول انتخاب شود";

        }

        public void FillCmbTabagheKala()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    epTabaghehKalasBindingSource.DataSource = q.Count > 0 && En != EnumCED.Create ? q : q.Count > 0 && En == EnumCED.Create ? q.Where(s => s.IsActive == true).ToList() : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillCmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    epHesabMoin1sBindingSource.DataSource = q.Count > 0 && En != EnumCED.Create ? q : q.Count > 0 && En == EnumCED.Create ? q.Where(s => s.IsActive == true).ToList() : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        List<EpAllHesabTafsili> list;
        //List<EpAllHesabTafsili_HesabMovaghat> list1;
        public void FillCmbHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    // list = null;
                    list = new List<EpAllHesabTafsili>();

                    var q1 = db.R_EpHesabMoin1_B_EpAllGroupTafsilis.Where(s => s.EpHesabMoin1Id == _HesabMoinId && s.SalId == _SalId).Select(s => s.AllGroupTafsiliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.GroupTafsiliId == item).OrderBy(s => s.Code).ToList();
                            list.AddRange(q);
                        }
                        #region MyRegion
                        // //db.EpAllHesabTafsilis.AddRange(list);
                        //// list1 = null;
                        // list1 = new List<EpAllHesabTafsili_HesabMovaghat>();
                        // foreach (var item in list)
                        // {
                        //     EpAllHesabTafsili_HesabMovaghat obj = new EpAllHesabTafsili_HesabMovaghat();
                        //     obj.Id = item.Id;
                        //     obj.SalId = item.SalId;
                        //     obj.LevelNumber = item.LevelNumber;
                        //     obj.Code = item.Code;
                        //     obj.Name = item.Name;
                        //     obj.GroupTafsiliId = item.GroupTafsiliId;
                        //     obj.MoinId = _HesabMoinId;
                        //     obj.IsActive = item.IsActive;
                        //     obj.IsDefault = item.IsDefault;
                        //     obj.SharhHesab = item.SharhHesab;
                        //     list1.Add(obj);
                        // }
                        // db.EpAllHesabTafsili_HesabMovaghats.AddRange(list1);

                        // //BindingSource bs = new BindingSource();
                        // //bs.DataSource = list;
                        // //BindingList<EpAllHesabTafsili> ok = new BindingList<EpAllHesabTafsili>(list);
                        // db.EpAllHesabTafsili_HesabMovaghats.Load();
                        // epHesabTafsiliAnbarhasBindingSource.DataSource = db.EpAllHesabTafsili_HesabMovaghats.Local.ToBindingList(); 
                        #endregion
                        cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.LevelNumber == 1).OrderBy(s => s.Code).Count() > 0 && En != EnumCED.Create ? list.Where(s => s.LevelNumber == 1).OrderBy(s => s.Code) : list.Where(s => s.LevelNumber == 1).OrderBy(s => s.Code).Count() > 0 && En == EnumCED.Create ? list.Where(s => s.LevelNumber == 1 && s.IsActive == true).OrderBy(s => s.Code) : null;
                        cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.LevelNumber == 2).OrderBy(s => s.Code).Count() > 0 && En != EnumCED.Create ? list.Where(s => s.LevelNumber == 2).OrderBy(s => s.Code) : list.Where(s => s.LevelNumber == 2).OrderBy(s => s.Code).Count() > 0 && En == EnumCED.Create ? list.Where(s => s.LevelNumber == 2 && s.IsActive == true).OrderBy(s => s.Code) : null;
                        cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.LevelNumber == 3).OrderBy(s => s.Code).Count() > 0 && En != EnumCED.Create ? list.Where(s => s.LevelNumber == 3).OrderBy(s => s.Code) : list.Where(s => s.LevelNumber == 3).OrderBy(s => s.Code).Count() > 0 && En == EnumCED.Create ? list.Where(s => s.LevelNumber == 3 && s.IsActive == true).OrderBy(s => s.Code) : null;
                    }
                    else
                    {
                        cmbHesabTafsili1.Properties.DataSource = null;
                        cmbHesabTafsili2.Properties.DataSource = null;
                        cmbHesabTafsili3.Properties.DataSource = null;

                    }

                    //if (_HesabMoinId == 14)
                    //{
                    //    cmbHesabTafsili.Properties.DataSource = db.EpAllHesabTafsilis.Where(s => s.GroupTafsiliId == 1 || s.GroupTafsiliId == 2).ToList();
                    //}
                    //else if (_HesabMoinId == 15)
                    //{
                    //    cmbHesabTafsili.Properties.DataSource = db.EpAllHesabTafsilis.Where(s => s.GroupTafsiliId == 3 || s.GroupTafsiliId == 4).ToList();
                    //}

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReloadHesabMoin_Click(object sender, EventArgs e)
        {
            FillCmbHesabMoin();
        }

        private void btnReloadHesabTafsili_Click(object sender, EventArgs e)
        {
            FillCmbHesabTafsili();
        }

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    FillCmbHesabTafsili();
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    var q = db.EpHesabMoin1s.FirstOrDefault(s => s.SalId == _SalId && s.Id == _HesabMoinId);
                    if (q != null)
                    {
                        //cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = 0;
                        switch (q.GroupTafsiliLevelsIndex)
                        {
                            case 0:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    cmbHesabTafsili1.EditValue = cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = 0;
                                    break;
                                }
                            case 1:
                                {
                                    cmbHesabTafsili1.ReadOnly = false;
                                    cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    cmbHesabTafsili2.EditValue = cmbHesabTafsili3.EditValue = 0;
                                    break;
                                }
                            case 2:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = false;
                                    cmbHesabTafsili3.ReadOnly = true;
                                    cmbHesabTafsili3.EditValue = 0;
                                    break;
                                }
                            case 3:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = false;
                                    break;
                                }
                            default:
                                break;
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

        private void cmbHesabMoin_Click(object sender, EventArgs e)
        {
        }

        private void cmbHesabTafsili2_Click(object sender, EventArgs e)
        {
        }

        private void cmbHesabTafsili3_Click(object sender, EventArgs e)
        {

        }

        private void cmbHesabTafsili1_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTafsili1.ShowPopup();
            }
            // memoEdit1.Text = "در قسمت اطلاعات پایه -> کدینگ حسابداری -> حسابهای تفصیلی سطح 1 -> در تب انبارها ، نام انبار مربوطه تعریف و در این قسمت انتخاب شود ضمناً ارتباط حساب معین با گروه تفصیلی انبارها در سطح یک داده شود";
            // memoEdit1.Text = "پیشنهاد : از قسمت اطلاعات پایه => کدینگ حسابداری => حسابهای تفصیلی سطح 1 => در تب انبارها ، انبار فعلی تعریف واز این قسمت انتخاب نمایید";
            //memoEdit1.Text = "پیشنهاد : در صورتیکه میخواهید در حسابداری زیر گروه حساب معین انبار ، لیست کالاها بیاید  " +
            //    "اولین کالای تعریف شده دراین قسمت انتخاب شود در غیر اینصورت سایر 1 را در این قسمت انتخاب نمایید";
            if (cmbHesabTafsili1.ReadOnly == false)
                memoEdit1.Text = " پیشنهاد : در صورتیکه واحد تجاری دارای چندین انبار می باشد  " +
                     "در قسمت اطلاعات پایه => کدینگ حسابداری => حسابهای تفصیلی سطح 1 => در تب انبارها ، " +
                     "نام انبار فعلی تعریف و در این قسمت انتخاب شود در غیر اینصورت گزینه سایر 1 را انتخاب نمایید";


        }

        private void cmbHesabTafsili2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTafsili2.ShowPopup();
            }
            if (cmbHesabTafsili2.ReadOnly == false)
                memoEdit1.Text = "پیشنهاد : در صورتیکه میخواهید در حسابداری در سطح دوم تفصیلی حساب معین انبار ، لیست کالاها بیاید  " +
                "اولین کالای تعریف شده دراین قسمت انتخاب شود در غیر اینصورت گزینه سایر 2 را انتخاب نمایید";

            //memoEdit1.Text = " پیشنهاد : در صورتیکه در حساب تفصیلی سطح 1  ، نام کالا انتخاب شده است و ضمناً واحد تجاری دارای چندین انبار می باشد  " +
            //                 "در قسمت اطلاعات پایه => کدینگ حسابداری => حسابهای تفصیلی سطح 2 => در تب انبارها ، " +
            //                 "نام انبار فعلی تعریف و در این قسمت انتخاب شود در غیر اینصورت گزینه سایر 2 را انتخاب نمایید";

            //memoEdit1.Text = "در قسمت اطلاعات پایه -> کدینگ حسابداری -> حسابهای تفصیلی سطح 1 -> " +
            //    "در تب انبارها ، نام انبار مربوطه تعریف و در این قسمت انتخاب شود ضمناً ارتباط حساب معین با گروه تفصیلی انبارها در سطح یک داده شود";
            //memoEdit1.Text = "پیشنهاد : در صورتیکه میخواهید در حسابداری ، زیر گروه حساب تفصیلی سطح 1 انبار ، لیست کالاها بیاید  " +
            //    "اولین کالای تعریف شده را دراین قسمت انتخاب نمایید در غیر اینصورت سایر 2 را در این قسمت انتخاب نمایید";

        }

        private void cmbHesabTafsili3_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbHesabTafsili3.ShowPopup();
            }
            if (cmbHesabTafsili3.ReadOnly == false)
                memoEdit1.Text = " پیشنهاد : در صورتیکه واحد تجاری بغیر از شعبه اصلی دارای شعبات وابسته و یا شعبات همگروه دیگری می باشد  " +
                             "در قسمت اطلاعات پایه => کدینگ حسابداری => حسابهای تفصیلی سطح 3 => در تب شعبات وابسته ،" +
                             " شعبه مورد نظر تعریف و در این قسمت انتخاب شود در غیر اینصورت گزینه سایر 3 را انتخاب نمایید";

        }

        private void cmbHesabTafsili2_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void cmbHesabTafsili3_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void chkIsActive_Leave(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            cmbHesabMoin.Focus();

        }

        private void cmbLookupEdit_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            HelpClass1._IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));

        }

        private void btnReloadTabagheKala_Click(object sender, EventArgs e)
        {
            FillCmbTabagheKala();
            //cmbTabagheKala.SetEditValue(0);

        }

        private void cmbHesabTafsili3_Leave(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 2;
            cmbTabagheKala.Focus();

        }

        private void cmbTabagheKala_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbTabagheKala.ShowPopup();
            }

        }

        private void btnCodingHesabdari_Click(object sender, EventArgs e)
        {
            FrmCodingHesabdari fm = new FrmCodingHesabdari();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();

        }

        private void btnHesabTafsili1_Click(object sender, EventArgs e)
        {
            FrmHesabhaTafsili fm = new FrmHesabhaTafsili();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm._levelNamber = 1;
            fm.Name = "FrmHesabhaTafsiliLevel1";
            fm.Text = "حسابهای تفصیلی سطح 1";
            fm.ShowDialog();

        }

        private void btnHesabTafsili2_Click(object sender, EventArgs e)
        {
            FrmHesabhaTafsili fm = new FrmHesabhaTafsili();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm._levelNamber = 2;
            fm.Name = "FrmHesabhaTafsiliLevel2";
            fm.Text = "حسابهای تفصیلی سطح 2";
            fm.ShowDialog();

        }

        private void btnHesabTafsili3_Click(object sender, EventArgs e)
        {
            FrmHesabhaTafsili fm = new FrmHesabhaTafsili();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm._levelNamber = 3;
            fm.Name = "FrmHesabhaTafsiliLevel3";
            fm.Text = "حسابهای تفصیلی سطح 3";
            fm.ShowDialog();

        }

        private void btnTabagheKala_Click(object sender, EventArgs e)
        {
            FrmCodingKala fm = new FrmCodingKala();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();

        }
    }
}