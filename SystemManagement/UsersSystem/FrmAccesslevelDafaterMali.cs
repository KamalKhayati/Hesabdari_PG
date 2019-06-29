﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmAccesslevelDafaterMali.cs
*	Project:		SystemManagement
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 20   10:46 AM
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
using DBHesabdari_PG;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraBars;

namespace SystemManagement.UsersSystem
{
    public partial class FrmAccesslevelDafaterMali : DevExpress.XtraEditors.XtraForm
    {
        public FrmAccesslevelDafaterMali()
        {
            InitializeComponent();
        }
        public void FillcmbUsersList()
        {
            using (var dbContext = new MyContext())
            {
                try
                {
                    if (lblUserId.Text == "1")
                    {
                        // This line of code is generated by Data Source Configuration Wizard
                        dbContext.MsUsers.Where(s => s.UserIsActive == true && s.MsUserId != 1).Load();
                        // Bind data to control when loading complete
                        msUserBindingSource.DataSource = dbContext.MsUsers.Local.ToBindingList();
                    }
                    else
                    {
                        int _UserId = Convert.ToInt32(lblUserId.Text);
                        // This line of code is generated by Data Source Configuration Wizard
                        dbContext.MsUsers.Where(s => s.UserIsActive == true && s.MsUserId == _UserId).Load();
                        // Bind data to control when loading complete
                        msUserBindingSource.DataSource = dbContext.MsUsers.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void FilltreeList_DafaterMali()
        {
            using (var dbContext = new MyContext())
            {
                try
                {
                    if (dbContext.MsMajmoes.Any())
                    {
                        // Call the Load method to get the data for the given DbSet from the database.
                        dbContext.MsAccessLevelDafaterMalis.Where(s => s.IsActive == true).OrderBy(s => s.KeyId).Load();
                        // This line of code is generated by Data Source Configuration Wizard
                        msAccessLevelDafaterMalisBindingSource.DataSource = dbContext.MsAccessLevelDafaterMalis.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmAccesslevelDafaterMali_Load(object sender, EventArgs e)
        {
            FillcmbUsersList();
            FilltreeList_DafaterMali();
            //treeListDafaterMali.ExpandAll();

            //using (var db = new MyContext())
            //{
            //    try
            //    {
            //        int _UserId = Convert.ToInt32(lblUserId.Text);
            //        var q1 = db.RmsUserBmsAccessLevelMenus.Where(s => s.MsUserId == _UserId).ToList();
            //        if (q1.Count() > 0)
            //        {
            //            //btnCreate.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55331) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnSave_ListDafaterMali.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 550302021) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //            //btnDelete.Visibility = q1.Any(s => s.MsAccessLevelMenuId == 55333) ? BarItemVisibility.Never : BarItemVisibility.Always;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var q1 = db.RmsUserBmsAccessLevelDafaterMalis.Where(f => f.MsUserId == _UserId).ToList();
                    //for (int i = tabPane1.Pages.Count-1; i >=0; i--)
                    //{
                    //    tabPane1.SelectedPageIndex=i ;
                    //}
                    treeListDafaterMali.CheckAll();
                    //treeListCodingHesabdari.CheckAll();
                    if (q1.Count > 0)
                    {
                        q1.ForEach(item =>
                        {
                            var node1 = treeListDafaterMali.FindNodeByKeyID(item.KeyId);
                            if (node1 != null)
                                treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                        });
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                treeListDafaterMali.ShowRibbonPrintPreview();
        }

        private void treeListDafaterMali_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            int a = Convert.ToInt32(e.Node.GetValue(colKeyId1));
            if (a > 0)
            {
                if (a.ToString().Length == 2)
                {
                    if (treeListDafaterMali.FindNodeByKeyID(a).CheckState == CheckState.Checked)
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 2) == item[colKeyId1].ToString().Substring(0, 2))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                        });
                    }
                    else
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 2) == item[colKeyId1].ToString().Substring(0, 2))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                                }
                            }
                        });
                    }
                }
                else if (a.ToString().Length == 4)
                {
                    if (treeListDafaterMali.FindNodeByKeyID(a).CheckState == CheckState.Checked)
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 4) == item[colKeyId1].ToString().Substring(0, 4))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                            else
                            {
                                if (item[colKeyId1].ToString().Length == 2)
                                {
                                    if (a.ToString().Substring(0, 2) == item[colKeyId1].ToString().Substring(0, 2))
                                    {
                                        var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                        treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                    }
                                }
                            }
                        });
                    }
                    else
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 4) == item[colKeyId1].ToString().Substring(0, 4))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                                }
                            }
                            //else
                            //{
                            //    if (item[colKeyId].ToString().Length == 2)
                            //    {
                            //        if (a.ToString().Substring(0, 2) == item[colKeyId].ToString().Substring(0, 2))
                            //        {
                            //            var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                            //            treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                            //        }
                            //    }
                            //}

                        });
                    }
                }
                else if (a.ToString().Length == 6)
                {
                    if (treeListDafaterMali.FindNodeByKeyID(a).CheckState == CheckState.Checked)
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 6) == item[colKeyId1].ToString().Substring(0, 6))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                            else
                            {
                                if (item[colKeyId1].ToString().Length == 4)
                                {
                                    if (a.ToString().Substring(0, 4) == item[colKeyId1].ToString().Substring(0, 4))
                                    {
                                        var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                        treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                    }
                                }
                                else if (item[colKeyId1].ToString().Length == 2)
                                {
                                    if (a.ToString().Substring(0, 2) == item[colKeyId1].ToString().Substring(0, 2))
                                    {
                                        var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                        treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                    }
                                }
                            }
                        });
                    }
                    else
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (Convert.ToInt32(item[colKeyId1]) > a)
                            {
                                if (a.ToString().Substring(0, 6) == item[colKeyId1].ToString().Substring(0, 6))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                                }
                            }
                            //else
                            //{
                            //    if (item[colKeyId].ToString().Length == 4)
                            //    {
                            //        if (a.ToString().Substring(0, 4) == item[colKeyId].ToString().Substring(0, 4))
                            //        {
                            //            var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                            //            treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                            //        }
                            //    }
                            //    else if (item[colKeyId].ToString().Length == 2)
                            //    {
                            //        if (a.ToString().Substring(0, 2) == item[colKeyId].ToString().Substring(0, 2))
                            //        {
                            //            var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                            //            treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                            //        }
                            //    }
                            //}
                        });
                    }
                }
                else
                {
                    if (treeListDafaterMali.FindNodeByKeyID(a).CheckState == CheckState.Checked)
                    {
                        treeListDafaterMali.GetNodeList().ForEach(item =>
                        {
                            if (item[colKeyId1].ToString().Length == 6)
                            {
                                if (a.ToString().Substring(0, 6) == item[colKeyId1].ToString().Substring(0, 6))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                            else if (item[colKeyId1].ToString().Length == 4)
                            {
                                if (a.ToString().Substring(0, 4) == item[colKeyId1].ToString().Substring(0, 4))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                            else if (item[colKeyId1].ToString().Length == 2)
                            {
                                if (a.ToString().Substring(0, 2) == item[colKeyId1].ToString().Substring(0, 2))
                                {
                                    var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId1]);
                                    treeListDafaterMali.SetNodeCheckState(node1, CheckState.Checked, false);
                                }
                            }
                        });
                    }
                    #region
                    //else
                    //{
                    //    treeListDafaterMali.GetNodeList().ForEach(item =>
                    //    {
                    //        if (item[colKeyId].ToString().Length == 6)
                    //        {
                    //            if (a.ToString().Substring(0, 6) == item[colKeyId].ToString().Substring(0, 6))
                    //            {
                    //                var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                    //                treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                    //            }
                    //        }
                    //        else if (item[colKeyId].ToString().Length == 4)
                    //        {
                    //            if (a.ToString().Substring(0, 4) == item[colKeyId].ToString().Substring(0, 4))
                    //            {
                    //                var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                    //                treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                    //            }
                    //        }
                    //        else if (item[colKeyId].ToString().Length == 2)
                    //        {
                    //            if (a.ToString().Substring(0, 2) == item[colKeyId].ToString().Substring(0, 2))
                    //            {
                    //                var node1 = treeListDafaterMali.FindNodeByKeyID(item[colKeyId]);
                    //                treeListDafaterMali.SetNodeCheckState(node1, CheckState.Unchecked, false);
                    //            }
                    //        }
                    //    });

                    //}
                    #endregion

                }
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _UserId = Convert.ToInt32(cmbUsersList.EditValue);
                    /////////////////////////// ویرایش سطح دسترسی کاربران به لیست دفاتر مالی /////////////////////////////
                    var q = db.RmsUserBmsAccessLevelDafaterMalis.Where(s => s.MsUserId == _UserId).ToList();
                    if (q.Count > 0)
                    {
                        db.RmsUserBmsAccessLevelDafaterMalis.RemoveRange(q);
                    }

                    foreach (var item in treeListDafaterMali.GetNodeList().Except(treeListDafaterMali.GetAllCheckedNodes()))
                    {
                        if (item.CheckState == CheckState.Unchecked)
                        {
                            RmsUserBmsAccessLevelDafaterMali obj1 = new RmsUserBmsAccessLevelDafaterMali();
                            obj1.MsUserId = _UserId;
                            obj1.Name = cmbUsersList.Edit.GetDisplayText(cmbUsersList.EditValue);
                            obj1.MsAccessLevelDafaterMaliId = Convert.ToInt32(item.GetValue(colMsAccessLevelDafaterMaliId1));
                            obj1.KeyId = Convert.ToInt32(item.GetValue(colKeyId1));
                            obj1.MajmoeId = Convert.ToInt32(item.GetValue(colMajmoeId1));
                            obj1.VahedId = Convert.ToInt32(item.GetValue(colVahedId1));
                            obj1.ShobeId = Convert.ToInt32(item.GetValue(colShobeId1));
                            obj1.DoreMaliId = Convert.ToInt32(item.GetValue(colDoreMaliId1));
                            obj1.IsActive = Convert.ToBoolean(item.GetValue(colIsActive1));

                            db.RmsUserBmsAccessLevelDafaterMalis.Add(obj1);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////
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

        private void chkSelectAll_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chkSelectAll.Checked)
                treeListDafaterMali.CheckAll();
            else
                treeListDafaterMali.UncheckAll();
        }

        private void chkOpenClose_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chkOpenClose.Checked)
                treeListDafaterMali.ExpandAll();
            else
                treeListDafaterMali.CollapseAll();
        }

    }
}