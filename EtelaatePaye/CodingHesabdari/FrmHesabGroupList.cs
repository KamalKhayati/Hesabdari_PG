/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabGroupList.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 7   10:36 ب.ظ
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
using DBHesabdari_TG;
using System.Data.Entity;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabGroupList : DevExpress.XtraEditors.XtraForm
    {
       public EnumCED En;
        public FrmHesabGroupList()
        {
            InitializeComponent();
        }
        public void FillHesabGroupList()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (isActive == true)
                    {
                        var q1 = dataContext.EpHesabGroups.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epHesabGroupsBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                            if (q1.Count > 0)
                            {
                                if (q2.Count > 0)
                                {
                                    q2.ForEach(item3 =>
                                    {
                                        q1.Remove(dataContext.EpHesabGroups.FirstOrDefault(s => s.Id == item3));
                                    });
                                    epHesabGroupsBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    epHesabGroupsBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpHesabGroups.Where(p => p.IsActive == false).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                epHesabGroupsBindingSource.DataSource = q.ToList();
                            else
                                epHesabGroupsBindingSource.DataSource = null;
                        }
                        else
                            epHesabGroupsBindingSource.DataSource = null;
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
        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmHesabGroupCed fm = new FrmHesabGroupCed(this);
            En = EnumCED.Create;
            HelpClass1.FormNewRecordCreate(fm);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmHesabGroupCed fm = new FrmHesabGroupCed(this);
                En = EnumCED.Edit;
                HelpClass1.FormCurrentRecordEdit(gridView1, fm);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmHesabGroupCed fm = new FrmHesabGroupCed(this);
                En = EnumCED.Delete;
                HelpClass1.FormCurrentRecordDelete(gridView1, fm);
            }
        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass1.PrintPreview(gridControl1, gridView1);
        }

        public void btnDisplyActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = true;
            FillHesabGroupList();
        }

        public void btnDisplyNotActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = false;
            FillHesabGroupList();
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

        private void FrmHesabGroupList_Load(object sender, EventArgs e)
        {
            FillHesabGroupList();
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

        private void btnAdvancedSearch_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;
        }

        private void btnSharhHesab_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible==false ? true : false;
        }
    }
}