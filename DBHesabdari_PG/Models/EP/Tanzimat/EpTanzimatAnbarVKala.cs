using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.EP.Tanzimat
{
    public class EpTanzimatAnbarVKala
    {
        public int Id { get; set; }
        [Required]
        public int SalId { get; set; }

        [Required]
        public int CodeAnbarCarakter { get; set; }
        [Required]
        public int CodeTabagehKalaCarakter { get; set; }
        [Required]
        public int CodeGroupAsliKalaCarakter { get; set; }
        [Required]
        public int CodeGroupFareeKalaCarakter { get; set; }
        [Required]
        public int CodeNameKalaCarakter { get; set; }
        [Required]
        public int CodeVahedKalaCarakter { get; set; }

        [Required, MaxLength(3)]
        public string CodeAnbarMinCode { get; set; }
        [Required, MaxLength(3)]
        public string CodeAnbarMaxCode { get; set; }

        [Required, MaxLength(4)]
        public string CodeTabagehKalaMinCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeTabagehKalaMaxCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeGroupAsliKalaMinCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeGroupAsliKalaMaxCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeGroupFareeKalaMinCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeGroupFareeKalaMaxCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeNameKalaMinCode { get; set; }
        [Required, MaxLength(4)]
        public string CodeNameKalaMaxCode { get; set; }

        [Required, MaxLength(3)]
        public string CodeVahedKalaMinCode { get; set; }
        [Required, MaxLength(3)]
        public string CodeVahedKalaMaxCode { get; set; }

    }
}
