using DBHesabdari_PG.Models.AK;
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
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public long KeyCode { get; set; }
        [Required]
        public long ParentCode { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required, MaxLength(100)]
        public string LevelName { get; set; }
        //public int HesabTabaghehId { get; set; }
        //public int HesabGroupId { get; set; }
        // public int HesabColId { get; set; }
        //public int HesabMoinId { get; set; }
        [Required]
        public int VahedAsliKalaId { get; set; }
        //[Required, MaxLength(50)]
        //public string VahedAsliName { get; set; }
        public bool IsActive { get; set; }
        public virtual EpTabaghehKala EpTabaghehKala1 { get; set; }
        public virtual EpGroupAsliKala EpGroupAsliKala1 { get; set; }
        public virtual EpGroupFareeKala EpGroupFareeKala1 { get; set; }
        public virtual EpNameKala EpNameKala1 { get; set; }
        public virtual EpVahedKala EpVahedAsliKala { get; set; }
    }
}
