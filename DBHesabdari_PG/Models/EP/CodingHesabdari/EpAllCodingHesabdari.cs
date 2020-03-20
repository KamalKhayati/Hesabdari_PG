/****************************** Ghost.github.io ******************************\
*	Module Name:	MsAccessLevelDafaterMali.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 8   11:41 ق.ظ
*	
***********************************************************************************/
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
        public int KeyId { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required, MaxLength(50)]
        public string LevelName { get; set; }
        public int TabaghebandiHesabhaId { get; set; }
        public int HesabGroupId { get; set; }
        public int HesabColId { get; set; }
        public int HesabMoinId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<RmsUserBallCodingHesabdari> RmsUserBallCodingHesabdaris { get; set; }
        public virtual EpHesabTabagheh EpTabaghebandiHesabha1 { get; set; }
        public virtual EpHesabGroup EpHesabGroup1 { get; set; }

    }
}
