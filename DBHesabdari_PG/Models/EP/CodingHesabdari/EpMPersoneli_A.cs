using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpMPersoneli_A
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        //[Required]
        //public int GroupTafziliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafziliName { get; set; }
        //[Required]
        //public int AshkhasId { get; set; }
        [Required]
        public int Code { get; set; }
        //[Required]
        //public int AshkhasCode { get; set; }
        //[Required, MaxLength(100)]
        //public string AshkhasName { get; set; }
        public int? CodPersoneli { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhEstekhdam { get; set; }
        [MaxLength(20)]
        public string NamePedar { get; set; }
        [MaxLength(10)]
        public string ShShenasname { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TarikhTavalod { get; set; }
        [Required]
        public int IndexJensiat { get; set; }
        [Required, MaxLength(5)]
        public string Jensiat { get; set; }
        [Required]
        public int IndexTaahol { get; set; }
        [Required, MaxLength(5)]
        public string Taahol { get; set; }
        [MaxLength(20)]
        public string Shogl { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }
    }
}
