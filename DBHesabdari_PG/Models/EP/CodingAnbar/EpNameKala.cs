using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
   public class EpNameKala
    {
        public int Id { get; set; }
        [Required]
        public int DasteBandiIndex { get; set; }
        [Required, MaxLength(20)]
        public string DasteBandiName { get; set; }
        [Required]
        public int GroupAsliId { get; set; }
        [Required, MaxLength(100)]
        public string GroupAsliName { get; set; }
        [Required]
        public int GroupFareeId { get; set; }
        [Required, MaxLength(100)]
        public string GroupFareeName { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int? CodeEkhtesasi { get; set; }
        public string TaminKonandeId { get; set; }
        public string TaminKonandeName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int VahedKala1Id { get; set; }
        [Required, MaxLength(50)]
        public string VahedKala1Name { get; set; }
        public int? VahedKala2Id { get; set; }
        [MaxLength(50)]
        public string VahedKala2Name { get; set; }
        public int? VahedKala3Id { get; set; }
        [MaxLength(50)]
        public string VahedKala3Name { get; set; }
        public double? HarBaste { get; set; }
        public double? HarKarton { get; set; }
        [Required]
        public bool IscheckVahedKala2 { get; set; }
        [Required]
        public bool IscheckVahedKala3 { get; set; }
        public string SerialKala { get; set; }
        public string BarcodKala { get; set; }
        public string ShomareFani { get; set; }
        public decimal? GhimatAkharinKharid { get; set; }
        public decimal? GhimatTamamShode { get; set; }
        public decimal? GhimatPayeFroosh { get; set; }
        public float? DarsadTakhfif { get; set; }
        public decimal? GhimatNaghdi1 { get; set; }
        public decimal? GhimatNesiye1 { get; set; }
        public decimal? GhimatNaghdi2 { get; set; }
        public decimal? GhimatNesiye2 { get; set; }
        public double? Vazn { get; set; }
        public double? Tool { get; set; }
        public double? Arz { get; set; }
        public double? Ertefae { get; set; }
        public double? NoghteSefaresh { get; set; }
        public double? HadeSefaresh { get; set; }
        [Required]
        public bool IsArzeshAfzode { get; set; }
        public byte[] Pictuer { get; set; }
        public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpGroupFareeKala EpGroupFareeKala1 { get; set; }
        public virtual ICollection<R_EpTaminKonandeKala_EpNameKala> R_EpTaminKonandeKala_EpNameKalas { get; set; }
    }
}
