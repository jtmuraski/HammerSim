using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerSimAPI.Models.Units;

namespace HammerSimAPI.Models.Data
{
    public class RangedWeaponResult
    {
        // ---Propeties---
        public RangedWeapon Weapon { get; set; }
        public int ShotsFired { get; set; }
        public int Hits { get; set; }
        public int Wounds { get; set; }
        public int Saves { get; set; }
        public int ModelsKilled { get; set; }
    }
}
