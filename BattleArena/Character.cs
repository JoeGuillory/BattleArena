using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Character
    {
        private string _name = "Character";
        private float _maxHealth = 10;
        private float _health = 10;
        private float _attackPower = 1;
        private float _defensePower =1;
        private int _gold = 10; 

        public float Health
        {
            get
            {
              return _health;
            }
            set
            {
                _health = Math.Clamp(value, 0, _maxHealth);
            }
        }
        
       
        public float AttackPower { get { return _attackPower; } set { _attackPower = value; } }
        public float DefensePower { get { return _defensePower; } set { _defensePower = value;} }
        public string Name { get { return _name; } }
        public float MaxHealth { get { return _maxHealth; } }
        public int Gold { get { return _gold; } set { _gold = Math.Max(0, value); } }
        public Character()
        {

        }
        public Character(string name, float maxHealth, float attackPower,float defensePower, int gold)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
            _gold = gold;

        }
       

        public void TakeDamage(float damage)
        {

            Health -= damage;
            if (Health == 0)
            {
                Die();
            }
        }
        public void Heal(float health)
        {
            Health += health;
        }

        private void Die()
        {
            Console.WriteLine(Name + " has died!");
        }
        public void PrintStats()
        {
            Console.WriteLine("Name:            " + Name);
            Console.WriteLine("Health:          " + Health + "/" + MaxHealth);
            Console.WriteLine("Attack Power:    " + AttackPower);
            Console.WriteLine("Defense Power:   " + DefensePower);
            Console.WriteLine("Gold:            " + Gold);
        }
    }
}
