﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	MyContext.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:37
*	
***********************************************************************************/
namespace DBHesabdari_PG
{
    using DBHesabdari_PG.Migrations;
    using DBHesabdari_PG;
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using DBHesabdari_PG.Models.EP.CodingHesabdari;
    using DBHesabdari_PG.Models.Ms.ActiveSystem;
    using DBHesabdari_PG.Models.Ms.DafaterMali;
    using DBHesabdari_PG.Models.Ms.SystemUsers;
    using DBHesabdari_PG.Models.EP.CodingAnbar;
    using DBHesabdari_PG.Models.EP.Tanzimat;
    using DBHesabdari_PG.Models.AK;
    using System.Reflection.Emit;
    using DBHesabdari_PG.Models.Tz;
    using DBHesabdari_PG.Models.FK;
    using DBHesabdari_PG.Models.FK.Tanzimat;
    using DBHesabdari_PG.Models.FK.Taarif;

    public class MyContext : DbContext
    {
        #region
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Hesabdari_PG.Models.MyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyContext' 
        // connection string in the application configuration file.
        #endregion

        public MyContext()
            : base("name=MyContext")
        {
            #region
            //پیش فرض
            //Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
            //حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییرویاعدم تغییر(در هرصورت) کلاس مدل
        //    Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
            // حذف دیتابیس قبلی بهمراه داده های داخلش و ایجاد دیتابیس جدید بدون داده در صورت تغییر کلاس مدل
            //Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
            // غیرفعال کردن پیکربندی دیتابیس برای اینکه داده های فعلی موجود در دیتا بیس حذف نشود
            //Database.SetInitializer<MyContext>(null);
            //پیکربندی دیتابیس بصورت Coustom
            //Database.SetInitializer<MyContext>(new MyContextInitializer());
            #endregion
            //Migration SetInitializer
            Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>(true));
            SqlConnection.ClearAllPools();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MsUser> MsUsers { get; set; }
        public virtual DbSet<MsMajmoe> MsMajmoes { get; set; }
        public virtual DbSet<MsVahed> MsVaheds { get; set; }
        public virtual DbSet<MsShobe> MsShobes { get; set; }
        public virtual DbSet<MsInfoOther> MsInfoOthers { get; set; }
        public virtual DbSet<MsDoreMali> MsDoreMalis { get; set; }
        public virtual DbSet<MsAccessLevelMenu> MsAccessLevelMenus { get; set; }
        public virtual DbSet<R_MsUser_B_MsAccessLevelMenu> RmsUserBmsAccessLevelMenus { get; set; }
        public virtual DbSet<MsDefault> MsDefaults { get; set; }
        public virtual DbSet<MsAccessLevelDafaterMali> MsAccessLevelDafaterMalis { get; set; }
        public virtual DbSet<R_MsUser_B_MsAccessLevelDafaterMali> RmsUserBmsAccessLevelDafaterMalis { get; set; }
        public virtual DbSet<TzTanzimatSystem> TzTanzimatSystems { get; set; }
        public virtual DbSet<R_MsUser_B_TzTanzimatSystem> R_MsUser_B_TzTanzimatSystems { get; set; }


        public virtual DbSet<EpTanzimatCodingHesabdari> EpTanzimatCodingHesabdaris { get; set; }
        public virtual DbSet<EpTanzimatGroupTafsili> EpTanzimatGroupTafsilis { get; set; }
        public virtual DbSet<EpHesabTabagheh> EpHesabTabaghehs { get; set; }
        public virtual DbSet<EpHesabGroup> EpHesabGroups { get; set; }
        public virtual DbSet<EpHesabCol> EpHesabCols { get; set; }
        public virtual DbSet<EpHesabMoin1> EpHesabMoin1s { get; set; }
        public virtual DbSet<EpSharhStandardMoin> EpSharhStandardMoins { get; set; }
        public virtual DbSet<EpAllCodingHesabdari> EpAllCodingHesabdaris { get; set; }
        public virtual DbSet<R_MsUser_B_AllCodingHesabdari> RmsUserBallCodingHesabdaris { get; set; }
        public virtual DbSet<MsActiveSystem> MsActiveSystems { get; set; }
        public virtual DbSet<R_EpAllCodingHesabdari_B_MsActiveSystem> REpAllCodingHesabdariBMsActiveSystems { get; set; }

        public virtual DbSet<EpGroupTafsiliLevel1> EpGroupTafsiliLevel1s { get; set; }
        public virtual DbSet<EpGroupTafsiliLevel2> EpGroupTafsiliLevel2s { get; set; }
        public virtual DbSet<EpGroupTafsiliLevel3> EpGroupTafsiliLevel3s { get; set; }
        public virtual DbSet<EpAllGroupTafsili> EpAllGroupTafsilis { get; set; }
        public virtual DbSet<R_EpHesabMoin1_B_EpAllGroupTafsili> R_EpHesabMoin1_B_EpAllGroupTafsilis { get; set; }


        public virtual DbSet<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }
        public virtual DbSet<EpHesabTafsiliAshkhas> EpHesabTafsiliAshkhass { get; set; }
        public virtual DbSet<EpHesabTafsiliAghlamAnbar> EpHesabTafsiliAghlamAnbars { get; set; }
        public virtual DbSet<EpHesabTafsiliDaraeha> EpHesabTafsiliDaraehas { get; set; }
        public virtual DbSet<EpHesabTafsiliSandogh> EpHesabTafsiliSandoghs { get; set; }
        public virtual DbSet<EpHesabTafsiliBankha> EpHesabTafsiliBankhas { get; set; }
        public virtual DbSet<EpNameBank> EpNameBanks { get; set; }
        public virtual DbSet<EpNoeHesab> EpNoeHesabs { get; set; }
        public virtual DbSet<EpNoeArz> EpNoeArzs { get; set; }
        public virtual DbSet<EpHesabTafsiliVam> EpHesabTafsiliVams { get; set; }
        public virtual DbSet<EpHesabTafsiliMarakezHazine> EpHesabTafsiliMarakezHazines { get; set; }
        public virtual DbSet<EpHesabTafsiliShoabat> EpHesabTafsiliShoabats { get; set; }
        public virtual DbSet<EpHesabTafsiliProzhe> EpHesabTafsiliProzhes { get; set; }
        public virtual DbSet<EpHesabTafsiliGharardad> EpHesabTafsiliGharardads { get; set; }
        public virtual DbSet<EpHesabTafsiliAnbarha> EpHesabTafsiliAnbarhas { get; set; }
        public virtual DbSet<EpHesabTafsiliSayer> EpHesabTafsiliSayers { get; set; }


        public virtual DbSet<EpMoshakhasat_A> EpMoshakhasat_As { get; set; }
        public virtual DbSet<EpAdress_A> EpAdress_As { get; set; }
        public virtual DbSet<EpNameAdress> EpNameAdresss { get; set; }
        public virtual DbSet<EpNameOstan> EpNameOstans { get; set; }
        public virtual DbSet<EpNameShahrstan> EpNameShahrstans { get; set; }
        public virtual DbSet<EpShTamas_A> EpShTamas_As { get; set; }
        public virtual DbSet<EpEetebarat_A> EpEetebarat_As { get; set; }
        public virtual DbSet<EpFazaMajazi_A> EpFazaMajazi_As { get; set; }
        public virtual DbSet<EpHesabBanki_A> EpHesabBanki_As { get; set; }
        public virtual DbSet<EpDarsadTakhfif_A> EpDarsadTakhfif_As { get; set; }
        public virtual DbSet<EpMPersoneli_A> EpMPersoneli_As { get; set; }
        public virtual DbSet<EpSahmSahamdar_A> EpSahmSahamdar_As { get; set; }
        public virtual DbSet<EpDarsadVizitor_A> EpDarsadVizitor_As { get; set; }
        public virtual DbSet<EpDarsadRanande_A> EpDarsadRanande_As { get; set; }


        public virtual DbSet<EpAllCodingKala> EpAllCodingKalas { get; set; }
        public virtual DbSet<EpTanzimatAnbarVKala> EpTanzimatAnbarVKalas { get; set; }
        public virtual DbSet<EpListAnbarha> EpListAnbarhas { get; set; }
        public virtual DbSet<R_EpListAnbarha_B_EpTabaghehKala> R_EpListAnbarha_B_EpTabaghehKalas { get; set; }

        
        public virtual DbSet<EpVahedKala> EpVahedKalas { get; set; }
        public virtual DbSet<EpTabaghehKala> EpTabaghehKalas { get; set; }
        public virtual DbSet<EpGroupAsliKala> EpGroupAsliKalas { get; set; }
        public virtual DbSet<EpGroupFareeKala> EpGroupFareeKalas { get; set; }
        public virtual DbSet<EpNameKala> EpNameKalas { get; set; }


        //public virtual DbSet<AkAllAmaliateRozaneh> AkAllAmaliateRozanehs { get; set; }
        //public virtual DbSet<AkVorodeKala> AkVorodeKalas { get; set; }
        public virtual DbSet<AKAmaliatAnbarVKala_Riz> AKAmaliatAnbarVKala_Rizs { get; set; }
        // public virtual DbSet<AkKhorojeKala_Riz> AkKhorojeKala_Rizs { get; set; }
        //public virtual DbSet<R_EpAllCodingKala_B_AkAllAmaliateRozaneh> R_EpAllCodingKala_B_AkAllAmaliateRozanehs { get; set; }

        public virtual DbSet<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Rizs { get; set; }
        public virtual DbSet<FKTanzimatFactor> FKTanzimatFactors { get; set; }
        public virtual DbSet<FKTarifEz_Ks_Factor> FKTarifEz_Ks_Factors { get; set; }
        public virtual DbSet<FKMotamemFactor> FKMotamemFactors { get; set; }


        #region
        //public class StudentContextInitializer : DropCreateDatabaseIfModelChanges<StudentContext>
        //{
        //    protected override void Seed(StudentContext context)
        //    {
        //        //context.Students.Add(new Student() { FName = "Abdulla61", LName = "Varash61", Degree = 4455, Adress = "fffff3", Tell = "888883", Mobile = "yyyy",Mobile3="33" });
        //        IList<Student> os = new List<Student>();
        //        os.Add(new Student() { FName = "kamal", LName = "khayati", Degree = 35, Tell = "555", Mobile = "666" });
        //        os.Add(new Student() { FName = "kamal1", LName = "khayati1", Degree = 35, Tell = "5551", Mobile = "6661" });
        //        os.Add(new Student() { FName = "kamal2", LName = "khayati2", Degree = 35, Tell = "5552", Mobile = "6662" });
        //        os.Add(new Student() { FName = "kamal3", LName = "khayati3", Degree = 35, Tell = "5553", Mobile = "6663" });

        //        foreach (var item in os)
        //        {
        //            context.Students.Add(item);
        //        }
        //    }

        //}
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsMajmoe>().HasMany(m => m.MsVaheds).WithRequired(m => m.MsMajmoe1).HasForeignKey(m => m.MsMajmoeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsVahed>().HasMany(m => m.MsShobes).WithRequired(m => m.MsVahed1).HasForeignKey(m => m.MsVahedId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsShobe>().HasMany(m => m.MsDoreMalis).WithRequired(m => m.MsShobe1).HasForeignKey(m => m.MsShobeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<MsUser>().HasMany(m => m.R_MsUser_B_TzTanzimatSystems).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<TzTanzimatSystem>().HasMany(m => m.R_MsUser_B_TzTanzimatSystems).WithRequired(m => m.TzTanzimatSystem1).HasForeignKey(m => m.TanzimatSystemId).WillCascadeOnDelete(true);


            modelBuilder.Entity<MsUser>().HasMany(m => m.R_MsUser_B_MsAccessLevelMenus).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsAccessLevelMenu>().HasMany(m => m.RmsUserhaBmsAccessLevelMenuhas).WithRequired(m => m.MsAccessLevelMenu1).HasForeignKey(m => m.MsAccessLevelMenuId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasMany(m => m.R_MsUser_B_MsAccessLevelDafaterMalis).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsAccessLevelDafaterMali>().HasMany(m => m.RmsUserBmsAccessLevelDafaterMalis).WithRequired(m => m.MsAccessLevelDafaterMali1).HasForeignKey(m => m.MsAccessLevelDafaterMaliId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasOptional(m => m.MsDefault1).WithRequired(m => m.MsUser1).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasMany(m => m.R_MsUser_B_AllCodingHesabdaris).WithRequired(m => m.MsUser1).HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasMany(m => m.RmsUserBallCodingHesabdaris).WithRequired(m => m.EpAllCodingHesabdari1).HasForeignKey(m => m.CodingHesabdariId).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabTabagheh1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabGroup1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabCol1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabMoin1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.R_EpHesabMoin1_B_EpAllGroupTafsilis).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.EpHesabMoin1Id).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllGroupTafsili>().HasMany(m => m.R_EpHesabMoin1_B_EpAllGroupTafsilis).WithRequired(m => m.EpAllGroupTafsili1).HasForeignKey(m => m.AllGroupTafsiliId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasMany(m => m.R_EpAllCodingHesabdari_B_MsActiveSystems).WithRequired(m => m.EpAllCodingHesabdari1).HasForeignKey(m => m.AllCodingHesabdariId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsActiveSystem>().HasMany(m => m.REpAllCodingHesabdariBMsActiveSystems).WithRequired(m => m.MsActiveSystem1).HasForeignKey(m => m.ActiveSystemId).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpHesabTabagheh>().HasMany(m => m.EpHesabGroups).WithRequired(m => m.EpHesabTabagheh1).HasForeignKey(m => m.TabaghehId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabGroup>().HasMany(m => m.EpHesabCols).WithRequired(m => m.EpHesabGroup1).HasForeignKey(m => m.GroupId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabCol>().HasMany(m => m.EpHesabMoin1s).WithRequired(m => m.EpHesabCol1).HasForeignKey(m => m.ColId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz_Beds).WithRequired(m => m.EpHesabMoin1_Bed).HasForeignKey(m => m.HesabMoinId_Bed).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz_Bess).WithRequired(m => m.EpHesabMoin1_Bes).HasForeignKey(m => m.HesabMoinId_Bes).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.AKAmaliatAnbarVKala_Rizs).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.HesabMoinId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.EpNameKala_Khs).WithOptional(m => m.EpHesabMoin1_Kh).HasForeignKey(m => m.HesabMoinId_Kh).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.EpNameKala_Frs).WithOptional(m => m.EpHesabMoin1_Fr).HasForeignKey(m => m.HesabMoinId_Fr).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.EpSharhStandardMoins).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.EpListAnbarhas).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin1>().HasMany(m => m.FKTanzimatFactors).WithOptional(m => m.EpHesabMoin1).HasForeignKey(m => m.HesabMoinId).WillCascadeOnDelete(false);


            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliSandoghs).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliHesabBankis).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliAshkhass).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliDaraehas).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliProjhes).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliVams).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMavads).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliGhataats).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMahsols).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliKalas).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMarakezHazines).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliSayers).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpAllHesabTafsilis).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);


            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpGroupTafsiliLevel2s).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.Level1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel2>().HasMany(m => m.EpGroupTafsiliLevel3s).WithRequired(m => m.EpGroupTafsiliLevel2).HasForeignKey(m => m.Level2Id).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel1).WithRequired(m => m.EpAllGroupTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel2).WithRequired(m => m.EpAllGroupTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel3).WithRequired(m => m.EpAllGroupTafsili1).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpAllGroupTafsili>().HasMany(m => m.EpAllHesabTafsilis).WithRequired(m => m.EpAllGroupTafsili1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);

            // مجبور شدم رابطه یک به چند بین گروه تفصیلی و طبقه کالا برقرار کنم 
            modelBuilder.Entity<EpAllGroupTafsili>().HasMany(m => m.EpTabaghehKalas).WithRequired(m => m.EpAllGroupTafsili1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpTabaghehKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupAsliKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKala1s).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKala2s).WithOptional(m => m.EpVahedKala2).HasForeignKey(m => m.VahedKala2Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKala3s).WithOptional(m => m.EpVahedKala3).HasForeignKey(m => m.VahedKala3Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKala4s).WithRequired(m => m.EpVahedAsliKala).HasForeignKey(m => m.VahedAsliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpAllCodingKalas).WithRequired(m => m.EpVahedAsliKala).HasForeignKey(m => m.VahedAsliKalaId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpVahedKala>().HasMany(m => m.FkAmaliatFrooshVKharid_Rizs).WithOptional(m => m.EpVahedKala1).HasForeignKey(m => m.VahedeKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.AKAmaliatAnbarVKala_Rizs).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedeKalaId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpVahedKala>().HasMany(m => m.AkKhorojeKala_Rizs).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedeKalaId).WillCascadeOnDelete(false);


            modelBuilder.Entity<EpNameKala>().HasMany(m => m.FkAmaliatFrooshVKharid_Rizs).WithOptional(m => m.EpNameKala1).HasForeignKey(m => m.KalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameKala>().HasMany(m => m.AKAmaliatAnbarVKala_Rizs).WithRequired(m => m.EpNameKala1).HasForeignKey(m => m.KalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameKala>().HasMany(m => m.FKTanzimatFactors).WithOptional(m => m.EpNameKala1).HasForeignKey(m => m.KhadamatId).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpAllCodingKala>().HasOptional(m => m.EpTabaghehKala1).WithRequired(m => m.EpAllCodingKala1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingKala>().HasOptional(m => m.EpGroupAsliKala1).WithRequired(m => m.EpAllCodingKala1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingKala>().HasOptional(m => m.EpGroupFareeKala1).WithRequired(m => m.EpAllCodingKala1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingKala>().HasOptional(m => m.EpNameKala1).WithRequired(m => m.EpAllCodingKala1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpTabaghehKala>().HasMany(m => m.EpGroupAsliKalas).WithRequired(m => m.EpTabaghehKala1).HasForeignKey(m => m.TabaghehId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupAsliKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpGroupAsliKala1).HasForeignKey(m => m.GroupAsliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupFareeKala>().HasMany(m => m.EpNameKalas).WithRequired(m => m.EpGroupFareeKala1).HasForeignKey(m => m.GroupFareeId).WillCascadeOnDelete(false);

            ///////////////////////
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliAshkhas1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliAghlamAnbar1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliSandogh1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliBankha1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliDaraeha1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliSandogh1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliBankha1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliVam1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliMarakezHazine1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliShoabat1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliProzhe1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliGharardad1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliAnbarha1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliSayer1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz1_Beds).WithRequired(m => m.EpAllHesabTafsili1_Bed).HasForeignKey(m => m.HesabTafsili1Id_Bed).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz2_Beds).WithRequired(m => m.EpAllHesabTafsili2_Bed).HasForeignKey(m => m.HesabTafsili2Id_Bed).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz3_Beds).WithRequired(m => m.EpAllHesabTafsili3_Bed).HasForeignKey(m => m.HesabTafsili3Id_Bed).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz1_Bess).WithRequired(m => m.EpAllHesabTafsili1_Bes).HasForeignKey(m => m.HesabTafsili1Id_Bes).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz2_Bess).WithRequired(m => m.EpAllHesabTafsili2_Bes).HasForeignKey(m => m.HesabTafsili2Id_Bes).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz3_Bess).WithRequired(m => m.EpAllHesabTafsili3_Bes).HasForeignKey(m => m.HesabTafsili3Id_Bes).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Kh1s).WithOptional(m => m.EpAllHesabTafsili1_Kh).HasForeignKey(m => m.HesabTafsili1Id_Kh).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Kh2s).WithOptional(m => m.EpAllHesabTafsili2_Kh).HasForeignKey(m => m.HesabTafsili2Id_Kh).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Kh3s).WithOptional(m => m.EpAllHesabTafsili3_Kh).HasForeignKey(m => m.HesabTafsili3Id_Kh).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Fr1s).WithOptional(m => m.EpAllHesabTafsili1_Fr).HasForeignKey(m => m.HesabTafsili1Id_Fr).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Fr2s).WithOptional(m => m.EpAllHesabTafsili2_Fr).HasForeignKey(m => m.HesabTafsili2Id_Fr).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpNameKala_Fr3s).WithOptional(m => m.EpAllHesabTafsili3_Fr).HasForeignKey(m => m.HesabTafsili3Id_Fr).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.FkAmaliatFrooshVKharid_Rizs).WithOptional(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.VizitorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.FKTanzimatFactors).WithOptional(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.VizitorId).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FKTanzimatFactor1s).WithOptional(m => m.EpAllHesabTafsili1).HasForeignKey(m => m.HesabTafsili1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FKTanzimatFactor2s).WithOptional(m => m.EpAllHesabTafsili2).HasForeignKey(m => m.HesabTafsili2Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.FKTanzimatFactor3s).WithOptional(m => m.EpAllHesabTafsili3).HasForeignKey(m => m.HesabTafsili3Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AKAmaliatAnbarVKala_Riz1s).WithRequired(m => m.EpAllHesabTafsili1).HasForeignKey(m => m.HesabTafsili1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AKAmaliatAnbarVKala_Riz2s).WithRequired(m => m.EpAllHesabTafsili2).HasForeignKey(m => m.HesabTafsili2Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AKAmaliatAnbarVKala_Riz3s).WithRequired(m => m.EpAllHesabTafsili3).HasForeignKey(m => m.HesabTafsili3Id).WillCascadeOnDelete(false);

            //modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AkKhorojeKala_Riz1s).WithRequired(m => m.EpAllHesabTafsili1).HasForeignKey(m => m.HesabTafsili1Id).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AkKhorojeKala_Riz2s).WithRequired(m => m.EpAllHesabTafsili2).HasForeignKey(m => m.HesabTafsili2Id).WillCascadeOnDelete(false);
            //modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.AkKhorojeKala_Riz3s).WithRequired(m => m.EpAllHesabTafsili3).HasForeignKey(m => m.HesabTafsili3Id).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpListAnbarha1s).WithRequired(m => m.EpAllHesabTafsili1).HasForeignKey(m => m.TafsiliId1).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpListAnbarha2s).WithRequired(m => m.EpAllHesabTafsili2).HasForeignKey(m => m.TafsiliId2).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpAllHesabTafsili>().HasMany(m => m.EpListAnbarha3s).WithRequired(m => m.EpAllHesabTafsili3).HasForeignKey(m => m.TafsiliId3).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabTafsiliBankhas).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeHesab>().HasMany(m => m.EpHesabTafsiliBankhas).WithRequired(m => m.EpNoeHesab1).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeArz>().HasMany(m => m.EpHesabTafsiliBankhas).WithRequired(m => m.EpNoeArz1).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(false);


            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNameBank1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNoeHesab1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNoeArz1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasOptional(m => m.EpMoshakhasat_A1).WithRequired(m => m.EpHesabTafsiliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpShTamas_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpEetebarat_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpFazaMajazi_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadTakhfif_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasOptional(m => m.EpMPersoneli_A1).WithRequired(m => m.EpHesabTafsiliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpSahmSahamdar_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadVizitor_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadRanande_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m => m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpNameAdress>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameAdress1).HasForeignKey(m => m.NameAdressId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameOstan>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameOstan1).HasForeignKey(m => m.NameOstanId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameShahrstan>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameShahrstan1).HasForeignKey(m => m.NameShahrstanId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameOstan>().HasMany(m => m.EpNameShahrstans).WithRequired(m => m.EpNameOstan1).HasForeignKey(m => m.NameOstanId).WillCascadeOnDelete(false);

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 4));
            //modelBuilder.Entity<AkVorodeKala>().Property(p => p.SumMeghdar).HasPrecision(18, 4);
            //modelBuilder.Entity<AkVorodeKala>().Property(p => p.SumMablag).HasPrecision(18, 0);
            modelBuilder.Entity<FkAmaliatFrooshVKharid_Riz>().Property(p => p.Meghdar).HasPrecision(18, 3);
            modelBuilder.Entity<FkAmaliatFrooshVKharid_Riz>().Property(p => p.Nerkh).HasPrecision(18, 3);
            modelBuilder.Entity<FkAmaliatFrooshVKharid_Riz>().Property(p => p.Mablag).HasPrecision(18, 0);
            modelBuilder.Entity<AKAmaliatAnbarVKala_Riz>().Property(p => p.Meghdar).HasPrecision(18, 3);
            modelBuilder.Entity<AKAmaliatAnbarVKala_Riz>().Property(p => p.Nerkh).HasPrecision(18, 3);
            modelBuilder.Entity<AKAmaliatAnbarVKala_Riz>().Property(p => p.Mablag).HasPrecision(18, 0);
            //modelBuilder.Entity<AkAllAmaliateRozaneh>().Property(p => p.Meghdar).HasPrecision(18, 3);
           // modelBuilder.Entity<AkAllAmaliateRozaneh>().Property(p => p.Nerkh).HasPrecision(18, 3);
           // modelBuilder.Entity<AkAllAmaliateRozaneh>().Property(p => p.Mablag).HasPrecision(18, 0);

            //modelBuilder.Entity<EpAllCodingKala>().HasMany(m => m.R_EpAllCodingKala_B_AkAllAmaliateRozanehs).WithRequired(m => m.EpAllCodingKala1).HasForeignKey(m => m.KalaId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<AkAllAmaliateRozaneh>().HasMany(m => m.R_EpAllCodingKala_B_AkAllAmaliateRozanehs).WithRequired(m => m.AkAllAmaliateRozaneh1).HasForeignKey(m => m.AmaliatId).WillCascadeOnDelete(true);

            //modelBuilder.Entity<AkAllAmaliateRozaneh>().HasOptional(m => m.AKAmaliatAnbarVKala_Riz1).WithRequired(m => m.AkAllAmaliateRozaneh1).WillCascadeOnDelete(true);
            //modelBuilder.Entity<AkAllAmaliateRozaneh>().HasOptional(m => m.AkKhorojeKala_Riz1).WithRequired(m => m.AkAllAmaliateRozaneh1).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.R_EpListAnbarha_B_EpTabaghehKalas).WithRequired(m => m.EpListAnbarha1).HasForeignKey(m => m.AnbarhId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpTabaghehKala>().HasMany(m => m.R_EpListAnbarha_B_EpTabaghehKalas).WithRequired(m => m.EpTabaghehKala1).HasForeignKey(m => m.TabagheKalaId).WillCascadeOnDelete(true);

            //modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz1s).WithRequired(m => m.EpListAnbarha1).HasForeignKey(m => m.AnbarId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.FkAmaliatFrooshVKharid_Riz1s).WithOptional(m => m.EpListAnbarha1).HasForeignKey(m => m.AnbarId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.AKAmaliatAnbarVKala_Riz1s).WithRequired(m => m.EpListAnbarha1).HasForeignKey(m => m.AzAnbarId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.AKAmaliatAnbarVKala_Riz2s).WithRequired(m => m.EpListAnbarha2).HasForeignKey(m => m.BeAnbarId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.FKTanzimatFactors).WithOptional(m => m.EpListAnbarha1).HasForeignKey(m => m.AnbarId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpListAnbarha>().HasMany(m => m.AkKhorojeKala_Riz2s).WithRequired(m => m.EpListAnbarha2).HasForeignKey(m => m.BeAnbarId).WillCascadeOnDelete(false);

            modelBuilder.Entity<FKTarifEz_Ks_Factor>().HasMany(m => m.FkAmaliatFrooshVKharid_Rizs).WithOptional(m => m.FKTarifEz_Ks_Factor1).HasForeignKey(m => m.Ez_KsId).WillCascadeOnDelete(false);
            modelBuilder.Entity<FKTarifEz_Ks_Factor>().HasMany(m => m.FKTanzimatFactors).WithOptional(m => m.FKTarifEz_Ks_Factor1).HasForeignKey(m => m.Ez_KsId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpDarsadTakhfif_A>().HasMany(m => m.FKMotamemFactors).WithOptional(m => m.EpDarsadTakhfif_A1).HasForeignKey(m => m.TakhfifId).WillCascadeOnDelete(false);


            #region
            //--------> one - to - zero - or - one relationships < ------------
            //modelBuilder.Entity<Student>()
            //     .HasRequired(c => c.Standard)
            //     .WithRequiredPrincipal(f => f.Student);


            //--------> one-to-Many relationships <-------------- 

            //modelBuilder.Entity<Student>()
            //    .HasRequired(c => c.Standard)
            //    .WithMany(g => g.Student)
            //    .HasForeignKey(c => c.StandardId);

            //modelBuilder.Entity<Standard>()
            //    .HasMany(s => s.Student)
            //    .WithRequired(c => c.Standard)
            //    .HasForeignKey(c => c.StandardId)
            //    .WillCascadeOnDelete();

            //--------> Many-to-Many relationships <------------------
            //}
            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new RmsUserhaBmsMajmoeha.Configuration());
            //modelBuilder.HasDefaultSchema("Admin");
            //modelBuilder.ComplexType<Models.Adress>();
            //}
            #endregion

        }


        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    }
}