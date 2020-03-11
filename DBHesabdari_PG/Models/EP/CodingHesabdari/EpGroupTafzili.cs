/****************************** Ghost.github.io ******************************\
*	Module Name:	EpGroupTafzili.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpGroupTafzili
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual ICollection<REpHesabMoinBEpGroupTafziliLevel1> REpHesabMoinBEpGroupTafziliLevel1s { get; set; }
        public virtual ICollection<EpHesabTafziliSandogh> EpHesabTafziliSandoghs { get; set; }
        public virtual ICollection<EpHesabTafziliHesabBanki> EpHesabTafziliHesabBankis { get; set; }
        public virtual ICollection<EpHesabTafziliAshkhas> EpHesabTafziliAshkhass { get; set; }
        public virtual ICollection<EpHesabTafziliDaraeha> EpHesabTafziliDaraehas { get; set; }
        public virtual ICollection<EpHesabTafziliProjhe> EpHesabTafziliProjhes { get; set; }
        public virtual ICollection<EpHesabTafziliVam> EpHesabTafziliVams { get; set; }
        public virtual ICollection<EpHesabTafziliMavad> EpHesabTafziliMavads { get; set; }
        public virtual ICollection<EpHesabTafziliGhataat> EpHesabTafziliGhataats { get; set; }
        public virtual ICollection<EpHesabTafziliMahsol> EpHesabTafziliMahsols { get; set; }
        public virtual ICollection<EpHesabTafziliKala> EpHesabTafziliKalas { get; set; }
        public virtual ICollection<EpHesabTafziliMarakezHazine> EpHesabTafziliMarakezHazines { get; set; }
        public virtual ICollection<EpHesabTafziliSayer> EpHesabTafziliSayers { get; set; }
        public virtual ICollection<EpAllHesabTafzili> EpAllHesabTafzilis { get; set; }

    }
}
