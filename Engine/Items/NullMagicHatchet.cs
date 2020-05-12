using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class NullMagicHatchet : Axe
    {
        public NullMagicHatchet() : base("item0010")
        {
            IsAxe = true;
            HpMod = 50;
            StrMod = 120;
            PrMod = -5;
            GoldValue = 225;
            PublicName = "Null-Magic Hatchet";
            PublicTip = "A hatchet that does not tolerate any magic.";

        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.MagicMultiplier = 0;
            return pack;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            base.ApplyBuffs(currentPlayer, otherItems);
            currentPlayer.MagicPower = 0;
        }
    }
}
