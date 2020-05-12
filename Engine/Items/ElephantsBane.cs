using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class ElephantsBane : Staff
    {
        

        public ElephantsBane() : base("item0009")
        {
            HpMod = 100;
            MgcMod = 50;
            GoldValue = 500;
            PublicName = "Elephantsbane";
            IsStaff = true;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.DamageType = "elephant";
            return pack;
        }
    }
}
