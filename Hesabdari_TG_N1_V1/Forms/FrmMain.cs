/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmMain.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 14   03:53 ق.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;
using Hesabdari_TG_N1_V1.Forms.Ap;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.InternalItems;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTab;
using Hesabdari_TG_N1_V1.Forms.Ap.AnbarKala;
using Microsoft.Win32;
using System.Data.SqlClient;
using HelpClassLibrary;
using SystemManagement.DafaterMali;
using SystemManagement.UsersSystem;
using DBHesabdari_TG;
using System.Data.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        DocumentManager documentManager1;
        //XtraTabbedMdiManager xtraTabbedMdiManager1;
        public FrmMain()
        {
            InitializeComponent();
        }
        int _UserId = 0;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _UserId = Convert.ToInt32(txtUserId.Caption.ToString());
            // that will manage MDI child windows.
            //documentManager1.View = new NativeMdiView();
            ribbon.Minimized = true;
            //xtraTabbedMdiManager1 = new XtraTabbedMdiManager();
            //xtraTabbedMdiManager1.MdiParent = this;     
            documentManager1 = new DocumentManager
            {
                MdiParent = this,
                View = new TabbedView()
            };
            FillcmbMajmoehaList();
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsDefaults.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                    {
                        cmbMajmoehaList.EditValue = q.MsMajmoeId;
                        //chkDefault.Checked = true;
                    }
                    //////////////////////////////////////////////////////////////////////
                    var q1 = db.RmsUserhaBmsAccessLevel1has.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        Ms.Visible = q1.Any(s => s.MsAccessLevel1Id == 55) ? false : true;
                        rpgOperationDafaterVaDoreMali.Visible = q1.Any(s => s.MsAccessLevel1Id == 55100 || s.MsAccessLevel1Id == 55200) ? false : true;
                        mbsListDafaterMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55100) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListMojmoeha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55110) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListVahedha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55120) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListShobeha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55130) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListDorehaiMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55140) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        ///////////////////////////
                        mbsOperationDoreMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55200) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        ///////////////////////////
                        rpgUsers.Visible = q1.Any(s => s.MsAccessLevel1Id == 55300) ? false : true;
                        mbsSystemUsers.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55300) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnUsersList.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55310) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDetermineAccessLevel.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55320) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDetermineAccessLevel1.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55330) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDetermineAccessLevel2.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55340) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnChangePassword.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55350) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        //////////////////////////
                    }
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
        }
        public void FillcmbMajmoehaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    msMajmoeBindingSource.DataSource = null;
                    List<MsMajmoe> ListMajmoeha = new List<MsMajmoe>();
                    var q2 = db.MsMajmoes.Where(s => s.MajmoeIsActive == true).ToList();
                    var q3 = db.RmsUserhaBmsMajmoehas.Where(s => s.MsUserId == _UserId).Select(s => s.MsMajmoeId).ToList();
                    if (q2.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            foreach (var item2 in q2)
                            {
                                if (!q3.Contains(item2.MsMajmoeId))
                                {
                                    ListMajmoeha.Add(db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == item2.MsMajmoeId));
                                }
                            }
                            msMajmoeBindingSource.DataSource = ListMajmoeha;
                        }
                        else
                        {
                            msMajmoeBindingSource.DataSource = q2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ////////////////////////////////////////////////////////////////////////////
            //var db = new MyContext();
            //db.MsMajmoes.Where(s => s.IsActive == true).LoadAsync().ContinueWith(loadTask =>
            //{
            //    // Bind data to control when loading complete
            //    msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

        }
        public void FillcmbVahedhaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    msVahedBindingSource.DataSource = null;
                    List<MsVahed> ListVahedha = new List<MsVahed>();
                    int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                    var q2 = db.MsVaheds.Where(s => s.VahedIsActive == true && s.MsMajmoeId == _MajmoeId).ToList();
                    var q3 = db.RmsUserhaBmsVahedhas.Where(s => s.MsUserId == _UserId).Select(s => s.MsVahedId).ToList();
                    if (q2.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            foreach (var item2 in q2)
                            {
                                if (!q3.Contains(item2.MsVahedId))
                                {
                                    ListVahedha.Add(db.MsVaheds.FirstOrDefault(s => s.MsVahedId == item2.MsVahedId));
                                }
                            }
                            msVahedBindingSource.DataSource = ListVahedha;
                        }
                        else
                        {
                            msVahedBindingSource.DataSource = q2;
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
        public void FillcmbShobehaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    msShobeBindingSource.DataSource = null;
                    List<MsShobe> ListShobeha = new List<MsShobe>();
                    int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                    var q2 = db.MsShobes.Where(s => s.ShobeIsActive == true && s.MsVahedId == _VahedId).ToList();
                    var q3 = db.RmsUserhaBmsShobehas.Where(s => s.MsUserId == _UserId).Select(s => s.MsShobeId).ToList();
                    if (q2.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            foreach (var item2 in q2)
                            {
                                if (!q3.Contains(item2.MsShobeId))
                                {
                                    ListShobeha.Add(db.MsShobes.FirstOrDefault(s => s.MsShobeId == item2.MsShobeId));
                                }
                            }
                            msShobeBindingSource.DataSource = ListShobeha;
                        }
                        else
                        {
                            msShobeBindingSource.DataSource = q2;
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
        public void FillcmbDoreMalihaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    msDoreMaliBindingSource.DataSource = null;
                    List<MsDoreMali> ListDoreha = new List<MsDoreMali>();
                    int _ShobeId = Convert.ToInt32(cmbShobehaList.EditValue);
                    var q2 = db.MsDoreMalis.Where(s => s.DoreMaliIsActive == true && s.MsShobeId == _ShobeId).ToList();
                    var q3 = db.RmsUserhaBmsDorehaiMalis.Where(s => s.MsUserId == _UserId).Select(s => s.MsDoreMaliId).ToList();
                    if (q2.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            foreach (var item2 in q2)
                            {
                                if (!q3.Contains(item2.MsDoreMaliId))
                                {
                                    ListDoreha.Add(db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == item2.MsDoreMaliId));
                                }
                            }
                            msDoreMaliBindingSource.DataSource = ListDoreha;
                        }
                        else
                        {
                            msDoreMaliBindingSource.DataSource = q2;
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


        private void btnListAnbarha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAnbarhaList fm = new FrmAnbarhaList();
            fm.lblSelectDoreMali.Text = cmbDoreMalihaList.Edit.GetDisplayText(cmbDoreMalihaList.EditValue);
            if (fm.lblSelectDoreMali.Text == "")
            {
                XtraMessageBox.Show("لطفاً سال مالی مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fm.MdiParent = this;
            HelpClass1.ActiveForm(fm);
        }

        private void btnListMojtamaha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMajmoehaList fm = new FrmMajmoehaList();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void btnUsersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUsersList fm = new FrmUsersList();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection.ClearAllPools();
            Dispose(true);
        }

        private void btnListVahedha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmVahedhaList fm = new FrmVahedhaList();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void btnListShoabat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmShoabatList fm = new FrmShoabatList();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void btnListDorehaiMali_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDorehaList fm = new FrmDorehaList();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void cmbMajmoehaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbVahedhaList();
            msShobeBindingSource.DataSource = null;
            msDoreMaliBindingSource.DataSource = null;
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsDefaults.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                        cmbVahedhaList.EditValue = q.MsVahedId;
                    else
                    {
                        cmbVahedhaList.EditValue = -1;
                        cmbShobehaList.EditValue = -1;
                        cmbDoreMalihaList.EditValue = -1;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbVahedhaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbShobehaList();
            msDoreMaliBindingSource.DataSource = null;
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsDefaults.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                        cmbShobehaList.EditValue = q.MsShobeId;
                    else
                    {
                        cmbShobehaList.EditValue = -1;
                        cmbDoreMalihaList.EditValue = -1;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbShobehaList_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbDoreMalihaList();
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsDefaults.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (q != null)
                        cmbDoreMalihaList.EditValue = q.MsDoreMaliId;
                    else
                    {
                        cmbDoreMalihaList.EditValue = -1;
                        //chkDefault.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void chkDefault_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            cmbMajmoehaList.Enabled = cmbVahedhaList.Enabled = cmbShobehaList.Enabled = cmbDoreMalihaList.Enabled =
                                      chkDefault.Checked ? false : true;

            int MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
            int VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
            int ShobeId = Convert.ToInt32(cmbShobehaList.EditValue);
            int DoreId = Convert.ToInt32(cmbDoreMalihaList.EditValue);

            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsDefaults.FirstOrDefault(s => s.MsUserId == _UserId);
                    if (chkDefault.Checked)
                    {
                        if (q == null)
                        {
                            MsDefault d1 = new MsDefault();
                            d1.MsUserId = _UserId;
                            d1.MsMajmoeId = MajmoeId;
                            d1.MsVahedId = VahedId;
                            d1.MsShobeId = ShobeId;
                            d1.MsDoreMaliId = DoreId;
                            db.MsDefaults.Add(d1);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (q != null)
                        {
                            db.MsDefaults.Remove(q);
                            db.SaveChanges();
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

        public bool FirstRunFrmMain = true;
        private void cmbDoreMalihaList_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbDoreMalihaList.EditValue) > -1)
                chkDefault.Checked = true;
            if (FirstRunFrmMain == false)
                HelpClass1.CloseAllOpenForms();
            FirstRunFrmMain = false;
        }

        private void btnDetermineAccessLevel1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevel1 fm = new FrmAccesslevel1();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);

        }

        private void btnDetermineAccessLevel2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevel2 fm = new FrmAccesslevel2();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmChangPassword fm = new FrmChangPassword();
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            HelpClass1.ActiveForm(fm);

        }
    }
}
