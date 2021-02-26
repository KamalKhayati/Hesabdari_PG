using DBHesabdari_PG.Models.Ms.SystemUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHesabdari_PG.Models.Tz
{
    public class TzTanzimatSystem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KeyId { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        public string LevelName { get; set; }
        [Required]
        public bool IsSetAllUser { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        [MaxLength(500)]
        public string UserId { get; set; }


        public virtual ICollection<R_MsUser_B_TzTanzimatSystem> R_MsUser_B_TzTanzimatSystems { get; set; }
    }
}
