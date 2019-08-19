﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmMain.cs
*	Project:		Hesabdari_PG
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
using Hesabdari_PG.Forms.Ap;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.InternalItems;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTab;
using Hesabdari_PG.Forms.Ap.AnbarKala;
using Microsoft.Win32;
using System.Data.SqlClient;
using HelpClassLibrary;
using DBHesabdari_PG;
using System.Data.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using EtelaatePaye.CodingHesabdari;
using SystemManagement.UsersSystem;
using SystemManagement.ActiveSystem;
using SystemManagement.DafaterMali;
using DBHesabdari_PG.Models.Ms.DafaterMali;
using EtelaatePaye.CodingAnbar;

namespace Hesabdari_PG.Forms
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

        public new void ActiveForm(XtraForm form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _UserId = Convert.ToInt32(txtUserId.Caption.ToString());
            // that will manage MDI child windows.
            //documentManager1.View = new NativeMdiView();
            //ribbon.Minimized = true;
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
                        cmbMajmoehaList.EditValue = q.MajmoeId;
                        //chkDefault.Checked = true;
                    }
                    //////////////////////////////////////////////////////////////////////
                    var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        Ms.Visible = q1.Any(s => s.MsAccessLevelMenuId == 55) ? false : true;
                        rpgOperationDafaterVaDoreMali.Visible = q1.Any(s => s.MsAccessLevelMenuId == 5501 || s.MsAccessLevelMenuId == 5502) ? false : true;
                        mbsListDafaterMali.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 5501) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListMojmoeha.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550101) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListVahedha.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550102) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListShobeha.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550103) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnListDorehaiMali.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550104) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        ///////////////////////////
                        mbsOperationDoreMali.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 5502) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        ///////////////////////////
                        rpgUsers.Visible = q1.Any(s => s.MsAccessLevelMenuId == 5503) ? false : true;
                        mbsSystemUsers.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 5503) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnUsersList.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550301) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDetermineAccessLevel.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550302) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnTaeenAccessLevelSystemVMenu.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55030201) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnTaeenAcecessLevelDafaterMali.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55030201) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnChangePassword.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550303) ? BarItemVisibility.Never : BarItemVisibility.Always;
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
                    var q1 = db.MsMajmoes.Where(s => s.MajmoeIsActive == true).ToList();
                    //var q2 = q1.Select(s => s.MsMajmoeId).ToList();
                    var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.VahedId == 0 && s.IsActive == true).Select(s => s.MajmoeId).ToList();
                    if (q1.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            //foreach (var item3 in q3)
                            //{
                            //    q1.Remove(db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId != item3));
                            //}
                            q3.ForEach(item3 =>
                            {
                                q1.Remove(db.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == item3));
                            });
                            msMajmoeBindingSource.DataSource = q1;
                        }
                        else
                        {
                            msMajmoeBindingSource.DataSource = q1;
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
                    int _MajmoeId = Convert.ToInt32(cmbMajmoehaList.EditValue);
                    var q1 = db.MsVaheds.Where(s => s.VahedIsActive == true && s.MsMajmoeId == _MajmoeId).ToList();
                    //var q2 = q1.Select(s=>s.MsVahedId).ToList(); ;
                    var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.ShobeId == 0 && s.IsActive == true).Select(s => s.VahedId).ToList();
                    if (q1.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            q3.ForEach(item3 =>
                            {
                                q1.Remove(db.MsVaheds.FirstOrDefault(s => s.MsVahedId == item3));
                            });
                            msVahedBindingSource.DataSource = q1;
                        }
                        else
                        {
                            msVahedBindingSource.DataSource = q1;
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
                    int _VahedId = Convert.ToInt32(cmbVahedhaList.EditValue);
                    var q1 = db.MsShobes.Where(s => s.ShobeIsActive == true && s.MsVahedId == _VahedId).ToList();
                    //var q2 = q1.Select(s=>s.MsShobeId).ToList();
                    var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.DoreMaliId == 0 && s.IsActive == true).Select(s => s.ShobeId).ToList();
                    if (q1.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            q3.ForEach(item3 =>
                            {
                                q1.Remove(db.MsShobes.FirstOrDefault(s => s.MsShobeId == item3));

                            });
                            msShobeBindingSource.DataSource = q1;
                        }
                        else
                        {
                            msShobeBindingSource.DataSource = q1;
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
                    int _ShobeId = Convert.ToInt32(cmbShobehaList.EditValue);
                    var q1 = db.MsDoreMalis.Where(s => s.DoreMaliIsActive == true && s.MsShobeId == _ShobeId).ToList();
                    //var q2 = q1.Select(s => s.MsDoreMaliId).ToList();
                    var q3 = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.DoreMaliId > 0 && s.IsActive == true).Select(s => s.DoreMaliId).ToList();
                    if (q1.Count > 0)
                    {
                        if (q3.Count > 0)
                        {
                            q3.ForEach(item3 =>
                            {
                                q1.Remove(db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == item3));

                            });
                            msDoreMaliBindingSource.DataSource = q1;
                        }
                        else
                        {
                            msDoreMaliBindingSource.DataSource = q1;
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
            FrmListAnbarha fm = new FrmListAnbarha();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnListMojtamaha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListMajmoeha fm = new FrmListMajmoeha();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnUsersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListUsers fm = new FrmListUsers();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection.ClearAllPools();
            Dispose(true);
        }

        private void btnListVahedha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListVahedha fm = new FrmListVahedha();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnListShoabat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListShoabat fm = new FrmListShoabat();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnListDorehaiMali_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListDoreha fm = new FrmListDoreha();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
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
                        cmbVahedhaList.EditValue = q.VahedId;
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
                        cmbShobehaList.EditValue = q.ShobeId;
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
                        cmbDoreMalihaList.EditValue = q.DoreMaliId;
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
                    if (q != null)
                    {
                        if (chkDefault.Checked)
                        {
                            q.MsUserId = _UserId;
                            q.MajmoeId = MajmoeId;
                            q.VahedId = VahedId;
                            q.ShobeId = ShobeId;
                            q.DoreMaliId = DoreId;
                        }
                        else
                        {
                            db.MsDefaults.Remove(q);
                        }
                    }
                    else
                    {
                        MsDefault d1 = new MsDefault();
                        d1.MsUserId = _UserId;
                        d1.MajmoeId = MajmoeId;
                        d1.VahedId = VahedId;
                        d1.ShobeId = ShobeId;
                        d1.DoreMaliId = DoreId;
                        db.MsDefaults.Add(d1);
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
            if (Convert.ToInt32(cmbDoreMalihaList.EditValue) > -1)
                chkDefault.Checked = true;
            if (FirstRunFrmMain == false)
                HelpClass1.CloseAllOpenForms();
            FirstRunFrmMain = false;
        }

        private void btnTaeenAccessLevelSystemVMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevelMenuh fm = new FrmAccesslevelMenuh();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTaeenAcecessLevelDafaterMali_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevelDafaterMali fm = new FrmAccesslevelDafaterMali();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmChangPassword fm = new FrmChangPassword();
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnHesabGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabGroup fm = new FrmHesabGroup();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnHesabCol_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabCol fm = new FrmHesabCol();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnHesabMoin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabMoin fm = new FrmHesabMoin();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnTaeenAcecessLevelCodingHesabdari_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevelCodingHesabdari fm = new FrmAccesslevelCodingHesabdari();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTaeenAcecessLevelActiveSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAccesslevelActiveSystem fm = new FrmAccesslevelActiveSystem();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnGroupTafzili_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmListGroupTafzili fm = new FrmListGroupTafzili();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnTafziliSandogh_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliSandogh fm = new FrmHesabTafziliSandogh();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliHesabBanki_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliHesabBanki fm = new FrmHesabTafziliHesabBanki();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliAshkhas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliAshkhas fm = new FrmHesabTafziliAshkhas();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliDaraeha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliDaraeha fm = new FrmHesabTafziliDaraeha();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnJoziatEtelaatAshkhas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEtelaateAshkhas fm = new FrmEtelaateAshkhas();
            //fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            fm.ShowDialog();

        }

        private void btnTafziliProjhe_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliProjhe fm = new FrmHesabTafziliProjhe();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliVam_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliVam fm = new FrmHesabTafziliVam();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliMavad_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliMavad fm = new FrmHesabTafziliMavad();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliGhataat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliGhataat fm = new FrmHesabTafziliGhataat();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliMahsol_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliMahsol fm = new FrmHesabTafziliMahsol();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliKala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliKala fm = new FrmHesabTafziliKala();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliMarakezHazine_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliMarakezHazine fm = new FrmHesabTafziliMarakezHazine();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnTafziliSayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHesabTafziliSayer fm = new FrmHesabTafziliSayer();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnGroupAsliKala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmGroupAsliKala fm = new FrmGroupAsliKala();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnGroupFareeKala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmGroupFareeKala fm = new FrmGroupFareeKala();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);

        }

        private void btnNameKala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmNameKala fm = new FrmNameKala();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }

        private void btnVahedKala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmVahedKala fm = new FrmVahedKala();
            fm.MdiParent = this;
            fm.lblUserId.Text = txtUserId.Caption;
            fm.lblUserName.Text = txtUserName.Caption;
            ActiveForm(fm);
        }
    }
}
