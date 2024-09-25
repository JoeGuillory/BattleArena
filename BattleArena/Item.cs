using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal abstract class Item
    {
        private string _name = "Item";
        private float _power = 0;
        private float _armor = 0;
        private int _value = 0;



        public string Name { get => _name; set => _name = value; }
        public float Power { get => _power; set => _power = value; }
        public float Armor { get => _armor; set => _armor = value; }
        public int Value { get => _value; set => _value = value; }


        public Item(string name,float power,float armor,int value)
        {
            name = Name;
            power = Power;
            armor = Armor;
            value = Value;

        }

        public abstract void ItemAffect();
       
        

    }
}
