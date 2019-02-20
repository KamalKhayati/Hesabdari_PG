/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmMajmoehaList.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   03:53 ب.ظ
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


namespace EtelaatePaye.DafaterMali
{
    public partial class FrmMajmoehaList : DevExpress.XtraEditors.XtraForm
    {
        public FrmMajmoehaList()
        {
            InitializeComponent();
        }
        public void FillMajmoehaList()
        {
            using (var dataContext = new MyContext())
            {
                try
                {
                    if (isActive == true)
                    {
                        var q1 = dataContext.MsMajmoes.Where(s => s.MajmoeIsActive == true).OrderBy(s => s.MajmoeCode).ToList();
                        if (lblUserId.Text == "1")
                        {
                            if (q1.Count > 0)
                                msMajmoesBindingSource.DataSource = q1;
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            //var q2 = q1.Select(s => s.MsMajmoeId).ToList(); ;
                            var q3 = dataContext.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId && s.VahedId == 0 && s.IsActive == true).Select(s => s.MajmoeId).ToList();
                            if (q1.Count > 0)
                            {
                                if (q3.Count > 0)
                                {
                                    q3.ForEach(item3 =>
                                    {
                                        q1.Remove(dataContext.MsMajmoes.FirstOrDefault(s => s.MsMajmoeId == item3));
                                    });
                                    msMajmoesBindingSource.DataSource = q1;
                                }
                                else
                                {
                                    msMajmoesBindingSource.DataSource = q1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblUserId.Text == "1")
                        {
                            var q = dataContext.MsMajmoes.Where(p => p.MajmoeIsActive == false).OrderBy(s => s.MajmoeCode);
                            if (q.ToList().Count() > 0)
                                msMajmoesBindingSource.DataSource = q.ToList();
                            else
                                msMajmoesBindingSource.DataSource = null;
                        }
                        else
                            msMajmoesBindingSource.DataSource = null;
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
            FrmMajmoehaCed fm = new FrmMajmoehaCed(this);
            En = EnumCED.Create;
            HelpClass1.FormNewRecordCreate(fm);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmMajmoehaCed fm = new FrmMajmoehaCed(this);
                En = EnumCED.Edit;
                HelpClass1.FormCurrentRecordEdit(gridView1, fm);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmMajmoehaCed fm = new FrmMajmoehaCed(this);
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
            FillMajmoehaList();
        }

        public void btnDisplyNotActiveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isActive = false;
            FillMajmoehaList();
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

        private void FrmMajmoehaList_Load(object sender, EventArgs e)
        {
            FillMajmoehaList();
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(lblUserId.Text);
                    var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010101) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010102) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55010103) ? BarItemVisibility.Never : BarItemVisibility.Always;
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
