using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedSpells
{
    [Serializable]
    class EarthBolt : Skill
    {
        public static string type = "fire";
        public EarthBolt() : base("Earth Bolt", 20, 4)
        {
            PublicName = $"{Name}: a chance equal to your Precision/2  to land 1*MP damage [{type}]";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(type);
            if (Index.RNG(0, 100) < player.Precision / 2)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = $"You use {Name}! {(int)(1 * player.MagicPower)} {type} damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = $"You try to use {Name} but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}