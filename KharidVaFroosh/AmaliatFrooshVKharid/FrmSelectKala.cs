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
using FrooshVKharid.AmaliatFrooshVKharid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.FK;
using HelpClassLibrary;
using EtelaatePaye.CodingAnbar;
using AnbarVaKala.Reports;
using DBHesabdari_PG.Models.AK;
using System.Data.Entity;
using DBHesabdari_PG.Models.EP.CodingHesabdari;

namespace KharidVaFroosh.AmaliatFrooshVKharid
{
    public partial class FrmSelectKala : DevExpress.XtraEditors.XtraForm
    {
        FrmFactor Fm;
        MyContext dbContext;
        public GridControl gridControl;
        public GridView gridView;
        public SimpleButton btnInsert;
        public SimpleButton btnDelete;
        public SimpleButton btnEdit;
        public int? _AnbarId = null;
        public int? _KalaId = null;
        //public int? _VahedeKalaId = null;
        public int? _VizitorId = null;
        public int? _Ez_KsId = null;
        //public int BeAnbarId = 0;
        string _AnbarName = null;
        string _KalaName = null;
        //string _VizitorName = null;
        string _VahedeKalaName = null;
        string _KalaCode = null;
        bool _IsActiveRow = true;

        public FrmSelectKala(FrmFactor fm)
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
                    if (Fm._FirstSelectAnbar_NextSanad && Fm._NoeFactor == 0 && Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
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
                    else if (!Fm._FirstSelectAnbar_NextSanad && Fm._NoeFactor == 0 && Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
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
                    else
                    {
                        epListAnbarhasBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmSelectKala_Load(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            xtraTabControl1.SelectedTabPageIndex = 0;
            _SalId = Convert.ToInt32(lblSalId.Text);
            if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
            {
                cmb_NameKala.Visible = true;
                this.MinimumSize = new Size(757, 416);
                panelControl_CmbControl.Height = 93;
                panelControl_CmbControl.Width = 936;
                txtMeghdar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtMeghdar.Properties.Mask.EditMask = "c3";
                if (Fm.Name == "FrmFactorFrooshKala" || Fm.Name == "FrmFactorBargashtAzFrooshKala" || Fm.Name == "FrmSefareshFrooshKala")
                    if (Fm.En2 == EnumCED.Create)
                        txtDarsadTakhfifRadifiKala.Text = (Convert.ToSingle(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) + Convert.ToSingle(Fm.txtDarsadTakhfifRadifi.Text.Replace(",", "").Replace("/", "."))).ToString();
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
            {
                cmb_NameKala.Visible = true;
                btnReloadNameAnbar2.Visible = cmbNameAnbar2.Visible = lblAnbarName2.Visible = false;
                btnKardes.Visible = btnMojodiAnbarVKala.Visible = txtMeghdarMa.Visible = lblMeghdarMa.Visible = false;
                this.MinimumSize = new Size(757, 530);
                this.MaximumSize = new Size(757, 530);
                panelControl_CmbControl.Size = new Size(749, 44);
                panelControl_DataEnter.Size = new Size(751, 407);
                panelControl_Report.Size = new Size(749, 0);
                cmb_NameKala.Properties.Columns["MeghdarMa_NM"].Visible = false;
                txtMeghdar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtMeghdar.Properties.Mask.EditMask = "c2";
                txtNerkh.Properties.Mask.EditMask = "n";
                if ((Fm.Name == "FrmFactorFrooshKhadamat" || Fm.Name == "FrmFactorBargashtAzFrooshKhadamat" || Fm.Name == "FrmSefareshFrooshKhadamat") && Fm._NoeFactor == 1)
                    if (Fm.En2 == EnumCED.Create)
                        txtDarsadTakhfifRadifiKala.Text = (Convert.ToSingle(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) + Convert.ToSingle(Fm.txtDarsadTakhfifRadifi.Text.Replace(",", "").Replace("/", "."))).ToString();
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat")
            {
                cmbEz_Ks.Visible = true;
                btnReloadNameAnbar2.Visible = cmbNameAnbar2.Visible = lblAnbarName2.Visible = false;
                btnKardes.Visible = btnMojodiAnbarVKala.Visible = txtMeghdarMa.Visible = lblMeghdarMa.Visible = false;
                txtMotefareghe.Visible = txtTakhfifRadifiKala.Visible = txtDarsadTakhfifRadifiKala.Visible = txtMabKhales.Visible = txtMaliat.Visible = txtAvarez.Visible = txtDarsadMabMaliat.Visible = txtDarsadMabAvarez.Visible = txtMabBadeMaliat.Visible = txtNerkh.Visible = false;
                lblMotefareghe.Visible = lblTakhfifRadifiKala.Visible = lblMabKhales.Visible = lblMaliat.Visible = lblAvarez.Visible = lblMabBadeMaliat.Visible = lblNerkh.Visible = false;
                lblVahedAsli.Visible = txtVahedAsli.Visible = false;
                lblNameKala.Text = "نوع اضافات";
                //txtNerkh.ReadOnly = true;
                //lblNerkh.Text = "جمع کل فاکتور";
                //lblNerkh.ForeColor = Color.Blue;
                //panelControl_JameColFactor.Visible = true;
                this.MinimumSize = new Size(757, 378);
                this.MaximumSize = new Size(757, 378);
                panelControl_CmbControl.Size = new Size(749, 44);
                panelControl_DataEnter.Size = new Size(751, 255);
                panelControl_Report.Size = new Size(749, 0);
                txtMeghdar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtMeghdar.Properties.Mask.EditMask = "c2";
                txtNerkh.Properties.Mask.EditMask = "n";
                lblMeghdar.Text = "درصد %";
                //txtMeghdar.Properties.MaxLength = 5;
                //txtAghlamKala.Text = Fm.txtJameAghlamKala.Text;
                //txtAghlamKhadamat.Text = Fm.txtJameAghlamKhadamat.Text;
                chkAghlamKala.Checked = true;
                chkAghlamKhadamat.Checked = true;
                chkKsorat.Checked = true;
                //if (Fm.En2 == EnumCED.Edit)
                //    txtEzafat.Text = (Convert.ToDecimal(Fm.txtEzafatFactor.Text) - Convert.ToDecimal(Fm.gridView1.GetFocusedRowCellValue("Mablag"))).ToString();
                //else
                //    txtEzafat.Text = Fm.txtEzafatFactor.Text;
                //txtKsorat.Text = Fm.txtKsoratFactor.Text;
                //chkEzafat.Enabled = false;
                //txtJameColFactor.Text = (Convert.ToDecimal(txtAghlamKala.Text) + Convert.ToDecimal(txtAghlamKhadamat.Text) + Convert.ToDecimal(txtchkMaliat.Text) + Convert.ToDecimal(txtEzafat.Text) - Convert.ToDecimal(txtKsorat.Text)).ToString();
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
            {
                cmbEz_Ks.Visible = true;
                btnReloadNameAnbar2.Visible = cmbNameAnbar2.Visible = lblAnbarName2.Visible = false;
                btnKardes.Visible = btnMojodiAnbarVKala.Visible = txtMeghdarMa.Visible = lblMeghdarMa.Visible = false;
                txtMotefareghe.Visible = txtTakhfifRadifiKala.Visible = txtDarsadTakhfifRadifiKala.Visible = txtMabKhales.Visible = txtMaliat.Visible = txtAvarez.Visible = txtDarsadMabMaliat.Visible = txtDarsadMabAvarez.Visible = txtMabBadeMaliat.Visible = txtNerkh.Visible = false;
                lblMotefareghe.Visible = lblTakhfifRadifiKala.Visible = lblMabKhales.Visible = lblMaliat.Visible = lblAvarez.Visible = lblMabBadeMaliat.Visible = false;
                lblVahedAsli.Visible = txtVahedAsli.Visible = false;
                lblNameKala.Text = "نوع کسورات";
                //txtNerkh.ReadOnly = true;
                //lblNerkh.Text = "جمع کل فاکتور";
                //lblNerkh.ForeColor = Color.Blue;
                //panelControl_JameColFactor.Visible = true;
                //chkKsorat.Enabled = false;
                //chkKsorat.Checked = false;
                this.MinimumSize = new Size(757, 378);
                this.MaximumSize = new Size(757, 378);
                panelControl_CmbControl.Size = new Size(749, 44);
                panelControl_DataEnter.Size = new Size(751, 255);
                panelControl_Report.Size = new Size(749, 0);
                txtMeghdar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtMeghdar.Properties.Mask.EditMask = "c2";
                txtNerkh.Properties.Mask.EditMask = "n";
                lblMeghdar.Text = "درصد %";
                //txtMeghdar.Properties.MaxLength = 5;
                //txtAghlamKala.Text = Fm.txtJameAghlamKala.Text;
                //txtAghlamKhadamat.Text = Fm.txtJameAghlamKhadamat.Text;
                chkAghlamKala.Checked = true;
                chkAghlamKhadamat.Checked = true;
                chkEzafat.Checked = true;
                if (Fm.En2 == EnumCED.Create)
                    txtMeghdar.Text = Fm.txtDarsadTakhfifJamei.Text;
                //txtEzafat.Text = Fm.txtEzafatFactor.Text;
                //if (Fm.En2 == EnumCED.Edit)
                //    txtKsorat.Text = (Convert.ToDecimal(Fm.txtKsoratFactor.Text) - Convert.ToDecimal(Fm.gridView1.GetFocusedRowCellValue("Mablag"))).ToString();
                //else
                //    txtKsorat.Text = Fm.txtKsoratFactor.Text;
                //chkKsorat.Checked = false;
                //chkKsorat.Enabled = false;
                //txtJameColFactor.Text = (Convert.ToDecimal(txtAghlamKala.Text) + Convert.ToDecimal(txtAghlamKhadamat.Text) + Convert.ToDecimal(txtchkMaliat.Text) + Convert.ToDecimal(txtEzafat.Text) - Convert.ToDecimal(txtKsorat.Text)).ToString();
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
            {

                cmbVizitor.Visible = true;
                btnReloadNameAnbar2.Visible = cmbNameAnbar2.Visible = lblAnbarName2.Visible = false;
                btnKardes.Visible = btnMojodiAnbarVKala.Visible = txtMeghdarMa.Visible = lblMeghdarMa.Visible = false;
                txtMotefareghe.Visible = txtTakhfifRadifiKala.Visible = txtDarsadTakhfifRadifiKala.Visible = txtMabKhales.Visible = txtMaliat.Visible = txtAvarez.Visible = txtDarsadMabMaliat.Visible = txtDarsadMabAvarez.Visible = txtMabBadeMaliat.Visible = txtNerkh.Visible = false;
                lblMotefareghe.Visible = lblTakhfifRadifiKala.Visible = lblMabKhales.Visible = lblMaliat.Visible = lblAvarez.Visible = lblMabBadeMaliat.Visible = lblNerkh.Visible = false;
                lblVahedAsli.Visible = txtVahedAsli.Visible = false;
                //txtNerkh.ReadOnly = true;
                lblNameKala.Text = "نام ویزیتور/واسطه";
                //lblNerkh.ForeColor = Color.Blue;
                //panelControl_JameColFactor.Visible = true;
                this.MinimumSize = new Size(757, 378);
                this.MaximumSize = new Size(757, 378);
                panelControl_CmbControl.Size = new Size(749, 44);
                panelControl_DataEnter.Size = new Size(751, 255);
                panelControl_Report.Size = new Size(749, 0);
                //cmb_NameKala.Properties.Columns["MeghdarMa_NM"].Visible = false;
                //cmb_NameKala.Properties.Columns["VahedAsliName_NM"].Visible = false;
                txtMeghdar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                txtMeghdar.Properties.Mask.EditMask = "c2";
                txtNerkh.Properties.Mask.EditMask = "n";
                lblMeghdar.Text = "درصد %";
                //txtMeghdar.Properties.MaxLength = 5;
                //txtAghlamKala.Text = Fm.txtJameAghlamKala.Text;
                //txtAghlamKhadamat.Text = Fm.txtJameAghlamKhadamat.Text;
                chkAghlamKala.Checked = true;
                chkAghlamKhadamat.Checked = true;
                chkEzafat.Checked = true;
                chkKsorat.Checked = true;
                //if (Fm.En2 == EnumCED.Edit)
                //    txtEzafat.Text = (Convert.ToDecimal(Fm.txtEzafatFactor.Text) - Convert.ToDecimal(Fm.gridView1.GetFocusedRowCellValue("Mablag"))).ToString();
                //else
                //    txtEzafat.Text = Fm.txtEzafatFactor.Text;
                //txtKsorat.Text = Fm.txtKsoratFactor.Text;
                //chkEzafat.Enabled = false;
                //txtJameColFactor.Text = (Convert.ToDecimal(txtAghlamKala.Text) + Convert.ToDecimal(txtAghlamKhadamat.Text) + Convert.ToDecimal(txtchkMaliat.Text) + Convert.ToDecimal(txtEzafat.Text) - Convert.ToDecimal(txtKsorat.Text)).ToString();
            }

            if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
            {
                if (Fm._FirstSelectAnbar_NextSanad)
                    FillCmbNameAnbar2();
                else
                    FillcmbNameKala();
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                FillcmbNameKala();
            else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                FillcmbEz_Ks();
            else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                FillcmbVizitor();




            //db = new MyContext();
            if (Fm != null)
            {
                if (Fm.En2 == EnumCED.Create)
                {
                    if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
                    {
                        if (Fm._FirstSelectAnbar_NextSanad)
                            cmbNameAnbar2.EditValue = Fm._AnbarId;
                        //cmb_NameKala.ShowPopup();
                    }
                    //else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                    //{
                    //    //cmbVizitor.ShowPopup();
                    //}
                    //else
                    //cmb_NameKala.ShowPopup();

                }
                else if (Fm.En2 == EnumCED.Edit)
                {
                    //using (var db = new MyContext())
                    {
                        try
                        {
                            if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
                            {
                                if (Fm._FirstSelectAnbar_NextSanad)
                                {
                                    cmbNameAnbar2.EditValue = Fm._AnbarId;
                                    cmb_NameKala.EditValue = Fm._KalaId;

                                    cmb_NameKala.Focus();
                                }
                                else
                                {
                                    cmb_NameKala.EditValue = Fm._KalaId;
                                    cmbNameAnbar2.EditValue = Fm._AnbarId;
                                    cmb_NameKala.Focus();
                                }
                                txtVahedAsli.Text = new MyContext().EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == Fm._KalaId).EpVahedAsliKala.Name;
                            }
                            else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                            {
                                cmb_NameKala.EditValue = Fm._KalaId;
                                cmb_NameKala.Focus();

                                txtVahedAsli.Text = new MyContext().EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == Fm._KalaId).EpVahedAsliKala.Name;
                            }
                            else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                            {
                                cmbEz_Ks.EditValue = Fm._Ez_KsId;
                                cmbEz_Ks.Focus();
                            }
                            else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                            {
                                cmbVizitor.EditValue = Fm._VizitorId;
                                cmbVizitor.Focus();
                            }

                            txtMeghdar.Text = Convert.ToString(Fm._Meghdar);
                            txtNerkh.Text = Convert.ToString(Fm._Nerkh);
                            txtMablag.Text = Convert.ToString(Fm._Mablag);
                            txtMotefareghe.Text = Convert.ToString(Fm._Motefareghe);
                            txtTakhfifRadifiKala.Text = Convert.ToString(Fm.TakhfifRadifiKala);
                            txtMaliat.Text = Convert.ToString(Fm._Maliat);
                            txtAvarez.Text = Convert.ToString(Fm._Avarez);
                            txtTozihat.Text = Fm._Tozihat;
                            cmbHesabMoin_Bed.EditValue = Fm._HesabMoinId_Bed;
                            cmbHesabTafsili1_Bed.EditValue = Fm._HesabTafsili1Id_Bed;
                            cmbHesabTafsili2_Bed.EditValue = Fm._HesabTafsili2Id_Bed;
                            cmbHesabTafsili3_Bed.EditValue = Fm._HesabTafsili3Id_Bed;
                            cmbHesabMoin_Bes.EditValue = Fm._HesabMoinId_Bes;
                            cmbHesabTafsili1_Bes.EditValue = Fm._HesabTafsili1Id_Bes;
                            cmbHesabTafsili2_Bes.EditValue = Fm._HesabTafsili2Id_Bes;
                            cmbHesabTafsili3_Bes.EditValue = Fm._HesabTafsili3Id_Bes;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                if (Fm._FirstSelectAnbar_NextSanad == false && Fm._NoeFactor == 0)
                {
                    cmbNameAnbar2.Enabled = true;
                    btnReloadNameAnbar2.Enabled = true;
                }
                //cmb_NameKala.Focus();

                FillCmbHesabMoin();
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
                    if (Fm.En2 == EnumCED.Edit)
                    {
                        cmbHesabMoin_Bed.Properties.DataSource = q.Count > 0 ? q : null;
                        cmbHesabMoin_Bes.Properties.DataSource = q.Count > 0 ? q : null;
                    }
                    else
                    {
                        var p = q.Where(s => s.IsActive == true).ToList();
                        cmbHesabMoin_Bed.Properties.DataSource = p.Count > 0 ? p.ToList() : null;
                        cmbHesabMoin_Bes.Properties.DataSource = p.Count > 0 ? p.ToList() : null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillCmbHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);

                    List<EpAllHesabTafsili> list = new List<EpAllHesabTafsili>();

                    var q1 = db.R_EpHesabMoin1_B_EpAllGroupTafsilis.Where(s => s.EpHesabMoin1Id == _HesabMoinId && s.SalId == _SalId).Select(s => s.AllGroupTafsiliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _SalId && s.GroupTafsiliId == item).OrderBy(s => s.Code).ToList();
                            list.AddRange(q);
                        }
                        #region MyRegion
                        ////db.EpAllHesabTafsilis.AddRange(list);
                        //List<EpAllHesabTafsili_HesabMovaghat> list1 = new List<EpAllHesabTafsili_HesabMovaghat>();
                        //foreach (var item in list)
                        //{
                        //    EpAllHesabTafsili_HesabMovaghat obj = new EpAllHesabTafsili_HesabMovaghat();
                        //    obj.Id = item.Id;
                        //    obj.SalId = item.SalId;
                        //    obj.LevelNumber = item.LevelNumber;
                        //    obj.Code = item.Code;
                        //    obj.Name = item.Name;
                        //    obj.GroupTafsiliId = item.GroupTafsiliId;
                        //    obj.MoinId = _HesabMoinId;
                        //    obj.IsActive = item.IsActive;
                        //    obj.IsDefault = item.IsDefault;
                        //    obj.SharhHesab = item.SharhHesab;
                        //    list1.Add(obj);
                        //}
                        //db.EpAllHesabTafsili_HesabMovaghats.AddRange(list1);

                        ////BindingSource bs = new BindingSource();
                        ////bs.DataSource = list;
                        ////BindingList<EpAllHesabTafsili> ok = new BindingList<EpAllHesabTafsili>(list);
                        //db.EpAllHesabTafsili_HesabMovaghats.Load(); 
                        #endregion
                        if (Fm.En2 == EnumCED.Create)
                        {
                            cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNumber == 1).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNumber == 1).OrderBy(s => s.Code).ToList() : null;
                            cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNumber == 2).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNumber == 2).OrderBy(s => s.Code).ToList() : null;
                            cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.IsActive == true && s.LevelNumber == 3).Count() > 0 ? list.Where(s => s.IsActive == true && s.LevelNumber == 3).OrderBy(s => s.Code).ToList() : null;

                        }
                        else
                        {
                            cmbHesabTafsili1.Properties.DataSource = list.Where(s => s.LevelNumber == 1).OrderBy(s => s.Code);
                            cmbHesabTafsili2.Properties.DataSource = list.Where(s => s.LevelNumber == 2).OrderBy(s => s.Code);
                            cmbHesabTafsili3.Properties.DataSource = list.Where(s => s.LevelNumber == 3).OrderBy(s => s.Code);
                        }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillcmbEz_Ks()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.FKTarifEz_Ks_Factors.Where(s => s.SalId == _SalId && s.NoeEz_KsIndex == Fm._IndexAghlamFactor).OrderBy(s => s.Code).ToList();
                    if (Fm.En2 == EnumCED.Create)
                        fKTarifEz_Ks_FactorsBindingSource.DataSource = q.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList().Count > 0 ? q : null;
                    else if (Fm.En2 == EnumCED.Edit)
                        fKTarifEz_Ks_FactorsBindingSource.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbVizitor()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpHesabTafsiliAshkhass.Where(s => s.SalId == _SalId && s.IsVizitor == true).OrderBy(s => s.Code).ToList();
                    if (Fm.En2 == EnumCED.Create)
                        epHesabTafsiliAshkhassBindingSource.DataSource = q.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList().Count > 0 ? q : null;
                    else if (Fm.En2 == EnumCED.Edit)
                        epHesabTafsiliAshkhassBindingSource.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbNameKala()
        {
            try
            {
                dbContext = new MyContext();
                _SalId = Convert.ToInt32(lblSalId.Text);
                if (!Fm._FirstSelectAnbar_NextSanad)
                {
                    var qq1 = dbContext.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && (s.NameAmaliatCode == 2 || s.NameAmaliatCode == 3)).ToList();
                    var q = dbContext.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.NoeTabagheIndex == Fm._IndexNoeTabaghehKala).ToList();
                    foreach (var item in q)
                    {
                        item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                        item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                        item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                        item.VahedAsliName_NM = q.FirstOrDefault(s => s.EpAllCodingKala1.Id == item.Id).EpVahedAsliKala.Name;
                        if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
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
                if (Fm._FirstSelectAnbar_NextSanad)
                {
                    if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala")
                    {
                        _AnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                        //BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                        //List<AKAmaliatAnbarVKala_Riz> _List3 = new List<AKAmaliatAnbarVKala_Riz>();
                        var _List3 = dbContext.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && ((s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId) || (s.AzAnbarId == _AnbarId && s.NameAmaliatCode == 3))).ToList();
                        //var qq2 = qq1.Where(s => s.BeAnbarId == BeAnbarId && s.NameAmaliatCode == 2).ToList();
                        //var qq3 = qq1.Where(s => s.BeAnbarId == AnbarId).ToList();
                        //if (qq2.Count > 0)
                        //    _List3.AddRange(qq2);
                        //if (qq1.Count > 0)
                        //    _List3.AddRange(qq1);

                        //var q3 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId).ToList();
                        //var q6 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == AzAnbarId).ToList();
                        var q1 = dbContext.R_EpListAnbarha_B_EpTabaghehKalas.Where(s => s.SalId == _SalId && s.AnbarhId == _AnbarId).Select(s => s.TabagheKalaId).ToList();
                        List<EpNameKala> List1 = new List<EpNameKala>();
                        IEnumerable<int> List2 = null;

                        if (Fm != null)
                        {
                            List2 = q1;
                        }

                        foreach (var item in List2)
                        {
                            var q5 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.TabaghehId == item).ToList();
                            List1.AddRange(q5);
                        }
                        var q = List1.OrderBy(s => s.Code).ToList();
                        foreach (var item in q)
                        {
                            item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                            item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                            item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                            item.VahedAsliName_NM = item.EpVahedAsliKala.Name;
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
                        var q5 = dbContext.EpNameKalas.Where(s => s.SalId == _SalId && s.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.NoeTabagheIndex == Fm._IndexNoeTabaghehKala).ToList();
                        foreach (var item in q5)
                        {
                            item.TabagheKalaName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.EpTabaghehKala1.Name;
                            item.GroupAsliName_NM = item.EpGroupFareeKala1.EpGroupAsliKala1.Name;
                            item.GroupFareeName_NM = item.EpGroupFareeKala1.Name;
                            item.VahedAsliName_NM = item.EpVahedAsliKala.Name;
                            //item.MeghdarMa_NM = _List3.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 2).Sum(s => s.Meghdar) - _List3.Where(s => s.KalaId == item.Id && s.NameAmaliatCode == 3).Sum(s => s.Meghdar);
                        }


                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Edit)
                                epNameKalasBindingSource.DataSource = q5.Count > 0 ? q5.OrderBy(s => s.Code).ToList() : null;
                            else
                                epNameKalasBindingSource.DataSource = q5.Where(s => s.IsActive == true).ToList().Count > 0 ? q5.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList() : null;
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
        private void btnReload_NameKala_Click(object sender, EventArgs e)
        {
            FillcmbNameKala();
        }

        private void FrmSelectKala_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dbContext != null)
                dbContext.Dispose();
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
                if (!string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) != 0)
                {
                    txtMablag.EnterMoveNextControl = true;
                    decimal _Meghdar = 0;
                    if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat" || Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                    {
                        panelControl_JameColFactor.Visible = txtNerkh.Visible = btnMabnaMohasebeDarsad.Visible = true;
                        btnMabnaMohasebeDarsad_Click(null, null);
                    }
                    if (Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) != 0)
                    {
                        _Meghdar = IsValidationMeghdar ? Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) : _BefourMeghdar;
                        decimal _Nerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                        decimal _Mablag = 0;
                        //decimal stringLength = _Mablag.ToString().Length;

                        if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        {
                            _Mablag = Convert.ToDecimal(_Meghdar * _Nerkh);

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
                                // txtMeghdar.Text = _Meghdar.ToString();
                                if (VrodMablagh == false)
                                    txtMablag.Text = _Mablag.ToString();
                                _BefourMeghdar = _Meghdar;
                                _BefourMablag = _Mablag;
                                IsValidationMeghdar = true;
                            }

                        }
                        else
                        {
                            _Mablag = Convert.ToDecimal(_Nerkh * (_Meghdar / 100));
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
                                //panelControl_JameColFactor.Visible = btnMabnaMohasebeDarsad.Visible = true;
                                //txtNerkh.Text = _BefourNerkh.ToString();
                                //if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat" && _Mablag > _Nerkh)
                                //{
                                //    XtraMessageBox.Show("مبلغ تخفیف نباید بیشتر از جمع کل فاکتور باشد" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    IsValidationMeghdar = false;
                                //    //_Meghdar = _BefourMeghdar;
                                //    txtMeghdar.Text = _BefourMeghdar.ToString();
                                //    txtMablag.Text = _BefourMablag.ToString();
                                //    txtMablag.Focus();
                                //    txtMeghdar.Focus();
                                //    return;
                                //}
                                //else
                                {
                                    if (VrodMablagh == false)
                                        txtMablag.Text = _Mablag.ToString();
                                    _BefourMeghdar = _Meghdar;
                                    _BefourNerkh = _Nerkh;
                                    _BefourMablag = _Mablag;
                                    IsValidationMeghdar = true;

                                }
                            }
                        }
                    }
                    string _txtTedadeDarVahed1 = !string.IsNullOrEmpty(txtTedadeDarVahed1.Text) ? txtTedadeDarVahed1.Text : "0";
                    string _txtTedadeDarVahed2 = !string.IsNullOrEmpty(txtTedadeDarVahed2.Text) ? txtTedadeDarVahed2.Text : "0";
                    string _txtTedadeDarVahed3 = !string.IsNullOrEmpty(txtTedadeDarVahed3.Text) ? txtTedadeDarVahed3.Text : "0";

                    if (txtVahedAsli.Text == txtVahed1.Text)
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
                    else if (txtVahedAsli.Text == txtVahed2.Text)
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
                    else if (txtVahedAsli.Text == txtVahed3.Text)
                    {
                        txtMeghdar3.Text = _Meghdar.ToString();
                        txtMeghdar2.Text = "0";
                        txtMeghdar1.Text = "0";
                    }

                }
                else
                {
                    if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat" || Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                    {
                        if (VrodMablagh == false)
                        {
                            panelControl_JameColFactor.Visible = txtNerkh.Visible = btnMabnaMohasebeDarsad.Visible = false;
                            _BefourNerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                            txtNerkh.Text = "0";

                        }
                    }
                    if (VrodMablagh == false)
                        txtMablag.Text = "0";
                    txtMeghdar3.Text = "0";
                    txtMeghdar2.Text = "0";
                    txtMeghdar1.Text = "0";

                }

                //MohasebeFieldTextBoxData();
            }
        }
        decimal _BefourMablag = 0;
        decimal _BefourNerkh = 0;
        bool IsValidationNerkh = true;
        bool IsValidationMablag = true;
        bool VrodMablagh = false;
        bool VrodDarsadTakhfif = false;
        bool VrodMablaghTakhfif = false;
        private void txtNerkh_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNerkh.IsHandleCreated)
            {
                if (!string.IsNullOrEmpty(txtNerkh.Text.Trim()) && Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) != 0)
                {
                    if (Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) != 0)
                    {
                        decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
                        decimal _Nerkh = IsValidationNerkh ? Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", ".")) : _BefourNerkh;
                        decimal _Mablag = 0;
                        //decimal stringLength = _Mablag.ToString().Length;

                        if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        {
                            _Mablag = Convert.ToDecimal(_Meghdar * _Nerkh);

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
                                if (VrodMablagh == false)
                                    txtMablag.Text = _Mablag.ToString();
                                _BefourNerkh = _Nerkh;
                                _BefourMablag = _Mablag;
                                IsValidationNerkh = true;
                            }
                        }
                        else
                        {
                            if (_Nerkh == 0)
                                txtMeghdar.Enabled = txtNerkh.Enabled = txtMablag.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = false;
                            else
                                txtMeghdar.Enabled = txtNerkh.Enabled = txtMablag.Enabled = btnSaveAndClosed.Enabled = btnSaveAndNext.Enabled = true;


                            if (IsValidationNerkh)
                                _Mablag = Convert.ToDecimal(_Nerkh * (_Meghdar / 100));
                            else
                                _Mablag = Convert.ToDecimal(_Nerkh * (_BefourMeghdar / 100));

                            if (_Mablag >= 1000000000000000000)
                            {
                                XtraMessageBox.Show("مبلغ وارده خیلی بزرگ خواهد بود" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                IsValidationNerkh = false;
                                txtMeghdar.Text = _BefourMeghdar.ToString();
                                txtMablag.Text = _BefourMablag.ToString();
                                txtMablag.Focus();
                                txtMeghdar.Focus();
                                return;

                            }
                            else
                            {
                                //if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat" && _Mablag > _Nerkh)
                                //{
                                //    XtraMessageBox.Show("مبلغ تخفیف نباید بیشتر از جمع کل فاکتور باشد" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    IsValidationMeghdar = false;
                                //    _Meghdar = _BefourMeghdar;
                                //    txtMeghdar.Text = _BefourMeghdar.ToString();
                                //    txtMablag.Text = _BefourMablag.ToString();
                                //    txtMablag.Focus();
                                //    txtMeghdar.Focus();
                                //    return;
                                //}
                                //else
                                {
                                    if (VrodMablagh == false)
                                        txtMablag.Text = _Mablag.ToString();
                                    _BefourMeghdar = _Meghdar;
                                    _BefourNerkh = _Nerkh;
                                    _BefourMablag = _Mablag;
                                    IsValidationNerkh = true;

                                }
                            }
                        }
                    }
                    else
                    {
                        if (VrodMablagh == false)
                            txtMablag.Text = "0";
                    }
                }
                else
                {
                    if (VrodMablagh == false)
                        txtMablag.Text = "0";
                }

                //MohasebeFieldTextBoxData();

            }
        }
        private void cmbControl_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_Khadamat")
                    {
                        if (Fm._FirstSelectAnbar_NextSanad)
                        {
                            int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                            txtVahed3.Text = q != null && q.EpVahedKala3 != null ? q.EpVahedKala3.Name : string.Empty;
                            txtVahed2.Text = q != null && q.EpVahedKala2 != null ? q.EpVahedKala2.Name : string.Empty;
                            txtVahed1.Text = q != null && q.EpVahedKala1 != null ? q.EpVahedKala1.Name : string.Empty;
                            txtVahedAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
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

                                if (txtVahedAsli.Text == txtVahed1.Text)
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
                                else if (txtVahedAsli.Text == txtVahed2.Text)
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
                                else if (txtVahedAsli.Text == txtVahed3.Text)
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
                                txtVahedAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
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

                                    if (txtVahedAsli.Text == txtVahed1.Text)
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
                                    else if (txtVahedAsli.Text == txtVahed2.Text)
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
                                    else if (txtVahedAsli.Text == txtVahed3.Text)
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

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (Fm.En2 == EnumCED.Create)
                    {
                        var p = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.IndexAghlamFactor == Fm._IndexAghlamFactor).ToList();
                        if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" && Fm._FirstSelectAnbar_NextSanad)
                        {
                            _AnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                            var q0 = p.Where(s => s.AnbarId == _AnbarId).ToList();
                            if (Fm._NameAmaliatCode == 1)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 101);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 102);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q02.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 201);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 202);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q02.HesabTafsili3Id;
                                }
                            }
                            else if (Fm._NameAmaliatCode == 2)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 301);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 302);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 303);
                                    cmbHesabMoin_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 401);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 402);
                                    cmbHesabMoin_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;

                                    var q01 = q0.FirstOrDefault(s => s.Code == 403);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                }
                            }
                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        {
                            _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            var q0 = p.Where(s => s.AnbarId == null && s.KhadamatId == _KalaId).ToList();
                            if (Fm._NameAmaliatCode == 1)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 101);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 102);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q02.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 201);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 202);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q02.HesabTafsili3Id;
                                }
                            }
                            else if (Fm._NameAmaliatCode == 2)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 301);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 302);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 303);
                                    cmbHesabMoin_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 401);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 402);
                                    cmbHesabMoin_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;

                                    var q01 = q0.FirstOrDefault(s => s.Code == 403);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                }
                            }
                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat")
                        {
                            _Ez_KsId = Convert.ToInt32(cmbEz_Ks.EditValue);
                            var q0 = p.Where(s => s.AnbarId == null && s.KhadamatId == null && s.Ez_KsId == _Ez_KsId).ToList();
                            if (Fm._NameAmaliatCode == 1)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 101);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 102);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q02.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 201);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 202);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q02.HesabTafsili3Id;
                                }
                            }
                            else if (Fm._NameAmaliatCode == 2)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 301);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 302);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 303);
                                    cmbHesabMoin_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 401);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 402);
                                    cmbHesabMoin_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;

                                    var q01 = q0.FirstOrDefault(s => s.Code == 403);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                }
                            }
                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                        {
                            _Ez_KsId = Convert.ToInt32(cmbEz_Ks.EditValue);
                            var q0 = p.Where(s => s.AnbarId == null && s.KhadamatId == null && s.Ez_KsId == _Ez_KsId).ToList();
                            if (Fm._NameAmaliatCode == 1)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 101);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q02.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q02.HesabTafsili3Id;
                                    var q01 = q0.FirstOrDefault(s => s.Code == 102);
                                    cmbHesabMoin_Bes.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q01.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 201);
                                    cmbHesabMoin_Bed.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q02.HesabTafsili3Id;
                                    var q01 = q0.FirstOrDefault(s => s.Code == 202);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                }
                            }
                            else if (Fm._NameAmaliatCode == 2)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 301);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 302);
                                    cmbHesabMoin_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;
                                    var q01 = q0.FirstOrDefault(s => s.Code == 303);
                                    cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 401);
                                    cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 402);
                                    var q03 = q0.FirstOrDefault(s => s.Code == 403);
                                    cmbHesabMoin_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;

                                }
                            }
                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                        {
                            _VizitorId = Convert.ToInt32(cmbVizitor.EditValue);
                            var q5 = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.SalId == _SalId && s.Id == _VizitorId && s.IsVizitor == true).LevelNumber;
                            var q0 = p.Where(s => s.AnbarId == null && s.KhadamatId == null && s.Ez_KsId == null && s.VizitorId == _VizitorId).ToList();
                            if (Fm._NameAmaliatCode == 1)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 101);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 102);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q5 == 1 ? _VizitorId : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q5 == 2 ? _VizitorId : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q5 == 3 ? _VizitorId : q02.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 201);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q5 == 1 ? _VizitorId : q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q5 == 2 ? _VizitorId : q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q5 == 3 ? _VizitorId : q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 202);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q02.HesabTafsili3Id;
                                }
                            }
                            else if (Fm._NameAmaliatCode == 2)
                            {
                                if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                {
                                    var q01 = q0.FirstOrDefault(s => s.Code == 301);
                                    cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                    var q02 = q0.FirstOrDefault(s => s.Code == 302);
                                    cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q5 == 1 ? _VizitorId : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q5 == 2 ? _VizitorId : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q5 == 3 ? _VizitorId : q02.HesabTafsili3Id;
                                }
                                else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                {
                                    var q02 = q0.FirstOrDefault(s => s.Code == 401);
                                    cmbHesabMoin_Bed.EditValue = q02.HesabMoinId;
                                    cmbHesabTafsili1_Bed.EditValue = q5 == 1 ? _VizitorId : q02.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bed.EditValue = q5 == 2 ? _VizitorId : q02.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bed.EditValue = q5 == 3 ? _VizitorId : q02.HesabTafsili3Id;

                                    var q01 = q0.FirstOrDefault(s => s.Code == 402);
                                    cmbHesabMoin_Bes.EditValue = q01.HesabMoinId;
                                    cmbHesabTafsili1_Bes.EditValue = q01.HesabTafsili1Id;
                                    cmbHesabTafsili2_Bes.EditValue = q01.HesabTafsili2Id;
                                    cmbHesabTafsili3_Bes.EditValue = q01.HesabTafsili3Id;
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

        public bool IsValidation()
        {
            // string s = txtMeghdar.Text.Trim();
            if (Convert.ToInt32(cmb_NameKala.EditValue) == 0 && (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat"))
            {
                XtraMessageBox.Show("لطفاً نام کالا را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_NameKala.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbEz_Ks.EditValue) == 0 && (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat"))
            {
                XtraMessageBox.Show("لطفاً " + lblNameKala.Text + "  را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEz_Ks.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbVizitor.EditValue) == 0 && Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
            {
                XtraMessageBox.Show("لطفاً نام ویزیتور یا واسط را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVizitor.Focus();
                return false;
            }
            else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" && Convert.ToInt32(cmbNameAnbar2.EditValue) == 0)
            {
                XtraMessageBox.Show("لطفاً نام انبار را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNameAnbar2.Focus();
                return false;
            }
            else if ((string.IsNullOrEmpty(txtMeghdar.Text) || Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) == 0) && (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat"))
            {
                XtraMessageBox.Show("لطفاً مقدار را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMeghdar.Focus();
                return false;
            }
            else if ((string.IsNullOrEmpty(txtNerkh.Text) || Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) == 0) && (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat"))
            {
                XtraMessageBox.Show("لطفاً نرخ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNerkh.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtMablag.Text) || txtMablag.Text.Trim() == "0")
            {
                XtraMessageBox.Show("لطفاً مبلغ را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMablag.Focus();
                return false;
            }
            return true;
        }

        bool IsClosed = true;
        private void btnSaveAndClosed_Click(object sender, EventArgs e)
        {
            //dbContext = new MyContext();
            using (var db = new MyContext())
            {
                try
                {
                    if (IsValidation())
                    {
                        if (sender == btnSaveAndClosed)
                            IsClosed = true;
                        if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        {
                            _VizitorId = null;
                            _Ez_KsId = null;

                            _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                            _KalaName = cmb_NameKala.Text;

                            var q = db.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                            if (q != null)
                            {
                                //_VahedeKalaId = q.VahedAsliId;
                                _VahedeKalaName = q.EpVahedAsliKala.Name;
                                _KalaCode = q.Code.ToString();

                            }

                            if (Convert.ToInt32(cmbNameAnbar2.EditValue) != 0)
                            {
                                _AnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                                _AnbarName = cmbNameAnbar2.Text;

                            }
                            else
                            {
                                _AnbarId = null;
                                _AnbarName = null;
                            }
                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                        {
                            _Ez_KsId = Convert.ToInt32(cmbEz_Ks.EditValue);
                            _KalaName = cmbEz_Ks.Text;

                            var q = db.FKTarifEz_Ks_Factors.FirstOrDefault(s => s.SalId == _SalId && s.Id == _Ez_KsId);
                            if (q != null)
                                _KalaCode = q.Code.ToString();

                            _VizitorId = null;
                            _KalaId = null;
                            _AnbarId = null;
                            _VahedeKalaName = null;
                            _AnbarName = null;

                        }
                        else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                        {
                            _VizitorId = Convert.ToInt32(cmbVizitor.EditValue);
                            _KalaName = cmbVizitor.Text;

                            var q = db.EpHesabTafsiliAshkhass.FirstOrDefault(s => s.SalId == _SalId && s.IsVizitor == true && s.Id == _VizitorId);
                            if (q != null)
                                _KalaCode = q.Code.ToString();

                            _Ez_KsId = null;
                            _KalaId = null;
                            _AnbarId = null;
                            _VahedeKalaName = null;
                            _AnbarName = null;



                        }

                        //BeAnbarName = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == BeAnbarId).Name;
                        if (Fm != null)
                        {
                            if (Fm.En2 == EnumCED.Create)
                            {
                                Fm._VizitorId = _VizitorId;
                                Fm._Ez_KsId = _Ez_KsId;

                                Fm._KalaId = _KalaId;
                                Fm._KalaName_NM = _KalaName;

                                Fm._AnbarId = _AnbarId;
                                Fm._AnbarName_NM = _AnbarName;

                                //Fm._VahedeKalaId = _VahedeKalaId;
                                Fm._VahedeKala_NM = _VahedeKalaName;

                                Fm._KalaCode_NM = _KalaCode;


                                Fm._Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
                                Fm._Nerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                Fm._Mablag = Convert.ToDecimal(txtMablag.Text.Trim().Replace(",", ""));
                                Fm._Motefareghe = Convert.ToDecimal(txtMotefareghe.Text.Trim().Replace(",", ""));
                                Fm.TakhfifRadifiKala = Convert.ToDecimal(txtTakhfifRadifiKala.Text.Trim().Replace(",", ""));
                                Fm._Maliat = Convert.ToDecimal(txtMaliat.Text.Trim().Replace(",", ""));
                                Fm._Avarez = Convert.ToDecimal(txtAvarez.Text.Trim().Replace(",", ""));
                                if (!string.IsNullOrEmpty(txtTozihat.Text.Trim())) Fm._Tozihat = txtTozihat.Text.Trim(); else Fm._Tozihat = null;

                                Fm._HesabMoinId_Bed = Convert.ToInt32(cmbHesabMoin_Bed.EditValue);
                                Fm._HesabTafsili1Id_Bed = Convert.ToInt32(cmbHesabTafsili1_Bed.EditValue);
                                Fm._HesabTafsili2Id_Bed = Convert.ToInt32(cmbHesabTafsili2_Bed.EditValue);
                                Fm._HesabTafsili3Id_Bed = Convert.ToInt32(cmbHesabTafsili3_Bed.EditValue);
                                Fm._HesabMoinId_Bes = Convert.ToInt32(cmbHesabMoin_Bes.EditValue);
                                Fm._HesabTafsili1Id_Bes = Convert.ToInt32(cmbHesabTafsili1_Bes.EditValue);
                                Fm._HesabTafsili2Id_Bes = Convert.ToInt32(cmbHesabTafsili2_Bes.EditValue);
                                Fm._HesabTafsili3Id_Bes = Convert.ToInt32(cmbHesabTafsili3_Bes.EditValue);
                                //Fm.gridView_AmaliatAddVaEdit1_InitNewRow(null,null);
                                Fm.gridView1.AddNewRow();
                                Fm.gridView1.FocusInvalidRow();
                                //Fm.gridView_InitNewRow(null, null);
                            }
                            else if (Fm.En2 == EnumCED.Edit)
                            {
                                //int _KalaId = Convert.ToInt32(cmb_NameKala.EditValue);
                                // var q = dbContext.EpNameKalas.FirstOrDefault(s => s.SalId == _SalId && s.Id == _KalaId);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "VizitorId", _VizitorId);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Ez_KsId", _Ez_KsId);

                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "AnbarId", _AnbarId);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "AnbarName_NM", _AnbarName);

                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaId", _KalaId);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaName_NM", _KalaName);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "KalaCode_NM", _KalaCode);

                                //Fm.gridView1.SetRowCellValue(Fm._RowHandle, "VahedeKalaId", _VahedeKalaId);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "VahedeKala_NM", _VahedeKalaName);

                                //Fm.gridView1.SetRowCellValue(Fm._RowHandle, "BeAnbarName_NM", BeAnbarName);
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Meghdar", txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Nerkh", txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Mablag", txtMablag.Text.Trim().Replace(",", ""));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Motefareghe", txtMotefareghe.Text.Trim().Replace(",", ""));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "TakhfifRadifiKala", txtTakhfifRadifiKala.Text.Trim().Replace(",", ""));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Maliat", txtMaliat.Text.Trim().Replace(",", ""));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Avarez", txtAvarez.Text.Trim().Replace(",", ""));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "Tozihat", txtTozihat.Text.Trim());

                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabMoinId_Bed", Convert.ToInt32(cmbHesabMoin_Bed.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili1Id_Bed", Convert.ToInt32(cmbHesabTafsili1_Bed.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili2Id_Bed", Convert.ToInt32(cmbHesabTafsili2_Bed.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili3Id_Bed", Convert.ToInt32(cmbHesabTafsili3_Bed.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabMoinId_Bes", Convert.ToInt32(cmbHesabMoin_Bes.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili1Id_Bes", Convert.ToInt32(cmbHesabTafsili1_Bes.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili2Id_Bes", Convert.ToInt32(cmbHesabTafsili2_Bes.EditValue));
                                Fm.gridView1.SetRowCellValue(Fm._RowHandle, "HesabTafsili3Id_Bes", Convert.ToInt32(cmbHesabTafsili3_Bes.EditValue));
                            }

                            Fm.gridView1.UpdateSummary();
                            Fm.FillVaziyatHesab();
                            if (IsClosed)
                            {
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
                //cmbNameAnbar2.EditValue = 0;
                //cmb_NameKala.EditValue = 0;
                txtMeghdar.Text = "0";
                if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                {
                    txtNerkh.Text = "0";
                    txtMotefareghe.Text = "0";
                    txtTakhfifRadifiKala.Text = "0";
                    txtMaliat.Text = "0";
                    txtAvarez.Text = "0";
                }
                else
                {
                    // txtMeghdar.Text = "0";
                    txtMablag.Text = "0";
                    chkAghlamKala.Checked = true;
                    chkAghlamKhadamat.Checked = true;
                    if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat")
                        chkEzafat.Checked = false;
                    else if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                        chkKsorat.Checked = false;
                    else if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                    {
                        chkEzafat.Checked = true;
                        chkKsorat.Checked = true;
                    }

                    //txtAghlamKala.Text = Fm.txtJameAghlamKala.Text;
                    //txtAghlamKhadamat.Text = Fm.txtJameAghlamKhadamat.Text;
                    //txtchkMaliat.Text = chkMaliat.Checked ? (Convert.ToDecimal(Fm.txtJameMaliat.Text) + Convert.ToDecimal(Fm.txtJameAvarez.Text)).ToString() : "0";
                    //txtEzafat.Text = Fm.txtEzafatFactor.Text;
                    //txtKsorat.Text = Fm.txtKsoratFactor.Text;
                    //chkMaliat.Checked = chkEzafat.Checked = chkKsorat.Checked = false;
                    //if(Fm.objXtraTabPage_1.Name == "xtp_Ezafat")
                    //txtKsorat.Text = Fm.txtKsoratFactor.Text;
                    //txtJameColFactor.Text = (Convert.ToDecimal(txtAghlamKala.Text) + Convert.ToDecimal(txtAghlamKhadamat.Text) + Convert.ToDecimal(txtEzafat.Text) - Convert.ToDecimal(txtKsorat.Text)).ToString();

                }

                txtMeghdar1.Text = "0";
                txtMeghdar2.Text = "0";
                txtMeghdar3.Text = "0";
                txtTozihat.Text = string.Empty;

                if (Fm != null)
                {
                    Fm.En2 = EnumCED.Create;
                    if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                        cmbVizitor.Focus();
                    else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                        cmbEz_Ks.Focus();
                    else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        cmb_NameKala.Focus();

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
            if (txtMablag.IsEditorActive && VrodMablagh)
            {
                if (txtMablag.Text.Trim() != "0")
                {
                    decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
                    decimal _Mablag = IsValidationMablag ? Convert.ToDecimal(txtMablag.Text.Trim().Replace(",", "").Replace("/", ".")) : _BefourMablag;
                    decimal _Nerkh = 0;
                    //decimal stringLength = _Mablag.ToString().Length;

                    if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                    {
                        if (!string.IsNullOrEmpty(txtMeghdar.Text.Trim()) && Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) != 0)
                        {
                            _Nerkh = _Meghdar != 0 ? Convert.ToDecimal(_Mablag / _Meghdar) : 0;
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
                    }
                    else
                    {
                        if (_Mablag >= 1000000000000000000)
                        {
                            XtraMessageBox.Show("مبلغ وارده خیلی بزرگ خواهد بود" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IsValidationMablag = false;
                            IsValidationMeghdar = false;
                            txtMeghdar.Text = _BefourMeghdar.ToString();
                            txtMablag.Text = _BefourMablag.ToString();
                            txtMeghdar.Focus();
                            txtMablag.Focus();
                            return;

                        }
                        else
                        {

                            //if (Fm.objXtraTabPage_1.Name == "xtp_Ksorat" && _Mablag > _Nerkh)
                            //{
                            //    XtraMessageBox.Show("مبلغ تخفیف نباید بیشتر از جمع کل فاکتور باشد" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    IsValidationMablag = false;
                            //    IsValidationMeghdar = false;
                            //    txtMeghdar.Text = _BefourMeghdar.ToString();
                            //    txtMablag.Text = _BefourMablag.ToString();
                            //    txtMeghdar.Focus();
                            //    txtMablag.Focus();
                            //    return;
                            //}
                            //else
                            {
                                _Nerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
                                if (_Nerkh != 0)
                                    txtMeghdar.Text = (_Mablag / _Nerkh * 100).ToString();
                                _BefourMeghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
                                _BefourNerkh = _Nerkh;
                                _BefourMablag = _Mablag;
                                IsValidationMablag = true;
                            }
                        }
                    }
                }
                else
                {
                    if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                        txtNerkh.Text = "0";
                    else
                    {
                        txtMeghdar.Text = "0";

                    }
                }

            }

            //if (!string.IsNullOrEmpty(txtDarsadTakhfifRadifiKala.Text))
               // if (Convert.ToSingle(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) != 0)
                    txtTakhfifRadifiKala.Text = ((Convert.ToDecimal(txtMablag.Text.Replace(",", "").Replace("/", ".")) * Convert.ToDecimal(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", "."))) / 100).ToString();
            // else
            //    txtTakhfifRadifiKala.Text = "0";
            if (Convert.ToSingle(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) != 0)
                MablaghTakhfifChenged = true;


            MohasebeFieldTextBoxData();

        }

        private void txtMeghdar_Leave(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtMeghdar.Text.Trim()) || Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", ".")) == 0) &&
               Fm.objXtraTabPage_1.Name != "xtp_Ezafat" && Fm.objXtraTabPage_1.Name != "xtp_Ksorat" && Fm.objXtraTabPage_1.Name != "xtp_Vizitor")
            {
                txtMablag.EnterMoveNextControl = false;
                txtMeghdar.Focus();
                return;
            }

        }

        byte Count = 0;
        private void FrmSelectKala_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Escape)
            {
                if (Count == 0)
                {
                    btnSaveAndClosed.Focus();
                    Count = 1;
                }
                else if (Count == 1)
                {
                    btnClose.Focus();
                    Count = 2;
                }
                else if (Count == 2)
                {
                    this.Close();
                    Count = 0;
                }
            }

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
                fm.cmbAnbarName.EditValue = _AnbarId;
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
            fm._EditValueId = _AnbarId;
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

                _AnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                //BeAnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);

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
                            txtVahedAsli.Text = q != null ? q.EpVahedAsliKala.Name : string.Empty;
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

                                if (txtVahedAsli.Text == txtVahed1.Text)
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
                                else if (txtVahedAsli.Text == txtVahed2.Text)
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
                                else if (txtVahedAsli.Text == txtVahed3.Text)
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

                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            if (Fm.En2 == EnumCED.Create)
                            {
                                var p = db.FKTanzimatFactors.Where(s => s.SalId == _SalId && s.IndexAghlamFactor == Fm._IndexAghlamFactor).ToList();
                                if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" && !Fm._FirstSelectAnbar_NextSanad)
                                {
                                    _AnbarId = Convert.ToInt32(cmbNameAnbar2.EditValue);
                                    var q0 = p.Where(s => s.AnbarId == _AnbarId).ToList();
                                    if (Fm._NameAmaliatCode == 1)
                                    {
                                        if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 101) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 103))
                                        {
                                            var q01 = q0.FirstOrDefault(s => s.Code == 101);
                                            cmbHesabMoin_Bed.EditValue = q01.HesabMoinId;
                                            cmbHesabTafsili1_Bed.EditValue = q01.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bed.EditValue = q01.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bed.EditValue = q01.HesabTafsili3Id;
                                            var q02 = q0.FirstOrDefault(s => s.Code == 102);
                                            cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q02.HesabMoinId;
                                            cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q02.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q02.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q02.HesabTafsili3Id;
                                        }
                                        else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 102)
                                        {
                                            var q01 = q0.FirstOrDefault(s => s.Code == 201);
                                            cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                            cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                            var q02 = q0.FirstOrDefault(s => s.Code == 202);
                                            cmbHesabMoin_Bes.EditValue = q02.HesabMoinId;
                                            cmbHesabTafsili1_Bes.EditValue = q02.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bes.EditValue = q02.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bes.EditValue = q02.HesabTafsili3Id;
                                        }
                                    }
                                    else if (Fm._NameAmaliatCode == 2)
                                    {
                                        if ((Fm._NameSanadIndex == 0 && Fm._NameSanadCode == 201) || (Fm._NameSanadIndex == 2 && Fm._NameSanadCode == 203))
                                        {
                                            var q01 = q0.FirstOrDefault(s => s.Code == 301);
                                            cmbHesabMoin_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                            cmbHesabTafsili1_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bed.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
                                            var q02 = q0.FirstOrDefault(s => s.Code == 302);
                                            var q03 = q0.FirstOrDefault(s => s.Code == 303);
                                            cmbHesabMoin_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                            cmbHesabTafsili1_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bes.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;
                                        }
                                        else if (Fm._NameSanadIndex == 1 && Fm._NameSanadCode == 202)
                                        {
                                            var q02 = q0.FirstOrDefault(s => s.Code == 401);
                                            var q03 = q0.FirstOrDefault(s => s.Code == 402);
                                            cmbHesabMoin_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabMoinId : q03.HesabMoinId;
                                            cmbHesabTafsili1_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili1Id : q03.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili2Id : q03.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bed.EditValue = Fm.cmbNoeSanad.SelectedIndex == 0 ? q02.HesabTafsili3Id : q03.HesabTafsili3Id;

                                            var q01 = q0.FirstOrDefault(s => s.Code == 403);
                                            cmbHesabMoin_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabMoin.EditValue) != 0 ? Fm.cmbHesabMoin.EditValue : q01.HesabMoinId;
                                            cmbHesabTafsili1_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili1.EditValue) != 0 ? Fm.cmbHesabTafsili1.EditValue : q01.HesabTafsili1Id;
                                            cmbHesabTafsili2_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili2.EditValue) != 0 ? Fm.cmbHesabTafsili2.EditValue : q01.HesabTafsili2Id;
                                            cmbHesabTafsili3_Bes.EditValue = Convert.ToInt32(Fm.cmbHesabTafsili3.EditValue) != 0 ? Fm.cmbHesabTafsili3.EditValue : q01.HesabTafsili3Id;
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
        }

        private void cmbNameAnbar2_Enter(object sender, EventArgs e)
        {
            if (Fm.En2 == EnumCED.Create)
                cmbNameAnbar2.ShowPopup();

        }

        private void txtMablag_Enter(object sender, EventArgs e)
        {
            VrodMablagh = true;
        }

        private void txtMablag_Leave(object sender, EventArgs e)
        {
            VrodMablagh = false;

        }

        private void txtMablag_Click(object sender, EventArgs e)
        {
            VrodMablagh = true;

        }

        private void chkControl_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit _CheckEdit = (CheckEdit)sender;
            if (_CheckEdit.Name == "chkAghlamKala")
            {
                txtAghlamKala.Text = chkAghlamKala.Checked ? Fm.txtMabKhalesKala.Text : "0";
            }
            else if (_CheckEdit.Name == "chkAghlamKhadamat")
            {
                txtAghlamKhadamat.Text = chkAghlamKhadamat.Checked ? Fm.txtMabKhalesKhadamat.Text : "0";
            }
            else if (_CheckEdit.Name == "chkMaliat")
            {
                txtchkMaliat.Text = chkMaliat.Checked ? (Convert.ToDecimal(Fm.txtMabMaliat.Text) + Convert.ToDecimal(Fm.txtMabAvarez.Text)).ToString() : "0";
            }
            else if (_CheckEdit.Name == "chkEzafat")
            {
                if (chkEzafat.Checked)
                {
                    if (Fm.En2 == EnumCED.Edit)
                        txtEzafat.Text = (Convert.ToDecimal(Fm.txtMabEzafat.Text) - Convert.ToDecimal(Fm.gridView_Ezafat.GetFocusedRowCellValue("Mablag"))).ToString();
                    else
                        txtEzafat.Text = Fm.txtMabEzafat.Text;

                }
                else
                    txtEzafat.Text = "0";
            }
            else if (_CheckEdit.Name == "chkKsorat")
            {
                if (chkKsorat.Checked)
                {
                    if (Fm.En2 == EnumCED.Edit)
                        txtKsorat.Text = (Convert.ToDecimal(Fm.txtMabKsorat.Text) - Convert.ToDecimal(Fm.gridView_Ksorat.GetFocusedRowCellValue("Mablag"))).ToString();
                    else
                        txtKsorat.Text = Fm.txtMabKsorat.Text;

                }
                else
                    txtKsorat.Text = "0";
            }

            txtJameColFactor.Text = (Convert.ToDecimal(txtAghlamKala.Text) + Convert.ToDecimal(txtAghlamKhadamat.Text) + Convert.ToDecimal(txtchkMaliat.Text) + Convert.ToDecimal(txtEzafat.Text) - Convert.ToDecimal(txtKsorat.Text)).ToString();

        }

        private void btnMabnaMohasebeDarsad_Click(object sender, EventArgs e)
        {
            txtNerkh.Text = txtJameColFactor.Text.Replace("-", "");
            _BefourNerkh = Convert.ToDecimal(txtNerkh.Text.Trim().Replace(",", "").Replace("/", "."));
            //decimal _Meghdar = Convert.ToDecimal(txtMeghdar.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
            //decimal _JameColFactor = Convert.ToDecimal(txtJameColFactor.Text.Trim().Replace(",", "").Replace("%", "").Replace("/", "."));
            //if (_Meghdar != 0)
            //{
            //    txtMablag.Text = (_JameColFactor * (_Meghdar / 100)).ToString();
            //}

        }

        public void MohasebeFieldTextBoxData()
        {
            if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
            {
                //if (VrodMablagh == false)
                //    txtMablag.Text = (Convert.ToDecimal(txtMeghdar.Text.Replace(",", "").Replace("/", ".")) * Convert.ToDecimal(txtNerkh.Text.Replace(",", "").Replace("/", "."))).ToString("n0");
                txtMabKhales.Text = (Convert.ToDecimal(txtMablag.Text.Replace(",", "").Replace("/", ".")) + Convert.ToDecimal(txtMotefareghe.Text.Replace(",", "").Replace("/", ".")) - Convert.ToDecimal(txtTakhfifRadifiKala.Text.Replace(",", "").Replace("/", "."))).ToString("n0");
                txtMabBadeMaliat.Text = (Convert.ToDecimal(txtMabKhales.Text.Replace(",", "").Replace("/", ".")) + Convert.ToDecimal(txtMaliat.Text.Replace(",", "").Replace("/", ".")) + Convert.ToDecimal(txtAvarez.Text.Replace(",", "").Replace("/", "."))).ToString("n0");

            }
        }

        private void txtMotefareghe_EditValueChanged(object sender, EventArgs e)
        {
            MohasebeFieldTextBoxData();

        }

        string _BeforeEditTakhfifRadifiKala = string.Empty;
        bool IsValidMablaghTakhfif = true;
        private void txtTakhfifRadifiKala_EditValueChanged(object sender, EventArgs e)
        {
             if ((txtTakhfifRadifiKala.IsEditorActive && VrodMablaghTakhfif) || (Fm.En2==EnumCED.Edit && MablaghTakhfifChenged==false))
                if (Convert.ToSingle(txtMablag.Text.Replace(",", "").Replace("/", ".")) != 0)
                {
                    if (IsValidMablaghTakhfif && (Convert.ToDecimal(txtTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) > Convert.ToDecimal(txtMablag.Text.Replace(",", "").Replace("/", "."))))
                    {
                        XtraMessageBox.Show("مبلغ تخفیف نباید بیشتر از مبلغ ناخالص باشد" + "\n", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsValidMablaghTakhfif = false;
                        return;
                    }
                    else
                    {
                        txtDarsadTakhfifRadifiKala.Text = ((Convert.ToDecimal(txtTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) / Convert.ToDecimal(txtMablag.Text.Replace(",", "").Replace("/", "."))) * 100).ToString();
                        _BeforeEditTakhfifRadifiKala = txtTakhfifRadifiKala.Text;
                        IsValidMablaghTakhfif = true;

                    }
                }
            MohasebeFieldTextBoxData();

        }

        private void txtMaliat_EditValueChanged(object sender, EventArgs e)
        {
            MohasebeFieldTextBoxData();

        }

        private void txtAvarez_EditValueChanged(object sender, EventArgs e)
        {
            MohasebeFieldTextBoxData();

        }

        //bool _IsActiveRow = true;
        private void cmbControl_CustomDrawRow(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawRowArgs e)
        {
            _IsActiveRow = Convert.ToBoolean(e.GetCellValue(0));

        }

        private void cmbControl_Enter(object sender, EventArgs e)
        {
            if (Fm.En2 == EnumCED.Create)
            {
                if (sender == cmb_NameKala)
                {
                    cmb_NameKala.ShowPopup();
                }
                else if (sender == cmbNameAnbar2)
                {
                    cmbNameAnbar2.ShowPopup();
                }
                else if (sender == cmbEz_Ks)
                {
                    cmbEz_Ks.ShowPopup();
                }
                else if (sender == cmbVizitor)
                {
                    cmbVizitor.ShowPopup();
                }
                else if (sender == cmbHesabMoin_Bed)
                {
                    cmbHesabMoin_Bed.ShowPopup();
                }
                else if (sender == cmbHesabMoin_Bes)
                {
                    cmbHesabMoin_Bes.ShowPopup();
                }
                else if (sender == cmbHesabTafsili1_Bed)
                {
                    cmbHesabTafsili1_Bed.ShowPopup();
                }
                else if (sender == cmbHesabTafsili2_Bed)
                {
                    cmbHesabTafsili2_Bed.ShowPopup();
                }
                else if (sender == cmbHesabTafsili3_Bed)
                {
                    cmbHesabTafsili3_Bed.ShowPopup();
                }
                else if (sender == cmbHesabTafsili1_Bes)
                {
                    cmbHesabTafsili1_Bes.ShowPopup();
                }
                else if (sender == cmbHesabTafsili2_Bes)
                {
                    cmbHesabTafsili2_Bes.ShowPopup();
                }
                else if (sender == cmbHesabTafsili3_Bes)
                {
                    cmbHesabTafsili3_Bes.ShowPopup();
                }
            }

        }

        //bool _IsActiveRow = true;
        private void cmbControl_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
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

        private void FrmSelectKala_Shown(object sender, EventArgs e)
        {
            if (Fm.objXtraTabPage_1.Name == "xtp_Vizitor")
                cmbVizitor.Focus();
            else if (Fm.objXtraTabPage_1.Name == "xtp_Ezafat" || Fm.objXtraTabPage_1.Name == "xtp_Ksorat")
                cmbEz_Ks.Focus();
            else if (Fm.objXtraTabPage_1.Name == "xtp_AghlamKala" || Fm.objXtraTabPage_1.Name == "xtp_AghlamKhadamat")
                cmb_NameKala.Focus();
        }

        public LookUpEdit cmbHesabMoin;
        public LookUpEdit cmbHesabTafsili1;
        public LookUpEdit cmbHesabTafsili2;
        public LookUpEdit cmbHesabTafsili3;

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (sender == cmbHesabMoin_Bed)
                    {
                        cmbHesabMoin = cmbHesabMoin_Bed;
                        cmbHesabTafsili1 = cmbHesabTafsili1_Bed;
                        cmbHesabTafsili2 = cmbHesabTafsili2_Bed;
                        cmbHesabTafsili3 = cmbHesabTafsili3_Bed;
                    }
                    else if (sender == cmbHesabMoin_Bes)
                    {
                        cmbHesabMoin = cmbHesabMoin_Bes;
                        cmbHesabTafsili1 = cmbHesabTafsili1_Bes;
                        cmbHesabTafsili2 = cmbHesabTafsili2_Bes;
                        cmbHesabTafsili3 = cmbHesabTafsili3_Bes;

                    }

                    FillCmbHesabTafsili();
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    var q = db.EpHesabMoin1s.FirstOrDefault(s => s.SalId == _SalId && s.Id == _HesabMoinId);
                    if (q != null)
                    {
                        switch (q.GroupTafsiliLevelsIndex)
                        {
                            case 0:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    break;
                                }
                            case 1:
                                {
                                    cmbHesabTafsili1.ReadOnly = false;
                                    cmbHesabTafsili2.ReadOnly = cmbHesabTafsili3.ReadOnly = true;
                                    break;
                                }
                            case 2:
                                {
                                    cmbHesabTafsili1.ReadOnly = cmbHesabTafsili2.ReadOnly = false;
                                    cmbHesabTafsili3.ReadOnly = true;
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

        private void txtDarsadTakhfifRadifiKala_Leave(object sender, EventArgs e)
        {
            VrodDarsadTakhfif = false;
        }

        bool MablaghTakhfifChenged = false;
        private void txtDarsadTakhfifRadifiKala_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDarsadTakhfifRadifiKala.IsEditorActive && VrodDarsadTakhfif)
            {
                //if (!string.IsNullOrEmpty(txtDarsadTakhfifRadifiKala.Text))
                   // if (Convert.ToSingle(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) != 0)
                        txtTakhfifRadifiKala.Text = ((Convert.ToDecimal(txtMablag.Text.Replace(",", "").Replace("/", ".")) * Convert.ToDecimal(txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", "."))) / 100).ToString();
                // else
                //   txtTakhfifRadifiKala.Text = "0";
                if(Convert.ToSingle( txtDarsadTakhfifRadifiKala.Text.Replace(",", "").Replace("/", ".")) !=0)
                MablaghTakhfifChenged = true;
            }
        }

        private void txtTakhfifRadifiKala_Enter(object sender, EventArgs e)
        {
            VrodMablaghTakhfif = true;
        }

        private void txtTakhfifRadifiKala_Leave(object sender, EventArgs e)
        {
            VrodMablaghTakhfif = false;
            if (IsValidMablaghTakhfif == false)
            {
                txtTakhfifRadifiKala.Text = _BeforeEditTakhfifRadifiKala;
            }
        }

        private void txtDarsadTakhfifRadifiKala_Enter(object sender, EventArgs e)
        {
            VrodDarsadTakhfif = true;
        }
    }
}