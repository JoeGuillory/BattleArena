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
            if(Uses != 0)
            {
                player.AttackPower += Power;
                Uses -= 1;
            }
            else if (Uses == 0)
            {
                Console.WriteLine("Out of uses");

            }
            
           
        }




    }
}
