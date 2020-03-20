using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTabagheh
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int IndexNoeHesab { get; set; }
        [Required, MaxLength(20)]
        public string NoeHesab { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual ICollection<EpHesabGroup> EpHesabGroups { get; set; }
        public virtual EpAllCodingHesabdari EpAllCodingHesabdari1 { get; set; }
    }
}
