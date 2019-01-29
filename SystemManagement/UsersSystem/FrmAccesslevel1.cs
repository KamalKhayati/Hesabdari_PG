﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmAccess level.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 11   10:49 ق.ظ
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
using DevExpress.XtraTreeList;
using DBHesabdari_TG;
using DevExpress.XtraBars;

namespace SystemManagement.UsersSystem
{
    public partial class FrmAccesslevel1 : DevExpress.XtraEditors.XtraForm
    {
        public FrmAccesslevel1()
        {
            InitializeComponent();
        }

        //private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        //{
        //    //TreeList tree = sender as TreeList;
        //    //if (e.Node==tree.FocusedNode)
        //    //{
        //    //    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
        //    //    Rectangle rect = new Rectangle(e.EditViewInfo.ContentRect.Right,
        //    //        e.EditViewInfo.ContentRect.Top,
        //    //        Convert.ToInt32(e.Graphics.MeasureString(e.CellText, treeList1.Font).Width + 1),
        //    //        Convert.ToInt32(e.Graphics.MeasureString(e.CellText, treeList1.Font).Height));
        //    //    e.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
        //    //    e.Graphics.DrawString(e.CellText, treeList1.Font, SystemBrushes.HighlightText, rect);
        //    //    e.Handled = true;
        //    //}
        //}

        public void FillTreeList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsAccessLevelMenus.Any())
                    {
                        // This line of code is generated by Data Source Configuration Wizard
                        db.MsAccessLevelMenus.Load();
                        // Bind data to control when loading complete
                        msAccessLevelMenusBindingSource.DataSource = db.MsAccessLevelMenus.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void FillcmbUsersList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsUsers.Any())
                    {
                        if (lblUserId.Text == "1")
                        {
                            // This line of code is generated by Data Source Configuration Wizard
                            db.MsUsers.Where(s => s.UserIsActive == true && s.MsUserId != 1).Load();
                            // Bind data to control when loading complete
                            msUserBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
                        }
                        else
                        {
                            int _UserId = Convert.ToInt32(lblUserId.Text);
                            // This line of code is generated by Data Source Configuration Wizard
                            db.MsUsers.Where(s => s.UserIsActive == true && s.MsUserId == _UserId).Load();
                            // Bind data to control when loading complete
                            msUserBindingSource.DataSource = db.MsUsers.Local.ToBindingList();
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
            //if (cmbUsersList.EditValue == null)
            //{
            //    XtraMessageBox.Show("لطفا نام کاربر مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            ////else if (!treeList1.GetAllCheckedNodes().Any())
            ////{
            ////    XtraMessageBox.Show("هیچگونه سطح دسترسی برای این کاربر تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    return;
            ////}
            //else
            //{
            //    using (var db = new MyContext())
            //    {
            //        try
            //        {
            //            int _UserId = Convert.ToInt32(cmbUsersList.EditValue);
            //            var q = db.RmsUserhaBmsAccessLevelMenuhas.Where(s => s.MsUserId == _UserId).ToList();
            //            if (q.Count > 0)
            //            {
            //                XtraMessageBox.Show("قبلاً سطح دسترسی برای این کاربر ایجاد شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //            else
            //            {
            //                foreach (var item in treeList1.GetAllCheckedNodes())
            //                {
            //                    RmsUserhaBmsAccessLevelMenuha obj1 = new RmsUserhaBmsAccessLevelMenuha();
            //                    obj1.MsUserId = _UserId;
            //                    obj1.UserName = cmbUsersList.Edit.GetDisplayText(cmbUsersList.EditValue);
            //                    obj1.MsAccessLevelMenuId = Convert.ToInt32(item.GetValue(MsAccessLevelMenuId));
            //                    obj1.LevelName = item.GetDisplayText(LevelName);
            //                    db.RmsUserhaBmsAccessLevelMenuhas.Add(obj1);
            //                }
            //                db.SaveChanges();
            //                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}
        }

        private void cmbUsersList_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(cmbUsersList.EditValue);
                    var q = db.RmsUserBmsAccessLevelMenus.Where(f => f.MsUserId == _UserId).ToList();
                    if (q.Count > 0)
                    {
                        treeList1.CheckAll();
                        q.ForEach(item =>
                        {
                            var node1 = treeList1.FindNodeByKeyID(item.MsAccessLevelMenuId);
                            if (node1 != null)
                                treeList1.SetNodeCheckState(node1, CheckState.Unchecked, false);
                        });
                    }
                    else
                        treeList1.CheckAll();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCheckAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnCheckAll.Checked)
                treeList1.UncheckAll();
            else
                treeList1.CheckAll();
        }

        private void btnOpenClose_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnOpenClose.Checked)
                treeList1.ExpandAll();
            else
                treeList1.CollapseAll();

        }

        private void FrmAccesslevel1_Load(object sender, EventArgs e)
        {
            FillcmbUsersList();
            FillTreeList();
            treeList1.ExpandAll();

            //treeList1.FindNodeByFieldValue("LevelName", "تولید").Visible = false;
            //treeList1.FindNodeByFieldValue("LevelName", "حقوق ودستمزد").Visible = false;
            //treeList1.FindNodeByFieldValue("LevelName", "اموال").Visible = false;
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(lblUserId.Text);
                    var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                    if (q1.Count() > 0)
                    {
                        //btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55331) ? BarItemVisibility.Always : BarItemVisibility.Never;
                        btnEdit.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55332) ? BarItemVisibility.Always : BarItemVisibility.Never;
                        //btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55333) ? BarItemVisibility.Always : BarItemVisibility.Never;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbUsersList.EditValue == null)
            {
                XtraMessageBox.Show("لطفا نام کاربر مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _UserId = Convert.ToInt32(cmbUsersList.EditValue);
                        var q = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
                        if (q.Count > 0)
                        {
                            db.RmsUserBmsAccessLevelMenus.RemoveRange(q);
                        }

                        foreach (var item in treeList1.GetNodeList().Except(treeList1.GetAllCheckedNodes()))
                        {
                            if (item.CheckState == CheckState.Unchecked)
                            {
                                RmsUserBmsAccessLevelMenu obj1 = new RmsUserBmsAccessLevelMenu();
                                obj1.MsUserId = _UserId;
                                obj1.UserName = cmbUsersList.Edit.GetDisplayText(cmbUsersList.EditValue);
                                obj1.MsAccessLevelMenuId = Convert.ToInt32(item.GetValue(MsAccessLevelMenuId));
                                obj1.LevelName = item.GetDisplayText(LevelName);
                                db.RmsUserBmsAccessLevelMenus.Add(obj1);
                            }
                        }
                        db.SaveChanges();
                        XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (cmbUsersList.EditValue == null)
            //{
            //    XtraMessageBox.Show("لطفا نام کاربر مورد نظر را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    using (var db = new MyContext())
            //    {
            //        try
            //        {
            //            int _UserId = Convert.ToInt32(cmbUsersList.EditValue);
            //            var q = db.RmsUserhaBmsAccessLevelMenuhas.Where(s => s.MsUserId == _UserId).ToList();
            //            if (q.Count == 0)
            //            {
            //                XtraMessageBox.Show("رکوردی برای حذف در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //            else
            //            {
            //                db.RmsUserhaBmsAccessLevelMenuhas.RemoveRange(q);
            //                if (XtraMessageBox.Show("آیا دسترسی های این کاربر حذف شود", "پیغام", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //                {
            //                    db.SaveChanges();
            //                    treeList1.UncheckAll();
            //                    XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }

            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}

        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.ShowRibbonPrintPreview();

        }

        private void btnListPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.Print();

        }
    }
}
