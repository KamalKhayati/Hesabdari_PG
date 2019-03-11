/****************************** Ghost.github.io ******************************\
*	Module Name:	EpAdress_A.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 10   07:10 ب.ظ
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
   public class EpAdress_A
    {
        public int Id { get; set; }
        //[Required]
        //public int GroupTafziliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafziliName { get; set; }
        [Required]
        public int AshkhasId { get; set; }
        //[Required]
        //public int AshkhasCode { get; set; }
        //[Required, MaxLength(100)]
        //public string AshkhasName { get; set; }
        [MaxLength(50)]
        public string Adress { get; set; }
        [MaxLength(50)]
        public string Ostan { get; set; }
        [MaxLength(50)]
        public string Shahrstan { get; set; }
        [MaxLength(400)]
        public string SharhAdress { get; set; }
        [MaxLength(12)]
        public string CodePosti { get; set; }
        [MaxLength(12)]
        public string SandoghPosti { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(400)]
        public string SharhHesab { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }
    }
}
