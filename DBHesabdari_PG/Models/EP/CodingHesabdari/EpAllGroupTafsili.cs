using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
  public  class EpAllGroupTafsili
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required]
        public int KeyCode { get; set; }
        [Required]
        public int ParentCode { get; set; }
        [Required, MaxLength(50)]
        public string LevelName { get; set; }
        [Required]
        public int TabaghehGroupIndex { get; set; }
        [Required, MaxLength(50)]
        public string TabaghehGroupName { get; set; }
        //[Required]
        //public int TabaghehIndex { get; set; }
        //[Required]
        //public int Level1Id { get; set; }
        //[Required]
        //public int Level2Id { get; set; }
        //[Required]
        //public int Level3Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //[MaxLength(500)]
        //public string SharhHesab { get; set; }
        public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }
        public virtual EpGroupTafsiliLevel2 EpGroupTafsiliLevel2 { get; set; }
        public virtual EpGroupTafsiliLevel3 EpGroupTafsiliLevel3 { get; set; }
        public virtual ICollection<REpAllCodingHesabdariBEpAllGroupTafsili> REpAllCodingHesabdariBEpAllGroupTafsilis { get; set; }
        public virtual ICollection<EpAllHesabTafsili> EpAllHesabTafsilis { get; set; }

    }
}
