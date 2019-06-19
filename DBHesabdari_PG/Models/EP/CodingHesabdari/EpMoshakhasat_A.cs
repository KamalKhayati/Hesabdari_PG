/****************************** Ghost.github.io ******************************\
*	Module Name:	EpMoshakhasat_A.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 10   04:44 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG
{
   public class EpMoshakhasat_A
    {
        public int Id { get; set; }
        //[Required]
        //public int GroupTafziliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafziliName { get; set; }
        //[Required]
        //public int AshkhasId { get; set; }
        //[Required]
        //public int AshkhasCode { get; set; }
        //[Required, MaxLength(100)]
        //public string AshkhasName { get; set; }
        [MaxLength(50)]
        public string NameEkhtesar { get; set; }
        [MaxLength(50)]
        public string NoeFaaliat { get; set; }
        [MaxLength(11)]
        public string ShenaseMelli { get; set; }
        [MaxLength(12)]
        public string CodeEghtesadi { get; set; }
        [MaxLength(12)]
        public string ShomareSabt { get; set; }
        //[Required]
        //public bool IsActive { get; set; }
        //public bool IsDefault { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }

    }
}
