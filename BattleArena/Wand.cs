using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Wand : Item
    {
       
        public Wand(string name, float power, float armor,float maxuses, int value, string discription) : base(name, power, armor,maxuses, value, discription)
        {
            
        }

        /// <summary>
        /// Wand affect adds more damage to player
        /// </summary>
        public override void ItemAffect(ref Player player)
        {
            player.AttackPower += Power;
            
           
        }




    }
}
