﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpDarsadTakhfif_A
    {
        public int Id { get; set; }
        //[Required]
        //public int GroupTafsiliId { get; set; }
        //[Required, MaxLength(50)]
        //public string GroupTafsiliName { get; set; }
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
        //[Required]
        //public int IndexNoeTakhfif { get; set; }
        //[Required, MaxLength(20)]
        //public string NoeTakhfif { get; set; }
        [Required]
        public float DarsadTakhfifRadifi { get; set; }
        [Required]
        public float DarsadTakhfifJamei { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? AzTarikh { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? TaTarikh { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        [MaxLength(400)]
        public string Molahezat { get; set; }
        public virtual EpHesabTafsiliAshkhas EpHesabTafsiliAshkhas1 { get; set; }
    }
}
