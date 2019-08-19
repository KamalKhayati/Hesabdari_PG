using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafziliDaraeha
    {
        public int Id { get; set; }
        [Required]
        public int GroupTafziliId { get; set; }
        [Required, MaxLength(50)]
        public string GroupTafzili { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int IndexRaveshEstehlak { get; set; }
        [Required, MaxLength(30)]
        public string RaveshEstehlak { get; set; }
        [Required]
        public int OmreMofid { get; set; }
        [Required]
        public float DarsadEstehlak { get; set; }
        [Required]
        public decimal ArzeshEsghat { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpGroupTafzili EpGroupTafzili1 { get; set; }
    }
}
