/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmHesabMoinCed.cs
*	Project:		EtelaatePaye
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 10   14:06
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
using DBHesabdari_TG;
using HelpClassLibrary;
using System.Data.Entity.Infrastructure;

namespace EtelaatePaye.CodingHesabdari
{
    public partial class FrmHesabMoinCed : DevExpress.XtraEditors.XtraForm
    {
        FrmHesabMoinList Fm;
        public FrmHesabMoinCed(FrmHesabMoinList fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        MyContext db1 = new MyContext();
        public void FillcmbHesabGroupList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabGroups.Any())
                    {
                        if (Fm.isActive == true)
                        {
                            db.EpHesabGroups.Where(s => s.IsActive == true).Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabGroups.Load();
                            epHesabGroupsBindingSource.DataSource = db.EpHesabGroups.Local.ToBindingList();
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
        public void FillcmbHesabColList()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpHesabCols.Any())
                    {
                        int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                        if (Fm.isActive == true)
                        {
                            db.EpHesabCols.Where(s => s.IsActive == true && s.GroupId == _GroupId).Load();
                            epHesabColsBindingSource.DataSource = db.EpHesabCols.Local.ToBindingList();
                        }
                        else
                        {
                            db.EpHesabCols.Where(s => s.GroupId == _GroupId).Load();
                            epHesabColsBindingSource.DataSource = db.EpHesabCols.Local.ToBindingList();
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
        public void FillGridViewSharhStandard()
        {
            //using (var db = new MyContext())
            //{
            try
            {
                if (db1.EpSharhStandardMoins.Any())
                {
                    int RowId = Convert.ToInt32(txtId.Text);
                    db1.EpSharhStandardMoins.Where(s => s.MoinId == RowId).Load();
                    EpSharhStandardMoinsBindingSource.DataSource = db1.EpSharhStandardMoins.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                    "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}

        }
        public void FillListBoxActiveSystem()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.MsActiveSystems.Any())
                    {
                        db.MsActiveSystems.Where(s => s.IsActive == true).Load();
                        msActiveSystemsBindingSource.DataSource = db.MsActiveSystems.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillListBoxLevel1()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (db.EpGroupTafzilis.Any())
                    {
                        db.EpGroupTafzilis.Where(s => s.IsActive == true).Load();
                        epGroupTafzilisBindingSource.DataSource = db.EpGroupTafzilis.Local.ToBindingList();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (cmbListHesabCol.EditValue != null)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.EpHesabMoins.Where(s => s.ColId == _ColId);
                        if (q.Any())
                        {
                            var MaximumCod = q.Max(p => p.Code);
                            if (MaximumCod.ToString().Substring(2) != "99")
                                txtCode.Text = (MaximumCod + 1).ToString().Substring(2);
                            else
                            {
                                if (Fm.En == EnumCED.Create)
                                    XtraMessageBox.Show("اعمال محدودیت تعریف 99 حساب معین برای هر حساب کل ..." + "\n" +
                                        "توجه : نمیتوان بیشتر از 99 حساب معین برای هر حساب کل تعریف کرد مگر اینکه در صورت امکان از کدهای خالی مابین 1 تا 99 استفاده نمایید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtCode.Text = "01";
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        int GroupIdBeforeEdit = 0;
        int ColIdBeforeEdit = 0;
        string CodeBeforeEdit = "";
        string NameBeforeEdit = "";
        bool IsActiveBeforeEdit;
        private void FrmHesabColCed_Load(object sender, EventArgs e)
        {
            FillcmbHesabGroupList();
            FillListBoxLevel1();
            FillListBoxActiveSystem();
            chkListBoxActiveSystem.CheckAll();
            if (Fm.lblUserId.Text == "1")
                chkIsActive.Visible = true;

            if (Fm.En != EnumCED.Create)
            { 
                cmbListHesabGroup.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("GroupId").ToString());
                cmbListHesabCol.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("ColId").ToString());
                txtId.Text = Fm.gridView1.GetFocusedRowCellValue("Id").ToString();
                txtCode.Text = Fm.gridView1.GetFocusedRowCellValue("Code").ToString().Substring(2);
                txtName.Text = Fm.gridView1.GetFocusedRowCellValue("Name").ToString();
                cmbMahiatHesab.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexMahiatHesab").ToString());
                chkIsActive.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsActive"));
                txtSharhHesab.Text = Fm.gridView1.GetFocusedRowCellValue("SharhHesab").ToString();

                GroupIdBeforeEdit = Convert.ToInt32(cmbListHesabGroup.EditValue);
                ColIdBeforeEdit = Convert.ToInt32(cmbListHesabCol.EditValue);
                CodeBeforeEdit = txtCode.Text;
                NameBeforeEdit = txtName.Text;
                IsActiveBeforeEdit = chkIsActive.Checked;

                if (txtCode.Text == "99")
                    btnNewCode.Enabled = false;

                FillGridViewSharhStandard();
                using (var db = new MyContext())
                {
                    try
                    {
                        int RowId = Convert.ToInt32(txtId.Text);
                        var q = db.RMsActiveSystemBEpHesabMoins.Where(f => f.MoinId == RowId).Select(f => f.ActiveSystemId).ToList();
                        if (q.Count > 0)
                        {
                            if (chkListBoxActiveSystem.DataSource != null)
                            {
                                q.ForEach(item =>
                                {
                                    for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                    {
                                        if (Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i)) == item)

                                            chkListBoxActiveSystem.SetItemCheckState(i, CheckState.Unchecked);
                                    }
                                });
                            }
                        }
                        ////////////////////////////////////////////////////////////////
                        var q1 = db.REpHesabMoinBEpGroupTafziliLevel1s.Where(f => f.MoinId == RowId && f.NumberLevel == 1).Select(f => f.GroupTafziliId).ToList();
                        if (q1.Count > 0)
                        {
                            if (chkListBoxLevel1.DataSource != null)
                            {
                                q1.ForEach(item =>
                                {
                                    for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                    {
                                        if (Convert.ToInt32(chkListBoxLevel1.GetItemValue(i)) == item)

                                            chkListBoxLevel1.SetItemCheckState(i, CheckState.Checked);
                                    }
                                });
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
        }

        private void btnCreateNext_Click(object sender, EventArgs e)
        {
            btnCreateCloseClicked = false;
            btnCreateClose_Click(null, null);
            btnCreateCloseClicked = true;
        }

        bool btnCreateCloseClicked = true;
        private void btnCreateClose_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                btnCreateClose.Enabled = false;
                btnCreateNext.Enabled = false;
                if (Fm.En == EnumCED.Create)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            EpHesabMoin obj = new EpHesabMoin();
                            obj.Code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                            obj.Name = txtName.Text;
                            obj.IsActive = chkIsActive.Checked;
                            obj.GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                            obj.GroupName = cmbListHesabGroup.Text;
                            obj.ColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                            obj.ColName = cmbListHesabCol.Text;
                            obj.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                            obj.MahiatHesab = cmbMahiatHesab.Text;
                            obj.SharhHesab = txtSharhHesab.Text;
                            string ActiveSystem = string.Empty;
                            for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                            {
                                if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                {
                                    ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                }
                            }
                            obj.SelectedActivesystem = ActiveSystem;
                            string GroupTafzili = string.Empty;
                            for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                            {
                                if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                {
                                    GroupTafzili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                }
                            }
                            obj.SelectedGroupTafziliLevel1 = GroupTafzili;

                            db.EpHesabMoins.Add(obj);
                            db.SaveChanges();
                            //////////////////////////////////////////////////////////////////////////////////////
                            int _code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                            var q = db.EpHesabMoins.FirstOrDefault(s => s.Code == _code);
                            int RowId = q.Id;
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                obj1.Name = gridView1.GetRowCellDisplayText(i, "Name");
                                obj1.MoinId = RowId;
                                db.EpSharhStandardMoins.Add(obj1);
                            }
                            /////////////////////////////////////////////////////////////////////////////////////
                            for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                            {
                                if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                {
                                    RMsActiveSystemBEpHesabMoin obj1 = new RMsActiveSystemBEpHesabMoin();
                                    obj1.ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));
                                    obj1.MoinId = RowId;
                                    db.RMsActiveSystemBEpHesabMoins.Add(obj1);
                                }
                            }
                            /////////////////////////////////////////////////////////////////////////////////////
                            for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                            {
                                if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                {
                                    REpHesabMoinBEpGroupTafziliLevel1 obj1 = new REpHesabMoinBEpGroupTafziliLevel1();
                                    obj1.GroupTafziliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));
                                    obj1.MoinId = RowId;
                                    obj1.NumberLevel = 1;
                                    db.REpHesabMoinBEpGroupTafziliLevel1s.Add(obj1);
                                }
                            }
                            ////////////////////////////////////// اضافه کردن حساب کل به کلاس سطح دسترسی کدینگ حسابداری ////////////////////
                            EpAccessLevelCodingHesabdari n1 = new EpAccessLevelCodingHesabdari();
                            n1.KeyId = _code;
                            n1.ParentId = Convert.ToInt32(txtColCode.Text);
                            n1.LevelName = txtName.Text;
                            n1.HesabGroupId = q.GroupId;
                            n1.HesabColId = q.ColId;
                            n1.HesabMoinId = q.Id;
                            n1.IsActive = chkIsActive.Checked;
                            db.EpAccessLevelCodingHesabdaris.Add(n1);
                            /////////////////////////////////////////////////////////////////////////////////////
                            db.SaveChanges();
                            if (chkIsActive.Checked)
                                Fm.btnDisplyActiveList_ItemClick(null, null);
                            else
                                Fm.btnDisplyNotActiveList_ItemClick(null, null);
                            XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                            Fm.gridView1.MoveLast();
                            if (btnCreateCloseClicked)
                                this.Close();
                            else
                            {
                                btnCreateClose.Enabled = true;
                                btnCreateNext.Enabled = true;
                                //cmbListHesabGroup.EditValue = Convert.ToInt32(cmbListHesabGroup.EditValue);
                                btnNewCode_Click(null, null);
                                txtSharhHesab.Text = string.Empty;
                                cmbMahiatHesab.EditValue = string.Empty;
                                txtName.Text = string.Empty;
                                txtName.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (Fm.En == EnumCED.Edit)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int _GroupId = Convert.ToInt32(cmbListHesabGroup.EditValue);
                            string _GroupName = cmbListHesabGroup.Text;
                            int _ColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                            string _ColName = cmbListHesabCol.Text;
                            string _Name = txtName.Text;
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabMoins.FirstOrDefault(p => p.Id == RowId);
                            if (q != null)
                            {
                                q.Code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                q.Name = _Name;
                                q.GroupId = _GroupId;
                                q.GroupName = _GroupName;
                                q.ColId = _ColId;
                                q.ColName = _ColName;
                                q.IsActive = chkIsActive.Checked;
                                q.IndexMahiatHesab = cmbMahiatHesab.SelectedIndex;
                                q.MahiatHesab = cmbMahiatHesab.Text;
                                q.SharhHesab = txtSharhHesab.Text;

                                string ActiveSystem = string.Empty;
                                for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                {
                                    if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        ActiveSystem += chkListBoxActiveSystem.GetDisplayItemValue(i).ToString() + ",";
                                    }
                                }
                                q.SelectedActivesystem = ActiveSystem;
                                string GroupTafzili = string.Empty;
                                for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                {
                                    if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        GroupTafzili += chkListBoxLevel1.GetDisplayItemValue(i).ToString() + ",";
                                    }
                                }
                                q.SelectedGroupTafziliLevel1 = GroupTafzili;
                                ////////////////////////////////////////////////////////////////////////////////
                                var q1 = db.EpSharhStandardMoins.Where(s => s.MoinId == RowId).ToList();
                                if (q1.Count > 0)
                                {
                                    db.EpSharhStandardMoins.RemoveRange(q1);
                                }

                                for (int i = 0; i < gridView1.RowCount; i++)
                                {
                                    EpSharhStandardMoin obj1 = new EpSharhStandardMoin();
                                    obj1.Name = gridView1.GetRowCellDisplayText(i, "Name");
                                    obj1.MoinId = RowId;
                                    db.EpSharhStandardMoins.Add(obj1);
                                }
                                /////////////////////////////////////////////////////////////////////////////////////
                                var q2 = db.RMsActiveSystemBEpHesabMoins.Where(s => s.MoinId == RowId).ToList();
                                if (q2.Count > 0)
                                {
                                    db.RMsActiveSystemBEpHesabMoins.RemoveRange(q2);
                                }
                                for (int i = 0; i < chkListBoxActiveSystem.ItemCount; i++)
                                {
                                    if (chkListBoxActiveSystem.GetItemCheckState(i) == CheckState.Unchecked)
                                    {
                                        RMsActiveSystemBEpHesabMoin obj1 = new RMsActiveSystemBEpHesabMoin();
                                        obj1.ActiveSystemId = Convert.ToInt32(chkListBoxActiveSystem.GetItemValue(i));
                                        obj1.MoinId = RowId;
                                        db.RMsActiveSystemBEpHesabMoins.Add(obj1);
                                    }
                                }
                                /////////////////////////////////////////////////////////////////////////////////////
                                var q3 = db.REpHesabMoinBEpGroupTafziliLevel1s.Where(s => s.MoinId == RowId && s.NumberLevel == 1).ToList();
                                if (q3.Count>0)
                                {
                                    db.REpHesabMoinBEpGroupTafziliLevel1s.RemoveRange(q3);
                                }
                                for (int i = 0; i < chkListBoxLevel1.ItemCount; i++)
                                {
                                    if (chkListBoxLevel1.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        REpHesabMoinBEpGroupTafziliLevel1 obj1 = new REpHesabMoinBEpGroupTafziliLevel1();
                                        obj1.GroupTafziliId = Convert.ToInt32(chkListBoxLevel1.GetItemValue(i));
                                        obj1.MoinId = RowId;
                                        obj1.NumberLevel = 1;
                                        db.REpHesabMoinBEpGroupTafziliLevel1s.Add(obj1);
                                    }
                                }
                                ///////////////////////////////متد اصلاح کد و نام در لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate ///////////////////////
                                var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabMoinId == RowId);
                                if (q8 != null)
                                {
                                    if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        q8.KeyId = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                    if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        q8.ParentId = Convert.ToInt32(txtColCode.Text);
                                    if (NameBeforeEdit != txtName.Text)
                                        q8.LevelName = txtName.Text;
                                    if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        q8.HesabGroupId = _GroupId;
                                    if (ColIdBeforeEdit != Convert.ToInt32(cmbListHesabCol.EditValue))
                                        q8.HesabColId = _ColId;
                                    if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        q8.IsActive = chkIsActive.Checked;
                                }
                                /////////////////////////////////////////متد اصلاح کد و نام در جدول رابطه بین کاربران و لیست سطح دسترسی به کدینگ حسابداری  WillCascadeOnUpdate////////////////////////////////////// 
                                var q9 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabMoinId == RowId);
                                if (q9 != null)
                                {
                                    if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue) || CodeBeforeEdit != txtCode.Text)
                                        q9.KeyId = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                    if (GroupIdBeforeEdit != Convert.ToInt32(cmbListHesabGroup.EditValue))
                                        q9.HesabGroupId = _GroupId;
                                    if (ColIdBeforeEdit != Convert.ToInt32(cmbListHesabCol.EditValue))
                                        q9.HesabColId = _ColId;
                                    if (IsActiveBeforeEdit != chkIsActive.Checked)
                                        q9.IsActive = chkIsActive.Checked;
                                }
                                //////////////////////////////////////////////////////////////////////////////////////
                                if (IsActiveBeforeEdit == false && chkIsActive.Checked == true)
                                {
                                    var m1 = db.EpHesabGroups.FirstOrDefault(p => p.Id == _GroupId);
                                    var m2 = db.EpHesabCols.FirstOrDefault(p => p.Id == _ColId);
                                    var a1 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    var a2 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == _ColId && p.HesabMoinId == 0);
                                    var b1 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == 0);
                                    var b2 = db.RmsUserBepAccessLevelCodingHesabdaris.FirstOrDefault(p => p.HesabGroupId == _GroupId && p.HesabColId == _ColId && p.HesabMoinId == 0);
                                    if (m1 != null)
                                        m1.IsActive = true;
                                    if (m2 != null)
                                        m2.IsActive = true;
                                    if (a1 != null)
                                        a1.IsActive = true;
                                    if (a2 != null)
                                        a2.IsActive = true;
                                    if (b1 != null)
                                        b1.IsActive = true;
                                    if (b2 != null)
                                        b2.IsActive = true;
                                }

                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                else
                                    Fm.btnDisplyNotActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                if (Fm.gridView1.RowCount > 0)
                                    Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (Fm.En == EnumCED.Delete)
                {
                    using (var db = new MyContext())
                    {
                        try
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.EpHesabMoins.FirstOrDefault(p => p.Id == RowId);
                            var q8 = db.EpAccessLevelCodingHesabdaris.FirstOrDefault(s => s.HesabMoinId == RowId);
                            if (q != null && q8 != null)
                            {
                                db.EpHesabMoins.Remove(q);
                                db.EpAccessLevelCodingHesabdaris.Remove(q8);
                                /////////////////////////////////////////////////////////////////////////////
                                db.SaveChanges();

                                if (IsActiveBeforeEdit)
                                    Fm.btnDisplyActiveList_ItemClick(null, null);
                                else
                                    Fm.btnDisplyNotActiveList_ItemClick(null, null);
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                                if (Fm.gridView1.RowCount > 0)
                                    Fm.gridView1.FocusedRowHandle = HelpClass1.EditRowIndex - 1;
                            }
                            else
                                XtraMessageBox.Show("رکورد جاری در بانک اطلاعاتی موجود نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (DbUpdateException)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد \n حذف این حساب معین مقدور نیست \n" +
                                " جهت حذف حساب معین در ابتدا بایستی ارتباط این حساب با گروه های تفضیلی حذف گردد" +
                                "", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("لطفا کد حساب را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabMoins.Any())
                            {
                                int _code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                                var q1 = db.EpHesabMoins.Where(p => p.Code == _code);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnNewCode_Click(null, null);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            int _code = Convert.ToInt32(txtColCode.Text + txtCode.Text);
                            var q1 = db.EpHesabMoins.Where(p => p.Id != RowId && p.Code == _code);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCode.Text = CodeBeforeEdit;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            ////////////////// اعتبار سنجی تکس باکس و کمبوباکس ها////////////

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "0" || string.IsNullOrEmpty(cmbListHesabGroup.Text) || string.IsNullOrEmpty(cmbListHesabCol.Text))
            {
                XtraMessageBox.Show("لطفاً اطلاعات را کامل وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        if (Fm.En == EnumCED.Create)
                        {
                            if (db.EpHesabMoins.Any())
                            {
                                var q1 = db.EpHesabMoins.Where(p => p.Name == txtName.Text);
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else if (Fm.En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q1 = db.EpHesabMoins.Where(p => p.Id != RowId && p.Name == txtName.Text);
                            if (q1.Any())
                            {
                                XtraMessageBox.Show("این نام قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //txtName.Text = nameBeforeEdit;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            if (Fm.En == EnumCED.Create)
            {
                if (cmbMahiatHesab.Text == string.Empty)
                {
                    XtraMessageBox.Show("لطفاً ماهیت حساب را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        int _ColId = 0;
        private void cmbListHesabGroup_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabColList();
            cmbListHesabCol.EditValue = string.Empty;
            txtColCode.Text = txtCode.Text = string.Empty;
        }

        private void cmbListHesabCol_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    _ColId = Convert.ToInt32(cmbListHesabCol.EditValue);
                    var q = db.EpHesabCols.FirstOrDefault(s => s.Id == _ColId).Code;
                    if (q > 0)
                        txtColCode.Text = q.ToString();

                    btnNewCode_Click(null, null);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbListHesabGroup_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbListHesabGroup.ShowPopup();
            }
        }

        private void cmbListHesabCol_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbListHesabCol.ShowPopup();
            }
        }

        private void FrmHesabMoinCed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnCreateClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnCreateNext_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnNewCode_Click(sender, null);
            }

        }

        private void chkEditCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCode.ReadOnly = chkEditCode.Checked ? false : true;

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                if (Convert.ToInt32(txtCode.Text) == 0 || Convert.ToInt32(txtCode.Text) > 99)
                {
                    XtraMessageBox.Show("کد وارده بایستی عددی بزرگتر از صفر و کمتر از 100 باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Fm.En == EnumCED.Create)
                    {
                        btnNewCode_Click(null, null);
                    }
                    else
                    {
                        txtCode.Text = CodeBeforeEdit;
                    }
                    txtCode.Focus();
                }
            }
        }

        private void cmbMahiatHesab_Enter(object sender, EventArgs e)
        {
            if (Fm.En == EnumCED.Create)
            {
                cmbMahiatHesab.ShowPopup();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            HelpClass1.CustomDrawRowIndicator(sender, e, gridView1);
        }

        private void FrmHesabMoinCed_FormClosing(object sender, FormClosingEventArgs e)
        {
            db1.Dispose();
        }
    }
}