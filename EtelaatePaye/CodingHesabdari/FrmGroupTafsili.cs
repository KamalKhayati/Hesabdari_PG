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
using DevExpress.XtraGrid.Views.Grid;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmGroupTafsili : DevExpress.XtraEditors.XtraForm
    {
        public FrmGroupTafsili()
        {
            InitializeComponent();
        }

        public EnumCED En = EnumCED.Cancel;
        public bool IsActiveList = true;
        public void FillGridviewGroupTafsili()
        {
            btnDelete.Enabled = btnEdit.Enabled = false;
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                using (var dataContext = new MyContext())
                {
                    try
                    {
                        if (IsActiveList == true)
                        {
                            var q1 = dataContext.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                                else
                                    epGroupTafsiliLevel1sBindingSource.DataSource = null;
                            }
                            gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
                            //gridView1.Appearance.Row.ForeColor = Color.Black;
                            HelpClass1.ClearControls(panelControl1_2);
                            //else
                            //{
                            //    int _UserId = Convert.ToInt32(lblUserId.Text);
                            //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                            //    if (q1.Count > 0)
                            //    {
                            //        if (q2.Count > 0)
                            //        {
                            //            q2.ForEach(item3 =>
                            //            {
                            //                q1.Remove(dataContext.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == item3));
                            //            });
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //        else
                            //        {
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //    }
                            //    else
                            //        epGroupTafsiliLevel1sBindingSource.DataSource = null;
                            //}
                        }
                        else
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupTafsiliLevel1s.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    epGroupTafsiliLevel1sBindingSource.DataSource = q;
                                else
                                    epGroupTafsiliLevel1sBindingSource.DataSource = null;
                            }
                            else
                                epGroupTafsiliLevel1sBindingSource.DataSource = null;

                            gridView1.Appearance.HeaderPanel.ForeColor = Color.Red;
                            //gridView1.Appearance.Row.ForeColor = Color.Red;
                            HelpClass1.ClearControls(panelControl1_2);
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                using (var dataContext = new MyContext())
                {
                    try
                    {
                        if (IsActiveList == true)
                        {
                            var q1 = dataContext.EpGroupTafsiliLevel2s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    epGroupTafsiliLevel2sBindingSource.DataSource = q1;
                                else
                                    epGroupTafsiliLevel2sBindingSource.DataSource = null;
                            }
                            gridView2.Appearance.HeaderPanel.ForeColor = Color.Black;
                            //gridView2.Appearance.Row.ForeColor = Color.Black;
                            HelpClass1.ClearControls(panelControl2_2);
                            //else
                            //{
                            //    int _UserId = Convert.ToInt32(lblUserId.Text);
                            //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                            //    if (q1.Count > 0)
                            //    {
                            //        if (q2.Count > 0)
                            //        {
                            //            q2.ForEach(item3 =>
                            //            {
                            //                q1.Remove(dataContext.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == item3));
                            //            });
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //        else
                            //        {
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //    }
                            //    else
                            //        epGroupTafsiliLevel1sBindingSource.DataSource = null;
                            //}
                        }
                        else
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupTafsiliLevel2s.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    epGroupTafsiliLevel2sBindingSource.DataSource = q;
                                else
                                    epGroupTafsiliLevel2sBindingSource.DataSource = null;
                            }
                            else
                                epGroupTafsiliLevel2sBindingSource.DataSource = null;

                            gridView2.Appearance.HeaderPanel.ForeColor = Color.Red;
                            //gridView2.Appearance.Row.ForeColor = Color.Red;
                            HelpClass1.ClearControls(panelControl2_2);
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                using (var dataContext = new MyContext())
                {
                    try
                    {
                        if (IsActiveList == true)
                        {
                            var q1 = dataContext.EpGroupTafsiliLevel3s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                            if (lblUserId.Text == "1")
                            {
                                if (q1.Count > 0)
                                    epGroupTafsiliLevel3sBindingSource.DataSource = q1;
                                else
                                    epGroupTafsiliLevel3sBindingSource.DataSource = null;
                            }
                            gridView3.Appearance.HeaderPanel.ForeColor = Color.Black;
                            //gridView3.Appearance.Row.ForeColor = Color.Black;
                            HelpClass1.ClearControls(panelControl3_2);
                            //else
                            //{
                            //    int _UserId = Convert.ToInt32(lblUserId.Text);
                            //    var q2 = dataContext.RmsUserBallCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                            //    if (q1.Count > 0)
                            //    {
                            //        if (q2.Count > 0)
                            //        {
                            //            q2.ForEach(item3 =>
                            //            {
                            //                q1.Remove(dataContext.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == item3));
                            //            });
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //        else
                            //        {
                            //            epGroupTafsiliLevel1sBindingSource.DataSource = q1;
                            //        }
                            //    }
                            //    else
                            //        epGroupTafsiliLevel1sBindingSource.DataSource = null;
                            //}
                        }
                        else
                        {
                            if (lblUserId.Text == "1")
                            {
                                var q = dataContext.EpGroupTafsiliLevel3s.Where(s => s.IsActive == false && s.SalId == _SalId).OrderBy(s => s.Code).ToList();
                                if (q.Count > 0)
                                    epGroupTafsiliLevel3sBindingSource.DataSource = q;
                                else
                                    epGroupTafsiliLevel3sBindingSource.DataSource = null;
                            }
                            else
                                epGroupTafsiliLevel3sBindingSource.DataSource = null;

                            gridView3.Appearance.HeaderPanel.ForeColor = Color.Red;
                            //gridView3.Appearance.Row.ForeColor = Color.Red;
                            HelpClass1.ClearControls(panelControl3_2);
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

        public void FillcmbGruopLevel1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafsiliLevel1s.Any())
                    {
                        //int _SalId = Convert.ToInt32(lblSalId.Text);
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.IsActive == true && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epGroupTafsiliLevel1sBindingSource1.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafsiliLevel1s.Where(s => s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epGroupTafsiliLevel1sBindingSource1.DataSource = db.EpGroupTafsiliLevel1s.Local.ToBindingList();
                        }

                        //if (En != EnumCED.Edit)
                        //    cmbGruopLevel1_2.EditValue = 0;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillcmbGruopLevel2()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafsiliLevel2s.Any())
                    {
                        //int _SalId = Convert.ToInt32(lblSalId.Text);
                        _Level1Id = Convert.ToInt32(cmbGruopLevel1_3.EditValue);
                        if (IsActiveList == true)
                        {
                            db.EpGroupTafsiliLevel2s.Where(s => s.IsActive == true && s.Level1Id == _Level1Id && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epGroupTafsiliLevel2sBindingSource.DataSource = db.EpGroupTafsiliLevel2s.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpGroupTafsiliLevel2s.Where(s => s.Level1Id == _Level1Id && s.SalId == _SalId).OrderBy(s => s.Code).Load();
                            epGroupTafsiliLevel2sBindingSource.DataSource = db.EpGroupTafsiliLevel2s.Local.ToBindingList();
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

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.EpGroupTafsiliLevel1s.Where(s => s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString() != _GroupTafsiliLevel1MaxCode)
                                txtCode_1.Text = (MaximumCod + 1).ToString();
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف 90 حساب گروه تفصیلی در سطح 1 ..." + "\n" + "توجه : نمیتوان بیشتر از 90 حساب گروه تفصیلی در سطح 1 تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode_1.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode_1.Text = _GroupTafsiliLevel1MinCode;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _Level1Id = Convert.ToInt32(cmbGruopLevel1_2.EditValue);
                        var q = db.EpGroupTafsiliLevel2s.Where(s => s.Level1Id == _Level1Id && s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString().Substring(_GroupTafsiliLevel1Carakter) != _GroupTafsiliLevel2MaxCode)
                                txtCode_2.Text = (MaximumCod + 1).ToString().Substring(_GroupTafsiliLevel1Carakter);
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف " + _GroupTafsiliLevel2MaxCode + " حساب گروه تفصیلی در سطح 2 ..." + "\n" + "توجه : نمیتوان بیشتر از " + _GroupTafsiliLevel2MaxCode + " حساب گروه تفصیلی در سطح 2 تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode_2.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode_2.Text = _GroupTafsiliLevel2MinCode;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        _Level2Id = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                        var q = db.EpGroupTafsiliLevel3s.Where(s => s.Level2Id == _Level2Id && s.SalId == _SalId).ToList();
                        if (q.Count > 0)
                        {
                            var MaximumCod = q.Max(s => s.Code);
                            if (MaximumCod.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter) != _GroupTafsiliLevel3MaxCode)
                                txtCode_3.Text = (MaximumCod + 1).ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);
                            else
                            {
                                XtraMessageBox.Show("اعمال محدودیت تعریف " + _GroupTafsiliLevel3MaxCode + " حساب گروه تفصیلی در سطح 3 ..." + "\n" + "توجه : نمیتوان بیشتر از " + _GroupTafsiliLevel3MaxCode + " حساب گروه تفصیلی در سطح 3 تعریف کرد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                chkEditCode_3.Checked = true;
                            }
                        }
                        else
                        {
                            txtCode_3.Text = _GroupTafsiliLevel3MinCode;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit = true;
        int Level1IdBeforeEdit = 0;
        int Level2IdBeforeEdit = 0;
        int _SalId = 0;
        int _GroupTafsiliLevel1Carakter = 0;
        int _GroupTafsiliLevel2Carakter = 0;
        int _GroupTafsiliLevel3Carakter = 0;
        int _CodeTafsiliCarakter = 0;
        string _GroupTafsiliLevel1MinCode = "";
        string _GroupTafsiliLevel1MaxCode = "";
        string _GroupTafsiliLevel2MinCode = "";
        string _GroupTafsiliLevel2MaxCode = "";
        string _GroupTafsiliLevel3MinCode = "";
        string _GroupTafsiliLevel3MaxCode = "";
        string _CodeTafsiliMinCode = "";
        string _CodeTafsiliMaxCode = "";
        private void FrmGroupTafsili_Load(object sender, EventArgs e)
        {
            _SalId = Convert.ToInt32(lblSalId.Text);
            FillGridviewGroupTafsili();
            btnCreate.Focus();
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

                        _GroupTafsiliLevel1MinCode = q.GroupTafsiliLevel1MinCode;
                        _GroupTafsiliLevel1MaxCode = q.GroupTafsiliLevel1MaxCode;
                        _GroupTafsiliLevel2MinCode = q.GroupTafsiliLevel2MinCode;
                        _GroupTafsiliLevel2MaxCode = q.GroupTafsiliLevel2MaxCode;
                        _GroupTafsiliLevel3MinCode = q.GroupTafsiliLevel3MinCode;
                        _GroupTafsiliLevel3MaxCode = q.GroupTafsiliLevel3MaxCode;
                        _CodeTafsiliMinCode = q.CodeTafsiliMinCode;
                        _CodeTafsiliMaxCode = q.CodeTafsiliMaxCode;

                        txtCode_1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                        txtCode_1.Properties.Mask.EditMask = "00";
                        txtCode_1.Properties.MaxLength = _GroupTafsiliLevel1Carakter;

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

        string _Name = "";
        int _Code = 0;
        int _CodeLevel = 0;
        bool _IsActive = true;
        string _SharhHesab = "";
        int _StartCode = 0;
        int _EndCode = 0;
        int _Level1Id = 0;
        int _Level2Id = 0;
        int _LevelNamber = 0;
        private bool TextEditValidation()
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                _Name = txtName_1.Text.Trim();
                _Code = Convert.ToInt32(txtCode_1.Text);
                _IsActive = chkIsActive_1.Checked;
                _SharhHesab = txtSharhHesab_1.Text;
                _StartCode = Convert.ToInt32(txtStartCode_1.Text);
                _EndCode = Convert.ToInt32(txtEndCode_1.Text);
                _LevelNamber = 1;
                ///////////////// اعتبار سنجی کد ////////////////////////////////////
                if (string.IsNullOrEmpty(_Code.ToString()))
                {
                    XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (_Code < Convert.ToInt32(_GroupTafsiliLevel1MinCode) || _Code > Convert.ToInt32(_GroupTafsiliLevel1MaxCode))
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی از " + _GroupTafsiliLevel1MinCode + " تا " + _GroupTafsiliLevel1MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode_1.Focus();
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
                                if (db.EpGroupTafsiliLevel1s.Any())
                                {
                                    var q1 = db.EpGroupTafsiliLevel1s.Where(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1.Any())
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_1.Text);
                                var q1 = db.EpGroupTafsiliLevel1s.Where(s => s.Id != _RowId && s.Code == _Code && s.SalId == _SalId);
                                //var q2 = db.REpHesabMoinBEpGroupTafsiliLevel1s.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                //var q3 = db.EpAllHesabTafsilis.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                //if (q2 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با حساب معین ارتباط دارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                //if (q3 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با گروه فوق ، حساب تفصیلی تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_1.Text = CodeBeforeEdit;
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

                //////////////// اعتبار سنجی تکس باکس///////////////////////////////

                if (string.IsNullOrEmpty(_Name) || _Name == "0")
                {
                    XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                if (db.EpGroupTafsiliLevel1s.Any())
                                {
                                    var q2 = db.EpGroupTafsiliLevel1s.Where(s => s.Name == _Name && s.SalId == _SalId);
                                    if (q2.Any())
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_1.Text);
                                var q2 = db.EpGroupTafsiliLevel1s.Where(s => s.Id != _RowId && s.Name == _Name && s.SalId == _SalId);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                _Name = txtName_2.Text.Trim();
                _Code = Convert.ToInt32(txtCodeLevel1.Text + txtCode_2.Text);
                _CodeLevel = Convert.ToInt32(txtCodeLevel1.Text);
                _IsActive = chkIsActive_2.Checked;
                _SharhHesab = txtSharhHesab_2.Text;
                _StartCode = Convert.ToInt32(txtStartCode_2.Text);
                _EndCode = Convert.ToInt32(txtEndCode_2.Text);
                _Level1Id = Convert.ToInt32(cmbGruopLevel1_2.EditValue);
                _LevelNamber = 2;
                ///////////////// اعتبار سنجی کد ////////////////////////////////////
                if (string.IsNullOrEmpty(txtCode_2.Text) || string.IsNullOrEmpty(_CodeLevel.ToString()))
                {
                    XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (Convert.ToInt32(txtCode_2.Text) < Convert.ToInt32(_GroupTafsiliLevel2MinCode) || Convert.ToInt32(txtCode_2.Text) > Convert.ToInt32(_GroupTafsiliLevel2MaxCode))
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی از " + _GroupTafsiliLevel2MinCode + " تا " + _GroupTafsiliLevel2MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode_2.Focus();
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
                                if (db.EpGroupTafsiliLevel2s.Any())
                                {
                                    var q1 = db.EpGroupTafsiliLevel2s.Where(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1.Any())
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_2.Text);
                                var q1 = db.EpGroupTafsiliLevel2s.Where(s => s.Id != _RowId && s.Code == _Code && s.SalId == _SalId);
                                //var q2 = db.REpHesabMoinBEpGroupTafsiliLevel2s.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                //var q3 = db.EpAllHesabTafsilis.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                //if (q2 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با حساب معین ارتباط دارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                //if (q3 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با گروه فوق ، حساب تفصیلی تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_2.Text = CodeBeforeEdit.Substring(_GroupTafsiliLevel1Carakter);
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

                //////////////// اعتبار سنجی تکس باکس///////////////////////////////

                if (string.IsNullOrEmpty(_Name) || _Name == "0")
                {
                    XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                if (db.EpGroupTafsiliLevel2s.Any())
                                {
                                    var q2 = db.EpGroupTafsiliLevel2s.Where(s => s.Name == _Name && s.SalId == _SalId);
                                    if (q2.Any())
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_2.Text);
                                var q2 = db.EpGroupTafsiliLevel2s.Where(s => s.Id != _RowId && s.Name == _Name && s.SalId == _SalId);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                _Name = txtName_3.Text.Trim();
                _Code = Convert.ToInt32(txtCodeLevel2.Text + txtCode_3.Text);
                _CodeLevel = Convert.ToInt32(txtCodeLevel2.Text);
                _IsActive = chkIsActive_3.Checked;
                _SharhHesab = txtSharhHesab_3.Text;
                _StartCode = Convert.ToInt32(txtStartCode_3.Text);
                _EndCode = Convert.ToInt32(txtEndCode_3.Text);
                _Level1Id = Convert.ToInt32(cmbGruopLevel1_3.EditValue);
                _Level2Id = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                _LevelNamber = 3;
                ///////////////// اعتبار سنجی کد ////////////////////////////////////
                if (string.IsNullOrEmpty(txtCode_3.Text) || string.IsNullOrEmpty(_CodeLevel.ToString()))
                {
                    XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (Convert.ToInt32(txtCode_3.Text) < Convert.ToInt32(_GroupTafsiliLevel3MinCode) || Convert.ToInt32(txtCode_3.Text) > Convert.ToInt32(_GroupTafsiliLevel3MaxCode))
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی از " + _GroupTafsiliLevel3MinCode + " تا " + _GroupTafsiliLevel3MaxCode + " باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode_3.Focus();
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
                                if (db.EpGroupTafsiliLevel3s.Any())
                                {
                                    var q1 = db.EpGroupTafsiliLevel3s.Where(s => s.Code == _Code && s.SalId == _SalId);
                                    if (q1.Any())
                                    {
                                        XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        btnNewCode_Click(null, null);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_3.Text);
                                var q1 = db.EpGroupTafsiliLevel3s.Where(s => s.Id != _RowId && s.Code == _Code && s.SalId == _SalId);
                                //var q2 = db.REpHesabMoinBEpGroupTafsiliLevel1s.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                // var q3 = db.EpAllHesabTafsilis.FirstOrDefault(s => s.GroupTafsiliId == _RowId);
                                //if (q2 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با حساب معین ارتباط دارد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                //if (q3 != null && txtCode_1.Text != CodeBeforeEdit)
                                //{
                                //    XtraMessageBox.Show("کد گروه تفصیلی فوق قابل ویرایش نیست زیرا با گروه فوق ، حساب تفصیلی تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    txtCode_1.Text = CodeBeforeEdit;
                                //    return false;
                                //}
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtCode_3.Text = CodeBeforeEdit.Substring(_GroupTafsiliLevel1Carakter+_GroupTafsiliLevel2Carakter);
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

                //////////////// اعتبار سنجی تکس باکس///////////////////////////////

                if (string.IsNullOrEmpty(_Name) || _Name == "0")
                {
                    XtraMessageBox.Show("لطفاً نام حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                if (db.EpGroupTafsiliLevel3s.Any())
                                {
                                    var q2 = db.EpGroupTafsiliLevel3s.Where(s => s.Name == _Name && s.SalId == _SalId);
                                    if (q2.Any())
                                    {
                                        XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            else if (En == EnumCED.Edit)
                            {
                                int _RowId = Convert.ToInt32(txtId_3.Text);
                                var q2 = db.EpGroupTafsiliLevel3s.Where(s => s.Id != _RowId && s.Name == _Name && s.SalId == _SalId);
                                if (q2.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            }

            return true;
        }

        private void FrmGroupTafsili_KeyDown(object sender, KeyEventArgs e)
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
                btnDisplyActiveList_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnDisplyNotActiveList_Click(sender, null);
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                btnNewCode_1.Enabled = txtCode_1.Enabled = chkEditCode_1.Checked ? true : false;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                btnNewCode_2.Enabled = txtCode_2.Enabled = chkEditCode_2.Checked ? true : false;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                btnNewCode_3.Enabled = txtCode_3.Enabled = chkEditCode_3.Checked ? true : false;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                HelpClass1.MoveLast(gridView1);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                HelpClass1.MoveLast(gridView2);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                HelpClass1.MoveLast(gridView3);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                HelpClass1.MoveNext(gridView1);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                HelpClass1.MoveNext(gridView2);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                HelpClass1.MoveNext(gridView3);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                HelpClass1.MovePrev(gridView1);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                HelpClass1.MovePrev(gridView2);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                HelpClass1.MovePrev(gridView3);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                HelpClass1.MoveFirst(gridView1);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                HelpClass1.MoveFirst(gridView2);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                HelpClass1.MoveFirst(gridView3);
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (btnPrintPreview.Visible)
                    HelpClass1.PrintPreview(gridControl1, gridView1);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (btnPrintPreview.Visible)
                    HelpClass1.PrintPreview(gridControl2, gridView2);
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (btnPrintPreview.Visible)
                    HelpClass1.PrintPreview(gridControl3, gridView3);
            }
        }

        public void btnDisplyActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = true;
            FillGridviewGroupTafsili();
        }

        public void btnDisplyNotActiveList_Click(object sender, EventArgs e)
        {
            IsActiveList = false;
            FillGridviewGroupTafsili();
            FillcmbGruopLevel1();
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (btnCreate.Visible)
                {
                    En = EnumCED.Create;
                    gridControl1.Enabled = false;
                    HelpClass1.InActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl1_2);
                    HelpClass1.ActiveControls(panelControl1_2);
                    // txtCode.ReadOnly = true;
                    // xtraTabControl1.SelectedTabPageIndex = 0;
                    btnNewCode_Click(null, null);
                    chkEditCode_1.Checked = false;
                    chkIsActive_1.Checked = true;
                    txtName_1.Focus();
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (btnCreate.Visible)
                {
                    En = EnumCED.Create;
                    gridControl2.Enabled = false;
                    HelpClass1.InActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl2_2);
                    HelpClass1.ActiveControls(panelControl2_2);
                    // txtCode.ReadOnly = true;
                    // xtraTabControl1.SelectedTabPageIndex = 0;
                    //btnNewCode_Click(null, null);
                    chkEditCode_2.Checked = false;
                    chkIsActive_2.Checked = true;
                    cmbGruopLevel1_2.Focus();
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (btnCreate.Visible)
                {
                    En = EnumCED.Create;
                    gridControl3.Enabled = false;
                    HelpClass1.InActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl3_2);
                    HelpClass1.ActiveControls(panelControl3_2);
                    // txtCode.ReadOnly = true;
                    // xtraTabControl1.SelectedTabPageIndex = 0;
                    //btnNewCode_Click(null, null);
                    chkEditCode_3.Checked = false;
                    chkIsActive_3.Checked = true;
                    cmbGruopLevel1_3.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (btnDelete.Visible)
                {
                    if (gridView1.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView1.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int _RowId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                                    //var q = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    var q8 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllGroupTafsilis.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();


                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView1.RowCount > 0)
                                            gridView1.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl1_2);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این گروه تفضیلی مقدور نیست \n" +
                                        " جهت حذف حساب گروه تفضیلی فوق در ابتدا بایستی کلیه ارتباط های این حساب با\n" +
                                        " حسابهای معین ، گروه تفضیلی سطح 2 و 3 و حسابهای تفضیلی حذف گردد" +
                                        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (btnDelete.Visible)
                {
                    if (gridView2.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView2.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int _RowId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Id").ToString());
                                    // var q = db.EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _RowId);
                                    var q8 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllGroupTafsilis.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();


                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl2_2);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این گروه تفضیلی مقدور نیست \n" +
                                        " جهت حذف حساب گروه تفضیلی فوق در ابتدا بایستی کلیه ارتباط های این حساب با\n" +
                                        " حسابهای معین ، گروه تفضیلی سطح 3 و حسابهای تفضیلی حذف گردد" +
                                        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (btnDelete.Visible)
                {
                    if (gridView3.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("آیا گروه تفضیلی انتخابی حذف گردد؟", "پیغام حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            IsActiveBeforeEdit = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                            EditRowIndex = gridView3.FocusedRowHandle;
                            using (var db = new MyContext())
                            {
                                try
                                {
                                    int _RowId = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Id").ToString());
                                    // var q = db.EpGroupTafsiliLevel3s.FirstOrDefault(s => s.Id == _RowId);
                                    var q8 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q8 != null)
                                    {
                                        db.EpAllGroupTafsilis.Remove(q8);
                                        /////////////////////////////////////////////////////////////////////////////
                                        db.SaveChanges();


                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);
                                        // XtraMessageBox.Show("عملیات حذف با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView3.RowCount > 0)
                                            gridView3.FocusedRowHandle = EditRowIndex - 1;
                                        HelpClass1.ClearControls(panelControl3_2);
                                    }
                                    else
                                        XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (DbUpdateException)
                                {
                                    XtraMessageBox.Show("حذف این گروه تفضیلی مقدور نیست \n" +
                                        " جهت حذف حساب گروه تفضیلی فوق در ابتدا بایستی کلیه ارتباط های این حساب با\n" +
                                        " حسابهای معین و حسابهای تفضیلی حذف گردد" +
                                        "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        public int EditRowIndex = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (btnEdit.Visible)
                {
                    if (gridView1.RowCount > 0)
                    {
                        gridControl1.Enabled = false;
                        EditRowIndex = gridView1.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl);
                        HelpClass1.ActiveControls(panelControl1_2);


                        txtId_1.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                        txtCode_1.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                        txtName_1.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                        chkIsActive_1.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab_1.Text = gridView1.GetFocusedRowCellValue("SharhHesab") != null ? gridView1.GetFocusedRowCellValue("SharhHesab").ToString() : "";

                        CodeBeforeEdit = txtCode_1.Text;
                        NameBeforeEdit = txtName_1.Text.Trim();
                        IsActiveBeforeEdit = chkIsActive_1.Checked;
                        //if (txtCode.Text == "9")
                        //    btnNewCode.Enabled = false;
                        chkEditCode_1.Checked = false;
                        txtName_1.Focus();
                    }

                }

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (btnEdit.Visible)
                {
                    if (gridView2.RowCount > 0)
                    {
                        gridControl2.Enabled = false;
                        EditRowIndex = gridView2.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl);
                        HelpClass1.ActiveControls(panelControl2_2);
                        //FillcmbGruopLevel1();

                        cmbGruopLevel1_2.EditValue = gridView2.GetFocusedRowCellValue("Level1Id").ToString();
                        txtId_2.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
                        txtCode_2.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(_GroupTafsiliLevel1Carakter);
                        txtCodeLevel1.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(0, _GroupTafsiliLevel1Carakter);
                        txtName_2.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                        chkIsActive_2.Checked = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab_2.Text = gridView2.GetFocusedRowCellValue("SharhHesab") != null ? gridView2.GetFocusedRowCellValue("SharhHesab").ToString() : "";

                        CodeBeforeEdit = txtCodeLevel1.Text + txtCode_2.Text;
                        NameBeforeEdit = txtName_2.Text.Trim();
                        IsActiveBeforeEdit = chkIsActive_2.Checked;
                        Level1IdBeforeEdit = Convert.ToInt32(cmbGruopLevel1_2.EditValue);
                        //if (txtCode.Text == "9")
                        //    btnNewCode.Enabled = false;
                        chkEditCode_2.Checked = false;
                        cmbGruopLevel1_2.Focus();
                    }

                }

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (btnEdit.Visible)
                {
                    if (gridView3.RowCount > 0)
                    {
                        gridControl3.Enabled = false;
                        EditRowIndex = gridView3.FocusedRowHandle;
                        En = EnumCED.Edit;
                        HelpClass1.InActiveButtons(panelControl);
                        HelpClass1.ActiveControls(panelControl3_2);
                        //FillcmbGruopLevel1();
                        _Level2Id = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Level2Id").ToString());
                        cmbGruopLevel1_3.EditValue = new MyContext().EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _Level2Id && s.SalId == _SalId).Level1Id;
                        cmbGruopLevel2_3.EditValue = gridView3.GetFocusedRowCellValue("Level2Id").ToString();
                        txtId_3.Text = gridView3.GetFocusedRowCellValue("Id").ToString();
                        txtCode_3.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);
                        txtCodeLevel2.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);
                        txtName_3.Text = gridView3.GetFocusedRowCellValue("Name").ToString();
                        chkIsActive_3.Checked = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                        txtSharhHesab_3.Text = gridView3.GetFocusedRowCellValue("SharhHesab") != null ? gridView3.GetFocusedRowCellValue("SharhHesab").ToString() : "";

                        CodeBeforeEdit = txtCodeLevel2.Text + txtCode_3.Text;
                        NameBeforeEdit = txtName_3.Text.Trim();
                        IsActiveBeforeEdit = chkIsActive_3.Checked;
                        Level2IdBeforeEdit = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                        //if (txtCode.Text == "9")
                        //    btnNewCode.Enabled = false;
                        chkEditCode_3.Checked = false;
                        cmbGruopLevel1_3.Focus();
                    }

                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
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
                                    EpGroupTafsiliLevel1 obj = new EpGroupTafsiliLevel1();
                                    obj.SalId = _SalId;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.StartCode = _StartCode;
                                    obj.EndCode = _EndCode;
                                    obj.IsActive = _IsActive;
                                    obj.SharhHesab = _SharhHesab;
                                    //db.EpGroupTafsiliLevel1s.Add(obj);
                                    //db.SaveChanges();
                                    /////////////////////////////////////////////////////////////////////////////////////

                                    //var q = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Code == _Code);
                                    //////////////////////////////////////// اضافه کردن حساب گروه به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                                    EpAllGroupTafsili n1 = new EpAllGroupTafsili();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = _Code;
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpGroupTafsiliLevel1 = obj;
                                    db.EpAllGroupTafsilis.Add(n1);
                                    ///////////////////////////////////////////////////////////////////////////////////////
                                    db.SaveChanges();
                                    if (chkIsActive_1.Checked)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    btnCancel_Click(null, null);
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
                                    int _RowId = Convert.ToInt32(txtId_1.Text);
                                    ////////////////
                                    var s3 = db.EpGroupTafsiliLevel3s.Where(s => s.EpGroupTafsiliLevel2.Level1Id == _RowId && s.SalId == _SalId).ToList();
                                    if (s3.Count > 0)
                                    {
                                        foreach (var item in s3)
                                        {
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.Code.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                            //if (txtName_1.Text != NameBeforeEdit)
                                            //    item.Level1Name = txtName_1.Text;
                                            if (chkIsActive_1.Checked != IsActiveBeforeEdit)
                                                item.IsActive = chkIsActive_1.Checked;
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.StartCode = Convert.ToInt32(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.StartCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.EndCode = Convert.ToInt32(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.EndCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                        }
                                    }

                                    ///////////////
                                    var s2 = db.EpGroupTafsiliLevel2s.Where(s => s.Level1Id == _RowId && s.SalId == _SalId).ToList();
                                    if (s2.Count > 0)
                                    {
                                        foreach (var item in s2)
                                        {
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.Code.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                            //if (txtName_1.Text != NameBeforeEdit)
                                            //    item.Level1Name = txtName_1.Text;
                                            if (chkIsActive_1.Checked != IsActiveBeforeEdit)
                                                item.IsActive = chkIsActive_1.Checked;
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.StartCode = Convert.ToInt32(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.StartCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                            if (txtCode_1.Text != CodeBeforeEdit)
                                                item.EndCode = Convert.ToInt32(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                        + item.EndCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                            foreach (var item1 in s3)
                                            {
                                                if (item.Id == item1.Level2Id)
                                                    item.EpGroupTafsiliLevel3s.Append(item1);
                                            }
                                        }
                                    }

                                    ///////////////
                                    var s1 = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (s1 != null)
                                    {
                                        s1.Code = _Code;
                                        s1.Name = _Name;
                                        s1.StartCode = _StartCode;
                                        s1.EndCode = _EndCode;
                                        s1.IsActive = _IsActive;
                                        s1.SharhHesab = _SharhHesab;
                                        s1.EpGroupTafsiliLevel2s = s2;
                                    }
                                    //////////////
                                    var a1 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (a1 != null)
                                    {
                                        a1.KeyCode = _Code;
                                        a1.ParentCode = _Code;
                                        a1.LevelName = _Name;
                                        //a1.LevelNamber = _LevelNamber;
                                        a1.IsActive = _IsActive;
                                        a1.EpGroupTafsiliLevel1 = s1;


                                        var q7 = db.EpAllGroupTafsilis.Where(s => s.EpGroupTafsiliLevel2.Level1Id == _RowId && s.SalId == _SalId).ToList();
                                        if (q7.Count > 0)
                                        {
                                            foreach (var item in q7)
                                            {
                                                if (txtCode_1.Text != CodeBeforeEdit)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                                  + item.KeyCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                                  + item.ParentCode.ToString().Substring(_GroupTafsiliLevel1Carakter));

                                                }
                                                if (chkIsActive_1.Checked != IsActiveBeforeEdit)
                                                    item.IsActive = chkIsActive_1.Checked;

                                            }
                                        }
                                        var q5 = db.EpAllGroupTafsilis.Where(s => s.EpGroupTafsiliLevel3.EpGroupTafsiliLevel2.Level1Id == _RowId && s.SalId == _SalId).ToList();
                                        if (q5.Count > 0)
                                        {
                                            foreach (var item in q5)
                                            {
                                                if (txtCode_1.Text != CodeBeforeEdit)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                                  + item.KeyCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter).Replace(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter), _Code.ToString())
                                                                 + item.ParentCode.ToString().Substring(_GroupTafsiliLevel1Carakter));
                                                }
                                                if (chkIsActive_1.Checked != IsActiveBeforeEdit)
                                                    item.IsActive = chkIsActive_1.Checked;
                                            }
                                        }

                                        db.SaveChanges();
                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView1.RowCount > 0)
                                            gridView1.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
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
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
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
                                    EpGroupTafsiliLevel2 obj = new EpGroupTafsiliLevel2();
                                    obj.SalId = _SalId;
                                    obj.Level1Id = _Level1Id;
                                   // obj.Level1Name = cmbGruopLevel1_2.Text;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.StartCode = _StartCode;
                                    obj.EndCode = _EndCode;
                                    obj.IsActive = _IsActive;
                                    obj.SharhHesab = _SharhHesab;
                                    //db.EpGroupTafsiliLevel2s.Add(obj);
                                    //db.SaveChanges();
                                    ////////////////////////////////////////////////////////////
                                    EpAllGroupTafsili n1 = new EpAllGroupTafsili();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(_Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter));
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpGroupTafsiliLevel2 = obj;
                                    db.EpAllGroupTafsilis.Add(n1);
                                    db.SaveChanges();
                                    if (chkIsActive_2.Checked)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    btnCancel_Click(null, null);
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
                                    int _RowId = Convert.ToInt32(txtId_2.Text);
                                    ///////////////
                                    var q3 = db.EpGroupTafsiliLevel3s.Where(s => s.Level2Id == _RowId && s.SalId == _SalId).ToList();
                                    if (q3.Count > 0)
                                    {
                                        foreach (var item in q3)
                                        {
                                            if (_Code.ToString() != CodeBeforeEdit)
                                                item.Code = Convert.ToInt32(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter).Replace(item.Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter), _Code.ToString())
                                                        + item.Code.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                            //if (txtName_2.Text != NameBeforeEdit)
                                            //    item.Level2Name = txtName_2.Text;
                                            if (chkIsActive_2.Checked != IsActiveBeforeEdit)
                                                item.IsActive = chkIsActive_2.Checked;
                                            if (_Code.ToString() != CodeBeforeEdit)
                                                item.StartCode = Convert.ToInt32(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter).Replace(item.StartCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter), _Code.ToString())
                                                        + item.StartCode.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                            if (_Code.ToString() != CodeBeforeEdit)
                                                item.EndCode = Convert.ToInt32(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter).Replace(item.EndCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter), _Code.ToString())
                                                        + item.EndCode.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                        }
                                    }
                                    ///////////
                                    var q = db.EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                        q.Level1Id = _Level1Id;
                                       // q.Level1Name = cmbGruopLevel1_2.Text;
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.StartCode = _StartCode;
                                        q.EndCode = _EndCode;
                                        q.IsActive = _IsActive;
                                        q.SharhHesab = _SharhHesab;
                                        q.EpGroupTafsiliLevel3s = q3;
                                    }
                                    var q2 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(_Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter));
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpGroupTafsiliLevel2 = q;


                                        var q5 = db.EpAllGroupTafsilis.Where(s => s.EpGroupTafsiliLevel3.Level2Id == _RowId && s.SalId == _SalId).ToList();
                                        if (q5.Count > 0)
                                        {
                                            foreach (var item in q5)
                                            {
                                                if (_Code.ToString() != CodeBeforeEdit)
                                                {
                                                    item.KeyCode = Convert.ToInt32(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter).Replace(item.KeyCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter), _Code.ToString())
                                                                  + item.KeyCode.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                                    item.ParentCode = Convert.ToInt32(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter).Replace(item.ParentCode.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter), _Code.ToString())
                                                                 + item.ParentCode.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                                }
                                                if (chkIsActive_1.Checked != IsActiveBeforeEdit)
                                                    item.IsActive = chkIsActive_1.Checked;
                                            }
                                        }

                                        if (IsActiveBeforeEdit == false && chkIsActive_2.Checked == true)
                                        {
                                            var A = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _Level1Id && s.SalId == _SalId);
                                            var B = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == _Level1Id && s.SalId == _SalId);
                                            //var C = db.EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _Level2Id);
                                            //var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _HesabTabaghehId || s.CodingHesabdariId == _HesabGroupId && s.SalId == _SalId);
                                            if (A != null)
                                                A.IsActive = true;
                                            if (B != null)
                                                B.IsActive = true;
                                            //if (C != null)
                                            //    C.IsActive = true;
                                            //foreach (var item in A)
                                            //    item.IsActive = true;
                                            //foreach (var item in U)
                                            //    item.IsActive = true;
                                        }

                                        db.SaveChanges();
                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView2.RowCount > 0)
                                            gridView2.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
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
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
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
                                    EpGroupTafsiliLevel3 obj = new EpGroupTafsiliLevel3();
                                    obj.SalId = _SalId;
                                   // obj.Level1Name = cmbGruopLevel1_3.Text;
                                    obj.Level2Id = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                                   // obj.Level2Name = cmbGruopLevel2_3.Text;
                                    obj.Code = _Code;
                                    obj.Name = _Name;
                                    obj.StartCode = _StartCode;
                                    obj.EndCode = _EndCode;
                                    obj.IsActive = _IsActive;
                                    obj.SharhHesab = _SharhHesab;
                                    ///////////////
                                    EpAllGroupTafsili n1 = new EpAllGroupTafsili();
                                    n1.SalId = _SalId;
                                    n1.KeyCode = _Code;
                                    n1.ParentCode = Convert.ToInt32(_Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                    n1.LevelName = _Name;
                                    n1.LevelNamber = _LevelNamber;
                                    n1.IsActive = _IsActive;
                                    n1.EpGroupTafsiliLevel3 = obj;
                                    db.EpAllGroupTafsilis.Add(n1);
                                    db.SaveChanges();

                                    if (chkIsActive_3.Checked)
                                        btnDisplyActiveList_Click(null, null);
                                    else
                                        btnDisplyNotActiveList_Click(null, null);

                                    //XtraMessageBox.Show("عملیات ایجاد با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                    btnLast_Click(null, null);
                                    btnCancel_Click(null, null);
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
                                    int _RowId = Convert.ToInt32(txtId_3.Text);
                                    var q = db.EpGroupTafsiliLevel3s.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q != null)
                                    {
                                       // q.Level1Name = cmbGruopLevel1_3.Text;
                                        q.Level2Id = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                                      //  q.Level2Name = cmbGruopLevel2_3.Text;
                                        q.Code = _Code;
                                        q.Name = _Name;
                                        q.StartCode = _StartCode;
                                        q.EndCode = _EndCode;
                                        q.IsActive = _IsActive;
                                        q.SharhHesab = _SharhHesab;
                                    }
                                    var q2 = db.EpAllGroupTafsilis.FirstOrDefault(s => s.Id == _RowId && s.SalId == _SalId);
                                    if (q2 != null)
                                    {
                                        q2.KeyCode = _Code;
                                        q2.ParentCode = Convert.ToInt32(_Code.ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter));
                                        q2.LevelName = _Name;
                                        q2.IsActive = _IsActive;
                                        q2.EpGroupTafsiliLevel3 = q;
                                        ////////////////////////////////////
                                        if (IsActiveBeforeEdit == false && chkIsActive_3.Checked == true)
                                        {
                                            var A = db.EpAllGroupTafsilis.Where(s => s.Id == _Level1Id || s.Id == _Level2Id && s.SalId == _SalId);
                                            var B = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == _Level1Id && s.SalId == _SalId);
                                            var C = db.EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _Level2Id && s.SalId == _SalId);
                                            //var U = db.RmsUserBallCodingHesabdaris.Where(s => s.CodingHesabdariId == _HesabTabaghehId || s.CodingHesabdariId == _HesabGroupId && s.SalId == _SalId);
                                            if (B != null)
                                                B.IsActive = true;
                                            if (C != null)
                                                C.IsActive = true;
                                            foreach (var item in A)
                                                item.IsActive = true;
                                            //foreach (var item in U)
                                            //    item.IsActive = true;
                                        }


                                        db.SaveChanges();
                                        if (IsActiveBeforeEdit)
                                            btnDisplyActiveList_Click(null, null);
                                        else
                                            btnDisplyNotActiveList_Click(null, null);

                                        //XtraMessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                        if (gridView3.RowCount > 0)
                                            gridView3.FocusedRowHandle = EditRowIndex;
                                        btnCancel_Click(null, null);
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (btnCancel.Enabled)
                {
                    gridControl1.Enabled = true;
                    En = EnumCED.Cancel;
                    HelpClass1.ActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl1_2);
                    HelpClass1.InActiveControls(panelControl1_2);
                    btnCreate.Focus();
                }

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (btnCancel.Enabled)
                {
                    gridControl2.Enabled = true;
                    En = EnumCED.Cancel;
                    HelpClass1.ActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl2_2);
                    HelpClass1.InActiveControls(panelControl2_2);
                    btnCreate.Focus();
                }

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (btnCancel.Enabled)
                {
                    gridControl3.Enabled = true;
                    En = EnumCED.Cancel;
                    HelpClass1.ActiveButtons(panelControl);
                    HelpClass1.ClearControls(panelControl3_2);
                    HelpClass1.InActiveControls(panelControl3_2);
                    btnCreate.Focus();
                }

            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (xtraTabControl1.SelectedTabPageIndex == 0)
            //{
            //    btnDelete.Enabled = btnEdit.Enabled = gridView.RowCount > 0 ? true : false;
            //}
            //else if (xtraTabControl1.SelectedTabPageIndex == 1)
            //{
            //    btnDelete.Enabled = btnEdit.Enabled = gridView.RowCount > 0 ? true : false;
            //}
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (gridView1.RowCount > 0)
                {
                    txtId_1.Text = gridView1.GetFocusedRowCellDisplayText("Id");
                    txtCode_1.Text = gridView1.GetFocusedRowCellDisplayText("Code");
                    txtName_1.Text = gridView1.GetFocusedRowCellDisplayText("Name");
                    txtStartCode_1.Text = gridView1.GetFocusedRowCellDisplayText("StartCode");
                    txtEndCode_1.Text = gridView1.GetFocusedRowCellDisplayText("EndCode");
                    chkIsActive_1.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab_1.Text = gridView1.GetFocusedRowCellDisplayText("SharhHesab");

                    btnDelete.Enabled = btnEdit.Enabled = true;
                }
                else
                    btnDelete.Enabled = btnEdit.Enabled = false;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                //FillcmbGruopLevel1();
                if (gridView2.RowCount > 0)
                {
                    cmbGruopLevel1_2.EditValue = Convert.ToInt32(gridView2.GetFocusedRowCellValue("Level1Id").ToString());
                    txtId_2.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
                    txtCode_2.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(_GroupTafsiliLevel1Carakter);
                    txtCodeLevel1.Text = gridView2.GetFocusedRowCellValue("Code").ToString().Substring(0, _GroupTafsiliLevel1Carakter);
                    txtName_2.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                    chkIsActive_2.Checked = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab_2.Text = gridView2.GetFocusedRowCellValue("SharhHesab") != null ? gridView2.GetFocusedRowCellValue("SharhHesab").ToString() : "";
                    btnDelete.Enabled = btnEdit.Enabled = true;
                }
                else
                    btnDelete.Enabled = btnEdit.Enabled = false;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                //FillcmbGruopLevel1();
                if (gridView3.RowCount > 0)
                {
                    _Level2Id = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Level2Id").ToString());
                    cmbGruopLevel1_3.EditValue = new MyContext().EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _Level2Id && s.SalId == _SalId).Level1Id;
                    //cmbGruopLevel1_3.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Level1Id").ToString());
                    cmbGruopLevel2_3.EditValue = Convert.ToInt32(gridView3.GetFocusedRowCellValue("Level2Id").ToString());
                    txtId_3.Text = gridView3.GetFocusedRowCellValue("Id").ToString();
                    txtCode_3.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);
                    txtCodeLevel2.Text = gridView3.GetFocusedRowCellValue("Code").ToString().Substring(0, _GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);
                    txtName_3.Text = gridView3.GetFocusedRowCellValue("Name").ToString();
                    chkIsActive_3.Checked = Convert.ToBoolean(gridView3.GetFocusedRowCellValue("IsActive"));
                    txtSharhHesab_3.Text = gridView3.GetFocusedRowCellValue("SharhHesab") != null ? gridView3.GetFocusedRowCellValue("SharhHesab").ToString() : "";
                    btnDelete.Enabled = btnEdit.Enabled = true;
                }
                else
                    btnDelete.Enabled = btnEdit.Enabled = false;
            }
        }

        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtCode_1.Text.Trim()))
                {
                    if (Convert.ToInt32(txtCode_1.Text) >= Convert.ToInt32(_GroupTafsiliLevel1MinCode) && Convert.ToInt32(txtCode_1.Text) <= Convert.ToInt32(_GroupTafsiliLevel1MaxCode))
                    {
                        txtStartCode_1.Text = txtCode_1.Text + _CodeTafsiliMinCode;
                        txtEndCode_1.Text = txtCode_1.Text + _CodeTafsiliMaxCode;
                    }
                    else
                    {
                        txtStartCode_1.Text = string.Empty;
                        txtEndCode_1.Text = string.Empty;
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (!string.IsNullOrEmpty(txtCode_2.Text.Trim()))
                {
                    if (Convert.ToInt32(txtCode_2.Text) >= Convert.ToInt32(_GroupTafsiliLevel2MinCode) && Convert.ToInt32(txtCode_2.Text) <= Convert.ToInt32(_GroupTafsiliLevel2MaxCode))
                    {
                        txtStartCode_2.Text = txtCodeLevel1.Text + txtCode_2.Text + _CodeTafsiliMinCode;
                        txtEndCode_2.Text = txtCodeLevel1.Text + txtCode_2.Text + _CodeTafsiliMaxCode;
                    }
                    else
                    {
                        txtStartCode_2.Text = string.Empty;
                        txtEndCode_2.Text = string.Empty;
                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (!string.IsNullOrEmpty(txtCode_3.Text.Trim()))
                {
                    if (Convert.ToInt32(txtCode_3.Text) >= Convert.ToInt32(_GroupTafsiliLevel3MinCode) && Convert.ToInt32(txtCode_3.Text) <= Convert.ToInt32(_GroupTafsiliLevel3MaxCode))
                    {
                        txtStartCode_3.Text = txtCodeLevel2.Text + txtCode_3.Text + _CodeTafsiliMinCode;
                        txtEndCode_3.Text = txtCodeLevel2.Text + txtCode_3.Text + _CodeTafsiliMaxCode;
                    }
                    else
                    {
                        txtStartCode_3.Text = string.Empty;
                        txtEndCode_3.Text = string.Empty;
                    }
                }
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            // btnDelete.Enabled = btnEdit.Enabled = false;
            btnDisplyActiveList_Click(null, null);
            FillcmbGruopLevel1();
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                txtCode_1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode_1.Properties.Mask.EditMask = "00";
                txtCode_1.Properties.MaxLength = _GroupTafsiliLevel1Carakter;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                txtCode_2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode_2.Properties.Mask.EditMask = "0";
                txtCode_2.Properties.MaxLength = _GroupTafsiliLevel2Carakter;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                txtCode_3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; ;
                txtCode_3.Properties.Mask.EditMask = "0";
                txtCode_3.Properties.MaxLength = _GroupTafsiliLevel3Carakter;
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (En == EnumCED.Create || En == EnumCED.Edit)
            {
                btnCancel_Click(null, null);
            }
        }

        private void cmbGruopLevel1_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _Level1Id = Convert.ToInt32(cmbGruopLevel1_2.EditValue);
                        // int _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpGroupTafsiliLevel1s.FirstOrDefault(s => s.Id == _Level1Id);
                        if (q != null)
                        {
                            txtCodeLevel1.Text = q.Code.ToString();
                            if (En == EnumCED.Edit)
                                if (_Level1Id != Level1IdBeforeEdit)
                                {
                                    btnNewCode_Click(null, null);
                                }
                                else
                                    txtCode_2.Text = CodeBeforeEdit.ToString().Substring(_GroupTafsiliLevel1Carakter);

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
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                FillcmbGruopLevel2();
                cmbGruopLevel2_3.EditValue = 0;
                txtCodeLevel2.Text = txtCode_3.Text = string.Empty;
            }
        }


        private void cmbGruopLevel1_Enter(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (En == EnumCED.Create)
                {
                    cmbGruopLevel1_2.ShowPopup();
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                if (En == EnumCED.Create)
                {
                    cmbGruopLevel1_3.ShowPopup();
                }
            }

        }
        private void cmbGruopLevel2_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                cmbGruopLevel2_3.ShowPopup();
            }
        }

        private void btnReloadGroupLevel1_Click(object sender, EventArgs e)
        {
            FillcmbGruopLevel1();
        }
        private void btnReloadGroupLevel2_Click(object sender, EventArgs e)
        {
            FillcmbGruopLevel2();
        }

        private void cmbGruopLevel2_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _Level2Id = Convert.ToInt32(cmbGruopLevel2_3.EditValue);
                    // int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpGroupTafsiliLevel2s.FirstOrDefault(s => s.Id == _Level2Id);
                    if (q != null)
                    {
                        txtCodeLevel2.Text = q.Code.ToString();

                        if (En == EnumCED.Edit)
                            if (_Level2Id != Level2IdBeforeEdit)
                            {
                                btnNewCode_Click(null, null);
                            }
                            else
                                txtCode_3.Text = CodeBeforeEdit.ToString().Substring(_GroupTafsiliLevel1Carakter + _GroupTafsiliLevel2Carakter);

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
    }
}