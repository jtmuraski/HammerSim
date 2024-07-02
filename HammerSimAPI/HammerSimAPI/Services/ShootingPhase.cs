using HammerSimAPI.Models.Data;
using HammerSimAPI.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSimAPI.Services
{
    public static class ShootingPhase
    {
        /// <summary>
        /// calculate the results of a shooitng phase and return the results
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static ShootingResults ResolveShootingPhase(Unit attacker, Unit defender, int range)
        {
            ShootingResults results = new ShootingResults();

            foreach(var weapon in attacker.RangedWeapons)
            {
                RangedWeaponResult result = new RangedWeaponResult();
                if(weapon.Range >= range)
                {
                    result.Hits = RollAttacks(attacker, defender, weapon, results);
                    int tempWounds = RollForWounds(attacker, weapon, defender, result.Hits);
                    result.Saves = RollSaves(attacker, weapon, defender, result.Hits);
                    result.Wounds = tempWounds - result.Saves;
                    result.ModelsKilled = CalculateModelsKilled(result.Wounds, defender);
                    results.IndividualWeaponResults.Add(result);
                }
                else
                {
                    results.OutOfRangeWeapons.Add(weapon);
                }
            }

            return results;
        }

        private static int RollAttacks(Unit attacker, Unit defender, RangedWeapon weapon, int modifier, ShootingResults results)
        {
            int numOfAttacks = weapon.Attacks * weapon.NumOfWeapons;
            int hits = 0;
            int misses = 0;
            int currentRoll = 0;

            for(int i = 0; i < numOfAttacks; i++)
            {
                currentRoll = RollD6();

                if (currentRoll == 1)
                    misses++;
                else if (currentRoll == 6)
                    hits++;
                else if (currentRoll + modifier >= weapon.WeaponSkill)
                    hits++;
                else
                    misses++;

                results.AttackDiceDistribution[currentRoll] = results.AttackDiceDistribution[currentRoll] + 1;
            }

            results.TotalShotsFired += numOfAttacks;
            return hits;
        }
    }
}
