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
using EtelaatePaye.CodingAnbar;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmAmaliatVorodeKala : DevExpress.XtraEditors.XtraForm
    {
        FrmAmaliatRozaneh Fm;
        MyContext db;
        public FrmAmaliatVorodeKala(FrmAmaliatRozaneh fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        int _SallId = 0;
        private void FrmAmaliatVorodeKala_Load(object sender, EventArgs e)
        {
            FillcmbNameKala();
            if (Fm.En2 == EnumCED.Create)
            {
                cmb_NameKala.Focus();
            }
            if (Fm.En2 == EnumCED.Edit)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _CodeKala = Convert.ToInt32(Fm._KalaCode);
                        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SallId && s.Code == _CodeKala);
                        if (q != null)
                        {
                            cmb_NameKala.EditValue = q.Id;
                            lblVahedeAsli.Text = Fm._VahedeKala;
                            txtMeghdar.Text = Fm._Meghdar;
                            txtNerkh.Text = Fm._Nerkh;
                            txtMablag.Text = Fm._Mablag;
                            txtTozihat.Text = Fm._Tozihat;
                            // btnSaveAndNext.Enabled = false;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillcmbNameKala()
        {
            try
            {
                db = new MyContext();
                _SallId = Convert.ToInt32(lblSalId.Text);
                var q = db.EpNameKalas.Where(s => s.SalId == _SallId && s.IsActive == true).OrderBy(s => s.Code).ToList();
                epNameKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                //db.EpNameKalas.Where(s => s.SalId == _SallId && s.IsActive == true).LoadAsync().ContinueWith(loadTask =>
                //{
                //    // Bind data to control when loading complete
                //    epNameKalasBindingSource.DataSource = db.EpNameKalas.Local.ToBindingList();
                //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnReload_NameKala_Click(object sender, EventArgs e)
        {
            FillcmbNameKala();
        }

        private void FrmAmaliatVorodeKala_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void cmb_NameKala_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void cmb_NameKala_Enter(object sender, EventArgs e)
        {
            if (Fm.En2 == EnumCED.Create)
            {
                cmb_NameKala.ShowPopup();
            }

        }
        decimal _BefourMeghdar = 0;
        bool IsValidationMeghdar = true;

        private void txtMeghdar_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMeghdar.IsEditorActive)
            {
                if (!string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && txtMeghdar.Text.Trim() != "0/000")
                {
                    txtMablag.EnterMoveNextControl = true;

                    decimal _Meghdar = IsValidationMeghdar ? Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".")) : _BefourMeghdar;
                    decimal _Nerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                    decimal _Mablag = Convert.ToDecimal(_Meghdar * _Nerkh);
                    //decimal stringLength = _Mablag.ToString().Length;

                    if (_Mablag >= 1000000000000000000)
                    {
                        XtraMessageBox.Show("مبلغ وارده خیلی بزرگ خواهد بود" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsValidationMeghdar = false;
                        txtMeghdar.Text = _BefourMeghdar.ToString();
                        txtMablag.Text = _BefourMablag.ToString();
                        txtMablag.Focus();
                        txtMeghdar.Focus();
                        return;
                    }
                    else
                    {
                        txtMeghdar.Text = _Meghdar.ToString();
                        txtMablag.Text = _Mablag.ToString();
                        _BefourMeghdar = _Meghdar;
                        _BefourMablag = _Mablag;
                        IsValidationMeghdar = true;
                    }

                    string _txtTedadeDarVahed1 = !string.IsNullOrEmpty(txtTedadeDarVahed1.Text) ? txtTedadeDarVahed1.Text : "0";
                    string _txtTedadeDarVahed2 = !string.IsNullOrEmpty(txtTedadeDarVahed2.Text) ? txtTedadeDarVahed2.Text : "0";
                    string _txtTedadeDarVahed3 = !string.IsNullOrEmpty(txtTedadeDarVahed3.Text) ? txtTedadeDarVahed3.Text : "0";

                    if (lblVahedeAsli.Text == txtVahed1.Text)
                    {
                        long _TedadeBaste = 0;
                        long _TedadeKarton = 0;
                        long _TedadeBaste1 = 0;
                        decimal _Meghdar1 = 0;

                        if (!string.IsNullOrEmpty(_txtTedadeDarVahed2) && _Meghdar >= Convert.ToDecimal(_txtTedadeDarVahed2) && _txtTedadeDarVahed2 != "0")
                            _TedadeBaste = (long)(_Meghdar / Convert.ToDecimal(_txtTedadeDarVahed2));

                        if (!string.IsNullOrEmpty(_txtTedadeDarVahed3) && _TedadeBaste >= Convert.ToDecimal(_txtTedadeDarVahed3) && _txtTedadeDarVahed3 != "0")
                        {
                            _TedadeKarton = (long)(_TedadeBaste / Convert.ToDecimal(_txtTedadeDarVahed3));
                            txtMeghdar3.Text = _TedadeKarton.ToString();
                        }
                        else
                            txtMeghdar3.Text = "0";

                        if (_TedadeBaste > (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)))
                        {
                            _TedadeBaste1 = (long)(_TedadeBaste - (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)));
                            txtMeghdar2.Text = _TedadeBaste1.ToString();
                        }
                        else
                            txtMeghdar2.Text = "0";

                        if (_Meghdar > _TedadeBaste * Convert.ToDecimal(_txtTedadeDarVahed2))
                        {
                            _Meghdar1 = _Meghdar - (_TedadeBaste * Convert.ToDecimal(_txtTedadeDarVahed2));
                            txtMeghdar1.Text = _Meghdar1.ToString();
                        }
                        else
                            txtMeghdar1.Text = "0";

                    }
                    else if (lblVahedeAsli.Text == txtVahed2.Text)
                    {
                        long _TedadeKarton = 0;


                        if (!string.IsNullOrEmpty(_txtTedadeDarVahed3) && _Meghdar >= Convert.ToDecimal(_txtTedadeDarVahed3) && _txtTedadeDarVahed3 != "0")
                        {
                            _TedadeKarton = (long)(_Meghdar / Convert.ToDecimal(_txtTedadeDarVahed3));
                            txtMeghdar3.Text = _TedadeKarton.ToString();
                        }
                        else
                            txtMeghdar3.Text = "0";

                        if (_Meghdar > (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)))
                        {
                            txtMeghdar2.Text = (_Meghdar - (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3))).ToString();
                        }
                        else
                            txtMeghdar2.Text = "0";

                        txtMeghdar1.Text = "0";

                    }
                    else if (lblVahedeAsli.Text == txtVahed3.Text)
                    {
                        txtMeghdar3.Text = _Meghdar.ToString();
                        txtMeghdar2.Text = "0";
                        txtMeghdar1.Text = "0";
                    }

                }
                else
                {
                    txtMablag.Text = "0";
                    txtMeghdar3.Text = "0";
                    txtMeghdar2.Text = "0";
                    txtMeghdar1.Text = "0";
                }

            }
        }
        decimal _BefourMablag = 0;
        decimal _BefourNerkh = 0;
        bool IsValidationNerkh = true;
        bool IsValidationMablag = true;
        private void txtNerkh_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNerkh.IsEditorActive)
            {
                if (!string.IsNullOrEmpty(txtNerkh.Text.Trim()) && txtNerkh.Text.Trim() != "0/000" && txtMeghdar.Text.Trim() != "0/000")
                {
                    decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                    decimal _Nerkh = IsValidationNerkh ? Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".")) : _BefourNerkh;
                    decimal _Mablag = Convert.ToDecimal(_Meghdar * _Nerkh);
                    //decimal stringLength = _Mablag.ToString().Length;

                    if (_Mablag > 1000000000000000000)
                    {
                        XtraMessageBox.Show("مبلغ وارده خیلی بزرگ خواهد بود" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsValidationNerkh = false;
                        txtNerkh.Text = _BefourNerkh.ToString();
                        txtMablag.Text = _BefourMablag.ToString();
                        txtMablag.Focus();
                        txtNerkh.Focus();
                        return;

                    }
                    else
                    {
                        txtNerkh.Text = _Nerkh.ToString();
                        txtMablag.Text = _Mablag.ToString();
                        _BefourNerkh = _Nerkh;
                        _BefourMablag = _Mablag;
                        IsValidationNerkh = true;
                    }
                }
                else
                    txtMablag.Text = "0";
            }
        }

        private void cmb_NameKala_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _KalaName = Convert.ToInt32(cmb_NameKala.EditValue);
                    var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SallId && s.Id == _KalaName);
                    txtVahed3.Text = q != null ? q.VahedKala3Name : string.Empty;
                    txtVahed2.Text = q != null ? q.VahedKala2Name : string.Empty;
                    txtVahed1.Text = q != null ? q.VahedKala1Name : string.Empty;
                    lblVahedeAsli.Text = q != null ? q.VahedAsliName : string.Empty;

                    txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : string.Empty;
                    txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : string.Empty;

                    txtMeghdar_EditValueChanged(null, null);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public bool IsValidation()
        {
            // string s = txtMeghdar.Text.Trim();
            if (Convert.ToInt32(cmb_NameKala.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً نام کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_NameKala.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtMeghdar.Text) || txtMeghdar.Text.Trim() == "0/000")
            {
                XtraMessageBox.Show("لطفاً مقدار کالا را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMeghdar.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNerkh.Text) || txtNerkh.Text.Trim() == "0/000")
            {
                XtraMessageBox.Show("لطفاً نرخ کالا را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNerkh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtMablag.Text) || txtMablag.Text.Trim() == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ کالا را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablag.Focus();
                return false;
            }
            return true;
        }

        bool IsClosed = true;
        private void btnSaveAndClosed_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (IsValidation())
                    {
                        if (Fm.En2 == EnumCED.Create)
                        {
                            int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SallId && s.Id == _NameKalaId);
                            if (q != null)
                            {
                                Fm._KalaCode = q.Code.ToString();
                                Fm._KalaName = q.Name;
                                Fm._VahedeKala = q.VahedAsliName;
                                Fm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                                Fm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                                Fm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                                if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                                    Fm._Tozihat = txtTozihat.Text.Trim();
                                else
                                    Fm._Tozihat = null;

                                Fm.gridView_AmaliatAddVaEdit.AddNewRow();
                                Fm.gridView_AmaliatAddVaEdit.FocusInvalidRow();

                                if (IsClosed)
                                    this.Close();
                            }
                        }
                        else if (Fm.En2 == EnumCED.Edit)
                        {
                            int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SallId && s.Id == _NameKalaId);
                            if (q != null)
                            {
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "KalaCode", q.Code);
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "KalaName", q.Name);
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "VahedeKala", q.VahedAsliName);
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                                if (IsClosed)
                                    this.Close();
                            }
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

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (IsValidation())
            {
                IsClosed = false;
                btnSaveAndClosed_Click(null, null);
                Fm.En2 = EnumCED.Create;
                cmb_NameKala.EditValue = 0;
                txtMeghdar.Text = txtNerkh.Text = "0";
                txtMablag.Text = "0";
                txtTozihat.Text = string.Empty;
                cmb_NameKala.Focus();
            }
        }

        private void btnReloadNameKala_Click(object sender, EventArgs e)
        {
            FrmCodingKala fm = new FrmCodingKala();
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            //fm.xtraTabControl_CodingKala.SelectedTabPageIndex = 0;
            //fm.xtraTabControl_CodingKala.SelectedTabPageIndex = 3;
            fm.Show();
        }

        private void txtMablag_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMablag.IsEditorActive)
            {
                if (!string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && txtMeghdar.Text.Trim() != "0/000" && txtMablag.Text.Trim() != "0")
                {
                    decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                    decimal _Mablag = IsValidationMablag ? Convert.ToDecimal(txtMablag.Text.Trim().Replace(",", "").Replace("/", ".")) : _BefourMablag;
                    decimal _Nerkh = Convert.ToDecimal(_Mablag / _Meghdar);
                    //decimal stringLength = _Mablag.ToString().Length;

                    if (_Mablag > 1000000000000000000)
                    {
                        XtraMessageBox.Show("مبلغ وارده خیلی بزرگ خواهد بود" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsValidationMablag = false;
                        txtNerkh.Text = _BefourNerkh.ToString();
                        txtMablag.Text = _BefourMablag.ToString();
                        txtNerkh.Focus();
                        txtMablag.Focus();
                        return;

                    }
                    else
                    {
                        txtNerkh.Text = _Nerkh.ToString();
                        txtMablag.Text = _Mablag.ToString();
                        _BefourNerkh = _Nerkh;
                        _BefourMablag = _Mablag;
                        IsValidationMablag = true;
                    }

                }
                else
                    txtNerkh.Text = "0";
            }
        }

        private void txtMeghdar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMeghdar.Text.Trim()) || txtMeghdar.Text.Trim() == "0/000")
            {
                txtMablag.EnterMoveNextControl = false;
                txtMeghdar.Focus();
                return;
            }

        }
    }
}