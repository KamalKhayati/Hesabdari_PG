﻿/****************************** Ghost.github.io ******************************\
*	Module Name:	MsVahed.cs
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
        public string PermissiveUsers { get; set; }
        public virtual ICollection<RmsVahedhaBmsUserha> RmsVahedhaBmsUserhas { get; set; }
        public virtual ICollection<MsShobe> MsShobes { get; set; }

    }

    public class RmsVahedhaBmsUserha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsVahedId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string VahedName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsUserId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        public virtual MsVahed MsVahed1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }
    }
}
