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
                    result.Hits = RollAttacks(attacker, weapon, defender);
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
    }
}
