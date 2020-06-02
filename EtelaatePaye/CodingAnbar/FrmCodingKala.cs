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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DBHesabdari_PG;
using DevExpress.XtraTreeList;
using System.Data.Entity;
using DBHesabdari_PG.Models.EP.CodingAnbar;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace EtelaatePaye.CodingAnbar
{
    public partial class FrmCodingKala : DevExpress.XtraEditors.XtraForm
    {
        MyContext db1;
        public FrmCodingKala()
        {
            InitializeComponent();
        }

        EnumCED En;
        int _SalId = 0;
        int _Code = 0;
        string _Name = "";
        bool _IsActive = true;
        string _SharhHesab = "";
        int _LevelNumber = 0;
        int _TabaghehKalaId = 0;
        int _GroupAsliKalaId = 0;
        int _GroupFareeKalaId = 0;
        int _NameKalaId = 0;
        int _VahedKalaId = 0;
        int EditRowIndex = 0;
        int _IndexTabControl3 = 0;
        string _SelectedTabPage = "";

        int TabaghehKalaIdBeforeEdit = 0;
        int GroupAsliIdBeforeEdit = 0;
        int GroupFareeIdBeforeEdit = 0;

        //int _TabaghehKalaIdBeforeEdit = 0;
        int _CodeBeforeEdit = 0;
        string _NameBeforeEdit = "";
        bool _IsActiveBeforeEdit = true;


        int _Carakter = 0;
        string _MinCode = "";
        string _MaxCode = "";
        int _CodeTabaghehKalaCarakter = 0;
        int _CodeGroupAsliKalaCarakter = 0;
        int _CodeGroupFareeKalaCarakter = 0;
        int _CodeNameKalaCarakter = 0;

        string _CodeTabaghehKalaMinCode = "";
        string _CodeTabaghehKalaMaxCode = "";
        string _CodeGroupAsliKalaMinCode = "";
        string _CodeGroupAsliKalaMaxCode = "";
        string _CodeGroupFareeKalaMinCode = "";
        string _CodeGroupFareeKalaMaxCode = "";
        string _CodeNameKalaMinCode = "";
        string _CodeNameKalaMaxCode = "";

        GridControl gridControl;
        GridView gridView;
        TreeList treelist;
        LookUpEdit cmbTabaghehKala;
        LookUpEdit cmbGroupAsliKala;
        LookUpEdit cmbGroupFareeKala;
        LookUpEdit cmbVahedKala;
        SimpleButton btnReloadTabaghehKala;
        SimpleButton btnReloadGroupAsli;
        SimpleButton btnReloadGroupFaree;
        TextEdit txtCode;
        TextEdit txtGroupCode;
        CheckEdit chkEditCode;
        SimpleButton btnNewCode;
        TextEdit txtId;
        TextEdit txtName;
        TextEdit txtTarikhEjad;
        CheckEdit chkIsActive;
        TextEdit txtSharh;
        PanelControl PanelControl1;
        PanelControl PanelControl2;


        public void FillGridViewCodingKala()
        {
            try
            {
                db1 = new MyContext();
                _SalId = Convert.ToInt32(lblSalId.Text);
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                if (lblUserId.Text == "1")
                {
                    switch (_SelectedTabPage)
                    {
                        case "xtraTabPage_TabaghehKala":
                            {
                                var q = db1.EpTabaghehKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                gridControl.DataSource = q.Count > 0 ? q : null;
                                break;
                            }
                        case "xtraTabPage_GroupAsli":
                            {
                                var q = db1.EpGroupAsliKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                gridControl.DataSource = q.Count > 0 ? q : null;
                                break;
                            }
                        case "xtraTabPage_GroupFaree":
                            {
                                var q = db1.EpGroupFareeKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                gridControl.DataSource = q.Count > 0 ? q : null;
                                break;
                            }
                        case "xtraTabPage_NameKala":
                            {
                                var q = db1.EpNameKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                gridControl.DataSource = q.Count > 0 ? q : null;
                                break;
                            }
                        case "xtraTabPage_DerakhtVareh":
                            {
                                var q = db1.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                                treelist.DataSource = q.Count > 0 ? q : null;
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

        public void FillcmbTabaghehKala()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    epTabaghehKalasBindingSource.DataSource = q.Count > 0 ? q : null;
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
                    _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpGroupAsliKalas.Where(s => s.SalId == _SalId && s.TabaghehId == _TabaghehKalaId).OrderBy(s => s.Code).ToList();
                    epGroupAsliKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbGroupFaree()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _GroupAsliKalaId = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpGroupFareeKalas.Where(s => s.SalId == _SalId && s.GroupAsliId == _GroupAsliKalaId).OrderBy(s => s.Code).ToList();
                    epGroupFareeKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public void FillcmbVahedKala()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpVahedKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    epVahedKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillcmbTaminKonande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    //var q = db.EpTaminKonandeKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    //epTaminKonandeKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                    var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.EpAllGroupTafsili1.TabaghehGroupIndex == 0 || s.EpAllGroupTafsili1.TabaghehGroupIndex == 6 || s.EpAllGroupTafsili1.TabaghehGroupIndex == 7).OrderBy(s => s.Code).ToList();
                    epAllHesabTafsilisBindingSource.DataSource = q.Count > 0 ? q : null;
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
                    if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                    {
                        var q = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString() != _MaxCode)
                            {
                                txtCode.Text = (MaximumCod + 1).ToString();
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف  " + _MaxCode + " حساب طبقه ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از  " + _MaxCode + "  حساب طبقه تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = _MinCode;
                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                    {
                        _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        var q = db.EpGroupAsliKalas.Where(s => s.SalId == _SalId && s.TabaghehId == _TabaghehKalaId).OrderBy(s => s.Code).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(_Carakter) != _MaxCode)
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(_Carakter);
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف  " + _MaxCode + " حساب گروه اصلی کالا ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از  " + _MaxCode + "  حساب گروه اصلی کالا تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = _MinCode;
                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                    {
                        _GroupAsliKalaId = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        var q = db.EpGroupFareeKalas.Where(s => s.SalId == _SalId && s.GroupAsliId == _GroupAsliKalaId).OrderBy(s => s.Code).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(_Carakter) != _MaxCode)
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(_Carakter);
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف  " + _MaxCode + " حساب گروه فرعی کالا ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از  " + _MaxCode + "  حساب گروه فرعی کالا تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = _MinCode;
                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        _GroupFareeKalaId = Convert.ToInt32(cmbGroupFareeKala.EditValue);
                        var q = db.EpNameKalas.Where(s => s.SalId == _SalId && s.GroupFareeId == _GroupFareeKalaId).OrderBy(s => s.Code).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(_Carakter) != _MaxCode)
                            {
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(_Carakter);
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف  " + _MaxCode + " حساب نام کالا ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از  " + _MaxCode + "  حساب نام کالا تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = _MinCode;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmCodingKala_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpTanzimatAnbarVKalas.FirstOrDefault(s => s.SalId == _SalId);
                    if (q != null)
                    {
                        _CodeTabaghehKalaCarakter = q.CodeTabagehKalaCarakter;
                        _CodeGroupAsliKalaCarakter = q.CodeGroupAsliKalaCarakter;
                        _CodeGroupFareeKalaCarakter = q.CodeGroupFareeKalaCarakter;
                        _CodeNameKalaCarakter = q.CodeNameKalaCarakter;

                        _CodeTabaghehKalaMinCode = q.CodeTabagehKalaMinCode;
                        _CodeTabaghehKalaMaxCode = q.CodeTabagehKalaMaxCode;
                        _CodeGroupAsliKalaMinCode = q.CodeGroupAsliKalaMinCode;
                        _CodeGroupAsliKalaMaxCode = q.CodeGroupAsliKalaMaxCode;
                        _CodeGroupFareeKalaMinCode = q.CodeGroupFareeKalaMinCode;
                        _CodeGroupFareeKalaMaxCode = q.CodeGroupFareeKalaMaxCode;
                        _CodeNameKalaMinCode = q.CodeNameKalaMinCode;
                        _CodeNameKalaMaxCode = q.CodeNameKalaMaxCode;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            gridControl = gridControl_TabaghehKala;
            gridView = gridView_TabaghehKala;
            cmbVahedKala = cmbVahedKala_Tabagheh;
            txtCode = txtCode_Tabagheh;
            txtGroupCode = txtCodeGroup_TabaghehKala;
            chkEditCode = chkEditCode_Tabagheh;
            btnNewCode = btnNewCode_Tabagheh;
            txtId = txtId_Tabagheh;
            txtName = txtName_Tabagheh;
            //txtTarikhEjad
            chkIsActive = chkIsActive_Tabagheh;
            txtSharh = txtSharhHesab_Tabagheh;
            PanelControl1 = panelControl_Button;
            PanelControl2 = panelControl_Tabagheh;
            _LevelNumber = 1;
            //_Carakter;
            txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
            txtCode.Properties.Mask.EditMask = _CodeTabaghehKalaCarakter == 1 ? "0" :
                                               _CodeTabaghehKalaCarakter == 2 ? "00" :
                                               _CodeTabaghehKalaCarakter == 3 ? "000" : "0000";
            txtCode.Properties.MaxLength = _CodeTabaghehKalaCarakter;
            _MinCode = _CodeTabaghehKalaMinCode;
            _MaxCode = _CodeTabaghehKalaMaxCode;

            _SelectedTabPage = xtraTabControl_CodingKala.SelectedTabPage.Name;
            FillGridViewCodingKala();
            FillcmbVahedKala();
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
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _Name = txtName.Text.Trim();
                    _IsActive = chkIsActive.Checked;
                    _SharhHesab = txtSharh.Text.Trim();
                    _VahedKalaId = Convert.ToInt32(cmbVahedKala.EditValue);

                    if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                    {
                        _Code = !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtCode.Text) : 0;

                        if (string.IsNullOrEmpty(_Code.ToString()))
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (_Code == 0 || _Code > Convert.ToInt32(_MaxCode) || _Code < Convert.ToInt32(_MinCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _MinCode + " تا " + _MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Focus();
                            return false;
                        }
                        else if (_VahedKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفاً واحد کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbVahedKala.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                var q1 = db.EpTabaghehKalas.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;

                                }
                                else if (db.EpTabaghehKalas.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpTabaghehKalas.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // txtCode.Text = CodeBeforeEdit;
                                    _Code = _CodeBeforeEdit;
                                    return false;
                                }
                                else if (db.EpTabaghehKalas.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                        }

                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                    {
                        _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        _Code = !String.IsNullOrEmpty(txtGroupCode.Text) && !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtGroupCode.Text + txtCode.Text) : 0;

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (_TabaghehKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbTabaghehKala.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text) || Convert.ToInt32(txtGroupCode.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_MaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _MinCode + " تا " + _MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Focus();
                            return false;
                        }
                        else if (_VahedKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفاً واحد کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbVahedKala.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                var q1 = db.EpGroupAsliKalas.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                                else if (db.EpGroupAsliKalas.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpGroupAsliKalas.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);
                                    return false;
                                }
                                else if (db.EpGroupAsliKalas.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                    {
                        _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        _GroupAsliKalaId = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        _Code = !String.IsNullOrEmpty(txtGroupCode.Text) && !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtGroupCode.Text + txtCode.Text) : 0;

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (_TabaghehKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbTabaghehKala.Focus();
                            return false;
                        }
                        if (_GroupAsliKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب گروه اصلی را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbGroupAsliKala.Focus();
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text) || Convert.ToInt32(txtGroupCode.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_MaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _MinCode + " تا " + _MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Focus();
                            return false;
                        }
                        else if (_VahedKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفاً واحد کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbVahedKala.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                var q1 = db.EpGroupFareeKalas.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                                else if (db.EpGroupFareeKalas.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpGroupFareeKalas.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);
                                    return false;
                                }
                                else if (db.EpGroupFareeKalas.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }

                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        _Code = !String.IsNullOrEmpty(txtGroupCode.Text) && !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtGroupCode.Text + txtCode.Text) : 0;
                        _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        _GroupAsliKalaId = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        _GroupFareeKalaId = Convert.ToInt32(cmbGroupFareeKala.EditValue);

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (string.IsNullOrEmpty(cmbTabaghehKala.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbTabaghehKala.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(cmbGroupAsliKala.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب گروه اصلی را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbGroupAsliKala.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(cmbGroupFareeKala.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب گروه فرعی را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbGroupFareeKala.Focus();
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtGroupCode.Text) || Convert.ToInt32(txtGroupCode.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > Convert.ToInt32(_MaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _MinCode + " تا " + _MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام کالا را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Focus();
                            return false;
                        }
                        else if (_VahedKalaId == 0)
                        {
                            XtraMessageBox.Show("لطفاً واحد کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbVahedKala.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(cmbVahedAsli.EditValue) == 0)
                        {
                            XtraMessageBox.Show("لطفاً واحد اصلی کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbVahedAsli.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                var q1 = db.EpNameKalas.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                                else if (db.EpNameKalas.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpNameKalas.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);
                                    return false;
                                }
                                else if (db.EpNameKalas.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtName.Focus();
                                    return false;
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
        }

        private void FrmCodingKala_KeyDown(object sender, KeyEventArgs e)
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
            FillGridViewCodingKala();
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

                if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                {
                    HelpClass1.InActiveButtons(PanelControl1);
                    HelpClass1.ClearControls(PanelControl2);
                    HelpClass1.ActiveControls(PanelControl2);
                    btnNewCode_Click(null, null);
                    txtName.Focus();
                }
                else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                {
                    HelpClass1.InActiveButtons(PanelControl1);
                    HelpClass1.ClearControls(PanelControl2);
                    HelpClass1.ActiveControls(PanelControl2);
                    FillcmbTabaghehKala();
                    cmbTabaghehKala.Focus();
                }
                else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                {
                    HelpClass1.InActiveButtons(PanelControl1);
                    HelpClass1.ClearControls(PanelControl2);
                    HelpClass1.ActiveControls(PanelControl2);
                    FillcmbTabaghehKala();
                    cmbTabaghehKala.Focus();
                }
                else if (_SelectedTabPage == "xtraTabPage_NameKala")
                {
                    HelpClass1.InActiveButtons(PanelControl1);
                    HelpClass1.ClearControls(xtraTabPage1);
                    HelpClass1.ClearControls(xtraTabPage2);
                    HelpClass1.ClearControls(xtraTabPage3);
                    HelpClass1.ClearControls(xtraTabPage4);
                    HelpClass1.ClearControls(xtraTabPage5);
                    HelpClass1.ActiveControls(xtraTabPage1);
                    HelpClass1.ActiveControls(xtraTabPage2);
                    HelpClass1.ActiveControls(xtraTabPage3);
                    HelpClass1.ActiveControls(xtraTabPage4);
                    HelpClass1.ActiveControls(xtraTabPage5);
                    FillcmbTaminKonande();
                    txtTarikhEjad.Text = DateTime.Now.ToString().Substring(0, 10);

                    xtraTabControl_NameKala.SelectedTabPageIndex = 1;
                    xtraTabControl_NameKala.SelectedTabPageIndex = 0;
                    FillcmbTabaghehKala();
                    cmbTabaghehKala.Focus();
                }
                chkIsActive.Checked = true;
                FillcmbVahedKala();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView.RowCount > 0)
                {
                    if (XtraMessageBox.Show("آیا حساب مورد نظر حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        _IsActiveBeforeEdit = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                        EditRowIndex = gridView.FocusedRowHandle;
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int RowId = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id").ToString());
                                var q = db.EpAllCodingKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == RowId);
                                if (q != null)
                                {
                                    db.EpAllCodingKalas.Remove(q);
                                    /////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();

                                    if (_SelectedTabPage != "xtraTabPage_NameKala")
                                    {
                                        HelpClass1.ClearControls(PanelControl2);
                                    }
                                    else
                                    {
                                        HelpClass1.ClearControls(xtraTabPage1);
                                        HelpClass1.ClearControls(xtraTabPage2);
                                        HelpClass1.ClearControls(xtraTabPage3);
                                        HelpClass1.ClearControls(xtraTabPage4);
                                        HelpClass1.ClearControls(xtraTabPage5);
                                    }
                                    btnDisplyList_Click(null, null);
                                    // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    if (gridView.RowCount > 0)
                                        gridView.FocusedRowHandle = EditRowIndex - 1;
                                }
                                else
                                    XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (DbUpdateException)
                            {
                                if (_SelectedTabPage != "xtraTabPage_NameKala")
                                {
                                    XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                                " جهت حذف حساب بایستی در ابتدا زیرمجموعه های این حساب حذف شود", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                    XtraMessageBox.Show("حذف این حساب مقدور نیست \n" + " زیرا با حساب فوق سند صادر گردیده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    FillcmbVahedKala();
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

                    gridView_RowCellClick(null, null);

                    _CodeBeforeEdit = Convert.ToInt32(txtGroupCode.Text + txtCode.Text);
                    _NameBeforeEdit = txtName.Text;
                    _IsActiveBeforeEdit = chkIsActive.Checked;

                    if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                    {
                        HelpClass1.InActiveButtons(PanelControl1);
                        HelpClass1.ActiveControls(PanelControl2);
                        txtName.Focus();
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                    {
                        HelpClass1.InActiveButtons(PanelControl1);
                        HelpClass1.ActiveControls(PanelControl2);
                        TabaghehKalaIdBeforeEdit = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        FillcmbTabaghehKala();
                        cmbTabaghehKala.Focus();
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                    {
                        HelpClass1.InActiveButtons(PanelControl1);
                        HelpClass1.ActiveControls(PanelControl2);
                        TabaghehKalaIdBeforeEdit = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        GroupAsliIdBeforeEdit = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        FillcmbTabaghehKala();
                        cmbTabaghehKala.Focus();
                    }
                    else if (_SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        HelpClass1.InActiveButtons(PanelControl1);
                        HelpClass1.ActiveControls(xtraTabPage1);
                        HelpClass1.ActiveControls(xtraTabPage2);
                        HelpClass1.ActiveControls(xtraTabPage3);
                        HelpClass1.ActiveControls(xtraTabPage4);
                        HelpClass1.ActiveControls(xtraTabPage5);
                        TabaghehKalaIdBeforeEdit = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        GroupAsliIdBeforeEdit = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        GroupFareeIdBeforeEdit = Convert.ToInt32(cmbGroupFareeKala.EditValue);
                        FillcmbTaminKonande();
                        FillcmbTabaghehKala();
                        using (var db = new MyContext())
                        {
                            try
                            {
                                _SalId = Convert.ToInt32(lblSalId.Text);
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q = db.AkAllAmaliateRozanehs.FirstOrDefault(s => s.KalaId == RowId && s.SalId == _SalId);
                                cmbVahedAsli.Enabled = q != null ? false : true;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        cmbTabaghehKala.Focus();
                    }
                }
            }
        }

        Image img;
        private void btnBrowsPictuer_NameKala_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog XtraOpenFileDialog1 = new XtraOpenFileDialog();
            XtraOpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (XtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(XtraOpenFileDialog1.FileName);
                this.pictureEdit1_NameKala.Image = img;
                //this.pictureEdit1.Tag = openFileDialog1.FileName;
            }

        }

        private void btnDeletePictuer_NameKala_Click(object sender, EventArgs e)
        {
            this.pictureEdit1_NameKala.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (TextEditValidation())
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (En == EnumCED.Create)
                            {
                                if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                                {
                                    EpTabaghehKala obj = new EpTabaghehKala();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.VahedKalaId = _VahedKalaId;
                                    obj.VahedKalaName = cmbVahedKala.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    // var q = db.EpHesabTabagheh.FirstOrDefault(s => s.Code == _code && s.SalId == _SalId);
                                    ////////////////////////////////////// اضافه کردن حساب طبقه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingKala n1 = new EpAllCodingKala();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = _Code;
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNumber;
                                    n1.IsActive = _IsActive;
                                    n1.EpTabaghehKala1 = obj;
                                    db.EpAllCodingKalas.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridViewCodingKala();

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }
                                else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                                {
                                    EpGroupAsliKala obj = new EpGroupAsliKala();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.VahedKalaId = _VahedKalaId;
                                    obj.VahedKalaName = cmbVahedKala.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    obj.TabaghehId = _TabaghehKalaId;
                                    ////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingKala n1 = new EpAllCodingKala();
                                    n1.SalId = Convert.ToInt32(lblSalId.Text);
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNumber;
                                    n1.IsActive = _IsActive;
                                    n1.EpGroupAsliKala1 = obj;
                                    db.EpAllCodingKalas.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridViewCodingKala();

                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                                {
                                    EpGroupFareeKala obj = new EpGroupFareeKala();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.VahedKalaId = _VahedKalaId;
                                    obj.VahedKalaName = cmbVahedKala.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    obj.GroupAsliId = _GroupAsliKalaId;
                                    /////////////////////////////////////////////////
                                    EpAllCodingKala n1 = new EpAllCodingKala();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNumber;
                                    n1.IsActive = _IsActive;
                                    n1.EpGroupFareeKala1 = obj;
                                    db.EpAllCodingKalas.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridViewCodingKala();

                                    // XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }
                                else if (_SelectedTabPage == "xtraTabPage_NameKala")
                                {
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 0;
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 1;
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 2;
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 3;
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 4;
                                    xtraTabControl_NameKala.SelectedTabPageIndex = 0;

                                    EpNameKala obj = new EpNameKala();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.VahedKala1Id = _VahedKalaId;
                                    obj.VahedKala1Name = cmbVahedKala.Text;
                                    obj.VahedAsliId = Convert.ToInt32(cmbVahedAsli.EditValue);
                                    obj.VahedAsliName = cmbVahedAsli.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    obj.TarikhEjad = !string.IsNullOrEmpty(txtTarikhEjad.Text) ? Convert.ToDateTime(txtTarikhEjad.Text) : DateTime.Now;

                                    obj.GroupFareeId = _GroupFareeKalaId;

                                    if (!string.IsNullOrEmpty(txtCodeEkhtesasi_NameKala.Text))
                                        obj.CodeEkhtesasi = Convert.ToInt32(txtCodeEkhtesasi_NameKala.Text);
                                    if (!string.IsNullOrEmpty(cmbTaminKonande_NameKala.Text))
                                    {
                                        obj.TaminKonandeName = cmbTaminKonande_NameKala.Text;

                                        string CheckedItems = string.Empty;
                                        var CheckedList = cmbTaminKonande_NameKala.Properties.GetItems().GetCheckedValues();
                                        if (CheckedList.Count > 0)
                                        {
                                            foreach (var item in CheckedList)
                                            {
                                                CheckedItems += item.ToString() + ",";
                                            }
                                        }
                                        obj.TaminKonandeId = CheckedItems;
                                    }


                                    obj.IscheckVahedKala2 = Convert.ToBoolean(chkVahedKala2_NameKala.Checked);
                                    if (chkVahedKala2_NameKala.Checked && !string.IsNullOrEmpty(cmbVahedKala2_NameKala.Text))
                                    {
                                        obj.VahedKala2Id = Convert.ToInt32(cmbVahedKala2_NameKala.EditValue);
                                        obj.VahedKala2Name = cmbVahedKala2_NameKala.Text;
                                        if (!string.IsNullOrEmpty(txtHarBaste_NameKala.Text))
                                            obj.HarBaste = Convert.ToInt32(txtHarBaste_NameKala.Text);
                                    }

                                    obj.IscheckVahedKala3 = Convert.ToBoolean(chkVahedKala3_NameKala.Checked);
                                    if (chkVahedKala3_NameKala.Checked && !string.IsNullOrEmpty(cmbVahedKala3_NameKala.Text))
                                    {
                                        obj.VahedKala3Id = Convert.ToInt32(cmbVahedKala3_NameKala.EditValue);
                                        obj.VahedKala3Name = cmbVahedKala3_NameKala.Text;
                                        if (!string.IsNullOrEmpty(txtHarKarton_NameKala.Text))
                                            obj.HarKarton = Convert.ToInt32(txtHarKarton_NameKala.Text);
                                    }
                                    if (!string.IsNullOrEmpty(txtVazn_NameKala.Text))
                                        obj.Vazn = Convert.ToDouble(txtVazn_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtTool_NameKala.Text))
                                        obj.Tool = Convert.ToDouble(txtTool_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtArz_NameKala.Text))
                                        obj.Arz = Convert.ToDouble(txtArz_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtErtefae_NameKala.Text))
                                        obj.Ertefae = Convert.ToDouble(txtErtefae_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtZekhamat_NameKala.Text))
                                        obj.Zekhamat = Convert.ToDouble(txtZekhamat_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtMasahat_NameKala.Text))
                                        obj.Masahat = Convert.ToDouble(txtMasahat_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtMohit_NameKala.Text))
                                        obj.Mohit = Convert.ToDouble(txtMohit_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtHajm_NameKala.Text))
                                        obj.Hajm = Convert.ToDouble(txtHajm_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtSaiz_NameKala.Text))
                                        obj.Saiz = txtSaiz_NameKala.Text;

                                    obj.SerialKala = lstSerialKala_NameKala.Text;
                                    obj.ShomareFani = lstShomareFani_NameKala.Text;

                                    if (!string.IsNullOrEmpty(txtGhimatAkharinKharid_NameKala.Text))
                                        obj.GhimatAkharinKharid = Convert.ToDecimal(txtGhimatAkharinKharid_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtGhimatTamamShode_NameKala.Text))
                                        obj.GhimatTamamShode = Convert.ToDecimal(txtGhimatTamamShode_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtGhimatPayeFroosh_NameKala.Text))
                                        obj.GhimatPayeFroosh = Convert.ToDecimal(txtGhimatPayeFroosh_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtDarsadTakhfif_NameKala.Text))
                                        obj.DarsadTakhfif = Convert.ToSingle(txtDarsadTakhfif_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtGhimatNaghdiKhorde1_NameKala.Text))
                                        obj.GhimatNaghdiKhorde1 = Convert.ToDecimal(txtGhimatNaghdiKhorde1_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtGhimatNesiyeKhorde1_NameKala.Text))
                                        obj.GhimatNesiyeKhorde1 = Convert.ToDecimal(txtGhimatNesiyeKhorde1_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtGhimatNaghdiOmde1_NameKala.Text))
                                        obj.GhimatNaghdiOmde1 = Convert.ToDecimal(txtGhimatNaghdiOmde1_NameKala.Text.Replace(",", ""));
                                    if (!string.IsNullOrEmpty(txtGhimatNesiyeOmde1_NameKala.Text))
                                        obj.GhimatNesiyeOmde1 = Convert.ToDecimal(txtGhimatNesiyeOmde1_NameKala.Text.Replace(",", ""));

                                    if (!string.IsNullOrEmpty(txtNoghteSefaresh_NameKala.Text))
                                        obj.NoghteSefaresh = Convert.ToDouble(txtNoghteSefaresh_NameKala.Text);
                                    if (!string.IsNullOrEmpty(txtHadeSefaresh_NameKala.Text))
                                        obj.HadeSefaresh = Convert.ToDouble(txtHadeSefaresh_NameKala.Text);

                                    obj.IsArzeshAfzode = Convert.ToBoolean(chkArzeshAfzode_NameKala.Checked);

                                    if (pictureEdit1_NameKala.Image != null)
                                    {
                                        MemoryStream ms = new MemoryStream();
                                        img.Save(ms, pictureEdit1_NameKala.Image.RawFormat);
                                        byte[] myarrey = ms.GetBuffer();
                                        obj.Pictuer = myarrey;
                                    }
                                    else
                                        obj.Pictuer = null;

                                    ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingKala n1 = new EpAllCodingKala();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNumber;
                                    n1.IsActive = _IsActive;
                                    n1.EpNameKala1 = obj;
                                    db.EpAllCodingKalas.Add(n1);

                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridViewCodingKala();
                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }

                            }
                            else if (En == EnumCED.Edit)
                            {
                                if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                                {
                                    int RowId = Convert.ToInt32(txtId.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpNameKalas.Where(s => s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q5 = db.EpGroupFareeKalas.Where(s => s.EpGroupAsliKala1.EpTabaghehKala1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q5.Count > 0)
                                    {
                                        foreach (var item in q5)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q6)
                                            {
                                                if (item1.GroupFareeId == item.Id)
                                                    item.EpNameKalas.Append(item1);
                                            }
                                        }
                                    }
                                    /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                    var q4 = db.EpGroupAsliKalas.Where(s => s.TabaghehId == RowId && s.SalId == _SalId).ToList();
                                    if (q4.Count > 0)
                                    {
                                        foreach (var item in q4)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q5)
                                            {
                                                if (item1.GroupAsliId == item.Id)
                                                    item.EpGroupFareeKalas.Append(item1);
                                            }
                                        }
                                    }

                                    var q = db.EpTabaghehKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.IsActive = _IsActive;
                                        q.VahedKalaId = _VahedKalaId;
                                        q.VahedKalaName = cmbVahedKala.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.EpGroupAsliKalas = q4;
                                    }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = _Code;
                                        q2.LevelName = _Name;
                                        q2.LevelNamber = _LevelNumber;
                                        q2.IsActive = _IsActive;
                                        q2.EpTabaghehKala1 = q;

                                        var q3 = db.EpAllCodingKalas.Where(s => s.EpGroupAsliKala1.TabaghehId == RowId || s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Id == RowId || s.EpNameKala1.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (_CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter).Replace(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_CodeTabaghehKalaCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter).Replace(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_CodeTabaghehKalaCarakter));
                                                }
                                                if (_IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                        //           s.EpAllCodingHesabdari1.Id == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabGroup1.TabaghehId == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId && s.SalId == _SalId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    foreach (var item in q9)
                                        //    {
                                        //        if (CodeBeforeEdit != _Code)
                                        //            item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                        //                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter));
                                        //        if (IsActiveBeforeEdit != _IsActive)
                                        //            item.IsActive = _IsActive;
                                        //    }
                                        //}
                                        /////////////////////////////////////////////////////////////////////////////////////////////

                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridViewCodingKala();

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView.RowCount > 0)
                                            gridView.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                                {
                                    int RowId = Convert.ToInt32(txtId.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpNameKalas.Where(s => s.EpGroupFareeKala1.EpGroupAsliKala1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                    var q5 = db.EpGroupFareeKalas.Where(s => s.EpGroupAsliKala1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q5.Count > 0)
                                    {
                                        foreach (var item in q5)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q6)
                                            {
                                                if (item1.GroupFareeId == item.Id)
                                                    item.EpNameKalas.Append(item1);
                                            }
                                        }
                                    }
                                    //////////////////////////////////////////////////////
                                    var q = db.EpGroupAsliKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.IsActive = _IsActive;
                                        q.VahedKalaId = _VahedKalaId;
                                        q.VahedKalaName = cmbVahedKala.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.TabaghehId = _TabaghehKalaId;
                                        q.EpGroupFareeKalas = q5;
                                    }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                        q2.LevelName = _Name;
                                        q2.LevelNamber = _LevelNumber;
                                        q2.IsActive = _IsActive;
                                        q2.EpGroupAsliKala1 = q;

                                        var q3 = db.EpAllCodingKalas.Where(s => s.EpGroupAsliKala1.Id == RowId || s.EpGroupFareeKala1.EpGroupAsliKala1.Id == RowId || s.EpNameKala1.EpGroupFareeKala1.EpGroupAsliKala1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (_CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter).Replace(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter).Replace(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter));
                                                }

                                                if (_IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }

                                        }

                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                        //           s.EpAllCodingHesabdari1.Id == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabCol1.GroupId == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    foreach (var item in q9)
                                        //    {
                                        //        if (CodeBeforeEdit != _Code)
                                        //            item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                        //                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                        //        if (IsActiveBeforeEdit != _IsActive)
                                        //            item.IsActive = _IsActive;
                                        //    }
                                        //}
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (_IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        {
                                            var T = db.EpTabaghehKalas.FirstOrDefault(s => s.Id == _TabaghehKalaId && s.SalId == _SalId);
                                            var A = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == _TabaghehKalaId && s.SalId == _SalId);
                                            // var U = db.RmsUserBallCodingHesabdaris.FirstOrDefault(s => s.CodingHesabdariId == _TabaghehId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (A != null)
                                                A.IsActive = true;
                                            //if (U != null)
                                            //    U.IsActive = true;
                                        }


                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridViewCodingKala();
                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView.RowCount > 0)
                                            gridView.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                                {
                                    int RowId = Convert.ToInt32(txtId.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpNameKalas.Where(s => s.GroupFareeId == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (_CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter).Replace(item.Code.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter));
                                            if (_IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    //////////////////
                                    var q = db.EpGroupFareeKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.IsActive = _IsActive;
                                        q.VahedKalaId = _VahedKalaId;
                                        q.VahedKalaName = cmbVahedKala.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.GroupAsliId = _GroupAsliKalaId;
                                        q.IsActive = _IsActive;
                                        q.EpNameKalas = q6;
                                    }
                                    ////////////////////////////////////////////////////
                                    var q2 = db.EpAllCodingKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                        q2.LevelName = _Name;
                                        q2.LevelNamber = _LevelNumber;
                                        q2.IsActive = _IsActive;
                                        q2.EpGroupFareeKala1 = q;

                                        var q3 = db.EpAllCodingKalas.Where(s => s.EpNameKala1.GroupFareeId == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (_CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter).Replace(item.KeyCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter).Replace(item.ParentCode.ToString().Substring(0, _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter));
                                                }

                                                if (_IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }

                                        }


                                        //////////////////////////////////////////////////////////////////////////// 
                                        //var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                        //           s.EpAllCodingHesabdari1.Id == RowId
                                        //        || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.Id == RowId && s.SalId == _SalId).ToList();
                                        //if (q9.Count > 0)
                                        //{
                                        //    foreach (var item in q9)
                                        //    {
                                        //        if (CodeBeforeEdit != _Code)
                                        //            item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter), _Code.ToString())
                                        //            + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));

                                        //        if (IsActiveBeforeEdit != _IsActive)
                                        //            item.IsActive = _IsActive;
                                        //    }
                                        //}
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (_IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                        {
                                            var T = db.EpTabaghehKalas.FirstOrDefault(s => s.Id == _TabaghehKalaId && s.SalId == _SalId);
                                            var G = db.EpGroupAsliKalas.FirstOrDefault(s => s.Id == _GroupAsliKalaId && s.SalId == _SalId);
                                            var A = db.EpAllCodingKalas.Where(s => s.Id == _TabaghehKalaId || s.Id == _GroupAsliKalaId && s.SalId == _SalId);
                                            //var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _TabaghehId || s.CodingHesabdariId == _GroupId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (G != null)
                                                G.IsActive = true;
                                            foreach (var item in A)
                                                item.IsActive = true;
                                            //foreach (var item in U)
                                            //    item.IsActive = true;
                                        }

                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridViewCodingKala();

                                        //  XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView.RowCount > 0)
                                            gridView.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (_SelectedTabPage == "xtraTabPage_NameKala")
                                {
                                    int RowId = Convert.ToInt32(txtId.Text);

                                    var q = db.EpNameKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 0;
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 1;
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 2;
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 3;
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 4;
                                        xtraTabControl_NameKala.SelectedTabPageIndex = 0;

                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.IsActive = _IsActive;
                                        q.VahedKala1Id = _VahedKalaId;
                                        q.VahedKala1Name = cmbVahedKala.Text;
                                        q.VahedAsliId = Convert.ToInt32(cmbVahedAsli.EditValue);
                                        q.VahedAsliName = cmbVahedAsli.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.TarikhEjad = !string.IsNullOrEmpty(txtTarikhEjad.Text) ? Convert.ToDateTime(txtTarikhEjad.Text) : DateTime.Now;

                                        q.GroupFareeId = _GroupFareeKalaId;

                                        if (!string.IsNullOrEmpty(txtCodeEkhtesasi_NameKala.Text))
                                            q.CodeEkhtesasi = Convert.ToInt32(txtCodeEkhtesasi_NameKala.Text);
                                        else
                                            q.CodeEkhtesasi = null;


                                        cmbTaminKonande_NameKala.ShowPopup();
                                        cmbTaminKonande_NameKala.ClosePopup();

                                        if (!string.IsNullOrEmpty(cmbTaminKonande_NameKala.Text))
                                        {
                                            q.TaminKonandeName = cmbTaminKonande_NameKala.Text;

                                            string CheckedItems = string.Empty;
                                            var CheckedList = cmbTaminKonande_NameKala.Properties.GetItems().GetCheckedValues();
                                            if (CheckedList.Count > 0)
                                            {
                                                foreach (var item in CheckedList)
                                                {
                                                    CheckedItems += item.ToString() + ",";
                                                }
                                            }
                                            else
                                                CheckedItems = string.Empty;

                                            q.TaminKonandeId = CheckedItems;
                                        }

                                        q.IscheckVahedKala2 = Convert.ToBoolean(chkVahedKala2_NameKala.Checked);
                                        if (chkVahedKala2_NameKala.Checked && !string.IsNullOrEmpty(cmbVahedKala2_NameKala.Text))
                                        {
                                            q.VahedKala2Id = Convert.ToInt32(cmbVahedKala2_NameKala.EditValue);
                                            q.VahedKala2Name = cmbVahedKala2_NameKala.Text;
                                            if (!string.IsNullOrEmpty(txtHarBaste_NameKala.Text))
                                                q.HarBaste = Convert.ToInt32(txtHarBaste_NameKala.Text);
                                        }
                                        else
                                        {
                                            q.VahedKala2Id = null;
                                            q.VahedKala2Name = null;
                                            q.HarBaste = null;
                                        }

                                        q.IscheckVahedKala3 = Convert.ToBoolean(chkVahedKala3_NameKala.Checked);
                                        if (chkVahedKala3_NameKala.Checked && !string.IsNullOrEmpty(cmbVahedKala3_NameKala.Text))
                                        {
                                            q.VahedKala3Id = Convert.ToInt32(cmbVahedKala3_NameKala.EditValue);
                                            q.VahedKala3Name = cmbVahedKala3_NameKala.Text;
                                            if (!string.IsNullOrEmpty(txtHarKarton_NameKala.Text))
                                                q.HarKarton = Convert.ToInt32(txtHarKarton_NameKala.Text);
                                        }
                                        else
                                        {
                                            q.VahedKala3Id = null;
                                            q.VahedKala3Name = null;
                                            q.HarKarton = null;

                                        }
                                        if (!string.IsNullOrEmpty(txtVazn_NameKala.Text))
                                            q.Vazn = Convert.ToDouble(txtVazn_NameKala.Text);
                                        else
                                            q.Vazn = null;
                                        if (!string.IsNullOrEmpty(txtTool_NameKala.Text))
                                            q.Tool = Convert.ToDouble(txtTool_NameKala.Text);
                                        else
                                            q.Tool = null;
                                        if (!string.IsNullOrEmpty(txtArz_NameKala.Text))
                                            q.Arz = Convert.ToDouble(txtArz_NameKala.Text);
                                        else
                                            q.Arz = null;
                                        if (!string.IsNullOrEmpty(txtErtefae_NameKala.Text))
                                            q.Ertefae = Convert.ToDouble(txtErtefae_NameKala.Text);
                                        else
                                            q.Ertefae = null;
                                        if (!string.IsNullOrEmpty(txtZekhamat_NameKala.Text))
                                            q.Zekhamat = Convert.ToDouble(txtZekhamat_NameKala.Text);
                                        else
                                            q.Zekhamat = null;
                                        if (!string.IsNullOrEmpty(txtMasahat_NameKala.Text))
                                            q.Masahat = Convert.ToDouble(txtMasahat_NameKala.Text);
                                        else
                                            q.Masahat = null;
                                        if (!string.IsNullOrEmpty(txtMohit_NameKala.Text))
                                            q.Mohit = Convert.ToDouble(txtMohit_NameKala.Text);
                                        else
                                            q.Mohit = null;
                                        if (!string.IsNullOrEmpty(txtHajm_NameKala.Text))
                                            q.Hajm = Convert.ToDouble(txtHajm_NameKala.Text);
                                        else
                                            q.Hajm = null;
                                        if (!string.IsNullOrEmpty(txtSaiz_NameKala.Text))
                                            q.Saiz = txtSaiz_NameKala.Text;
                                        else
                                            q.Saiz = null;

                                        q.SerialKala = lstSerialKala_NameKala.Text;
                                        q.ShomareFani = lstShomareFani_NameKala.Text;

                                        if (!string.IsNullOrEmpty(txtGhimatAkharinKharid_NameKala.Text))
                                            q.GhimatAkharinKharid = Convert.ToDecimal(txtGhimatAkharinKharid_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatAkharinKharid = null;
                                        if (!string.IsNullOrEmpty(txtGhimatTamamShode_NameKala.Text))
                                            q.GhimatTamamShode = Convert.ToDecimal(txtGhimatTamamShode_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatTamamShode = null;
                                        if (!string.IsNullOrEmpty(txtGhimatPayeFroosh_NameKala.Text))
                                            q.GhimatPayeFroosh = Convert.ToDecimal(txtGhimatPayeFroosh_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatPayeFroosh = null;
                                        if (!string.IsNullOrEmpty(txtDarsadTakhfif_NameKala.Text))
                                            q.DarsadTakhfif = Convert.ToSingle(txtDarsadTakhfif_NameKala.Text);
                                        else
                                            q.DarsadTakhfif = null;
                                        if (!string.IsNullOrEmpty(txtGhimatNaghdiKhorde1_NameKala.Text))
                                            q.GhimatNaghdiKhorde1 = Convert.ToDecimal(txtGhimatNaghdiKhorde1_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatNaghdiKhorde1 = null;
                                        if (!string.IsNullOrEmpty(txtGhimatNesiyeKhorde1_NameKala.Text))
                                            q.GhimatNesiyeKhorde1 = Convert.ToDecimal(txtGhimatNesiyeKhorde1_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatNesiyeKhorde1 = null;
                                        if (!string.IsNullOrEmpty(txtGhimatNaghdiOmde1_NameKala.Text))
                                            q.GhimatNaghdiOmde1 = Convert.ToDecimal(txtGhimatNaghdiOmde1_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatNaghdiOmde1 = null;
                                        if (!string.IsNullOrEmpty(txtGhimatNesiyeOmde1_NameKala.Text))
                                            q.GhimatNesiyeOmde1 = Convert.ToDecimal(txtGhimatNesiyeOmde1_NameKala.Text.Replace(",", ""));
                                        else
                                            q.GhimatNesiyeOmde1 = null;
                                        if (!string.IsNullOrEmpty(txtNoghteSefaresh_NameKala.Text))
                                            q.NoghteSefaresh = Convert.ToDouble(txtNoghteSefaresh_NameKala.Text);
                                        else
                                            q.NoghteSefaresh = null;
                                        if (!string.IsNullOrEmpty(txtHadeSefaresh_NameKala.Text))
                                            q.HadeSefaresh = Convert.ToDouble(txtHadeSefaresh_NameKala.Text);
                                        else
                                            q.HadeSefaresh = null;

                                        q.IsArzeshAfzode = Convert.ToBoolean(chkArzeshAfzode_NameKala.Checked);

                                        if (pictureEdit1_NameKala.Image != null)
                                        {
                                            MemoryStream ms = new MemoryStream();
                                            img.Save(ms, pictureEdit1_NameKala.Image.RawFormat);
                                            byte[] myarrey = ms.GetBuffer();
                                            q.Pictuer = myarrey;
                                        }
                                        else
                                            q.Pictuer = null;

                                        //////////////////////////
                                        var q2 = db.EpAllCodingKalas.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                        if (q2 != null)
                                        {
                                            q2.KeyCode = _Code;
                                            q2.ParentCode = Convert.ToInt32(txtGroupCode.Text);
                                            q2.LevelName = _Name;
                                            q2.LevelNamber = _LevelNumber;
                                            q2.IsActive = _IsActive;
                                            q2.EpNameKala1 = q;
                                            /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                            //var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == RowId && s.SalId == _SalId).ToList();

                                            //if (q9.Count > 0)
                                            //{

                                            //    foreach (var item in q9)
                                            //    {

                                            //        if (CodeBeforeEdit != _Code)
                                            //            item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter), _Code.ToString())
                                            //            + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter));

                                            //        if (IsActiveBeforeEdit != _IsActive)
                                            //            item.IsActive = _IsActive;
                                            //    }
                                            //}
                                            //////////////////////////////////////////////////////////////////////////////////////
                                            if (_IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                            {
                                                var T = db.EpTabaghehKalas.FirstOrDefault(s => s.Id == _TabaghehKalaId && s.SalId == _SalId);
                                                var G = db.EpGroupAsliKalas.FirstOrDefault(s => s.Id == _GroupAsliKalaId && s.SalId == _SalId);
                                                var C = db.EpGroupFareeKalas.FirstOrDefault(s => s.Id == _GroupFareeKalaId && s.SalId == _SalId);
                                                var A = db.EpAllCodingKalas.Where(s => s.Id == _TabaghehKalaId || s.Id == _GroupAsliKalaId || s.Id == _GroupFareeKalaId && s.SalId == _SalId);
                                                //var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _TabaghehId || s.CodingHesabdariId == _GroupId || s.CodingHesabdariId == _ColId && s.SalId == _SalId);
                                                if (T != null)
                                                    T.IsActive = true;
                                                if (G != null)
                                                    G.IsActive = true;
                                                if (C != null)
                                                    C.IsActive = true;
                                                foreach (var item in A)
                                                    item.IsActive = true;
                                                //foreach (var item in U)
                                                //    item.IsActive = true;
                                            }

                                            db.SaveChanges();
                                        }

                                        btnCancel_Click(null, null);
                                        FillGridViewCodingKala();

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView.RowCount > 0)
                                            gridView.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HelpClass1.ActiveButtons(PanelControl1);
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                if (_SelectedTabPage == "xtraTabPage_NameKala")
                {
                    HelpClass1.ClearControls(xtraTabPage1);
                    HelpClass1.ClearControls(xtraTabPage2);
                    HelpClass1.ClearControls(xtraTabPage3);
                    HelpClass1.ClearControls(xtraTabPage4);
                    HelpClass1.ClearControls(xtraTabPage5);
                    HelpClass1.InActiveControls(xtraTabPage1);
                    HelpClass1.InActiveControls(xtraTabPage2);
                    HelpClass1.InActiveControls(xtraTabPage3);
                    HelpClass1.InActiveControls(xtraTabPage4);
                    HelpClass1.InActiveControls(xtraTabPage5);
                }
                else
                {
                    HelpClass1.ClearControls(PanelControl2);
                    HelpClass1.InActiveControls(PanelControl2);

                }
                btnCreate.Focus();
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

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (gridView.RowCount > 0)
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    txtId.Text = gridView.GetFocusedRowCellValue("Id").ToString();
                    txtName.Text = gridView.GetFocusedRowCellValue("Name").ToString();
                    chkIsActive.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                    txtSharh.Text = gridView.GetFocusedRowCellValue("SharhHesab").ToString();

                    if (_SelectedTabPage == "xtraTabPage_TabaghehKala")
                    {
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKalaId").ToString());
                        txtCode.Text = gridView.GetFocusedRowCellValue("Code").ToString();
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                    {
                        //FillcmbHesabTabagheh();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKalaId").ToString());
                        cmbTabaghehKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("TabaghehId").ToString());
                        txtGroupCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(0, _Carakter);
                        txtCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(_Carakter);
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                    {
                        //FillcmbHesabTabagheh();
                        cmbVahedKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKalaId").ToString());
                        _GroupAsliKalaId = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupAsliId").ToString());
                        _TabaghehKalaId = new MyContext().EpGroupAsliKalas.FirstOrDefault(s => s.Id == _GroupAsliKalaId && s.SalId == _SalId).TabaghehId;
                        cmbTabaghehKala.EditValue = _TabaghehKalaId;

                        cmbGroupAsliKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupAsliId").ToString());
                        txtGroupCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(0, _Carakter);
                        txtCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(_Carakter);
                    }
                    else if (_SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        //FillcmbHesabTabagheh();
                        _GroupFareeKalaId = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupFareeId").ToString());
                        _GroupAsliKalaId = new MyContext().EpGroupFareeKalas.FirstOrDefault(s => s.Id == _GroupFareeKalaId && s.SalId == _SalId).GroupAsliId;
                        _TabaghehKalaId = new MyContext().EpGroupAsliKalas.FirstOrDefault(s => s.Id == _GroupAsliKalaId && s.SalId == _SalId).TabaghehId;
                        cmbTabaghehKala.EditValue = _TabaghehKalaId;

                        _GroupFareeKalaId = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupFareeId").ToString());
                        _GroupAsliKalaId = new MyContext().EpGroupFareeKalas.FirstOrDefault(s => s.Id == _GroupFareeKalaId && s.SalId == _SalId).GroupAsliId;
                        cmbGroupAsliKala.EditValue = _GroupAsliKalaId;

                        cmbGroupFareeKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("GroupFareeId").ToString());
                        txtGroupCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(0, _Carakter);
                        txtCode.Text = gridView.GetFocusedRowCellValue("Code").ToString().Substring(_Carakter);

                        txtCodeEkhtesasi_NameKala.Text = gridView.GetFocusedRowCellValue("CodeEkhtesasi") != null ? gridView.GetFocusedRowCellValue("CodeEkhtesasi").ToString() : "";
                        txtTarikhEjad.Text = gridView.GetFocusedRowCellValue("TarikhEjad") != null ? gridView.GetFocusedRowCellValue("TarikhEjad").ToString().Substring(0, 10) : "";
                        if (gridView.GetFocusedRowCellValue("TaminKonandeId") != null)
                            cmbTaminKonande_NameKala.SetEditValue(gridView.GetFocusedRowCellValue("TaminKonandeId"));
                        else
                            cmbTaminKonande_NameKala.SetEditValue(0);

                        cmbVahedKala.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKala1Id"));
                        cmbVahedAsli.EditValue = Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedAsliId"));

                        chkVahedKala2_NameKala.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IscheckVahedKala2"));
                        cmbVahedKala2_NameKala.EditValue = gridView.GetFocusedRowCellValue("VahedKala2Id") != null ? Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKala2Id")) : 0;
                        txtHarBaste_NameKala.Text = gridView.GetFocusedRowCellValue("HarBaste") != null ? gridView.GetFocusedRowCellValue("HarBaste").ToString() : "";


                        chkVahedKala3_NameKala.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IscheckVahedKala3"));
                        cmbVahedKala3_NameKala.EditValue = gridView.GetFocusedRowCellValue("VahedKala3Id") != null ? Convert.ToInt32(gridView.GetFocusedRowCellValue("VahedKala3Id")) : 0;
                        txtHarKarton_NameKala.Text = gridView.GetFocusedRowCellValue("HarKarton") != null ? gridView.GetFocusedRowCellValue("HarKarton").ToString() : "";

                        txtVazn_NameKala.Text = gridView.GetFocusedRowCellValue("Vazn") != null ? gridView.GetFocusedRowCellValue("Vazn").ToString() : "";
                        txtTool_NameKala.Text = gridView.GetFocusedRowCellValue("Tool") != null ? gridView.GetFocusedRowCellValue("Tool").ToString() : "";
                        txtArz_NameKala.Text = gridView.GetFocusedRowCellValue("Arz") != null ? gridView.GetFocusedRowCellValue("Arz").ToString() : "";
                        txtErtefae_NameKala.Text = gridView.GetFocusedRowCellValue("Ertefae") != null ? gridView.GetFocusedRowCellValue("Ertefae").ToString() : "";
                        txtZekhamat_NameKala.Text = gridView.GetFocusedRowCellValue("Zekhamat") != null ? gridView.GetFocusedRowCellValue("Zekhamat").ToString() : "";
                        txtMasahat_NameKala.Text = gridView.GetFocusedRowCellValue("Masahat") != null ? gridView.GetFocusedRowCellValue("Masahat").ToString() : "";
                        txtMohit_NameKala.Text = gridView.GetFocusedRowCellValue("Mohit") != null ? gridView.GetFocusedRowCellValue("Mohit").ToString() : "";
                        txtHajm_NameKala.Text = gridView.GetFocusedRowCellValue("Hajm") != null ? gridView.GetFocusedRowCellValue("Hajm").ToString() : "";
                        txtSaiz_NameKala.Text = gridView.GetFocusedRowCellValue("Saiz") != null ? gridView.GetFocusedRowCellValue("Saiz").ToString() : "";

                        lstSerialKala_NameKala.Text = gridView.GetFocusedRowCellValue("SerialKala") != null ? gridView.GetFocusedRowCellValue("SerialKala").ToString() : "";
                        lstShomareFani_NameKala.Text = gridView.GetFocusedRowCellValue("ShomareFani") != null ? gridView.GetFocusedRowCellValue("ShomareFani").ToString() : "";


                        txtGhimatAkharinKharid_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatAkharinKharid") != null ? gridView.GetFocusedRowCellValue("GhimatAkharinKharid").ToString() : "";
                        txtGhimatTamamShode_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatTamamShode") != null ? gridView.GetFocusedRowCellValue("GhimatTamamShode").ToString() : "";
                        txtGhimatPayeFroosh_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatPayeFroosh") != null ? gridView.GetFocusedRowCellValue("GhimatPayeFroosh").ToString() : "";
                        txtDarsadTakhfif_NameKala.Text = gridView.GetFocusedRowCellValue("DarsadTakhfif") != null ? gridView.GetFocusedRowCellValue("DarsadTakhfif").ToString() : "";
                        txtGhimatNaghdiKhorde1_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatNaghdiKhorde1") != null ? gridView.GetFocusedRowCellValue("GhimatNaghdiKhorde1").ToString() : "";
                        txtGhimatNesiyeKhorde1_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatNesiyeKhorde1") != null ? gridView.GetFocusedRowCellValue("GhimatNesiyeKhorde1").ToString() : "";
                        txtGhimatNaghdiOmde1_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatNaghdiOmde1") != null ? gridView.GetFocusedRowCellValue("GhimatNaghdiOmde1").ToString() : "";
                        txtGhimatNesiyeOmde1_NameKala.Text = gridView.GetFocusedRowCellValue("GhimatNesiyeOmde1") != null ? gridView.GetFocusedRowCellValue("GhimatNesiyeOmde1").ToString() : "";

                        txtNoghteSefaresh_NameKala.Text = gridView.GetFocusedRowCellValue("NoghteSefaresh") != null ? gridView.GetFocusedRowCellValue("NoghteSefaresh").ToString() : "";
                        txtHadeSefaresh_NameKala.Text = gridView.GetFocusedRowCellValue("HadeSefaresh") != null ? gridView.GetFocusedRowCellValue("HadeSefaresh").ToString() : "";
                        chkArzeshAfzode_NameKala.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsArzeshAfzode"));

                        using (var db = new MyContext())
                        {
                            try
                            {
                                int RowId = Convert.ToInt32(txtId.Text);
                                var q1 = db.EpNameKalas.FirstOrDefault(s => s.Id == RowId);
                                if (q1.Pictuer != null)
                                {
                                    MemoryStream ms = new MemoryStream(q1.Pictuer);
                                    pictureEdit1_NameKala.Image = Image.FromStream(ms);
                                    img = pictureEdit1_NameKala.Image;
                                }
                                else
                                    pictureEdit1_NameKala.Image = null;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
                if (En != EnumCED.Edit)
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void xtraTabControl_CodingKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            _SelectedTabPage = xtraTabControl_CodingKala.SelectedTabPage.Name;
            if (xtraTabControl_CodingKala.SelectedTabPage == xtraTabPage_TabaghehKala)
            {
                gridControl = gridControl_TabaghehKala;
                gridView = gridView_TabaghehKala;
                cmbVahedKala = cmbVahedKala_Tabagheh;
                txtCode = txtCode_Tabagheh;
                txtGroupCode = txtCodeGroup_TabaghehKala;
                chkEditCode = chkEditCode_Tabagheh;
                btnNewCode = btnNewCode_Tabagheh;
                txtId = txtId_Tabagheh;
                txtName = txtName_Tabagheh;
                //txtTarikhEjad
                chkIsActive = chkIsActive_Tabagheh;
                txtSharh = txtSharhHesab_Tabagheh;
                PanelControl1 = panelControl_Button;
                PanelControl2 = panelControl_Tabagheh;
                _LevelNumber = 1;
                //_Carakter;
                txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode.Properties.Mask.EditMask = _CodeTabaghehKalaCarakter == 1 ? "0" :
                                                   _CodeTabaghehKalaCarakter == 2 ? "00" :
                                                   _CodeTabaghehKalaCarakter == 3 ? "000" : "0000";
                txtCode.Properties.MaxLength = _CodeTabaghehKalaCarakter;
                _MinCode = _CodeTabaghehKalaMinCode;
                _MaxCode = _CodeTabaghehKalaMaxCode;
                FillGridViewCodingKala();
                //FillcmbTabaghehKala();
                FillcmbVahedKala();
                btnCreate.Enabled = true;
                btnCreate.Focus();
            }
            else if (xtraTabControl_CodingKala.SelectedTabPage == xtraTabPage_GroupAsli)
            {
                gridControl = gridControl_GroupAsli;
                gridView = gridView_GroupAsli;
                cmbTabaghehKala = cmbTabaghehKala_GroupAsli; ;
                btnReloadTabaghehKala = btnReloadTabaghehKala_GroupAsli;
                cmbVahedKala = cmbVahedKala_GroupAsli;
                txtCode = txtCode_GroupAsli;
                txtGroupCode = txtCodeGroup_GroupAsli;
                chkEditCode = chkEditCode_GroupAsli;
                btnNewCode = btnNewCode_GroupAsli;
                txtId = txtId_GroupAsli;
                txtName = txtName_GroupAsli;
                //txtTarikhEjad
                chkIsActive = chkIsActive_GroupAsli;
                txtSharh = txtSharhHesab_GroupAsli;
                PanelControl1 = panelControl_Button;
                PanelControl2 = panelControl_GroupAsli;
                _LevelNumber = 2;
                _Carakter = _CodeTabaghehKalaCarakter;
                txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode.Properties.Mask.EditMask = _CodeGroupAsliKalaCarakter == 1 ? "0" :
                                                   _CodeGroupAsliKalaCarakter == 2 ? "00" :
                                                   _CodeGroupAsliKalaCarakter == 3 ? "000" : "0000";
                txtCode.Properties.MaxLength = _CodeGroupAsliKalaCarakter;
                _MinCode = _CodeGroupAsliKalaMinCode;
                _MaxCode = _CodeGroupAsliKalaMaxCode;
                FillGridViewCodingKala();
                FillcmbTabaghehKala();
                FillcmbVahedKala();
                btnCreate.Enabled = true;
                btnCreate.Focus();
            }
            else if (xtraTabControl_CodingKala.SelectedTabPage == xtraTabPage_GroupFaree)
            {
                gridControl = gridControl_GroupFaree;
                gridView = gridView_GroupFaree;
                cmbTabaghehKala = cmbTabaghehKala_GroupFaree;
                cmbGroupAsliKala = cmbGroupAsli_GroupFaree;
                btnReloadTabaghehKala = btnReloadTabaghehKala_GroupFaree;
                btnReloadGroupAsli = btnReloadGroupAsli_GroupFaree;
                cmbVahedKala = cmbVahedKala_GroupFaree;
                txtCode = txtCode_GroupFaree;
                txtGroupCode = txtCodeGroup_GroupFaree;
                chkEditCode = chkEditCode_GroupFaree;
                btnNewCode = btnNewCode_GroupFaree;
                txtId = txtId_GroupFaree;
                txtName = txtName_GroupFaree;
                //txtTarikhEjad
                chkIsActive = chkIsActive_GroupFaree;
                txtSharh = txtSharhHesab_GroupFaree;
                PanelControl1 = panelControl_Button;
                PanelControl2 = panelControl_GroupFaree;
                _LevelNumber = 3;
                _Carakter = _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter;
                txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode.Properties.Mask.EditMask = _CodeGroupFareeKalaCarakter == 1 ? "0" :
                                                   _CodeGroupFareeKalaCarakter == 2 ? "00" :
                                                   _CodeGroupFareeKalaCarakter == 3 ? "000" : "0000";
                txtCode.Properties.MaxLength = _CodeGroupFareeKalaCarakter;
                _MinCode = _CodeGroupFareeKalaMinCode;
                _MaxCode = _CodeGroupFareeKalaMaxCode;
                FillGridViewCodingKala();
                FillcmbTabaghehKala();
                FillcmbVahedKala();
                btnCreate.Enabled = true;
                btnCreate.Focus();
            }
            else if (xtraTabControl_CodingKala.SelectedTabPage == xtraTabPage_NameKala)
            {
                gridControl = gridControl_NameKala;
                gridView = gridView_NameKala;
                cmbTabaghehKala = cmbTabaghehKala_NameKala;
                cmbGroupAsliKala = cmbGroupAsli_NameKala;
                cmbGroupFareeKala = cmbGroupFaree_NameKala;
                btnReloadTabaghehKala = btnReloadTabaghehKala_NameKala;
                btnReloadGroupAsli = btnReloadGroupAsli_NameKala;
                btnReloadGroupFaree = btnReloadGroupFaree_NameKala;
                cmbVahedKala = cmbVahedKala1_NameKala;
                txtCode = txtCode_NameKala;
                txtGroupCode = txtCodeGroup_NameKala;
                chkEditCode = chkEditCode_NameKala;
                btnNewCode = btnNewCode_NameKala;
                txtId = txtId_NameKala;
                txtName = txtName_NameKala;
                txtTarikhEjad = txtTarikhEjad_NameKala;
                chkIsActive = chkIsActive_NameKala;
                txtSharh = txtSharhHesab_NameKala;
                PanelControl1 = panelControl_Button;
                PanelControl2 = panelControl_NameKala;
                _LevelNumber = 4;
                _Carakter = _CodeTabaghehKalaCarakter + _CodeGroupAsliKalaCarakter + _CodeGroupFareeKalaCarakter;
                txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode.Properties.Mask.EditMask = _CodeNameKalaCarakter == 1 ? "0" :
                                                   _CodeNameKalaCarakter == 2 ? "00" :
                                                   _CodeNameKalaCarakter == 3 ? "000" : "0000";
                txtCode.Properties.MaxLength = _CodeNameKalaCarakter;
                _MinCode = _CodeNameKalaMinCode;
                _MaxCode = _CodeNameKalaMaxCode;

                HelpClass1.InActiveControls(xtraTabPage1);
                HelpClass1.InActiveControls(xtraTabPage2);
                HelpClass1.InActiveControls(xtraTabPage3);
                HelpClass1.InActiveControls(xtraTabPage4);
                HelpClass1.InActiveControls(xtraTabPage5);

                HelpClass1.DateTimeMask(txtTarikhEjad);

                FillGridViewCodingKala();
                FillcmbTabaghehKala();
                FillcmbTaminKonande();
                FillcmbVahedKala();
                btnCreate.Enabled = true;
                btnCreate.Focus();
            }
            if (xtraTabControl_CodingKala.SelectedTabPage == xtraTabPage_DerakhtVareh)
            {
                treelist = treeListCodingKala;
                btnCreate.Enabled = false;
                FillGridViewCodingKala();
            }
        }

        private void xtraTabControl_CodingKala_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnCancel_Click(null, null);
            }
        }

        private void btnReloadTabaghehKala_Click(object sender, EventArgs e)
        {
            FillcmbTabaghehKala();
        }

        private void btnReloadGroupAsli_Click(object sender, EventArgs e)
        {
            FillcmbGroupAsli();
        }

        private void btnReloadGroupFaree_Click(object sender, EventArgs e)
        {
            FillcmbGroupFaree();
        }

        private void cmbTabaghehKala_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (_SelectedTabPage == "xtraTabPage_GroupAsli")
                    {
                        _TabaghehKalaId = Convert.ToInt32(cmbTabaghehKala.EditValue);
                        var q = db.EpTabaghehKalas.FirstOrDefault(s => s.Id == _TabaghehKalaId && s.SalId == _SalId);
                        if (q != null)
                        {
                            txtGroupCode.Text = q.Code.ToString();
                            cmbVahedKala.EditValue = q.VahedKalaId;
                            if (En == EnumCED.Edit)
                                if (_TabaghehKalaId != TabaghehKalaIdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);

                            else
                                btnNewCode_Click(null, null);
                        }
                    }
                    else if (_SelectedTabPage == "xtraTabPage_GroupFaree" || _SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        FillcmbGroupAsli();
                        cmbGroupAsliKala.EditValue = 0;
                        txtGroupCode.Text = txtCode.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbListGroupAsli_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (_SelectedTabPage == "xtraTabPage_GroupFaree")
                    {
                        _GroupAsliKalaId = Convert.ToInt32(cmbGroupAsliKala.EditValue);
                        var q = db.EpGroupAsliKalas.FirstOrDefault(s => s.Id == _GroupAsliKalaId && s.SalId == _SalId);
                        if (q != null)
                        {
                            txtGroupCode.Text = q.Code.ToString();
                            cmbVahedKala.EditValue = q.VahedKalaId;
                            if (En == EnumCED.Edit)
                                if (_GroupAsliKalaId != GroupAsliIdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);

                            else
                                btnNewCode_Click(null, null);
                        }

                    }
                    else if (_SelectedTabPage == "xtraTabPage_NameKala")
                    {
                        FillcmbGroupFaree();
                        cmbGroupFareeKala.EditValue = 0;
                        txtGroupCode.Text = txtCode.Text = string.Empty;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbGroupFaree_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _GroupFareeKalaId = Convert.ToInt32(cmbGroupFareeKala.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpGroupFareeKalas.FirstOrDefault(s => s.Id == _GroupFareeKalaId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtGroupCode.Text = q.Code.ToString();
                        if (En == EnumCED.Edit)
                            if (_GroupFareeKalaId != GroupFareeIdBeforeEdit)
                            {
                                btnNewCode_Click(null, null);
                            }
                            else
                                txtCode.Text = _CodeBeforeEdit.ToString().Substring(_Carakter);

                        else
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

        private void cmbTabaghehKala_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbTabaghehKala.ShowPopup();
            }
        }

        private void cmbGroupAsli_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupAsliKala.ShowPopup();
            }
        }

        private void cmbGroupFaree_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupFareeKala.ShowPopup();
            }
        }

        private void btnTaminKonande_Click(object sender, EventArgs e)
        {
            FillcmbTaminKonande();
            //FrmTaminKonandeKala fm = new FrmTaminKonandeKala();
            //fm.lblUserId.Text = lblUserId.Text;
            //fm.lblUserName.Text = lblUserName.Text;
            //fm.lblSalId.Text = lblSalId.Text;
            //fm.lblSalMali.Text = lblSalMali.Text;
            //fm.ShowDialog();
        }

        private void cmbVahedKala1_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedKala.ShowPopup();
            }
        }
        private void cmbVahedKala2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedKala2_NameKala.ShowPopup();
            }
        }
        private void cmbVahedKala3_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedKala3_NameKala.ShowPopup();
            }
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            HelpClass1.gridView_RowCellStyle(sender, e);
        }

        private void LookupEdit_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void treeListCodingKala_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "IsActive") return;
            if (e.Node.GetDisplayText(colIsActive1) == "انتخاب نشده")
                e.Appearance.BackColor = Color.Pink;

        }

        private void btnVahedKala_Click(object sender, EventArgs e)
        {
            FrmVahedKala fm = new FrmVahedKala(this);
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();
        }
        int _cmbVahedKala1Id = 0;
        int _cmbVahedKala2Id = 0;
        int _cmbVahedKala3Id = 0;

        public void FillcmbVahedAsli()
        {
            try
            {
                db1 = new MyContext();
                _cmbVahedKala1Id = Convert.ToInt32(cmbVahedKala1_NameKala.EditValue);
                _cmbVahedKala2Id = Convert.ToInt32(cmbVahedKala2_NameKala.EditValue);
                _cmbVahedKala3Id = Convert.ToInt32(cmbVahedKala3_NameKala.EditValue);
                var q = db1.EpVahedKalas.Where(s => s.SalId == _SalId && s.Id == _cmbVahedKala1Id || s.Id == _cmbVahedKala2Id || s.Id == _cmbVahedKala3Id).ToList();
                epVahedKalasBindingSource1.DataSource = q.Count > 0 ? q : null;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmbVahedKala1_EditValueChanged(object sender, EventArgs e)
        {
            // if (!string.IsNullOrEmpty(cmbVahedKala2.Text))
            labelControl24.Text = cmbVahedKala1_NameKala.Text;
            FillcmbVahedAsli();
        }

        private void cmbVahedKala2_EditValueChanged(object sender, EventArgs e)
        {
            if (chkVahedKala2_NameKala.Checked)
            {
                labelControl26.Text = "هر " + cmbVahedKala2_NameKala.Text;
                labelControl21.Text = cmbVahedKala2_NameKala.Text;
                FillcmbVahedAsli();

            }
            //labelControl17.Text = cmbVahedKala1.Text;
            // if (!string.IsNullOrEmpty(cmbVahedKala3.Text))

        }

        private void cmbVahedKala3_EditValueChanged(object sender, EventArgs e)
        {
            if (chkVahedKala3_NameKala.Checked)
            {
                labelControl23.Text = "هر " + cmbVahedKala3_NameKala.Text;
                FillcmbVahedAsli();

            }
            //labelControl18.Text = cmbVahedKala2.Text;

        }

        private void chkVahedKala2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVahedKala2_NameKala.Checked)
            {
                cmbVahedKala2_NameKala.Enabled = true;
                txtHarBaste_NameKala.Enabled = true;
            }
            else
            {
                cmbVahedKala2_NameKala.Enabled = false;
                txtHarBaste_NameKala.Enabled = false;
                cmbVahedKala2_NameKala.EditValue = 0;
                txtHarBaste_NameKala.Text = string.Empty;
            }
        }

        private void chkVahedKala3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVahedKala3_NameKala.Checked)
            {
                cmbVahedKala3_NameKala.Enabled = true;
                txtHarKarton_NameKala.Enabled = true;
            }
            else
            {
                cmbVahedKala3_NameKala.Enabled = false;
                txtHarKarton_NameKala.Enabled = false;
                cmbVahedKala3_NameKala.EditValue = 0;
                txtHarKarton_NameKala.Text = string.Empty;
            }
        }

        private void cmbTaminKonande_NameKala_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbTaminKonande_NameKala.ShowPopup();
            }
        }

        private void xtraTabControl_NameKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            // btnSave.TabStop = btnSaveNext.TabStop = btnCancel.TabStop = false;
            if (xtraTabControl_NameKala.SelectedTabPage == xtraTabPage2)
            {
                cmbVahedKala1_EditValueChanged(null, null);
                cmbVahedKala2_EditValueChanged(null, null);
                cmbVahedKala3_EditValueChanged(null, null);
            }
        }

        private void treeListCodingKala_NodeCellStyle_1(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "IsActive") return;
            if (e.Node.GetDisplayText(colIsActive1) == "انتخاب نشده")
                e.Appearance.BackColor = Color.Pink;

        }

        private void cmbVahedAsli_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbVahedAsli.ShowPopup();
            }
        }

        private void FrmCodingKala_FormClosed(object sender, FormClosedEventArgs e)
        {
            db1.Dispose();
        }
    }
}