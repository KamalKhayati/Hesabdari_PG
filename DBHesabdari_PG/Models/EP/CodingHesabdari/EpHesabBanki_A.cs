using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
    public class EpHesabBanki_A
    {
        public int Id { get; set; }
        //[Required]
        //public int GroupTafziliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafziliName { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int AshkhasId { get; set; }
        [Required]
        public int Code { get; set; }
        //[Required]
        //public int AshkhasCode { get; set; }
        //[Required, MaxLength(100)]
        //public string AshkhasName { get; set; }
        [Required, MaxLength(40)]
        public string NameBank { get; set; }
        [Required]
        public int NameBankId { get; set; }
        [Required, MaxLength(40)]
        public string ShomareHesab { get; set; }
        [MaxLength(40)]
        public string ShomareKart { get; set; }
        [MaxLength(40)]
        public string ShomareShaba { get; set; }
        [MaxLength(40)]
        public string ShomareMoshtari { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        public virtual EpNameBank EpNameBank1 { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }
    }
}
