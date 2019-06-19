/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmDoreMaliList.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   04:08 ب.ظ
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
using DevExpress.XtraEditors;
using HelpClassLibrary;
using DevExpress.XtraBars;
using DBHesabdari_PG;
using System.Data.Entity;

namespace EtelaatePaye.DafaterMali
{
    public partial class FrmDorehaList : DevExpress.XtraEditors.XtraForm
    {
        public FrmDorehaList()
        {
            InitializeComponent();
        }

        public void FillDorehaiMaliList()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (isActive == true)
                    {
                        var q1 = dataContext.MsDoreMalis.Where(s => s.DoreMaliIsActive == true).OrderBy(s => s.DoreMaliCode).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                msDoreMalisBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            //var q2 = q1.Select(s => s.MsDoreMaliId).ToList(); ;
                            var q3 = dataContext.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.DoreMaliId > 0 && s.IsActive == true).Select(s => s.DoreMaliId).ToList();
                            if (q1.Count > 0)
                            {
                                if (q3.Count > 0)
                                {
                                    q3.ForEach(item3 =>
                                    {
                                        q1.Remove(dataContext.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == item3));
                                    });
                                    msDoreMalisBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    msDoreMalisBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.MsDoreMalis.Where(p => p.DoreMaliIsActive == false).OrderBy(s => s.DoreMaliCode);
                            if (q.ToList().Count() > 0)
                                msDoreMalisBindingSource.DataSource = q.ToList();
                            else
                                msDoreMalisBindingSource.DataSource = null;
                        }
                        else
                            msDoreMalisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public bool isActive = true;
        public EnumCED En;
        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDorehaCed fm = new FrmDorehaCed(this);
            En = EnumCED.Create;
            HelpClass1.FormNewRecordCreate(fm);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmDorehaCed fm = new FrmDorehaCed(this);
                En = EnumCED.Edit;
                HelpClass1.FormCurrentRecordEdit(gridView1, fm);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmDorehaCed fm = new FrmDorehaCed(this);
                En = EnumCED.Delete;
                HelpClass1.FormCurrentRecordDelete(gridView1, fm);
            }
        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        private void btnAdvancedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;

        }

        public void btnDisplyActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = true;
            FillDorehaiMaliList();
        }

        public void btnDisplyNotActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = false;
            FillDorehaiMaliList();
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

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);
        }

        private void FrmDorehaList_Load(object sender, EventArgs e)
        {
            FillDorehaiMaliList();
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(lblUserId.Text);
                    var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010401) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010402) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010403) ? BarItemVisibility.Never : BarItemVisibility.Always;
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