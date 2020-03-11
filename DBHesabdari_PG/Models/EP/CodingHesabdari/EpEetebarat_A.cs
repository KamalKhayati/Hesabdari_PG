using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpEetebarat_A
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
        [MaxLength(20)]
        public string ShGharadad { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhGharadad { get; set; }
        [Required]
        public decimal Mablagh { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public bool chkEetebarat { get; set; }
        //[Required]
        //public bool chkGharardad { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }
    }
}
