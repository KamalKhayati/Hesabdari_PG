/****************************** Ghost.github.io ******************************\
*	Module Name:	MsVahed.cs
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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG
{
   public class MsVahed
    {
        public int MsVahedId { get; set; }
        [Required]
        public int VahedCode { get; set; }
        [Required, MaxLength(50)]
        public string VahedName { get; set; }
        [Required]
        public bool VahedIsActive { get; set; }
        [Required]
        public int MsMajmoeId { get; set; }
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }
        public virtual MsMajmoe MsMajmoe1 { get; set; }
        public virtual ICollection<MsShobe> MsShobes { get; set; }

    }
}
