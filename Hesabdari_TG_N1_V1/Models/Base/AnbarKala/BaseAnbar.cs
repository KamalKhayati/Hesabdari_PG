/****************************** Ghost.github.io ******************************\
*	Module Name:	Base_Anbar.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 18   12:47 ق.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hesabdari_TG_N1_V1.Models.Base
{
    public class BaseAnbar
    {
        public int BaseAnbarId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
