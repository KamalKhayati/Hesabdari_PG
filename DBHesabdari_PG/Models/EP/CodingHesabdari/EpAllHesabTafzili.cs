using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpAllHesabTafzili
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        //[Required]
        //public int SandoghId { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
        public virtual EpGroupTafzili EpGroupTafzili1 { get; set; }
        public virtual EpHesabTafziliSandogh EpHesabTafziliSandogh1 { get; set; }
        public virtual EpHesabTafziliHesabBanki EpHesabTafziliHesabBanki1 { get; set; }
        //public virtual ICollection<HaghOzviat> HaghOzviats { get; set; }
        //public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        //public virtual ICollection<CheckTazmin> CheckTazmins { get; set; }
    }
}
