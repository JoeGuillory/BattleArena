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
        private float _maxuses = 3;
        private float _uses = 0; 
        private int _value = 0;
        private string _discription = "";



        public string Name { get => _name; }
        public float Power { get => _power; }
        public float Armor { get => _armor; }
        public int Value { get => _value; }
        public string Discription { get => _discription; set => _discription = value; }

        public float Uses
        {
            get
            {
                return _uses;
            }
            set
            {
                _uses = Math.Clamp(value, 0, _maxuses);
            }

        }


        public Item()
        {

        }
        public Item(string name,float power,float armor,float maxuses,int value,string discritpion)
        {
            _name = name;
            _power = power;
            _armor = armor;
            _maxuses = maxuses;
            _uses = maxuses;
            _value = value;
            _discription = discritpion;

           

        }
        
        public abstract void ItemAffect(ref Player player);
       
        

    }
}
