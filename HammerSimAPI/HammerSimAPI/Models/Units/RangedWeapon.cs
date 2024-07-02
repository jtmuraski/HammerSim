using HammerSimAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSimAPI.Models.Units
{
    /// <summary>
    /// Data for a given Ranged Weapon. Each Range Weapon is unique to the unit it is assigned to.
    /// </summary>
    public class RangedWeapon
    {
        // ---Properties---
        public string? Name { get; set; }
        public int Range { get; set; }
        public int NumOfWeapons { get; set; }
        public int Attacks { get; set; }
        public int WeaponSkill { get; set; }
        public int Strength { get; set; }
        public int AP { get; set; }
        public int Damage { get; set; }
        public List<RangedWeaponKeywords> WeaponKeywords { get; set; } = new List<RangedWeaponKeywords>();

        public RangedWeapon()
        {
            WeaponKeywords = new List<RangedWeaponKeywords>();
        }
    }
}
