using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.CodingAnbar
{
    public class EpTaminKonandeKala
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<R_EpTaminKonandeKala_EpNameKala> R_EpTaminKonandeKala_EpNameKalas { get; set; }

    }
    public class R_EpTaminKonandeKala_EpNameKala
    {
        [Key]
        [Column(Order = 0)]
        public int TKId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int NKId { get; set; }
        public virtual EpTaminKonandeKala EpTaminKonandeKala1 { get; set; }
        public virtual EpNameKala EpNameKala1 { get; set; }
    }
}
