/****************************** Ghost.github.io ******************************\
*	Module Name:	MsDoreMali.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 5   05:38 ب.ظ
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
   public class MsDoreMali
    {
        public int MsDoreMaliId { get; set; }
        [Required]
        public int DoreMaliCode { get; set; }
        [Required]
        public int DoreMali { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime StartDoreMali { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime EndDoreMali { get; set; }
        [Required]
        public bool DoreMaliIsActive { get; set; }
        public bool IsDefault { get; set; }
        public bool DoreIsClose { get; set; }
        public float Maliat { get; set; }
        public float Avarez { get; set; }
        [Required]
        public int MsMajmoeId { get; set; }
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }
        [Required]
        public int MsVahedId { get; set; }
        [Required, MaxLength(50)]
        public string VahedName { get; set; }
        [Required]
        public int MsShobeId { get; set; }
        [Required, MaxLength(50)]
        public string ShobeName { get; set; }
        public virtual MsShobe MsShobe1 { get; set; }
        public string PermissiveUsers { get; set; }
        public virtual ICollection<RmsUserhaBmsDorehaiMali> RmsUserhaBmsDorehaiMalis { get; set; }
    }

}
