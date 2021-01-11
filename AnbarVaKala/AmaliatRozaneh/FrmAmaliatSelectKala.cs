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
using DBHesabdari_PG.Models.EP.CodingAnbar;
using AnbarVaKala.Reports;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmAmaliatSelectKala : DevExpress.XtraEditors.XtraForm
    {
        FrmAmaliatRozanehAnbarVKala Fm;
        FrmJabejaeeKala Jm;
        FrmMojodiAvalDoreKala Dm;
        MyContext db;

        public FrmAmaliatSelectKala(FrmAmaliatRozanehAnbarVKala fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        public FrmAmaliatSelectKala(FrmJabejaeeKala jm)
        {
            InitializeComponent();
            Jm = jm;
        }
        public FrmAmaliatSelectKala(FrmMojodiAvalDoreKala dm)
        {
            InitializeComponent();
            Dm = dm;
        }
        int _SalId = 0;
        //public EnumCED En3 = EnumCED.Cancel;
        public void FillCmbNameAnbar2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q1 = db.EpListAnbarhas.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                    var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                    foreach (var item in q1)
                    {
                        var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                        if (qq.Count > 0)
                        {
                            string _KalaId = String.Empty;
                            foreach (var item2 in qq)
                            {
                                _KalaId += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                            }
                            item.TabagheKalaIdName_NM = _KalaId;
                        }
                    }

                    if (Fm != null)
                    {
                        if (Fm.En2 == EnumCED.Edit)
                            epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;
                        else
                            epListAnbarhasBindingSource.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).ToList() : null;
                    }
                    else if (Jm != null)
                    {
                        if (Jm.En2 == EnumCED.Edit)
                            epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;
                        else
                            epListAnbarhasBindingSource.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).ToList() : null;

                    }
                    else if (Dm != null)
                    {
                        if (Dm.En2 == EnumCED.Edit)
                            epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1 : null;
                        else
                            epListAnbarhasBindingSource.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).ToList() : null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmAmaliatSelectKala_Load(object sender, EventArgs e)
        {
            FillCmbNameAnbar2();
            if (Fm != null)
            {
                if (Fm.En2 == EnumCED.Create)
                {
                    if (Fm._FirstSelectAnbar_NextSanad == false)
                    {
                        cmbNameAnbar2.Enabled = true;
                        btnReloadNameAnbar2.Enabled = true;
                        cmbNameAnbar2.Focus();
                    }
                    else
                    {
                        cmbNameAnbar2.EditValue = AzAnbarId;
                        cmb_NameKala.Focus();

                    }
                }
                else if (Fm.En2 == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            cmbNameAnbar2.EditValue = Fm._AzAnbarId;
                            cmb_NameKala.EditValue = Convert.ToInt32(Fm._KalaId);
                            lblVahedeAsli.Text = Fm._VahedeKala;
                            txtMeghdar.Text = Fm._Meghdar;
                            txtNerkh.Text = Fm._Nerkh;
                            txtMablag.Text = Fm._Mablag;
                            txtTozihat.Text = Fm._Tozihat;
                            // btnSaveAndNext.Enabled = false;
                            if (Fm._FirstSelectAnbar_NextSanad == false)
                            {
                                cmbNameAnbar2.Enabled = true;
                                btnReloadNameAnbar2.Enabled = true;
                                cmbNameAnbar2.Focus();
                            }
                            else
                            {
                                cmb_NameKala.Focus();

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
            else if (Jm != null)
            {
                if (Jm.En2 == EnumCED.Create)
                {
                    cmbNameAnbar2.EditValue = AzAnbarId;
                    cmb_NameKala.Focus();
                }
                else if (Jm.En2 == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            cmbNameAnbar2.EditValue = Jm._AzAnbarId;
                            cmb_NameKala.EditValue = Convert.ToInt32(Jm._KalaId);
                            lblVahedeAsli.Text = Jm._VahedeKala;
                            txtMeghdar.Text = Jm._Meghdar;
                            txtNerkh.Text = Jm._Nerkh;
                            txtMablag.Text = Jm._Mablag;
                            txtTozihat.Text = Jm._Tozihat;
                            // btnSaveAndNext.Enabled = false;
                            cmb_NameKala.Focus();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            else if (Dm != null)
            {
                if (Dm.En2 == EnumCED.Create)
                {
                    if (Dm._FirstSelectAnbar_NextSanad == false)
                    {
                        cmbNameAnbar2.Enabled = true;
                        btnReloadNameAnbar2.Enabled = true;
                        cmbNameAnbar2.Focus();
                    }
                    else
                    {
                        cmbNameAnbar2.EditValue = AzAnbarId;
                        cmb_NameKala.Focus();
                    }
                }
                else if (Dm.En2 == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            long _CodeKala = Convert.ToInt64(Dm._KalaCode);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Code == _CodeKala);
                            if (q != null)
                            {
                                cmbNameAnbar2.EditValue = Dm._AzAnbarId;
                                cmb_NameKala.EditValue = Convert.ToInt32(Dm._KalaId);
                                lblVahedeAsli.Text = Dm._VahedeKala;
                                txtMeghdar.Text = Dm._Meghdar;
                                txtNerkh.Text = Dm._Nerkh;
                                txtMablag.Text = Dm._Mablag;
                                txtTozihat.Text = Dm._Tozihat;
                                // btnSaveAndNext.Enabled = false;
                                if (Dm._FirstSelectAnbar_NextSanad == false)
                                {
                                    cmbNameAnbar2.Enabled = true;
                                    btnReloadNameAnbar2.Enabled = true;
                                    cmbNameAnbar2.Focus();
                                }
                                else
                                {
                                    cmb_NameKala.Focus();

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


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int AzAnbarId = 0;
        public int BeAnbarId = 0;

        public void FillcmbNameKala()
        {
            try
            {
                db = new MyContext();
                _SalId = Convert.ToInt32(lblSalId.Text);
                AzAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                //var q3 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                var q6 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId && s.AzAnbarId == AzAnbarId).ToList();
                var q1 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == AzAnbarId).Select(s => s.TabagheKalaId).ToList();
                List<EpNameKala> List1 = new List<EpNameKala>();
                IEnumerable<int> List2 = null;

                if (Fm != null)
                {
                    List2 = q1;
                }
                else if (Jm != null)
                {
                    var q2 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == BeAnbarId).Select(s => s.TabagheKalaId).ToList();
                    List2 = q2.Except(q2.Except(q1));

                }
                else if (Dm != null)
                {
                    List2 = q1;

                }

                foreach (var item in List2)
                {
                    var q5 = db.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.TabaghehId == item).ToList();
                    List1.AddRange(q5);
                }
                var q = List1.OrderBy(s => s.Code).ToList();
                foreach (var item in q)
                {
                    item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                    item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                    item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                    item.MeghdarMa_NM = q6.Where(s => s.KalaId == item.Id && (s.NoeAmaliatCode == 1 || s.NoeAmaliatCode == 2)).Sum(s => s.Meghdar) - q6.Where(s => s.KalaId == item.Id && s.NoeAmaliatCode == 3).Sum(s => s.Meghdar);
                }


                if (Fm != null)
                {
                    if (Fm.En2 == EnumCED.Edit)
                        epNameKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                    else
                        epNameKalasBindingSource.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true) : null;
                }
                else if (Jm != null)
                {
                    if (Jm.En2 == EnumCED.Edit)
                        epNameKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                    else
                        epNameKalasBindingSource.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true) : null;
                }
                else if (Dm != null)
                {
                    if (Dm.En2 == EnumCED.Edit)
                        epNameKalasBindingSource.DataSource = q.Count > 0 ? q : null;
                    else
                        epNameKalasBindingSource.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true) : null;
                }


                //db.EpNameKalas.Where(s => s.SalId == _SallId ).LoadAsync().ContinueWith(loadTask =>
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

        private void FrmAmaliatSelectKala_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (db != null)
                db.Dispose();
        }

        private void cmb_NameKala_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void cmb_NameKala_Enter(object sender, EventArgs e)
        {
            if (Fm != null)
            {
                if (Fm.En2 == EnumCED.Create)
                {
                    cmb_NameKala.ShowPopup();
                }

            }
            else if (Jm != null)
            {
                if (Jm.En2 == EnumCED.Create)
                {
                    cmb_NameKala.ShowPopup();
                }
            }
            else if (Dm != null)
            {
                if (Dm.En2 == EnumCED.Create)
                {
                    cmb_NameKala.ShowPopup();
                }
            }
        }
        decimal _BefourMeghdar = 0;
        bool IsValidationMeghdar = true;

        private void txtMeghdar_EditValueChanged(object sender, EventArgs e)
        {
            
            if (txtMeghdar.IsHandleCreated)
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
            if (txtNerkh.IsHandleCreated)
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
                    int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                    var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                    txtVahed3.Text = q != null ? q.EpVahedKala3.Name : string.Empty;
                    txtVahed2.Text = q != null ? q.EpVahedKala2.Name : string.Empty;
                    txtVahed1.Text = q != null ? q.EpVahedKala1.Name : string.Empty;
                    lblVahedeAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
                    txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : string.Empty;
                    txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : string.Empty;

                    decimal MeghdarMa_NM = Convert.ToDecimal(cmb_NameKala.Properties.GetDataSourceValue("MeghdarMa_NM", cmb_NameKala.ItemIndex));
                    txtMeghdarMa.Text = MeghdarMa_NM.ToString();

                    if (MeghdarMa_NM != 0)
                    {
                        string _txtTedadeDarVahed1 = !string.IsNullOrEmpty(txtTedadeDarVahed1.Text) ? txtTedadeDarVahed1.Text : "0";
                        string _txtTedadeDarVahed2 = !string.IsNullOrEmpty(txtTedadeDarVahed2.Text) ? txtTedadeDarVahed2.Text : "0";
                        string _txtTedadeDarVahed3 = !string.IsNullOrEmpty(txtTedadeDarVahed3.Text) ? txtTedadeDarVahed3.Text : "0";

                        if (lblVahedeAsli.Text == txtVahed1.Text)
                        {
                            long _TedadeBaste = 0;
                            long _TedadeKarton = 0;
                            long _TedadeBaste1 = 0;
                            decimal _Meghdar1 = 0;

                            if (!string.IsNullOrEmpty(_txtTedadeDarVahed2) && MeghdarMa_NM >= Convert.ToDecimal(_txtTedadeDarVahed2) && _txtTedadeDarVahed2 != "0")
                                _TedadeBaste = (long)(MeghdarMa_NM / Convert.ToDecimal(_txtTedadeDarVahed2));

                            if (!string.IsNullOrEmpty(_txtTedadeDarVahed3) && _TedadeBaste >= Convert.ToDecimal(_txtTedadeDarVahed3) && _txtTedadeDarVahed3 != "0")
                            {
                                _TedadeKarton = (long)(_TedadeBaste / Convert.ToDecimal(_txtTedadeDarVahed3));
                                txtmojodi3.Text = _TedadeKarton.ToString();
                            }
                            else
                                txtmojodi3.Text = "0";

                            if (_TedadeBaste > (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)))
                            {
                                _TedadeBaste1 = (long)(_TedadeBaste - (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)));
                                txtmojodi2.Text = _TedadeBaste1.ToString();
                            }
                            else
                                txtmojodi2.Text = "0";

                            if (MeghdarMa_NM > _TedadeBaste * Convert.ToDecimal(_txtTedadeDarVahed2))
                            {
                                _Meghdar1 = MeghdarMa_NM - (_TedadeBaste * Convert.ToDecimal(_txtTedadeDarVahed2));
                                txtmojodi1.Text = _Meghdar1.ToString();
                            }
                            else
                                txtmojodi1.Text = "0";

                        }
                        else if (lblVahedeAsli.Text == txtVahed2.Text)
                        {
                            long _TedadeKarton = 0;


                            if (!string.IsNullOrEmpty(_txtTedadeDarVahed3) && MeghdarMa_NM >= Convert.ToDecimal(_txtTedadeDarVahed3) && _txtTedadeDarVahed3 != "0")
                            {
                                _TedadeKarton = (long)(MeghdarMa_NM / Convert.ToDecimal(_txtTedadeDarVahed3));
                                txtmojodi3.Text = _TedadeKarton.ToString();
                            }
                            else
                                txtmojodi3.Text = "0";

                            if (MeghdarMa_NM > (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3)))
                            {
                                txtmojodi2.Text = (MeghdarMa_NM - (_TedadeKarton * Convert.ToDecimal(_txtTedadeDarVahed3))).ToString();
                            }
                            else
                                txtmojodi2.Text = "0";

                            txtmojodi1.Text = "0";

                        }
                        else if (lblVahedeAsli.Text == txtVahed3.Text)
                        {
                            txtmojodi1.Text = MeghdarMa_NM.ToString();
                            txtmojodi2.Text = "0";
                            txtmojodi3.Text = "0";
                        }

                    }
                    else
                    {
                        txtmojodi1.Text = "0";
                        txtmojodi2.Text = "0";
                        txtmojodi3.Text = "0";
                    }

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
                        AzAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);

                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Create)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Fm._AzAnbarId = AzAnbarId;
                                    Fm._KalaId = q.Id.ToString();
                                    Fm._KalaCode = q.Code.ToString();
                                    Fm._KalaName = q.Name;
                                    Fm._VahedeKala = q.VahedAsliName_NM;
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
                                    {
                                        this.Close();
                                    }
                                }
                            }
                            else if (Fm.En2 == EnumCED.Edit)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "AzAnbarId", AzAnbarId);
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "KalaId", q.Id);
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "KalaCode", q.Code);
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "KalaName", q.Name);
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "VahedeKala", q.VahedAsliName_NM);
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                    Fm.gridView_AmaliatAddVaEdit.SetRowCellValue(Fm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                                    if (IsClosed)
                                    {
                                        this.Close();
                                    }
                                }
                            }
                        }
                        else if (Jm != null)
                        {
                            if (Jm.En2 == EnumCED.Create)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Jm._AzAnbarId = AzAnbarId;
                                    Jm._KalaId = q.Id.ToString();
                                    Jm._KalaCode = q.Code.ToString();
                                    Jm._KalaName = q.Name;
                                    Jm._VahedeKala = q.VahedAsliName_NM;
                                    Jm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Jm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Jm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                                    if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                                        Jm._Tozihat = txtTozihat.Text.Trim();
                                    else
                                        Jm._Tozihat = null;

                                    Jm.gridView_AmaliatAddVaEdit.AddNewRow();
                                    Jm.gridView_AmaliatAddVaEdit.FocusInvalidRow();

                                    if (IsClosed)
                                    {
                                        this.Close();
                                    }
                                }
                            }
                            else if (Jm.En2 == EnumCED.Edit)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "AzAnbarId", AzAnbarId);
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaId", q.Id);
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaCode", q.Code);
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaName", q.Name);
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "VahedeKala", q.VahedAsliName_NM);
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                    Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                                    if (IsClosed)
                                    {
                                        this.Close();
                                    }
                                }
                            }
                        }
                        else if (Dm != null)
                        {
                            if (Dm.En2 == EnumCED.Create)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Dm._AzAnbarId = AzAnbarId;
                                    Dm._KalaId = q.Id.ToString();
                                    Dm._KalaCode = q.Code.ToString();
                                    Dm._KalaName = q.Name;
                                    Dm._VahedeKala = q.VahedAsliName_NM;
                                    Dm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Dm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Dm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                                    if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                                        Dm._Tozihat = txtTozihat.Text.Trim();
                                    else
                                        Dm._Tozihat = null;

                                    Dm.gridView_AmaliatAddVaEdit.AddNewRow();
                                    Dm.gridView_AmaliatAddVaEdit.FocusInvalidRow();

                                    if (IsClosed)
                                    {
                                        this.Close();
                                    }
                                }
                            }
                            else if (Dm.En2 == EnumCED.Edit)
                            {
                                int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                                if (q != null)
                                {
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "AzAnbarId", AzAnbarId);
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaId", q.Id);
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaCode", q.Code);
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaName", q.Name);
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "VahedeKala", q.VahedAsliName_NM);
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                    Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                                    if (IsClosed)
                                    {
                                        this.Close();
                                    }
                                }
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
                if (Fm != null)
                {
                    Fm.En2 = EnumCED.Create;
                }
                else if (Jm != null)
                {
                    Jm.En2 = EnumCED.Create;
                }
                else if (Dm != null)
                {
                    Dm.En2 = EnumCED.Create;
                }
                cmb_NameKala.EditValue = 0;
                txtMeghdar.Text = txtNerkh.Text = "0";
                txtMablag.Text = "0";
                txtMeghdar1.Text = "0";
                txtMeghdar2.Text = "0";
                txtMeghdar3.Text = "0";
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

        private void FrmAmaliatSelectKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveAndClosed_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSaveAndNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }

        }

        private void cmbControl_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            HelpClass1._IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));
        }

        private void btnKardes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_NameKala.Text) || Convert.ToInt32(cmb_NameKala.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً کالای مورد نظر را انتخاب کنید",
                                  "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_NameKala.ShowPopup();
            }
            else
            {
                FrmKardeksKala fm = new FrmKardeksKala();
                // fm.MdiParent = this;
                fm.lblUserId.Text = lblUserId.Text;
                fm.lblUserName.Text = lblUserName.Text;
                fm.lblSalId.Text = lblSalId.Text;
                fm.lblSalMali.Text = lblSalMali.Text;
                using (var db = new MyContext())
                {
                    try
                    {
                        int _DoreMaliId = Convert.ToInt32(lblSalId.Text);
                        var q = db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == _DoreMaliId).StartDoreMali;
                        if (q != null)
                            fm.txtAzTarikh.Text = q.ToString();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                fm.txtTaTarikh.Text = DateTime.Now.ToString();
                fm._chkIsEdgham = false;
                fm.cmbAnbarName.EditValue = AzAnbarId;
                fm.cmbKalaName.EditValue = Convert.ToInt32(cmb_NameKala.EditValue);
                //fm.cmbNoeGozaresh.SelectedIndex = Convert.ToInt32(cmbNoeGozaresh.SelectedIndex);
                fm.Show();
            }

        }

        private void btnMojodiAnbarVKala_Click(object sender, EventArgs e)
        {
            FrmMojodiAnbarVKala fm = new FrmMojodiAnbarVKala();
            // fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            using (var db = new MyContext())
            {
                try
                {
                    int _DoreMaliId = Convert.ToInt32(lblSalId.Text);
                    var q = db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == _DoreMaliId).StartDoreMali;
                    if (q != null)
                        fm.txtAzTarikh.Text = q.ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            fm.txtTaTarikh.Text = DateTime.Now.ToString();
            fm.chkIsEdgham.Checked = false;
            fm._EditValueId = AzAnbarId;
            //fm.cmbKalaName.EditValue = Convert.ToInt32(cmb_NameKala.EditValue);
            //fm.cmbNoeGozaresh.SelectedIndex = Convert.ToInt32(cmbNoeGozaresh.SelectedIndex);
            fm.Show();

        }

        private void btnReloadNameAnbar2_Click(object sender, EventArgs e)
        {
            FillCmbNameAnbar2();
        }

        private void cmbNameAnbar2_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNameAnbar2.Text != "")
            {
                FillcmbNameKala();
            }
        }

        private void cmbNameAnbar2_Enter(object sender, EventArgs e)
        {
            if (cmbNameAnbar2.Text == "")
            {
                cmbNameAnbar2.ShowPopup();
            }

        }
        bool _IsActiveRow = true;

        private void cmbNameAnbar2_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            if (!_IsActiveRow)
                e.Appearance.ForeColor = Color.Red;

            if (e.Header.Caption == "فعال" && e.DisplayText == "True")
                e.DisplayText = "بله";
            if (e.Header.Caption == "فعال" && e.DisplayText == "False")
                e.DisplayText = "خیر";
            if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "True")
                e.DisplayText = "بله";
            if (e.Header.Caption == "اجازه موجودی منفی" && e.DisplayText == "False")
                e.DisplayText = "خیر";

        }

        private void cmbNameAnbar2_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));

        }
    }
}