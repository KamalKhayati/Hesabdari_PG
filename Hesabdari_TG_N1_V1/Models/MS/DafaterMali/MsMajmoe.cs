/****************************** Ghost.github.io ******************************\
*	Module Name:	MsMajmoeha.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 21   03:08 ب.ظ
*	
***********************************************************************************/
using Hesabdari_TG_N1_V1.Models.MS.UsersSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabdari_TG_N1_V1.Models.MS.DafaterMali
{
    public class MsMajmoe
    {
        public int MsMajmoeId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<RmsUserhaBmsMajmoeha> RmsUserhaBmsMajmoehas { get; set; }

    }

    public class RmsUserhaBmsMajmoeha
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MsUserId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int MsMajmoeId { get; set; }

        public virtual MsUser MsUser1 { get; set; }
        public virtual MsMajmoe MsMajmoe1 { get; set; }

    }
}
