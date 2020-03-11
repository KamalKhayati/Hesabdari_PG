/****************************** Ghost.github.io ******************************\
*	Module Name:	EpNameBank.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 3 / 5   05:08 ب.ظ
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
    public class EpNameBank
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<EpHesabTafziliHesabBanki> EpHesabTafziliHesabBankis { get; set; }
        public virtual ICollection<EpHesabBanki_A> EpHesabBanki_As { get; set; }

    }
}
