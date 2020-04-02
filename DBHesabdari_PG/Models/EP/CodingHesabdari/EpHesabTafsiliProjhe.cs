using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafsiliProjhe
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
        [MaxLength(50)]
        public string NameMasol { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }

    }
}
