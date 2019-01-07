/****************************** Ghost.github.io ******************************\
*	Module Name:	MsMajmoe.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:36
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_TG
{
   public class MsMajmoe
    {
        public int MsMajmoeId { get; set; }
        [Required]
        public int MajmoeCode { get; set; }
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }
        [Required]
        public bool MajmoeIsActive { get; set; }
        public bool MajmoeIsDefault { get; set; }
        public string PermissiveUsers { get; set; }
        public virtual ICollection<RmsMajmoehaBmsUserha> RmsMajmoehaBmsUserhas { get; set; }
        public virtual ICollection<MsVahed> MsVaheds { get; set; }

    }

    public class RmsMajmoehaBmsUserha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsMajmoeId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsUserId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual MsMajmoe MsMajmoe1 { get; set; }

        //internal class Configuration : EntityTypeConfiguration<RmsUserhaBmsMajmoeha>
        //{
        //public Configuration()
        //{
        //    Property(s => s.MsMajmoeId)
        //        .HasColumnOrder(3);
        //    Property(s => s.MsUserId)
        //        .HasColumnOrder(2);

        #region
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
        #endregion
        //}
        //}
    }
}
