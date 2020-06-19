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
                    if (!context.EpAllGroupTafsilis.Any())
                    {
                        var q1 = new EpGroupTafsiliLevel1() { Id = 1, Code = 10, StartCode = 10000001, EndCode = 10999999, Name = "سهامداران", IsActive = true, SalId = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 1, KeyCode = 10, ParentCode = 10, LevelNamber = 1, LevelName = "سهامداران", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص" , EpGroupTafsiliLevel1=q1}).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 10) ? EntityState.Unchanged : EntityState.Added;
                        var q2 = new EpGroupTafsiliLevel1() { Id = 2, Code = 20, StartCode = 20000001, EndCode = 20999999, Name = "کارکنان", IsActive = true, SalId = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 2, KeyCode = 20, ParentCode = 20, LevelNamber = 1, LevelName = "کارکنان", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q2 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 20) ? EntityState.Unchanged : EntityState.Added;
                        var q3 = new EpGroupTafsiliLevel1() { Id = 3, Code = 30, StartCode = 30000001, EndCode = 30999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 3, KeyCode = 30, ParentCode = 30, LevelNamber = 1, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q3 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 30) ? EntityState.Unchanged : EntityState.Added;
                        var q4 = new EpGroupTafsiliLevel1() { Id = 4, Code = 40, StartCode = 40000001, EndCode = 40999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 4, KeyCode = 40, ParentCode = 40, LevelNamber = 1, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q4 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 40) ? EntityState.Unchanged : EntityState.Added;
                        var q5 = new EpGroupTafsiliLevel1() { Id = 5, Code = 50, StartCode = 50000001, EndCode = 50999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 5, KeyCode = 50, ParentCode = 50, LevelNamber = 1, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص" , EpGroupTafsiliLevel1 = q5 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 50) ? EntityState.Unchanged : EntityState.Added;
                        var q6 = new EpGroupTafsiliLevel1() { Id = 6, Code = 60, StartCode = 60000001, EndCode = 60999999, Name = "مواد", IsActive = true, SalId = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار" };
                        context.Entry(new EpAllGroupTafsili() { Id = 6, KeyCode = 60, ParentCode = 60, LevelNamber = 1, LevelName = "مواد", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel1 = q6 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 60) ? EntityState.Unchanged : EntityState.Added;
                        var q7 = new EpGroupTafsiliLevel1() { Id = 7, Code = 65, StartCode = 65000001, EndCode = 65999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار" };
                        context.Entry(new EpAllGroupTafsili() { Id = 7, KeyCode = 65, ParentCode = 65, LevelNamber = 1, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel1 = q7 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 65) ? EntityState.Unchanged : EntityState.Added;
                        var q8 = new EpGroupTafsiliLevel1() { Id = 8, Code = 70, StartCode = 70000001, EndCode = 70999999, Name = "محصولات", IsActive = true, SalId = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار" };
                        context.Entry(new EpAllGroupTafsili() { Id = 8, KeyCode = 70, ParentCode = 70, LevelNamber = 1, LevelName = "محصولات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel1 = q8 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 70) ? EntityState.Unchanged : EntityState.Added;
                        var q9 = new EpGroupTafsiliLevel1() { Id = 9, Code = 75, StartCode = 75000001, EndCode = 75999999, Name = "کالاها", IsActive = true, SalId = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار" };
                        context.Entry(new EpAllGroupTafsili() { Id = 9, KeyCode = 75, ParentCode = 75, LevelNamber = 1, LevelName = "کالاها", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel1 = q9 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 75) ? EntityState.Unchanged : EntityState.Added;
                        var q10 = new EpGroupTafsiliLevel1() { Id = 10, Code = 80, StartCode = 80000001, EndCode = 80999999, Name = "دارائیها", IsActive = true, SalId = 1, TabaghehIndex = 2, TabaghehName = "دارائیها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 10, KeyCode = 80, ParentCode = 80, LevelNamber = 1, LevelName = "دارائیها", IsActive = true, SalId = 1, TabaghehGroupIndex = 2, TabaghehGroupName = "دارائیها", EpGroupTafsiliLevel1 = q10 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 80) ? EntityState.Unchanged : EntityState.Added;
                        var q11 = new EpGroupTafsiliLevel1() { Id = 11, Code = 85, StartCode = 85000001, EndCode = 85999999, Name = "صندوقها", IsActive = true, SalId = 1, TabaghehIndex = 3, TabaghehName = "صندوقها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 11, KeyCode = 85, ParentCode = 85, LevelNamber = 1, LevelName = "صندوقها", IsActive = true, SalId = 1, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel1 = q11 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 85) ? EntityState.Unchanged : EntityState.Added;
                        var q12 = new EpGroupTafsiliLevel1() { Id = 12, Code = 88, StartCode = 88000001, EndCode = 88999999, Name = "بانکها", IsActive = true, SalId = 1, TabaghehIndex = 4, TabaghehName = "بانکها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 12, KeyCode = 88, ParentCode = 88, LevelNamber = 1, LevelName = "بانکها", IsActive = true, SalId = 1, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel1 = q12 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 88) ? EntityState.Unchanged : EntityState.Added;
                        var q13 = new EpGroupTafsiliLevel1() { Id = 13, Code = 89, StartCode = 89000001, EndCode = 89999999, Name = "وامها", IsActive = true, SalId = 1, TabaghehIndex = 5, TabaghehName = "وامها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 13, KeyCode = 89, ParentCode = 89, LevelNamber = 1, LevelName = "وامها", IsActive = true, SalId = 1, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel1 = q13 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 89) ? EntityState.Unchanged : EntityState.Added;
                        var q14 = new EpGroupTafsiliLevel1() { Id = 14, Code = 90, StartCode = 90000001, EndCode = 90999999, Name = "مراکز هزینه", IsActive = true, SalId = 1, TabaghehIndex = 6, TabaghehName = "مراکز هزینه" };
                        context.Entry(new EpAllGroupTafsili() { Id = 14, KeyCode = 90, ParentCode = 90, LevelNamber = 1, LevelName = "مراکز هزینه", IsActive = true, SalId = 1, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel1 = q14 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 90) ? EntityState.Unchanged : EntityState.Added;
                        var q15 = new EpGroupTafsiliLevel1() { Id = 15, Code = 91, StartCode = 91000001, EndCode = 91999999, Name = "شعبات وابسته", IsActive = true, SalId = 1, TabaghehIndex = 7, TabaghehName = "شعبات وابسته" };
                        context.Entry(new EpAllGroupTafsili() { Id = 15, KeyCode = 91, ParentCode = 91, LevelNamber = 1, LevelName = "شعبات وابسته", IsActive = true, SalId = 1, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel1 = q15 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 91) ? EntityState.Unchanged : EntityState.Added;
                        var q16 = new EpGroupTafsiliLevel1() { Id = 16, Code = 92, StartCode = 92000001, EndCode = 92999999, Name = "پروژه ها", IsActive = true, SalId = 1, TabaghehIndex = 8, TabaghehName = "پروژه ها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 16, KeyCode = 92, ParentCode = 92, LevelNamber = 1, LevelName = "پروژه ها", IsActive = true, SalId = 1, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel1 = q16 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 92) ? EntityState.Unchanged : EntityState.Added;
                        var q17 = new EpGroupTafsiliLevel1() { Id = 17, Code = 93, StartCode = 93000001, EndCode = 93999999, Name = "قراردادها", IsActive = true, SalId = 1, TabaghehIndex = 9, TabaghehName = "قراردادها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 17, KeyCode = 93, ParentCode = 93, LevelNamber = 1, LevelName = "قراردادها", IsActive = true, SalId = 1, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel1 = q17 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 93) ? EntityState.Unchanged : EntityState.Added;
                        var q18 = new EpGroupTafsiliLevel1() { Id = 18, Code = 94, StartCode = 94000001, EndCode = 94999999, Name = "انبارها", IsActive = true, SalId = 1, TabaghehIndex = 10, TabaghehName = "انبارها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 18, KeyCode = 94, ParentCode = 94, LevelNamber = 1, LevelName = "انبارها", IsActive = true, SalId = 1, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel1 = q18 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 94) ? EntityState.Unchanged : EntityState.Added;
                        var q19 = new EpGroupTafsiliLevel1() { Id = 19, Code = 95, StartCode = 95000001, EndCode = 95999999, Name = "سایر", IsActive = true, SalId = 1, TabaghehIndex = 11, TabaghehName = "سایر" };
                        context.Entry(new EpAllGroupTafsili() { Id = 19, KeyCode = 95, ParentCode = 95, LevelNamber = 1, LevelName = "سایر", IsActive = true, SalId = 1, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel1 = q19 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 95) ? EntityState.Unchanged : EntityState.Added;

                        /////////////////////////
                        var q20 = new EpGroupTafsiliLevel2() { Id = 20, Code =  101, StartCode = 101000001, EndCode = 101999999, Name = "سهامداران", IsActive = true, SalId = 1, Level1Id=1 };
                        context.Entry(new EpAllGroupTafsili() { Id = 20, KeyCode =  101, ParentCode = 10, LevelNamber = 2, LevelName = "سهامداران", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q20 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 101) ? EntityState.Unchanged : EntityState.Added;
                        var q21 = new EpGroupTafsiliLevel2() { Id = 21, Code =  201, StartCode = 201000001, EndCode = 201999999, Name = "کارکنان", IsActive = true, SalId = 1, Level1Id = 2 };
                        context.Entry(new EpAllGroupTafsili() { Id = 21, KeyCode =  201, ParentCode = 20, LevelNamber = 2, LevelName = "کارکنان", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص" ,EpGroupTafsiliLevel2 = q21 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 201) ? EntityState.Unchanged : EntityState.Added;
                        var q22 = new EpGroupTafsiliLevel2() { Id = 22, Code =  301, StartCode = 301000001, EndCode = 301999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1, Level1Id = 3 };
                        context.Entry(new EpAllGroupTafsili() { Id = 22, KeyCode =  301, ParentCode = 30, LevelNamber = 2, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص" ,EpGroupTafsiliLevel2 = q22 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 301) ? EntityState.Unchanged : EntityState.Added;
                        var q23 = new EpGroupTafsiliLevel2() { Id = 23, Code =  401, StartCode = 401000001, EndCode = 401999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, Level1Id = 4};
                        context.Entry(new EpAllGroupTafsili() { Id = 23, KeyCode =  401, ParentCode = 40, LevelNamber = 2, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص",EpGroupTafsiliLevel2 = q23 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 401) ? EntityState.Unchanged : EntityState.Added;
                        var q24 = new EpGroupTafsiliLevel2() { Id = 24, Code =  501, StartCode = 501000001, EndCode = 501999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, Level1Id = 5 };
                        context.Entry(new EpAllGroupTafsili() { Id = 24, KeyCode =  501, ParentCode = 50, LevelNamber = 2, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص" ,EpGroupTafsiliLevel2 = q24 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 501) ? EntityState.Unchanged : EntityState.Added;
                        var q25 = new EpGroupTafsiliLevel2() { Id = 25, Code =  601, StartCode = 601000001, EndCode = 601999999, Name = "مواد", IsActive = true, SalId = 1, Level1Id = 6 };
                        context.Entry(new EpAllGroupTafsili() { Id = 25, KeyCode =  601, ParentCode = 60, LevelNamber = 2, LevelName = "مواد", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار" ,EpGroupTafsiliLevel2 = q25 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 601) ? EntityState.Unchanged : EntityState.Added;
                        var q26 = new EpGroupTafsiliLevel2() { Id = 26, Code =  651, StartCode = 651000001, EndCode = 651999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1, Level1Id = 7};
                        context.Entry(new EpAllGroupTafsili() { Id = 26, KeyCode =  651, ParentCode = 65, LevelNamber = 2, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel2 = q26 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 651) ? EntityState.Unchanged : EntityState.Added;
                        var q27 = new EpGroupTafsiliLevel2() { Id = 27, Code =  701, StartCode = 701000001, EndCode = 701999999, Name = "محصولات", IsActive = true, SalId = 1, Level1Id = 8 };
                        context.Entry(new EpAllGroupTafsili() { Id = 27, KeyCode =  701, ParentCode = 70, LevelNamber = 2, LevelName = "محصولات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار" ,EpGroupTafsiliLevel2 = q27 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 701) ? EntityState.Unchanged : EntityState.Added;
                        var q28 = new EpGroupTafsiliLevel2() { Id = 28, Code =  751, StartCode = 751000001, EndCode = 751999999, Name = "کالاها", IsActive = true, SalId = 1, Level1Id = 9 };
                        context.Entry(new EpAllGroupTafsili() { Id = 28, KeyCode =  751, ParentCode = 75, LevelNamber = 2, LevelName = "کالاها", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار" ,EpGroupTafsiliLevel2 = q28 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 751) ? EntityState.Unchanged : EntityState.Added;
                        var q29 = new EpGroupTafsiliLevel2() { Id = 29, Code = 801, StartCode = 801000001, EndCode = 801999999, Name = "دارائیها", IsActive = true, SalId = 1, Level1Id = 10 };
                        context.Entry(new EpAllGroupTafsili() { Id = 29, KeyCode = 801, ParentCode = 80, LevelNamber = 2, LevelName = "دارائیها", IsActive = true, SalId = 1, TabaghehGroupIndex = 2, TabaghehGroupName = "دارائیها" ,EpGroupTafsiliLevel2 = q29 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 801) ? EntityState.Unchanged : EntityState.Added;
                        var q30 = new EpGroupTafsiliLevel2() { Id = 30, Code = 851, StartCode = 851000001, EndCode = 851999999, Name = "صندوقها", IsActive = true, SalId = 1, Level1Id = 11 };
                        context.Entry(new EpAllGroupTafsili() { Id = 30, KeyCode = 851, ParentCode = 85, LevelNamber = 2, LevelName = "صندوقها", IsActive = true, SalId = 1, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel2 = q30 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 851) ? EntityState.Unchanged : EntityState.Added;
                        var q31 = new EpGroupTafsiliLevel2() { Id = 31, Code = 881, StartCode = 881000001, EndCode = 881999999, Name = "بانکها", IsActive = true, SalId = 1, Level1Id = 12 };
                        context.Entry(new EpAllGroupTafsili() { Id = 31, KeyCode = 881, ParentCode = 88, LevelNamber = 2, LevelName = "بانکها", IsActive = true, SalId = 1, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel2 = q31 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 881) ? EntityState.Unchanged : EntityState.Added;
                        var q32 = new EpGroupTafsiliLevel2() { Id = 32, Code = 891, StartCode = 891000001, EndCode = 891999999, Name = "وامها", IsActive = true, SalId = 1, Level1Id = 13};
                        context.Entry(new EpAllGroupTafsili() { Id = 32, KeyCode = 891, ParentCode = 89, LevelNamber = 2, LevelName = "وامها", IsActive = true, SalId = 1, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel2 = q32 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 891) ? EntityState.Unchanged : EntityState.Added;
                        var q33 = new EpGroupTafsiliLevel2() { Id = 33, Code = 901, StartCode = 901000001, EndCode = 901999999, Name = "مراکز هزینه", IsActive = true, SalId = 1, Level1Id = 14};
                        context.Entry(new EpAllGroupTafsili() { Id = 33, KeyCode = 901, ParentCode = 90, LevelNamber = 2, LevelName = "مراکز هزینه", IsActive = true, SalId = 1, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel2 = q33 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 901) ? EntityState.Unchanged : EntityState.Added;
                        var q34 = new EpGroupTafsiliLevel2() { Id = 34, Code = 911, StartCode = 911000001, EndCode = 911999999, Name = "شعبات وابسته", IsActive = true, SalId = 1, Level1Id = 15 };
                        context.Entry(new EpAllGroupTafsili() { Id = 34, KeyCode = 911, ParentCode = 91, LevelNamber = 2, LevelName = "شعبات وابسته", IsActive = true, SalId = 1, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel2 = q34 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 911) ? EntityState.Unchanged : EntityState.Added;
                        var q35 = new EpGroupTafsiliLevel2() { Id = 35, Code = 921, StartCode = 921000001, EndCode = 921999999, Name = "پروژه ها", IsActive = true, SalId = 1, Level1Id = 16 };
                        context.Entry(new EpAllGroupTafsili() { Id = 35, KeyCode = 921, ParentCode = 92, LevelNamber = 2, LevelName = "پروژه ها", IsActive = true, SalId = 1, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel2 = q35 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 921) ? EntityState.Unchanged : EntityState.Added;
                        var q36 = new EpGroupTafsiliLevel2() { Id = 36, Code = 931, StartCode = 931000001, EndCode = 931999999, Name = "قراردادها", IsActive = true, SalId = 1, Level1Id = 17 };
                        context.Entry(new EpAllGroupTafsili() { Id = 36, KeyCode = 931, ParentCode = 93, LevelNamber = 2, LevelName = "قراردادها", IsActive = true, SalId = 1, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel2 = q36 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 931) ? EntityState.Unchanged : EntityState.Added;
                        var q37 = new EpGroupTafsiliLevel2() { Id = 37, Code = 941, StartCode = 941000001, EndCode = 941999999, Name = "انبارها", IsActive = true, SalId = 1, Level1Id = 18 };
                        context.Entry(new EpAllGroupTafsili() { Id = 37, KeyCode = 941, ParentCode = 94, LevelNamber = 2, LevelName = "انبارها", IsActive = true, SalId = 1, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel2 = q37 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 941) ? EntityState.Unchanged : EntityState.Added;
                        var q38 = new EpGroupTafsiliLevel2() { Id = 38, Code = 951, StartCode = 951000001, EndCode = 951999999, Name = "سایر", IsActive = true, SalId = 1, Level1Id = 19 };
                        context.Entry(new EpAllGroupTafsili() { Id = 38, KeyCode = 951, ParentCode = 95, LevelNamber = 2, LevelName = "سایر", IsActive = true, SalId = 1, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel2 = q38 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 951) ? EntityState.Unchanged : EntityState.Added;

                        /////////////////////////
                        var q39 = new EpGroupTafsiliLevel3() { Id = 39, Code = 1011, StartCode = 1011000001, EndCode = 1011999999, Name = "سهامداران", IsActive = true, SalId = 1, Level2Id=20};
                        context.Entry(new EpAllGroupTafsili() { Id = 39, KeyCode = 1011, ParentCode = 101, LevelNamber = 3, LevelName = "سهامداران", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q39 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 1011) ? EntityState.Unchanged : EntityState.Added;
                        var q40 = new EpGroupTafsiliLevel3() { Id = 40, Code = 2011, StartCode = 2011000001, EndCode = 2011999999, Name = "کارکنان", IsActive = true, SalId = 1, Level2Id = 21 };
                        context.Entry(new EpAllGroupTafsili() { Id = 40, KeyCode = 2011, ParentCode = 201, LevelNamber = 3, LevelName = "کارکنان", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q40 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 2011) ? EntityState.Unchanged : EntityState.Added;
                        var q41 = new EpGroupTafsiliLevel3() { Id = 41, Code = 3011, StartCode = 3011000001, EndCode = 3011999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1, Level2Id = 22};
                        context.Entry(new EpAllGroupTafsili() { Id = 41, KeyCode = 3011, ParentCode = 301, LevelNamber = 3, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q41 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 3011) ? EntityState.Unchanged : EntityState.Added;
                        var q42 = new EpGroupTafsiliLevel3() { Id = 42, Code = 4011, StartCode = 4011000001, EndCode = 4011999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, Level2Id = 23};
                        context.Entry(new EpAllGroupTafsili() { Id = 42, KeyCode = 4011, ParentCode = 401, LevelNamber = 3, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q42 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 4011) ? EntityState.Unchanged : EntityState.Added;
                        var q43 = new EpGroupTafsiliLevel3() { Id = 43, Code = 5011, StartCode = 5011000001, EndCode = 5011999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, Level2Id = 24 };
                        context.Entry(new EpAllGroupTafsili() { Id = 43, KeyCode = 5011, ParentCode = 501, LevelNamber = 3, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q43 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 5011) ? EntityState.Unchanged : EntityState.Added;
                        var q44 = new EpGroupTafsiliLevel3() { Id = 44, Code = 6011, StartCode = 6011000001, EndCode = 6011999999, Name = "مواد", IsActive = true, SalId = 1, Level2Id = 25};
                        context.Entry(new EpAllGroupTafsili() { Id = 44, KeyCode = 6011, ParentCode = 601, LevelNamber = 3, LevelName = "مواد", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel3 = q44 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 6011) ? EntityState.Unchanged : EntityState.Added;
                        var q45 = new EpGroupTafsiliLevel3() { Id = 45, Code = 6511, StartCode = 6511000001, EndCode = 6511999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1, Level2Id = 26};
                        context.Entry(new EpAllGroupTafsili() { Id = 45, KeyCode = 6511, ParentCode = 651, LevelNamber = 3, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel3 = q45 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 6511) ? EntityState.Unchanged : EntityState.Added;
                        var q46 = new EpGroupTafsiliLevel3() { Id = 46, Code = 7011, StartCode = 7011000001, EndCode = 7011999999, Name = "محصولات", IsActive = true, SalId = 1, Level2Id = 27};
                        context.Entry(new EpAllGroupTafsili() { Id = 46, KeyCode = 7011, ParentCode = 701, LevelNamber = 3, LevelName = "محصولات", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel3 = q46 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 7011) ? EntityState.Unchanged : EntityState.Added;
                        var q47 = new EpGroupTafsiliLevel3() { Id = 47, Code = 7511, StartCode = 7511000001, EndCode = 7511999999, Name = "کالاها", IsActive = true, SalId = 1, Level2Id = 28};
                        context.Entry(new EpAllGroupTafsili() { Id = 47, KeyCode = 7511, ParentCode = 751, LevelNamber = 3, LevelName = "کالاها", IsActive = true, SalId = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار", EpGroupTafsiliLevel3 = q47 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 7511) ? EntityState.Unchanged : EntityState.Added;
                        var q48 = new EpGroupTafsiliLevel3() { Id = 48, Code = 8011, StartCode = 8011000001, EndCode = 8011999999, Name = "دارائیها", IsActive = true, SalId = 1, Level2Id = 29 };
                        context.Entry(new EpAllGroupTafsili() { Id = 48, KeyCode = 8011, ParentCode = 801, LevelNamber = 3, LevelName = "دارائیها", IsActive = true, SalId = 1, TabaghehGroupIndex = 2, TabaghehGroupName = "دارائیها", EpGroupTafsiliLevel3 = q48 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8011) ? EntityState.Unchanged : EntityState.Added;
                        var q49 = new EpGroupTafsiliLevel3() { Id = 49, Code = 8511, StartCode = 8511000001, EndCode = 8511999999, Name = "صندوقها", IsActive = true, SalId = 1, Level2Id = 30 };
                        context.Entry(new EpAllGroupTafsili() { Id = 49, KeyCode = 8511, ParentCode = 851, LevelNamber = 3, LevelName = "صندوقها", IsActive = true, SalId = 1, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel3 = q49 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8511) ? EntityState.Unchanged : EntityState.Added;
                        var q50 = new EpGroupTafsiliLevel3() { Id = 50, Code = 8811, StartCode = 8811000001, EndCode = 8811999999, Name = "بانکها", IsActive = true, SalId = 1, Level2Id = 31 };
                        context.Entry(new EpAllGroupTafsili() { Id = 50, KeyCode = 8811, ParentCode = 881, LevelNamber = 3, LevelName = "بانکها", IsActive = true, SalId = 1, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel3 = q50 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8811) ? EntityState.Unchanged : EntityState.Added;
                        var q51 = new EpGroupTafsiliLevel3() { Id = 51, Code = 8911, StartCode = 8911000001, EndCode = 8911999999, Name = "وامها", IsActive = true, SalId = 1, Level2Id = 32 };
                        context.Entry(new EpAllGroupTafsili() { Id = 51, KeyCode = 8911, ParentCode = 891, LevelNamber = 3, LevelName = "وامها", IsActive = true, SalId = 1, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel3 = q51 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8911) ? EntityState.Unchanged : EntityState.Added;
                        var q52 = new EpGroupTafsiliLevel3() { Id = 52, Code = 9011, StartCode = 9011000001, EndCode = 9011999999, Name = "مراکز هزینه", IsActive = true, SalId = 1, Level2Id = 33};
                        context.Entry(new EpAllGroupTafsili() { Id = 52, KeyCode = 9011, ParentCode = 901, LevelNamber = 3, LevelName = "مراکز هزینه", IsActive = true, SalId = 1, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel3 = q52 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9011) ? EntityState.Unchanged : EntityState.Added;
                        var q53 = new EpGroupTafsiliLevel3() { Id = 53, Code = 9111, StartCode = 9111000001, EndCode = 9111999999, Name = "شعبات وابسته", IsActive = true, SalId = 1, Level2Id = 34 };
                        context.Entry(new EpAllGroupTafsili() { Id = 53, KeyCode = 9111, ParentCode = 911, LevelNamber = 3, LevelName = "شعبات وابسته", IsActive = true, SalId = 1, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel3 = q53 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9111) ? EntityState.Unchanged : EntityState.Added;
                        var q54 = new EpGroupTafsiliLevel3() { Id = 54, Code = 9211, StartCode = 9211000001, EndCode = 9211999999, Name = "پروژه ها", IsActive = true, SalId = 1, Level2Id = 35 };
                        context.Entry(new EpAllGroupTafsili() { Id = 54, KeyCode = 9211, ParentCode = 921, LevelNamber = 3, LevelName = "پروژه ها", IsActive = true, SalId = 1, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel3 = q54 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9211) ? EntityState.Unchanged : EntityState.Added;
                        var q55 = new EpGroupTafsiliLevel3() { Id = 55, Code = 9311, StartCode = 9311000001, EndCode = 9311999999, Name = "قراردادها", IsActive = true, SalId = 1, Level2Id = 36 };
                        context.Entry(new EpAllGroupTafsili() { Id = 55, KeyCode = 9311, ParentCode = 931, LevelNamber = 3, LevelName = "قراردادها", IsActive = true, SalId = 1, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel3 = q55 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9311) ? EntityState.Unchanged : EntityState.Added;
                        var q56 = new EpGroupTafsiliLevel3() { Id = 56, Code = 9411, StartCode = 9411000001, EndCode = 9411999999, Name = "انبارها", IsActive = true, SalId = 1, Level2Id = 37 };
                        context.Entry(new EpAllGroupTafsili() { Id = 56, KeyCode = 9411, ParentCode = 941, LevelNamber = 3, LevelName = "انبارها", IsActive = true, SalId = 1, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel3 = q56 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9411) ? EntityState.Unchanged : EntityState.Added;
                        var q57 = new EpGroupTafsiliLevel3() { Id = 57, Code = 9511, StartCode = 9511000001, EndCode = 9511999999, Name = "سایر", IsActive = true, SalId = 1, Level2Id = 38 };
                        context.Entry(new EpAllGroupTafsili() { Id = 57, KeyCode = 9511, ParentCode = 951, LevelNamber = 3, LevelName = "سایر", IsActive = true, SalId = 1, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel3 = q57 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9511) ? EntityState.Unchanged : EntityState.Added;

                    }

                    if (!context.MsActiveSystems.Any())
                    {
                        context.Entry(new MsActiveSystem() { Id = 10, Code = 10, Name = "فروش و خرید", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 10) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 15, Code = 15, Name = "دریافت و پرداخت", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 15) ? EntityState.Unchanged : EntityState.Added;
                        //context.Entry(new MsActiveSystem() { Id = 20, Code = 20, Name = "اسناد حسابداری", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 20) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 25, Code = 25, Name = "انبار و کالا", IsActive = false }).State = context.MsActiveSystems.Any(s => s.Code == 25) ? EntityState.Unchanged : EntityState.Added;
                    }

                    ////////////////////////////////////////////////// کدینگ حسابداری //////////////////////////////////////////////////////
                    context.Entry(new EpTanzimatCodingHesabdari() { SalId = 1, HesabTabaghehCarakter = 1, HesabGroupCarakter = 1, HesabColCarakter = 1, HesabMoinLevel1Carakter = 2, HesabTabaghehMinCode = "1", HesabTabaghehMaxCode = "9", HesabGroupMinCode = "1", HesabGroupMaxCode = "9", HesabColMinCode = "1", HesabColMaxCode = "9", HesabMoinLevel1MinCode = "01", HesabMoinLevel1MaxCode = "99" }).State = context.EpTanzimatCodingHesabdaris.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;
                    context.Entry(new EpTanzimatGroupTafsili() { SalId = 1, GroupTafsiliLevel1Carakter = 2, GroupTafsiliLevel2Carakter = 1, GroupTafsiliLevel3Carakter = 1, CodeTafsiliCarakter = 6, GroupTafsiliLevel1MinCode = "10", GroupTafsiliLevel1MaxCode = "99", GroupTafsiliLevel2MinCode = "1", GroupTafsiliLevel2MaxCode = "9", GroupTafsiliLevel3MinCode = "1", GroupTafsiliLevel3MaxCode = "9", CodeTafsiliMinCode = "000001", CodeTafsiliMaxCode = "999999", IsActiveGroupTafsiliLevel1 = true }).State = context.EpTanzimatGroupTafsilis.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;
                    context.Entry(new EpTanzimatAnbarVKala() { SalId = 1, CodeAnbarCarakter = 3, CodeTabagehKalaCarakter = 2, CodeGroupAsliKalaCarakter = 3, CodeGroupFareeKalaCarakter = 3, CodeNameKalaCarakter = 4, CodeVahedKalaCarakter = 3, CodeAnbarMinCode = "1", CodeAnbarMaxCode = "999", CodeGroupAsliKalaMinCode = "001", CodeGroupAsliKalaMaxCode = "999", CodeGroupFareeKalaMinCode = "001", CodeGroupFareeKalaMaxCode = "999", CodeNameKalaMinCode = "0001", CodeNameKalaMaxCode = "9999", CodeVahedKalaMinCode = "1", CodeVahedKalaMaxCode = "999" }).State = context.EpTanzimatAnbarVKalas.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;

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