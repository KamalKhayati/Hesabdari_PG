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
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System.Data.Entity;
using DBHesabdari_PG.Models.Ms.ActiveSystem;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmCodingHesabdari : DevExpress.XtraEditors.XtraForm
    {
        public FrmCodingHesabdari()
        {
            InitializeComponent();
        }

        MyContext db1 = new MyContext();
        EnumCED En;
        EnumTreeList treeList;
        //bool IsActiveList = true;

        int _SalId = 0;
        int _Code = 0;
        string _Name = "";
        bool _IsActive = true;
        string _SharhHesab = "";
        int _LevelNamber = 0;
        int _TabaghehId = 0;
        int _GroupId = 0;
        int _ColId = 0;
        int _GroupTafsiliLevelId = 0;
        public int EditRowIndex = 0;
        int _IndexTabControl3 = 0;

        int TabaghehIdBeforeEdit = 0;
        int GroupIdBeforeEdit = 0;
        int ColIdBeforeEdit = 0;
        int CodeBeforeEdit = 0;
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;

        int _Carakter = 0;
        int _HesabTabaghehCarakter = 0;
        int _HesabGroupCarakter = 0;
        int _HesabColCarakter = 0;
        int _HesabMoin1Carakter = 0;

        string _HesabTabaghehMinCode = "";
        string _HesabTabaghehMaxCode = "";
        string _HesabGroupMinCode = "";
        string _HesabGroupMaxCode = "";
        string _HesabColMinCode = "";
        string _HesabColMaxCode = "";
        string _HesabMoin1MinCode = "";
        string _HesabMoin1MaxCode = "";

        GridView gridView;
        GridControl gridControl;
        LookUpEdit cmbHesab;
        ComboBoxEdit cmbNoeHesab;
        ComboBoxEdit cmbMahiatHesab;
        SimpleButton btnReload;
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
        LabelControl lblNoeHesab;


        /////////////////////////////////////////////////////////

        public void FillGridviewCodingHesabdari()
        {
            using (var db = new MyContext())
            {
                try
                {
                    btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q1 = db.EpHesabTabaghehs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                            {
                                gridControl1.DataSource = q1;
                            }
                            else
                                gridControl1.DataSource = null;
                        }

                        //gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
                        // gridView1.Appearance.Row.ForeColor = Color.Black;

                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabTabaghehId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item3 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabTabagheh.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            gridControl1.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            gridControl1.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        gridControl1.DataSource = null;
                        //}
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q1 = db.EpHesabGroups.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                                gridControl2.DataSource = q1;
                            else
                                gridControl2.DataSource = null;
                        }

                        //gridView2.Appearance.HeaderPanel.ForeColor = Color.Black;
                        // gridView1.Appearance.Row.ForeColor = Color.Black;

                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = db.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item3 =>
                        //            {
                        //                q1.Remove(db.EpHesabGroups.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            gridControl1.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            gridControl1.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        gridControl1.DataSource = null;
                        //}
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q1 = db.EpHesabCols.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                                gridControl3.DataSource = q1;
                            else
                                gridControl3.DataSource = null;
                        }

                        // gridView3.Appearance.HeaderPanel.ForeColor = Color.Black;
                        //   gridView1.Appearance.Row.ForeColor = Color.Black;

                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId == 0 && s.IsActive == true).Select(s => s.HesabColId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabCols.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            gridControl1.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            gridControl1.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        gridControl1.DataSource = null;
                        //}
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q1 = db.EpHesabMoin1s.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (q1.Count > 0)
                                gridControl4.DataSource = q1;
                            else
                                gridControl4.DataSource = null;
                        }

                        //gridView4.Appearance.HeaderPanel.ForeColor = Color.Black;
                        //  gridView1.Appearance.Row.ForeColor = Color.Black;
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBEpAllCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabMoinId > 0 && s.IsActive == true).Select(s => s.HesabMoinId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item2 =>
                        //            {
                        //                q1.Remove(dataContext.EpHesabMoins.FirstOrDefault(s => s.Id == item2));
                        //            });
                        //            gridControl1.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            gridControl1.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        gridControl1.DataSource = null;
                        //}

                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_DerakhtVareh)
                    {
                        var q1 = db.EpAllCodingHesabdaris.Where(s => s.SalId == _SalId).ToList();
                        if (q1.Count > 0)
                        {
                            epAllCodingHesabdarisBindingSource.DataSource = q1;
                            // treeListCodingHesabdari.CollapseAll();
                            // treeListCodingHesabdari.ExpandAll();
                        }
                        else
                            epAllCodingHesabdarisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillcmbHesabTabagheh()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group
                        || xtraTabControl1.SelectedTabPage == xtraTabPage_Col
                        || xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        if (db.EpHesabTabaghehs.Any())
                        {
                            _SalId = Convert.ToInt32(lblSalId.Text);

                            db.EpHesabTabaghehs.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epHesabTabaghehsBindingSource.DataSource = db.EpHesabTabaghehs.Local.ToBindingList();
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

        public void FillcmbHesabGroup()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        _SalId = Convert.ToInt32(lblSalId.Text);

                        if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                            _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_3.EditValue);
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                            _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_4.EditValue);

                        db.EpHesabGroups.Where(s => s.TabaghehId == _TabaghehId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                        epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbHesabCol()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabCols.Any())
                    {
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        _GroupId = Convert.ToInt32(cmbListHesabGroup_4.EditValue);
                        db.EpHesabCols.Where(s => s.GroupId == _GroupId && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                        epHesabColsBindingSource.DataSource = db.EpHesabCols.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillDataGridSharhStandard()
        {
            //using (var db = new MyContext())
            //{
            try
            {
                db1 = new MyContext();
                if (db1.EpSharhStandardMoins.Any())
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    int RowId = Convert.ToInt32(txtId_4.Text);
                    db1.EpSharhStandardMoins.Where(s => s.MoinId == RowId && s.SalId == _SalId).OrderBy(s => s.Id).Load();
                    epSharhStandardMoinsBindingSource.DataSource = db1.EpSharhStandardMoins.Local.ToBindingList();
                }
                //else
                //    epSharhStandardMoinsBindingSource.DataSource = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}

        }

        public void FillListBoxActiveSystem()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsActiveSystems.Any())
                    {
                        db.MsActiveSystems.Where(s => s.IsActive == true).OrderBy(s => s.Code).Load();
                        msActiveSystemsBindingSource.DataSource = db.MsActiveSystems.Local.ToBindingList();
                    }
                    else
                        msActiveSystemsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillListBoxGroupTafsiliLevels()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    if (db.EpGroupTafsiliLevel1s.Any())
                    {
                        db.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                        epGroupTafsiliLevel1sBindingSource.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                    }
                    else
                    {
                        epGroupTafsiliLevel1sBindingSource.DataSource = null;

                    }

                    if (db.EpGroupTafsiliLevel2s.Any())
                    {
                        db.EpGroupTafsiliLevel2s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                        epGroupTafsiliLevel2sBindingSource.DataSource = db.EpGroupTafsiliLevel2s.Local.ToBindingList();
                    }
                    else
                    {
                        epGroupTafsiliLevel2sBindingSource.DataSource = null;

                    }

                    if (db.EpGroupTafsiliLevel3s.Any())
                    {
                        db.EpGroupTafsiliLevel3s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                        epGroupTafsiliLevel3sBindingSource.DataSource = db.EpGroupTafsiliLevel3s.Local.ToBindingList();
                    }
                    else
                    {
                        epGroupTafsiliLevel3sBindingSource.DataSource = null;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        int _cmbNoeHesabIndex = 0;
        string _cmbNoeHesabName = "";
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

                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                    {
                        _Code = !String.IsNullOrEmpty(txtCode.Text) ? Convert.ToInt32(txtCode.Text) : 0;
                        _cmbNoeHesabIndex = cmbNoeHesab_1.SelectedIndex;
                        _cmbNoeHesabName = cmbNoeHesab_1.Text;

                        if (_HesabTabaghehCarakter > 1 && Convert.ToInt32(txtCode_1.Text) < 10)
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabTabaghehMinCode + " تا " + _HesabTabaghehMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_1.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Code.ToString()))
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_1.Focus();
                            return false;
                        }
                        else if (_Code == 0 || _Code > Convert.ToInt32(_HesabTabaghehMaxCode) || _Code < Convert.ToInt32(_HesabTabaghehMinCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabTabaghehMinCode + " تا " + _HesabTabaghehMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_1.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName_1.Focus();
                            return false;
                        }
                        else if (cmbNoeHesab_1.Text == string.Empty)
                        {
                            XtraMessageBox.Show("لطفاً نوع حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbNoeHesab_1.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                if (db.EpHesabTabaghehs.Any())
                                {
                                    var q1 = db.EpHesabTabaghehs.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1 != null)
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;

                                    }
                                    else if (db.EpHesabTabaghehs.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId_1.Text);
                                var q1 = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // txtCode.Text = CodeBeforeEdit;
                                    _Code = CodeBeforeEdit;
                                    return false;
                                }
                                else if (db.EpHesabTabaghehs.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
                                    return false;
                                }
                            }
                        }

                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                    {
                        _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_2.EditValue);
                        _Code = !String.IsNullOrEmpty(txtTabaghehCode_2.Text) && !String.IsNullOrEmpty(txtCode_2.Text) ? Convert.ToInt32(txtTabaghehCode_2.Text + txtCode_2.Text) : 0;

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (_TabaghehId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbHesabTabagheh_2.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(txtCode_2.Text) || string.IsNullOrEmpty(txtTabaghehCode_2.Text) || Convert.ToInt32(txtTabaghehCode_2.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_2.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode_2.Text) == 0 || Convert.ToInt32(txtCode_2.Text) > Convert.ToInt32(_HesabGroupMaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabGroupMinCode + " تا " + _HesabGroupMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_2.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName_2.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                if (db.EpHesabGroups.Any())
                                {
                                    var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1 != null)
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                    else if (db.EpHesabGroups.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId_2.Text);
                                var q1 = db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_2.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter);
                                    return false;
                                }
                                else if (db.EpHesabGroups.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
                                    return false;
                                }
                            }
                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_3.EditValue);
                        _GroupId = Convert.ToInt32(cmbListHesabGroup_3.EditValue);
                        _Code = !String.IsNullOrEmpty(txtGroupCode_3.Text) && !String.IsNullOrEmpty(txtCode_3.Text) ? Convert.ToInt32(txtGroupCode_3.Text + txtCode_3.Text) : 0;

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (_TabaghehId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbHesabTabagheh_3.Focus();
                            return false;
                        }
                        if (_GroupId == 0)
                        {
                            XtraMessageBox.Show("لطفا حساب گروه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbListHesabGroup_3.Focus();
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCode_3.Text) || string.IsNullOrEmpty(txtGroupCode_3.Text) || Convert.ToInt32(txtGroupCode_3.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_3.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode_3.Text) == 0 || Convert.ToInt32(txtCode_3.Text) > Convert.ToInt32(_HesabColMaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabColMinCode + " تا " + _HesabColMaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_3.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName_3.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                if (db.EpHesabCols.Any())
                                {
                                    var q1 = db.EpHesabCols.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1 != null)
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                    else if (db.EpHesabCols.FirstOrDefault(s => s.Name == _Name && s.SalId == _SalId) != null)
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId_3.Text);
                                var q1 = db.EpHesabCols.FirstOrDefault(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_3.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter);
                                    return false;
                                }
                                else if (db.EpHesabCols.FirstOrDefault(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId) != null)
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
                                    return false;
                                }
                            }

                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        _Code = !String.IsNullOrEmpty(txtColCode_4.Text) && !String.IsNullOrEmpty(txtCode_4.Text) ? Convert.ToInt32(txtColCode_4.Text + txtCode_4.Text) : 0;
                        _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_4.EditValue);
                        _GroupId = Convert.ToInt32(cmbListHesabGroup_4.EditValue);
                        _ColId = Convert.ToInt32(cmbListHesabCol_4.EditValue);
                        _GroupTafsiliLevelId = cmbGroupTafsiliLevels_4.SelectedIndex;

                        ///////////////// اعتبار سنجی کد ////////////////////////////////////
                        if (string.IsNullOrEmpty(cmbHesabTabagheh_4.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب طبقه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbHesabTabagheh_4.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(cmbListHesabGroup_4.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب گروه را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbListHesabGroup_4.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(cmbListHesabCol_4.Text))
                        {
                            XtraMessageBox.Show("لطفاً حساب کل را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbListHesabCol_4.Focus();
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCode_4.Text) || string.IsNullOrEmpty(txtColCode_4.Text) || Convert.ToInt32(txtColCode_4.Text) == 0)
                        {
                            XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_4.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(txtCode_4.Text) == 0 || Convert.ToInt32(txtCode_4.Text) > Convert.ToInt32(_HesabMoin1MaxCode))
                        {
                            XtraMessageBox.Show("کد وارده بایستی عددی از " + _HesabMoin1MinCode + " تا " + _HesabMoin1MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCode_4.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(_Name) || _Name == "0")
                        {
                            XtraMessageBox.Show("لطفاً نام حساب معین را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName_4.Focus();
                            return false;
                        }
                        else if (cmbMahiatHesab_4.SelectedIndex == -1)
                        {
                            XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbMahiatHesab_4.Focus();
                            return false;
                        }
                        else if (cmbGroupTafsiliLevels_4.SelectedIndex == -1)
                        {
                            XtraMessageBox.Show("لطفاً نوع ارتباط با سطوح تفصیلی را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbGroupTafsiliLevels_4.Focus();
                            return false;
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                            {
                                if (db.EpHesabMoin1s.Any())
                                {
                                    var q1 = db.EpHesabMoin1s.Where(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1.Any())
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                    else if (db.EpHesabMoin1s.Where(s => s.Name == _Name && s.SalId == _SalId).Any())
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int RowId = Convert.ToInt32(txtId_4.Text);
                                var q1 = db.EpHesabMoin1s.Where(s => s.Id != RowId && s.Code == _Code && s.SalId == _SalId);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_4.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                                    return false;
                                }
                                else if (db.EpHesabMoin1s.Where(s => s.Id != RowId && s.Name == _Name && s.SalId == _SalId).Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //txtName.Text = nameBeforeEdit;
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
                                if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                                {
                                    EpHesabTabagheh obj = new EpHesabTabagheh();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.IndexNoeHesab = cmbNoeHesab_1.SelectedIndex;
                                    obj.NoeHesab = cmbNoeHesab_1.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    // var q = db.EpHesabTabagheh.FirstOrDefault(s => s.Code == _code && s.SalId == _SalId);
                                    ////////////////////////////////////// اضافه کردن حساب طبقه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = _Code;
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpHesabTabagheh1 = obj;
                                    db.EpAllCodingHesabdaris.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridviewCodingHesabdari();

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                                {
                                    EpHesabGroup obj = new EpHesabGroup();
                                    obj.SalId = Convert.ToInt32(lblSalId.Text);
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.TabaghehId = _TabaghehId;
                                    //obj.TabaghehName = cmbHesabTabagheh.Text;
                                    obj.IsActive = _IsActive;
                                    //obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                    //obj.NoeHesab = cmbNoeHesab.Text;
                                    obj.SharhHesab = _SharhHesab;

                                    //var qq = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _HesabTabaghehId && s.SalId == _SalId);
                                    //qq.EpHesabGroups.Add(obj);

                                    //EpHesabTabagheh obj1 = new EpHesabTabagheh();
                                    //obj1.EpHesabGroups.Add(obj);
                                    //db.EpHesabGroups.Add(obj);
                                    //db.SaveChanges();
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //var q = db.EpHesabGroups.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    ////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    n1.SalId = Convert.ToInt32(lblSalId.Text);
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtTabaghehCode_2.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpHesabGroup1 = obj;
                                    db.EpAllCodingHesabdaris.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridviewCodingHesabdari();

                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;
                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                                {
                                    EpHesabCol obj = new EpHesabCol();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.IsActive = _IsActive;
                                    obj.GroupId = _GroupId;
                                    //obj.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                    //obj.MahiatHesab = cmbMahiatHesab.Text;
                                    //obj.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                    //obj.NoeHesab = cmbNoeHesab.Text;
                                    obj.SharhHesab = _SharhHesab;

                                    /////////////////////////////////////////////////////////////////////////////////////
                                    //_SalId = Convert.ToInt32(lblSalId.Text);
                                    //var q = db.EpHesabCols.FirstOrDefault(s => s.Code == _Code && s.SalId == _SalId);
                                    ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtGroupCode_3.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpHesabCol1 = obj;
                                    db.EpAllCodingHesabdaris.Add(n1);
                                    /////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridviewCodingHesabdari();

                                    // XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                                {
                                    EpHesabMoin1 obj = new EpHesabMoin1();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.GroupLevelsId = _GroupTafsiliLevelId;
                                    obj.GroupLevelsName = cmbGroupTafsiliLevels_4.Text;
                                    obj.IsActive = _IsActive;
                                    obj.ColId = _ColId;
                                    obj.IndexMahiatHesab = cmbMahiatHesab_4.SelectedIndex;
                                    obj.MahiatHesab = cmbMahiatHesab_4.Text;
                                    obj.SharhHesab = _SharhHesab;
                                    /////////////
                                    string GroupTafsili = string.Empty;
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            GroupTafsili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    GroupTafsili += "/";
                                    for (int i = 0; i < chkListBoxLevel2.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel2.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            GroupTafsili += chkListBoxLevel2.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    GroupTafsili += "/";
                                    for (int i = 0; i < chkListBoxLevel3.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel3.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            GroupTafsili += chkListBoxLevel3.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    obj.SelectedGroupTafsiliLevel1 = GroupTafsili;
                                    ////////////
                                    string ActiveSystem = string.Empty;
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                        }
                                    }
                                    obj.SelectedActivesystem = ActiveSystem;
                                    //////////
                                    List<EpSharhStandardMoin> obj01 = new List<EpSharhStandardMoin>();

                                    for (int i = 0; i < gridView5.RowCount; i++)
                                    {
                                        EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                        obj1.SalId = _SalId;
                                        obj1.Name = gridView5.GetRowCellDisplayText(i, "Name");
                                        //obj1.MoinCode = _Code;
                                        obj01.Add(obj1);
                                    }
                                    obj.EpSharhStandardMoins = obj01;

                                    ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllCodingHesabdari n1 = new EpAllCodingHesabdari();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(txtColCode_4.Text);
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpHesabMoin1 = obj;

                                    //////////////////
                                    List<REpAllCodingHesabdariBEpAllGroupTafsili> obj03 = new List<REpAllCodingHesabdariBEpAllGroupTafsili>();
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));

                                            REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                            obj1.SalId = _SalId;
                                            obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                            obj1.LevelNamber = 1;
                                            obj03.Add(obj1);
                                        }
                                    }
                                    for (int i = 0; i < chkListBoxLevel2.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel2.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel2.GetItemValue(i));

                                            REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                            obj1.SalId = _SalId;
                                            obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                            obj1.LevelNamber = 2;
                                            obj03.Add(obj1);
                                        }
                                    }
                                    for (int i = 0; i < chkListBoxLevel3.ItemCount; i++)
                                    {
                                        if (chkListBoxLevel3.GetItemCheckState(i) == CheckState.Checked)
                                        {
                                            int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel3.GetItemValue(i));

                                            REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                            obj1.SalId = _SalId;
                                            obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                            obj1.LevelNamber = 3;
                                            obj03.Add(obj1);
                                        }
                                    }

                                    n1.REpAllCodingHesabdariBEpAllGroupTafsilis = obj03;
                                    /////////////
                                    List<REpAllCodingHesabdariBMsActiveSystem> obj02 = new List<REpAllCodingHesabdariBMsActiveSystem>();
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                        {
                                            int _ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));

                                            REpAllCodingHesabdariBMsActiveSystem obj1 = new REpAllCodingHesabdariBMsActiveSystem();
                                            obj1.SalId = _SalId;
                                            obj1.ActiveSystemId = _ActiveSystemId;
                                            //obj1.ActiveSystemCode = db.MsActiveSystems.FirstOrDefault(s =>s.Id == _ActiveSystemId).Code;
                                            //obj1.MoinCode = _Code;
                                            obj02.Add(obj1);
                                        }
                                    }
                                    n1.REpAllCodingHesabdariBMsActiveSystems = obj02;
                                    /////////////

                                    db.EpAllCodingHesabdaris.Add(n1);

                                    db.SaveChanges();
                                    btnCancel_Click(null, null);
                                    FillGridviewCodingHesabdari();
                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    En = EnumCED.Save;

                                }

                            }
                            else if (En == EnumCED.Edit)
                            {
                                if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                                {
                                    int RowId = Convert.ToInt32(txtId_1.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpHesabMoin1s.Where(s => s.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q5 = db.EpHesabCols.Where(s => s.EpHesabGroup1.EpHesabTabagheh1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q5.Count > 0)
                                    {
                                        foreach (var item in q5)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q6)
                                            {
                                                if (item1.ColId == item.Id)
                                                    item.EpHesabMoin1s.Append(item1);
                                            }
                                        }
                                    }
                                    /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                    var q4 = db.EpHesabGroups.Where(s => s.TabaghehId == RowId && s.SalId == _SalId).ToList();
                                    if (q4.Count > 0)
                                    {
                                        foreach (var item in q4)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q5)
                                            {
                                                if (item1.GroupId == item.Id)
                                                    item.EpHesabCols.Append(item1);
                                            }
                                        }
                                    }

                                    var q = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.IsActive = _IsActive;
                                        q.IndexNoeHesab = cmbNoeHesab_1.SelectedIndex;
                                        q.NoeHesab = cmbNoeHesab_1.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.EpHesabGroups = q4;
                                    }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = _Code;
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpHesabTabagheh1 = q;

                                        var q3 = db.EpAllCodingHesabdaris.Where(s => s.EpHesabGroup1.TabaghehId == RowId || s.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId || s.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_HesabTabaghehCarakter));
                                                }
                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                                   s.EpAllCodingHesabdari1.Id == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabGroup1.TabaghehId == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.EpHesabTabagheh1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q9.Count > 0)
                                        {
                                            foreach (var item in q9)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter), _Code.ToString())
                                                            + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter));
                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        /////////////////////////////////////////////////////////////////////////////////////////////

                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridviewCodingHesabdari();

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView1.RowCount > 0)
                                            gridView1.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                                {
                                    int RowId = Convert.ToInt32(txtId_2.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpHesabMoin1s.Where(s => s.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    /////////////////////////////// WillCascadeOnUpdate : EpHesabCols ///////////////////////
                                    var q5 = db.EpHesabCols.Where(s => s.GroupId == RowId && s.SalId == _SalId).ToList();
                                    if (q5.Count > 0)
                                    {
                                        foreach (var item in q5)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;

                                            foreach (var item1 in q6)
                                            {
                                                if (item1.ColId == item.Id)
                                                    item.EpHesabMoin1s.Append(item1);
                                            }
                                        }
                                    }
                                    //////////////////////////////////////////////////////
                                    var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.TabaghehId = _TabaghehId;
                                        q.IsActive = _IsActive;
                                        //q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                        //q.NoeHesab = cmbNoeHesab.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.EpHesabCols = q5;
                                    }
                                    ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                    var q2 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(txtTabaghehCode_2.Text);
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpHesabGroup1 = q;

                                        var q3 = db.EpAllCodingHesabdaris.Where(s => s.EpHesabCol1.GroupId == RowId || s.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                                }

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }

                                        }

                                        /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                        var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                                   s.EpAllCodingHesabdari1.Id == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabCol1.GroupId == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.EpHesabGroup1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q9.Count > 0)
                                        {
                                            foreach (var item in q9)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter), _Code.ToString())
                                                            + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter));
                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (IsActiveBeforeEdit == false && chkIsActive_2.Checked == true)
                                        {
                                            var T = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId);
                                            var A = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId);
                                            var U = db.RmsUserBallCodingHesabdaris.FirstOrDefault(s => s.CodingHesabdariId == _TabaghehId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (A != null)
                                                A.IsActive = true;
                                            if (U != null)
                                                U.IsActive = true;
                                        }


                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridviewCodingHesabdari();
                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                                {
                                    int RowId = Convert.ToInt32(txtId_3.Text);
                                    ///////////////////////////// WillCascadeOnUpdate : EpHesabMoins /////////////////////////
                                    var q6 = db.EpHesabMoin1s.Where(s => s.ColId == RowId && s.SalId == _SalId).ToList();
                                    if (q6.Count > 0)
                                    {
                                        foreach (var item in q6)
                                        {
                                            if (CodeBeforeEdit != _Code)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter).Replace(item.Code.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter), _Code.ToString())
                                                    + item.Code.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));
                                            if (IsActiveBeforeEdit != _IsActive)
                                                item.IsActive = _IsActive;
                                        }
                                    }
                                    //////////////////
                                    var q = db.EpHesabCols.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.GroupId = _GroupId;
                                        q.IsActive = _IsActive;
                                        //q.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                        //q.MahiatHesab = cmbMahiatHesab.Text;
                                        //q.IndexNoeHesab = cmbNoeHesab.SelectedIndex;
                                        //q.NoeHesab = cmbNoeHesab.Text;
                                        q.SharhHesab = _SharhHesab;
                                        q.EpHesabMoin1s = q6;
                                    }
                                    ////////////////////////////////////////////////////
                                    var q2 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(txtGroupCode_3.Text);
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpHesabCol1 = q;

                                        var q3 = db.EpAllCodingHesabdaris.Where(s => s.EpHesabMoin1.ColId == RowId && s.SalId == _SalId).ToList();
                                        if (q3.Count > 0)
                                        {
                                            foreach (var item in q3)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));

                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter).Replace(item.ParentCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter), _Code.ToString())
                                                        + item.ParentCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));
                                                }

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }

                                        }


                                        //////////////////////////////////////////////////////////////////////////// 
                                        var q9 = db.RmsUserBallCodingHesabdaris.Where(s =>
                                                   s.EpAllCodingHesabdari1.Id == RowId
                                                || s.EpAllCodingHesabdari1.EpHesabMoin1.EpHesabCol1.Id == RowId && s.SalId == _SalId).ToList();
                                        if (q9.Count > 0)
                                        {
                                            foreach (var item in q9)
                                            {
                                                if (CodeBeforeEdit != _Code)
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter), _Code.ToString())
                                                    + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));

                                                if (IsActiveBeforeEdit != _IsActive)
                                                    item.IsActive = _IsActive;
                                            }
                                        }
                                        //////////////////////////////////////////////////////////////////////////////////////
                                        if (IsActiveBeforeEdit == false && chkIsActive_3.Checked == true)
                                        {
                                            var T = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId);
                                            var G = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId);
                                            var A = db.EpAllCodingHesabdaris.Where(s => s.Id == _TabaghehId || s.Id == _GroupId && s.SalId == _SalId);
                                            var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _TabaghehId || s.CodingHesabdariId == _GroupId && s.SalId == _SalId);
                                            if (T != null)
                                                T.IsActive = true;
                                            if (G != null)
                                                G.IsActive = true;
                                            foreach (var item in A)
                                                item.IsActive = true;
                                            foreach (var item in U)
                                                item.IsActive = true;
                                        }

                                        db.SaveChanges();
                                        btnCancel_Click(null, null);
                                        FillGridviewCodingHesabdari();

                                        //  XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView3.RowCount > 0)
                                            gridView3.FocusedRowHandle = EditRowIndex;
                                        En = EnumCED.Save;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                                {
                                    int RowId = Convert.ToInt32(txtId_4.Text);

                                    var q = db.EpHesabMoin1s.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.ColId = _ColId;
                                        q.GroupLevelsId = _GroupTafsiliLevelId;
                                        q.GroupLevelsName = cmbGroupTafsiliLevels_4.Text;
                                        q.IsActive = _IsActive;
                                        q.IndexMahiatHesab = cmbMahiatHesab_4.SelectedIndex;
                                        q.MahiatHesab = cmbMahiatHesab_4.Text;
                                        q.SharhHesab = _SharhHesab;
                                        ///////////////
                                        string ActiveSystem = string.Empty;
                                        for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                        {
                                            if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                            {
                                                ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                            }
                                        }
                                        q.SelectedActivesystem = ActiveSystem;
                                        ////////
                                        string GroupTafsili = string.Empty;
                                        for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                        {
                                            if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                            {
                                                GroupTafsili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                            }
                                        }
                                        GroupTafsili += "/";
                                        for (int i = 0; i < chkListBoxLevel2.ItemCount; i++)
                                        {
                                            if (chkListBoxLevel2.GetItemCheckState(i) == CheckState.Checked)
                                            {
                                                GroupTafsili += chkListBoxLevel2.GetDisplayItemValue(i).ToString() + ",";
                                            }
                                        }
                                        GroupTafsili += "/";
                                        for (int i = 0; i < chkListBoxLevel3.ItemCount; i++)
                                        {
                                            if (chkListBoxLevel3.GetItemCheckState(i) == CheckState.Checked)
                                            {
                                                GroupTafsili += chkListBoxLevel3.GetDisplayItemValue(i).ToString() + ",";
                                            }
                                        }

                                        q.SelectedGroupTafsiliLevel1 = GroupTafsili;
                                        ////////////////////////////////////////////////////////////////////////////////
                                        var q1 = db.EpSharhStandardMoins.Where(s => s.MoinId == RowId && s.SalId == _SalId).ToList();
                                        if (q1.Count > 0)
                                        {
                                            db.EpSharhStandardMoins.RemoveRange(q1);
                                        }

                                        List<EpSharhStandardMoin> obj01 = new List<EpSharhStandardMoin>();
                                        for (int i = 0; i < gridView5.RowCount; i++)
                                        {
                                            EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                            obj1.SalId = Convert.ToInt32(lblSalId.Text);
                                            //obj1.Code = db.EpSharhStandardMoins.Any() ? db.EpSharhStandardMoins.Max(s =>s.Code) + 1 : 1;
                                            obj1.Name = gridView5.GetRowCellDisplayText(i, "Name");
                                            //obj1.MoinId = RowId;
                                            //obj1.MoinCode = _Code;
                                            //db.EpSharhStandardMoins.Add(obj1);
                                            obj01.Add(obj1);
                                        }
                                        q.EpSharhStandardMoins = obj01;

                                        /////////////////////////////// متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                        var q10 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                        if (q10 != null)
                                        {
                                            q10.KeyCode = _Code;
                                            q10.ParentCode = Convert.ToInt32(txtColCode_4.Text);
                                            q10.LevelName = _Name;
                                            q10.IsActive = _IsActive;
                                            q10.EpHesabMoin1 = q;

                                            //////////////////
                                            var q3 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId).ToList();
                                            if (q3.Count > 0)
                                            {
                                                db.REpAllCodingHesabdariBEpAllGroupTafsilis.RemoveRange(q3);
                                            }

                                            List<REpAllCodingHesabdariBEpAllGroupTafsili> obj03 = new List<REpAllCodingHesabdariBEpAllGroupTafsili>();
                                            for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                            {
                                                if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                                {
                                                    int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));

                                                    REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                                    obj1.SalId = _SalId;
                                                    obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                                    obj1.LevelNamber = 1;
                                                    obj03.Add(obj1);
                                                }
                                            }
                                            for (int i = 0; i < chkListBoxLevel2.ItemCount; i++)
                                            {
                                                if (chkListBoxLevel2.GetItemCheckState(i) == CheckState.Checked)
                                                {
                                                    int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel2.GetItemValue(i));

                                                    REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                                    obj1.SalId = _SalId;
                                                    obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                                    obj1.LevelNamber = 2;
                                                    obj03.Add(obj1);
                                                }
                                            }
                                            for (int i = 0; i < chkListBoxLevel3.ItemCount; i++)
                                            {
                                                if (chkListBoxLevel3.GetItemCheckState(i) == CheckState.Checked)
                                                {
                                                    int _GroupTafsiliId = Convert.ToInt32(chkListBoxLevel3.GetItemValue(i));

                                                    REpAllCodingHesabdariBEpAllGroupTafsili obj1 = new REpAllCodingHesabdariBEpAllGroupTafsili();
                                                    obj1.SalId = _SalId;
                                                    obj1.AllGroupTafsiliId = _GroupTafsiliId;
                                                    obj1.LevelNamber = 3;
                                                    obj03.Add(obj1);
                                                }
                                            }

                                            q10.REpAllCodingHesabdariBEpAllGroupTafsilis = obj03;

                                            /////////////////////////////////////////////////////////////////////////////////////
                                            var q2 = db.REpAllCodingHesabdariBMsActiveSystems.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId).ToList();
                                            if (q2.Count > 0)
                                            {
                                                db.REpAllCodingHesabdariBMsActiveSystems.RemoveRange(q2);
                                            }

                                            List<REpAllCodingHesabdariBMsActiveSystem> obj02 = new List<REpAllCodingHesabdariBMsActiveSystem>();
                                            for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                            {
                                                if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                                {
                                                    int _ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));

                                                    REpAllCodingHesabdariBMsActiveSystem obj1 = new REpAllCodingHesabdariBMsActiveSystem();
                                                    obj1.SalId = _SalId;
                                                    obj1.ActiveSystemId = _ActiveSystemId;
                                                    //obj1.ActiveSystemCode = db.MsActiveSystems.FirstOrDefault(s =>s.Id == _ActiveSystemId).Code;
                                                    //obj1.MoinId = RowId;
                                                    //obj1.MoinCode = _Code;
                                                    //db.RMsActiveSystemBEpHesabMoins.Add(obj1);
                                                    obj02.Add(obj1);
                                                }
                                            }
                                            q10.REpAllCodingHesabdariBMsActiveSystems = obj02;
                                            /////////////////////////////////////////////////////////////////////////////////////



                                            //var q3 = db.EpAllCodingHesabdaris.Where(s => s.HesabColId == RowId && s.SalId == _SalId).ToList();
                                            //if (q3.Count > 0)
                                            //{
                                            //    foreach (var item in q3)
                                            //    {
                                            //        if (HesabTabaghehIdBeforeEdit != _TabaghehId)
                                            //            item.HesabTabaghehId = _TabaghehId;

                                            //        if (HesabGroupIdBeforeEdit != _HesabGroupId)
                                            //            item.HesabGroupId = _HesabGroupId;

                                            //        if (CodeBeforeEdit != _Code)
                                            //        {
                                            //            item.KeyId = Convert.ToInt32(item.KeyId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter+_HesabMoinCarakter).Replace(item.KeyId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter+_HesabMoinCarakter), _Code.ToString())
                                            //            + item.KeyId.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter));

                                            //            item.ParentId = Convert.ToInt32(item.ParentId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter).Replace(item.ParentId.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter),_Code.ToString())
                                            //                + item.ParentId.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter+ _HesabColCarakter+_HesabMoinCarakter));
                                            //        }

                                            //        if (IsActiveBeforeEdit != _IsActive)
                                            //            item.IsActive = _IsActive;
                                            //    }


                                            /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                            var q9 = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == RowId && s.SalId == _SalId).ToList();

                                            if (q9.Count > 0)
                                            {

                                                foreach (var item in q9)
                                                {

                                                    if (CodeBeforeEdit != _Code)
                                                        item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter).Replace(item.KeyCode.ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter), _Code.ToString())
                                                        + item.KeyCode.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter + _HesabMoin1Carakter));

                                                    if (IsActiveBeforeEdit != _IsActive)
                                                        item.IsActive = _IsActive;
                                                }
                                            }
                                            //////////////////////////////////////////////////////////////////////////////////////
                                            if (IsActiveBeforeEdit == false && chkIsActive_4.Checked == true)
                                            {
                                                var T = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId);
                                                var G = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId);
                                                var C = db.EpHesabCols.FirstOrDefault(s => s.Id == _ColId && s.SalId == _SalId);
                                                var A = db.EpAllCodingHesabdaris.Where(s => s.Id == _TabaghehId || s.Id == _GroupId || s.Id == _ColId && s.SalId == _SalId);
                                                var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _TabaghehId || s.CodingHesabdariId == _GroupId || s.CodingHesabdariId == _ColId && s.SalId == _SalId);
                                                if (T != null)
                                                    T.IsActive = true;
                                                if (G != null)
                                                    G.IsActive = true;
                                                if (C != null)
                                                    C.IsActive = true;
                                                foreach (var item in A)
                                                    item.IsActive = true;
                                                foreach (var item in U)
                                                    item.IsActive = true;
                                            }

                                            db.SaveChanges();
                                        }

                                        btnCancel_Click(null, null);
                                        FillGridviewCodingHesabdari();

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView4.RowCount > 0)
                                            gridView4.FocusedRowHandle = EditRowIndex;
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

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                    {
                        var q = db.EpHesabTabaghehs.Where(s => s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCode = q.Max(s => s.Code);
                            if (MaximumCode != Convert.ToInt32(_HesabTabaghehMaxCode))
                                txtCode_1.Text = (MaximumCode + 1).ToString();
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف" + _HesabTabaghehMaxCode + "حساب طبقه ..." + "\n" + "توجه : نمیتوان بیشتر از" + _HesabTabaghehMaxCode + "حساب طبقه تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode_1.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode_1.Text = _HesabTabaghehMinCode;
                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                    {
                        if (cmbHesabTabagheh_2.EditValue != null)
                        {
                            _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_2.EditValue);
                            var q = db.EpHesabGroups.Where(s => s.TabaghehId == _TabaghehId && s.SalId == _SalId).ToList();
                            if (q.Count > 0)
                            {
                                var MaximumCode = q.Max(s => s.Code);
                                if (MaximumCode.ToString().Substring(_HesabTabaghehCarakter) != _HesabGroupMaxCode)
                                    txtCode_2.Text = (MaximumCode + 1).ToString().Substring(_HesabTabaghehCarakter);
                                else
                                {
                                    XtraMessageBox.Show("اعمال محدودیت تعریف " + _HesabGroupMaxCode + " حساب گروه ..." + "\n" + "توجه : نمیتوان بیشتر از " + _HesabGroupMaxCode + " حساب گروه تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    chkEditCode_2.Checked = true;
                                }
                            }
                            else
                            {
                                txtCode_2.Text = _HesabGroupMinCode;
                            }


                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        if (cmbListHesabGroup_3.EditValue != null)
                        {
                            _GroupId = Convert.ToInt32(cmbListHesabGroup_3.EditValue);

                            var q = db.EpHesabCols.Where(s => s.GroupId == _GroupId && s.SalId == _SalId).ToList();
                            if (q.Count > 0)
                            {
                                var MaximumCod = q.Max(s => s.Code);
                                if (MaximumCod.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter) != _HesabColMaxCode)
                                {
                                    txtCode_3.Text = (MaximumCod + 1).ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter);
                                }
                                else
                                {
                                    XtraMessageBox.Show("اعمال محدودیت تعریف" + _HesabColMaxCode + "حساب کل ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از" + _HesabColMaxCode + "حساب کل تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    chkEditCode_3.Checked = true;
                                }
                            }
                            else
                            {
                                txtCode_3.Text = _HesabColMinCode;

                            }
                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        _ColId = Convert.ToInt32(cmbListHesabCol_4.EditValue);
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpHesabMoin1s.Where(s => s.ColId == _ColId && s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter) != _HesabMoin1MaxCode)
                            {
                                txtCode_4.Text = (MaximumCod + 1).ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                                //btnNewCode.Enabled = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف" + _HesabMoin1MaxCode + "حساب معین ..." + "\n" + "توجه : نمیتوان بیشتر از" + _HesabMoin1MaxCode + "حساب معین تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode_4.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode_4.Text = _HesabMoin1MinCode;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmCodingHesabdari_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            En = EnumCED.None;
            treeList = EnumTreeList.CollapseAll;
            FillGridviewCodingHesabdari();
            btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
            gridView = gridView1;
            btnCreate.Focus();
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.EpTanzimatCodingHesabdaris.FirstOrDefault(s => s.SalId == _SalId);
                    if (q != null)
                    {
                        _HesabTabaghehCarakter = q.HesabTabaghehCarakter;
                        _HesabGroupCarakter = q.HesabGroupCarakter;
                        _HesabColCarakter = q.HesabColCarakter;
                        _HesabMoin1Carakter = q.HesabMoinLevel1Carakter;

                        _HesabTabaghehMinCode = q.HesabTabaghehMinCode;
                        _HesabTabaghehMaxCode = q.HesabTabaghehMaxCode;
                        _HesabGroupMinCode = q.HesabGroupMinCode;
                        _HesabGroupMaxCode = q.HesabGroupMaxCode;
                        _HesabColMinCode = q.HesabColMinCode;
                        _HesabColMaxCode = q.HesabColMaxCode;
                        _HesabMoin1MinCode = q.HesabMoinLevel1MinCode;
                        _HesabMoin1MaxCode = q.HesabMoinLevel1MaxCode;

                        txtCode = txtCode_1;
                        _Carakter = _HesabTabaghehCarakter;
                        txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        txtCode.Properties.Mask.EditMask = _Carakter == 1 ? "0" : "00";
                        txtCode.Properties.MaxLength = _Carakter;

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
            //    labelControl3.Visible = true;
            //}
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

        private void FrmCodingHesabdari_KeyDown(object sender, KeyEventArgs e)
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
            {
                HelpClass1.PrintPreview(gridControl, gridView);
            }
        }

        public void btnDisplyList_Click(object sender, EventArgs e)
        {
            FillGridviewCodingHesabdari();
            //if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
            //{
            //    HelpClass1.ClearControls(panelControl1_2);
            //}
            //else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
            //{
            //    HelpClass1.ClearControls(panelControl2_2);
            //}
            //else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
            //{
            //    HelpClass1.ClearControls(panelControl3_2);
            //}
            //else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Moin)
            //{
            //    HelpClass1.InActiveControls(xtraTabPage1);
            //    HelpClass1.InActiveControls(xtraTabPage2.Controls["xtraTabControl2"]);
            //    HelpClass1.InActiveControls(xtraTabPage3);
            //    HelpClass1.InActiveControls(xtraTabPage4);
            //    HelpClass1.ClearControls(panelControl4_3);
            //    xtraTabControl3.SelectedTabPageIndex = 1;
            //    xtraTabControl2.SelectedTabPageIndex = 0;
            //    chkListBoxLevel1.UnCheckAll();
            //    xtraTabControl2.SelectedTabPageIndex = 1;
            //    chkListBoxLevel2.UnCheckAll();
            //    xtraTabControl2.SelectedTabPageIndex = 2;
            //    chkListBoxLevel3.UnCheckAll();
            //    xtraTabControl3.SelectedTabPageIndex = 2;
            //    chkListBoxActiveSystem.UnCheckAll();
            //    xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;

            //    epSharhStandardMoinsBindingSource.Clear();

            //}
            //else if (xtraTabControl1.SelectedTabPage == xtraTabPage_DerakhtVareh)
            //{
            //    if (treeList == EnumTreeList.CollapseAll)
            //    {
            //        treeListCodingHesabdari.CollapseAll();
            //        treeList = EnumTreeList.ExpandAll;
            //    }
            //    else
            //    {
            //        treeListCodingHesabdari.ExpandAll();
            //        treeList = EnumTreeList.CollapseAll;
            //    }
            //}
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
                gridControl1.Enabled = false;
                HelpClass1.InActiveButtons(panelControl_Button);
                HelpClass1.ClearControls(PanelControl);
                HelpClass1.ActiveControls(PanelControl);
                chkIsActive.Checked = true;
                if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                {
                    btnNewCode_Click(null, null);
                    txtName.Focus();
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                {
                    FillcmbHesabTabagheh();
                    cmbHesabTabagheh_2.Focus();
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                {
                    FillcmbHesabTabagheh();
                    cmbHesabTabagheh_3.Focus();
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                {
                    FillcmbHesabTabagheh();
                    FillListBoxActiveSystem();
                    FillListBoxGroupTafsiliLevels();
                    chkListBoxActiveSystem.Enabled = true;
                    gridControl5.Enabled = true;
                    epSharhStandardMoinsBindingSource.Clear();

                    xtraTabControl3.SelectedTabPageIndex = 1;
                    xtraTabControl2.SelectedTabPageIndex = 0;
                    chkListBoxLevel1.UnCheckAll();
                    xtraTabControl2.SelectedTabPageIndex = 1;
                    chkListBoxLevel2.UnCheckAll();
                    xtraTabControl2.SelectedTabPageIndex = 2;
                    chkListBoxLevel3.UnCheckAll();
                    xtraTabControl3.SelectedTabPageIndex = 2;
                    chkListBoxActiveSystem.CheckAll();
                    _IndexTabControl3 = 0;
                    xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;
                    cmbHesabTabagheh_4.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Visible)
            {
                if (gridView.RowCount > 0)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            _SalId = Convert.ToInt32(lblSalId.Text);
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView.FocusedRowHandle;
                            int RowId = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id").ToString());

                            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                            {
                                if (XtraMessageBox.Show("آیا حساب طبقه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    //var q = db.EpHesabTabagheh.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        //db.EpHesabTabagheh.Remove(q);
                                        db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                            {
                                if (XtraMessageBox.Show("آیا حساب گروه انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                            {
                                if (XtraMessageBox.Show("آیا حساب کل انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                            {
                                if (XtraMessageBox.Show("آیا حساب معین انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    var q8 = db.EpAllCodingHesabdaris.FirstOrDefault(s => s.Id == RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllCodingHesabdaris.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();

                                        xtraTabControl3.SelectedTabPageIndex = 1;
                                        xtraTabControl2.SelectedTabPageIndex = 0;
                                        chkListBoxLevel1.UnCheckAll();
                                        xtraTabControl2.SelectedTabPageIndex = 1;
                                        chkListBoxLevel2.UnCheckAll();
                                        xtraTabControl2.SelectedTabPageIndex = 2;
                                        chkListBoxLevel3.UnCheckAll();
                                        xtraTabControl3.SelectedTabPageIndex = 2;
                                        chkListBoxActiveSystem.UnCheckAll();
                                        xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            btnDisplyList_Click(null, null);
                            if (gridView.RowCount > 0)
                                gridView.FocusedRowHandle = EditRowIndex - 1;
                        }
                        catch (DbUpdateException)
                        {
                            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh
                                || xtraTabControl1.SelectedTabPage == xtraTabPage_Col
                                || xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                            {
                                XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                                    " جهت حذف این حساب در ابتدا بایستی زیر مجموعه های این حساب حذف گردد" +
                                    "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                XtraMessageBox.Show("حذف این حساب مقدور نیست \n" +
                                    " زیرا با حساب معین فوق سند حسابداری صادر گردیده است" +
                                    "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    En = EnumCED.Edit;
                    gridControl.Enabled = false;
                    EditRowIndex = gridView.FocusedRowHandle;
                    HelpClass1.InActiveButtons(panelControl_Button);
                    HelpClass1.ActiveControls(PanelControl);

                    NameBeforeEdit = txtName.Text.Trim();
                    IsActiveBeforeEdit = chkIsActive.Checked;
                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                    {
                        CodeBeforeEdit = Convert.ToInt32(txtCode.Text);
                        txtName.Focus();
                    }

                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                    {
                        FillcmbHesabTabagheh();
                        CodeBeforeEdit = Convert.ToInt32(txtTabaghehCode_2.Text + txtCode_2.Text);
                        TabaghehIdBeforeEdit = Convert.ToInt32(cmbHesabTabagheh_2.EditValue);
                        cmbHesabTabagheh_2.Focus();

                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        FillcmbHesabTabagheh();
                        CodeBeforeEdit = Convert.ToInt32(txtGroupCode_3.Text + txtCode_3.Text);
                        GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup_3.EditValue);
                        cmbHesabTabagheh_3.Focus();
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        chkListBoxActiveSystem.Enabled = true;
                        gridControl5.Enabled = true;
                        cmbGroupTafsiliLevels_4.SelectedIndex = -1;
                        cmbGroupTafsiliLevels_4.SelectedIndex = Convert.ToInt32(gridView4.GetFocusedRowCellValue("GroupLevelsId").ToString());
                        FillcmbHesabTabagheh();
                        FillListBoxGroupTafsiliLevels();
                        FillListBoxActiveSystem();

                        GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup_4.EditValue);
                        ColIdBeforeEdit = Convert.ToInt32(cmbListHesabCol_4.EditValue);
                        CodeBeforeEdit = Convert.ToInt32(txtColCode_4.Text + txtCode_4.Text);
                        cmbHesabTabagheh_4.Focus();
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
                En = EnumCED.Cancel;
                gridControl.Enabled = true;
                HelpClass1.ActiveButtons(panelControl_Button);
                HelpClass1.ClearControls(PanelControl);
                HelpClass1.InActiveControls(PanelControl);
                if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                {
                    chkListBoxActiveSystem.Enabled = false;
                    gridControl5.Enabled = false;
                    chkListBoxLevel1.Enabled = false;
                    chkListBoxLevel2.Enabled = false;
                    chkListBoxLevel3.Enabled = false;
                    xtraTabControl3.SelectedTabPageIndex = 1;
                    xtraTabControl2.SelectedTabPageIndex = 0;
                    chkListBoxLevel1.UnCheckAll();
                    xtraTabControl2.SelectedTabPageIndex = 1;
                    chkListBoxLevel2.UnCheckAll();
                    xtraTabControl2.SelectedTabPageIndex = 2;
                    chkListBoxLevel3.UnCheckAll();
                    xtraTabControl3.SelectedTabPageIndex = 2;
                    chkListBoxActiveSystem.UnCheckAll();
                    xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;

                    epSharhStandardMoinsBindingSource.Clear();
                    //db.Dispose();
                    // epSharhStandardMoinsBindingSource.cle;
                }
                btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = false;
                btnCreate.Focus();
            }
        }

        private void cmbNoeHesab_Enter(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
            {
                if (En == EnumCED.Create)
                {
                    cmbNoeHesab_1.ShowPopup();
                }
            }
        }

        private void cmbNoeHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNoeHesab.Text = (cmbNoeHesab.SelectedIndex == 0 || cmbNoeHesab.SelectedIndex == 2) ? "دائم" : (cmbNoeHesab_1.SelectedIndex == 1) ? "موقت" : ".";
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
                if (En != EnumCED.Edit)
                {
                    if (gridView.RowCount > 0)
                    {
                        _SalId = Convert.ToInt32(lblSalId.Text);
                        txtId.Text = gridView.GetFocusedRowCellValue("Id").ToString();
                        txtName.Text = gridView.GetFocusedRowCellValue("Name").ToString();
                        chkIsActive.Checked = Convert.ToBoolean(gridView.GetFocusedRowCellValue("IsActive"));
                        txtSharh.Text = gridView.GetFocusedRowCellValue("SharhHesab").ToString();

                        if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
                        {
                            txtCode_1.Text = gridView.GetFocusedRowCellValue("Code").ToString();
                            cmbNoeHesab.SelectedIndex = Convert.ToInt32(gridView.GetFocusedRowCellValue("IndexNoeHesab"));
                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                        {
                            cmbHesabTabagheh_2.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("TabaghehId").ToString());
                            txtTabaghehCode_2.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter);
                            txtCode_2.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter);
                            cmbNoeHesab_2.SelectedIndex = new MyContext().EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId).IndexNoeHesab;
                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                        {
                            _GroupId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("GroupId").ToString());
                            _TabaghehId = new MyContext().EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId).TabaghehId;
                            cmbHesabTabagheh_3.EditValue = _TabaghehId;

                            cmbListHesabGroup_3.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("GroupId").ToString()); ;
                            txtGroupCode_3.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter);
                            txtCode_3.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter);
                            cmbNoeHesab_3.SelectedIndex = new MyContext().EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId).IndexNoeHesab;
                        }
                        else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                        {
                            _ColId = Convert.ToInt32(gridView4.GetFocusedRowCellValue("ColId").ToString());
                            _GroupId = new MyContext().EpHesabCols.FirstOrDefault(s => s.Id == _ColId && s.SalId == _SalId).GroupId;
                            _TabaghehId = new MyContext().EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId).TabaghehId;
                            cmbHesabTabagheh_4.EditValue = _TabaghehId;

                            //_ColId = Convert.ToInt32(gridView4.GetFocusedRowCellValue("ColId").ToString());
                            //_GroupId = new MyContext().EpHesabCols.FirstOrDefault(s => s.Id == _ColId && s.SalId == _SalId).GroupId;
                            cmbListHesabGroup_4.EditValue = _GroupId;

                            cmbListHesabCol_4.EditValue = Convert.ToInt32(gridView4.GetFocusedRowCellValue("ColId").ToString());
                            txtColCode_4.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(0, _HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                            txtCode_4.Text = gridView4.GetFocusedRowCellValue("Code").ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);
                            cmbMahiatHesab_4.SelectedIndex = Convert.ToInt32(gridView4.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                            cmbGroupTafsiliLevels_4.SelectedIndex = Convert.ToInt32(gridView4.GetFocusedRowCellValue("GroupLevelsId").ToString());

                            cmbGroupTafsiliLevels_4_SelectedIndexChanged(null, null);
                            FillDataGridSharhStandard();

                            using (var db = new MyContext())
                            {
                                try
                                {
                                    // FillListBoxActiveSystem();
                                    xtraTabControl3.SelectedTabPageIndex = 2;
                                    chkListBoxActiveSystem.CheckAll();
                                    int RowId = Convert.ToInt32(txtId_4.Text);
                                    var q = db.REpAllCodingHesabdariBMsActiveSystems.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId).Select(s => s.ActiveSystemId).ToList();
                                    if (q.Count > 0)
                                    {
                                        if (chkListBoxActiveSystem.DataSource != null)
                                        {
                                            foreach (var item in q)
                                            {
                                                for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                                {
                                                    if (Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i)) == item)
                                                    {
                                                        chkListBoxActiveSystem.SetItemCheckState(i, CheckState.Unchecked);
                                                        i = chkListBoxActiveSystem.ItemCount;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    ////////////////////////////////////////////////////////////////
                                    // FillListBoxGroupTafsiliLevels();
                                    xtraTabControl3.SelectedTabPageIndex = 1;
                                    xtraTabControl2.SelectedTabPageIndex = 0;
                                    chkListBoxLevel1.UnCheckAll();
                                    xtraTabControl2.SelectedTabPageIndex = 1;
                                    chkListBoxLevel2.UnCheckAll();
                                    xtraTabControl2.SelectedTabPageIndex = 2;
                                    chkListBoxLevel3.UnCheckAll();
                                    xtraTabControl2.SelectedTabPageIndex = 0;
                                    xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;

                                    var q1 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId && s.LevelNamber == 1).Select(s => s.AllGroupTafsiliId).ToList();
                                    if (q1.Count > 0)
                                    {
                                        if (chkListBoxLevel1.DataSource != null)
                                        {
                                            foreach (var item in q1)
                                            {
                                                for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                                {
                                                    if (Convert.ToInt32(chkListBoxLevel1.GetItemValue(i)) == item)
                                                    {
                                                        chkListBoxLevel1.SetItemCheckState(i, CheckState.Checked);
                                                        i = chkListBoxLevel1.ItemCount;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    var q2 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId && s.LevelNamber == 2).Select(s => s.AllGroupTafsiliId).ToList();
                                    if (q2.Count > 0)
                                    {
                                        if (chkListBoxLevel2.DataSource != null)
                                        {
                                            foreach (var item in q2)
                                            {
                                                for (int i = 0; i < chkListBoxLevel2.ItemCount; i++)
                                                {
                                                    if (Convert.ToInt32(chkListBoxLevel2.GetItemValue(i)) == item)
                                                    {
                                                        chkListBoxLevel2.SetItemCheckState(i, CheckState.Checked);
                                                        i = chkListBoxLevel2.ItemCount;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    var q3 = db.REpAllCodingHesabdariBEpAllGroupTafsilis.Where(s => s.AllCodingHesabdariId == RowId && s.SalId == _SalId && s.LevelNamber == 3).Select(s => s.AllGroupTafsiliId).ToList();
                                    if (q3.Count > 0)
                                    {
                                        if (chkListBoxLevel3.DataSource != null)
                                        {
                                            foreach (var item in q3)
                                            {
                                                for (int i = 0; i < chkListBoxLevel3.ItemCount; i++)
                                                {
                                                    if (Convert.ToInt32(chkListBoxLevel3.GetItemValue(i)) == item)
                                                    {
                                                        chkListBoxLevel3.SetItemCheckState(i, CheckState.Checked);
                                                        i = chkListBoxLevel3.ItemCount;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                    xtraTabControl3.SelectedTabPageIndex = _IndexTabControl3;
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        btnDelete.Enabled = btnEdit.Enabled = btnLast.Enabled = btnNext.Enabled = btnPreview.Enabled = btnFirst.Enabled = true;
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            FillGridviewCodingHesabdari();
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Tabagheh)
            {
                gridView = gridView1;
                gridControl = gridControl1;
                cmbNoeHesab = cmbNoeHesab_1;
                lblNoeHesab = lblNoeHesab_1;
                txtCode = txtCode_1;
                chkEditCode = chkEditCode_1;
                btnNewCode = btnNewCode_1;
                txtId = txtId_1;
                txtName = txtName_1;
                chkIsActive = chkIsActive_1;
                txtSharh = txtSharhHesab_1;
                PanelControl = panelControl1_2;
                _LevelNamber = 1;
                _Carakter = _HesabTabaghehCarakter;
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
            {
                gridView = gridView2;
                gridControl = gridControl2;
                cmbHesab = cmbHesabTabagheh_2;
                btnReload = btnReloadHesabTabagheh_2;
                cmbNoeHesab = cmbNoeHesab_2;
                lblNoeHesab = lblNoeHesab_2;
                txtCode = txtCode_2;
                txtGroupCode = txtTabaghehCode_2;
                chkEditCode = chkEditCode_2;
                btnNewCode = btnNewCode_2;
                txtId = txtId_2;
                txtName = txtName_2;
                chkIsActive = chkIsActive_2;
                txtSharh = txtSharhHesab_2;
                PanelControl = panelControl2_2;
                _LevelNamber = 2;
                _Carakter = _HesabGroupCarakter;
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
            {
                gridView = gridView3;
                gridControl = gridControl3;
                cmbHesab = cmbListHesabGroup_3;
                lblNoeHesab = lblNoeHesab_3;
                btnReload = btnReloadHesabGroup_3;
                cmbNoeHesab = cmbNoeHesab_3;
                txtCode = txtCode_3;
                txtGroupCode = txtGroupCode_3;
                chkEditCode = chkEditCode_3;
                btnNewCode = btnNewCode_3;
                txtId = txtId_3;
                txtName = txtName_3;
                chkIsActive = chkIsActive_3;
                txtSharh = txtSharhHesab_3;
                PanelControl = panelControl3_2;
                _LevelNamber = 3;
                _Carakter = _HesabColCarakter;
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
            {
                gridView = gridView4;
                gridControl = gridControl4;
                cmbHesab = cmbListHesabCol_4;
                btnReload = btnReloadHesabCol_4;
                cmbMahiatHesab = cmbMahiatHesab_4;
                txtCode = txtCode_4;
                txtGroupCode = txtColCode_4;
                chkEditCode = chkEditCode_4;
                btnNewCode = btnNewCode_4;
                txtId = txtId_4;
                txtName = txtName_4;
                chkIsActive = chkIsActive_4;
                txtSharh = txtSharhHesab_4;
                PanelControl = panelControl4_3;
                _LevelNamber = 4;
                _Carakter = _HesabMoin1Carakter;
                FillListBoxGroupTafsiliLevels();
                FillListBoxActiveSystem();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_DerakhtVareh)
            {
                btnCreate.Enabled = false;
                return;
            }
            txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
            txtCode.Properties.Mask.EditMask = _Carakter == 1 ? "0" : "00";
            txtCode.Properties.MaxLength = _Carakter;
            FillcmbHesabTabagheh();
            btnCreate.Enabled = true;
            btnCreate.Focus();
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnCancel_Click(null, null);
            }
        }

        private void btnReloadHesabTabagheh_Click(object sender, EventArgs e)
        {
            FillcmbHesabTabagheh();
        }

        private void btnReloadHesabGroup_Click(object sender, EventArgs e)
        {
            FillcmbHesabGroup();
        }

        private void btnReloadHesabCol_Click(object sender, EventArgs e)
        {
            FillcmbHesabCol();
        }

        private void cmbHesabTabagheh_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
                    {
                        _TabaghehId = Convert.ToInt32(cmbHesabTabagheh_2.EditValue);
                        var q = db.EpHesabTabaghehs.FirstOrDefault(s => s.Id == _TabaghehId && s.SalId == _SalId);
                        if (q != null)
                        {
                            txtTabaghehCode_2.Text = q.Code.ToString();
                            cmbNoeHesab_2.SelectedIndex = q.IndexNoeHesab;
                            if (En == EnumCED.Edit)
                                if (_TabaghehId != TabaghehIdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode_2.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter);

                            else
                                btnNewCode_Click(null, null);
                        }
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        FillcmbHesabGroup();
                        cmbListHesabGroup_3.EditValue = 0;
                        txtGroupCode_3.Text = txtCode_3.Text = string.Empty;
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        FillcmbHesabGroup();
                        cmbListHesabGroup_4.EditValue = 0;
                        txtColCode_4.Text = txtCode_4.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);

                    if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
                    {
                        _GroupId = Convert.ToInt32(cmbListHesabGroup_3.EditValue);
                        var q = db.EpHesabGroups.FirstOrDefault(s => s.Id == _GroupId && s.SalId == _SalId);
                        if (q != null)
                        {
                            txtGroupCode_3.Text = q.Code.ToString();
                            cmbNoeHesab_3.SelectedIndex = q.EpHesabTabagheh1.IndexNoeHesab;
                            if (En == EnumCED.Edit)
                                if (_GroupId != GroupIdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode_3.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter);

                            else
                                btnNewCode_Click(null, null);
                        }

                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
                    {
                        FillcmbHesabCol();
                        cmbListHesabCol_4.EditValue = 0;
                        txtColCode_4.Text = txtCode_4.Text = string.Empty;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbListHesabCol_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _ColId = Convert.ToInt32(cmbListHesabCol_4.EditValue);
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpHesabCols.FirstOrDefault(s => s.Id == _ColId && s.SalId == _SalId);
                    if (q != null)
                    {
                        txtColCode_4.Text = q.Code.ToString();
                        if (En == EnumCED.Edit)
                            if (_ColId != ColIdBeforeEdit)
                            {
                                btnNewCode_Click(null, null);
                            }
                            else
                                txtCode_4.Text = CodeBeforeEdit.ToString().Substring(_HesabTabaghehCarakter + _HesabGroupCarakter + _HesabColCarakter);

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

        private void cmbHesabTabagheh_Enter(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Group)
            {
                if (En == EnumCED.Create)
                {
                    cmbHesabTabagheh_2.ShowPopup();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
            {
                if (En == EnumCED.Create)
                {
                    cmbHesabTabagheh_3.ShowPopup();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
            {
                if (En == EnumCED.Create)
                {
                    cmbHesabTabagheh_4.ShowPopup();
                }
            }
        }

        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_Col)
            {
                if (En == EnumCED.Create)
                {
                    cmbListHesabGroup_3.ShowPopup();
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_MoinLevel1)
            {
                if (En == EnumCED.Create)
                {
                    cmbListHesabGroup_4.ShowPopup();
                }
            }
        }

        private void cmbListHesabCol_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbListHesabCol_4.ShowPopup();
            }
        }

        private void cmbMahiatHesab_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbMahiatHesab_4.ShowPopup();
            }
        }

        private void FrmHesabMoin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (db1 != null)
                db1.Dispose();

        }

        private void xtraTabControl3_MouseClick(object sender, MouseEventArgs e)
        {
            _IndexTabControl3 = xtraTabControl3.SelectedTabPageIndex;

        }

        private void cmbGroupTafsiliLevels_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (En == EnumCED.Edit || En == EnumCED.Create)
            {
                chkListBoxLevel1.Enabled = true;
                chkListBoxLevel2.Enabled = true;
                chkListBoxLevel3.Enabled = true;
                if (cmbGroupTafsiliLevels_4.SelectedIndex == 0)
                {
                    chkListBoxLevel1.Enabled = false;
                    chkListBoxLevel2.Enabled = false;
                    chkListBoxLevel3.Enabled = false;
                }
                else if (cmbGroupTafsiliLevels_4.SelectedIndex == 1)
                {
                    chkListBoxLevel1.Enabled = true;
                    chkListBoxLevel2.Enabled = false;
                    chkListBoxLevel3.Enabled = false;
                }
                else if (cmbGroupTafsiliLevels_4.SelectedIndex == 2)
                {
                    chkListBoxLevel1.Enabled = true;
                    chkListBoxLevel2.Enabled = true;
                    chkListBoxLevel3.Enabled = false;
                }
                else if (cmbGroupTafsiliLevels_4.SelectedIndex == 3)
                {
                    chkListBoxLevel1.Enabled = true;
                    chkListBoxLevel2.Enabled = true;
                    chkListBoxLevel3.Enabled = true;
                }
            }
        }

        private void cmbGroupTafsiliLevels_4_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGroupTafsiliLevels_4.ShowPopup();
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

        private void treeListCodingHesabdari_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "IsActive") return;
            if (e.Node.GetDisplayText(colIsActive1) == "انتخاب نشده")
                e.Appearance.BackColor = Color.Pink;

        }

        private void xtraTabControl3_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl3.SelectedTabPageIndex == 1)
            {
                xtraTabControl2.SelectedTabPageIndex = 0;
            }
        }

        private void chkListBoxLevel_GetItemEnabled(object sender, DevExpress.XtraEditors.Controls.GetItemEnabledEventArgs e)
        {
            CheckedListBoxControl control = sender as CheckedListBoxControl;
            //bool isDiscontinued = (bool)((control.DataSource as BindingSource)[e.Index] as
            //    DataRowView)["سایر"];
            //if (e.Index==3)
            //    e.Enabled = false;
            for (int i = 0; i < control.ItemCount; i++)
            {
                if (control.GetDisplayItemValue(i).ToString() == "سایر")
                {
                    if (e.Index == i)
                    {
                        e.Enabled = false;
                        control.SetItemChecked(i, true);
                        //i = control.ItemCount;
                        return;
                    }
                }
            }
        }

    }
}
