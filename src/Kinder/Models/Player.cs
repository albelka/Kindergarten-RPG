using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinder.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAttack { get; set; } = 3;
        public int PlayerHP { get; set; } = 10;
        public int PlayerDefense { get; set; } = 0;
        public int Shield { get; set; } = 0;
        public int Weapon { get; set; } = 0;
        public int Armour { get; set; } = 0;
        public int Potion { get; set; } = 1;
        public string ImageURI { get; set; }
        public virtual Plunder Plunder { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
