/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabTafsiliSandogh.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 25   06:06 ب.ظ
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
    public class EpHesabTafsiliSandogh
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string NameMasol { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }

    }
}
