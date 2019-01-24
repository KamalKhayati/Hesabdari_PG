/****************************** Ghost.github.io ******************************\
*	Module Name:	MsDefault.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 24   01:09 ب.ظ
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
   public class MsDefault
    {
        public int Id { get; set; }

        public int MsUserId { get; set; }

        public int MsMajmoeId { get; set; }

        public int MsVahedId { get; set; }

        public int MsShobeId { get; set; }

        public int MsDoreMaliId { get; set; }

    }
}
