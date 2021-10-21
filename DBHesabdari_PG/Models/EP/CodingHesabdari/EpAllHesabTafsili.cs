using DBHesabdari_PG.Models.AK;
using DBHesabdari_PG.Models.EP.CodingAnbar;
using DBHesabdari_PG.Models.FK;
using DBHesabdari_PG.Models.FK.Tanzimat;
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
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [Required]
        public long Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int GroupTafsiliId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        //[Required]
        //public int MoinId { get; set; }
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
        public virtual EpHesabTafsiliAnbarha EpHesabTafsiliAnbarha1 { get; set; }
        public virtual EpHesabTafsiliSayer EpHesabTafsiliSayer1 { get; set; }

        //public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozaneh1s { get; set; }
        //public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozaneh2s { get; set; }
        //public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozaneh3s { get; set; }
        public virtual ICollection<EpListAnbarha> EpListAnbarha1s { get; set; }
        public virtual ICollection<EpListAnbarha> EpListAnbarha2s { get; set; }
        public virtual ICollection<EpListAnbarha> EpListAnbarha3s { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz1_Beds { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz2_Beds { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz3_Beds { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz1_Bess { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz2_Bess { get; set; }
        public virtual ICollection<FkAmaliatFrooshVKharid_Riz> FkAmaliatFrooshVKharid_Riz3_Bess { get; set; }
        public virtual ICollection<AKAmaliatAnbarVKala_Riz> AKAmaliatAnbarVKala_Riz1s { get; set; }
        public virtual ICollection<AKAmaliatAnbarVKala_Riz> AKAmaliatAnbarVKala_Riz2s { get; set; }
        public virtual ICollection<AKAmaliatAnbarVKala_Riz> AKAmaliatAnbarVKala_Riz3s { get; set; }
        public virtual ICollection<FKTanzimatFactor> FKTanzimatFactor1s { get; set; }
        public virtual ICollection<FKTanzimatFactor> FKTanzimatFactor2s { get; set; }
        public virtual ICollection<FKTanzimatFactor> FKTanzimatFactor3s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Kh1s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Kh2s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Kh3s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Fr1s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Fr2s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala_Fr3s { get; set; }
    }

}
