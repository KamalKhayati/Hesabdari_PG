using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
    public class EpTabaghehKala
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int VahedKalaId { get; set; }
        //[Required, MaxLength(50)]
        //public string VahedKalaName { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpAllCodingKala EpAllCodingKala1 { get; set; }
        public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsili1 { get; set; }
        public virtual ICollection<EpGroupAsliKala> EpGroupAsliKalas { get; set; }
        public virtual ICollection<R_EpListAnbarha_B_EpTabaghehKala> R_EpListAnbarha_B_EpTabaghehKalas { get; set; }

    }
}
