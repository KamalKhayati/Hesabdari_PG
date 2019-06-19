/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmGroupTafziliList.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 17   11:55 ق.ظ
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
using System.Data.Entity;
using DevExpress.XtraBars;
using DBHesabdari_PG;
using HelpClassLibrary;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmGroupTafziliList : DevExpress.XtraEditors.XtraForm
    {
        public FrmGroupTafziliList()
        {
            InitializeComponent();
        }

        public EnumCED En;
        public bool isActive = true;
        public void FillGroupTafziliList()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (isActive == true)
                    {
                        var q1 = dataContext.EpGroupTafzilis.Where(s => s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                epGroupTafzilisBindingSource.DataSource = q1;
                            else
                                epGroupTafzilisBindingSource.DataSource = null;
                        }
                        //else
                        //{
                        //    int _UserId = Convert.ToInt32(lblUserId.Text);
                        //    var q2 = dataContext.RmsUserBepAccessLevelCodingHesabdaris.Where(s => s.UserId == _UserId && s.HesabColId == 0 && s.IsActive == true).Select(s => s.HesabGroupId).ToList();

                        //    if (q1.Count > 0)
                        //    {
                        //        if (q2.Count > 0)
                        //        {
                        //            q2.ForEach(item3 =>
                        //            {
                        //                q1.Remove(dataContext.EpGroupTafzilis.FirstOrDefault(s => s.Id == item3));
                        //            });
                        //            epGroupTafzilisBindingSource.DataSource = q1;
                        //        }
                        //        else
                        //        {
                        //            epGroupTafzilisBindingSource.DataSource = q1;
                        //        }
                        //    }
                        //    else
                        //        epGroupTafzilisBindingSource.DataSource = null;
                        //}
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.EpGroupTafzilis.Where(p => p.IsActive == false).OrderBy(s => s.Code);
                            if (q.Count() > 0)
                                epGroupTafzilisBindingSource.DataSource = q.ToList();
                            else
                                epGroupTafzilisBindingSource.DataSource = null;
                        }
                        else
                            epGroupTafzilisBindingSource.DataSource = null;
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
            FrmGroupTafziliCed fm = new FrmGroupTafziliCed(this);
            En = EnumCED.Create;
            HelpClass1.FormNewRecordCreate(fm);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmGroupTafziliCed fm = new FrmGroupTafziliCed(this);
                En = EnumCED.Edit;
                HelpClass1.FormCurrentRecordEdit(gridView1, fm);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmGroupTafziliCed fm = new FrmGroupTafziliCed(this);
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
            FillGroupTafziliList();
        }

        public void btnDisplyNotActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = false;
            FillGroupTafziliList();
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
            FillGroupTafziliList();
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
            gridView1.Columns["SharhHesab"].Visible = gridView1.Columns["SharhHesab"].Visible == false ? true : false;
        }

        private void FrmGroupTafziliList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}