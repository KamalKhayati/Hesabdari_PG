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
           // Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
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
        public virtual DbSet<EpHesabGroup> EpHesabGroups { get; set; }
        public virtual DbSet<EpAccessLevelCodingHesabdari> EpAccessLevelCodingHesabdaris { get; set; }
        public virtual DbSet<RmsUserBepAccessLevelCodingHesabdari> RmsUserBepAccessLevelCodingHesabdaris { get; set; }
        public virtual DbSet<EpHesabCol> EpHesabCols { get; set; }
        public virtual DbSet<EpHesabMoin> EpHesabMoins { get; set; }
        public virtual DbSet<EpSharhStandardMoin> EpSharhStandardMoins { get; set; }
        public virtual DbSet<MsActiveSystem> MsActiveSystems { get; set; }
        public virtual DbSet<RMsActiveSystemBEpHesabMoin> RMsActiveSystemBEpHesabMoins { get; set; }
        public virtual DbSet<EpGroupTafzili> EpGroupTafzilis { get; set; }
        public virtual DbSet<REpHesabMoinBEpGroupTafziliLevel1> REpHesabMoinBEpGroupTafziliLevel1s { get; set; }
        public virtual DbSet<EpHesabTafziliSandogh> EpHesabTafziliSandoghs { get; set; }
        public virtual DbSet<EpHesabTafziliHesabBanki> EpHesabTafziliHesabBankis { get; set; }
        public virtual DbSet<EpNameBank> EpNameBanks { get; set; }
        public virtual DbSet<EpNoeHesab> EpNoeHesabs { get; set; }
        public virtual DbSet<EpNoeArz> EpNoeArzs { get; set; }
        public virtual DbSet<EpHesabTafziliAshkhas> EpHesabTafziliAshkhass { get; set; }
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
        public virtual DbSet<EpHesabTafziliDaraeha> EpHesabTafziliDaraehas { get; set; }
        public virtual DbSet<EpHesabTafziliProjhe> EpHesabTafziliProjhes { get; set; }
        public virtual DbSet<EpHesabTafziliVam> EpHesabTafziliVams { get; set; }
        public virtual DbSet<EpHesabTafziliMavad> EpHesabTafziliMavads { get; set; }
        public virtual DbSet<EpHesabTafziliGhataat> EpHesabTafziliGhataats { get; set; }
        public virtual DbSet<EpHesabTafziliMahsol> EpHesabTafziliMahsols { get; set; }
        public virtual DbSet<EpHesabTafziliKala> EpHesabTafziliKalas { get; set; }
        public virtual DbSet<EpHesabTafziliMarakezHazine> EpHesabTafziliMarakezHazines { get; set; }
        public virtual DbSet<EpHesabTafziliSayer> EpHesabTafziliSayers { get; set; }
        public virtual DbSet<EpListAnbarha> EpListAnbarhas { get; set; }
        public virtual DbSet<EpVahedKala> EpVahedKalas { get; set; }
        public virtual DbSet<EpGroupAsliKala> EpGroupAsliKalas { get; set; }
        public virtual DbSet<EpGroupFareeKala> EpGroupFareeKalas { get; set; }
        public virtual DbSet<EpNameKala> EpNameKalas { get; set; }
        public virtual DbSet<EpTaminKonandeKala> EpTaminKonandeKalas { get; set; }
        public virtual DbSet<R_EpTaminKonandeKala_EpNameKala> R_EpTaminKonandeKala_EpNameKalas { get; set; }



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

            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsUserBepAccessLevelCodingHesabdaris).WithRequired(m => m.MsUser1).HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpAccessLevelCodingHesabdari>().HasMany(m => m.RmsUserBepAccessLevelCodingHesabdaris).WithRequired(m => m.EpAccessLevelCodingHesabdari1).HasForeignKey(m => m.CodingHesabdariId).WillCascadeOnDelete(true);

            modelBuilder.Entity<EpHesabGroup>().HasMany(m => m.EpHesabCols).WithRequired(m => m.EpHesabGroup1).HasForeignKey(m => m.GroupId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabCol>().HasMany(m => m.EpHesabMoins).WithRequired(m => m.EpHesabCol1).HasForeignKey(m => m.ColId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.EpSharhStandardMoins).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.RMsActiveSystemBEpHesabMoins).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MsActiveSystem>().HasMany(m => m.RMsActiveSystemBEpHesabMoins).WithRequired(m => m.MsActiveSystem1).HasForeignKey(m => m.ActiveSystemId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabMoin>().HasMany(m => m.REpHesabMoinBEpGroupTafziliLevel1s).WithRequired(m => m.EpHesabMoin1).HasForeignKey(m => m.MoinId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.REpHesabMoinBEpGroupTafziliLevel1s).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliSandoghs).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliHesabBankis).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliAshkhass).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliDaraehas).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliProjhes).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliVams).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliMavads).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliGhataats).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliMahsols).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliKalas).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliMarakezHazines).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupTafzili>().HasMany(m => m.EpHesabTafziliSayers).WithRequired(m => m.EpGroupTafzili1).HasForeignKey(m => m.GroupTafziliId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupAsliKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKalaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithRequired(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala1Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithOptional(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala2Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpVahedKala>().HasMany(m => m.EpNameKalas).WithOptional(m => m.EpVahedKala1).HasForeignKey(m => m.VahedKala3Id).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpGroupAsliKala>().HasMany(m => m.EpGroupFareeKalas).WithRequired(m => m.EpGroupAsliKala1).HasForeignKey(m => m.GroupAsliId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpGroupFareeKala>().HasMany(m => m.EpNameKalas).WithRequired(m => m.EpGroupFareeKala1).HasForeignKey(m => m.GroupFareeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<EpTaminKonandeKala>().HasMany(m => m.R_EpTaminKonandeKala_EpNameKalas).WithRequired(m => m.EpTaminKonandeKala1).HasForeignKey(m => m.TKId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameKala>().HasMany(m => m.R_EpTaminKonandeKala_EpNameKalas).WithRequired(m => m.EpNameKala1).HasForeignKey(m => m.NKId).WillCascadeOnDelete(false);


            //modelBuilder.Entity<EpHesabTafziliHesabBanki>().HasRequired(m => m.EpNameBank1).WithMany(m=>m.EpHesabTafziliHesabBankis).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafziliHesabBanki>().HasRequired(m => m.EpNoeHesab1).WithMany(m=>m.EpHesabTafziliHesabBankis).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<EpHesabTafziliHesabBanki>().HasRequired(m => m.EpNoeArz1).WithMany(m=>m.EpHesabTafziliHesabBankis).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabTafziliHesabBankis).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNameBank>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpNameBank1).HasForeignKey(m => m.NameBankId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeHesab>().HasMany(m => m.EpHesabTafziliHesabBankis).WithRequired(m => m.EpNoeHesab1).HasForeignKey(m => m.NoeHesaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpNoeArz>().HasMany(m => m.EpHesabTafziliHesabBankis).WithRequired(m => m.EpNoeArz1).HasForeignKey(m => m.NoeArzId).WillCascadeOnDelete(false);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasOptional(m => m.EpMoshakhasat_A1).WithRequired(m => m.EpHesabTafziliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpAdress_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpShTamas_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpEetebarat_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpFazaMajazi_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpHesabBanki_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpDarsadTakhfif_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasOptional(m => m.EpMPersoneli_A1).WithRequired(m => m.EpHesabTafziliAshkhas1).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpSahmSahamdar_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpDarsadVizitor_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
            modelBuilder.Entity<EpHesabTafziliAshkhas>().HasMany(m => m.EpDarsadRanande_As).WithRequired(m => m.EpHesabTafziliAshkhas1).HasForeignKey(m=>m.AshkhasId).WillCascadeOnDelete(true);
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