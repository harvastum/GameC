using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class WoodArmor : Item
    {
        // extra reduction of magic damage
        public WoodArmor() : base("item0011")
        {
            PublicName = "Wood Armor";
            PublicTip = "gives some protection, but be careful around fire";
            GoldValue = 15;
            ArMod = 30;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "fire")
            {
                pack.HealthDmg = 2 * pack.HealthDmg ;
            }
            return pack;
        }
    }
}