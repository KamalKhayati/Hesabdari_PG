using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.FK.Taarif
{
    public class FKTarifEz_Ks_Factor
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        //public int Ez_KsId { get; set; }
        [Required]
        public byte NoeEz_KsIndex { get; set; }
        [Required, MaxLength(100)]
        public string NoeEz_KsName { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }

        //[Required]
        //public int HesabMoinId { get; set; }
        //[Required]
        //public int HesabTafsili1Id { get; set; }
        //[Required]
        //public int HesabTafsili2Id { get; set; }
        //[Required]
        //public int HesabTafsili3Id { get; set; }

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

    }
}
