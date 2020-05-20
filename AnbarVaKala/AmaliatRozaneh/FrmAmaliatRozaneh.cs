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
using DBHesabdari_PG.Models.AK;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using HelpClassLibrary;
using DBHesabdari_PG;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DevExpress.XtraTab;

namespace AnbarVaKala.AmaliatRozaneh
{
    public partial class FrmAmaliatRozaneh : DevExpress.XtraEditors.XtraForm
    {
        MyContext dbContext;
        public FrmAmaliatRozaneh()
        {
            InitializeComponent();
            dbContext = new MyContext();
        }

        public EnumCED En1;
        public EnumCED En2;

        public void FillCmbNameAnbar()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _Sall = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpListAnbarhas.Where(s => s.SalId == _Sall && s.IsActive == true).ToList();
                    cmbNameAnbar.Properties.DataSource = q.Count > 0 ? q : null;

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
                    _Sall = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabMoin1s.Where(s => s.SalId == _Sall && s.IsActive == true).ToList();
                    cmbHesabMoin.Properties.DataSource = q.Count > 0 ? q : null;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int _HesabMoinId = 0;
        public void FillCmbHesabTafsili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _Sall = Convert.ToInt32(lblSalId.Text);
                    _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    List<EpAllHesabTafsili> list = new List<EpAllHesabTafsili>();
                    var q1 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == _HesabMoinId && s.SalId == _Sall).Select(s => s.AllGroupTafsiliId).ToList();
                    if (q1.Count > 0)
                    {
                        foreach (var item in q1)
                        {
                            var q = db.EpAllHesabTafsilis.Where(s => s.SalId == _Sall && s.IsActive == true && s.GroupTafsiliId == item).ToList();
                            list.AddRange(q);
                        }
                        cmbHesabTafsili.Properties.DataSource = list;
                    }
                    else
                        cmbHesabTafsili.Properties.DataSource = null;


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("آیا ردیف انتخابی گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //gridView_AmaliatAddVaEdit.DeleteSelectedRows();
                gridView_AmaliatAddVaEdit.DeleteRow(gridView_AmaliatAddVaEdit.FocusedRowHandle);

                if (gridView_AmaliatAddVaEdit.RowCount == 0)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = btnLast1.Enabled = btnNext1.Enabled = btnPreview1.Enabled =
                        btnFirst1.Enabled = btnSaveAndClosed.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
                }
            }

        }
        // int _Index = 0;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            En2 = EnumCED.Create;
            FrmAmaliatVorodeKala fm = new FrmAmaliatVorodeKala(this);
            //fm.MdiParent = this;
            fm.lblUserId.Text = lblUserId.Text;
            fm.lblUserName.Text = lblUserName.Text;
            fm.lblSalId.Text = lblSalId.Text;
            fm.lblSalMali.Text = lblSalMali.Text;
            fm.ShowDialog();

            //gridView_AmaliatAddVaEdit.AddNewRow();
            //gridView_AmaliatAddVaEdit.FocusInvalidRow();
            //gridView_AmaliatAddVaEdit.SetRowCellValue(0, "M", 10);
            //add a new row
            //gridView_AmaliatAddVaEdit.AddNewRow();
            //set a new row cell value. The static GridControl.NewItemRowHandle field allows you to retrieve the added row
            //gridView_AmaliatAddVaEdit.SetRowCellValue(GridControl.NewItemRowHandle, gridView_AmaliatAddVaEdit.Columns["Meghdar"], 11);

            //gridView_AmaliatAddVaEdit_InitNewRow(null, null);
            //gridView_AmaliatAddVaEdit.AddNewRow();
            //if (gridView_AmaliatAddVaEdit.RowCount > 0)
            //    _Index = gridView_AmaliatAddVaEdit.RowCount;
            //else
            //    _Index = 0;
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Meghdar", "105");
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Nerkh", "106");
            //gridView_AmaliatAddVaEdit.SetRowCellValue(_Index, "Mablag", "107");


            //BindingList<AkVorodeKala_Riz> List1 = new BindingList<AkVorodeKala_Riz>();
            //List1[0].Mablag = 11;
            //(gridControl_AmaliatAddVaEdit.DataSource as BindingList<List1>).AddNew();


            //List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>()
            //          {
            //              new AkVorodeKala_Riz { Meghdar = 11, },
            //              new AkVorodeKala_Riz { Meghdar = 12, },
            //          };
            //BindingList<AkVorodeKala_Riz> bindingList = new BindingList<AkVorodeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

            //List<AkVorodeKala_Riz> list = new List<AkVorodeKala_Riz>()
            //{
            //    new AkVorodeKala_Riz(){Meghdar = 13,Nerkh = 14,Mablag = 15,}
            //};
            //BindingList<AkVorodeKala_Riz> bindingList = new BindingList<AkVorodeKala_Riz>(list);
            //BindingSource source = new BindingSource(bindingList, null);
            //gridControl_AmaliatAddVaEdit.DataSource = source;

        }

        private void gridView_AmaliatAddVaEdit_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "CodeKala", "101001010");
            view.SetRowCellValue(e.RowHandle, "NameKala", "فریم آریا وین 3 حفره");
            view.SetRowCellValue(e.RowHandle, "VahedeKala", "متر");
            view.SetRowCellValue(e.RowHandle, "Meghdar", "105");
            view.SetRowCellValue(e.RowHandle, "Nerkh", "106");
            view.SetRowCellValue(e.RowHandle, "Mablag", "107");

            // gridView_AmaliatAddVaEdit.AddNewRow();
        }

        private void gridView_AmaliatAddVaEdit_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            HelpClass1.CustomDrawRowIndicator(sender, e, gridView_AmaliatAddVaEdit);
            //HelpClass1.MoveFirst(gridView_AmaliatAddVaEdit);
            //gridView_AmaliatAddVaEdit.FocusInvalidRow();
            //HelpClass1.MoveLast(gridView_AmaliatAddVaEdit);

        }

        private void btnLast1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveLast(gridView_AmaliatAddVaEdit);
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveNext(gridView_AmaliatAddVaEdit);

        }

        private void btnPreview1_Click(object sender, EventArgs e)
        {
            HelpClass1.MovePrev(gridView_AmaliatAddVaEdit);

        }

        private void btnFirst1_Click(object sender, EventArgs e)
        {
            HelpClass1.MoveFirst(gridView_AmaliatAddVaEdit);

        }

        string _SelectedTabPage1 = string.Empty;
        string _SelectedTabPage1_1 = string.Empty;
        //string _SelectedTabPage1_2 = string.Empty;
        int _IndexTabPage = 0;

        int _Sall = 0;
        int _AnbarId = 0;
        int _TabPageCount = 0;

        //XtraTabControl XtraTabControl1;
        XtraTabControl XtraTabControl1_1;
        //XtraTabControl XtraTabControl1_2;
        //XtraTabPage XtraTabPage1;
        //XtraTabPage XtraTabPage1_1;
        //XtraTabPage XtraTabPage1_2;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    En1 = EnumCED.Create;
                    _AnbarId = Convert.ToInt32(cmbNameAnbar.EditValue);
                    if (_AnbarId == 0)
                    {
                        XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbNameAnbar.Focus();
                        return;
                    }

                    _Sall = Convert.ToInt32(lblSalId.Text);
                    panelControl_Button.Enabled = panelControl_NameAnbar.Enabled = false;
                    _SelectedTabPage1 = xtcAmaliatRozaneh.SelectedTabPage.Name;
                    switch (_SelectedTabPage1)
                    {
                        case "xtpVrodeKala":
                            {
                                XtraTabControl1_1 = xtc_VorodeKala;
                                _IndexTabPage = XtraTabControl1_1.SelectedTabPageIndex;
                                _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;
                                txtNoeSanad.Text = XtraTabControl1_1.SelectedTabPage.Text;
                                txtNoeSanad.BackColor = Color.LightGreen;
                                xtp_AddVaEdit.PageVisible = true;
                                xtp_AddVaEdit.Appearance.Header.BackColor = Color.LightGreen;
                                HelpClass1.DateTimeMask(txtTarikh);
                                txtTarikh.Text = DateTime.Now.ToString();
                                chkIsSanadHesabdari.Checked = true;
                                switch (_SelectedTabPage1_1)
                                {
                                    case "xtp_ResidKharid":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _Sall && s.AnbarId == _AnbarId && s.NoeAmaliatIndex == 2 && s.AmaliatIndex == 201).ToList();
                                            if (q.Count > 0)
                                            {
                                                txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                                            }
                                            else
                                                txtSeryal.Text = "1";
                                            break;
                                        }
                                    case "xtp_BargashtAzFroosh":
                                        {
                                            var q = db.AkVorodeKala_Rizs.Where(s => s.SalId == _Sall && s.AnbarId == _AnbarId && s.NoeAmaliatIndex == 2 && s.AmaliatIndex == 202).ToList();
                                            if (q.Count > 0)
                                            {
                                                txtSeryal.Text = (q.Max(s => s.Seryal) + 1).ToString();
                                            }
                                            else
                                                txtSeryal.Text = "1";
                                            break;
                                        }

                                    default:
                                        break;
                                }
                                _TabPageCount = XtraTabControl1_1.TabPages.Count;
                                XtraTabControl1_1.SelectedTabPageIndex = _TabPageCount - 1;

                                break;
                            }
                        case "xtpKhrojeKala":
                            {
                                break;
                            }
                        case "xtpJabejaeeKala":
                            {
                                break;
                            }
                        case "xtpMojodiAvalDore":
                            {
                                break;
                            }
                        default:
                            break;
                    }

                    for (int i = 0; i < xtcAmaliatRozaneh.TabPages.Count; i++)
                    {
                        if (xtcAmaliatRozaneh.TabPages[i].Name != _SelectedTabPage1)
                        {
                            xtcAmaliatRozaneh.TabPages[i].PageEnabled = false;
                        }
                    }
                    for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                    {
                        if (XtraTabControl1_1.TabPages[i].Name != _SelectedTabPage1_1)
                        {
                            XtraTabControl1_1.TabPages[i].PageEnabled = false;
                        }
                    }
                    xtp_AddVaEdit.PageEnabled = true;
                    FillCmbHesabMoin();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dbContext.AkVorodeKala_Rizs.Where(s => s.Id == 0).LoadAsync().ContinueWith(loadTask =>
                {
                // Bind data to control when loading complete
                akVorodeKala_RizsBindingSource.DataSource = dbContext.AkVorodeKala_Rizs.Local.ToBindingList();
                }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());


        }

        private void FrmAmaliatRozaneh_Load(object sender, EventArgs e)
        {
            _Sall = Convert.ToInt32(lblSalId.Text);

            _SelectedTabPage1 = xtcAmaliatRozaneh.SelectedTabPage.Name;
            xtcAmaliatRozaneh.SelectedTabPageIndex = 0;

            XtraTabControl1_1 = xtc_VorodeKala;
            _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;
            XtraTabControl1_1.SelectedTabPageIndex = 0;

            FillCmbNameAnbar();

        }

        private void xtcAmaliatRozaneh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _SelectedTabPage1 = xtcAmaliatRozaneh.SelectedTabPage.Name;

            switch (_SelectedTabPage1)
            {
                case "xtpVrodeKala":
                    {
                        XtraTabControl1_1 = xtc_VorodeKala;
                        _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;
                        break;
                    }
                case "xtpKhrojeKala":
                    {
                        XtraTabControl1_1 = xtc_KhorojeKala;
                        _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;
                        break;
                    }
                case "xtpJabejaeeKala":
                    {
                        break;
                    }
                case "xtpMojodiAvalDore":
                    {
                        break;
                    }
                default:
                    break;
            }



        }

        private void xtc_VorodeKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl1_1 = xtc_VorodeKala;
            _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;
        }

        private void xtc_KhorojeKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl1_1 = xtc_KhorojeKala;
            _SelectedTabPage1_1 = XtraTabControl1_1.SelectedTabPage.Name;

        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillCmbNameAnbar();
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
            FillCmbHesabTafsili();
            cmbHesabTafsili.EditValue = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < xtcAmaliatRozaneh.TabPages.Count; i++)
            {
                if (xtcAmaliatRozaneh.TabPages[i].Name != _SelectedTabPage1)
                {
                    xtcAmaliatRozaneh.TabPages[i].PageEnabled = true;
                }
            }

            _SelectedTabPage1 = xtcAmaliatRozaneh.SelectedTabPage.Name;
            switch (_SelectedTabPage1)
            {
                case "xtpVrodeKala":
                    {
                        for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                        {
                            if (XtraTabControl1_1.TabPages[i].Name != _SelectedTabPage1_1)
                            {
                                XtraTabControl1_1.TabPages[i].PageEnabled = true;
                            }
                        }
                        XtraTabControl1_1.SelectedTabPageIndex = _IndexTabPage;
                        break;
                    }
                case "xtpKhrojeKala":
                    {
                        for (int i = 0; i < XtraTabControl1_1.TabPages.Count; i++)
                        {
                            if (XtraTabControl1_1.TabPages[i].Name != _SelectedTabPage1_1)
                            {
                                XtraTabControl1_1.TabPages[i].PageEnabled = true;
                            }
                        }
                        XtraTabControl1_1.SelectedTabPageIndex = _IndexTabPage;
                        break;
                    }
                case "xtpJabejaeeKala":
                    {
                        break;
                    }
                case "xtpMojodiAvalDore":
                    {
                        break;
                    }
                default:
                    break;
            }

            HelpClass1.ClearControls(panelControl_AddVaEdit);
            btnDelete1.Enabled = btnEdit1.Enabled = btnLast1.Enabled = btnNext1.Enabled = btnPreview1.Enabled =
                btnFirst1.Enabled = btnSaveAndClosed.Enabled = btnSaveAndPrintAndClosed.Enabled = false;
            xtp_AddVaEdit.PageVisible = false;
            panelControl_Button.Enabled = panelControl_NameAnbar.Enabled = true;

            akVorodeKala_RizsBindingSource.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbContext.Dispose();
            panelControl_Button.Enabled = panelControl_NameAnbar.Enabled = true;
            this.Close();
        }

        private void cmbNameAnbar_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);
        }

        private void cmbHesabMoin_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void cmbHesabTafsili_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            HelpClass1.LookupEdit_CustomDrawCell(sender, e);

        }

        private void gridView_AmaliatAddVaEdit_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (gridView_AmaliatAddVaEdit.RowCount > 0)
                {
                    btnDelete1.Enabled = btnEdit1.Enabled = btnLast1.Enabled = btnNext1.Enabled = btnPreview1.Enabled = btnFirst1.Enabled = true;
                }
            }
            catch (Exception)
            {
            }

        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (gridView_AmaliatAddVaEdit.RowCount > 0)
            {
                En2 = EnumCED.Edit;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            En1 = EnumCED.Edit;

        }

        private void gridView_AmaliatAddVaEdit_KeyDown(object sender, KeyEventArgs e)
        {
            gridView_AmaliatAddVaEdit_RowCellClick(null, null);
        }

        private void gridView_AmaliatAddVaEdit_KeyUp(object sender, KeyEventArgs e)
        {
            gridView_AmaliatAddVaEdit_RowCellClick(null, null);
        }
    }
}