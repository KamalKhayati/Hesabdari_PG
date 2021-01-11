using DBHesabdari_PG.Models.AK;
using DBHesabdari_PG.Models.EP.CodingHesabdari;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
   public class EpListAnbarha
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [Required]
        public int IndexNoeAnbar { get; set; }
        [MaxLength(20)]
        public string NoeAnbar { get; set; }
        [Required]
        public bool MojavezMojodiManfi { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string SharhHesab { get; set; }
        [Required]
        public int MoinId { get; set; }
        [Required]
        public int TafsiliId1 { get; set; }
        [Required]
        public int TafsiliId2 { get; set; }
        [Required]
        public int TafsiliId3 { get; set; }
        public string TabagheKalaId { get; set; }
        public string TabagheKalaName { get; set; }


        [NotMapped]
        public string TabagheKalaIdName_NM { get; set; }

        public virtual ICollection<R_EpListAnbarha_B_EpTabaghehKala> R_EpListAnbarha_B_EpTabaghehKalas { get; set; }
        public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozaneh1s { get; set; }
        public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozaneh2s { get; set; }
        public virtual ICollection<AkVorodeKala_Riz> AkVorodeKala_Riz1s { get; set; }
        public virtual ICollection<AkVorodeKala_Riz> AkVorodeKala_Riz2s { get; set; }
        public virtual ICollection<AkKhorojeKala_Riz> AkKhorojeKala_Riz1s { get; set; }
        public virtual ICollection<AkKhorojeKala_Riz> AkKhorojeKala_Riz2s { get; set; }
        public virtual EpHesabMoin1 EpHesabMoin1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili1 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili2 { get; set; }
        public virtual EpAllHesabTafsili EpAllHesabTafsili3 { get; set; }

    }

    public class R_EpListAnbarha_B_EpTabaghehKala
    {
        //[Column(Order = 0)]
        // public int Id { get; set; }
        [Required, Column(Order = 1)]
        public int SalId { get; set; }
        [Key]
        [Required, Column(Order = 2)]
        public int AnbarhId { get; set; }
        [Key]
        [Required, Column(Order = 3)]
        public int TabagheKalaId { get; set; }
        public virtual EpListAnbarha EpListAnbarha1 { get; set; }
        public virtual EpTabaghehKala EpTabaghehKala1 { get; set; }
    }

}
