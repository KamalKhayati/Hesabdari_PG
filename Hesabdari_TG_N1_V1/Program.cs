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
using Hesabdari_TG_N1_V1.Models;
using Hesabdari_TG_N1_V1.Forms;

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
            BonusSkins.Register();
            Application.Run(new FrmMain());
        }
    }
}
