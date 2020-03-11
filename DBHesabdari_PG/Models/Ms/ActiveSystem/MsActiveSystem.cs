/****************************** Ghost.github.io ******************************\
*	Module Name:	MsActiveSystem.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 18   10:54 ق.ظ
*	
***********************************************************************************/
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.Ms.ActiveSystem
{
    public class MsActiveSystem
    {
        public int Id { get; set; }
        //[Required]
        //public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<RMsActiveSystemBEpHesabMoin> RMsActiveSystemBEpHesabMoins { get; set; }

    }

    public class RMsActiveSystemBEpHesabMoin
    {
        //[Column(Order = 0)]
       // public int Id { get; set; }
        [Required, Column(Order = 1)]
        public int SalId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ActiveSystemId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int MoinId { get; set; }
        [Required, Column(Order = 4)]
        public int ActiveSystemCode { get; set; }
        [Required, Column(Order = 5)]
        public int MoinCode { get; set; }

        public virtual MsActiveSystem MsActiveSystem1 { get; set; }
        public virtual EpHesabMoin EpHesabMoin1 { get; set; }
    }

}
