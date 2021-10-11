using DBHesabdari_PG.Models.AK;
using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using DBHesabdari_PG.Models.FK.Taarif;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.FK
{
    public class FkAmaliatFrooshVKharid_Riz
    {
        public long Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        public int? KalaId { get; set; }
        //[Required]
        //public int? VahedeKalaId { get; set; }
        //[Required]
        public int? AnbarId { get; set; }
        //[Required]
        public int? Ez_KsId { get; set; }
        //[Required]
        public int? VizitorId { get; set; }

        [Required]///// شماره فاکتور کلی بدون هیچ فیلتر یا شرطی
        public int FNumber_BeNameAmaliat_BeSelectAnbar { get; set; }
        //[Required]///// شماره فاکتور کلی با فیلتر یکی از عملیات خرید یا فروش
        //public int FNumber_BaNameAmaliat_BeSelectAnbar { get; set; }
        [Required]///// شماره فاکتور کلی با فیلتر یکی از سندهای عملیات خرید یا فروش بدون نوع فاکتور(کالا/خدمات)ض
        public int FNumberCol_BaNameSanad_BeSelectAnbar { get; set; }
        //[Required]///// شماره فاکتور جزء با فیلتر یکی از عملیات خرید یا فروش و یکی از انبارها
        //public int FNumber_BaNameAmaliat_BaSelectAnbar { get; set; }
        [Required]///// شماره فاکتور جزء با فیلتر یکی از سندهای عملیات خرید یا فروش و یکی از انبارها
        public int FNumberJoze_BaNameSanad_BaSelectAnbar { get; set; }
        [Required]///// شماره فاکتور جزء با فیلتر یکی از سندهای عملیات خرید یا فروش و یکی از انبارها
        public int FNumberJoze_BaNameSanad_BaNoeFactor { get; set; }


        //[Required]
        public int? SNumber_BeNameAmaliat_BeSelectAnbar { get; set; }
        //[Required]
        //public int SNumber_BaNameAmaliat_BeSelectAnbar { get; set; }
        //[Required]
        public int? SNumberCol_BaNameSanad_BeSelectAnbar { get; set; }
        //[Required]
        //public int SNumber_BaNameAmaliat_BaSelectAnbar { get; set; }
        //[Required]
        public int? SNumberJoze_BaNameSanad_BaSelectAnbar { get; set; }


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
        ///کالا=1///خدمات==2///
        [Required]
        public byte NoeFactor { get; set; }
        /////خریدوبرگشت وسفارش==1/////فروش وبرگشت وسفارش==2/////
        [Required]
        public int NameAmaliatCode { get; set; }
        /////فاکتورخرید وفروش==0//////فاکتوربرگشت خرید وفروش==1////سفارش خریدوفروش==2
        [Required]
        public int NameSanadIndex { get; set; }
        //////////////فاکتور خرید==101////فاکتور برگشت خرید==102/////سفارش خرید==103
        //////////////فاکتور فروش ==201////فاکتور برگشت فروش ==202 //// سفارش فروش== 203
        [Required]
        public int NameSanadCode { get; set; }
        //////////////فاکتور خرید////فاکتور برگشت خرید/////سفارش خرید
        //////////////فاکتور فروش ////فاکتور برگشت فروش //// سفارش فروش 
        [MaxLength(100)]
        public string NameSanadText { get; set; }
        //////////////خرید داخلی ==0////خرید وارداتی==1
        //////////////برگشت داخلی ==0//// برگشت وارداتی ==1
        //////////////سفارش داخلی ==0//// سفارش وارداتی ==1
        //////////////فروش داخلی ==0//// فروش صادارتی ==1
        //////////////برگشت داخلی ==0//// برگشت صادارتی ==1
        //////////////سفارش داخلی ==0//// سفارش صادارتی ==1
        [Required]
        public int NoeSanadIndex { get; set; }
        //////////////خرید داخلی ////خرید وارداتی
        //////////////برگشت داخلی //// برگشت وارداتی 
        //////////////سفارش داخلی //// سفارش وارداتی 
        //////////////فروش داخلی //// فروش صادارتی 
        //////////////برگشت داخلی //// برگشت صادارتی 
        //////////////سفارش داخلی //// سفارش صادارتی 
        [MaxLength(100)]
        public string NoeSanadText { get; set; }
        //////////////خرید داخلی ==0////خرید وارداتی==1
        //////////////برگشت داخلی ==0//// برگشت وارداتی ==1
        //////////////سفارش داخلی ==0//// سفارش وارداتی ==1
        //////////////فروش داخلی ==0//// فروش صادارتی ==1
        //////////////برگشت داخلی ==0//// برگشت صادارتی ==1
        //////////////سفارش داخلی ==0//// سفارش صادارتی ==1
        //[Required]
        //public int NoeSanadIndex_Khadamat { get; set; }
        //////////////خرید داخلی ////خرید وارداتی
        //////////////برگشت داخلی //// برگشت وارداتی 
        //////////////سفارش داخلی //// سفارش وارداتی 
        //////////////فروش داخلی //// فروش صادارتی 
        //////////////برگشت داخلی //// برگشت صادارتی 
        //////////////سفارش داخلی //// سفارش صادارتی 
        //[MaxLength(100)]
        //public string NoeSanadText_Khadamat { get; set; }
        //[Required]
        public int? SefareshId { get; set; }
        //[Required]
        public int? SanadMabnaId { get; set; }
        [Required]
        public decimal Meghdar { get; set; }
        [Required]
        public decimal Nerkh { get; set; }
        [Required]
        public decimal Mablag { get; set; }
        //[Required]
        public decimal? Motefareghe { get; set; }
        public decimal? TakhfifRadifiKala { get; set; }
        public decimal? TakhfifRadifiTaraf { get; set; }
        public decimal? Maliat { get; set; }
        public decimal? Avarez { get; set; }
        [Required]
        public byte IndexAghlamFactor { get; set; }
        //[Required]
        //public decimal? Ksorat { get; set; }
        //[Required]
        //public bool IsMeghdari { get; set; }
        //[Required]
        //public bool? IsRiali { get; set; }
        //[Required]
        //public int RozaneSanadNumber { get; set; }
        [Required]
        public int HesabMoinId_Bed { get; set; }
        [Required]
        public int HesabTafsili1Id_Bed { get; set; }
        [Required]
        public int HesabTafsili2Id_Bed { get; set; }
        [Required]
        public int HesabTafsili3Id_Bed { get; set; }
        [Required]
        public int HesabMoinId_Bes { get; set; }
        [Required]
        public int HesabTafsili1Id_Bes { get; set; }
        [Required]
        public int HesabTafsili2Id_Bes { get; set; }
        [Required]
        public int HesabTafsili3Id_Bes { get; set; }
        //[MaxLength(100)]
        //public string Tafsili2Name { get; set; }
        //[MaxLength(100)]
        //public string Tafsili3Name { get; set; }
        [Required]
        public int Radif { get; set; }
        //public int FactorNumber { get; set; }
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
        //[NotMapped]
        //[MaxLength(100)]
        //public string VizitorName_NM { get; set; }
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




        public virtual EpListAnbarha EpListAnbarha1 { get; set; }
        //public virtual EpListAnbarha EpListAnbarha2 { get; set; }
        //public virtual EpVahedKala EpVahedKala1 { get; set; }
        public virtual EpNameKala EpNameKala1 { get; set; }
        public virtual FKTarifEz_Ks_Factor FKTarifEz_Ks_Factor1 { get; set; }
        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili2 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili3 { get; set; }
        public virtual EpHesabTafsiliAshkhas EpHesabTafsiliAshkhas1 { get; set; }

    }
}
