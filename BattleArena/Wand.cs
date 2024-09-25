using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Wand : Item
    {
        private string _discription = "";
        
        public Wand(string name, float power, float armor,float maxuses, int value, string discription) : base(name, power, armor,maxuses, value)
        {
            discription = _discription;



        }


        public override void ItemAffect()
        {



        }




    }
}
