/****************************** Ghost.github.io ******************************\
*	Module Name:	EpHesabMoin.cs
*	Project:		DBHesabdari_PG
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 2 / 10   14:16
*	
***********************************************************************************/
using DBHesabdari_PG.Models.AK;
using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.FK;
using DBHesabdari_PG.Models.FK.Tanzimat;
using DBHesabdari_PG.Models.Ms.ActiveSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
    public class EpHesabMoin1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [Required]
        public int GroupTafsiliLevelsIndex { get; set; }
        [Required, MaxLength(20)]
        public string GroupTafsiliLevelsName { get; set; }
        //[Required]
        //public int GroupId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupName { get; set; }
        [Required]
        public int ColId { get; set; }
        //[Required, MaxLength(50)]
        //public string ColName { get; set; }
        [Required]
        public int IndexMahiatHesab { get; set; }
        [Required, MaxLength(30)]
        public string MahiatHesab { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [MaxLength(1000)]
        public string SelectedGroupTafsiliLevels { get; set; }
        [MaxLength(500)]
        public string SelectedActivesystem { get; set; }

        public virtual EpHesabCol EpHesabCol1 { get; set; }
        public virtual EpAllCodingHesabdari EpAllCodingHesabdari1 { get; set; }
        public virtual ICollection<EpSharhStandardMoin> EpSharhStandardMoins { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Rizs { get; set; }
        public virtual ICollection<AKAmaliatAnbarVKala_Riz> AKAmaliatAnbarVKala_Rizs { get; set; }
        //public virtual ICollection<AkKhorojeKala_Riz> AkKhorojeKala_Rizs { get; set; }
        //public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozanehs { get; set; }
        public virtual ICollection<EpListAnbarha> EpListAnbarhas { get; set; }
        public virtual ICollection<R_EpHesabMoin1_B_EpAllGroupTafsili> R_EpHesabMoin1_B_EpAllGroupTafsilis { get; set; }
        public virtual ICollection<FKTanzimatFactor> FKTanzimatFactors { get; set; }
    }

    public class R_EpHesabMoin1_B_EpAllGroupTafsili
    {
        //[Column(Order = 0)]
        // public int Id { get; set; }
        [Required, Column(Order = 0)]
        public int SalId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public int EpHesabMoin1Id { get; set; }
        [Key]
        [Required, Column(Order = 2)]
        public int AllGroupTafsiliId { get; set; }
        [Required, Column(Order = 3)]
        public int LevelNumber { get; set; }

        //[Required, Column(Order = 3)]
        //public int NumberLevel { get; set; }
        //[Required, Column(Order = 4)]
        //public int MoinCode { get; set; }
        //[Required, Column(Order = 4)]
        //public int GroupTafsiliCode { get; set; }

        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsili1 { get; set; }

    }

}
