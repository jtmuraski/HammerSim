using HammerSimAPI.Models.Units;
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
        public int Id { get; set; }
        public int TotalShotsFired
        {
            get { return IndividualWeaponResults.Sum(x => x.ShotsFired); }
        }
           
        public int TotalHits
        {
            get {return IndividualWeaponResults.Sum(x => x.Hits); }
        }
        public int TotalMisses
        {
            get { return TotalShotsFired - TotalHits; }
        }
        public int TotalWounds
        {
            get { return IndividualWeaponResults.Sum(x => x.Wounds); }
        }
        public int TotalSaves
        {
            get { return IndividualWeaponResults.Sum(x => x.Saves); }
        }
        public int DefendingModelsKilled
        {
            get { return IndividualWeaponResults.Sum(x => x.ModelsKilled); }
        }
        public List<RangedWeaponResult> IndividualWeaponResults { get; set;}
        public List<RangedWeapon> OutOfRangeWeapons { get; set; }
        //public Dictionary<int, int> AttackDiceDistribution { get; set; }

        public ShootingResults()
        {
            IndividualWeaponResults = new List<RangedWeaponResult>();
            OutOfRangeWeapons = new List<RangedWeapon>();
            //AttackDiceDistribution = new Dictionary<int, int>()
            //{
            //    {1, 0},
            //    {2, 0},
            //    {3, 0},
            //    {4, 0},
            //    {5, 0},
            //    {6, 0}
            //};
        }
    }
}
