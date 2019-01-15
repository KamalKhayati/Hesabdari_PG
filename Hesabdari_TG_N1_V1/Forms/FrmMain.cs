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

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DocumentManager documentManager1;
        //XtraTabbedMdiManager xtraTabbedMdiManager1;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

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
                    var q = db.MsMajmoes.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null)
                    {
                        cmbMajmoehaList.EditValue = q.MsMajmoeId;
                        chkDefault.Checked = true;
                    }
                    //////////////////////////////////////////////////////////////////////
                    int _UserId = Convert.ToInt32(txtUserId.Caption);
                    var q1 = db.RmsUserhaBmsAccessLevel1has.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                            Ms.Visible = q1.Any(s => s.MsAccessLevel1Id == 55) ? true : false;
                            rpgOperationDafaterVaDoreMali.Visible = q1.Any(s => s.MsAccessLevel1Id == 55100 || s.MsAccessLevel1Id == 55200) ? true : false;
                            mbsListDafaterMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55100) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnListMojmoeha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55110) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnListVahedha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55120) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnListShobeha.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55130) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnListDorehaiMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55140) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            ///////////////////////////
                            mbsOperationDoreMali.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55200) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            ///////////////////////////
                            rpgUsers.Visible = q1.Any(s => s.MsAccessLevel1Id == 55300) ? true : false;
                            mbsSystemUsers.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55300) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnUsersList.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55310) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnDetermineAccessLevel.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55320) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnDetermineAccessLevel1.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55330) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnDetermineAccessLevel2.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55340) ? BarItemVisibility.Always : BarItemVisibility.Never;
                            btnChangePassword.Visibility = q1.Any(s => s.MsAccessLevel1Id == 55350) ? BarItemVisibility.Always : BarItemVisibility.Never;
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
            //var db = new MyContext();
            //db.MsMajmoes.Where(s => s.IsActive == true).LoadAsync().ContinueWith(loadTask =>
            //{
            //    // Bind data to control when loading complete
            //    msMajmoesBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            //using (var db = new MyContext())
            //{
            try
            {
                var db = new MyContext();
                if (db.MsMajmoes.Any())
                {
                    // This line of code is generated by Data Source Configuration Wizard
                    db.MsMajmoes.Where(s => s.MajmoeIsActive == true).LoadAsync().ContinueWith(loadTask =>
                    {
                        // Bind data to control when loading complete
                        msMajmoeBindingSource.DataSource = db.MsMajmoes.Local.ToBindingList();
                    }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}

        }
        public void FillcmbVahedhaList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsVaheds.Any())
                    {
                        int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                        // This line of code is generated by Data Source Configuration Wizard
                        db.MsVaheds.Where(s => s.VahedIsActive == true && s.MsMajmoeId == _MajmoeId).Load();
                        // Bind data to control when loading complete
                        msVahedBindingSource.DataSource = db.MsVaheds.Local.ToBindingList();
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
                    if (db.MsVaheds.Any())
                    {
                        int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                        // This line of code is generated by Data Source Configuration Wizard
                        db.MsShobes.Where(s => s.ShobeIsActive == true && s.MsVahedId == _VahedId).Load();
                        // Bind data to control when loading complete
                        msShobeBindingSource.DataSource = db.MsShobes.Local.ToBindingList();
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
                    if (db.MsDoreMalis.Any())
                    {
                        int _ShobeId = Convert.ToInt32(cmbShobehaList.EditValue);
                        // This line of code is generated by Data Source Configuration Wizard
                        db.MsDoreMalis.Where(s => s.DoreMaliIsActive == true && s.MsShobeId == _ShobeId).Load();
                        // Bind data to control when loading complete
                        msDoreMaliBindingSource.DataSource = db.MsDoreMalis.Local.ToBindingList();
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
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsVaheds.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null)
                        cmbVahedhaList.EditValue = q.MsVahedId;
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
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.MsShobes.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null)
                        cmbShobehaList.EditValue = q.MsShobeId;
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
                    var q = db.MsDoreMalis.FirstOrDefault(s => s.IsDefault == true);
                    if (q != null)
                        cmbDoreMalihaList.EditValue = q.MsDoreMaliId;
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
                    var q1 = db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == MajmoeId);
                    var q2 = db.MsVaheds.FirstOrDefault(s => s.MsVahedId == VahedId);
                    var q3 = db.MsShobes.FirstOrDefault(s => s.MsShobeId == ShobeId);
                    var q4 = db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == DoreId);

                    if (chkDefault.Checked)
                    {
                        if (q1 != null)
                            q1.IsDefault = true;
                        if (q2 != null)
                            q2.IsDefault = true;
                        if (q3 != null)
                            q3.IsDefault = true;
                        if (q4 != null)
                            q4.IsDefault = true;
                    }
                    else
                    {
                        if (q1 != null)
                            q1.IsDefault = false;
                        if (q2 != null)
                            q2.IsDefault = false;
                        if (q3 != null)
                            q3.IsDefault = false;
                        if (q4 != null)
                            q4.IsDefault = false;
                    }
                    db.SaveChanges();
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
    }
}
