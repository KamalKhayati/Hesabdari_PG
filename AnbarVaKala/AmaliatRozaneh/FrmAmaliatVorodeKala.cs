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
            cmb_NameKala.Focus();
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
                var q = db.EpNameKalas.Where(s => s.SalId == _SallId && s.IsActive == true).ToList();
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
            if (!string.IsNullOrEmpty(txtNerkh.Text.Trim()) && txtNerkh.Text.Trim() != "0" && !string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && txtMeghdar.Text.Trim() != "0")
            {
                decimal _Meghdar = IsValidationMeghdar ? Convert.ToDecimal(txtMeghdar.Text.Replace(",", "").Replace("/", ".")) : _BefourMeghdar;
                decimal _Nerkh = Convert.ToDecimal(txtNerkh.Text.Replace(",", "").Replace("/", "."));
                decimal _Mablag = Convert.ToDecimal(_Meghdar * _Nerkh);
                //decimal stringLength = _Mablag.ToString().Length;

                if (_Mablag > 1000000000000000000)
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

                long _TedadeBaste = 0;
                long _TedadeKarton = 0;
                long _TedadeBaste1 = 0;
                decimal _Meghdar1 = 0;

                if (!string.IsNullOrEmpty(txtTedadeDarVahed2.Text) && _Meghdar >= Convert.ToDecimal(txtTedadeDarVahed2.Text)&& txtTedadeDarVahed2.Text != "0")
                    _TedadeBaste = (long)(_Meghdar / Convert.ToDecimal(txtTedadeDarVahed2.Text));

                if (!string.IsNullOrEmpty(txtTedadeDarVahed3.Text) && _TedadeBaste >= Convert.ToDecimal(txtTedadeDarVahed3.Text) && txtTedadeDarVahed3.Text != "0")
                {
                    _TedadeKarton = (long)(_TedadeBaste / Convert.ToDecimal(txtTedadeDarVahed3.Text));
                    txtMeghdar3.Text = _TedadeKarton.ToString();
                }
                else
                    txtMeghdar3.Text = "0";

                if (_TedadeBaste > (_TedadeKarton * Convert.ToDecimal(txtTedadeDarVahed3.Text)))
                {
                    _TedadeBaste1 = (long)(_TedadeBaste - (_TedadeKarton * Convert.ToDecimal(txtTedadeDarVahed3.Text)));
                    txtMeghdar2.Text = _TedadeBaste1.ToString();
                }
                else
                    txtMeghdar2.Text = "0";

                if (_Meghdar > _TedadeBaste * Convert.ToDecimal(txtTedadeDarVahed2.Text))
                {
                    _Meghdar1 = _Meghdar -(_TedadeBaste * Convert.ToDecimal(txtTedadeDarVahed2.Text)) ;
                    txtMeghdar1.Text = _Meghdar1.ToString();
                }
                else
                    txtMeghdar1.Text = "0";


            }
            else
            {
                txtMablag.Text = "0";
                txtMeghdar3.Text = "0";
                txtMeghdar2.Text = "0";
                txtMeghdar1.Text = "0";
            }

        }
        decimal _BefourMablag = 0;
        decimal _BefourNerkh = 0;
        bool IsValidationNerkh = true;
        private void txtNerkh_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && txtMeghdar.Text.Trim() != "0" && !string.IsNullOrEmpty(txtNerkh.Text.Trim()) && txtNerkh.Text.Trim() != "0")
            {
                decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Replace(",", "").Replace("/", "."));
                decimal _Nerkh = IsValidationNerkh ? Convert.ToDecimal(txtNerkh.Text.Replace(",", "").Replace("/", ".")) : _BefourNerkh;
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

        private void cmb_NameKala_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _NameKala = Convert.ToInt32(cmb_NameKala.EditValue);
                    var q = db.EpNameKalas.FirstOrDefault(s => s.Id == _NameKala);
                    txtVahed3.Text = q != null ? q.VahedKala3Name : string.Empty;
                    txtVahed2.Text = q != null ? q.VahedKala2Name : string.Empty;
                    txtVahed1.Text = q != null ? q.VahedKala1Name : string.Empty;
                    lblVahedeAsli.Text = q != null ? q.VahedAsliName : string.Empty;

                    txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : "0"; ;
                    txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : "0"; ;
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