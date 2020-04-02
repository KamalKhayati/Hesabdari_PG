using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.Tanzimat
{
  public class EpTanzimatCodingHesabdari
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        //public int Code { get; set; }
        [Required]
        public int HesabTabaghehCarakter { get; set; }
        [Required]
        public int HesabGroupCarakter { get; set; }
        [Required]
        public int HesabColCarakter { get; set; }
        [Required]
        public int HesabMoinCarakter { get; set; }

        [Required ,MaxLength(1)]
        public string HesabTabaghehMinCode { get; set; }
        [Required, MaxLength(1)]
        public string HesabTabaghehMaxCode { get; set; }
        [Required, MaxLength(2)]
        public string HesabGroupMinCode { get; set; }
        [Required, MaxLength(2)]
        public string HesabGroupMaxCode { get; set; }
        [Required, MaxLength(3)]
        public string HesabColMinCode { get; set; }
        [Required, MaxLength(3)]
        public string HesabColMaxCode { get; set; }
        [Required, MaxLength(3)]
        public string HesabMoinMinCode { get; set; }
        [Required, MaxLength(3)]
        public string HesabMoinMaxCode { get; set; }

    }
}
