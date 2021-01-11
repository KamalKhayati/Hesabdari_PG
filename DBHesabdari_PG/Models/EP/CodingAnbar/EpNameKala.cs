using DBHesabdari_PG.Models.AK;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
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
        public int SalId { get; set; }
        [Required]
        public int GroupFareeId { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public long CodeHesabdari { get; set; }
        public int? CodeEkhtesasi { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TarikhEjad { get; set; }
        [MaxLength(1000)]
        public string TaminKonandeId { get; set; }
        [MaxLength(1000)]
        public string TaminKonandeName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int VahedKala1Id { get; set; }
        //[Required, MaxLength(50)]
        //public string VahedKala1Name { get; set; }
        public int? VahedKala2Id { get; set; }
        //[MaxLength(50)]
        //public string VahedKala2Name { get; set; }
        public int? VahedKala3Id { get; set; }
        //[MaxLength(50)]
        //public string VahedKala3Name { get; set; }
        [Required]
        public int VahedAsliId { get; set; }
        public double? HarBaste { get; set; }
        public double? HarKarton { get; set; }
        [Required]
        public bool IscheckVahedKala2 { get; set; }
        [Required]
        public bool IscheckVahedKala3 { get; set; }
        public string SerialKala { get; set; }
        public string ShomareFani { get; set; }
        public decimal? GhimatAkharinKharid { get; set; }
        public decimal? GhimatTamamShode { get; set; }
        public decimal? GhimatPayeFroosh { get; set; }
        public float? DarsadTakhfif { get; set; }
        public decimal? GhimatNaghdiKhorde1 { get; set; }
        public decimal? GhimatNesiyeKhorde1 { get; set; }
        public decimal? GhimatNaghdiOmde1 { get; set; }
        public decimal? GhimatNesiyeOmde1 { get; set; }
        public double? Vazn { get; set; }
        public double? Tool { get; set; }
        public double? Arz { get; set; }
        public double? Ertefae { get; set; }
        public double? Zekhamat { get; set; }
        public double? Masahat { get; set; }
        public double? Mohit { get; set; }
        public double? Hajm { get; set; }
        [MaxLength(20)]
        public string Saiz { get; set; }
        public double? NoghteSefaresh { get; set; }
        public double? HadeSefaresh { get; set; }
        [Required]
        public bool IsArzeshAfzode { get; set; }
        public byte[] Pictuer { get; set; }


        [MaxLength(50), NotMapped]
        public string VahedAsliName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string GroupAsliName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string GroupFareeName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string TabagheKalaName_NM { get; set; }
        [NotMapped]
        public decimal MeghdarMa_NM { get; set; }

        public virtual EpAllCodingKala EpAllCodingKala1 { get; set; }
        public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpVahedKala EpVahedKala2 { get; set; }
        public virtual EpVahedKala EpVahedKala3 { get; set; }
        public virtual EpVahedKala EpVahedAsliKala { get; set; }
        public virtual EpGroupFareeKala EpGroupFareeKala1 { get; set; }
        public virtual ICollection<AkVorodeKala_Riz> AkVorodeKala_Rizs { get; set; }
        public virtual ICollection<AkKhorojeKala_Riz> AkKhorojeKala_Rizs { get; set; }
        public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozanehs { get; set; }
    }
}
