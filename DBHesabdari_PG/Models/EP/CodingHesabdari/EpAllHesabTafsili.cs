using DBHesabdari_PG.Models.EP.CodingAnbar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingHesabdari
{
   public class EpAllHesabTafsili
    {
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
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        //[Required]
        //public int SandoghId { get; set; }
        //public virtual TarifSandogh TarifSandogh1 { get; set; }
       // public virtual EpGroupTafsiliLevel1 EpGroupTafsiliLevel1 { get; set; }
        public virtual EpAllGroupTafsili EpAllGroupTafsili1 { get; set; }
        public virtual EpHesabTafsiliAshkhas EpHesabTafsiliAshkhas1 { get; set; }
        public virtual EpHesabTafsiliAghlamAnbar EpHesabTafsiliAghlamAnbar1 { get; set; }
        public virtual EpHesabTafsiliDaraeha EpHesabTafsiliDaraeha1 { get; set; }
        public virtual EpHesabTafsiliSandogh EpHesabTafsiliSandogh1 { get; set; }
        public virtual EpHesabTafsiliBankha EpHesabTafsiliBankha1 { get; set; }
        public virtual EpHesabTafsiliVam EpHesabTafsiliVam1 { get; set; }
        public virtual EpHesabTafsiliMarakezHazine EpHesabTafsiliMarakezHazine1 { get; set; }
        public virtual EpHesabTafsiliShoabat EpHesabTafsiliShoabat1 { get; set; }
        public virtual EpHesabTafsiliProzhe EpHesabTafsiliProzhe1 { get; set; }
        public virtual EpHesabTafsiliGharardad EpHesabTafsiliGharardad1 { get; set; }
        public virtual EpHesabTafsiliSayer EpHesabTafsiliSayer1 { get; set; }

        //public virtual ICollection<HaghOzviat> HaghOzviats { get; set; }
        //public virtual ICollection<AsnadeHesabdariRow> AsnadeHesabdariRows { get; set; }
        //public virtual ICollection<CheckTazmin> CheckTazmins { get; set; }
    }

}
