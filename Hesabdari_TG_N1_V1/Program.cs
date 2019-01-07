/****************************** Ghost.github.io ******************************\
*	Module Name:	Program.cs
*	Project:		Hesabdari_TG_N1_V1
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
using Hesabdari_TG_N1_V1.Forms;
using System.Threading;
using DBHesabdari_TG;
using HelpClassLibrary;

namespace Hesabdari_TG_N1_V1
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

                    MessageBox.Show(ex.Message);
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

            HelpClass1.SwitchToPersianLanguage();
            Cultures.InitializePersianCulture();
            HelpClass1.SetRegionAndLanguage();

            BonusSkins.Register();
            Application.Run(new FrmMain());
        }
    }
}
