using DBHesabdari_PG.Models.EP.CodingAnbar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.AK
{
   public class AkAllAmaliateRozaneh
    {
        public long Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int AzAnbarId { get; set; }
        [Required]
        public int BeAnbarId { get; set; }
        [Required]
        public int KalaId { get; set; }
        [Required]
        public int VahedeKalaId { get; set; }
        [Required]
        public int Seryal { get; set; }
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
        [Required]
        public int HesabTafsili1Id { get; set; }
        [Required]
        public int HesabTafsili2Id { get; set; }
        [Required]
        public int HesabTafsili3Id { get; set; }
        [Required]
        public int Radif { get; set; }
        [Required]
        public DateTime DateTimeSanad { get; set; }
        public int? FactorNamber { get; set; }

        /// <summary>
        /// فیلدهای پین شده به جدول
        /// </summary>
        [NotMapped]
        [MaxLength(100)]
        public string AnbarName { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string VahedKala { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string HesabTafsiliName { get; set; }
        [NotMapped]
        public decimal MeghdarMo { get; set; }
        [NotMapped]
        public decimal NerkhMo { get; set; }
        [NotMapped]
        public decimal MablagMo { get; set; }
        [NotMapped]
        public decimal MeghdarVa { get; set; }
        [NotMapped]
        public decimal NerkhVa { get; set; }
        [NotMapped]
        public decimal MablagVa { get; set; }
        [NotMapped]
        public decimal MeghdarSa { get; set; }
        [NotMapped]
        public decimal NerkhSa { get; set; }
        [NotMapped]
        public decimal MablagSa { get; set; }
        [NotMapped]
        public decimal MeghdarMa { get; set; }
        [NotMapped]
        public decimal NerkhMa { get; set; }
        [NotMapped]
        public decimal MablagMa { get; set; }


        public virtual AkVorodeKala_Riz AkVorodeKala_Riz1 { get; set; }
        public virtual AkKhorojeKala_Riz AkKhorojeKala_Riz1 { get; set; }
        public virtual ICollection<R_EpAllCodingKala_B_AkAllAmaliateRozaneh> R_EpAllCodingKala_B_AkAllAmaliateRozanehs { get; set; }
    }

    public class R_EpAllCodingKala_B_AkAllAmaliateRozaneh
    {
        [Required, Column(Order = 0)]
        public int SalId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public int KalaId { get; set; }
        [Key]
        [Required, Column(Order = 2)]
        public long AmaliatId { get; set; }

        public virtual AkAllAmaliateRozaneh AkAllAmaliateRozaneh1 { get; set; }
        public virtual EpAllCodingKala EpAllCodingKala1 { get; set; }
    }
}
