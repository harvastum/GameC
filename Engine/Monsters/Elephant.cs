using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Elephant : Engine.Monsters.Monster
    {
        public Elephant(int level)
        {
            Health = 300 + 50 * level;
            Strength = 200 + level ;
            Armor = 100 * level / 5;
            Precision = 75 + level;
            MagicPower = 20 + level * 20;
            Stamina = 250;
            XPValue = 200 + level * 5;
            Name = "monster0007";
            BattleGreetings = "Let me just eat my leaves, man.";
        }

        public override List<StatPackage> BattleMove()
        {
            List<StatPackage> attack = new List<StatPackage>();
            if (Stamina > 50)
            {
                Stamina -= 50;
                attack.Add(new StatPackage("earth", 100 + strength / 2,
                    $"Elephant used Earthquake! It's super effective! (+{50 + magicPower / 10} fire damage!"));
            }
            else
            {
                attack.Add(new StatPackage("none", 0,
                    $"Elephant is tired."));
            }

            if (Index.RNG(0, 100) > 70)
            {
                Stamina += 30;
                attack.Add(new StatPackage("none", 0,
                    $"Elephant ate some leaves and regained stamina!"));
            }

            return attack;
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                if (pack.DamageType == "elephant")
                {
                    Health /= 2;
                    Stamina /= 2;
                }
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                MagicPower *= pack.MagicMultiplier;
                
            }
        }

    }
}