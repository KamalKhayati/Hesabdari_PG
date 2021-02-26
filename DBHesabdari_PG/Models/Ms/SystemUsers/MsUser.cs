/****************************** Ghost.github.io ******************************\
*	Module Name:	MsUser.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:36
*	
***********************************************************************************/
using DBHesabdari_PG;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DBHesabdari_PG.Models.Ms.DafaterMali;
using DBHesabdari_PG.Models.Tz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.Ms.SystemUsers
{
    public class MsUser
    {
        public int MsUserId { get; set; }
        [Required]
        public int UserCode { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Shenase { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public bool UserIsActive { get; set; }

        public virtual MsDefault MsDefault1 { get; set; }
        public virtual ICollection<R_MsUser_B_MsAccessLevelMenu> R_MsUser_B_MsAccessLevelMenus { get; set; }
        public virtual ICollection<R_MsUser_B_MsAccessLevelDafaterMali> R_MsUser_B_MsAccessLevelDafaterMalis { get; set; }
        public virtual ICollection<R_MsUser_B_AllCodingHesabdari> R_MsUser_B_AllCodingHesabdaris { get; set; }
        public virtual ICollection<R_MsUser_B_TzTanzimatSystem> R_MsUser_B_TzTanzimatSystems { get; set; }
    }

    public class R_MsUser_B_AllCodingHesabdari
    {
        [Required]
        [Column(Order = 0)]
        public int SalId { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public int CodingHesabdariId { get; set; }
        [Required]
        [Column(Order = 3)]
        public int KeyCode { get; set; }
        //[Required]
        //[Column(Order = 4)]
        //public int HesabTabaghehId { get; set; }
        //[Required]
        //[Column(Order = 5)]
        //public int HesabGroupId { get; set; }
        //[Required]
        //[Column(Order = 6)]
        //public int HesabColId { get; set; }
        //[Required]
        //[Column(Order = 7)]
        //public int HesabMoinId { get; set; }
        [Required]
        [Column(Order = 4)]
        public bool IsActive { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual EpAllCodingHesabdari EpAllCodingHesabdari1 { get; set; }
    }

    public class R_MsUser_B_MsAccessLevelMenu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsAccessLevelMenuId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string LevelName { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual MsAccessLevelMenu MsAccessLevelMenu1 { get; set; }
    }

    public class R_MsUser_B_MsAccessLevelDafaterMali
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsAccessLevelDafaterMaliId { get; set; }
        [Column(Order = 4)]
        public int KeyId { get; set; }
        [Column(Order = 5)]
        public int MajmoeId { get; set; }
        [Column(Order = 6)]
        public int VahedId { get; set; }
        [Column(Order = 7)]
        public int ShobeId { get; set; }
        [Column(Order = 8)]
        public int DoreMaliId { get; set; }
        [Column(Order = 9)]
        public bool IsActive { get; set; }


        public virtual MsUser MsUser1 { get; set; }
        public virtual MsAccessLevelDafaterMali MsAccessLevelDafaterMali1 { get; set; }
    }

    public class R_MsUser_B_TzTanzimatSystem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsUserId { get; set; }

        //[Column(Order = 2)]
        //[Required, MaxLength(50)]
        //public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TanzimatSystemId { get; set; }

        //[Column(Order = 3)]
        //[Required, MaxLength(500)]
        //public string LevelName { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual TzTanzimatSystem TzTanzimatSystem1 { get; set; }
    }

}
