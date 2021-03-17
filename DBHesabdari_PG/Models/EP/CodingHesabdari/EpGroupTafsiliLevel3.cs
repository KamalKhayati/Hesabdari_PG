using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpGroupTafsiliLevel3
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        ////[Required]
        ////public int Level1Id { get; set; }
        //[Required, MaxLength(50)]
        //public string Level1Name { get; set; }
        [Required]
        public int Level2Id { get; set; }
        //[Required, MaxLength(50)]
        //public string Level2Name { get; set; }
        [Required]
        public long StartCode { get; set; }
        [Required]
        public long EndCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        public virtual EpGroupTafsiliLevel2 EpGroupTafsiliLevel2 { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsili1 { get; set; }
    }
}
