/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabCol.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 9   07:13 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabCol
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TabaghehId { get; set; }
        [Required, MaxLength(50)]
        public string TabaghehName { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required, MaxLength(50)]
        public string GroupName { get; set; }
        [Required]
        public int IndexMahiatHesab { get; set; }
        [Required, MaxLength(20)]
        public string MahiatHesab { get; set; }
        [Required]
        public int IndexNoeHesab { get; set; }
        [Required, MaxLength(20)]
        public string NoeHesab { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpAllCodingHesabdari EpAllCodingHesabdari1 { get; set; }
        public virtual EpHesabGroup EpHesabGroup1 { get; set; }
        public virtual ICollection<EpHesabMoin> EpHesabMoins { get; set; }

    }
}
