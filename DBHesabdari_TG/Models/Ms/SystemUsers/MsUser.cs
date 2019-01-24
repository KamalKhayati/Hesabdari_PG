/****************************** Ghost.github.io ******************************\
*	Module Name:	MsUser.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:36
*	
***********************************************************************************/
using DBHesabdari_TG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_TG
{
    public class MsUser
    {
        public int MsUserId { get; set; }
        [Required]
        public int UserCode { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public bool UserIsActive { get; set; }
        public virtual ICollection<RmsUserhaBmsAccessLevel1ha> RmsUserhaBmsAccessLevel1has { get; set; }

        public virtual ICollection<RmsUserhaBmsMajmoeha> RmsUserhaBmsMajmoehas { get; set; }
        public virtual ICollection<RmsUserhaBmsVahedha> RmsUserhaBmsVahedhas { get; set; }
        public virtual ICollection<RmsUserhaBmsShobeha> RmsUserhaBmsShobehas { get; set; }
        public virtual ICollection<RmsUserhaBmsDorehaiMali> RmsUserhaBmsDorehaiMalis { get; set; }

    }

    public class RmsUserhaBmsAccessLevel1ha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsAccessLevel1Id { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string LevelName { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual MsAccessLevel1 MsAccessLeve11 { get; set; }
    }
    public class RmsUserhaBmsMajmoeha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsMajmoeId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual MsMajmoe MsMajmoe1 { get; set; }

        #region
        //internal class Configuration : EntityTypeConfiguration<RmsUserhaBmsMajmoeha>
        //{
        //public Configuration()
        //{
        //    Property(s => s.MsMajmoeId)
        //        .HasColumnOrder(3);
        //    Property(s => s.MsUserId)
        //        .HasColumnOrder(2);

        //ToTable("Standard3")
        //    .HasKey(s => s.StandardId)
        //    .HasMany(c => c.Student)
        //    .WithRequired(s => s.Standard)
        //    .WillCascadeOnDelete();
        //Property(s => s.StandardId)
        //    .HasColumnName("StandardID")
        //    .HasColumnOrder(0)
        //    .HasColumnType("int")
        //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
        //    .IsRequired();
        //Property(s => s.StandardName)
        //    .HasColumnName("StandardName")
        //    .HasColumnOrder(1)
        //    .HasColumnType("nvarchar")
        //    .HasMaxLength(100)
        //    .IsRequired()
        //    .IsUnicode()
        //    .IsVariableLength();
        //Property(s => s.Discription1)
        //    .HasColumnName("Disc1")
        //    .HasColumnOrder(2)
        //    .HasColumnType("nvarchar")
        //    .HasMaxLength(100)
        //    .IsOptional()
        //    .IsUnicode()
        //    .IsVariableLength();
        //Property(s => s.Discription3)
        //    .HasColumnName("Disc3")
        //    .HasColumnOrder(3)
        //    .HasColumnType("nvarchar")
        //    .HasMaxLength(100)
        //    .IsOptional()
        //    .IsUnicode()
        //    .IsVariableLength();
        //}
        //}
        #endregion
    }
    public class RmsUserhaBmsVahedha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsVahedId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string VahedName { get; set; }

        public virtual MsVahed MsVahed1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }
    }
    public class RmsUserhaBmsShobeha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsShobeId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string ShobeName { get; set; }

        public virtual MsShobe MsShobe1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }


    }
    public class RmsUserhaBmsDorehaiMali
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsDoreMaliId { get; set; }

        [Column(Order = 4)]
        [Required]
        public int DoreMali { get; set; }

        public virtual MsDoreMali MsDoreMali1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }

    }
}
