/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmListMojtamaha.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 20   03:32 ق.ظ
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
using DevExpress.XtraBars;

namespace Hesabdari_TG_N1_V1.Forms.MS.DafaterMali
{
    public partial class FrmListMajmoeha : DevExpress.XtraEditors.XtraForm
    {
        public FrmListMajmoeha()
        {
            InitializeComponent();
        }

        private void FrmListMojtamaha_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSedMajmoeha fm = new FrmSedMajmoeha(this);
            HelpClass.HelpClass1.FormSaveNewRecord(gridView1, fm);
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && btnEdit.Visibility == BarItemVisibility.Always)
            {
                FrmSedMajmoeha fm = new FrmSedMajmoeha(this);
                fm.txtId.Text = gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                fm.txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                fm.txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                fm.chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                HelpClass.HelpClass1.FormEditeCurrentRecord(gridView1, fm);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                FrmSedMajmoeha fm = new FrmSedMajmoeha(this);
                fm.txtId.Text = gridView1.GetFocusedRowCellValue("MsMajmoeId").ToString();
                fm.txtCode.Text = gridView1.GetFocusedRowCellValue("Code").ToString();
                fm.txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                fm.chkIsActive.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsActive"));
                HelpClass.HelpClass1.FormDeleteCurrentRecord(gridView1, fm);
            }
        }

        private void btnPreviewPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass.HelpClass1.ShowGridPreview(gridControl1, gridView1);
        }

        private void btnAdvancedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.OptionsFind.AlwaysVisible = gridView1.OptionsFind.AlwaysVisible ? false : true;

        }

        private void btnDisplyListActive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDisplyListNotActive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
    }
}