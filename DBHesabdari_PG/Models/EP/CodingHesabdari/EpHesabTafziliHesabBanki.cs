/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabTafziliHesabBanki.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 5   10:38 ق.ظ
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
   public class EpHesabTafziliHesabBanki
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(40)]
        public string NameBank { get; set; }
        [Required, MaxLength(40)]
        public string NameShobe { get; set; }
        [MaxLength(40)]
        public string CodeShobe { get; set; }
        [Required, MaxLength(40)]
        public string NoeHesab { get; set; }
        [Required, MaxLength(40)]
        public string ShomareHesab { get; set; }
        [MaxLength(40)]
        public string ShomareKart { get; set; }
        [MaxLength(40)]
        public string ShomareShaba { get; set; }
        [MaxLength(40)]
        public string ShomareMoshtari { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Required, MaxLength(40)]
        public string NoeArz { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        public virtual EpGroupTafzili EpGroupTafzili1 { get; set; }
        [Required]
        public int NameBankId { get; set; }
        public virtual EpNameBank EpNameBank1 { get; set; }
        [Required]
        public int NoeHesaId { get; set; }
        public virtual EpNoeHesab EpNoeHesab1 { get; set; }
        [Required]
        public int NoeArzId { get; set; }
        public virtual EpNoeArz EpNoeArz1 { get; set; }
        public virtual EpAllHesabTafzili EpAllHesabTafzili1 { get; set; }

    }
}
