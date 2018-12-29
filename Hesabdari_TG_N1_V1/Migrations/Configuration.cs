/****************************** Ghost.github.io ******************************\
*	Module Name:	Configuration.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 13   03:50 ق.ظ
*	
***********************************************************************************/
namespace Hesabdari_TG_N1_V1.Migrations
{
    using Hesabdari_TG_N1_V1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Hesabdari_TG_N1_V1.Models.MyContext";
            string DataPath = Application.StartupPath + @"\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", DataPath);
        }

        protected override void Seed(MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.MsUsers.Any())
            {
                using (context = new MyContext())
                {
                    context.MsUsers.Add(new Models.MS.UsersSystem.MsUser() { UserCode = 101, UserName = "مدیر سیستم", UserNam = "1", UserPassword = "1", UserIsActive = true });
                    context.MsUsers.Add(new Models.MS.UsersSystem.MsUser() { UserCode = 102, UserName = "کمال خیاطی", UserNam = "2", UserPassword = "2", UserIsActive = true });
                    context.MsUsers.Add(new Models.MS.UsersSystem.MsUser() { UserCode = 103, UserName = "جمال خیاطی", UserNam = "3", UserPassword = "3", UserIsActive = false });
                    context.SaveChanges();
                }
            }
                base.Seed(context);
            /////////////////////////////////////////////////////////////////////////////////////////////////
            //        //context.Students.Add(new Student() { StudentName = "Kaveh", StudentAge = 35 });
            //        IList<Standard> DefaultStandards = new List<Standard>();
            //        DefaultStandards.Add(new Standard() { StandardName = "Abdulla", Description = "1 Standard",Degree=20 });
            //        DefaultStandards.Add(new Standard() { StandardName = "Saman", Description = "2 Standard", Degree = 30 });
            //        DefaultStandards.Add(new Standard() { StandardName = "Avat", Description = "3 Standard" , Degree = 40 });

            //        foreach (var item in DefaultStandards)
            //        {
            //            context.Standards.Add(item);
            //            context.SaveChanges();
            //        }
            /////////////////////////////////////////////////////////////////////////////////////////////////

        }
    }
}
