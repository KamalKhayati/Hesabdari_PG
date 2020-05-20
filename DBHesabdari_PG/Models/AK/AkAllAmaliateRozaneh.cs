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
        public virtual AkVorodeKala_Riz AkVorodeKala_Riz1 { get; set; }
        public virtual ICollection<R_EpAllCodingKala_B_AkAllAmaliateRozaneh> R_EpAllCodingKala_B_AkAllAmaliateRozanehs { get; set; }
    }

    public class R_EpAllCodingKala_B_AkAllAmaliateRozaneh
    {
        [Required, Column(Order = 0)]
        public int SalId { get; set; }
        [Key]
        [Required, Column(Order = 1)]
        public long KalaId { get; set; }
        [Key]
        [Required, Column(Order = 2)]
        public long AmaliatId { get; set; }

        public virtual AkAllAmaliateRozaneh AkAllAmaliateRozaneh1 { get; set; }
        public virtual EpAllCodingKala EpAllCodingKala1 { get; set; }
    }
}
