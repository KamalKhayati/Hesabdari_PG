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
    using DBHesabdari_PG.Models.EP.Tanzimat;

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
                    //if (!context.EpGroupTafsiliLevel1s.Any())
                    //{
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 10, StartCode = 1000001, EndCode = 1099999, Name = "سهامداران", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 10) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 20, StartCode = 2000001, EndCode = 2099999, Name = "کارکنان", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 20) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 30, StartCode = 3000001, EndCode = 3099999, Name = "اشخاص حقیقی", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 30) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 40, StartCode = 4000001, EndCode = 4099999, Name = "شرکتها یا ادارات خصوصی", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 40) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 50, StartCode = 5000001, EndCode = 5099999, Name = "شرکتها یا ادارات دولتی", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 50) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 60, StartCode = 6000001, EndCode = 6099999, Name = "مواد", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 60) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 65, StartCode = 6500001, EndCode = 6599999, Name = "قطعات و ملزومات", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 65) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 70, StartCode = 7000001, EndCode = 7099999, Name = "محصولات", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 70) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 75, StartCode = 7500001, EndCode = 7599999, Name = "کالاها", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 75) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 80, StartCode = 8000001, EndCode = 8099999, Name = "داراییها", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 80) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 85, StartCode = 8500001, EndCode = 8599999, Name = "پروژه ها", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 85) ? EntityState.Unchanged : EntityState.Added;

                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 88, StartCode = 8800001, EndCode = 8899999, Name = "صندوق", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 88) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 89, StartCode = 8900001, EndCode = 8999999, Name = "حسابهای بانکی", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 89) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 90, StartCode = 9000001, EndCode = 9099999, Name = "وامها", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 90) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 91, StartCode = 9100001, EndCode = 9199999, Name = "مراکز", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 91) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 92, StartCode = 9200001, EndCode = 9299999, Name = "شعبات یا نمایندگیهای وابسته", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 92) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpGroupTafsiliLevel1() { Code = 93, StartCode = 9300001, EndCode = 9399999, Name = "سایر", IsActive = true }).State = context.EpGroupTafsiliLevel1s.Any(s => s.Code == 93) ? EntityState.Unchanged : EntityState.Added;

                    //}
                    if (!context.MsActiveSystems.Any())
                    {
                        context.Entry(new MsActiveSystem() { Id = 10, Code = 10, Name = "فروش و خرید", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 10) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 15, Code = 15, Name = "دریافت و پرداخت", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 15) ? EntityState.Unchanged : EntityState.Added;
                        //context.Entry(new MsActiveSystem() { Id = 20, Code = 20, Name = "اسناد حسابداری", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 20) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 25, Code = 25, Name = "انبار و کالا", IsActive = false }).State = context.MsActiveSystems.Any(s => s.Code == 25) ? EntityState.Unchanged : EntityState.Added;
                    }

                    ////////////////////////////////////////////////// کدینگ حسابداری //////////////////////////////////////////////////////
                    if (!context.EpTanzimatCodingHesabdaris.Any())
                    {
                        context.Entry(new EpTanzimatCodingHesabdari() { SalId = 1, HesabTabaghehCarakter = 1, HesabGroupCarakter = 1, HesabColCarakter = 1, HesabMoinCarakter = 1, HesabTabaghehMinCode = "1", HesabTabaghehMaxCode = "9", HesabGroupMinCode = "1", HesabGroupMaxCode = "9", HesabColMinCode = "1", HesabColMaxCode = "9", HesabMoinMinCode = "1", HesabMoinMaxCode = "9" }).State = context.EpTanzimatCodingHesabdaris.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;
                    }

                    if (!context.EpTanzimatGroupTafsilis.Any())
                    {
                        context.Entry(new EpTanzimatGroupTafsili() { GroupTafsiliLevel1Carakter = 2, GroupTafsiliLevel2Carakter = 1, GroupTafsiliLevel3Carakter = 1, CodeTafsiliCarakter = 5, GroupTafsiliLevel1MinCode = "10", GroupTafsiliLevel1MaxCode = "99", GroupTafsiliLevel2MinCode = "1", GroupTafsiliLevel2MaxCode = "9", GroupTafsiliLevel3MinCode = "1", GroupTafsiliLevel3MaxCode = "9", CodeTafsiliMinCode = "00001", CodeTafsiliMaxCode = "99999" }).State = context.EpTanzimatGroupTafsilis.Any() ? EntityState.Unchanged : EntityState.Added;
                    }

                    //if (!context.EpHesabTabagheh.Any())
                    //{
                    //    context.Entry(new EpHesabTabagheh() { SalId = 1, Code = 1, Name = "دارائیها", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabTabagheh.Any(s => s.Code == 1) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabTabagheh() { SalId = 1, Code = 2, Name = "بدهیها و حقوق صاحبان سهام", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabTabagheh.Any(s => s.Code == 2) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabTabagheh() { SalId = 1, Code = 3, Name = "عملکرد (سود و زیان)", IndexNoeHesab = 1, NoeHesab = "سود و زیانی", IsActive = true, SharhHesab = "" }).State = context.EpHesabTabagheh.Any(s => s.Code == 3) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabTabagheh() { SalId = 1, Code = 4, Name = "حسابهای انتظامی و کنترلی", IndexNoeHesab = 2, NoeHesab = "انتظامی و کنترلی", IsActive = true, SharhHesab = "" }).State = context.EpHesabTabagheh.Any(s => s.Code == 4) ? EntityState.Unchanged : EntityState.Added;
                    //    context.SaveChanges();
                    //}

                    //if (!context.EpHesabGroups.Any())
                    //{
                    //    context.Entry(new EpHesabGroup() { SalId = 1, Code = 10, Name = "دارائیهای جاری", HesabTabaghehId = 1, HesabTabaghehName = "دارائیها", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabGroups.Any(s => s.Code == 10) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabGroup() { SalId = 1, Code = 20, Name = "دارائیهای غیرجاری", HesabTabaghehId = 1, HesabTabaghehName = "دارائیها", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabGroups.Any(s => s.Code == 20) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabGroup() { SalId = 1, Code = 30, Name = "بدهیهای جاری", HesabTabaghehId = 2, HesabTabaghehName = "بدهیها و حقوق صاحبان سهام", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabGroups.Any(s => s.Code == 30) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabGroup() { SalId = 1, Code = 40, Name = "بدهیهای غیرجاری", HesabTabaghehId = 2, HesabTabaghehName = "بدهیها و حقوق صاحبان سهام", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabGroups.Any(s => s.Code == 40) ? EntityState.Unchanged : EntityState.Added;
                    //    context.SaveChanges();
                    //}
                    //if (!context.EpHesabCols.Any())
                    //{
                    //    context.Entry(new EpHesabCol() { SalId = 1, Code = 1001, Name = "موجودی نقد و بانک", GroupId = 1, GroupName = "دارائیهای جاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabCols.Any(s => s.Code == 1001) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabCol() { SalId = 1, Code = 2001, Name = "دارائیهای ثابت مشهود", GroupId = 2, GroupName = "دارائیهای غیرجاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabCols.Any(s => s.Code == 2001) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabCol() { SalId = 1, Code = 3001, Name = "حسابهای پرداختنی تجاری", GroupId = 3, GroupName = "بدهیهای جاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabCols.Any(s => s.Code == 3001) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabCol() { SalId = 1, Code = 4001, Name = "حسابهای پرداختنی غیرتجاری", GroupId = 4, GroupName = "بدهیهای غیرجاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = "" }).State = context.EpHesabCols.Any(s => s.Code == 4001) ? EntityState.Unchanged : EntityState.Added;
                    //    context.SaveChanges();
                    //}

                    //if (!context.EpHesabMoins.Any())
                    //{
                    //    context.Entry(new EpHesabMoin() { SalId = 1, Code = 100101, Name = "صندوق", GroupId = 1, GroupName = "دارائیهای جاری", ColId = 1, ColName = "موجودی نقد و بانک", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IsActive = true, SelectedGroupTafsiliLevel1 = "صندوق,", SelectedActivesystem = "دریافت و پرداخت,", SharhHesab = "" }).State = context.EpHesabMoins.Any(s => s.Code == 100101) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabMoin() { SalId = 1, Code = 200101, Name = "زمین", GroupId = 2, GroupName = "دارائیهای غیرجاری", ColId = 2, ColName = "دارائیهای ثابت مشهود", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IsActive = true, SelectedGroupTafsiliLevel1 = "دارائیها,", SelectedActivesystem = "اسناد حسابداری,", SharhHesab = "" }).State = context.EpHesabMoins.Any(s => s.Code == 200101) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabMoin() { SalId = 1, Code = 300101, Name = "بستانکاران تجاری", GroupId = 3, GroupName = "بدهیهای جاری", ColId = 3, ColName = "حسابهای پرداختنی تجاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IsActive = true, SelectedGroupTafsiliLevel1 = "اشخاص حقیقی,", SelectedActivesystem = "دریافت و پرداخت,", SharhHesab = "" }).State = context.EpHesabMoins.Any(s => s.Code == 300101) ? EntityState.Unchanged : EntityState.Added;
                    //    context.Entry(new EpHesabMoin() { SalId = 1, Code = 400101, Name = "حقوق و دستمزد پرداختنی", GroupId = 4, GroupName = "بدهیهای غیرجاری", ColId = 4, ColName = "حسابهای پرداختنی غیرتجاری", IndexMahiatHesab = 0, MahiatHesab = "مانده بدهکار", IsActive = true, SelectedGroupTafsiliLevel1 = "اشخاص حقوقی,", SelectedActivesystem = "اسناد حسابداری,", SharhHesab = "" }).State = context.EpHesabMoins.Any(s => s.Code == 400101) ? EntityState.Unchanged : EntityState.Added;
                    //    context.SaveChanges();
                    //}

                    if (!context.MsDefaults.Any())
                    {
                        context.Entry(new MsDefault() { MsUserId = 1, MajmoeId = 1, VahedId = 1, ShobeId = 1, DoreMaliId = 1 }).State = context.MsDefaults.Any(s => s.MsUserId == 1) ? EntityState.Unchanged : EntityState.Added;
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
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(), "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
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