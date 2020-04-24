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
using DevExpress.XtraGrid;
using System.Data.Entity;
using HelpClassLibrary;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabhaTafsili : DevExpress.XtraEditors.XtraForm
    {
        public FrmHesabhaTafsili()
        {
            InitializeComponent();
        }

        EnumCED En;
        int _SalId = 0;
        public int _levelNamber = 0;
        string _SelectedTabPage = "";
        int _TabaghehIndex = 0;
        int _Carakter = 0;

        int _cmbGroupTafsiliId = 0;
        //string _cmbGroupTafsiliName = "";
        int _CodeTafsili = 0;
        //int _txtGroupCode = 0;
        //bool _chkEditCode = true;
        string _txtName = "";
        bool _IsActive = true;
        DateTime _TarikhEjad;
        string _txtSharh = "";

        GridControl gridControl;
        GridView gridView;
        LookUpEdit cmbGroupTafsili;
        SimpleButton btnReloadGroupTafsili;
        TextEdit txtCode;
        TextEdit txtGroupCode;
        CheckEdit chkEditCode;
        SimpleButton btnNewCode;
        TextEdit txtId;
        TextEdit txtName;
        TextEdit txtTarikhEjad;
        CheckEdit chkIsActive;
        TextEdit txtSharh;
        PanelControl PanelControl;

        int _CodeBeforeEdit = 0;
        int _GroupTafsiliIdBeforeEdit = 0;
        string _NameBeforeEdit = "";
        bool _IsActiveBeforeEdit = true;
        int EditRowIndex = 0;


        int _GroupTafsiliLevel1Carakter = 0;
        int _GroupTafsiliLevel2Carakter = 0;
        int _GroupTafsiliLevel3Carakter = 0;
        int _CodeTafsiliCarakter = 0;

        string _CodeTafsiliMinCode = "";
        string _CodeTafsiliMaxCode = "";

        string _NameBank = string.Empty;
        string _NameShobe = string.Empty;
        string _NoeHesab = string.Empty;
        string _ShomareHesab = string.Empty;


        public void FillGridViewHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                    if (lblUserId.Text == "1")
                    {
                        switch (_SelectedTabPage)
                        {
                            case "xtpAllHesabTafsili":
                                {
                                    var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpAshkhas":
                                {
                                    var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpAghlamAnbar":
                                {
                                    var q = db.EpHesabTafsiliAghlamAnbars.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpDaraeha":
                                {
                                    var q = db.EpHesabTafsiliDaraehas.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpSandoghha":
                                {
                                    var q = db.EpHesabTafsiliSandoghs.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpBankha":
                                {
                                    var q = db.EpHesabTafsiliBankhas.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpVamha":
                                {
                                    var q = db.EpHesabTafsiliVams.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpMarakezHazine":
                                {
                                    var q = db.EpHesabTafsiliMarakezHazines.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpShoabat":
                                {
                                    var q = db.EpHesabTafsiliShoabats.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpProzheha":
                                {
                                    var q = db.EpHesabTafsiliProzhes.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpGharardadha":
                                {
                                    var q = db.EpHesabTafsiliGharardads.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
                                    break;
                                }
                            case "xtpSayer":
                                {
                                    var q = db.EpHesabTafsiliSayers.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber).OrderBy(s => s.Code).ToList();
                                    gridControl.DataSource = q.Count > 0 ? q : null;
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

        public void FillcmbGroupTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    if (_levelNamber == 1)
                    {
                        var q = db.EpAllGroupTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex).OrderBy(s => s.KeyCode).ToList();
                        cmbGroupTafsili.Properties.DataSource = q.Count > 0 ? q : null;
                    }
                   else if (_levelNamber == 2)
                    {
                        var q = db.EpAllGroupTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.EpGroupTafsiliLevel2.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex).OrderBy(s => s.KeyCode).ToList();
                        cmbGroupTafsili.Properties.DataSource = q.Count > 0 ? q : null;
                    }
                   else if (_levelNamber == 3)
                    {
                        var q = db.EpAllGroupTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.EpGroupTafsiliLevel3.EpGroupTafsiliLevel2.EpGroupTafsiliLevel1.TabaghehIndex == _TabaghehIndex).OrderBy(s => s.KeyCode).ToList();
                        cmbGroupTafsili.Properties.DataSource = q.Count > 0 ? q : null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillcmbNameBank()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpNameBanks.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    cmbNameBank_Bank.Properties.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillcmbNoeHesab()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpNoeHesabs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    cmbNoeHesab_Bank.Properties.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNoeArz()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpNoeArzs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    cmbNoeArz_Bank.Properties.DataSource = q.Count > 0 ? q : null;
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
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.GroupTafsiliId == _cmbGroupTafsiliId).OrderBy(s => s.Code).ToList();

                    if (q.Count > 0)
                    {
                        var MaximumCod = q.Max(p => p.Code);
                        if (MaximumCod.ToString().Substring(_Carakter) != _CodeTafsiliMaxCode)
                        {
                            txtCode.Text = (MaximumCod + 1).ToString().Substring(_Carakter);
                        }
                        else
                        {
                            XtraMessageBox.Show("اعمال محدودیت تعریف  " + _CodeTafsiliMaxCode + " حساب تفضیلی برای هر گروه تفضیلی ..." + "\n" +
                                "توجه : نمیتوان بیشتر از  " + _CodeTafsiliMaxCode + "  حساب تفضیلی برای هر گروه تفضیلی تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        txtCode.Text = _CodeTafsiliMinCode;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmHesabhaTafsili_Load(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            btnJoziatAshkhas.Visible = false;
            gridControl = gridControl_AllHesabTafsili;
            gridView = gridView_AllHesabTafsili;
            _SelectedTabPage = xtcHesabhaTafsili.SelectedTabPage.Name;
            FillGridViewHesabTafsili();
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;

            using (var db = new MyContext())
            {
                try
                {
                    //int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpTanzimatGroupTafsilis.FirstOrDefault();
                    if (q != null)
                    {
                        _GroupTafsiliLevel1Carakter = q.GroupTafsiliLevel1Carakter;
                        _GroupTafsiliLevel2Carakter = q.GroupTafsiliLevel2Carakter;
                        _GroupTafsiliLevel3Carakter = q.GroupTafsiliLevel3Carakter;
                        _CodeTafsiliCarakter = q.CodeTafsiliCarakter;

                        _CodeTafsiliMinCode = q.CodeTafsiliMinCode;
                        _CodeTafsiliMaxCode = q.CodeTafsiliMaxCode;

                        //txtCode_1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        //txtCode_1.Properties.Mask.EditMask = "00";
                        //txtCode_1.Properties.MaxLength = _GroupTafsiliLevel1Carakter;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
            if (Convert.ToInt32(_cmbGroupTafsiliId) == 0)
            {
                XtraMessageBox.Show("لطفاً گروه تفصیلی را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGroupTafsili.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtCode.Text) < Convert.ToInt32(_CodeTafsiliMinCode) || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_CodeTafsiliMaxCode))
            {
                XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از  " + _CodeTafsiliMinCode + " تا " + _CodeTafsiliMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(_txtName) || _txtName == "0")
            {
                XtraMessageBox.Show("لطفاً نام حساب تفضیلی را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (xtcHesabhaTafsili.SelectedTabPage.Name == "xtpBankha")
            {
                if (string.IsNullOrEmpty(txtShomareHesab_Bank.Text))
                {
                    XtraMessageBox.Show("لطفاً شماره حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtShomareHesab_Bank.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNameShobe_Bank.Text))
                {
                    XtraMessageBox.Show("لطفاً نام شعبه را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNameShobe_Bank.Focus();
                    return false;
                }
                else if (Convert.ToInt32(cmbNameBank_Bank.EditValue) == 0)
                {
                    XtraMessageBox.Show("لطفاً نام بانک را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNameBank_Bank.Focus();
                    return false;
                }
                else if (Convert.ToInt32(cmbNoeHesab_Bank.EditValue) == 0)
                {
                    XtraMessageBox.Show("لطفاً نوع حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNoeHesab_Bank.Focus();
                    return false;
                }
                else if (Convert.ToInt32(cmbNoeArz_Bank.EditValue) == 0)
                {
                    XtraMessageBox.Show("لطفاً نوع ارز را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNoeArz_Bank.Focus();
                    return false;
                }

            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _CodeTafsili = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                        _SalId = Convert.ToInt32(lblSalId.Text);

                        if (En == EnumCED.Create)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.GroupTafsiliId == _cmbGroupTafsiliId).ToList();
                            if (q.Count > 0)
                            {
                                var q1 = q.FirstOrDefault(s => s.Code == _CodeTafsili);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                                var q2 = q.FirstOrDefault(s => s.Name == _txtName);
                                if (q2 != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpAllHesabTafsilis.Where(s => s.Id != RowId && s.SalId == _SalId && s.LevelNamber == _levelNamber && s.GroupTafsiliId == _cmbGroupTafsiliId).ToList();
                            if (q.Count > 0)
                            {
                                var q1 = q.FirstOrDefault(s => s.Code == _CodeTafsili);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);
                                    return false;
                                }
                                var q2 = q.FirstOrDefault(s => s.Name == txtName.Text);
                                if (q2 != null)
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
                }
            }
            return true;
        }

        private void FrmHesabhaTafsili_KeyDown(object sender, KeyEventArgs e)
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
            HelpClass1.MoveLast(gridView);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Visible)
                HelpClass1.PrintPreview(gridControl, gridView);
        }

        public void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillGridViewHesabTafsili();
        }

        private void gridView_KeyPress(object sender, KeyPressEventArgs e)
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
                gridControl.Enabled = false;
                HelpClass1.InActiveButtons(panelControl1);
                HelpClass1.ClearControls(PanelControl);
                HelpClass1.ActiveControls(PanelControl);
                chkIsActive.Checked = true;
                chkHaghighi_Ashkhas.Checked = true;
                txtTarikhEjad.Text = DateTime.Now.ToString().Substring(0, 10);
                FillcmbGroupTafsili();
                cmbGroupTafsili.Focus();
                if (xtcHesabhaTafsili.SelectedTabPage.Name == "xtpBankha")
                    FillcmbNameBank(); FillcmbNoeHesab(); FillcmbNoeArz();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب تفضیلی مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        _IsActiveBeforeEdit = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int RowId = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpAllHesabTafsilis.FirstOrDefault(s => s.SalId == _SalId && s.LevelNamber == _levelNamber && s.Id == RowId);
                                if (q != null)
                                {
                                    db.EpAllHesabTafsilis.Remove(q);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    btnDisplyList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView.RowCount > 0)
                                        gridView.FocusedRowHandle = EditRowIndex - 1;
                                    // HelpClass1.ClearControls(panelControl1);
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                XtraMessageBox.Show("حذف این حساب تفضیلی مقدور نیست \n" +
                                    " زیرا با حساب تفضیلی فوق سند صادر گردیده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Visible)
            {
                if (gridView.RowCount > 0)
                {
                        gridControl.Enabled = false;
                        EditRowIndex = gridView.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl1);
                        HelpClass1.ActiveControls(PanelControl);
                        FillcmbGroupTafsili();
                        if (xtcHesabhaTafsili.SelectedTabPage.Name == "xtpBankha")
                            FillcmbNameBank(); FillcmbNoeHesab(); FillcmbNoeArz();

                        //cmbListGroupTafsili.EditValue = Convert.ToInt32(gridView1.GetFocusedRowCellValue("GroupTafsiliId")); ;
                        //txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                        //txtCodeGroupTafsili.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(0, 2);
                        //txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                        //txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                        //txtTarikhEjad_Ashkhas.Text = gridView1.GetFocusedRowCellValue("TarikhEjad") != null ? gridView1.GetFocusedRowCellValue("TarikhEjad").ToString().Substring(0, 10) : "";
                        //chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        //txtSharhHesab.Text = gridView1.GetFocusedRowCellValue("SharhHesab").ToString();
                        //chkPersonel.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsPersonel"));
                        //chkSahamdar.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsSahamdar"));
                        //chkVizitor.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsVizitor"));
                        //chkRanande.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsRanande"));

                        _CodeBeforeEdit = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                        _NameBeforeEdit = txtName.Text;
                        _IsActiveBeforeEdit = chkIsActive.Checked;
                        _GroupTafsiliIdBeforeEdit = Convert.ToInt32(cmbGroupTafsili.EditValue);
                        cmbGroupTafsili.Focus();
                }
            }
        }

        EpHesabTafsiliAshkhas objAshkhas;
        EpHesabTafsiliAghlamAnbar objAghlamAnbar;
        EpHesabTafsiliDaraeha objDaraeha;
        EpHesabTafsiliSandogh objSandogh;
        EpHesabTafsiliBankha objBankha;
        EpHesabTafsiliVam objVamha;
        EpHesabTafsiliMarakezHazine objMarakez;
        EpHesabTafsiliShoabat objShoabat;
        EpHesabTafsiliProzhe objProzhe;
        EpHesabTafsiliGharardad objGharardad;
        EpHesabTafsiliSayer objSayer;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                _SalId = Convert.ToInt32(lblSalId.Text);
                _cmbGroupTafsiliId = Convert.ToInt32(cmbGroupTafsili.EditValue);
                _CodeTafsili = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                _txtName = txtName.Text.Trim();
                _IsActive = chkIsActive.Checked;
                _TarikhEjad = !string.IsNullOrEmpty(txtTarikhEjad.Text) ? Convert.ToDateTime(txtTarikhEjad.Text) : DateTime.Now;
                _txtSharh = txtSharh.Text.Trim();

                if (TextEditValidation())
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (En == EnumCED.Create)
                            {
                                switch (_SelectedTabPage)
                                {
                                    case "xtpAshkhas":
                                        {
                                            objAshkhas = new EpHesabTafsiliAshkhas();
                                            objAshkhas.SalId = _SalId;
                                            objAshkhas.LevelNamber = _levelNamber;
                                            objAshkhas.Code = _CodeTafsili;
                                            objAshkhas.Name = _txtName;
                                            objAshkhas.TarikhEjad = _TarikhEjad;
                                            objAshkhas.IsActive = _IsActive;
                                            objAshkhas.SharhHesab = _txtSharh;
                                            objAshkhas.GroupTafsiliId = _cmbGroupTafsiliId;
                                            objAshkhas.IsHaghighi = chkHaghighi_Ashkhas.Checked;
                                            objAshkhas.IsHoghoghi = chkHoghoghi_Ashkhas.Checked;
                                            objAshkhas.IsPersonel = chkPersonel_Ashkhas.Checked;
                                            objAshkhas.IsSahamdar = chkSahamdar_Ashkhas.Checked;
                                            objAshkhas.IsVizitor = chkVizitor_Ashkhas.Checked;
                                            objAshkhas.IsRanande = chkRanande_Ashkhas.Checked;
                                            objAshkhas.IsKharidar = chkKharidar_Ashkhas.Checked;
                                            objAshkhas.IsFroshandeh = chkFroshandeh_Ashkhas.Checked;
                                            break;
                                        }
                                    case "xtpAghlamAnbar":
                                        {
                                            objAghlamAnbar = new EpHesabTafsiliAghlamAnbar();
                                            objAghlamAnbar.SalId = _SalId;
                                            objAghlamAnbar.LevelNamber = _levelNamber;
                                            objAghlamAnbar.Code = _CodeTafsili;
                                            objAghlamAnbar.Name = _txtName;
                                            objAghlamAnbar.TarikhEjad = _TarikhEjad;
                                            objAghlamAnbar.IsActive = _IsActive;
                                            objAghlamAnbar.SharhHesab = _txtSharh;
                                            objAghlamAnbar.GroupTafsiliId = _cmbGroupTafsiliId;
                                            objAghlamAnbar.CodeKala = !string.IsNullOrEmpty(txtCodeKala_Aghlam.Text) ? Convert.ToInt32(txtCodeKala_Aghlam.Text) : 0;
                                            break;
                                        }
                                    case "xtpDaraeha":
                                        {
                                            objDaraeha = new EpHesabTafsiliDaraeha();
                                            objDaraeha.SalId = _SalId;
                                            objDaraeha.LevelNamber = _levelNamber;
                                            objDaraeha.Code = _CodeTafsili;
                                            objDaraeha.Name = _txtName;
                                            objDaraeha.TarikhEjad = _TarikhEjad;
                                            objDaraeha.IsActive = _IsActive;
                                            objDaraeha.SharhHesab = _txtSharh;
                                            objDaraeha.GroupTafsiliId = _cmbGroupTafsiliId;
                                            objDaraeha.CodeAmval = !string.IsNullOrEmpty(txtCodeAmval_Daraeha.Text) ? Convert.ToInt32(txtCodeAmval_Daraeha.Text) : 0;
                                            objDaraeha.IndexRaveshEstehlak = cmbRaveshEstehlak_Daraeha.SelectedIndex != -1 ? Convert.ToInt32(cmbRaveshEstehlak_Daraeha.SelectedIndex) : -1;
                                            objDaraeha.RaveshEstehlak = cmbRaveshEstehlak_Daraeha.SelectedIndex != -1 ? cmbRaveshEstehlak_Daraeha.Text : "";
                                            objDaraeha.OmreMofid = !string.IsNullOrEmpty(txtOmreMofid_Daraeha.Text) ? Convert.ToInt32(txtOmreMofid_Daraeha.Text) : 0;
                                            objDaraeha.DarsadEstehlak = !string.IsNullOrEmpty(txtDarsadEstehlak_Daraeha.Text) ? Convert.ToSingle(txtDarsadEstehlak_Daraeha.Text) : 0;
                                            objDaraeha.ArzeshEsghat = !string.IsNullOrEmpty(txtArzeshEsghat_Daraeha.Text) ? Convert.ToDecimal(txtArzeshEsghat_Daraeha.Text) : 0;
                                            break;
                                        }
                                    case "xtpSandoghha":
                                        {
                                            objSandogh = new EpHesabTafsiliSandogh();
                                            objSandogh.SalId = _SalId;
                                            objSandogh.LevelNamber = _levelNamber;
                                            objSandogh.Code = _CodeTafsili;
                                            objSandogh.Name = _txtName;
                                            objSandogh.TarikhEjad = _TarikhEjad;
                                            objSandogh.IsActive = _IsActive;
                                            objSandogh.SharhHesab = _txtSharh;
                                            objSandogh.GroupTafsiliId = _cmbGroupTafsiliId;
                                            objSandogh.NameMasol = txtNameMasol_Sandogh.Text;
                                            objSandogh.IsDefault = chkIsDefault_Sandogh.Checked;
                                            break;
                                        }
                                    case "xtpBankha":
                                        {
                                            objBankha = new EpHesabTafsiliBankha();
                                            objBankha.SalId = _SalId;
                                            objBankha.LevelNamber = _levelNamber;
                                            objBankha.Code = _CodeTafsili;
                                            objBankha.Name = _txtName;
                                            objBankha.TarikhEjad = _TarikhEjad;
                                            objBankha.IsActive = _IsActive;
                                            objBankha.SharhHesab = _txtSharh;
                                            objBankha.GroupTafsiliId = _cmbGroupTafsiliId;
                                            objBankha.NameBank = cmbNameBank_Bank.Text;
                                            objBankha.NameShobe = txtNameShobe_Bank.Text;
                                            objBankha.CodeShobe = txtCodeShobe_Bank.Text;
                                            objBankha.NoeHesab = cmbNoeHesab_Bank.Text;
                                            objBankha.ShomareHesab = txtShomareHesab_Bank.Text;
                                            objBankha.ShomareKart = txtShomareKart_Bank.Text;
                                            objBankha.ShomareShaba = txtShomareShaba_Bank.Text;
                                            objBankha.ShomareMoshtari = txtShomareMoshtari_Bank.Text;
                                            objBankha.NoeArz = cmbNoeArz_Bank.Text;
                                            objBankha.IsDefault = chkIsDefault_Bank.Checked;
                                            objBankha.NameBankId = Convert.ToInt32(cmbNameBank_Bank.EditValue);
                                            objBankha.NoeHesaId = Convert.ToInt32(cmbNoeHesab_Bank.EditValue);
                                            objBankha.NoeArzId = Convert.ToInt32(cmbNoeArz_Bank.EditValue);
                                            break;
                                        }
                                    case "xtpVamha":
                                        {
                                            objVamha = new EpHesabTafsiliVam();
                                            objVamha.SalId = _SalId;
                                            objVamha.LevelNamber = _levelNamber;
                                            objVamha.Code = _CodeTafsili;
                                            objVamha.Name = _txtName;
                                            objVamha.TarikhEjad = _TarikhEjad;
                                            objVamha.IsActive = _IsActive;
                                            objVamha.SharhHesab = _txtSharh;
                                            objVamha.GroupTafsiliId = _cmbGroupTafsiliId;
                                            if (!string.IsNullOrEmpty(txtTarikhDaryaftVam_Vam.Text))
                                                objVamha.TarikhDaryaftVam = Convert.ToDateTime(txtTarikhDaryaftVam_Vam.Text);
                                            objVamha.IndexNoeVam = cmbNoeVam_Vam.SelectedIndex;
                                            objVamha.NoeVam = cmbNoeVam_Vam.Text;
                                            objVamha.TedadAghsat = !string.IsNullOrEmpty(txtTedadAghsat_Vam.Text) ? Convert.ToInt32(txtTedadAghsat_Vam.Text) : 0;
                                            if (!string.IsNullOrEmpty(txtSarresidAvalinGhest_Vam.Text))
                                                objVamha.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest_Vam.Text);
                                            objVamha.NerkhBahre = !string.IsNullOrEmpty(txtNerkhBahre_Vam.Text) ? Convert.ToSingle(txtNerkhBahre_Vam.Text) : 0;
                                            break;
                                        }
                                    case "xtpMarakezHazine":
                                        {
                                            objMarakez = new EpHesabTafsiliMarakezHazine();
                                            objMarakez.SalId = _SalId;
                                            objMarakez.LevelNamber = _levelNamber;
                                            objMarakez.Code = _CodeTafsili;
                                            objMarakez.Name = _txtName;
                                            objMarakez.TarikhEjad = _TarikhEjad;
                                            objMarakez.IsActive = _IsActive;
                                            objMarakez.SharhHesab = _txtSharh;
                                            objMarakez.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpShoabat":
                                        {
                                            objShoabat = new EpHesabTafsiliShoabat();
                                            objShoabat.SalId = _SalId;
                                            objShoabat.LevelNamber = _levelNamber;
                                            objShoabat.Code = _CodeTafsili;
                                            objShoabat.Name = _txtName;
                                            objShoabat.TarikhEjad = _TarikhEjad;
                                            objShoabat.IsActive = _IsActive;
                                            objShoabat.SharhHesab = _txtSharh;
                                            objShoabat.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpProzheha":
                                        {
                                            objProzhe = new EpHesabTafsiliProzhe();
                                            objProzhe.SalId = _SalId;
                                            objProzhe.LevelNamber = _levelNamber;
                                            objProzhe.Code = _CodeTafsili;
                                            objProzhe.Name = _txtName;
                                            objProzhe.TarikhEjad = _TarikhEjad;
                                            objProzhe.IsActive = _IsActive;
                                            objProzhe.SharhHesab = _txtSharh;
                                            objProzhe.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpGharardadha":
                                        {
                                            objGharardad = new EpHesabTafsiliGharardad();
                                            objGharardad.SalId = _SalId;
                                            objGharardad.LevelNamber = _levelNamber;
                                            objGharardad.Code = _CodeTafsili;
                                            objGharardad.Name = _txtName;
                                            objGharardad.TarikhEjad = _TarikhEjad;
                                            objGharardad.IsActive = _IsActive;
                                            objGharardad.SharhHesab = _txtSharh;
                                            objGharardad.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpSayer":
                                        {
                                            objSayer = new EpHesabTafsiliSayer();
                                            objSayer.SalId = _SalId;
                                            objSayer.LevelNamber = _levelNamber;
                                            objSayer.Code = _CodeTafsili;
                                            objSayer.Name = _txtName;
                                            objSayer.TarikhEjad = _TarikhEjad;
                                            objSayer.IsActive = _IsActive;
                                            objSayer.SharhHesab = _txtSharh;
                                            objSayer.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    default:
                                        break;
                                }




                                //////////////////////////////////////////////////////////////

                                EpAllHesabTafsili obj1 = new EpAllHesabTafsili();
                                obj1.SalId = _SalId;
                                obj1.LevelNamber = _levelNamber;
                                obj1.Code = _CodeTafsili;
                                obj1.Name = _txtName;
                                obj1.GroupTafsiliId = _cmbGroupTafsiliId;
                                obj1.IsActive = _IsActive;
                                obj1.SharhHesab = _txtSharh;
                                switch (_SelectedTabPage)
                                {
                                    case "xtpAshkhas":
                                        {
                                            obj1.EpHesabTafsiliAshkhas1 = objAshkhas;
                                            break;
                                        }
                                    case "xtpAghlamAnbar":
                                        {
                                            obj1.EpHesabTafsiliAghlamAnbar1 = objAghlamAnbar;
                                            break;
                                        }
                                    case "xtpDaraeha":
                                        {
                                            obj1.EpHesabTafsiliDaraeha1 = objDaraeha;
                                            break;
                                        }
                                    case "xtpSandoghha":
                                        {
                                            obj1.EpHesabTafsiliSandogh1 = objSandogh;
                                            break;
                                        }
                                    case "xtpBankha":
                                        {
                                            obj1.EpHesabTafsiliBankha1 = objBankha;
                                            break;
                                        }
                                    case "xtpVamha":
                                        {
                                            obj1.EpHesabTafsiliVam1 = objVamha;
                                            break;
                                        }
                                    case "xtpMarakezHazine":
                                        {
                                            obj1.EpHesabTafsiliMarakezHazine1 = objMarakez;
                                            break;
                                        }
                                    case "xtpShoabat":
                                        {
                                            obj1.EpHesabTafsiliShoabat1 = objShoabat;
                                            break;
                                        }
                                    case "xtpProzheha":
                                        {
                                            obj1.EpHesabTafsiliProzhe1 = objProzhe;
                                            break;
                                        }
                                    case "xtpGharardadha":
                                        {
                                            obj1.EpHesabTafsiliGharardad1 = objGharardad;
                                            break;
                                        }
                                    case "xtpSayer":
                                        {
                                            obj1.EpHesabTafsiliSayer1 = objSayer;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                db.EpAllHesabTafsilis.Add(obj1);
                                db.SaveChanges();

                                /////////////////////////////////////////////////////////////////////////////////////
                                //int _Code = Convert.ToInt32(txtCodeGroupTafsiliSandogh.Text + txtCode.Text);
                                //var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _Code);
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
                                btnLast_Click(null, null);
                                En = EnumCED.Save;

                                switch (_SelectedTabPage)
                                {
                                    case "xtpAshkhas":
                                        {
                                            if (XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد" + "\n" + "آیا مایلید اطلاعات بیشتری برای این حساب تفضیلی تعریف کنید ؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
                                                //fm.MdiParent = this;
                                                fm.lblUserId.Text = lblUserId.Text;
                                                fm.lblUserName.Text = lblUserName.Text;
                                                fm.lblSalId.Text = lblSalId.Text;
                                                fm.lblSalMali.Text = lblSalMali.Text;
                                                //fm._levelNamber = _levelNamber;
                                                fm._GroupTafsiliId = _cmbGroupTafsiliId;
                                                var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _CodeTafsili && s.SalId == _SalId && s.LevelNamber == _levelNamber);
                                                if (q != null)
                                                    fm._AshkhasId = q.Id;
                                                fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
                                                fm.btnReloadGroupTafsili_Ashkhas.Enabled = fm.btnReloadHesabTafsili_Ashkhas.Enabled = false;
                                                fm.ShowDialog();
                                            }
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q = db.EpAllHesabTafsilis.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId && s.LevelNamber == _levelNamber);
                                if (q != null)
                                {
                                    //q.SalId = _SalId;
                                    //q.LevelNamber = _levelNamber;
                                    q.Code = _CodeTafsili;
                                    q.Name = _txtName;
                                    q.GroupTafsiliId = _cmbGroupTafsiliId;
                                    q.IsActive = _IsActive;
                                    q.SharhHesab = _txtSharh;

                                }
                                switch (_SelectedTabPage)
                                {
                                    case "xtpAshkhas":
                                        {
                                            q.EpHesabTafsiliAshkhas1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliAshkhas1.Name = _txtName;
                                            q.EpHesabTafsiliAshkhas1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliAshkhas1.IsActive = _IsActive;
                                            q.EpHesabTafsiliAshkhas1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliAshkhas1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            q.EpHesabTafsiliAshkhas1.IsHaghighi = chkHaghighi_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsHoghoghi = chkHoghoghi_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsPersonel = chkPersonel_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsSahamdar = chkSahamdar_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsVizitor = chkVizitor_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsRanande = chkRanande_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsKharidar = chkKharidar_Ashkhas.Checked;
                                            q.EpHesabTafsiliAshkhas1.IsFroshandeh = chkFroshandeh_Ashkhas.Checked;
                                            break;
                                        }
                                    case "xtpAghlamAnbar":
                                        {
                                            q.EpHesabTafsiliAghlamAnbar1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliAghlamAnbar1.Name = _txtName;
                                            q.EpHesabTafsiliAghlamAnbar1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliAghlamAnbar1.IsActive = _IsActive;
                                            q.EpHesabTafsiliAghlamAnbar1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliAghlamAnbar1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            q.EpHesabTafsiliAghlamAnbar1.CodeKala = !string.IsNullOrEmpty(txtCodeKala_Aghlam.Text) ? Convert.ToInt32(txtCodeKala_Aghlam.Text) : 0;
                                            break;
                                        }
                                    case "xtpDaraeha":
                                        {
                                            q.EpHesabTafsiliDaraeha1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliDaraeha1.Name = _txtName;
                                            q.EpHesabTafsiliDaraeha1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliDaraeha1.IsActive = _IsActive;
                                            q.EpHesabTafsiliDaraeha1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliDaraeha1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            q.EpHesabTafsiliDaraeha1.CodeAmval = !string.IsNullOrEmpty(txtCodeAmval_Daraeha.Text) ? Convert.ToInt32(txtCodeAmval_Daraeha.Text) : 0;
                                            q.EpHesabTafsiliDaraeha1.IndexRaveshEstehlak = cmbRaveshEstehlak_Daraeha.SelectedIndex != -1 ? Convert.ToInt32(cmbRaveshEstehlak_Daraeha.SelectedIndex) : -1;
                                            q.EpHesabTafsiliDaraeha1.RaveshEstehlak = cmbRaveshEstehlak_Daraeha.SelectedIndex != -1 ? cmbRaveshEstehlak_Daraeha.Text : "";
                                            q.EpHesabTafsiliDaraeha1.OmreMofid = !string.IsNullOrEmpty(txtOmreMofid_Daraeha.Text) ? Convert.ToInt32(txtOmreMofid_Daraeha.Text) : 0;
                                            q.EpHesabTafsiliDaraeha1.DarsadEstehlak = !string.IsNullOrEmpty(txtDarsadEstehlak_Daraeha.Text) ? Convert.ToSingle(txtDarsadEstehlak_Daraeha.Text) : 0;
                                            q.EpHesabTafsiliDaraeha1.ArzeshEsghat = !string.IsNullOrEmpty(txtArzeshEsghat_Daraeha.Text) ? Convert.ToDecimal(txtArzeshEsghat_Daraeha.Text) : 0;
                                            break;
                                        }
                                    case "xtpSandoghha":
                                        {
                                            q.EpHesabTafsiliSandogh1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliSandogh1.Name = _txtName;
                                            q.EpHesabTafsiliSandogh1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliSandogh1.IsActive = _IsActive;
                                            q.EpHesabTafsiliSandogh1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliSandogh1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            q.EpHesabTafsiliSandogh1.NameMasol = txtNameMasol_Sandogh.Text;
                                            q.EpHesabTafsiliSandogh1.IsDefault = chkIsDefault_Sandogh.Checked;
                                            break;
                                        }
                                    case "xtpBankha":
                                        {
                                            q.EpHesabTafsiliBankha1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliBankha1.Name = _txtName;
                                            q.EpHesabTafsiliBankha1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliBankha1.IsActive = _IsActive;
                                            q.EpHesabTafsiliBankha1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliBankha1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            q.EpHesabTafsiliBankha1.NameBank = cmbNameBank_Bank.Text;
                                            q.EpHesabTafsiliBankha1.NameShobe = txtNameShobe_Bank.Text;
                                            q.EpHesabTafsiliBankha1.CodeShobe = txtCodeShobe_Bank.Text;
                                            q.EpHesabTafsiliBankha1.NoeHesab = cmbNoeHesab_Bank.Text;
                                            q.EpHesabTafsiliBankha1.ShomareHesab = txtShomareHesab_Bank.Text;
                                            q.EpHesabTafsiliBankha1.ShomareKart = txtShomareKart_Bank.Text;
                                            q.EpHesabTafsiliBankha1.ShomareShaba = txtShomareShaba_Bank.Text;
                                            q.EpHesabTafsiliBankha1.ShomareMoshtari = txtShomareMoshtari_Bank.Text;
                                            q.EpHesabTafsiliBankha1.NoeArz = cmbNoeArz_Bank.Text;
                                            q.EpHesabTafsiliBankha1.IsDefault = chkIsDefault_Bank.Checked;
                                            q.EpHesabTafsiliBankha1.NameBankId = Convert.ToInt32(cmbNameBank_Bank.EditValue);
                                            q.EpHesabTafsiliBankha1.NoeHesaId = Convert.ToInt32(cmbNoeHesab_Bank.EditValue);
                                            q.EpHesabTafsiliBankha1.NoeArzId = Convert.ToInt32(cmbNoeArz_Bank.EditValue);
                                            break;
                                        }
                                    case "xtpVamha":
                                        {
                                            q.EpHesabTafsiliVam1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliVam1.Name = _txtName;
                                            q.EpHesabTafsiliVam1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliVam1.IsActive = _IsActive;
                                            q.EpHesabTafsiliVam1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliVam1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            if (!string.IsNullOrEmpty(txtTarikhDaryaftVam_Vam.Text))
                                                q.EpHesabTafsiliVam1.TarikhDaryaftVam = Convert.ToDateTime(txtTarikhDaryaftVam_Vam.Text);
                                            q.EpHesabTafsiliVam1.IndexNoeVam = cmbNoeVam_Vam.SelectedIndex;
                                            q.EpHesabTafsiliVam1.NoeVam = cmbNoeVam_Vam.Text;
                                            q.EpHesabTafsiliVam1.TedadAghsat = !string.IsNullOrEmpty(txtTedadAghsat_Vam.Text) ? Convert.ToInt32(txtTedadAghsat_Vam.Text) : 0;
                                            if (!string.IsNullOrEmpty(txtSarresidAvalinGhest_Vam.Text))
                                                q.EpHesabTafsiliVam1.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest_Vam.Text);
                                            q.EpHesabTafsiliVam1.NerkhBahre = !string.IsNullOrEmpty(txtNerkhBahre_Vam.Text) ? Convert.ToSingle(txtNerkhBahre_Vam.Text) : 0;
                                            break;
                                        }
                                    case "xtpMarakezHazine":
                                        {
                                            q.EpHesabTafsiliMarakezHazine1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliMarakezHazine1.Name = _txtName;
                                            q.EpHesabTafsiliMarakezHazine1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliMarakezHazine1.IsActive = _IsActive;
                                            q.EpHesabTafsiliMarakezHazine1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliMarakezHazine1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpShoabat":
                                        {
                                            q.EpHesabTafsiliShoabat1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliShoabat1.Name = _txtName;
                                            q.EpHesabTafsiliShoabat1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliShoabat1.IsActive = _IsActive;
                                            q.EpHesabTafsiliShoabat1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliShoabat1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpProzheha":
                                        {
                                            q.EpHesabTafsiliProzhe1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliProzhe1.Name = _txtName;
                                            q.EpHesabTafsiliProzhe1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliProzhe1.IsActive = _IsActive;
                                            q.EpHesabTafsiliProzhe1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliProzhe1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpGharardadha":
                                        {
                                            q.EpHesabTafsiliGharardad1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliGharardad1.Name = _txtName;
                                            q.EpHesabTafsiliGharardad1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliGharardad1.IsActive = _IsActive;
                                            q.EpHesabTafsiliGharardad1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliGharardad1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    case "xtpSayer":
                                        {
                                            q.EpHesabTafsiliSayer1.Code = _CodeTafsili;
                                            q.EpHesabTafsiliSayer1.Name = _txtName;
                                            q.EpHesabTafsiliSayer1.TarikhEjad = _TarikhEjad;
                                            q.EpHesabTafsiliSayer1.IsActive = _IsActive;
                                            q.EpHesabTafsiliSayer1.SharhHesab = _txtSharh;
                                            q.EpHesabTafsiliSayer1.GroupTafsiliId = _cmbGroupTafsiliId;
                                            break;
                                        }
                                    default:
                                        break;
                                }

                                db.SaveChanges();

                                btnCancel_Click(null, null);
                                btnDisplyList_Click(null, null);
                                if (gridView.RowCount > 0)
                                    gridView.FocusedRowHandle = EditRowIndex;
                                En = EnumCED.Save;

                                switch (_SelectedTabPage)
                                {
                                    case "xtpAshkhas":
                                        {
                                            if (XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد" + "\n" + "آیا مایلید اطلاعات دیگر این حساب را ویرایش نمایید ؟", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
                                                //fm.MdiParent = this;
                                                fm.lblUserId.Text = lblUserId.Text;
                                                fm.lblUserName.Text = lblUserName.Text;
                                                fm.lblSalId.Text = lblSalId.Text;
                                                fm.lblSalMali.Text = lblSalMali.Text;
                                                // ActiveForm(fm);
                                                fm.cmbGroupTafsili.EditValue = _cmbGroupTafsiliId;
                                                var q1 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.Code == _CodeTafsili && s.SalId == _SalId && s.LevelNamber == _levelNamber);
                                                if (q1 != null)
                                                    fm.cmbTafsiliAshkhas.EditValue = q1.Id;
                                                fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
                                                fm.ShowDialog();
                                            }
                                            break;
                                        }
                                    default:
                                        break;
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
                gridControl.Enabled = true;
                En = EnumCED.Cancel;
                HelpClass1.ActiveButtons(panelControl1);
                HelpClass1.ClearControls(PanelControl);
                HelpClass1.InActiveControls(PanelControl);
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                btnCreate.Focus();
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void cmbGroupTafsili_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Convert.ToInt32(cmbGroupTafsili.EditValue) != 0)
                    {
                        _cmbGroupTafsiliId = Convert.ToInt32(cmbGroupTafsili.EditValue);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _cmbGroupTafsiliId && s.SalId == _SalId && s.LevelNamber == _levelNamber);
                        if (q != null)
                        {
                            txtGroupCode.Text = q.KeyCode.ToString();
                            if (En == EnumCED.Edit)
                                if (_cmbGroupTafsiliId != _GroupTafsiliIdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);
                            else
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

        private void cmbGroupTafsili_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupTafsili.ShowPopup();
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

        private void btnJoziatAshkhas_Click(object sender, EventArgs e)
        {
            FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            //fm._levelNamber=_levelNamber;
            fm.cmbGroupTafsili.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupTafsiliId"));
            fm.cmbTafsiliAshkhas.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id").ToString());
            fm.cmbGroupTafsili.ReadOnly = fm.cmbTafsiliAshkhas.ReadOnly = true;
            fm.btnReloadGroupTafsili_Ashkhas.Enabled = fm.btnReloadHesabTafsili_Ashkhas.Enabled = false;
            fm.ShowDialog();

        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView.RowCount > 0)
                {
                    txtId.Text = gridView.GetFocusedRowCellValue("Id").ToString();
                    cmbGroupTafsili.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupTafsiliId"));
                    txtGroupCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(0, _Carakter);
                    txtCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(_Carakter);
                    txtName.Text = gridView.GetFocusedRowCellValue("Name").ToString();
                    txtTarikhEjad.Text = gridView.GetFocusedRowCellValue("TarikhEjad") != null ? gridView.GetFocusedRowCellValue("TarikhEjad").ToString().Substring(0, 10) : "";
                    chkIsActive.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                    txtSharh.Text = gridView.GetFocusedRowCellValue("SharhHesab").ToString();

                    switch (_SelectedTabPage)
                    {
                        case "xtpAshkhas":
                            {
                                chkHaghighi_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsHaghighi"));
                                chkHoghoghi_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsHoghoghi"));
                                chkPersonel_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsKarkonan"));
                                chkSahamdar_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsSahamdar"));
                                chkVizitor_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsVizitor"));
                                chkRanande_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsRanande"));
                                chkKharidar_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsKharidar"));
                                chkFroshandeh_Ashkhas.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsFroshandeh"));
                                break;
                            }
                        case "xtpAghlamAnbar":
                            {
                                txtCodeKala_Aghlam.Text = gridView.GetFocusedRowCellValue("CodeKala").ToString();
                                break;
                            }
                        case "xtpDaraeha":
                            {
                                txtCodeAmval_Daraeha.Text = gridView.GetFocusedRowCellValue("CodeAmval").ToString();
                                cmbRaveshEstehlak_Daraeha.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexRaveshEstehlak"));
                                txtOmreMofid_Daraeha.Text = gridView.GetFocusedRowCellValue("OmreMofid").ToString();
                                txtDarsadEstehlak_Daraeha.Text = gridView.GetFocusedRowCellValue("DarsadEstehlak").ToString();
                                txtArzeshEsghat_Daraeha.Text = gridView.GetFocusedRowCellValue("ArzeshEsghat").ToString();
                                break;
                            }
                        case "xtpSandoghha":
                            {
                                txtNameMasol_Sandogh.Text = gridView.GetFocusedRowCellValue("NameMasol").ToString();
                                chkIsDefault_Sandogh.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                                break;
                            }
                        case "xtpBankha":
                            {
                                cmbNameBank_Bank.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NameBankId").ToString());
                                cmbNoeHesab_Bank.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeHesaId").ToString());
                                cmbNoeArz_Bank.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("NoeArzId").ToString());
                                chkIsDefault_Bank.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsDefault"));
                                txtNameShobe_Bank.Text = gridView.GetFocusedRowCellValue("NameShobe").ToString();
                                txtCodeShobe_Bank.Text = gridView.GetFocusedRowCellValue("CodeShobe").ToString();
                                txtShomareHesab_Bank.Text = gridView.GetFocusedRowCellValue("ShomareHesab").ToString();
                                txtShomareKart_Bank.Text = gridView.GetFocusedRowCellValue("ShomareKart").ToString();
                                txtShomareShaba_Bank.Text = gridView.GetFocusedRowCellValue("ShomareShaba").ToString();
                                txtShomareMoshtari_Bank.Text = gridView.GetFocusedRowCellValue("ShomareMoshtari").ToString();
                                break;
                            }
                        case "xtpVamha":
                            {
                                txtTarikhDaryaftVam_Vam.Text = gridView.GetFocusedRowCellValue("TarikhDaryaftVam") != null ? gridView.GetFocusedRowCellValue("TarikhDaryaftVam").ToString().Substring(0, 10) : "";
                                txtSarresidAvalinGhest_Vam.Text = gridView.GetFocusedRowCellValue("SarresidAvalinGhest") != null ? gridView.GetFocusedRowCellValue("SarresidAvalinGhest").ToString().Substring(0, 10) : "";
                                cmbNoeVam_Vam.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNoeVam").ToString());
                                txtTedadAghsat_Vam.Text = gridView.GetFocusedRowCellValue("TedadAghsat").ToString();
                                txtNerkhBahre_Vam.Text = gridView.GetFocusedRowCellValue("NerkhBahre").ToString();
                                break;
                            }
                        default:
                            break;
                    }
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
                }

            }
            catch (Exception)
            {
            }
        }

        private void xtcHesabTafsili_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _Carakter = _levelNamber == 1 ? _GroupTafsiliLevel1Carakter : _levelNamber == 2 ? _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter : _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter + _GroupTafsiliLevel3Carakter;
            if (xtcHesabhaTafsili.SelectedTabPage == xtpAllHesabTafsili)
            {
                btnCreate.Enabled = false;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_AllHesabTafsili;
                gridView = gridView_AllHesabTafsili;
                PanelControl = panelControl_AllHesabTafsili;
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpAshkhas)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = true;
                gridControl = gridControl_Ashkhas;
                gridView = gridView_Ashkhas;
                cmbGroupTafsili = cmbGroupTafsili_Ashkhas;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Ashkhas;
                txtCode = txtCode_Ashkhas;
                txtGroupCode = txtCodeGroupTafsili_Ashkhas;
                chkEditCode = chkEditCode_Ashkhas;
                btnNewCode = btnNewCode_Ashkhas;
                txtId = txtId_Ashkhas;
                txtName = txtName_Ashkhas;
                txtTarikhEjad = txtTarikhEjad_Ashkhas;
                chkIsActive = chkIsActive_Ashkhas;
                txtSharh = txtSharh_Ashkhas;
                PanelControl = panelControl_Ashkhas;
                _TabaghehIndex = 0;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpAghlamAnbar)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Aghlam;
                gridView = gridView_Aghlam;
                cmbGroupTafsili = cmbGroupTafsili_Aghlam;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Aghlam;
                txtCode = txtCode_Aghlam;
                txtGroupCode = txtCodeGroupTafsili_Aghlam;
                chkEditCode = chkEditCode_Aghlam;
                btnNewCode = btnNewCode_Aghlam;
                txtId = txtId_Aghlam;
                txtName = txtName_Aghlam;
                txtTarikhEjad = txtTarikhEjad_Aghlam;
                chkIsActive = chkIsActive_Aghlam;
                txtSharh = txtSharh_Aghlam;
                PanelControl = panelControl_AghlamAnbar;
                _TabaghehIndex = 1;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpDaraeha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Daraeha;
                gridView = gridView_Daraeha;
                cmbGroupTafsili = cmbGroupTafsili_Daraeha;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Daraeha;
                txtCode = txtCode_Daraeha;
                txtGroupCode = txtCodeGroupTafsili_Daraeha;
                chkEditCode = chkEditCode_Daraeha;
                btnNewCode = btnNewCode_Daraeha;
                txtId = txtId_Daraeha;
                txtName = txtName_Daraeha;
                txtTarikhEjad = txtTarikhEjad_Daraeha;
                chkIsActive = chkIsActive_Daraeha;
                txtSharh = txtSharh_Daraeha;
                PanelControl = panelControl_Daraeha;
                _TabaghehIndex = 2;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpSandoghha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Sandogh;
                gridView = gridView_Sandogh;
                cmbGroupTafsili = cmbGroupTafsili_Sandogh;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Sandogh;
                txtCode = txtCode_Sandogh;
                txtGroupCode = txtCodeGroupTafsili_Sandogh;
                chkEditCode = chkEditCode_Sandogh;
                btnNewCode = btnNewCode_Sandogh;
                txtId = txtId_Sandogh;
                txtName = txtName_Sandogh;
                txtTarikhEjad = txtTarikhEjad_Sandogh;
                chkIsActive = chkIsActive_Sandogh;
                txtSharh = txtSharh_Sandogh;
                PanelControl = panelControl_Sandogh;
                _TabaghehIndex = 3;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpBankha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Bank;
                gridView = gridView_Bank;
                cmbGroupTafsili = cmbGroupTafsili_Bank;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Bank;
                txtCode = txtCode_Bank;
                txtGroupCode = txtCodeGroupTafsili_Bank;
                chkEditCode = chkEditCode_Bank;
                btnNewCode = btnNewCode_Bank;
                txtId = txtId_Bank;
                txtName = txtName_Bank;
                txtTarikhEjad = txtTarikhEjad_Bank;
                chkIsActive = chkIsActive_Bank;
                txtSharh = txtSharh_Bank;
                PanelControl = panelControl_Bank;
                _TabaghehIndex = 4;
                FillcmbGroupTafsili();
                FillcmbNameBank(); FillcmbNoeHesab(); FillcmbNoeArz();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpVamha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Vam;
                gridView = gridView_Vam;
                cmbGroupTafsili = cmbGroupTafsili_Vam;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Vam;
                txtCode = txtCode_Vam;
                txtGroupCode = txtCodeGroupTafsili_Vam;
                chkEditCode = chkEditCode_Vam;
                btnNewCode = btnNewCode_Vam;
                txtId = txtId_Vam;
                txtName = txtName_Vam;
                txtTarikhEjad = txtTarikhEjad_Vam;
                chkIsActive = chkIsActive_Vam;
                txtSharh = txtSharh_Vam;
                PanelControl = panelControl_Vam;
                _TabaghehIndex = 5;
                FillcmbGroupTafsili();
                HelpClass1.DateTimeMask(txtTarikhDaryaftVam_Vam);
                HelpClass1.DateTimeMask(txtSarresidAvalinGhest_Vam);
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpMarakezHazine)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Marakez;
                gridView = gridView_Marakez;
                cmbGroupTafsili = cmbGroupTafsili_Marakez;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Marakez;
                txtCode = txtCode_Marakez;
                txtGroupCode = txtCodeGroupTafsili_Marakez;
                chkEditCode = chkEditCode_Marakez;
                btnNewCode = btnNewCode_Marakez;
                txtId = txtId_Marakez;
                txtName = txtName_Marakez;
                txtTarikhEjad = txtTarikhEjad_Marakez;
                chkIsActive = chkIsActive_Marakez;
                txtSharh = txtSharh_Marakez;
                PanelControl = panelControl_Marakez;
                _TabaghehIndex = 6;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpShoabat)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Shoabat;
                gridView = gridView_Shoabat;
                cmbGroupTafsili = cmbGroupTafsili_Shoabat;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Shoabat;
                txtCode = txtCode_Shoabat;
                txtGroupCode = txtCodeGroupTafsili_Shoabat;
                chkEditCode = chkEditCode_Shoabat;
                btnNewCode = btnNewCode_Shoabat;
                txtId = txtId_Shoabat;
                txtName = txtName_Shoabat;
                txtTarikhEjad = txtTarikhEjad_Shoabat;
                chkIsActive = chkIsActive_Shoabat;
                txtSharh = txtSharh_Shoabat;
                PanelControl = panelControl_Shoabat;
                _TabaghehIndex = 7;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpProzheha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Prozhe;
                gridView = gridView_Prozhe;
                cmbGroupTafsili = cmbGroupTafsili_Prozhe;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Prozhe;
                txtCode = txtCode_Prozhe;
                txtGroupCode = txtCodeGroupTafsili_Prozhe;
                chkEditCode = chkEditCode_Prozhe;
                btnNewCode = btnNewCode_Prozhe;
                txtId = txtId_Prozhe;
                txtName = txtName_Prozhe;
                txtTarikhEjad = txtTarikhEjad_Prozhe;
                chkIsActive = chkIsActive_Prozhe;
                txtSharh = txtSharh_Prozhe;
                PanelControl = panelControl_Prozhe;
                _TabaghehIndex = 8;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpGharardadha)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Gharardad;
                gridView = gridView_Gharardad;
                cmbGroupTafsili = cmbGroupTafsili_Gharardad;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Gharardad;
                txtCode = txtCode_Gharardad;
                txtGroupCode = txtCodeGroupTafsili_Gharardad;
                chkEditCode = chkEditCode_Gharardad;
                btnNewCode = btnNewCode_Gharardad;
                txtId = txtId_Gharardad;
                txtName = txtName_Gharardad;
                txtTarikhEjad = txtTarikhEjad_Gharardad;
                chkIsActive = chkIsActive_Gharardad;
                txtSharh = txtSharh_Gharardad;
                PanelControl = panelControl_Gharardad;
                _TabaghehIndex = 9;
                FillcmbGroupTafsili();
            }
            else if (xtcHesabhaTafsili.SelectedTabPage == xtpSayer)
            {
                btnCreate.Enabled = true;
                btnJoziatAshkhas.Visible = false;
                gridControl = gridControl_Sayer;
                gridView = gridView_Sayer;
                cmbGroupTafsili = cmbGroupTafsili_Sayer;
                btnReloadGroupTafsili = btnReloadGroupTafsili_Sayer;
                txtCode = txtCode_Sayer;
                txtGroupCode = txtCodeGroupTafsili_Sayer;
                chkEditCode = chkEditCode_Sayer;
                btnNewCode = btnNewCode_Sayer;
                txtId = txtId_Sayer;
                txtName = txtName_Sayer;
                txtTarikhEjad = txtTarikhEjad_Sayer;
                chkIsActive = chkIsActive_Sayer;
                txtSharh = txtSharh_Sayer;
                PanelControl = panelControl_Sayer;
                _TabaghehIndex = 10;
                FillcmbGroupTafsili();
            }
            HelpClass1.DateTimeMask(txtTarikhEjad);
            _SelectedTabPage = xtcHesabhaTafsili.SelectedTabPage.Name;
            FillGridViewHesabTafsili();
        }

        private void btnReloadControl_Click(object sender, EventArgs e)
        {
            if (btnReloadGroupTafsili.Focused)
            {
                FillcmbGroupTafsili();
            }
            else if (btnNamBank_Bank.Focused)
            {
                FrmNameBank fm = new FrmNameBank(this);
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                fm.ShowDialog();
            }
            else if (btnNoeHesab_Bank.Focused)
            {
                FrmNoeHesab fm = new FrmNoeHesab(this);
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                fm.ShowDialog();
            }
            else if (btnNoeArz_Bank.Focused)
            {
                FrmNoeArz fm = new FrmNoeArz(this);
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                fm.ShowDialog();
            }
        }

        private void cmbGroupTafsili_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void gridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            HelpClass1.gridView_RowCellStyle(sender, e);
        }

        private void xtcHesabTafsili_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            btnCancel_Click(null, null);
        }

        private void cmbNameBank_Bank_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNameBank_Bank.ShowPopup();
            }
        }

        private void cmbNoeHesab_Bank_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeHesab_Bank.ShowPopup();
            }
        }

        private void cmbNoeArz_Bank_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeArz_Bank.ShowPopup();
            }
        }

        private void cmbRaveshEstehlak_Daraeha_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbRaveshEstehlak_Daraeha.ShowPopup();
            }
        }

        private void cmbNameBank_Bank_EditValueChanged(object sender, EventArgs e)
        {
            _NameBank = cmbNameBank_Bank.Text;
            txtName.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void cmbNoeHesab_Bank_EditValueChanged(object sender, EventArgs e)
        {
            _NoeHesab = cmbNoeHesab_Bank.Text;
            txtName.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void txtNameShobe_Bank_EditValueChanged(object sender, EventArgs e)
        {
            _NameShobe = txtNameShobe_Bank.Text;
            txtName.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void txtShomareHesab_Bank_EditValueChanged(object sender, EventArgs e)
        {
            _ShomareHesab = txtShomareHesab_Bank.Text;
            txtName.Text = _NameBank + " " + _NameShobe + " " + _NoeHesab + " " + _ShomareHesab;
        }

        private void cmbRaveshEstehlak_Daraeha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRaveshEstehlak_Daraeha.SelectedIndex == 0)
            {
                txtOmreMofid_Daraeha.Enabled = txtArzeshEsghat_Daraeha.Enabled = true;
                txtDarsadEstehlak_Daraeha.Enabled = false;
            }
            else if (cmbRaveshEstehlak_Daraeha.SelectedIndex == 1)
            {
                txtDarsadEstehlak_Daraeha.Enabled = txtArzeshEsghat_Daraeha.Enabled = true;
                txtOmreMofid_Daraeha.Enabled = false;
            }
            else if (cmbRaveshEstehlak_Daraeha.SelectedIndex == 2)
            {
                txtOmreMofid_Daraeha.Enabled = txtDarsadEstehlak_Daraeha.Enabled = txtArzeshEsghat_Daraeha.Enabled = false;
            }
        }

        private void cmbNoeVam_Vam_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbNoeVam_Vam.ShowPopup();
            }
        }

        private void chkHoghoghi_Ashkhas_CheckedChanged(object sender, EventArgs e)
        {
            chkHaghighi_Ashkhas.Checked = chkHoghoghi_Ashkhas.Checked ? false : true;

        }

        private void chkHaghighi_Ashkhas_CheckedChanged(object sender, EventArgs e)
        {
            chkHoghoghi_Ashkhas.Checked = chkHaghighi_Ashkhas.Checked ? false : true;

        }
    }
}