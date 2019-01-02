/****************************** Ghost.github.io ******************************\
*	Module Name:	MsShobe.cs
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
   public class MsShobe
    {
        public int MsShobeId { get; set; }
        [Required]
        public int ShobeCode { get; set; }
        [Required, MaxLength(50)]
        public string ShobeName { get; set; }
        [Required]
        public bool ShobeIsActive { get; set; }
        [Required]
        public int MsMajmoeId { get; set; }
        [Required, MaxLength(50)]
        public string MajmoeName { get; set; }
        [Required]
        public int MsVahedId { get; set; }
        [Required, MaxLength(50)]
        public string VahedName { get; set; }
        public virtual MsVahed MsVahed1 { get; set; }
        public string PermissiveUsers { get; set; }
        public virtual ICollection<RmsShobehaBmsUserha> RmsShobehaBmsUserhas { get; set; }

    }

    public class RmsShobehaBmsUserha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsShobeId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string ShobeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsUserId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        public virtual MsShobe MsShobe1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }


    }
}
