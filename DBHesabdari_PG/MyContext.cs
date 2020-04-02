/****************************** Ghost.github.io ******************************\
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
       //   Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
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

        public virtual DbSet<ApAnbar> ApAnbars { get; set; }
        public virtual DbSet<MsUser> MsUsers { get; set; }
        public virtual DbSet<MsMajmoe> MsMajmoes { get; set; }
        public virtual DbSet<MsVahed> MsVaheds { get; set; }
        public virtual DbSet<MsShobe> MsShobes { get; set; }
        public virtual DbSet<MsInfoOther> MsInfoOthers { get; set; }
        public virtual DbSet<MsDoreMali> MsDoreMalis { get; set; }
        public virtual DbSet<MsAccessLevelMenu> MsAccessLevelMenus { get; set; }
        public virtual DbSet<RmsUserBmsAccessLevelMenu> RmsUserBmsAccessLevelMenus { get; set; }
        public virtual DbSet<MsDefault> MsDefaults { get; set; }
        public virtual DbSet<MsAccessLevelDafaterMali> MsAccessLevelDafaterMalis { get; set; }
        public virtual DbSet<RmsUserBmsAccessLevelDafaterMali> RmsUserBmsAccessLevelDafaterMalis { get; set; }


        public virtual DbSet<EpTanzimatCodingHesabdari> EpTanzimatCodingHesabdaris { get; set; }
        public virtual DbSet<EpTanzimatGroupTafsili> EpTanzimatGroupTafsilis { get; set; }
        public virtual DbSet<EpHesabTabagheh> EpHesabTabaghehs { get; set; }
        public virtual DbSet<EpHesabGroup> EpHesabGroups { get; set; }
        public virtual DbSet<EpAllCodingHesabdari> EpAllCodingHesabdaris { get; set; }
        public virtual DbSet<RmsUserBallCodingHesabdari> RmsUserBallCodingHesabdaris { get; set; }
        public virtual DbSet<EpHesabCol> EpHesabCols { get; set; }
        public virtual DbSet<EpHesabMoin> EpHesabMoins { get; set; }
        public virtual DbSet<EpSharhStandardMoin> EpSharhStandardMoins { get; set; }
        public virtual DbSet<MsActiveSystem> MsActiveSystems { get; set; }
        public virtual DbSet<RMsActiveSystemBEpHesabMoin> RMsActiveSystemBEpHesabMoins { get; set; }

        public virtual DbSet<EpAllGroupTafsili> EpAllGroupTafsilis { get; set; }
        public virtual DbSet<EpGroupTafsiliLevel1> EpGroupTafsiliLevel1s { get; set; }
        public virtual DbSet<EpGroupTafsiliLevel2> EpGroupTafsiliLevel2s { get; set; }
        public virtual DbSet<EpGroupTafsiliLevel3> EpGroupTafsiliLevel3s { get; set; }

        public virtual DbSet<REpHesabMoinBEpGroupTafsiliLevel1> REpHesabMoinBEpGroupTafsiliLevel1s { get; set; }
        public virtual DbSet<EpHesabTafsiliSandogh> EpHesabTafsiliSandoghs { get; set; }
        public virtual DbSet<EpHesabTafsiliHesabBanki> EpHesabTafsiliHesabBankis { get; set; }
        public virtual DbSet<EpNameBank> EpNameBanks { get; set; }
        public virtual DbSet<EpNoeHesab> EpNoeHesabs { get; set; }
        public virtual DbSet<EpNoeArz> EpNoeArzs { get; set; }
        public virtual DbSet<EpHesabTafsiliAshkhas> EpHesabTafsiliAshkhass { get; set; }
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
        public virtual DbSet<EpHesabTafsiliDaraeha> EpHesabTafsiliDaraehas { get; set; }
        public virtual DbSet<EpHesabTafsiliProjhe> EpHesabTafsiliProjhes { get; set; }
        public virtual DbSet<EpHesabTafsiliVam> EpHesabTafsiliVams { get; set; }
        public virtual DbSet<EpHesabTafsiliMavad> EpHesabTafsiliMavads { get; set; }
        public virtual DbSet<EpHesabTafsiliGhataat> EpHesabTafsiliGhataats { get; set; }
        public virtual DbSet<EpHesabTafsiliMahsol> EpHesabTafsiliMahsols { get; set; }
        public virtual DbSet<EpHesabTafsiliKala> EpHesabTafsiliKalas { get; set; }
        public virtual DbSet<EpHesabTafsiliMarakezHazine> EpHesabTafsiliMarakezHazines { get; set; }
        public virtual DbSet<EpHesabTafsiliSayer> EpHesabTafsiliSayers { get; set; }
        public virtual DbSet<EpListAnbarha> EpListAnbarhas { get; set; }
        public virtual DbSet<EpVahedKala> EpVahedKalas { get; set; }
        public virtual DbSet<EpGroupAsliKala> EpGroupAsliKalas { get; set; }
        public virtual DbSet<EpGroupFareeKala> EpGroupFareeKalas { get; set; }
        public virtual DbSet<EpNameKala> EpNameKalas { get; set; }
        public virtual DbSet<EpTaminKonandeKala> EpTaminKonandeKalas { get; set; }
        public virtual DbSet<R_EpTaminKonandeKala_EpNameKala> R_EpTaminKonandeKala_EpNameKalas { get; set; }
        public virtual DbSet<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }



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


            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsUserBmsAccessLevelMenus).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsAccessLevelMenu>().HasMany(m => m.RmsUserhaBmsAccessLevelMenuhas).WithRequired(m => m.MsAccessLevelMenu1).HasForeignKey(m => m.MsAccessLevelMenuId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsUserBmsAccessLevelDafaterMalis).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsAccessLevelDafaterMali>().HasMany(m => m.RmsUserBmsAccessLevelDafaterMalis).WithRequired(m => m.MsAccessLevelDafaterMali1).HasForeignKey(m => m.MsAccessLevelDafaterMaliId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasOptional(m => m.MsDefault1).WithRequired(m => m.MsUser1).WillCascadeOnDelete(true);

            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsUserBallCodingHesabdaris).WithRequired(m => m.MsUser1).HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasMany(m => m.RmsUserBallCodingHesabdaris).WithRequired(m => m.EpAllCodingHesabdari1).HasForeignKey(m => m.CodingHesabdariId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabTabagheh1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabGroup1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabCol1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllCodingHesabdari>().HasOptional(m => m.EpHesabMoin1).WithRequired(m => m.EpAllCodingHesabdari1).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpHesabTabagheh>().HasMany(m => m.EpHesabGroups).WithRequired(m => m.EpHesabTabagheh1).HasForeignKey(m => m.TabaghehId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabGroup>().HasMany(m => m.EpHesabCols).WithRequired(m => m.EpHesabGroup1).HasForeignKey(m => m.GroupId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabCol>().HasMany(m => m.EpHesabMoins).WithRequired(m => m.EpHesabCol1).HasForeignKey(m => m.ColId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.EpSharhStandardMoins).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.RMsActiveSystemBEpHesabMoins).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsActiveSystem>().HasMany(m => m.RMsActiveSystemBEpHesabMoins).WithRequired(m => m.MsActiveSystem1).HasForeignKey(m => m.ActiveSystemId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.REpHesabMoinBEpGroupTafsiliLevel1s).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.REpHesabMoinBEpGroupTafsiliLevel1s).WithRequired(m => m.EpGroupTafsiliLevel11).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliSandoghs).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliHesabBankis).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliAshkhass).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliDaraehas).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliProjhes).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliVams).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMavads).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliGhataats).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMahsols).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliKalas).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliMarakezHazines).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpHesabTafsiliSayers).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpAllHesabTafsilis).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.GroupTafsiliId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel1).WithRequired(m => m.EpAllGroupTafsilis).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel2).WithRequired(m => m.EpAllGroupTafsilis).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllGroupTafsili>().HasOptional(m => m.EpGroupTafsiliLevel3).WithRequired(m => m.EpAllGroupTafsilis).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpGroupTafsiliLevel1>().HasMany(m => m.EpGroupTafsiliLevel2s).WithRequired(m => m.EpGroupTafsiliLevel1).HasForeignKey(m => m.Level1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafsiliLevel2>().HasMany(m => m.EpGroupTafsiliLevel3s).WithRequired(m => m.EpGroupTafsiliLevel2).HasForeignKey(m => m.Level2Id).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupAsliKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithOptional(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala2Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithOptional(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala3Id).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpGroupAsliKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpGroupAsliKala1).HasForeignKey(m => m.GroupAsliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupFareeKala>().HasMany(m => m.EpNameKalas).WithRequired(m => m.EpGroupFareeKala1).HasForeignKey(m => m.GroupFareeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpTaminKonandeKala>().HasMany(m => m.R_EpTaminKonandeKala_EpNameKalas).WithRequired(m => m.EpTaminKonandeKala1).HasForeignKey(m => m.TKId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameKala>().HasMany(m => m.R_EpTaminKonandeKala_EpNameKalas).WithRequired(m => m.EpNameKala1).HasForeignKey(m => m.NKId).WillCascadeOnDelete(false);
            ///////////////////////
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliSandogh1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliHesabBanki1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAllHesabTafsili>().HasOptional(m => m.EpHesabTafsiliAshkhas1).WithRequired(m => m.EpAllHesabTafsili1).WillCascadeOnDelete(true);


            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNameBank1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNoeHesab1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafsiliHesabBanki>().HasRequired(m => m.EpNoeArz1).WithMany(m=>m.EpHesabTafsiliHesabBankis).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabTafsiliHesabBankis).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeHesab>().HasMany(m => m.EpHesabTafsiliHesabBankis).WithRequired(m => m.EpNoeHesab1).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeArz>().HasMany(m => m.EpHesabTafsiliHesabBankis).WithRequired(m => m.EpNoeArz1).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasOptional(m => m.EpMoshakhasat_A1).WithRequired(m => m.EpHesabTafsiliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpShTamas_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpEetebarat_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpFazaMajazi_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadTakhfif_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasOptional(m => m.EpMPersoneli_A1).WithRequired(m => m.EpHesabTafsiliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpSahmSahamdar_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadVizitor_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafsiliAshkhas>().HasMany(m => m.EpDarsadRanande_As).WithRequired(m => m.EpHesabTafsiliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpNameAdress>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameAdress1).HasForeignKey(m => m.NameAdressId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameOstan>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameOstan1).HasForeignKey(m => m.NameOstanId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameShahrstan>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpNameShahrstan1).HasForeignKey(m => m.NameShahrstanId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameOstan>().HasMany(m => m.EpNameShahrstans).WithRequired(m => m.EpNameOstan1).HasForeignKey(m => m.NameOstanId).WillCascadeOnDelete(false);

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