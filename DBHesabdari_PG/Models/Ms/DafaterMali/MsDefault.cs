/****************************** Ghost.github.io ******************************\
*	Module Name:	MsDefault.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 24   01:09 ب.ظ
*	
***********************************************************************************/
using DBHesabdari_PG.Models.Ms.SystemUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.Ms.DafaterMali
{
   public class MsDefault
    {
        [Key]
        public int MsUserId { get; set; }

        public int MajmoeId { get; set; }

        public int VahedId { get; set; }

        public int ShobeId { get; set; }

        public int DoreMaliId { get; set; }

        public virtual MsUser MsUser1 { get; set; }

    }
}
