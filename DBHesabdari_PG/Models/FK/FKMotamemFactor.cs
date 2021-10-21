using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.FK
{
   public class FKMotamemFactor
    {
        public int Id { get; set; }
        //[Required]
        //public int Code { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        public int? TakhfifId { get; set; }
        //[Required]
        //public byte NoeEz_KsIndex { get; set; }
        [MaxLength(100)]
        public string NameTarafHesab { get; set; }
        [MaxLength(11)]
        public string ShMobile1 { get; set; }
        [MaxLength(11)]
        public string TelSabet1 { get; set; }
        [MaxLength(500)]
        public string Adress { get; set; }
        [MaxLength(100)]
        public string NameRanande { get; set; }
        [MaxLength(20)]
        public string ShPlak { get; set; }
        [MaxLength(11)]
        public string ShMobile2 { get; set; }
        [MaxLength(11)]
        public string TelSabet2 { get; set; }
        [MaxLength(500)]
        public string MohalTahvil { get; set; }
        [MaxLength(15)]
        public string ShBarname { get; set; }
        [MaxLength(10)]
        public string VaznBaskol { get; set; }
        [Required]///// شماره فاکتور کلی بدون هیچ فیلتر یا شرطی
        public int FNumber_BeNameAmaliat_BeSelectAnbar { get; set; }
        [Required]///// شماره فاکتور کلی با فیلتر یکی از سندهای عملیات خرید یا فروش بدون نوع فاکتور(کالا/خدمات)ض
        public int FNumberCol_BaNameSanad_BeSelectAnbar { get; set; }
        [Required]///// شماره فاکتور جزء با فیلتر یکی از سندهای عملیات خرید یا فروش و یکی از انبارها
        public int FNumberJoze_BaNameSanad_BaSelectAnbar { get; set; }
        [Required]///// شماره فاکتور جزء با فیلتر یکی از سندهای عملیات خرید یا فروش و یکی از انبارها
        public int FNumberJoze_BaNameSanad_BaNoeFactor { get; set; }


        /// <summary>
        /// فیلدهای پین شده به جدول
        /// </summary>
        //[NotMapped]
        //[MaxLength(100)]
        //public string HesabMoinName_NM { get; set; }
        //[NotMapped]
        //[MaxLength(100)]
        //public string HesabTafsili1Name_NM { get; set; }
        //[NotMapped]
        //[MaxLength(100)]
        //public string HesabTafsili2Name_NM { get; set; }
        //[NotMapped]
        //[MaxLength(100)]
        //public string HesabTafsili3Name_NM { get; set; }

        public virtual EpDarsadTakhfif_A EpDarsadTakhfif_A1 { get; set; }
        //public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Rizs { get; set; }
        //public virtual ICollection<FKTanzimatFactor> FKTanzimatFactors { get; set; }
    }
}
