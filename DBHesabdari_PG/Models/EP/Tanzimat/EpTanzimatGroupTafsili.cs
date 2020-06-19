using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.Tanzimat
{
    public class EpTanzimatGroupTafsili
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        //public int Code { get; set; }
        [Required]
        public int GroupTafsiliLevel1Carakter { get; set; }
        [Required]
        public int GroupTafsiliLevel2Carakter { get; set; }
        [Required]
        public int GroupTafsiliLevel3Carakter { get; set; }
        [Required]
        public int CodeTafsiliCarakter { get; set; }

        [Required, MaxLength(2)]
        public string GroupTafsiliLevel1MinCode { get; set; }
        [Required, MaxLength(2)]
        public string GroupTafsiliLevel1MaxCode { get; set; }
        [Required, MaxLength(1)]
        public string GroupTafsiliLevel2MinCode { get; set; }
        [Required, MaxLength(1)]
        public string GroupTafsiliLevel2MaxCode { get; set; }
        [Required, MaxLength(1)]
        public string GroupTafsiliLevel3MinCode { get; set; }
        [Required, MaxLength(1)]
        public string GroupTafsiliLevel3MaxCode { get; set; }
        [Required, MaxLength(6)]
        public string CodeTafsiliMinCode { get; set; }
        [Required, MaxLength(6)]
        public string CodeTafsiliMaxCode { get; set; }

        [Required]
        public bool IsActiveGroupTafsiliLevel1 { get; set; }
        [Required]
        public bool IsActiveGroupTafsiliLevel2 { get; set; }
        [Required]
        public bool IsActiveGroupTafsiliLevel3 { get; set; }

    }
}
