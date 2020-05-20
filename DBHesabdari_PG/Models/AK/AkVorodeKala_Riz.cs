using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.AK
{
   public class AkVorodeKala_Riz
    {
        public long Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [MaxLength(16)]
        public string CodeKala { get; set; }
        [MaxLength(100)]
        public string NameKala { get; set; }
        [MaxLength(20)]
        public string VahedeKala { get; set; }
        [Required]
        public int AnbarId { get; set; }
        [Required]
        public int Seryal { get; set; }
        [Required]
        public DateTime DateTimeSanad { get; set; }
        [Required]
        public DateTime DateTimeInsert { get; set; }
        [Required]
        public DateTime DateTimeEdit { get; set; }
        [Required]
        public int NoeAmaliatIndex { get; set; }
        [Required]
        public int AmaliatIndex { get; set; }
        [Required]
        public int KalaId { get; set; }
        [Required]
        public decimal Meghdar { get; set; }
        [Required]
        public decimal Nerkh { get; set; }
        [Required]
        public decimal Mablag { get; set; }
        [Required]
        public bool IsMeghdari { get; set; }
        [Required]
        public bool IsRiali { get; set; }
        [Required]
        public string Sh_Sanad { get; set; }
        [Required]
        public int Radif { get; set; }
        [Required]
        public long FactorNamber { get; set; }
        public virtual AkAllAmaliateRozaneh AkAllAmaliateRozaneh1 { get; set; }
    }
}
