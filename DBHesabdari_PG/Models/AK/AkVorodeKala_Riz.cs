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
        [Required]
        public int KalaId { get; set; }
        [MaxLength(16)]
        public string KalaCode { get; set; }
        [MaxLength(100)]
        public string KalaName { get; set; }
        [Required]
        public int VahedeKalaId { get; set; }
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
        public DateTime? DateTimeEdit { get; set; }
        [Required]
        public int NoeAmaliatCode { get; set; }
        [Required]
        public int NoeSanadCode { get; set; }
        [MaxLength(150)]
        public string NoeSanadText { get; set; }
        [Required]
        public decimal Meghdar { get; set; }
        [Required]
        public decimal Nerkh { get; set; }
        [Required]
        public decimal Mablag { get; set; }
        //[Required]
        //public bool IsMeghdari { get; set; }
        [Required]
        public bool IsRiali { get; set; }
        [Required]
        public int SanadNamber { get; set; }
        [Required]
        public int HesabMoinId { get; set; }
        [MaxLength(9)]
        public string MoinCode { get; set; }
        [MaxLength(100)]
        public string MoinName { get; set; }
        [Required]
        public int HesabTafsiliId { get; set; }
        [MaxLength(9)]
        public string TafsiliCode { get; set; }
        [MaxLength(100)]
        public string TafsiliName { get; set; }
        [Required]
        public int Radif { get; set; }
        public int? FactorNamber { get; set; }
        [MaxLength(350)]
        public string Tozihat { get; set; }
        public virtual AkAllAmaliateRozaneh AkAllAmaliateRozaneh1 { get; set; }
    }
}
