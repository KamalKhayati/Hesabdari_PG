using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpHesabTafsiliDaraeha
    {
        public int Id { get; set; }
        [Required]
        public int AllId { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        [Required, MaxLength(50)]
        public string GroupTafsili { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int IndexRaveshEstehlak { get; set; }
        [Required, MaxLength(30)]
        public string RaveshEstehlak { get; set; }
        [Required]
        public int OmreMofid { get; set; }
        [Required]
        public float DarsadEstehlak { get; set; }
        [Required]
        public decimal ArzeshEsghat { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }
    }
}
