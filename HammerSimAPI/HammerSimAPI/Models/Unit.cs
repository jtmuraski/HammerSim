using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSimAPI.Models
{
    /// <summary>
    /// Warhammer 40K Squad or character datasheet
    /// </summary>
    public class Unit
    {
        public string Name { get; set; }
        public string Faction { get; set; }
        public string SubFaction { get; set; }
        public int ModelCount { get; set; } 

    }
}
