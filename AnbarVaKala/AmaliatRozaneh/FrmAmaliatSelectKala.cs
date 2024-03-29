﻿using System;
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
using DBHesabdari_PG.Models.AK;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmAmaliatSelectKala : DevExpress.XtraEditors.XtraForm
    {
        FrmAmaliatRozanehAnbarVKala Fm;
        MyContext db;
        public GridControl gridControl;
        public GridView gridView;
        public SimpleButton btnInsert;
        public SimpleButton btnDelete;
        public SimpleButton btnEdit;
        public int AzAnbarId = 0;
        public int BeAnbarId = 0;
        string AzAnbarName = string.Empty;
        string BeAnbarName = string.Empty;

        public FrmAmaliatSelectKala(FrmAmaliatRozanehAnbarVKala fm)
        {
            InitializeComponent();
            Fm = fm;
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
                    if (Fm._FirstSelectAnbar_NextSanad)
                    {
                        var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                        foreach (var item in q1)
                        {
                            var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                            if (qq.Count > 0)
                            {
                                string _TabagheKala = String.Empty;
                                foreach (var item2 in qq)
                                {
                                    _TabagheKala += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                                }
                                item.TabagheKalaIdName_NM = _TabagheKala;
                            }
                        }

                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Edit)
                                epListAnbarhasBindingSource.DataSource = q1.Count > 0 ? q1.OrderBy(s => s.Code).ToList() : null;
                            else
                                epListAnbarhasBindingSource.DataSource = q1.Where(s => s.IsActive == true).ToList().Count > 0 ? q1.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList() : null;
                        }

                    }
                    else
                    {
                        int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        int _TabagheKalaId = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId).EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Id;
                        var qq = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.TabagheKalaId == _TabagheKalaId).Select(s => s.AnbarhId).ToList();
                        var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                        List<EpListAnbarha> List1 = new List<EpListAnbarha>();
                        if (qq.Count > 0)
                        {
                            foreach (var item in qq)
                            {
                                var qp1 = q.FirstOrDefault(s => s.Id == item);
                                List1.Add(qp1);
                            }
                        }
                        else
                        {
                            List1 = q;
                        }

                        var q2 = db.EpTabaghehKalas.Where(s => s.SalId == _SalId).ToList();

                        foreach (var item in List1)
                        {
                            var qq1 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == item.Id).Select(s => s.TabagheKalaId).ToList();
                            if (qq.Count > 0)
                            {
                                string _TabagheKala = String.Empty;
                                foreach (var item2 in qq1)
                                {
                                    _TabagheKala += q2.FirstOrDefault(s => s.Id == item2).Name + ",";
                                }
                                item.TabagheKalaIdName_NM = _TabagheKala;
                            }
                            var qq2 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                            item.MeghdarMa_NM = qq2.Where(s => s.KalaId == _KalaId && s.BeAnbarId == item.Id && s.NameAmaliatCode == 2).Sum(s => s.Meghdar) - qq2.Where(s => s.KalaId == _KalaId && s.AzAnbarId == item.Id && s.NameAmaliatCode == 3).Sum(s => s.Meghdar);
                        }

                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Edit)
                                epListAnbarhasBindingSource.DataSource = List1.Count > 0 ? List1.OrderBy(s => s.Code).ToList() : null;
                            else
                                epListAnbarhasBindingSource.DataSource = List1.Where(s => s.IsActive == true).ToList().Count > 0 ? List1.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList() : null;
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

        private void FrmAmaliatSelectKala_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            if (Fm._FirstSelectAnbar_NextSanad)
                FillCmbNameAnbar2();
            else
                FillcmbNameKala();
            db = new MyContext();
            var qq = db.EpVahedKalas.Where(s => s.SalId == _SalId).ToList();
            if (Fm != null)
            {
                if (Fm.En2 == EnumCED.Create)
                {
                    if (Fm._FirstSelectAnbar_NextSanad)
                    {
                        if (btnInsert.Name == "btnInsert1")
                            cmbNameAnbar2.EditValue = Fm._AzAnbarId;
                        else if (btnInsert.Name == "btnInsert2")
                            cmbNameAnbar2.EditValue = Fm._BeAnbarId;
                    }

                    cmb_NameKala.ShowPopup();

                }
                else if (Fm.En2 == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            if (btnEdit.Name == "btnEdit1")
                            {
                                if (Fm._FirstSelectAnbar_NextSanad)
                                {
                                    cmbNameAnbar2.EditValue = Fm._AzAnbarId;
                                    cmb_NameKala.EditValue = Fm._KalaId;
                                }
                                else
                                {
                                    cmb_NameKala.EditValue = Fm._KalaId;
                                    cmbNameAnbar2.EditValue = Fm._AzAnbarId;
                                }
                            }
                            else if (btnEdit.Name == "btnEdit2")
                            {
                                if (Fm._FirstSelectAnbar_NextSanad)
                                {
                                    cmbNameAnbar2.EditValue = Fm._BeAnbarId;
                                    cmb_NameKala.EditValue = Fm._KalaId;
                                }
                                else
                                {
                                    cmb_NameKala.EditValue = Fm._KalaId;
                                    cmbNameAnbar2.EditValue = Fm._BeAnbarId;
                                }
                            }


                            lblVahedeAsli.Text = qq.FirstOrDefault(s => s.Id == Fm._VahedeKalaId).Name;
                            txtMeghdar.Text = Fm._Meghdar;
                            txtNerkh.Text = Fm._Nerkh;
                            txtMablag.Text = Fm._Mablag;
                            txtTozihat.Text = Fm._Tozihat;
                            // btnSaveAndNext.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                if (Fm._NameSanadIndex == 8 || Fm._NameSanadIndex == 9)
                {
                    cmbNameAnbar2.Enabled = false;
                    btnReloadNameAnbar2.Enabled = false;
                    cmbNameAnbar2.EditValue = AzAnbarId;
                    cmb_NameKala.Focus();
                }
                else
                {
                    if (Fm._FirstSelectAnbar_NextSanad == false)
                    {
                        cmbNameAnbar2.Enabled = true;
                        btnReloadNameAnbar2.Enabled = true;
                    }
                    cmb_NameKala.Focus();

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
                if (Fm._FirstSelectAnbar_NextSanad)
                {
                    db = new MyContext();
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    AzAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                    BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                    List<AKAmaliatAnbarVKala_Riz> _List3 = new List<AKAmaliatAnbarVKala_Riz>();
                    var qq1 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                    var qq2 = qq1.Where(s => s.BeAnbarId == BeAnbarId && s.NameAmaliatCode == 2).ToList();
                    var qq3 = qq1.Where(s => s.AzAnbarId == AzAnbarId && s.NameAmaliatCode == 3).ToList();
                    if (qq2.Count > 0)
                        _List3.AddRange(qq2);
                    if (qq3.Count > 0)
                        _List3.AddRange(qq3);

                    //var q3 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                    //var q6 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == AzAnbarId).ToList();
                    var q1 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == AzAnbarId).Select(s => s.TabagheKalaId).ToList();
                    List<EpNameKala> List1 = new List<EpNameKala>();
                    IEnumerable<int> List2 = null;

                    if (Fm != null)
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
                        item.VahedAsliName_NM = List1.FirstOrDefault(s => s.EpAllCodingKala1.Id == item.Id).EpVahedAsliKala.Name;
                        item.MeghdarMa_NM = _List3.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 2).Sum(s => s.Meghdar) - _List3.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 3).Sum(s => s.Meghdar);
                    }


                    if (Fm != null)
                    {
                        if (Fm.En2 == EnumCED.Edit)
                            epNameKalasBindingSource.DataSource = q.Count > 0 ? q.OrderBy(s => s.Code).ToList() : null;
                        else
                            epNameKalasBindingSource.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList() : null;
                    }

                }
                else
                {
                    db = new MyContext();
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                    //BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                    //List<AKAmaliatAnbarVKala_Riz> _List3 = new List<AKAmaliatAnbarVKala_Riz>();
                    var qq1 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId).ToList();
                    //var qq2 = qq1.Where(s => s.KalaId == _KalaId && s.NameAmaliatCode == 2).ToList();
                    //var qq3 = qq1.Where(s => s.KalaId == _KalaId && s.NameAmaliatCode == 3).ToList();
                    //if (qq2.Count > 0)
                    //    _List3.AddRange(qq2);
                    //if (qq3.Count > 0)
                    //_List3.AddRange(qq3);

                    //var q3 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                    //var q6 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == AzAnbarId).ToList();
                    //var q1 = db.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == AzAnbarId).Select(s => s.TabagheKalaId).ToList();
                    //List<EpNameKala> List1 = new List<EpNameKala>();
                    //IEnumerable<int> List2 = null;

                    //if (Fm != null)
                    //{
                    //    List2 = q1;
                    //}

                    //foreach (var item in List2)
                    //{
                    //    var q5 = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    //    List1.AddRange(q5);
                    //}
                    var q = db.EpNameKalas.Where(s => s.SalId == _SalId).ToList();
                    foreach (var item in q)
                    {
                        item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                        item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                        item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                        item.VahedAsliName_NM = q.FirstOrDefault(s => s.EpAllCodingKala1.Id == item.Id).EpVahedAsliKala.Name;
                        item.MeghdarMa_NM = qq1.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 2).Sum(s => s.Meghdar) - qq1.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 3).Sum(s => s.Meghdar);
                    }


                    if (Fm != null)
                    {
                        if (Fm.En2 == EnumCED.Edit)
                            epNameKalasBindingSource.DataSource = q.Count > 0 ? q.OrderBy(s => s.Code).ToList() : null;
                        else
                            epNameKalasBindingSource.DataSource = q.Where(s => s.IsActive == true).ToList().Count > 0 ? q.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList() : null;
                    }

                }



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
            //else if (Jm != null)
            //{
            //    if (Jm.En2 == EnumCED.Create)
            //    {
            //        cmb_NameKala.ShowPopup();
            //    }
            //}
            //else if (Dm != null)
            //{
            //    if (Dm.En2 == EnumCED.Create)
            //    {
            //        cmb_NameKala.ShowPopup();
            //    }
            //}
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
                        //txtNerkh.Text = _Nerkh.ToString();
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
                    if (Fm._FirstSelectAnbar_NextSanad)
                    {
                        int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                        txtVahed3.Text = q != null && q.EpVahedKala3 != null ? q.EpVahedKala3.Name : string.Empty;
                        txtVahed2.Text = q != null && q.EpVahedKala2 != null ? q.EpVahedKala2.Name : string.Empty;
                        txtVahed1.Text = q != null && q.EpVahedKala1 != null ? q.EpVahedKala1.Name : string.Empty;
                        lblVahedeAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
                        txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : string.Empty;
                        txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : string.Empty;

                        decimal MeghdarMa_NM = 0;
                        //if (Fm._FirstSelectAnbar_NextSanad)
                        MeghdarMa_NM = Convert.ToDecimal(cmb_NameKala.Properties.GetDataSourceValue("MeghdarMa_NM", cmb_NameKala.ItemIndex));
                        //else
                        //    MeghdarMa_NM = Convert.ToDecimal(cmbNameAnbar2.Properties.GetDataSourceValue("MeghdarMa_NM", cmbNameAnbar2.ItemIndex));

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

                        //txtMeghdar_EditValueChanged(null, null);

                    }
                    else
                    {
                        FillCmbNameAnbar2();

                        if (!string.IsNullOrEmpty(cmbNameAnbar2.Text) && !string.IsNullOrEmpty(cmb_NameKala.Text))
                        {
                            int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                            txtVahed3.Text = q != null && q.EpVahedKala3 != null ? q.EpVahedKala3.Name : string.Empty;
                            txtVahed2.Text = q != null && q.EpVahedKala2 != null ? q.EpVahedKala2.Name : string.Empty;
                            txtVahed1.Text = q != null && q.EpVahedKala1 != null ? q.EpVahedKala1.Name : string.Empty;
                            lblVahedeAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
                            txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : string.Empty;
                            txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : string.Empty;

                            decimal MeghdarMa_NM = 0;
                            //if (Fm._FirstSelectAnbar_NextSanad)
                            MeghdarMa_NM = Convert.ToDecimal(cmbNameAnbar2.Properties.GetDataSourceValue("MeghdarMa_NM", cmbNameAnbar2.ItemIndex));
                            //else
                            //    MeghdarMa_NM = Convert.ToDecimal(cmbNameAnbar2.Properties.GetDataSourceValue("MeghdarMa_NM", cmbNameAnbar2.ItemIndex));

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

                            // txtMeghdar_EditValueChanged(null, null);

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
                        if (sender == btnSaveAndClosed)
                            IsClosed = true;
                        if (Fm._FirstSelectAnbar_NextSanad == false)
                        {
                            if (Fm._NameSanadIndex != 8 && Fm._NameSanadIndex != 9)
                            {
                                AzAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                                BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                            }
                        }
                        AzAnbarName = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == AzAnbarId).Name;
                        BeAnbarName = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == BeAnbarId).Name;
                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Create)
                            {
                                int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                                if (q != null)
                                {
                                    Fm._AzAnbarId = AzAnbarId;
                                    Fm._BeAnbarId = BeAnbarId;
                                    Fm._KalaId = _KalaId;
                                    Fm._VahedeKalaId = q.VahedAsliId;
                                    Fm._KalaCode_NM = q.Code.ToString();
                                    Fm._KalaName_NM = q.Name;
                                    Fm._VahedeKala_NM = q.EpVahedAsliKala.Name;
                                    Fm._AzAnbarName_NM = AzAnbarName;
                                    Fm._BeAnbarName_NM = BeAnbarName;
                                    Fm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Fm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                                    Fm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                                    if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                                        Fm._Tozihat = txtTozihat.Text.Trim();
                                    else
                                        Fm._Tozihat = null;

                                    //Fm.gridView_AmaliatAddVaEdit1_InitNewRow(null,null);
                                    Fm.gridView1.AddNewRow();
                                    Fm.gridView1.FocusInvalidRow();

                                }
                            }
                            else if (Fm.En2 == EnumCED.Edit)
                            {
                                int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                                if (q != null)
                                {
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "AzAnbarId", AzAnbarId);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "BeAnbarId", BeAnbarId);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaId", q.Id);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "VahedeKalaId", q.VahedAsliId);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaCode_NM", q.Code);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaName_NM", q.Name);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "VahedeKala_NM", q.EpVahedAsliKala.Name);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "AzAnbarName_NM", AzAnbarName);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "BeAnbarName_NM", BeAnbarName);
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                    Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Tozihat", txtTozihat.Text.Trim());


                                }

                            }

                            if (Fm._NameSanadIndex == 8)
                            {
                                Fm.amaliatAnbarVKala_RizsBindingSource2.DataSource = null;
                                Fm.amaliatAnbarVKala_RizsBindingSource2.DataSource = Fm.amaliatAnbarVKala_RizsBindingSource1.DataSource;
                            }

                            if (IsClosed)
                            {
                                this.Close();
                            }

                        }
                        //else if (Jm != null)
                        //{
                        //    if (Jm.En2 == EnumCED.Create)
                        //    {
                        //        int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        //        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                        //        if (q != null)
                        //        {
                        //            Jm._AzAnbarId = AzAnbarId;
                        //            Jm._KalaId = q.Id;
                        //            Jm._KalaCode_NM = q.Code.ToString();
                        //            Jm._KalaName_NM = q.Name;
                        //            Jm._VahedeKala_NM = q.EpVahedAsliKala.Name;
                        //            Jm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                        //            Jm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                        //            Jm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                        //            if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                        //                Jm._Tozihat = txtTozihat.Text.Trim();
                        //            else
                        //                Jm._Tozihat = null;

                        //            Jm.gridView_AmaliatAddVaEdit.AddNewRow();
                        //            Jm.gridView_AmaliatAddVaEdit.FocusInvalidRow();

                        //        }
                        //    }
                        //    else if (Jm.En2 == EnumCED.Edit)
                        //    {
                        //        int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        //        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                        //        if (q != null)
                        //        {
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "AzAnbarId", AzAnbarId);
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaId", q.Id);
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaCode", q.Code);
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "KalaName", q.Name);
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "VahedeKala", q.EpVahedAsliKala.Name);
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                        //            Jm.gridView_AmaliatAddVaEdit.SetRowCellValue(Jm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                        //        }
                        //    }

                        //    if (IsClosed)
                        //    {
                        //        this.Close();
                        //    }

                        //}
                        //else if (Dm != null)
                        //{
                        //    if (Dm.En2 == EnumCED.Create)
                        //    {
                        //        int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        //        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                        //        if (q != null)
                        //        {
                        //            Dm._AzAnbarId = AzAnbarId;
                        //            Dm._KalaId = q.Id;
                        //            Dm._KalaCode_NM = q.Code.ToString();
                        //            Dm._KalaName_NM = q.Name;
                        //            Dm._VahedeKala_NM = q.EpVahedAsliKala.Name;
                        //            Dm._Meghdar = txtMeghdar.Text.Trim().Replace(",", "").Replace("/", ".");
                        //            Dm._Nerkh = txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".");
                        //            Dm._Mablag = txtMablag.Text.Trim().Replace(",", "");
                        //            if (!string.IsNullOrEmpty(txtTozihat.Text.Trim()))
                        //                Dm._Tozihat = txtTozihat.Text.Trim();
                        //            else
                        //                Dm._Tozihat = null;

                        //            Dm.gridView_AmaliatAddVaEdit.AddNewRow();
                        //            Dm.gridView_AmaliatAddVaEdit.FocusInvalidRow();

                        //        }
                        //    }
                        //    else if (Dm.En2 == EnumCED.Edit)
                        //    {
                        //        int _NameKalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                        //        var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _NameKalaId);
                        //        if (q != null)
                        //        {
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "AzAnbarId", AzAnbarId);
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaId", q.Id);
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaCode", q.Code);
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "KalaName", q.Name);
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "VahedeKala", q.EpVahedAsliKala.Name);
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("/", "."));
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                        //            Dm.gridView_AmaliatAddVaEdit.SetRowCellValue(Dm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                        //        }
                        //    }

                        //    if (IsClosed)
                        //    {
                        //        this.Close();
                        //    }

                        //}

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
                //cmbNameAnbar2.EditValue = 0;
                //cmb_NameKala.EditValue = 0;
                txtMeghdar.Text = txtNerkh.Text = "0";
                txtMablag.Text = "0";
                txtMeghdar1.Text = "0";
                txtMeghdar2.Text = "0";
                txtMeghdar3.Text = "0";
                txtTozihat.Text = string.Empty;

                if (Fm != null)
                {
                    Fm.En2 = EnumCED.Create;
                    if (cmbNameAnbar2.Enabled == true)
                    {
                        cmbNameAnbar2.Focus();
                    }
                    else
                    {
                        cmb_NameKala.Focus();
                    }
                    //if (Fm._FirstSelectAnbar_NextSanad)
                    //    cmb_NameKala.Focus();
                    //else
                    //    cmbNameAnbar2.Focus();

                }
                //else if (Jm != null)
                //{
                //    Jm.En2 = EnumCED.Create;
                //    if (Fm._FirstSelectAnbar_NextSanad)
                //        cmb_NameKala.Focus();
                //    else
                //        cmbNameAnbar2.Focus();
                //}
                //else if (Dm != null)
                //{
                //    Dm.En2 = EnumCED.Create;
                //    if (Fm._FirstSelectAnbar_NextSanad)
                //        cmb_NameKala.Focus();
                //    else
                //        cmbNameAnbar2.Focus();
                //}
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
            fm.ShowDialog();
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
                        //txtMablag.Text = _Mablag.ToString();
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

        private void cmb_NameKala_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
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
                if (Fm._FirstSelectAnbar_NextSanad == true)
                    FillcmbNameKala();
                //else if (Fm._FirstSelectAnbar_NextSanad == false)
                // {
                //     //FillcmbNameKala();

                // }

                if (Fm._NameSanadIndex != 8 && Fm._NameSanadIndex != 9)
                {
                    AzAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                    BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                }


                using (var db = new MyContext())
                {
                    try
                    {
                        if (!Fm._FirstSelectAnbar_NextSanad && !string.IsNullOrEmpty(cmb_NameKala.Text))
                        {
                            int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                            txtVahed3.Text = q != null && q.EpVahedKala3 != null ? q.EpVahedKala3.Name : string.Empty;
                            txtVahed2.Text = q != null && q.EpVahedKala2 != null ? q.EpVahedKala2.Name : string.Empty;
                            txtVahed1.Text = q != null && q.EpVahedKala1 != null ? q.EpVahedKala1.Name : string.Empty;
                            lblVahedeAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
                            txtTedadeDarVahed3.Text = q != null ? q.HarKarton.ToString() : string.Empty;
                            txtTedadeDarVahed2.Text = q != null ? q.HarBaste.ToString() : string.Empty;

                            decimal MeghdarMa_NM = 0;
                            //if (Fm._FirstSelectAnbar_NextSanad)
                            MeghdarMa_NM = Convert.ToDecimal(cmbNameAnbar2.Properties.GetDataSourceValue("MeghdarMa_NM", cmbNameAnbar2.ItemIndex));
                            //else
                            //    MeghdarMa_NM = Convert.ToDecimal(cmbNameAnbar2.Properties.GetDataSourceValue("MeghdarMa_NM", cmbNameAnbar2.ItemIndex));

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

                            // txtMeghdar_EditValueChanged(null, null);

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

        private void cmbNameAnbar2_Enter(object sender, EventArgs e)
        {
            if (Fm.En2 == EnumCED.Create)
                cmbNameAnbar2.ShowPopup();

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