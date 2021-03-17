﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	Program.cs
*	Project:		Hesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 13   03:21 ق.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Hesabdari_PG.Forms;
using System.Threading;
using DBHesabdari_PG;
using HelpClassLibrary;

namespace Hesabdari_PG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region
            using (var db = new MyContext())
            {
                try
                {
                    db.Database.Initialize(true);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

            #endregion
            //var current = System.Threading.Thread.CurrentThread.CurrentCulture;
            //var culture = System.Globalization.CultureInfo.CreateSpecificCulture(current.Name);
            //culture.NumberFormat.DigitSubstitution = System.Globalization.DigitShapes.Context;
            //System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            //System.Globalization.CultureInfo cinfo = (System.Globalization.CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            //Thread.CurrentThread.CurrentCulture.ClearCachedData();
            //Application.CurrentCulture.ClearCachedData();
            //cinfo.NumberFormat.DigitSubstitution = System.Globalization.DigitShapes.Context;
            //Thread.CurrentThread.CurrentCulture = cinfo;
            //Thread.CurrentThread.CurrentUICulture = cinfo;
            //Application.CurrentCulture = cinfo;

            BonusSkins.Register();
            //new FrmLogin().Show();
            if (HelpClass1.IsSetGregorianCalendar())
            {
                Cultures.InitializePersianCulture();
                Application.Run(new AppContext());
            }
            else
                Application.Exit();

        }
        public class AppContext : ApplicationContext
        {
            public AppContext()
            {
                Application.Idle += new EventHandler(Application_Idle);
                //new FrmLogin().Show();
                new FrmMain().Show();
            }

            private void Application_Idle(object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            }
        }

    }
}
