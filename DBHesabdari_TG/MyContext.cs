﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	MyContext.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:37
*	
***********************************************************************************/
namespace DBHesabdari_TG
{
    using DBHesabdari_TG.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;

    public class MyContext : DbContext
    {
        #region
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Hesabdari_TG_N1_V1.Models.MyContext' database on your LocalDb instance. 
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
            //Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
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
        public virtual DbSet<RmsMajmoehaBmsUserha> RmsMajmoehaBmsUserhas { get; set; }
        public virtual DbSet<MsVahed> MsVaheds { get; set; }
        public virtual DbSet<RmsVahedhaBmsUserha> RmsVahedhaBmsUserhas { get; set; }
        public virtual DbSet<MsShobe> MsShobes { get; set; }
        public virtual DbSet<RmsShobehaBmsUserha> RmsShobehaBmsUserhas { get; set; }
        public virtual DbSet<MsInfoOther> MsInfoOthers { get; set; }




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
            modelBuilder.Entity<MsMajmoe>().HasMany(m => m.RmsMajmoehaBmsUserhas).WithRequired(m => m.MsMajmoe1).HasForeignKey(m => m.MsMajmoeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsMajmoehaBmsUserhas).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<MsVahed>().HasMany(m => m.MsShobes).WithRequired(m => m.MsVahed1).HasForeignKey(m => m.MsVahedId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsVahed>().HasMany(m => m.RmsVahedhaBmsUserhas).WithRequired(m => m.MsVahed1).HasForeignKey(m => m.MsVahedId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsVahedhaBmsUserhas).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<MsShobe>().HasMany(m => m.RmsShobehaBmsUserhas).WithRequired(m => m.MsShobe1).HasForeignKey(m => m.MsShobeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<MsUser>().HasMany(m => m.RmsShobehaBmsUserhas).WithRequired(m => m.MsUser1).HasForeignKey(m => m.MsUserId).WillCascadeOnDelete(false);



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