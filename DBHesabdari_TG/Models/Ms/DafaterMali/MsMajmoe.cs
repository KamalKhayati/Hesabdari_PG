﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	MsMajmoe.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 2   02:36
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_TG
{
   public class MsMajmoe
    {
        public int MsMajmoeId { get; set; }
        [Required]
        public int MajmoeCode { get; set; }
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }
        [Required]
        public bool MajmoeIsActive { get; set; }
        public virtual ICollection<MsVahed> MsVaheds { get; set; }

    }
}
