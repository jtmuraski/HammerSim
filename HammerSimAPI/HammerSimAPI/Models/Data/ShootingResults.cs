﻿using HammerSimAPI.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSimAPI.Models.Data
{
    public class ShootingResults
    {
        // ---Properties---
        public int TotalShotsFired { get; set; }
        public int TotalHits { get; set; }
        public int TotalWounds { get; set; }
        public int TotalSaves { get; set; }
        public int DefendingModelsKilled { get; set; }
        public List<RangedWeaponResult> IndividualWeaponResults { get; set;}
        public List<RangedWeapon> OutOfRangeWeapons { get; set; }
        public Dictionary<int, int> AttackDiceDistribution { get; set; }

        public ShootingResults()
        {
            IndividualWeaponResults = new List<RangedWeaponResult>();
            OutOfRangeWeapons = new List<RangedWeapon>();
            TotalShotsFired = 0;
            TotalHits = 0;
            TotalWounds = 0;
            TotalSaves = 0;
            DefendingModelsKilled = 0;
            AttackDiceDistribution = new Dictionary<int, int>()
            {
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0}
            };
        }
    }
}
