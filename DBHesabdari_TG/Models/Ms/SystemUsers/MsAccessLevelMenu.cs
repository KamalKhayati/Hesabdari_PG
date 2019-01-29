/****************************** Ghost.github.io ******************************\
*	Module Name:	AccessLevel.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 12   02:25 ب.ظ
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
   public class MsAccessLevelMenu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MsAccessLevelMenuId { get; set; }
        [Required]
        public int ParentId { get; set; }
        public string LevelName { get; set; }
        public virtual ICollection<RmsUserBmsAccessLevelMenu> RmsUserhaBmsAccessLevelMenuhas { get; set; }

    }
}
