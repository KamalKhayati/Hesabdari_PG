using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.Tanzimat
{
  public class EpTanzimatCodingHesabdari
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TabaghebandiHesabhaId { get; set; }
        [Required, MaxLength(50)]
        public string TabaghebandiHesabhaName { get; set; }
        [Required]
        public int IndexNoeHesab { get; set; }
        [Required, MaxLength(20)]
        public string NoeHesab { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
