using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedSpells
{
    [Serializable]
    class ElephantBolt : Skill
    {
        public static string type = "elephant";
        public ElephantBolt() : base("Elephant Bolt", 20, 3)
        {
            PublicName = $"{Name}: a chance equal to your Precision/2  to land 1*MP damage [{type}] Decimates elephants.";
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