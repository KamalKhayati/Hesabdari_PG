/****************************** Ghost.github.io ******************************\
*	Module Name:	MsUser.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_TG
{
    public class MsUser
    {
        public int MsUserId { get; set; }
        [Required]
        public int UserCode { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string UserNam { get; set; }
        [Required, MaxLength(50)]
        public string UserPassword { get; set; }
        [Required]
        public bool UserIsActive { get; set; }
        public virtual ICollection<RmsMajmoehaBmsUserha> RmsMajmoehaBmsUserhas { get; set; }
        public virtual ICollection<RmsVahedhaBmsUserha> RmsVahedhaBmsUserhas { get; set; }
        public virtual ICollection<RmsShobehaBmsUserha> RmsShobehaBmsUserhas { get; set; }

    }
}
