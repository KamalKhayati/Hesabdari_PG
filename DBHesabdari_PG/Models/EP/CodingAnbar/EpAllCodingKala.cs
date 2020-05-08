using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
   public class EpAllCodingKala
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int KeyCode { get; set; }
        [Required]
        public int ParentCode { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required, MaxLength(100)]
        public string LevelName { get; set; }
        //public int HesabTabaghehId { get; set; }
        //public int HesabGroupId { get; set; }
        // public int HesabColId { get; set; }
        //public int HesabMoinId { get; set; }
        public bool IsActive { get; set; }
        public virtual EpTabaghehKala EpTabaghehKala1 { get; set; }
        public virtual EpGroupAsliKala EpGroupAsliKala1 { get; set; }
        public virtual EpGroupFareeKala EpGroupFareeKala1 { get; set; }
        public virtual EpNameKala EpNameKala1 { get; set; }
    }
}
