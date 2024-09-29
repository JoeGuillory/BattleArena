using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Shield : Item
    {
        public Shield(string name, float power, float armor, float maxuses, int value, string discription) : base(name, power, armor, maxuses, value, discription)
        {

        }
        /// <summary>
        /// Shield affects player armor
        /// </summary>
     
        public override void ItemAffect(ref Player player)
        {
            player.DefensePower += Armor;
        }

    }
}
