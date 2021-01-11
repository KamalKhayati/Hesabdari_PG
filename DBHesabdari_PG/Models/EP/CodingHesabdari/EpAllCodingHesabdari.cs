/****************************** Ghost.github.io ******************************\
*	Module Name:	MsAccessLevelDafaterMali.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 8   11:41 ق.ظ
*	
***********************************************************************************/
using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.Ms.ActiveSystem;
using DBHesabdari_PG.Models.Ms.SystemUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
    public class EpAllCodingHesabdari
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int KeyCode { get; set; }
        [Required]
        public int ParentCode { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required, MaxLength(70)]
        public string LevelName { get; set; }
        //public int HesabTabaghehId { get; set; }
        //public int HesabGroupId { get; set; }
        // public int HesabColId { get; set; }
        //public int HesabMoinId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<R_MsUser_B_AllCodingHesabdari> RmsUserBallCodingHesabdaris { get; set; }
        public virtual EpHesabTabagheh EpHesabTabagheh1 { get; set; }
        public virtual EpHesabGroup EpHesabGroup1 { get; set; }
        public virtual EpHesabCol EpHesabCol1 { get; set; }
        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        public virtual ICollection<R_EpAllCodingHesabdari_B_MsActiveSystem> R_EpAllCodingHesabdari_B_MsActiveSystems { get; set; }
    }


    public class R_EpAllCodingHesabdari_B_MsActiveSystem
    {
        //[Column(Order = 0)]
        // public int Id { get; set; }
        [Required, Column(Order = 1)]
        public int SalId { get; set; }
        [Key]
        [Required, Column(Order = 2)]
        public int ActiveSystemId { get; set; }
        [Key]
        [Required, Column(Order = 3)]
        public int AllCodingHesabdariId { get; set; }
        //[Required, Column(Order = 4)]
        //public int ActiveSystemCode { get; set; }
        //[Required, Column(Order = 5)]
        //public int MoinCode { get; set; }

        public virtual MsActiveSystem MsActiveSystem1 { get; set; }
        public virtual EpAllCodingHesabdari EpAllCodingHesabdari1 { get; set; }
    }

}
