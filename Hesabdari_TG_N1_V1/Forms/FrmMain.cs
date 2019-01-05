/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmMain.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 14   03:53 ق.ظ
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
using DevExpress.XtraTabbedMdi;
using Hesabdari_TG_N1_V1.Forms.Ap;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.InternalItems;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTab;
using Hesabdari_TG_N1_V1.Forms.Ap.AnbarKala;
using Microsoft.Win32;
using System.Data.SqlClient;
using HelpClassLibrary;
using SystemManagement.DafaterMali;
using SystemManagement.UsersSystem;

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DocumentManager documentManager1;
        //XtraTabbedMdiManager xtraTabbedMdiManager1;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            HelpClass1.SwitchToPersianLanguage();
            HelpClass1.SetRegionAndLanguage();
            // that will manage MDI child windows.
            //documentManager1.View = new NativeMdiView();
            ribbon.Minimized = true;
            //xtraTabbedMdiManager1 = new XtraTabbedMdiManager();
            //xtraTabbedMdiManager1.MdiParent = this;     
            documentManager1 = new DocumentManager
            {
                MdiParent = this,
                View = new TabbedView()
            };


        }

        private void btnListAnbarha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAnbarhaList fm = new FrmAnbarhaList
            {
                MdiParent = this
            };
            HelpClass1.ActiveForm(fm);
        }

        private void btnListMojtamaha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMajmoehaList fm = new FrmMajmoehaList
            {
                MdiParent = this
            };
            HelpClass1.ActiveForm(fm);

        }

        private void btnUsersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUsersList fm = new FrmUsersList();
                fm.MdiParent = this;
            HelpClass1.ActiveForm(fm);

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection.ClearAllPools();
            Dispose(true);
        }

        private void btnListSherkatha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmVahedhaList fm = new FrmVahedhaList
            {
                MdiParent = this
            };
            HelpClass1.ActiveForm(fm);

        }

        private void btnListShoabat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmShoabatList fm = new FrmShoabatList
            {
                MdiParent = this
            };
            HelpClass1.ActiveForm(fm);

        }

        private void btnListDorehaiMali_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDorehaList fm = new FrmDorehaList
            {
                MdiParent = this
            };
            HelpClass1.ActiveForm(fm);

        }
    }
}