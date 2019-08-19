using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
    public class EpShTamas_A
    {
        public int Id { get; set; }
        //[Required]
        //public int GroupTafziliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafziliName { get; set; }
        [Required]
        public int AshkhasId { get; set; }
        //[Required]
        //public int AshkhasCode { get; set; }
        //[Required, MaxLength(100)]
        //public string AshkhasName { get; set; }
        [Required,MaxLength(50)]
        public string NoeTamas { get; set; }
        [Required,MaxLength(20)]
        public string ShTamas { get; set; }
        [MaxLength(50)]
        public string NameTaraf { get; set; }
        [MaxLength(50)]
        public string NameGhesmat { get; set; }
        [MaxLength(20)]
        public string ShDakheli { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        [Required]
        public int IndexNoeTamas { get; set; }
        public virtual EpHesabTafziliAshkhas EpHesabTafziliAshkhas1 { get; set; }

    }
}
