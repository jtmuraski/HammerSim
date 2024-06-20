using HammerSimAPI.Models.Enums;
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
        // ---Properties---
        public string Name { get; set; }
        public MainFactions Faction { get; set; }
        public SubFactions SubFaction { get; set; }
        public int ModelCount { get; set; } 
        public int Movement { get; set; }
        public int Toughness { get; set; }
        public int Save { get; set; }
        public int InvulnerableSave { get; set; }
        public int Wounds { get; set; }
        public int Leasership { get; set; }
        public int ObjectiveControl { get; set; }
        public List<RangedWeapons>? RangedWeapons { get; set; }
        public List<MeleeWeapons>? MeleeWeapons { get; set; }
        public List<Wargear>? Wargear { get; set; }
        public List<UnitKeywords>? UnitKeywords { get; set; }

        public Unit()
        {
            RangedWeapons = new List<RangedWeapons>();
            MeleeWeapons = new List<MeleeWeapons>();
            Wargear = new List<Wargear>();
            UnitKeywords = new List<UnitKeywords>();
            Name = string.Empty;
        }
    }
}
