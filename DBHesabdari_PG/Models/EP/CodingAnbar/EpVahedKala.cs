using DBHesabdari_PG.Models.AK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
  public  class EpVahedKala
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<EpTabaghehKala> EpTabaghehKalas { get; set; }
        public virtual ICollection<EpGroupAsliKala> EpGroupAsliKalas { get; set; }
        public virtual ICollection<EpGroupFareeKala> EpGroupFareeKalas { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala1s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala2s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala3s { get; set; }
        public virtual ICollection<EpNameKala> EpNameKala4s { get; set; }
        public virtual ICollection<EpAllCodingKala> EpAllCodingKalas { get; set; }
        public virtual ICollection<AkAllAmaliateRozaneh> AkAllAmaliateRozanehs { get; set; }
        public virtual ICollection<AkVorodeKala_Riz> AkVorodeKala_Rizs { get; set; }
        public virtual ICollection<AkKhorojeKala_Riz> AkKhorojeKala_Rizs { get; set; }

    }
}
