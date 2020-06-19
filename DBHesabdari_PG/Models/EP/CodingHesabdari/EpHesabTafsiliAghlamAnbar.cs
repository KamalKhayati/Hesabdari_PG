using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafsiliAghlamAnbar
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhEjad { get; set; }
        public long? CodeKala { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        [Required]
        public bool IsCreateByUser { get; set; }
        [MaxLength(15)]
        public string CreateName { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }
    }
}
