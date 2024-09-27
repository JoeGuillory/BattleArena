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

        public string Discription { get => _discription; set => _discription = value; }
        
        public Wand(string name, float power, float armor,float maxuses, int value, string discription) : base(name, power, armor,maxuses, value)
        {
            discription = Discription;


        }


        public override void ItemAffect()
        {



        }




    }
}
