/****************************** Ghost.github.io ******************************\
*	Module Name:	EpGroupTafsiliLevel1.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 19   06:20 ب.ظ
*	
***********************************************************************************/
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpGroupTafsiliLevel1
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int StartCode { get; set; }
        [Required]
        public int EndCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual ICollection<REpHesabMoinBEpGroupTafsiliLevel1> REpHesabMoinBEpGroupTafsiliLevel1s { get; set; }
        public virtual ICollection<EpHesabTafsiliSandogh> EpHesabTafsiliSandoghs { get; set; }
        public virtual ICollection<EpHesabTafsiliHesabBanki> EpHesabTafsiliHesabBankis { get; set; }
        public virtual ICollection<EpHesabTafsiliAshkhas> EpHesabTafsiliAshkhass { get; set; }
        public virtual ICollection<EpHesabTafsiliDaraeha> EpHesabTafsiliDaraehas { get; set; }
        public virtual ICollection<EpHesabTafsiliProjhe> EpHesabTafsiliProjhes { get; set; }
        public virtual ICollection<EpHesabTafsiliVam> EpHesabTafsiliVams { get; set; }
        public virtual ICollection<EpHesabTafsiliMavad> EpHesabTafsiliMavads { get; set; }
        public virtual ICollection<EpHesabTafsiliGhataat> EpHesabTafsiliGhataats { get; set; }
        public virtual ICollection<EpHesabTafsiliMahsol> EpHesabTafsiliMahsols { get; set; }
        public virtual ICollection<EpHesabTafsiliKala> EpHesabTafsiliKalas { get; set; }
        public virtual ICollection<EpHesabTafsiliMarakezHazine> EpHesabTafsiliMarakezHazines { get; set; }
        public virtual ICollection<EpHesabTafsiliSayer> EpHesabTafsiliSayers { get; set; }
        public virtual ICollection<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }

        public virtual ICollection<EpGroupTafsiliLevel2> EpGroupTafsiliLevel2s { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsilis { get; set; }

    }
}
