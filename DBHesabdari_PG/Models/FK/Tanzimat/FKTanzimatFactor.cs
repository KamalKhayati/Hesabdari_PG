using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.FK.Tanzimat
{
    public class FKTanzimatFactor
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int AnbarId { get; set; }
        [Required]
        public int KhadamatId { get; set; }
        [Required]
        public int Ez_KsId { get; set; }
        [Required]
        public int VizitorId { get; set; }
        [Required]
        public byte NoeAghlam { get; set; }
        [Required, MaxLength(100)]
        public string NameSanad { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int HesabMoinId { get; set; }
        [Required]
        public int HesabTafsili1Id { get; set; }
        [Required]
        public int HesabTafsili2Id { get; set; }
        [Required]
        public int HesabTafsili3Id { get; set; }

        /// <summary>
        /// فیلدهای پین شده به جدول
        /// </summary>
        [NotMapped]
        [MaxLength(100)]
        public string HesabMoinName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string HesabTafsili1Name_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string HesabTafsili2Name_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string HesabTafsili3Name_NM { get; set; }

        //public virtual EpListAnbarha EpListAnbarha1 { get; set; }
        //public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        //public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }
        //public virtual EpAllHesabTafsili EpAllHesabTafsili2 { get; set; }
        //public virtual EpAllHesabTafsili EpAllHesabTafsili3 { get; set; }

    }
}
