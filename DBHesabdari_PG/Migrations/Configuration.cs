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
    using System.Collections.Generic;
    using DBHesabdari_PG.Models.EP.CodingAnbar;
    using DBHesabdari_PG.Models.Tz;

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
                    /////////////// تعریف گروه تفصیلی در حسابدای
                    if (context.EpAllGroupTafsilis.Any())
                    {
                        var q1 = new EpGroupTafsiliLevel1() { Id = 1, Code = 10, StartCode = 10000001, EndCode = 10999999, Name = "سهامداران", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 1, KeyCode = 10, ParentCode = 10, LevelName = "سهامداران", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q1 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 10) ? EntityState.Unchanged : EntityState.Added;
                        var q2 = new EpGroupTafsiliLevel1() { Id = 2, Code = 20, StartCode = 20000001, EndCode = 20999999, Name = "کارکنان", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 2, KeyCode = 20, ParentCode = 20, LevelName = "کارکنان", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q2 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 20) ? EntityState.Unchanged : EntityState.Added;
                        var q3 = new EpGroupTafsiliLevel1() { Id = 3, Code = 30, StartCode = 30000001, EndCode = 30999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 3, KeyCode = 30, ParentCode = 30, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q3 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 30) ? EntityState.Unchanged : EntityState.Added;
                        var q4 = new EpGroupTafsiliLevel1() { Id = 4, Code = 40, StartCode = 40000001, EndCode = 40999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 4, KeyCode = 40, ParentCode = 40, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q4 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 40) ? EntityState.Unchanged : EntityState.Added;
                        var q5 = new EpGroupTafsiliLevel1() { Id = 5, Code = 50, StartCode = 50000001, EndCode = 50999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 0, TabaghehName = "اشخاص" };
                        context.Entry(new EpAllGroupTafsili() { Id = 5, KeyCode = 50, ParentCode = 50, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel1 = q5 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 50) ? EntityState.Unchanged : EntityState.Added;
                        var q6 = new EpGroupTafsiliLevel1() { Id = 6, Code = 60, StartCode = 60000001, EndCode = 60999999, Name = "مواد", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار و اموال" };
                        context.Entry(new EpAllGroupTafsili() { Id = 6, KeyCode = 60, ParentCode = 60, LevelName = "مواد", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel1 = q6 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 60) ? EntityState.Unchanged : EntityState.Added;
                        var q7 = new EpGroupTafsiliLevel1() { Id = 7, Code = 65, StartCode = 65000001, EndCode = 65999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار و اموال" };
                        context.Entry(new EpAllGroupTafsili() { Id = 7, KeyCode = 65, ParentCode = 65, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel1 = q7 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 65) ? EntityState.Unchanged : EntityState.Added;
                        var q8 = new EpGroupTafsiliLevel1() { Id = 8, Code = 70, StartCode = 70000001, EndCode = 70999999, Name = "محصولات", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار و اموال" };
                        context.Entry(new EpAllGroupTafsili() { Id = 8, KeyCode = 70, ParentCode = 70, LevelName = "محصولات", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel1 = q8 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 70) ? EntityState.Unchanged : EntityState.Added;
                        var q9 = new EpGroupTafsiliLevel1() { Id = 9, Code = 75, StartCode = 75000001, EndCode = 75999999, Name = "کالاها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار و اموال" };
                        context.Entry(new EpAllGroupTafsili() { Id = 9, KeyCode = 75, ParentCode = 75, LevelName = "کالاها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel1 = q9 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 75) ? EntityState.Unchanged : EntityState.Added;
                        var q10 = new EpGroupTafsiliLevel1() { Id = 10, Code = 80, StartCode = 80000001, EndCode = 80999999, Name = "اموال", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 1, TabaghehName = "اقلام انبار و اموال" };
                        context.Entry(new EpAllGroupTafsili() { Id = 10, KeyCode = 80, ParentCode = 80, LevelName = "اموال", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel1 = q10 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 80) ? EntityState.Unchanged : EntityState.Added;
                        var q11 = new EpGroupTafsiliLevel1() { Id = 11, Code = 87, StartCode = 87000001, EndCode = 87999999, Name = "صندوقها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 3, TabaghehName = "صندوقها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 11, KeyCode = 87, ParentCode = 87, LevelName = "صندوقها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel1 = q11 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 87) ? EntityState.Unchanged : EntityState.Added;
                        var q12 = new EpGroupTafsiliLevel1() { Id = 12, Code = 88, StartCode = 88000001, EndCode = 88999999, Name = "بانکها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 4, TabaghehName = "بانکها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 12, KeyCode = 88, ParentCode = 88, LevelName = "بانکها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel1 = q12 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 88) ? EntityState.Unchanged : EntityState.Added;
                        var q13 = new EpGroupTafsiliLevel1() { Id = 13, Code = 89, StartCode = 89000001, EndCode = 89999999, Name = "وامها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 5, TabaghehName = "وامها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 13, KeyCode = 89, ParentCode = 89, LevelName = "وامها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel1 = q13 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 89) ? EntityState.Unchanged : EntityState.Added;
                        var q14 = new EpGroupTafsiliLevel1() { Id = 14, Code = 90, StartCode = 90000001, EndCode = 90999999, Name = "مراکز هزینه", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 6, TabaghehName = "مراکز هزینه" };
                        context.Entry(new EpAllGroupTafsili() { Id = 14, KeyCode = 90, ParentCode = 90, LevelName = "مراکز هزینه", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel1 = q14 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 90) ? EntityState.Unchanged : EntityState.Added;
                        var q15 = new EpGroupTafsiliLevel1() { Id = 15, Code = 91, StartCode = 91000001, EndCode = 91999999, Name = "شعبات وابسته", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 7, TabaghehName = "شعبات وابسته" };
                        context.Entry(new EpAllGroupTafsili() { Id = 15, KeyCode = 91, ParentCode = 91, LevelName = "شعبات وابسته", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel1 = q15 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 91) ? EntityState.Unchanged : EntityState.Added;
                        var q16 = new EpGroupTafsiliLevel1() { Id = 16, Code = 92, StartCode = 92000001, EndCode = 92999999, Name = "پروژه ها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 8, TabaghehName = "پروژه ها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 16, KeyCode = 92, ParentCode = 92, LevelName = "پروژه ها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel1 = q16 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 92) ? EntityState.Unchanged : EntityState.Added;
                        var q17 = new EpGroupTafsiliLevel1() { Id = 17, Code = 93, StartCode = 93000001, EndCode = 93999999, Name = "قراردادها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 9, TabaghehName = "قراردادها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 17, KeyCode = 93, ParentCode = 93, LevelName = "قراردادها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel1 = q17 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 93) ? EntityState.Unchanged : EntityState.Added;
                        var q18 = new EpGroupTafsiliLevel1() { Id = 18, Code = 94, StartCode = 94000001, EndCode = 94999999, Name = "انبارها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 10, TabaghehName = "انبارها" };
                        context.Entry(new EpAllGroupTafsili() { Id = 18, KeyCode = 94, ParentCode = 94, LevelName = "انبارها", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel1 = q18 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 94) ? EntityState.Unchanged : EntityState.Added;
                        var q19 = new EpGroupTafsiliLevel1() { Id = 19, Code = 95, StartCode = 95000001, EndCode = 95999999, Name = "سایر", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 11, TabaghehName = "سایر" };
                        context.Entry(new EpAllGroupTafsili() { Id = 19, KeyCode = 95, ParentCode = 95, LevelName = "سایر", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel1 = q19 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 95) ? EntityState.Unchanged : EntityState.Added;

                        /////////////////////////
                        var q20 = new EpGroupTafsiliLevel2() { Id = 20, Code = 101, StartCode = 101000001, EndCode = 101999999, Name = "سهامداران", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 1 };
                        context.Entry(new EpAllGroupTafsili() { Id = 20, KeyCode = 101, ParentCode = 10, LevelName = "سهامداران", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q20 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 101) ? EntityState.Unchanged : EntityState.Added;
                        var q21 = new EpGroupTafsiliLevel2() { Id = 21, Code = 201, StartCode = 201000001, EndCode = 201999999, Name = "کارکنان", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 2 };
                        context.Entry(new EpAllGroupTafsili() { Id = 21, KeyCode = 201, ParentCode = 20, LevelName = "کارکنان", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q21 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 201) ? EntityState.Unchanged : EntityState.Added;
                        var q22 = new EpGroupTafsiliLevel2() { Id = 22, Code = 301, StartCode = 301000001, EndCode = 301999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 3 };
                        context.Entry(new EpAllGroupTafsili() { Id = 22, KeyCode = 301, ParentCode = 30, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q22 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 301) ? EntityState.Unchanged : EntityState.Added;
                        var q23 = new EpGroupTafsiliLevel2() { Id = 23, Code = 401, StartCode = 401000001, EndCode = 401999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 4 };
                        context.Entry(new EpAllGroupTafsili() { Id = 23, KeyCode = 401, ParentCode = 40, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q23 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 401) ? EntityState.Unchanged : EntityState.Added;
                        var q24 = new EpGroupTafsiliLevel2() { Id = 24, Code = 501, StartCode = 501000001, EndCode = 501999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 5 };
                        context.Entry(new EpAllGroupTafsili() { Id = 24, KeyCode = 501, ParentCode = 50, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel2 = q24 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 501) ? EntityState.Unchanged : EntityState.Added;
                        var q25 = new EpGroupTafsiliLevel2() { Id = 25, Code = 601, StartCode = 601000001, EndCode = 601999999, Name = "مواد", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 6 };
                        context.Entry(new EpAllGroupTafsili() { Id = 25, KeyCode = 601, ParentCode = 60, LevelName = "مواد", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel2 = q25 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 601) ? EntityState.Unchanged : EntityState.Added;
                        var q26 = new EpGroupTafsiliLevel2() { Id = 26, Code = 651, StartCode = 651000001, EndCode = 651999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 7 };
                        context.Entry(new EpAllGroupTafsili() { Id = 26, KeyCode = 651, ParentCode = 65, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel2 = q26 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 651) ? EntityState.Unchanged : EntityState.Added;
                        var q27 = new EpGroupTafsiliLevel2() { Id = 27, Code = 701, StartCode = 701000001, EndCode = 701999999, Name = "محصولات", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 8 };
                        context.Entry(new EpAllGroupTafsili() { Id = 27, KeyCode = 701, ParentCode = 70, LevelName = "محصولات", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel2 = q27 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 701) ? EntityState.Unchanged : EntityState.Added;
                        var q28 = new EpGroupTafsiliLevel2() { Id = 28, Code = 751, StartCode = 751000001, EndCode = 751999999, Name = "کالاها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 9 };
                        context.Entry(new EpAllGroupTafsili() { Id = 28, KeyCode = 751, ParentCode = 75, LevelName = "کالاها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel2 = q28 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 751) ? EntityState.Unchanged : EntityState.Added;
                        var q29 = new EpGroupTafsiliLevel2() { Id = 29, Code = 801, StartCode = 801000001, EndCode = 801999999, Name = "اموال", IsActive = true, SalId = 1 , LevelNumber = 1, Level1Id = 10 };
                        context.Entry(new EpAllGroupTafsili() { Id = 29, KeyCode = 801, ParentCode = 80, LevelName = "اموال", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel2 = q29 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 801) ? EntityState.Unchanged : EntityState.Added;
                        var q30 = new EpGroupTafsiliLevel2() { Id = 30, Code = 871, StartCode = 871000001, EndCode = 871999999, Name = "صندوقها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 11 };
                        context.Entry(new EpAllGroupTafsili() { Id = 30, KeyCode = 871, ParentCode = 87, LevelName = "صندوقها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel2 = q30 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 871) ? EntityState.Unchanged : EntityState.Added;
                        var q31 = new EpGroupTafsiliLevel2() { Id = 31, Code = 881, StartCode = 881000001, EndCode = 881999999, Name = "بانکها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 12 };
                        context.Entry(new EpAllGroupTafsili() { Id = 31, KeyCode = 881, ParentCode = 88, LevelName = "بانکها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel2 = q31 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 881) ? EntityState.Unchanged : EntityState.Added;
                        var q32 = new EpGroupTafsiliLevel2() { Id = 32, Code = 891, StartCode = 891000001, EndCode = 891999999, Name = "وامها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 13 };
                        context.Entry(new EpAllGroupTafsili() { Id = 32, KeyCode = 891, ParentCode = 89, LevelName = "وامها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel2 = q32 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 891) ? EntityState.Unchanged : EntityState.Added;
                        var q33 = new EpGroupTafsiliLevel2() { Id = 33, Code = 901, StartCode = 901000001, EndCode = 901999999, Name = "مراکز هزینه", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 14 };
                        context.Entry(new EpAllGroupTafsili() { Id = 33, KeyCode = 901, ParentCode = 90, LevelName = "مراکز هزینه", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel2 = q33 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 901) ? EntityState.Unchanged : EntityState.Added;
                        var q34 = new EpGroupTafsiliLevel2() { Id = 34, Code = 911, StartCode = 911000001, EndCode = 911999999, Name = "شعبات وابسته", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 15 };
                        context.Entry(new EpAllGroupTafsili() { Id = 34, KeyCode = 911, ParentCode = 91, LevelName = "شعبات وابسته", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel2 = q34 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 911) ? EntityState.Unchanged : EntityState.Added;
                        var q35 = new EpGroupTafsiliLevel2() { Id = 35, Code = 921, StartCode = 921000001, EndCode = 921999999, Name = "پروژه ها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 16 };
                        context.Entry(new EpAllGroupTafsili() { Id = 35, KeyCode = 921, ParentCode = 92, LevelName = "پروژه ها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel2 = q35 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 921) ? EntityState.Unchanged : EntityState.Added;
                        var q36 = new EpGroupTafsiliLevel2() { Id = 36, Code = 931, StartCode = 931000001, EndCode = 931999999, Name = "قراردادها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 17 };
                        context.Entry(new EpAllGroupTafsili() { Id = 36, KeyCode = 931, ParentCode = 93, LevelName = "قراردادها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel2 = q36 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 931) ? EntityState.Unchanged : EntityState.Added;
                        var q37 = new EpGroupTafsiliLevel2() { Id = 37, Code = 941, StartCode = 941000001, EndCode = 941999999, Name = "انبارها", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 18 };
                        context.Entry(new EpAllGroupTafsili() { Id = 37, KeyCode = 941, ParentCode = 94, LevelName = "انبارها", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel2 = q37 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 941) ? EntityState.Unchanged : EntityState.Added;
                        var q38 = new EpGroupTafsiliLevel2() { Id = 38, Code = 951, StartCode = 951000001, EndCode = 951999999, Name = "سایر", IsActive = true, SalId = 1 , LevelNumber = 2, Level1Id = 19 };
                        context.Entry(new EpAllGroupTafsili() { Id = 38, KeyCode = 951, ParentCode = 95, LevelName = "سایر", IsActive = true, SalId = 1 , LevelNumber = 2, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel2 = q38 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 951) ? EntityState.Unchanged : EntityState.Added;

                        /////////////////////////
                        var q39 = new EpGroupTafsiliLevel3() { Id = 39, Code = 1011, StartCode = 1011000001, EndCode = 1011999999, Name = "سهامداران", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 20 };
                        context.Entry(new EpAllGroupTafsili() { Id = 39, KeyCode = 1011, ParentCode = 101, LevelName = "سهامداران", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q39 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 1011) ? EntityState.Unchanged : EntityState.Added;
                        var q40 = new EpGroupTafsiliLevel3() { Id = 40, Code = 2011, StartCode = 2011000001, EndCode = 2011999999, Name = "کارکنان", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 21 };
                        context.Entry(new EpAllGroupTafsili() { Id = 40, KeyCode = 2011, ParentCode = 201, LevelName = "کارکنان", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q40 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 2011) ? EntityState.Unchanged : EntityState.Added;
                        var q41 = new EpGroupTafsiliLevel3() { Id = 41, Code = 3011, StartCode = 3011000001, EndCode = 3011999999, Name = "اشخاص حقیقی", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 22 };
                        context.Entry(new EpAllGroupTafsili() { Id = 41, KeyCode = 3011, ParentCode = 301, LevelName = "اشخاص حقیقی", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q41 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 3011) ? EntityState.Unchanged : EntityState.Added;
                        var q42 = new EpGroupTafsiliLevel3() { Id = 42, Code = 4011, StartCode = 4011000001, EndCode = 4011999999, Name = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 23 };
                        context.Entry(new EpAllGroupTafsili() { Id = 42, KeyCode = 4011, ParentCode = 401, LevelName = "شرکتها یا ادارات خصوصی", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q42 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 4011) ? EntityState.Unchanged : EntityState.Added;
                        var q43 = new EpGroupTafsiliLevel3() { Id = 43, Code = 5011, StartCode = 5011000001, EndCode = 5011999999, Name = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 24 };
                        context.Entry(new EpAllGroupTafsili() { Id = 43, KeyCode = 5011, ParentCode = 501, LevelName = "شرکتها یا ادارات دولتی", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 0, TabaghehGroupName = "اشخاص", EpGroupTafsiliLevel3 = q43 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 5011) ? EntityState.Unchanged : EntityState.Added;
                        var q44 = new EpGroupTafsiliLevel3() { Id = 44, Code = 6011, StartCode = 6011000001, EndCode = 6011999999, Name = "مواد", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 25 };
                        context.Entry(new EpAllGroupTafsili() { Id = 44, KeyCode = 6011, ParentCode = 601, LevelName = "مواد", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel3 = q44 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 6011) ? EntityState.Unchanged : EntityState.Added;
                        var q45 = new EpGroupTafsiliLevel3() { Id = 45, Code = 6511, StartCode = 6511000001, EndCode = 6511999999, Name = "قطعات و ملزومات", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 26 };
                        context.Entry(new EpAllGroupTafsili() { Id = 45, KeyCode = 6511, ParentCode = 651, LevelName = "قطعات و ملزومات", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel3 = q45 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 6511) ? EntityState.Unchanged : EntityState.Added;
                        var q46 = new EpGroupTafsiliLevel3() { Id = 46, Code = 7011, StartCode = 7011000001, EndCode = 7011999999, Name = "محصولات", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 27 };
                        context.Entry(new EpAllGroupTafsili() { Id = 46, KeyCode = 7011, ParentCode = 701, LevelName = "محصولات", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel3 = q46 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 7011) ? EntityState.Unchanged : EntityState.Added;
                        var q47 = new EpGroupTafsiliLevel3() { Id = 47, Code = 7511, StartCode = 7511000001, EndCode = 7511999999, Name = "کالاها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 28 };
                        context.Entry(new EpAllGroupTafsili() { Id = 47, KeyCode = 7511, ParentCode = 751, LevelName = "کالاها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel3 = q47 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 7511) ? EntityState.Unchanged : EntityState.Added;
                        var q48 = new EpGroupTafsiliLevel3() { Id = 48, Code = 8011, StartCode = 8011000001, EndCode = 8011999999, Name = "اموال", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 29 };
                        context.Entry(new EpAllGroupTafsili() { Id = 48, KeyCode = 8011, ParentCode = 801, LevelName = "اموال", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 1, TabaghehGroupName = "اقلام انبار و اموال", EpGroupTafsiliLevel3 = q48 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8011) ? EntityState.Unchanged : EntityState.Added;
                        var q49 = new EpGroupTafsiliLevel3() { Id = 49, Code = 8711, StartCode = 8711000001, EndCode = 8711999999, Name = "صندوقها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 30 };
                        context.Entry(new EpAllGroupTafsili() { Id = 49, KeyCode = 8711, ParentCode = 871, LevelName = "صندوقها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 3, TabaghehGroupName = "صندوقها", EpGroupTafsiliLevel3 = q49 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8711) ? EntityState.Unchanged : EntityState.Added;
                        var q50 = new EpGroupTafsiliLevel3() { Id = 50, Code = 8811, StartCode = 8811000001, EndCode = 8811999999, Name = "بانکها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 31 };
                        context.Entry(new EpAllGroupTafsili() { Id = 50, KeyCode = 8811, ParentCode = 881, LevelName = "بانکها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 4, TabaghehGroupName = "بانکها", EpGroupTafsiliLevel3 = q50 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8811) ? EntityState.Unchanged : EntityState.Added;
                        var q51 = new EpGroupTafsiliLevel3() { Id = 51, Code = 8911, StartCode = 8911000001, EndCode = 8911999999, Name = "وامها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 32 };
                        context.Entry(new EpAllGroupTafsili() { Id = 51, KeyCode = 8911, ParentCode = 891, LevelName = "وامها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 5, TabaghehGroupName = "وامها", EpGroupTafsiliLevel3 = q51 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 8911) ? EntityState.Unchanged : EntityState.Added;
                        var q52 = new EpGroupTafsiliLevel3() { Id = 52, Code = 9011, StartCode = 9011000001, EndCode = 9011999999, Name = "مراکز هزینه", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 33 };
                        context.Entry(new EpAllGroupTafsili() { Id = 52, KeyCode = 9011, ParentCode = 901, LevelName = "مراکز هزینه", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 6, TabaghehGroupName = "مراکز هزینه", EpGroupTafsiliLevel3 = q52 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9011) ? EntityState.Unchanged : EntityState.Added;
                        var q53 = new EpGroupTafsiliLevel3() { Id = 53, Code = 9111, StartCode = 9111000001, EndCode = 9111999999, Name = "شعبات وابسته", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 34 };
                        context.Entry(new EpAllGroupTafsili() { Id = 53, KeyCode = 9111, ParentCode = 911, LevelName = "شعبات وابسته", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 7, TabaghehGroupName = "شعبات وابسته", EpGroupTafsiliLevel3 = q53 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9111) ? EntityState.Unchanged : EntityState.Added;
                        var q54 = new EpGroupTafsiliLevel3() { Id = 54, Code = 9211, StartCode = 9211000001, EndCode = 9211999999, Name = "پروژه ها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 35 };
                        context.Entry(new EpAllGroupTafsili() { Id = 54, KeyCode = 9211, ParentCode = 921, LevelName = "پروژه ها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 8, TabaghehGroupName = "پروژه ها", EpGroupTafsiliLevel3 = q54 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9211) ? EntityState.Unchanged : EntityState.Added;
                        var q55 = new EpGroupTafsiliLevel3() { Id = 55, Code = 9311, StartCode = 9311000001, EndCode = 9311999999, Name = "قراردادها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 36 };
                        context.Entry(new EpAllGroupTafsili() { Id = 55, KeyCode = 9311, ParentCode = 931, LevelName = "قراردادها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 9, TabaghehGroupName = "قراردادها", EpGroupTafsiliLevel3 = q55 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9311) ? EntityState.Unchanged : EntityState.Added;
                        var q56 = new EpGroupTafsiliLevel3() { Id = 56, Code = 9411, StartCode = 9411000001, EndCode = 9411999999, Name = "انبارها", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 37 };
                        context.Entry(new EpAllGroupTafsili() { Id = 56, KeyCode = 9411, ParentCode = 941, LevelName = "انبارها", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 10, TabaghehGroupName = "انبارها", EpGroupTafsiliLevel3 = q56 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9411) ? EntityState.Unchanged : EntityState.Added;
                        var q57 = new EpGroupTafsiliLevel3() { Id = 57, Code = 9511, StartCode = 9511000001, EndCode = 9511999999, Name = "سایر", IsActive = true, SalId = 1 , LevelNumber = 3, Level2Id = 38 };
                        context.Entry(new EpAllGroupTafsili() { Id = 57, KeyCode = 9511, ParentCode = 951, LevelName = "سایر", IsActive = true, SalId = 1 , LevelNumber = 3, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel3 = q57 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9511) ? EntityState.Unchanged : EntityState.Added;

                        var q58 = new EpGroupTafsiliLevel1() { Id = 58, Code = 96, StartCode = 96000001, EndCode = 96999999, Name = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehIndex = 11, TabaghehName = "سایر" };
                        context.Entry(new EpAllGroupTafsili() { Id = 58, KeyCode = 96, ParentCode = 96, LevelName = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber = 1, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel1 = q58 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 96) ? EntityState.Unchanged : EntityState.Added;
                        var q59 = new EpGroupTafsiliLevel2() { Id = 59, Code = 961, StartCode = 961000001, EndCode = 961999999, Name = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber =2, Level1Id = 58 };
                        context.Entry(new EpAllGroupTafsili() { Id = 59, KeyCode = 961, ParentCode = 96, LevelName = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber = 2, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel2 = q59 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 961) ? EntityState.Unchanged : EntityState.Added;
                        var q60 = new EpGroupTafsiliLevel3() { Id = 60, Code = 9611, StartCode = 9611000001, EndCode = 9611999999, Name = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber = 3, Level2Id = 59 };
                        context.Entry(new EpAllGroupTafsili() { Id = 60, KeyCode = 9611, ParentCode = 961, LevelName = "کالاهای خدماتی", IsActive = true, SalId = 1, LevelNumber = 3, TabaghehGroupIndex = 11, TabaghehGroupName = "سایر", EpGroupTafsiliLevel3 = q60 }).State = context.EpAllGroupTafsilis.Any(s => s.KeyCode == 9611) ? EntityState.Unchanged : EntityState.Added;

                    }

                    ////////////// تعریف سیستمهای فعال 
                    if (!context.MsActiveSystems.Any())
                    {
                        context.Entry(new MsActiveSystem() { Id = 10, Code = 10, Name = "فروش و خرید", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 10) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 15, Code = 15, Name = "دریافت و پرداخت", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 15) ? EntityState.Unchanged : EntityState.Added;
                        //context.Entry(new MsActiveSystem() { Id = 20, Code = 20, Name = "اسناد حسابداری", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 20) ? EntityState.Unchanged : EntityState.Added;
                        context.Entry(new MsActiveSystem() { Id = 25, Code = 25, Name = "انبار و کالا", IsActive = true }).State = context.MsActiveSystems.Any(s => s.Code == 25) ? EntityState.Unchanged : EntityState.Added;
                    }

                    ////////////////////  تعریف تنظیمات کدینگ حسابدارو انبار و کالا 
                    context.Entry(new EpTanzimatCodingHesabdari() { SalId = 1, HesabTabaghehCarakter = 1, HesabGroupCarakter = 1, HesabColCarakter = 2, HesabMoinLevel1Carakter = 2, HesabTabaghehMinCode = "1", HesabTabaghehMaxCode = "9", HesabGroupMinCode = "1", HesabGroupMaxCode = "9", HesabColMinCode = "01", HesabColMaxCode = "99", HesabMoinLevel1MinCode = "01", HesabMoinLevel1MaxCode = "99" }).State = context.EpTanzimatCodingHesabdaris.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;
                    context.Entry(new EpTanzimatGroupTafsili() { SalId = 1, GroupTafsiliLevel1Carakter = 2, GroupTafsiliLevel2Carakter = 1, GroupTafsiliLevel3Carakter = 1, CodeTafsiliCarakter = 6, GroupTafsiliLevel1MinCode = "10", GroupTafsiliLevel1MaxCode = "99", GroupTafsiliLevel2MinCode = "1", GroupTafsiliLevel2MaxCode = "9", GroupTafsiliLevel3MinCode = "1", GroupTafsiliLevel3MaxCode = "9", CodeTafsiliMinCode = "000001", CodeTafsiliMaxCode = "999999", IsActiveGroupTafsiliLevel1 = true }).State = context.EpTanzimatGroupTafsilis.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;
                    context.Entry(new EpTanzimatAnbarVKala() { SalId = 1, CodeAnbarCarakter = 3, CodeTabagehKalaCarakter = 3, CodeGroupAsliKalaCarakter = 3, CodeGroupFareeKalaCarakter = 3, CodeNameKalaCarakter = 4, CodeVahedKalaCarakter = 3, CodeAnbarMinCode = "1", CodeAnbarMaxCode = "999", CodeGroupAsliKalaMinCode = "001", CodeGroupAsliKalaMaxCode = "999", CodeGroupFareeKalaMinCode = "001", CodeGroupFareeKalaMaxCode = "999", CodeNameKalaMinCode = "0001", CodeNameKalaMaxCode = "9999", CodeVahedKalaMinCode = "1", CodeVahedKalaMaxCode = "999" }).State = context.EpTanzimatAnbarVKalas.Any(s => s.SalId == 1) ? EntityState.Unchanged : EntityState.Added;

                    //////////// تعریف کدینگ حسابداری
                    {

                        //////////////// تعریف طبقه
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1, ParentCode = 1, LevelNumber = 1, LevelName = "دارائیها", IsActive = true, EpHesabTabagheh1 = new EpHesabTabagheh() { SalId = 1, LevelNumber = 1, Code = 1, Name = "دارائیها", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2, ParentCode = 2, LevelNumber = 1, LevelName = "بدهیها", IsActive = true, EpHesabTabagheh1 = new EpHesabTabagheh() { SalId = 1, LevelNumber = 1, Code = 2, Name = "بدهیها", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3, ParentCode = 3, LevelNumber = 1, LevelName = "حقوق صاحبان سهام", IsActive = true, EpHesabTabagheh1 = new EpHesabTabagheh() { SalId = 1, LevelNumber = 1, Code = 3, Name = "حقوق صاحبان سهام", IndexNoeHesab = 0, NoeHesab = "ترازنامه ای", IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4, ParentCode = 4, LevelNumber = 1, LevelName = "عملکرد (سود و زیان)", IsActive = true, EpHesabTabagheh1 = new EpHesabTabagheh() { SalId = 1, LevelNumber = 1, Code = 4, Name = "عملکرد (سود و زیان)", IndexNoeHesab = 1, NoeHesab = "سود و زیانی", IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 5, ParentCode = 5, LevelNumber = 1, LevelName = "حسابهای انتظامی و کنترلی", IsActive = true, EpHesabTabagheh1 = new EpHesabTabagheh() { SalId = 1, LevelNumber = 1, Code = 5, Name = "حسابهای انتظامی و کنترلی", IndexNoeHesab = 0, NoeHesab = "انتظامی و کنترلی", IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 5) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();
                        /////////////////// تعریف گروه
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 11, ParentCode = 1, LevelNumber = 2, LevelName = "دارائیهای جاری", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 11, Name = "دارائیهای جاری", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 1).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 11) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 12, ParentCode = 1, LevelNumber = 2, LevelName = "دارائیهای غیرجاری", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 12, Name = "دارائیهای غیرجاری", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 1).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 12) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 21, ParentCode = 2, LevelNumber = 2, LevelName = "بدهیهای جاری", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 21, Name = "بدهیهای جاری", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 2).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 21) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 22, ParentCode = 2, LevelNumber = 2, LevelName = "بدهیهای غیرجاری", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 22, Name = "بدهیهای غیرجاری", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 2).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 22) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 31, ParentCode = 3, LevelNumber = 2, LevelName = "حقوق صاحبان سهام", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 31, Name = "حقوق صاحبان سهام", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 3).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 31) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 41, ParentCode = 4, LevelNumber = 2, LevelName = "فروش و سایر درآمدها", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 41, Name = "فروش و سایر درآمدها", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 4).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 41) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 42, ParentCode = 4, LevelNumber = 2, LevelName = "بهای تمام شده کالای فروش رفته و خدمات ارائه شده", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 42, Name = "بهای تمام شده کالای فروش رفته و خدمات ارائه شده", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 4).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 42) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 43, ParentCode = 4, LevelNumber = 2, LevelName = "هزینه های فعالیت و سایر هزینه ها", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 43, Name = "هزینه های فعالیت و سایر هزینه ها", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 4).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 43) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 51, ParentCode = 5, LevelNumber = 2, LevelName = "حسابهای انتظامی و کنترلی", IsActive = true, EpHesabGroup1 = new EpHesabGroup() { SalId = 1, LevelNumber = 2, Code = 51, Name = "حسابهای انتظامی و کنترلی", TabaghehId = context.EpHesabTabaghehs.FirstOrDefault(s => s.SalId == 1 && s.Code == 5).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 51) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();
                        /////////////////// تعریف کل
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1101, ParentCode = 11, LevelNumber = 3, LevelName = "موجودی نقد و بانک", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1101, Name = "موجودی نقد و بانک", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1101) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1102, ParentCode = 11, LevelNumber = 3, LevelName = "سرمایه گذاری کوتاه مدت", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1102, Name = "سرمایه گذاری کوتاه مدت", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1102) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1103, ParentCode = 11, LevelNumber = 3, LevelName = "حسابها و اسناد دریافتنی تجاری", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1103, Name = "حسابها و اسناد دریافتنی تجاری", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1103) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1104, ParentCode = 11, LevelNumber = 3, LevelName = "سایر حسابها و اسناد دریافتنی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1104, Name = "سایر حسابها و اسناد دریافتنی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1104) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1105, ParentCode = 11, LevelNumber = 3, LevelName = "موجودی مواد وکالا", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1105, Name = "موجودی مواد وکالا", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1105) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1106, ParentCode = 11, LevelNumber = 3, LevelName = "سفارشات و پیش پرداخت ها", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1106, Name = "سفارشات و پیش پرداخت ها", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1106) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1107, ParentCode = 11, LevelNumber = 3, LevelName = "سپردهای ما نزد دیگران", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1107, Name = "سپردهای ما نزد دیگران", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 11).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1107) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1201, ParentCode = 12, LevelNumber = 3, LevelName = "دارائیهای ثابت مشهود", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1201, Name = "دارائیهای ثابت مشهود", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1201) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1202, ParentCode = 12, LevelNumber = 3, LevelName = "استهلاک انباشته دارائیهای ثابت مشهود", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1202, Name = "استهلاک انباشته دارائیهای ثابت مشهود", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1202) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1203, ParentCode = 12, LevelNumber = 3, LevelName = "دارائیهای در جریان تکمیل", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1203, Name = "دارائیهای در جریان تکمیل", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1203) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1204, ParentCode = 12, LevelNumber = 3, LevelName = "دارائیهای نامشهود", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1204, Name = "دارائیهای نامشهود", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1204) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1205, ParentCode = 12, LevelNumber = 3, LevelName = "سرمایه گذاری بلند مدت", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1205, Name = "سرمایه گذاری بلند مدت", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1205) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 1206, ParentCode = 12, LevelNumber = 3, LevelName = "سایر دارائیهای غیر جاری", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 1206, Name = "سایر دارائیهای غیر جاری", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 12).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 1206) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2101, ParentCode = 21, LevelNumber = 3, LevelName = "حسابها و اسناد پرداختنی تجاری", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2101, Name = "حسابها و اسناد پرداختنی تجاری", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2101) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2102, ParentCode = 21, LevelNumber = 3, LevelName = "سایر حسابهاو اسناد پرداختنی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2102, Name = "سایر حسابهاو اسناد پرداختنی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2102) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2103, ParentCode = 21, LevelNumber = 3, LevelName = "سفارشات و پیش دریافت ها", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2103, Name = "سفارشات و پیش دریافت ها", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2103) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2104, ParentCode = 21, LevelNumber = 3, LevelName = "ذخیره مالیات", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2104, Name = "ذخیره مالیات", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2104) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2105, ParentCode = 21, LevelNumber = 3, LevelName = "سود سهام پرداختنی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2105, Name = "سود سهام پرداختنی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2105) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2106, ParentCode = 21, LevelNumber = 3, LevelName = "سپرده های پرداختنی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2106, Name = "سپرده های پرداختنی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2106) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2107, ParentCode = 21, LevelNumber = 3, LevelName = "تسهیلات دریافتی کوتاه مدت", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2107, Name = "تسهیلات دریافتی کوتاه مدت", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2107) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2108, ParentCode = 21, LevelNumber = 3, LevelName = "ذخایر", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2108, Name = "ذخایر", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 21).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2108) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2201, ParentCode = 22, LevelNumber = 3, LevelName = "حسابها و اسناد پرداختنی بلندمدت تجاری", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2201, Name = "حسابها و اسناد پرداختنی بلندمدت تجاری", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 22).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2201) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2202, ParentCode = 22, LevelNumber = 3, LevelName = "سایر حسابها و اسناد پرداختنی بلندمدت", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2202, Name = "سایر حسابها و اسناد پرداختنی بلندمدت", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 22).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2202) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2203, ParentCode = 22, LevelNumber = 3, LevelName = "تسهیلات دریافتی بلندمدت", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2203, Name = "تسهیلات دریافتی بلندمدت", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 22).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2203) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2204, ParentCode = 22, LevelNumber = 3, LevelName = "ذخیره مزایای پایان خدمت کارکنان", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2204, Name = "ذخیره مزایای پایان خدمت کارکنان", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 22).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2204) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 2205, ParentCode = 22, LevelNumber = 3, LevelName = "درآمدهای انتقالی به دوره های آتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 2205, Name = "درآمدهای انتقالی به دوره های آتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 22).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 2205) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3101, ParentCode = 31, LevelNumber = 3, LevelName = "سرمایه پرداخت شده", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 3101, Name = "سرمایه پرداخت شده", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 31).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3101) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3102, ParentCode = 31, LevelNumber = 3, LevelName = "اندورخته قانونی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 3102, Name = "اندورخته قانونی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 31).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3102) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3103, ParentCode = 31, LevelNumber = 3, LevelName = "سایر اندوخته ها", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 3103, Name = "سایر اندوخته ها", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 31).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3103) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3104, ParentCode = 31, LevelNumber = 3, LevelName = "مازاد تجدید ارزیابی دارائیهای ثابت مشهود", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 3104, Name = "مازاد تجدید ارزیابی دارائیهای ثابت مشهود", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 31).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3104) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 3105, ParentCode = 31, LevelNumber = 3, LevelName = "سود و زیان انباشته", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 3105, Name = "سود و زیان انباشته", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 31).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 3105) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4101, ParentCode = 41, LevelNumber = 3, LevelName = "فروش", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4101, Name = "فروش", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 41).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4101) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4102, ParentCode = 41, LevelNumber = 3, LevelName = "درآمد حاصل از ارائه خدمات", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4102, Name = "درآمد حاصل از ارائه خدمات", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 41).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4102) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4103, ParentCode = 41, LevelNumber = 3, LevelName = "سایر درآمدهای عملیاتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4103, Name = "سایر درآمدهای عملیاتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 41).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4103) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4104, ParentCode = 41, LevelNumber = 3, LevelName = "سایر درآمدهای غیر عملیاتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4104, Name = "سایر درآمدهای غیر عملیاتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 41).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4104) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4201, ParentCode = 42, LevelNumber = 3, LevelName = "بهای تمام شده کالای فروش رفته داخلی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4201, Name = "بهای تمام شده کالای فروش رفته داخلی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 42).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4201) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4202, ParentCode = 42, LevelNumber = 3, LevelName = "بهای تمام شده کالای فروش رفته خارجی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4202, Name = "بهای تمام شده کالای فروش رفته خارجی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 42).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4202) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4203, ParentCode = 42, LevelNumber = 3, LevelName = "بهای تمام شده خدمات ارائه شده", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4203, Name = "بهای تمام شده خدمات ارائه شده", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 42).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4203) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4301, ParentCode = 43, LevelNumber = 3, LevelName = "هزینه حقوق و دستمزد", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4301, Name = "هزینه حقوق و دستمزد", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 43).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4301) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4302, ParentCode = 43, LevelNumber = 3, LevelName = "هزینه های عملیاتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4302, Name = "هزینه های عملیاتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 43).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4302) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4303, ParentCode = 43, LevelNumber = 3, LevelName = "سایر هزینه های عملیاتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4303, Name = "سایر هزینه های عملیاتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 43).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4303) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4304, ParentCode = 43, LevelNumber = 3, LevelName = "هزینه های مالی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4304, Name = "هزینه های مالی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 43).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4304) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 4305, ParentCode = 43, LevelNumber = 3, LevelName = "هزینه های غیرعملیاتی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 4305, Name = "هزینه های غیرعملیاتی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 43).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 4305) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 5101, ParentCode = 51, LevelNumber = 3, LevelName = "حسابهای انتظامی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 5101, Name = "حسابهای انتظامی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 51).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 5101) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 5102, ParentCode = 51, LevelNumber = 3, LevelName = "طرف حسابهای انتظامی", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 5102, Name = "طرف حسابهای انتظامی", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 51).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 5102) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 5103, ParentCode = 51, LevelNumber = 3, LevelName = "تراز افتتاحیه", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 5103, Name = "تراز افتتاحیه", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 51).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 5103) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 5104, ParentCode = 51, LevelNumber = 3, LevelName = "تراز اختتامیه", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, LevelNumber = 3, Code = 5104, Name = "تراز اختتامیه", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 51).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 5104) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();
                        /////////////////// تعریف معین
                        //List<R_EpHesabMoin1_B_EpAllGroupTafsili> List1 = new List<R_EpHesabMoin1_B_EpAllGroupTafsili>();
                        ////R_EpHesabMoin1_B_EpAllGroupTafsili List2 = new R_EpHesabMoin1_B_EpAllGroupTafsili();
                        //List1.Add(new R_EpHesabMoin1_B_EpAllGroupTafsili() { SalId = 1, LevelNumber = 1, AllGroupTafsiliId = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.TabaghehGroupName == "صندوقها").Id  });
                        //List<R_EpAllCodingHesabdari_B_MsActiveSystem> List2 = new List<R_EpAllCodingHesabdari_B_MsActiveSystem>();
                        //List2.Add(new R_EpAllCodingHesabdari_B_MsActiveSystem() { SalId = 1 , ActiveSystemId= 10 });
                        //List2.Add(new R_EpAllCodingHesabdari_B_MsActiveSystem() { SalId = 1 , ActiveSystemId= 15 });
                        //List2.Add(new R_EpAllCodingHesabdari_B_MsActiveSystem() { SalId = 1 , ActiveSystemId= 25 });
                        //context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 110101, ParentCode = 1101, LevelNumber = 4, LevelName = "صندوق ریالی", IsActive = true, R_EpAllCodingHesabdari_B_MsActiveSystems=List2,EpHesabMoin1 = new EpHesabMoin1() { SalId = 1, Code = 110101, Name = "صندوق ریالی", ColId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 1101).Id, IsActive = true, GroupTafsiliLevelsIndex = 1, GroupTafsiliLevelsName = "سطح 1", IndexMahiatHesab = 0, MahiatHesab = "مهم نیست", LevelNumber = 4, SelectedActivesystem = "فروش و خرید,دریافت وپرداخت,انبار وکالا,", SelectedGroupTafsiliLevels = "صندوق", R_EpHesabMoin1_B_EpAllGroupTafsilis= List1, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 110101) ? EntityState.Detached : EntityState.Added;

                        //context.Entry(new EpAllCodingHesabdari() { SalId = 1, KeyCode = 110101, ParentCode = 1101, LevelNumber = 4, LevelName = "", IsActive = true, EpHesabCol1 = new EpHesabCol() { SalId = 1, Code = 110101, Name = "", GroupId = context.EpHesabGroups.FirstOrDefault(s => s.SalId == 1 && s.Code == 1101).Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingHesabdaris.Any(s => s.SalId == 1 && s.KeyCode == 110101) ? EntityState.Detached : EntityState.Added;

                        //context.SaveChanges();

                    }

                    //////////// تعریف حسابهای تفصیلی
                    {
                        DateTime _datetime = Convert.ToDateTime("2021/01/14");

                        long _Code1 = 30;
                        var _GroupAshkhas = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == _Code1);
                        EpHesabTafsiliAshkhas Obj_Ashkhas1 = new EpHesabTafsiliAshkhas() { SalId = 1, Code = _Code1 * 1000000 + 1, Name = "کمال خیاطی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAshkhas.Id, IsHaghighi = true, TarikhEjad = _datetime, SharhHesab = null, IsFroshandeh = false, IsHoghoghi = false, IsKharidar = true, IsPersonel = false, IsRanande = false, IsSahamdar = false, IsVizitor = false };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code1 * 1000000 + 1, LevelNumber = 1, Name = "کمال خیاطی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAshkhas.Id, EpHesabTafsiliAshkhas1 = Obj_Ashkhas1 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code1 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliAshkhas Obj_Ashkhas2 = new EpHesabTafsiliAshkhas() { SalId = 1, Code = _Code1 * 1000000 + 2, Name = "جمال خیاطی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAshkhas.Id, IsHaghighi = true, TarikhEjad = _datetime, SharhHesab = null, IsFroshandeh = false, IsHoghoghi = false, IsKharidar = true, IsPersonel = false, IsRanande = false, IsSahamdar = false, IsVizitor = false };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code1 * 1000000 + 2, LevelNumber = 1, Name = "جمال خیاطی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAshkhas.Id, EpHesabTafsiliAshkhas1 = Obj_Ashkhas2 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code1 * 1000000 + 2) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliAshkhas Obj_Ashkhas3 = new EpHesabTafsiliAshkhas() { SalId = 1, Code = _Code1 * 1000000 + 3, Name = "جلال خیاطی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAshkhas.Id, IsHaghighi = true, TarikhEjad = _datetime, SharhHesab = null, IsFroshandeh = false, IsHoghoghi = false, IsKharidar = true, IsPersonel = false, IsRanande = false, IsSahamdar = false, IsVizitor = false };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code1 * 1000000 + 3, LevelNumber = 1, Name = "جلال خیاطی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAshkhas.Id, EpHesabTafsiliAshkhas1 = Obj_Ashkhas3 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code1 * 1000000 + 3) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliAshkhas Obj_Ashkhas4 = new EpHesabTafsiliAshkhas() { SalId = 1, Code = _Code1 * 1000000 + 4, Name = "کاوه خیاطی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAshkhas.Id, IsHaghighi = true, TarikhEjad = _datetime, SharhHesab = null, IsFroshandeh = false, IsHoghoghi = false, IsKharidar = true, IsPersonel = false, IsRanande = false, IsSahamdar = false, IsVizitor = false };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code1 * 1000000 + 4, LevelNumber = 1, Name = "کاوه خیاطی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAshkhas.Id, EpHesabTafsiliAshkhas1 = Obj_Ashkhas4 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code1 * 1000000 + 4) ? EntityState.Detached : EntityState.Added;

                        ///////////// تعریف صندوق
                        long _Code2 = 87;
                        var _GroupSandogh = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == _Code2);
                        EpHesabTafsiliSandogh Obj_Sandogh1 = new EpHesabTafsiliSandogh() { SalId = 1, Code = _Code2 * 1000000 + 1, Name = "صندوق اصلی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupSandogh.Id, TarikhEjad = _datetime, IsDefault = true, NameMasol = null, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code2 * 1000000 + 1, LevelNumber = 1, Name = "صندوق اصلی", IsActive = true, IsDefault = true, SharhHesab = null, GroupTafsiliId = _GroupSandogh.Id, EpHesabTafsiliSandogh1 = Obj_Sandogh1 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code2 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliSandogh Obj_Sandogh2 = new EpHesabTafsiliSandogh() { SalId = 1, Code = _Code2 * 1000000 + 2, Name = "صندوق فرعی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupSandogh.Id, TarikhEjad = _datetime, IsDefault = false, NameMasol = null, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code2 * 1000000 + 2, LevelNumber = 1, Name = "صندوق فرعی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupSandogh.Id, EpHesabTafsiliSandogh1 = Obj_Sandogh2 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code2 * 1000000 + 2) ? EntityState.Detached : EntityState.Added;

                        ///////////// تعریف انبار
                        long _Code3 = 94;
                        var _GroupAnbar = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == _Code3);
                        EpHesabTafsiliAnbarha Obj_Anbar1 = new EpHesabTafsiliAnbarha() { SalId = 1, Code = _Code3 * 1000000 + 1, Name = "انبار اصلی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAnbar.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code3 * 1000000 + 1, LevelNumber = 1, Name = "انبار اصلی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAnbar.Id, EpHesabTafsiliAnbarha1 = Obj_Anbar1 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code3 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliAnbarha Obj_Anbar2 = new EpHesabTafsiliAnbarha() { SalId = 1, Code = _Code3 * 1000000 + 2, Name = "انبار فرعی", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupAnbar.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code3 * 1000000 + 2, LevelNumber = 1, Name = "انبار فرعی", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupAnbar.Id, EpHesabTafsiliAnbarha1 = Obj_Anbar2 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code3 * 1000000 + 2) ? EntityState.Detached : EntityState.Added;
                        //context.SaveChanges();

                        ///////////// تعریف سایر 
                        long _Code4 = 95;
                        var _GroupSayer1 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == _Code4);
                        EpHesabTafsiliSayer Obj_Sayer1 = new EpHesabTafsiliSayer() { SalId = 1, Code = _Code4 * 1000000 + 1, Name = "سایر 1", LevelNumber = 1, IsActive = true, GroupTafsiliId = _GroupSayer1.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code4 * 1000000 + 1, LevelNumber = 1, Name = "سایر 1", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupSayer1.Id, EpHesabTafsiliSayer1 = Obj_Sayer1 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code4 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        long _Code5 = 951;
                        var _GroupSayer2 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == _Code5);
                        EpHesabTafsiliSayer Obj_Sayer2 = new EpHesabTafsiliSayer() { SalId = 1, Code = _Code5 * 1000000 + 1, Name = "سایر 2", LevelNumber = 2, IsActive = true, GroupTafsiliId = _GroupSayer2.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code5 * 1000000 + 1, LevelNumber = 2, Name = "سایر 2", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupSayer2.Id, EpHesabTafsiliSayer1 = Obj_Sayer2 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code5 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        long _Code6 = 9511;
                        var _GroupSayer3 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 3 && s.KeyCode == _Code6);
                        EpHesabTafsiliSayer Obj_Sayer3 = new EpHesabTafsiliSayer() { SalId = 1, Code = _Code6 * 1000000 + 1, Name = "سایر 3", LevelNumber = 3, IsActive = true, GroupTafsiliId = _GroupSayer3.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code6 * 1000000 + 1, LevelNumber = 3, Name = "سایر 3", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupSayer3.Id, EpHesabTafsiliSayer1 = Obj_Sayer3 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code6 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        ///////////// تعریف شعبات 
                        long _Code7 = 9111;
                        var _GroupShoabat = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 3 && s.KeyCode == _Code7);
                        EpHesabTafsiliShoabat Obj_Shoabat1 = new EpHesabTafsiliShoabat() { SalId = 1, Code = _Code7 * 1000000 + 1, Name = "شعبه 1", LevelNumber = 3, IsActive = true, GroupTafsiliId = _GroupShoabat.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code7 * 1000000 + 1, LevelNumber = 3, Name = "شعبه 1", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupShoabat.Id, EpHesabTafsiliShoabat1 = Obj_Shoabat1 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code7 * 1000000 + 1) ? EntityState.Detached : EntityState.Added;

                        EpHesabTafsiliShoabat Obj_Shoabat2 = new EpHesabTafsiliShoabat() { SalId = 1, Code = _Code7 * 1000000 + 2, Name = "شعبه 2", LevelNumber = 3, IsActive = true, GroupTafsiliId = _GroupShoabat.Id, TarikhEjad = _datetime, SharhHesab = null };
                        context.Entry(new EpAllHesabTafsili() { SalId = 1, Code = _Code7 * 1000000 + 2, LevelNumber = 3, Name = "شعبه 2", IsActive = true, SharhHesab = null, GroupTafsiliId = _GroupShoabat.Id, EpHesabTafsiliShoabat1 = Obj_Shoabat2 }).State = context.EpAllHesabTafsilis.Any(s => s.SalId == 1 && s.Code == _Code7 * 1000000 + 2) ? EntityState.Detached : EntityState.Added;

                        context.SaveChanges();
                    }

                    /////////////// تعریف کدینگ انبار و کالا
                    {
                        /////////////// تعریف واحد کالا
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 1, Name = "." }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 1) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 2, Name = "عدد" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 2) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 3, Name = "بسته" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 3) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 4, Name = "کارتن" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 4) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 5, Name = "گرم" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 5) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 6, Name = "کیلو" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 6) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 7, Name = "تن" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 7) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 8, Name = "متر" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 8) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 9, Name = "متر مربع" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 9) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 10, Name = "متر مکعب" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 10) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 11, Name = "سانتی متر" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 11) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 12, Name = "لیتر" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 12) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 13, Name = "دبه" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 13) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 14, Name = "گالن" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 14) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 15, Name = "بشکه" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 15) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpVahedKala() { SalId = 1, Code = 16, Name = "جفت" }).State = context.EpVahedKalas.Any(s => s.SalId == 1 && s.Code == 16) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();

                        ////////////////  تعریف طبقه اقلام انبار و اموال
                        var _VahedAsliKalaId1 = context.EpVahedKalas.FirstOrDefault(s => s.SalId == 1 && s.Name == ".");

                        var _GroupTafsiliId1_1 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601, ParentCode = 601, LevelNumber = 1, LevelName = "مواد", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId1.Id, EpTabaghehKala1 = new EpTabaghehKala() { SalId = 1, LevelNumber = 1, Code = 601, Name = "مواد", VahedKalaId = _VahedAsliKalaId1.Id, GroupTafsiliId = _GroupTafsiliId1_1.Id, IsActive = true,NoeTabagheIndex=0,NoeTabagheName="کالا", SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601) ? EntityState.Detached : EntityState.Added;

                        var _GroupTafsiliId1_2 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651, ParentCode = 651, LevelNumber = 1, LevelName = "قطعات و ملزومات", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId1.Id, EpTabaghehKala1 = new EpTabaghehKala() { SalId = 1, LevelNumber = 1, Code = 651, Name = "قطعات و ملزومات", VahedKalaId = _VahedAsliKalaId1.Id, GroupTafsiliId = _GroupTafsiliId1_2.Id, IsActive = true, NoeTabagheIndex = 0, NoeTabagheName = "کالا", SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651) ? EntityState.Detached : EntityState.Added;

                        var _GroupTafsiliId1_3 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 701);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 701, ParentCode = 701, LevelNumber = 1, LevelName = "محصولات", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId1.Id, EpTabaghehKala1 = new EpTabaghehKala() { SalId = 1, LevelNumber = 1, Code = 701, Name = "محصولات", VahedKalaId = _VahedAsliKalaId1.Id, GroupTafsiliId = _GroupTafsiliId1_3.Id, IsActive = true, NoeTabagheIndex = 0, NoeTabagheName = "کالا", SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 701) ? EntityState.Detached : EntityState.Added;

                        var _GroupTafsiliId1_4 = context.EpAllGroupTafsilis.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 751);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 751, ParentCode = 751, LevelNumber = 1, LevelName = "کالاها", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId1.Id, EpTabaghehKala1 = new EpTabaghehKala() { SalId = 1, LevelNumber = 1, Code = 751, Name = "کالاها", VahedKalaId = _VahedAsliKalaId1.Id, GroupTafsiliId = _GroupTafsiliId1_4.Id, IsActive = true, NoeTabagheIndex = 0, NoeTabagheName = "کالا", SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 751) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();

                        ////////////////  تعریف گروه اصلی اقلام انبار و اموال
                        var _VahedAsliKalaId2_1 = context.EpVahedKalas.FirstOrDefault(s => s.SalId == 1 && s.Name == "متر");
                        var _TabagheKalaId2_1 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == 601);

                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601001, ParentCode = 601, LevelNumber = 2, LevelName = "فریم", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 601001, Name = "فریم", VahedKalaId = _VahedAsliKalaId2_1.Id, TabaghehId = _TabagheKalaId2_1.Id, IsActive = true, SharhHesab = null, } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601002, ParentCode = 601, LevelNumber = 2, LevelName = "ساش پنجره", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 601002, Name = "ساش پنجره", VahedKalaId = _VahedAsliKalaId2_1.Id, TabaghehId = _TabagheKalaId2_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601002) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601003, ParentCode = 601, LevelNumber = 2, LevelName = "مولیون", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 601003, Name = "مولیون", VahedKalaId = _VahedAsliKalaId2_1.Id, TabaghehId = _TabagheKalaId2_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601003) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601004, ParentCode = 601, LevelNumber = 2, LevelName = "ساش درب", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 601004, Name = "ساش درب", VahedKalaId = _VahedAsliKalaId2_1.Id, TabaghehId = _TabagheKalaId2_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601004) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601005, ParentCode = 601, LevelNumber = 2, LevelName = "پنل", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 601005, Name = "پنل", VahedKalaId = _VahedAsliKalaId2_1.Id, TabaghehId = _TabagheKalaId2_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601005) ? EntityState.Detached : EntityState.Added;

                        var _VahedAsliKalaId2_2 = context.EpVahedKalas.FirstOrDefault(s => s.SalId == 1 && s.Name == "عدد");
                        var _TabagheKalaId2_2 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 1 && s.KeyCode == 651);

                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651001, ParentCode = 651, LevelNumber = 2, LevelName = "دستگیره", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 651001, Name = "دستگیره", VahedKalaId = _VahedAsliKalaId2_2.Id, TabaghehId = _TabagheKalaId2_2.Id, IsActive = true, SharhHesab = null, } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651002, ParentCode = 651, LevelNumber = 2, LevelName = "قفل", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 651002, Name = "قفل", VahedKalaId = _VahedAsliKalaId2_2.Id, TabaghehId = _TabagheKalaId2_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651002) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651003, ParentCode = 651, LevelNumber = 2, LevelName = "اسپانیولیت", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 651003, Name = "اسپانیولیت", VahedKalaId = _VahedAsliKalaId2_2.Id, TabaghehId = _TabagheKalaId2_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651003) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651004, ParentCode = 651, LevelNumber = 2, LevelName = "لولا", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 651004, Name = "لولا", VahedKalaId = _VahedAsliKalaId2_2.Id, TabaghehId = _TabagheKalaId2_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651004) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651005, ParentCode = 651, LevelNumber = 2, LevelName = "مغزی", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupAsliKala1 = new EpGroupAsliKala() { SalId = 1, LevelNumber = 2, Code = 651005, Name = "مغزی", VahedKalaId = _VahedAsliKalaId2_2.Id, TabaghehId = _TabagheKalaId2_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651005) ? EntityState.Detached : EntityState.Added;
                        context.SaveChanges();

                        ////////////////  تعریف گروه فرعی اقلام انبار و اموال
                        var _GroupAsliKalaId3_1 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601001);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601001001, ParentCode = 601001, LevelNumber = 3, LevelName = "فریم وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601001001, Name = "فریم وین تک", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601001001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601001002, ParentCode = 601001, LevelNumber = 3, LevelName = "فریم آریاوین", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601001002, Name = "فریم آریاوین", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_1.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601001002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_2 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601002);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601002001, ParentCode = 601002, LevelNumber = 3, LevelName = "ساش پنجره وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601002001, Name = "ساش پنجره وین تک", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601002001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601002002, ParentCode = 601002, LevelNumber = 3, LevelName = "ساش پنجره آریاوین", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601002002, Name = "ساش پنجره آریاوین", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_2.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601002002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_3 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601003);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601003001, ParentCode = 601003, LevelNumber = 3, LevelName = "مولیون وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601003001, Name = "مولیون وین تک", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_3.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601003001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601003002, ParentCode = 601003, LevelNumber = 3, LevelName = "مولیون آریاوین", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601003002, Name = "مولیون آریاوین", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_3.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601003002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_4 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601004);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601004001, ParentCode = 601004, LevelNumber = 3, LevelName = "ساش درب وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601004001, Name = "ساش درب وین تک", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_4.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601004001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601004002, ParentCode = 601004, LevelNumber = 3, LevelName = "ساش درب آریاوین", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601004001, Name = "ساش درب آریاوین", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_4.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601004002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_5 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 601005);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601005001, ParentCode = 601005, LevelNumber = 3, LevelName = "پنل وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601005001, Name = "پنل وین تک", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_5.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601005001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 601005002, ParentCode = 601005, LevelNumber = 3, LevelName = "پنل آریاوین", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_1.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 601005001, Name = "پنل آریاوین", VahedKalaId = _VahedAsliKalaId2_1.Id, GroupAsliId = _GroupAsliKalaId3_5.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 601005002) ? EntityState.Detached : EntityState.Added;
                        ///////////////
                        var _GroupAsliKalaId3_6 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651001);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651001001, ParentCode = 651001, LevelNumber = 3, LevelName = "دستگیره ویناک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651001001, Name = "دستگیره ویناک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_6.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651001001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651001002, ParentCode = 651001, LevelNumber = 3, LevelName = "دستگیره وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651001002, Name = "دستگیره وین تک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_6.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651001002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_7 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651002);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651002001, ParentCode = 651002, LevelNumber = 3, LevelName = "قفل ویناک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651002001, Name = "قفل ویناک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_7.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651002001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651002002, ParentCode = 651002, LevelNumber = 3, LevelName = "قفل وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651002002, Name = "قفل وین تک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_7.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651002002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_8 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651003);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651003001, ParentCode = 651003, LevelNumber = 3, LevelName = "اسپانیولیت ویناک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651003001, Name = "اسپانیولیت ویناک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_8.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651003001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651003002, ParentCode = 651003, LevelNumber = 3, LevelName = "اسپانیولیت وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651003001, Name = "اسپانیولیت وین تک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_8.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651003002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_9 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651004);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651004001, ParentCode = 651004, LevelNumber = 3, LevelName = "لولا ویناک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651004001, Name = "لولا ویناک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_9.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651004001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651004002, ParentCode = 651004, LevelNumber = 3, LevelName = "لولا وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651004002, Name = "لولا وین تک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_9.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651004002) ? EntityState.Detached : EntityState.Added;

                        var _GroupAsliKalaId3_10 = context.EpAllCodingKalas.FirstOrDefault(s => s.SalId == 1 && s.LevelNumber == 2 && s.KeyCode == 651005);
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651005001, ParentCode = 651005, LevelNumber = 3, LevelName = "پنل ویناک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651005001, Name = "پنل ویناک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_10.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651005001) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new EpAllCodingKala() { SalId = 1, KeyCode = 651005002, ParentCode = 651005, LevelNumber = 3, LevelName = "پنل وین تک", IsActive = true, VahedAsliKalaId = _VahedAsliKalaId2_2.Id, EpGroupFareeKala1 = new EpGroupFareeKala() { SalId = 1, LevelNumber = 3, Code = 651005002, Name = "پنل وین تک", VahedKalaId = _VahedAsliKalaId2_2.Id, GroupAsliId = _GroupAsliKalaId3_10.Id, IsActive = true, SharhHesab = null } }).State = context.EpAllCodingKalas.Any(s => s.SalId == 1 && s.KeyCode == 651005002) ? EntityState.Detached : EntityState.Added;

                        context.SaveChanges();
                    }
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

                    //////////////// تعریف سطح دسترسی به منو ها وزیر منوها
                    {
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

                    }

                    /////////////// تعریف گزینه های مربوط به تنظیمات سیستم
                    {
                        context.Entry(new TzTanzimatSystem() { KeyId = 44, ParentId = 44, LevelName = "تنظیمات انبار و کالا", IsSetAllUser = true, IsChecked = true }).State = context.TzTanzimatSystems.Any(s => s.KeyId == 44) ? EntityState.Detached : EntityState.Added;

                        context.Entry(new TzTanzimatSystem() { KeyId = 4401, ParentId = 44, LevelName = "عملیات ورود و خروج کالا", IsSetAllUser = true, IsChecked = true }).State = context.TzTanzimatSystems.Any(s => s.KeyId == 4401) ? EntityState.Detached : EntityState.Added;
                        context.Entry(new TzTanzimatSystem() { KeyId = 4401001, ParentId = 4401, LevelName = "در عملیات ورود و خروج کالا اول انبار مورد نظر انتخاب شود سپس کاربر اقدام به ثبت رسید و یا حواله نماید ", IsSetAllUser = true, IsChecked = true }).State = context.TzTanzimatSystems.Any(s => s.KeyId == 4401001) ? EntityState.Detached : EntityState.Added;

                    }
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