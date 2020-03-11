/****************************** Ghost.github.io ******************************\
*	Module Name:	SharhMoin.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 17   12:46 ب.ظ
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
    public class EpSharhStandardMoin
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        //public int Code { get; set; }
        [Required, MaxLength(500)]
        public string Name { get; set; }
        [Required]
        public int MoinId { get; set; }
        [Required]
        public int MoinCode { get; set; }
        public virtual EpHesabMoin EpHesabMoin1 { get; set; }

    }
}
