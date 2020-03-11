using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafziliVam
    {
        public int Id { get; set; }
        [Required]
        public int AllId { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int IndexNoeVam { get; set; }
        [MaxLength(20)]
        public string NoeVam { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhDaryaftVam { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? SarresidAvalinGhest { get; set; }
        public int TedadAghsat { get; set; }
        public float NerkhBahre { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        public virtual EpGroupTafzili EpGroupTafzili1 { get; set; }
    }
}
