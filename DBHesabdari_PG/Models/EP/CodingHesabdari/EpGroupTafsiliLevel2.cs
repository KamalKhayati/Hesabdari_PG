using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpGroupTafsiliLevel2
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Level1Id { get; set; }
        //[Required, MaxLength(50)]
        //public string Level1Name { get; set; }
        [Required]
        public int StartCode { get; set; }
        [Required]
        public int EndCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }
        public virtual ICollection<EpGroupTafsiliLevel3> EpGroupTafsiliLevel3s { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsilis { get; set; }
    }
}
