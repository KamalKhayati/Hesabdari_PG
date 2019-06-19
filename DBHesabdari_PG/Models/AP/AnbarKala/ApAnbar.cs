/****************************** Ghost.github.io ******************************\
*	Module Name:	ApAnbar.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:36
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG
{
    public class ApAnbar
    {
        public int ApAnbarId { get; set; }
        [Required]
        public int AnbarCode { get; set; }
        [Required, MaxLength(50)]
        public string AnbarName { get; set; }
        [Required]
        public bool AnbarIsActive { get; set; }
    }
}
