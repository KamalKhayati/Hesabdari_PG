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
        public virtual ICollection<RmsUserBmsAccessLevelMenu> RmsUserBmsAccessLevelMenus { get; set; }
        public virtual ICollection<RmsUserBmsAccessLevelDafaterMali> RmsUserBmsAccessLevelDafaterMalis { get; set; }
        public virtual ICollection<RmsUserBallCodingHesabdari> RmsUserBallCodingHesabdaris { get; set; }
    }

    public class RmsUserBallCodingHesabdari
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
        public int KeyId { get; set; }
        [Required]
        [Column(Order = 4)]
        public int TabaghebandiHesabhaId { get; set; }
        [Required]
        [Column(Order = 5)]
        public int HesabGroupId { get; set; }
        [Required]
        [Column(Order = 6)]
        public int HesabColId { get; set; }
        [Required]
        [Column(Order = 7)]
        public int HesabMoinId { get; set; }
        [Required]
        [Column(Order = 8)]
        public bool IsActive { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual AllCodingHesabdari AllCodingHesabdari1 { get; set; }
    }

    public class RmsUserBmsAccessLevelMenu
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
    public class RmsUserBmsAccessLevelDafaterMali
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

}
