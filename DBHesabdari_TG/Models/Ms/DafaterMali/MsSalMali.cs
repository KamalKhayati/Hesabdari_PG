/****************************** Ghost.github.io ******************************\
*	Module Name:	MsSalMali.cs
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
   public class MsSalMali
    {
        public int MsSalMaliId { get; set; }
        [Required]
        public int SalMaliCode { get; set; }
        [Required, MaxLength(50)]
        public string SalMali { get; set; }
        [Required, Column(TypeName = "Date")]
        public DateTime StartSalMali { get; set; }
        [Required,Column(TypeName = "Date")]
        public DateTime EndSalMali { get; set; }
        [Required]
        public bool SalMaliIsActive { get; set; }
        [Required]
        public bool SalIsDefault { get; set; }
        [Required]
        public bool SalIsClose { get; set; }
        public decimal? Maliat { get; set; }
        public decimal? Avarez { get; set; }
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
        public virtual ICollection<RmsSalMalihaBmsUserha> RmsSalMalihaBmsUserhas { get; set; }
    }

    public class RmsSalMalihaBmsUserha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MsSalMaliId { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(50)]
        public string SalMali { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MsUserId { get; set; }

        [Column(Order = 4)]
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Column(Order = 5)]
        public int MsMajmoeId { get; set; }

        [Column(Order = 6)]
        public int MsVahedId { get; set; }

        [Column(Order = 7)]
        public int MsShobeId { get; set; }

        public virtual MsSalMali MsSalMali1 { get; set; }
        public virtual MsUser MsUser1 { get; set; }

    }
}
