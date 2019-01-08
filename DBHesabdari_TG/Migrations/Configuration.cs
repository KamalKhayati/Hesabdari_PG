/****************************** Ghost.github.io ******************************\
*	Module Name:	Configuration.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:45
*	
***********************************************************************************/
namespace DBHesabdari_TG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;

    internal sealed class Configuration : DbMigrationsConfiguration<DBHesabdari_TG.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DBHesabdari_TG.MyContext";
            string DataPath = Application.StartupPath + @"\DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", DataPath);
        }

        protected override void Seed(MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            using (context = new MyContext())
            {
                if (!context.MsUsers.Any())
                {
                    context.MsUsers.Add(new MsUser() { MsUserId = 1, UserCode = 101, UserName = "مدیر سیستم", Name = "1", Password = "1", UserIsActive = true, DoreMali = 1397 });
                    context.MsUsers.Add(new MsUser() { MsUserId = 2, UserCode = 102, UserName = "کمال خیاطی", Name = "2", Password = "2", UserIsActive = true, DoreMali = 1397 });
                    context.MsUsers.Add(new MsUser() { MsUserId = 3, UserCode = 103, UserName = "جمال خیاطی", Name = "3", Password = "3", UserIsActive = true, DoreMali = 1397 });
                    context.MsUsers.Add(new MsUser() { MsUserId = 4, UserCode = 104, UserName = "جلال خیاطی", Name = "4", Password = "4", UserIsActive = true, DoreMali = 1397 });
                    context.MsUsers.Add(new MsUser() { MsUserId = 5, UserCode = 105, UserName = "کاوه خیاطی", Name = "5", Password = "5", UserIsActive = true, DoreMali = 1397 });
                    // context.SaveChanges();
                }
                if (!context.MsMajmoes.Any())
                {
                    context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 1, MajmoeCode = 10, MajmoeName = "مجموعه زنجیره ای آفاق", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", MajmoeIsActive = true, IsDefault = true, DoreMali = 1397 });

                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 1, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 1, UserName = "مدیر سیستم", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 2, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 2, UserName = "کمال خیاطی", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 3, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 3, UserName = "جمال خیاطی", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 4, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 4, UserName = "جلال خیاطی", DoreMali = 1397 });

                    context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 2, MajmoeCode = 11, MajmoeName = "مجتمع نرم افزاری تلاشگران", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", MajmoeIsActive = true, IsDefault = false, DoreMali = 1397 });

                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 5, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 1, UserName = "مدیر سیستم", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 6, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 2, UserName = "کمال خیاطی", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 7, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 3, UserName = "جمال خیاطی", DoreMali = 1397 });
                    context.RmsMajmoehaBmsUserhas.Add(new RmsMajmoehaBmsUserha() { Id = 8, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 4, UserName = "جلال خیاطی", DoreMali = 1397 });

                    //  context.SaveChanges();
                }
                if (!context.MsVaheds.Any())
                {
                    context.MsVaheds.Add(new MsVahed() { MsVahedId = 1, VahedCode = 1001, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", IsDefault = true, DoreMali = 1397 });

                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 1, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 2, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 3, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 4, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });

                    context.MsVaheds.Add(new MsVahed() { MsVahedId = 2, VahedCode = 1002, VahedName = "کارگاه تولیدی ام دی اف", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", IsDefault = false, DoreMali = 1397 });

                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 5, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 6, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 7, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });
                    context.RmsVahedhaBmsUserhas.Add(new RmsVahedhaBmsUserha() { Id = 8, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, DoreMali = 1397 });

                    // context.SaveChanges();
                }
                if (!context.MsShobes.Any())
                {
                    context.MsShobes.Add(new MsShobe() { MsShobeId = 1, ShobeCode = 100101, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", IsDefault = true, DoreMali = 1397 });

                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 1, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 2, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 3, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 4, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });

                    context.MsShobes.Add(new MsShobe() { MsShobeId = 2, ShobeCode = 100102, ShobeName = "شعبه بازارچه(یوپی وی سی)", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", IsDefault = false, DoreMali = 1397 });

                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 5, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 6, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 7, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 8, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 1, DoreMali = 1397 });
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    context.MsShobes.Add(new MsShobe() { MsShobeId = 3, ShobeCode = 100201, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", IsDefault = true, DoreMali = 1397 });

                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 9, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 10, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 11, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 12, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });

                    context.MsShobes.Add(new MsShobe() { MsShobeId = 4, ShobeCode = 100202, ShobeName = "شعبه ملاجامی(ام دی اف)", PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", IsDefault = false, DoreMali = 1397 });

                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 13, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 14, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 15, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });
                    context.RmsShobehaBmsUserhas.Add(new RmsShobehaBmsUserha() { Id = 16, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 2, DoreMali = 1397 });

                    //  context.SaveChanges();
                }
                if (!context.MsDoreMalis.Any())
                {
                    context.MsDoreMalis.Add(new MsDoreMali()
                    {
                        MsDoreMaliId = 1,
                        DoreMaliCode = 100101001,
                        DoreMali = 1397,
                        StartDoreMali = Convert.ToDateTime("2018/03/21"),
                        EndDoreMali = Convert.ToDateTime("2019/03/20"),
                        PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی",
                        DoreMaliIsActive = true,
                        MsMajmoeId = 1,
                        MajmoeName = "مجموعه زنجیره ای آفاق",
                        MsVahedId = 1,
                        VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی",
                        MsShobeId = 1,
                        ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)",
                        IsDefault = true
                    });

                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 1, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 1 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 2, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 1 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 3, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 1 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 4, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 1 });

                    context.MsDoreMalis.Add(new MsDoreMali()
                    {
                        MsDoreMaliId = 2,
                        DoreMaliCode = 100102001,
                        DoreMali = 1397,
                        StartDoreMali = Convert.ToDateTime("2018/03/21"),
                        EndDoreMali = Convert.ToDateTime("2019/03/20"),
                        PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی",
                        DoreMaliIsActive = true,
                        MsMajmoeId = 1,
                        MajmoeName = "مجموعه زنجیره ای آفاق",
                        MsVahedId = 1,
                        VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی",
                        MsShobeId = 2,
                        ShobeName = "شعبه بازارچه(یوپی وی سی)",
                        IsDefault = false
                    });

                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 5, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 2 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 6, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 2 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 7, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 2 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 8, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 1, MsShobeId = 2 });
                    ////////////////////////////////////////////////////////////////////////////////////////////
                    context.MsDoreMalis.Add(new MsDoreMali()
                    {
                        MsDoreMaliId = 3,
                        DoreMaliCode = 100201001,
                        DoreMali = 1397,
                        StartDoreMali = Convert.ToDateTime("2018/03/21"),
                        EndDoreMali = Convert.ToDateTime("2019/03/20"),
                        PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی",
                        DoreMaliIsActive = true,
                        MsMajmoeId = 1,
                        MajmoeName = "مجموعه زنجیره ای آفاق",
                        MsVahedId = 2,
                        VahedName = "کارگاه تولیدی ام دی اف",
                        MsShobeId = 3,
                        ShobeName = "شعبه خیابان ساحلی(ام دی اف)",
                        IsDefault = true
                    });

                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 9, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 3 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 10, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 3 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 11, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 3 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 12, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 3 });

                    context.MsDoreMalis.Add(new MsDoreMali()
                    {
                        MsDoreMaliId = 4,
                        DoreMaliCode = 100202001,
                        DoreMali = 1397,
                        StartDoreMali = Convert.ToDateTime("2018/03/21"),
                        EndDoreMali = Convert.ToDateTime("2019/03/20"),
                        PermissiveUsers = "مدیر سیستم,کمال خیاطی,جمال خیاطی,جلال خیاطی",
                        DoreMaliIsActive = true,
                        MsMajmoeId = 1,
                        MajmoeName = "مجموعه زنجیره ای آفاق",
                        MsVahedId = 2,
                        VahedName = "کارگاه تولیدی ام دی اف",
                        MsShobeId = 4,
                        ShobeName = "شعبه ملاجامی(ام دی اف)",
                        IsDefault = false,
                    });

                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 13, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 4 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 14, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 4 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 15, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 4 });
                    context.RmsDoreMalihaBmsUserhas.Add(new RmsDoreMalihaBmsUserha() { Id = 16, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی", MsMajmoeId = 1, MsVahedId = 2, MsShobeId = 4 });

                    // context.SaveChanges();
                }
                context.SaveChanges();
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
