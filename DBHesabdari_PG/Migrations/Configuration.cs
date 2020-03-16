/****************************** Ghost.github.io ******************************\
*	Module Name:	Configuration.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:45
*	
***********************************************************************************/
namespace DBHesabdari_PG.Migrations
{
    using DBHesabdari_PG;
    using DevExpress.XtraEditors;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Forms;
    using DBHesabdari_PG.Models.EP.CodingHesabdari;
    using DBHesabdari_PG.Models.Ms.ActiveSystem;
    using DBHesabdari_PG.Models.Ms.DafaterMali;
    using DBHesabdari_PG.Models.Ms.SystemUsers;

    internal sealed class Configuration : DbMigrationsConfiguration<DBHesabdari_PG.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DBHesabdari_PG.MyContext";
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
                    if (!context.EpGroupTafzilis.Any())
                    {
                        context.Entry(new EpGroupTafzili() { Id = 10, Code = 10, Name = "صندوق", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 10) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 15, Code = 15, Name = "حسابهای بانکی", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 15) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 20, Code = 20, Name = "اشخاص حقیقی", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 20) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 25, Code = 25, Name = "اشخاص حقوقی", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 25) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 30, Code = 30, Name = "ادارات دولتی", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 30) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 35, Code = 35, Name = "وامها", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 35) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 40, Code = 40, Name = "داراییها", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 40) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 45, Code = 45, Name = "پروژه ها", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 45) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 50, Code = 50, Name = "مواد", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 50) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 55, Code = 55, Name = "قطعات", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 55) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 60, Code = 60, Name = "محصول", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 60) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 65, Code = 65, Name = "کالاها", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 65) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 70, Code = 70, Name = "مراکز هزینه", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 70) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 75, Code = 75, Name = "شعبات یا نمایندگیهای وابسته", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 75) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new EpGroupTafzili() { Id = 90, Code = 90, Name = "سایر", IsActive = true }).State = context.EpGroupTafzilis.Any(s => s.Id == 90) ? EntityState.Unchanged : EntityState.Added;

                    }

                    if (!context.MsActiveSystems.Any())
                    {
                        context.Entry(new MsActiveSystem() { Id = 10, Code = 10, Name = "فروش و خرید", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Id == 1) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 15, Code = 15, Name = "دریافت و پرداخت", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Id == 2) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 20, Code = 20, Name = "اسناد حسابداری", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Id == 3) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 25, Code = 25, Name = "انبار و کالا", IsActive = false }).State = context.MsActiveSystems.Any(s => s.Id == 4) ? EntityState.Unchanged : EntityState.Added;
                    }

                    if (!context.MsDefaults.Any())
                    {
                        context.Entry(new MsDefault() { MsUserId = 1, MajmoeId = 1, VahedId = 1, ShobeId = 1, DoreMaliId=1}).State = context.MsDefaults.Any(s => s.MsUserId == 1) ? EntityState.Unchanged : EntityState.Added;
                    }

                    if (!context.MsUsers.Any())
                    {
                        context.MsUsers.Add(new MsUser() { MsUserId = 1, UserCode = 101, Name = "مدیر سیستم", Shenase = "1", Password = "1", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 2, UserCode = 102, Name = "کمال خیاطی", Shenase = "2", Password = "2", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 3, UserCode = 103, Name = "جمال خیاطی", Shenase = "3", Password = "3", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 4, UserCode = 104, Name = "جلال خیاطی", Shenase = "4", Password = "4", UserIsActive = true });
                        context.MsUsers.Add(new MsUser() { MsUserId = 5, UserCode = 105, Name = "کاوه خیاطی", Shenase = "5", Password = "5", UserIsActive = true });
                    }
                    if (!context.MsMajmoes.Any())
                    {
                        context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 1, MajmoeCode = 10, MajmoeName = "مجموعه زنجیره ای آفاق", MajmoeIsActive = true });
                        context.MsMajmoes.Add(new MsMajmoe() { MsMajmoeId = 2, MajmoeCode = 11, MajmoeName = "مجتمع نرم افزاری تلاشگران", MajmoeIsActive = true });
                    }
                    if (!context.MsVaheds.Any())
                    {
                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 1, VahedCode = 1001, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی", VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق" });
                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 2, VahedCode = 1002, VahedName = "کارگاه تولیدی ام دی اف", VahedIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق" });
                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 3, VahedCode = 1101, VahedName = "گروه برنامه نویسان ویندوزی", VahedIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران" });
                        context.MsVaheds.Add(new MsVahed() { MsVahedId = 4, VahedCode = 1102, VahedName = "گروه برنامه نویسان موبایل", VahedIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران" });
                    }
                    if (!context.MsShobes.Any())
                    {
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 1, ShobeCode = 100101, ShobeName = "شعبه خیابان ساحلی(یوپی وی سی)", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 2, ShobeCode = 100102, ShobeName = "شعبه بازارچه(یوپی وی سی)", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 1, VahedName = "کارگاه ساخت درب و پنجره یو پی وی سی" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 3, ShobeCode = 100201, ShobeName = "شعبه خیابان ساحلی(ام دی اف)", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 4, ShobeCode = 100202, ShobeName = "شعبه ملاجامی(ام دی اف)", ShobeIsActive = true, MsMajmoeId = 1, MajmoeName = "مجموعه زنجیره ای آفاق", MsVahedId = 2, VahedName = "کارگاه تولیدی ام دی اف" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 5, ShobeCode = 110101, ShobeName = "شعبه 1", ShobeIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsVahedId = 3, VahedName = "گروه برنامه نویسان ویندوزی" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 6, ShobeCode = 110102, ShobeName = "شعبه 2", ShobeIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsVahedId = 3, VahedName = "گروه برنامه نویسان ویندوزی" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 7, ShobeCode = 110201, ShobeName = "نمایندگی 1", ShobeIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsVahedId = 4, VahedName = "گروه برنامه نویسان موبایل" });
                        context.MsShobes.Add(new MsShobe() { MsShobeId = 8, ShobeCode = 110202, ShobeName = "نمایندگی 2", ShobeIsActive = true, MsMajmoeId = 2, MajmoeName = "مجتمع نرم افزاری تلاشگران", MsVahedId = 4, VahedName = "گروه برنامه نویسان مویایل" });
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
                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 5,
                            DoreMaliCode = 110101001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),

                            DoreMaliIsActive = true,
                            MsMajmoeId = 2,
                            MajmoeName = "مجتمع نرم افزاری تلاشگران",
                            MsVahedId = 3,
                            VahedName = "گروه برنامه نویسان ویندوزی",
                            MsShobeId = 5,
                            ShobeName = "شعبه 1",

                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3),
                        });
                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 6,
                            DoreMaliCode = 110102001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),

                            DoreMaliIsActive = true,
                            MsMajmoeId = 2,
                            MajmoeName = "مجتمع نرم افزاری تلاشگران",
                            MsVahedId = 3,
                            VahedName = "گروه برنامه نویسان ویندوزی",
                            MsShobeId = 6,
                            ShobeName = "شعبه 2",

                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3),
                        });
                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 7,
                            DoreMaliCode = 110201001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),

                            DoreMaliIsActive = true,
                            MsMajmoeId = 2,
                            MajmoeName = "مجتمع نرم افزاری تلاشگران",
                            MsVahedId = 4,
                            VahedName = "گروه برنامه نویسان موبایل",
                            MsShobeId = 7,
                            ShobeName = "نمایندگی 1",

                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3),
                        });
                        context.MsDoreMalis.Add(new MsDoreMali()
                        {
                            MsDoreMaliId = 8,
                            DoreMaliCode = 110202001,
                            DoreMali = 1397,
                            StartDoreMali = Convert.ToDateTime("2018/03/21"),
                            EndDoreMali = Convert.ToDateTime("2019/03/20"),

                            DoreMaliIsActive = true,
                            MsMajmoeId = 2,
                            MajmoeName = "مجتمع نرم افزاری تلاشگران",
                            MsVahedId = 4,
                            VahedName = "گروه برنامه نویسان موبایل",
                            MsShobeId = 8,
                            ShobeName = "نمایندگی 2",

                            Maliat = Convert.ToSingle(6),
                            Avarez = Convert.ToSingle(3),
                        });
                    }
                    if (!context.MsAccessLevelDafaterMalis.Any())
                    {
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 10, ParentId = 10, LevelName = "مجموعه زنجیره ای آفاق", MajmoeId = 1, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 1001, ParentId = 10, LevelName = "کارگاه ساخت درب و پنجره یو پی وی سی", MajmoeId = 1, VahedId = 1, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 1002, ParentId = 10, LevelName = "کارگاه تولیدی ام دی اف", MajmoeId = 1, VahedId = 2, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100101, ParentId = 1001, LevelName = "شعبه خیابان ساحلی(یوپی وی سی)", MajmoeId = 1, VahedId = 1, ShobeId = 1, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100102, ParentId = 1001, LevelName = "شعبه بازارچه(یوپی وی سی)", MajmoeId = 1, VahedId = 1, ShobeId = 2, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100201, ParentId = 1002, LevelName = "شعبه خیابان ساحلی(ام دی اف)", MajmoeId = 1, VahedId = 2, ShobeId = 3, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100202, ParentId = 1002, LevelName = "شعبه ملاجامی(ام دی اف)", MajmoeId = 1, VahedId = 2, ShobeId = 4, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100101001, ParentId = 100101, LevelName = "1397", MajmoeId = 1, VahedId = 1, ShobeId = 1, DoreMaliId = 1, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100102001, ParentId = 100102, LevelName = "1397", MajmoeId = 1, VahedId = 1, ShobeId = 2, DoreMaliId = 2, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100201001, ParentId = 100201, LevelName = "1397", MajmoeId = 1, VahedId = 2, ShobeId = 3, DoreMaliId = 3, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 100202001, ParentId = 100202, LevelName = "1397", MajmoeId = 1, VahedId = 2, ShobeId = 4, DoreMaliId = 4, IsActive = true });

                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 11, ParentId = 11, LevelName = "مجتمع نرم افزاری تلاشگران", MajmoeId = 2, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 1101, ParentId = 11, LevelName = "گروه برنامه نویسان ویندوزی", MajmoeId = 2, VahedId = 3, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 1102, ParentId = 11, LevelName = "گروه برنامه نویسان موبایل", MajmoeId = 2, VahedId = 4, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110101, ParentId = 1101, LevelName = "شعبه 1", MajmoeId = 2, VahedId = 3, ShobeId = 5, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110102, ParentId = 1101, LevelName = "شعبه2", MajmoeId = 2, VahedId = 3, ShobeId = 6, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110201, ParentId = 1102, LevelName = "نمایندگی 1", MajmoeId = 2, VahedId = 4, ShobeId = 7, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110202, ParentId = 1102, LevelName = "نمایندگی 2", MajmoeId = 2, VahedId = 4, ShobeId = 8, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110101001, ParentId = 110101, LevelName = "1397", MajmoeId = 2, VahedId = 3, ShobeId = 5, DoreMaliId = 5, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110102001, ParentId = 110102, LevelName = "1397", MajmoeId = 2, VahedId = 3, ShobeId = 6, DoreMaliId = 6, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110201001, ParentId = 110201, LevelName = "1397", MajmoeId = 2, VahedId = 4, ShobeId = 7, DoreMaliId = 7, IsActive = true });
                        context.MsAccessLevelDafaterMalis.Add(new MsAccessLevelDafaterMali() { KeyId = 110202001, ParentId = 110202, LevelName = "1397", MajmoeId = 2, VahedId = 4, ShobeId = 8, DoreMaliId = 8, IsActive = true });

                    }

                    ////////////////////////////////////////////////////
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55, ParentId = 55, LevelName = "مدیریت سیستم" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 5501, ParentId = 55, LevelName = "لیست دفاتر مالی" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 5501) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550101, ParentId = 5501, LevelName = "لیست اسامی مجموعه های زنجیره ای" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550101) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010101, ParentId = 550101, LevelName = "ایجاد کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010101) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010102, ParentId = 550101, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010102) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010103, ParentId = 550101, LevelName = "حذف کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010103) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550102, ParentId = 5501, LevelName = "لیست اسامی واحدهای تجاری یا خدماتی" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550102) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010201, ParentId = 550102, LevelName = "ایجاد کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010201) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010202, ParentId = 550102, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010202) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010203, ParentId = 550102, LevelName = "حذف کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010203) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550103, ParentId = 5501, LevelName = "لیست اسامی شعبه ها یا نمایندگی های واحدها" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550103) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010301, ParentId = 550103, LevelName = "ایجاد کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010301) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010302, ParentId = 550103, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010302) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010303, ParentId = 550103, LevelName = "حذف کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010303) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550104, ParentId = 5501, LevelName = "لیست دوره های مالی" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550104) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010401, ParentId = 550104, LevelName = "ایجاد کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010401) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010402, ParentId = 550104, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010402) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55010403, ParentId = 550104, LevelName = "حذف کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55010403) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 5502, ParentId = 55, LevelName = "عملیات سال مالی" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 5502) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 5503, ParentId = 55, LevelName = "کاربران سیستم" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 5503) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550301, ParentId = 5503, LevelName = "لیست کاربران" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550301) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55030101, ParentId = 550301, LevelName = "ایجاد کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55030101) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55030102, ParentId = 550301, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55030102) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55030103, ParentId = 550301, LevelName = "حذف کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55030103) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550302, ParentId = 5503, LevelName = "تعیین سطح دسترسی کاربران" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550302) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55030201, ParentId = 550302, LevelName = "دسترسی به منو ها، زیر منو ها و محتویات فرمها" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55030201) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550302011, ParentId = 55030201, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550302011) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 55030202, ParentId = 550302, LevelName = "دسترسی به داده ها و اطلاعات ایجاد شده" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 55030202) ? EntityState.Modified : EntityState.Added;
                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550302021, ParentId = 55030202, LevelName = "ویرایش کردن" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550302021) ? EntityState.Modified : EntityState.Added;

                    context.Entry(new MsAccessLevelMenu() { MsAccessLevelMenuId = 550303, ParentId = 5503, LevelName = "تغییر شناسه کاربری و رمز عبور کاربران" }).State = context.MsAccessLevelMenus.Any(s => s.MsAccessLevelMenuId == 550303) ? EntityState.Modified : EntityState.Added;

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