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
    using DBHesabdari_TG;
    using DevExpress.XtraEditors;
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
                try
                {
                    if (!context.MsUsers.Any())
                    {
                        context.MsUsers.Add(new MsUser() { MsUserId = 1, UserCode = 101, UserName = "مدیر سیستم", Name = "1", Password = "1", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 2, UserCode = 102, UserName = "کمال خیاطی", Name = "2", Password = "2", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 3, UserCode = 103, UserName = "جمال خیاطی", Name = "3", Password = "3", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 4, UserCode = 104, UserName = "جلال خیاطی", Name = "4", Password = "4", UserIsActive = true, });
                        context.MsUsers.Add(new MsUser() { MsUserId = 5, UserCode = 105, UserName = "کاوه خیاطی", Name = "5", Password = "5", UserIsActive = true });
                        // context.SaveChanges();
                    }
                    if (!context.MsMajmoes.Any())
                    {
                        context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 1, MajmoeCode = 10, MajmoeName = "مجموعه زنجیره ای آفاق",  MajmoeIsActive = true });

                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 1, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 1, UserName = "مدیر سیستم" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 2, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 2, UserName = "کمال خیاطی" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 3, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 3, UserName = "جمال خیاطی" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 4, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 2, MajmoeCode = 11, MajmoeName = "مجتمع نرم افزاری تلاشگران",  MajmoeIsActive = true });

                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 5, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 1, UserName = "مدیر سیستم" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 6, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 2, UserName = "کمال خیاطی" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 7, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 3, UserName = "جمال خیاطی" });
                        //context.RmsUserhaBmsMajmoehas.Add(new RmsUserhaBmsMajmoeha() { Id = 8, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsUserId = 4, UserName = "جلال خیاطی" });

                        //  context.SaveChanges();
                    }
                    if (!context.MsVaheds.Any())
                    {
                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 1, VahedCode = 1001, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی",  VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق" });

                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 1, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 2, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 3, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 4, MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 2, VahedCode = 1002, VahedName = "کارگاه تولیدی ام دی اف",  VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق" });

                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 5, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 6, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 7, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsVahedhas.Add(new RmsUserhaBmsVahedha() { Id = 8, MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف", MsUserId = 4, UserName = "جلال خیاطی" });

                        // context.SaveChanges();
                    }
                    if (!context.MsShobes.Any())
                    {
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 1, ShobeCode = 100101, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)",  ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی" });

                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 1, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 2, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 3, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 4, MsShobeId = 1, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsShobes.Add(new MsShobe() { MsShobeId = 2, ShobeCode = 100102, ShobeName = "شعبه بازارچه(یوپی وی سی)",  ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی" });

                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 5, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 6, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 7, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 8, MsShobeId = 2, ShobeName = "شعبه بازارچه(یوپی وی سی)", MsUserId = 4, UserName = "جلال خیاطی" });
                        ////////////////////////////////////////////////////////////////////////////////////////////
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 3, ShobeCode = 100201, ShobeName = "شعبه خیابان ساحلی(ام دی اف)",  ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف" });

                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 9, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 1, UserName = "مدیر سیستم" });
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 10, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 11, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 12, MsShobeId = 3, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsShobes.Add(new MsShobe() { MsShobeId = 4, ShobeCode = 100202, ShobeName = "شعبه ملاجامی(ام دی اف)",  ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف" });

                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 13, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 14, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 15, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsShobehas.Add(new RmsUserhaBmsShobeha() { Id = 16, MsShobeId = 4, ShobeName = "شعبه ملاجامی(ام دی اف)", MsUserId = 4, UserName = "جلال خیاطی" });

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
                            
                            DoreMaliIsActive = true,
                            MsMajmoeId = 1,
                            MajmoeName = "مجموعه زنجیره ای آفاق",
                            MsVahedId = 1,
                            VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی",
                            MsShobeId = 1,
                            ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)",
                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3)
                        });

                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 1, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 2, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 3, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 4, MsDoreMaliId = 1, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 2,
                            DoreMaliCode = 100102001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),
                            
                            DoreMaliIsActive = true,
                            MsMajmoeId = 1,
                            MajmoeName = "مجموعه زنجیره ای آفاق",
                            MsVahedId = 1,
                            VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی",
                            MsShobeId = 2,
                            ShobeName = "شعبه بازارچه(یوپی وی سی)",
                            
                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3)
                        });

                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 5, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 6, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 7, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 8, MsDoreMaliId = 2, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی" });
                        ////////////////////////////////////////////////////////////////////////////////////////////
                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 3,
                            DoreMaliCode = 100201001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),
                            
                            DoreMaliIsActive = true,
                            MsMajmoeId = 1,
                            MajmoeName = "مجموعه زنجیره ای آفاق",
                            MsVahedId = 2,
                            VahedName = "کارگاه تولیدی ام دی اف",
                            MsShobeId = 3,
                            ShobeName = "شعبه خیابان ساحلی(ام دی اف)",
                            
                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3)
                        });

                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 9, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم" });
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 10, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 11, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 12, MsDoreMaliId = 3, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی" });

                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 4,
                            DoreMaliCode = 100202001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),
                            
                            DoreMaliIsActive = true,
                            MsMajmoeId = 1,
                            MajmoeName = "مجموعه زنجیره ای آفاق",
                            MsVahedId = 2,
                            VahedName = "کارگاه تولیدی ام دی اف",
                            MsShobeId = 4,
                            ShobeName = "شعبه ملاجامی(ام دی اف)",
                            
                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3),
                        });

                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 13, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 1, UserName = "مدیر سیستم"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 14, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 2, UserName = "کمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 15, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 3, UserName = "جمال خیاطی"});
                        //context.RmsUserhaBmsDorehaiMalis.Add(new RmsUserhaBmsDorehaiMali() { Id = 16, MsDoreMaliId = 4, DoreMali = 1397, MsUserId = 4, UserName = "جلال خیاطی" });

                        // context.SaveChanges();
                    }
                    ////////////////////////////////////////////////////
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55, ParentId = 0, LevelName = "مدیریت سیستم" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55100, ParentId = 55, LevelName = "لیست دفاتر مالی" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55100) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55110, ParentId = 55100, LevelName = "لیست اسامی مجموعه های زنجیره ای" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55110) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55111, ParentId = 55110, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55111) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55112, ParentId = 55110, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55112) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55113, ParentId = 55110, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55113) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55120, ParentId = 55100, LevelName = "لیست اسامی واحدهای تجاری یا خدماتی" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55120) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55121, ParentId = 55120, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55121) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55122, ParentId = 55120, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55122) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55123, ParentId = 55120, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55123) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55130, ParentId = 55100, LevelName = "لیست اسامی شعبه ها یا نمایندگی های واحدها" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55130) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55131, ParentId = 55130, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55131) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55132, ParentId = 55130, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55132) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55133, ParentId = 55130, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55133) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55140, ParentId = 55100, LevelName = "لیست دوره های مالی" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55140) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55141, ParentId = 55140, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55141) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55142, ParentId = 55140, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55142) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55143, ParentId = 55140, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55143) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55200, ParentId = 55, LevelName = "عملیات سال مالی" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55200) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55300, ParentId = 55, LevelName = "کاربران سیستم" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55300) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55310, ParentId = 55300, LevelName = "لیست کاربران" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55310) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55311, ParentId = 55310, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55311) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55312, ParentId = 55310, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55312) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55313, ParentId = 55310, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55313) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55320, ParentId = 55300, LevelName = "تعیین سطح دسترسی کاربران" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55320) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55330, ParentId = 55320, LevelName = "دسترسی به منو ها، زیر منو ها و محتویات فرمها" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55330) ? EntityState.Modified : EntityState.Added;
                    //context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55331, ParentId = 55330, LevelName = "ایجاد کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55331) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55332, ParentId = 55330, LevelName = "ویرایش کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55332) ? EntityState.Modified : EntityState.Added;
                    //context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55333, ParentId = 55330, LevelName = "حذف کردن" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55333) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55340, ParentId = 55320, LevelName = "دسترسی به داده ها و اطلاعات ایجاد شده" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55340) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevel1() { AccessLevel1Id = 55350, ParentId = 55300, LevelName = "تغییر شناسه کاربری و رمز عبور کاربران" }).State = context.MsAccessLevel1s.Any(s => s.AccessLevel1Id == 55350) ? EntityState.Modified : EntityState.Added;

                    // context.SaveChanges();

                    context.SaveChanges();
                    base.Seed(context);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
}