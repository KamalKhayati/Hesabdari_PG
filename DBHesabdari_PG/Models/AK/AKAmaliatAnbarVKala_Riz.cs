﻿using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DBHesabdari_PG.Models.FK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.AK
{
   public class AKAmaliatAnbarVKala_Riz
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int KalaId { get; set; }
        [Required]
        public int VahedeKalaId { get; set; }
        [Required]
        public int AzAnbarId { get; set; }
        [Required]
        public int BeAnbarId { get; set; }
        [Required]
        public int SeryalCol_BeNameAmaliat_BeSelectAnbar { get; set; }
        //[Required]
        //public int SeryalCol_BeNameAmaliat_BaSelectAnbar { get; set; }
        [Required]
        public int SeryalCol_BaNameAmaliat_BeSelectAnbar { get; set; }
        [Required]
        public int SeryalJoze_BaNameSanad_BeSelectAnbar { get; set; }
        [Required]
        public int SeryalCol_BaNameAmaliat_BaSelectAnbar { get; set; }
        [Required]
        public int SeryalJoze_BaNameSanad_BaSelectAnbar { get; set; }
        //[Required]
        public int? GhateySanadNamber { get; set; }
        [Required]
        public int SabetAtefNumber { get; set; }
        [Required]
        public int RozaneSanadNumber { get; set; }
        //[Required]
        public int? PaygiriNumber { get; set; }
        //[Required]
        public DateTime? DateTimePaygiri { get; set; }
        [Required]
        public DateTime DateTimeSanad { get; set; }
        [Required]
        public DateTime DateTimeInsert { get; set; }
        public DateTime? DateTimeEdit { get; set; }
        [Required]
        public int NameAmaliatCode { get; set; }
        [Required]
        public int NameSanadIndex { get; set; }
        [Required]
        public int NameSanadCode { get; set; }
        [MaxLength(150)]
        public string NameSanadText { get; set; }
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
        //[Required]
        //public int RozaneSanadNumber { get; set; }
        [Required]
        public int HesabMoinId { get; set; }
        [Required]
        public int HesabTafsili1Id { get; set; }
        [Required]
        public int HesabTafsili2Id { get; set; }
        [Required]
        public int HesabTafsili3Id { get; set; }
        //[MaxLength(100)]
        //public string Tafsili2Name { get; set; }
        //[MaxLength(100)]
        //public string Tafsili3Name { get; set; }
        [Required]
        public int Radif { get; set; }
        public int? FactorNumber { get; set; }
        [Required]
        public long FactorId { get; set; }
        [MaxLength(350)]
        public string Tozihat { get; set; }
        [MaxLength(500)]
        public string SharhSanad { get; set; }


        /// <summary>
        /// فیلدهای پین شده به جدول
        /// </summary>
        [NotMapped]
        [MaxLength(16)]
        public string SeryalCol_NM { get; set; }
        [NotMapped]
        [MaxLength(16)]
        public string SeryalJoze_NM { get; set; }
        [NotMapped]
        [MaxLength(16)]
        public string KalaCode_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string KalaName_NM { get; set; }
        [NotMapped]
        [MaxLength(20)]
        public string VahedeKala_NM { get; set; }
        [NotMapped]
        [MaxLength(9)]
        public string TafsiliCode_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string TafsiliName_NM { get; set; }
        [NotMapped]
        [MaxLength(9)]
        public string MoinCode_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string MoinName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string AzAnbarName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string BeAnbarName_NM { get; set; }

        //[NotMapped]
        //[MaxLength(100)]
        //public string KalaName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string AnbarName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string VahedeKalaName_NM { get; set; }
        [NotMapped]
        [MaxLength(100)]
        public string HesabTafsiliName_NM { get; set; }
        //[NotMapped]
        //[MaxLength(20)]
        //public string KalaCode_NM { get; set; }
        [NotMapped]
        public decimal MeghdarMo_NM { get; set; }
        [NotMapped]
        public decimal NerkhMo_NM { get; set; }
        [NotMapped]
        public decimal MablagMo_NM { get; set; }
        [NotMapped]
        public decimal MeghdarVa_NM { get; set; }
        [NotMapped]
        public decimal NerkhVa_NM { get; set; }
        [NotMapped]
        public decimal MablagVa_NM { get; set; }
        [NotMapped]
        public decimal MeghdarSa_NM { get; set; }
        [NotMapped]
        public decimal NerkhSa_NM { get; set; }
        [NotMapped]
        public decimal MablagSa_NM { get; set; }
        [NotMapped]
        public decimal MeghdarMa_NM { get; set; }
        [NotMapped]
        public decimal NerkhMa_NM { get; set; }
        [NotMapped]
        public decimal MablagMa_NM { get; set; }
        [NotMapped]
        public string DateTimeSanadString_NM { get; set; }

        //public virtual AkAllAmaliateRozaneh AkAllAmaliateRozaneh1 { get; set; }
        public virtual EpListAnbarha EpListAnbarha1 { get; set; }
        public virtual EpListAnbarha EpListAnbarha2 { get; set; }
        public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpNameKala EpNameKala1 { get; set; }
        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili2 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili3 { get; set; }

        //public virtual FkAmaliatFrooshVKharidVKharid_Riz FkAmaliatFrooshVKharidVKharid_Riz1 { get; set; }

    }
}
