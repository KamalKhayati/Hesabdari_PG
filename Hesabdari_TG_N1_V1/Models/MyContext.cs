/****************************** Ghost.github.io ******************************\
*	Module Name:	MyContext.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 13   03:44 Þ.Ù
*	
***********************************************************************************/
namespace Hesabdari_TG_N1_V1.Models
{
    using Hesabdari_TG_N1_V1.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;

    public class MyContext : DbContext
    {
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Hesabdari_TG_N1_V1.Models.MyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyContext' 
        // connection string in the application configuration file.
        public MyContext()
            : base("name=MyContext")
        {
            Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            SqlConnection.ClearAllPools();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}