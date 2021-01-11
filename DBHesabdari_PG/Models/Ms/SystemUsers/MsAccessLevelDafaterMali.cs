/****************************** Ghost.github.io ******************************\
*	Module Name:	MsAccessLevelDafaterMali.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 26   11:47 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.Ms.SystemUsers
{
   public class MsAccessLevelDafaterMali
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsAccessLevelDafaterMaliId { get; set; }
        [Required]
        public int KeyId { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required,MaxLength(50)]
        public string LevelName { get; set; }
        public int MajmoeId { get; set; }
        public int VahedId { get; set; }
        public int ShobeId { get; set; }
        public int DoreMaliId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<R_MsUser_B_MsAccessLevelDafaterMali> RmsUserBmsAccessLevelDafaterMalis { get; set; }

    }
}
