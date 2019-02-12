/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabMoin.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 10   14:16
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_TG
{
   public class EpHesabMoin
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required, MaxLength(50)]
        public string GroupName { get; set; }
        [Required]
        public int ColId { get; set; }
        [Required, MaxLength(50)]
        public string ColName { get; set; }
        [Required]
        public int IndexMahiatHesab { get; set; }
        [Required, MaxLength(10)]
        public string MahiatHesab { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpHesabCol EpHesabCol1 { get; set; }
    }
}
