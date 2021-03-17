using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
    public class EpGroupAsliKala
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int TabaghehId { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int VahedKalaId { get; set; }
        //[Required, MaxLength(50)]
        //public string VahedKalaName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpAllCodingKala EpAllCodingKala1 { get; set; }
        public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpTabaghehKala EpTabaghehKala1 { get; set; }
        public virtual ICollection<EpGroupFareeKala> EpGroupFareeKalas { get; set; }
    }
}
