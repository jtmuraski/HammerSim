using HammerSimAPI.Models.Data;
using HammerSimAPI.Models.Units;
using HammerSimAPI.Utilities;
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
                    int modifier = 0;
                    result.Hits = RollAttacks(attacker, defender, weapon, modifier, results);

                    int tempWounds = RollForWounds(attacker, weapon, defender, result.Hits);

                    result.Saves = RollSaves(attacker, weapon, defender, tempWounds);

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
                currentRoll = Dice.RollD6();

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

        private static int RollForWounds(Unit attacker, RangedWeapon weapon, Unit defender, int hits)
        {
            int wounds = 0;
            
            for(int i = 0; i < hits; i++)
            {
                int currentRoll = Dice.RollD6();
                int woundSuccessValue = 0;
                if(weapon.Strength >= defender.Toughness * 2)
                    woundSuccessValue = 2;
                else if(weapon.Strength > defender.Toughness)
                    woundSuccessValue = 3;
                else if(weapon.Strength == defender.Toughness)
                    woundSuccessValue = 4;
                else if(weapon.Strength < defender.Toughness)
                    woundSuccessValue = 5;
                else
                    woundSuccessValue = 6;

                if(currentRoll == 6)
                    wounds++;
                else
                    wounds += currentRoll >= woundSuccessValue ? 1 : 0;
            }

            return wounds;
        }

        private static int RollSaves(Unit attacker, RangedWeapon weapon, Unit defender, int wounds)
        {
            int saves = 0;

            for(int i = 0; i < wounds;i++)
            {
                int currentRoll = Dice.RollD6();
                if(currentRoll > 1)
                {
                    int modifiedRoll = currentRoll - weapon.AP;
                    int saveValue = 0;
                    if(defender.InvulnerableSave > 0)
                    {
                        saveValue = defender.InvulnerableSave < defender.Save ? defender.InvulnerableSave : defender.Save;
                    }
                    else
                    {
                        saveValue = defender.Save;
                    }

                    if (modifiedRoll >= saveValue)
                    {
                        saves++;
                    }
                }
            }

            return saves;
        }

        private static int CalculateModelsKilled(int wounds, Unit defender)
        {
            int modelsKilled = 0;
            int woundCounter = wounds;
            while(woundCounter >= defender.Wounds)
            {
                woundCounter -= defender.Wounds;
                modelsKilled++;
            }

            return modelsKilled;
        }
    }
}
