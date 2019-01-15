/****************************** Ghost.github.io ******************************\
*	Module Name:	MsInfoOther.cs
*	Project:		DBHesabdari_TG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 3   10:20 ق.ظ
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
   public class MsInfoOther
    {
        public int Id { get; set; }
        public int? MsMajmoeId { get; set; }
        public int? MsVahedId { get; set; }
        public int? MsShobeId { get; set; }
        public int? MsCode { get; set; }
        [MaxLength(50)]
        public string MsName { get; set; }
        public string NoeShakhs { get; set; }
        [MaxLength(50)]
        public string NoeFaaliat { get; set; }
        [MaxLength(300)]
        public string Adress { get; set; }
        [MaxLength(50)]
        public string CodePosti { get; set; }
        [MaxLength(50)]
        public string SandoghPosti { get; set; }
        [MaxLength(50)]
        public string ShomarePlak { get; set; }
        [MaxLength(50)]
        public string ShomareSabt { get; set; }
        [MaxLength(50)]
        public string CodeMelli { get; set; }
        [MaxLength(50)]
        public string ShenaseMelli { get; set; }
        [MaxLength(50)]
        public string CodeSenfee { get; set; }
        [MaxLength(50)]
        public string CodeEghtesadi { get; set; }
        [MaxLength(50)]
        public string Tell1 { get; set; }
        [MaxLength(50)]
        public string Tell2 { get; set; }
        [MaxLength(50)]
        public string TellFax1 { get; set; }
        [MaxLength(50)]
        public string TellFax2 { get; set; }
        [MaxLength(50)]
        public string Mobile1 { get; set; }
        [MaxLength(50)]
        public string Mobile2 { get; set; }
        [MaxLength(50)]
        public string Email1 { get; set; }
        [MaxLength(50)]
        public string Email2 { get; set; }
        [MaxLength(50)]
        public string Site { get; set; }
        [MaxLength(50)]
        public string WebLog { get; set; }
        [MaxLength(50)]
        public string ShabakeEjtemaee1 { get; set; }
        [MaxLength(50)] 
        public string ShabakeEjtemaee2 { get; set; }
        [MaxLength(50)]
        public string ShParvandeMaliati { get; set; }
        [MaxLength(50)]
        public string ShBimeKargah { get; set; }

    }
}
