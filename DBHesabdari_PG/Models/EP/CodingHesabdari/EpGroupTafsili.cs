/****************************** Ghost.github.io ******************************\
*	Module Name:	EpGroupTafsili.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 19   06:20 ب.ظ
*	
***********************************************************************************/
using DBHesabdari_PG.Models.EP.CodingAnbar;
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
   public class EpGroupTafsili
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [Required]
        public int TabaghehIndex { get; set; }
        [Required, MaxLength(30)]
        public string TabaghehName { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long StartCode { get; set; }
        [Required]
        public long EndCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int Level1Id { get; set; }
        [Required]
        public int Level2Id { get; set; }

        // public virtual ICollection<REpHesabMoinBEpAllGroupTafsili> REpHesabMoinBEpGroupTafsilis { get; set; }
        // public virtual ICollection<EpHesabTafsiliSandogh> EpHesabTafsiliSandoghs { get; set; }
        //  public virtual ICollection<EpHesabTafsiliHesabBanki> EpHesabTafsiliHesabBankis { get; set; }
        //  public virtual ICollection<EpHesabTafsiliAshkhas> EpHesabTafsiliAshkhass { get; set; }
        //  public virtual ICollection<EpHesabTafsiliDaraeha> EpHesabTafsiliDaraehas { get; set; }
        //  public virtual ICollection<EpHesabTafsiliProjhe> EpHesabTafsiliProjhes { get; set; }
        //   public virtual ICollection<EpHesabTafsiliVam> EpHesabTafsiliVams { get; set; }
        //  public virtual ICollection<EpHesabTafsiliMavad> EpHesabTafsiliMavads { get; set; }
        //   public virtual ICollection<EpHesabTafsiliGhataat> EpHesabTafsiliGhataats { get; set; }
        //  public virtual ICollection<EpHesabTafsiliMahsol> EpHesabTafsiliMahsols { get; set; }
        // public virtual ICollection<EpHesabTafsiliKala> EpHesabTafsiliKalas { get; set; }
        //  public virtual ICollection<EpHesabTafsiliMarakezHazine> EpHesabTafsiliMarakezHazines { get; set; }
        //  public virtual ICollection<EpHesabTafsiliSayer> EpHesabTafsiliSayers { get; set; }
        //   public virtual ICollection<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }

        public virtual ICollection<EpTabaghehKala> EpTabaghehKalas { get; set; }
        //public virtual ICollection<EpGroupTafsiliLevel2> EpGroupTafsiliLevel2s { get; set; }
        public virtual ICollection<R_EpHesabMoin1_B_EpGroupTafsili> R_EpHesabMoin1_B_EpGroupTafsilis { get; set; }
        //public virtual EpAllGroupTafsili EpAllGroupTafsili1 { get; set; }
        public virtual ICollection<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }
    }
}
