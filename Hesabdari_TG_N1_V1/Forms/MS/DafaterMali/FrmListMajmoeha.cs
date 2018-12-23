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
            bar1.OptionsBar.DisableCustomization = true;
        }

        private void btnSabt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSedMajmoeha fm = new FrmSedMajmoeha();
            fm.Text = "ثبت نام مجتمع یا مجموعه زنجیره ای";
            fm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSedMajmoeha fm = new FrmSedMajmoeha();
            fm.Text = "ویرایش نام مجتمع یا مجموعه زنجیره ای";
            fm.btnSabtBastan.Text = "ویرایش و بستن";
            fm.btnSabtBadi.Visible = false;
            fm.ShowDialog();

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSedMajmoeha fm = new FrmSedMajmoeha();
            fm.Text = "حذف نام مجتمع یا مجموعه زنجیره ای";
            fm.btnSabtBastan.Text = "حذف و بستن";
            fm.btnSabtBadi.Visible = false;
            fm.panelControl1.Enabled = false;
            fm.ShowDialog();

        }

        private void btnPreviewPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HelpClass.HelpClass1.ShowGridPreview(gridControl1, gridView1);
        }
    }
}