/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmUsersList.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   11:47 ب.ظ
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
using HelpClassLibrary;
using DBHesabdari_TG;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace SystemManagement.UsersSystem
{
    public partial class FrmUsersList : DevExpress.XtraEditors.XtraForm
    {
        public FrmUsersList()
        {
            InitializeComponent();
        }

        public void FillUsersList()
        {
            using (var dbContext = new MyContext())
            {
                try
                {
                    if (isActive == true)
                    {
                        if (lblUserId.Text == "1")
                        {
                            dbContext.MsUsers.Where(p => p.UserIsActive == true).OrderBy(s => s.UserCode).Load();
                                msUsersBindingSource.DataSource = dbContext.MsUsers.Local.ToBindingList();
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            dbContext.MsUsers.Where(p => p.UserIsActive == true && p.MsUserId == _UserId).OrderBy(s => s.UserCode).Load();
                                msUsersBindingSource.DataSource = dbContext.MsUsers.Local.ToBindingList(); 
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            dbContext.MsUsers.Where(p => p.UserIsActive == false).OrderBy(s => s.UserCode).Load();
                                msUsersBindingSource.DataSource = dbContext.MsUsers.Local.ToBindingList(); ;
                        }
                        else
                        {
                            msUsersBindingSource.DataSource = null;
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

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUsersCed fm = new FrmUsersCed(this);
            HelpClass1.FormNewRecordCreate(fm);

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmUsersCed fm = new FrmUsersCed(this);
                HelpClass1.FormCurrentRecordEdit(gridView1, fm);
            }

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmUsersCed fm = new FrmUsersCed(this);
                HelpClass1.FormCurrentRecordDelete(gridView1, fm);
            }

        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);

        }


        public bool isActive = true;
        public void btnDisplyActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = true;
            FillUsersList();
        }

        public void btnDisplyNotActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = false;
            FillUsersList();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEdit_ItemClick(null, null);
            }
        }

        private void btnAdvancedSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        private void FrmUsersList_Load(object sender, EventArgs e)
        {
            FillUsersList();
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(lblUserId.Text);
                    var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55311) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55312) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55313) ? BarItemVisibility.Never : BarItemVisibility.Always;
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
