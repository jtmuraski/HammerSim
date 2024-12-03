using HammerSimAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerSimAPI.Models.Units;

namespace HammerSimAPI.Models.UiModels
{
    /// <summary>
    /// Warhammer 40K Squad or characters for use with the UI
    /// </summary>
    public class UiUnit
    {
        // ---Properties---
        public int Id { get; set; }

        [Required]
        [Length(3, 150, ErrorMessage = "Name must be between 3 and 150 characters")]
        public string Name { get; set; }

        [Required]
        public MainFactions Faction { get; set; }

        [Required]
        public SubFactions SubFaction { get; set; }

        [Required]
        [Range(1, 30, ErrorMessage = "Model Count must be between 1 and 30")]
        public int ModelCount { get; set; }

        [Required]
        [Range(1, 24, ErrorMessage = "Movement must be between 1 and 24")]
        public int Movement { get; set; }

        public int Toughness { get; set; }
        public int ArmorSave { get; set; }
        public int InvulnerableSave { get; set; }
        public int Wounds { get; set; }
        public int Leasership { get; set; }
        public int ObjectiveControl { get; set; }
        public List<RangedWeapon>? RangedWeapons { get; set; }
        public List<MeleeWeapon>? MeleeWeapons { get; set; }
        public List<Wargear>? Wargear { get; set; }
        public List<UnitKeywords>? UnitKeywords { get; set; }

        public UiUnit()
        {
            RangedWeapons = new List<RangedWeapon>();
            MeleeWeapons = new List<MeleeWeapon>();
            Wargear = new List<Wargear>();
            UnitKeywords = new List<UnitKeywords>();
            Name = string.Empty;
        }
    }
}
