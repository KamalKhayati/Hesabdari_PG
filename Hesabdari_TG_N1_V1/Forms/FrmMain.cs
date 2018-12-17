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
using Hesabdari_TG_N1_V1.Forms.Base;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.InternalItems;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTab;

namespace Hesabdari_TG_N1_V1.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //DocumentManager documentManager1;
        XtraTabbedMdiManager xtraTabbedMdiManager1;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // that will manage MDI child windows.
            // xtraTabbedMdiManager1.MdiParent = this;
            //documentManager1.MdiParent = this;
            //documentManager1.View = new NativeMdiView();
            ribbon.Minimized = true;
            //documentManager1 = new DocumentManager();
            xtraTabbedMdiManager1 = new XtraTabbedMdiManager();
            xtraTabbedMdiManager1.MdiParent = this;
        }

        private void btnHesabGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            FrmHesabGroup f = new FrmHesabGroup();
            f.MdiParent = this;
            f.Show();
        }

        private void btnHesabCol_ItemClick(object sender, ItemClickEventArgs e)
        {
            //documentManager1.MdiParent = this;
            //documentManager1.View = new NativeMdiView();

            // Create an MDI child form.
            FrmHesabCol f = new FrmHesabCol();
            //f.MdiParent = this;
            f.Show();

        }
    }
}