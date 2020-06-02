using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
    public class EpAllHesabTafsili_HesabMovaghat
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int LevelNamber { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        [Required]
        public int MoinId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
    }
}
