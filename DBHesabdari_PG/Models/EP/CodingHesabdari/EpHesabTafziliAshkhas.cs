﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabTafziliAshkhas.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 9   11:35 ق.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafziliAshkhas
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string GroupTafzili { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhEjad { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsPersonel { get; set; }
        public bool IsSahamdar { get; set; }
        public bool IsVizitor { get; set; }
        public bool IsRanande { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        public virtual EpGroupTafzili EpGroupTafzili1 { get; set; }
        public virtual EpMoshakhasat_A EpMoshakhasat_A1 { get; set; }
        public virtual ICollection<EpAdress_A> EpAdress_As { get; set; }
        public virtual ICollection<EpShTamas_A> EpShTamas_As { get; set; }
        public virtual ICollection<EpEetebarat_A> EpEetebarat_As { get; set; }
        public virtual ICollection<EpFazaMajazi_A> EpFazaMajazi_As { get; set; }
        public virtual ICollection<EpHesabBanki_A> EpHesabBanki_As { get; set; }
        public virtual ICollection<EpDarsadTakhfif_A> EpDarsadTakhfif_As { get; set; }
        public virtual EpMPersoneli_A EpMPersoneli_A1 { get; set; }
        public virtual ICollection<EpSahmSahamdar_A> EpSahmSahamdar_As { get; set; }
        public virtual ICollection<EpDarsadVizitor_A> EpDarsadVizitor_As { get; set; }
        public virtual ICollection<EpDarsadRanande_A> EpDarsadRanande_As { get; set; }

    }
}
