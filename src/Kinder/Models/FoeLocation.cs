using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinder.Models


{
    [Table("FoeLocations")]
    public class FoeLocation
    {
        [Key]
        public int FoeLocationId { get; set; }
        public string LocationName { get; set; }
        public string FoeName { get; set; }
        public int FoeAttack { get; set; }
        public int FoeHP { get; set; }
        public int PlunderId { get; set; }
        public virtual Plunder Plunder { get; set; }

        public FoeLocation(int Id, string location, string name, int attack, int hp)
        {
            FoeLocationId = Id;
            LocationName = location;
            FoeName = name;
            FoeAttack = attack;
            FoeHP = hp;
            PlunderId = 0;
        }
    }
}
