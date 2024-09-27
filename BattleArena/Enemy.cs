using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Enemy : Character
    {

        public Enemy(string name, float maxHealth, float attackPower, float defensePower, int gold) : base (name,maxHealth,attackPower,defensePower,gold)
        {
        }
        
        public float Attack(Player player)
        {
            float damage = Math.Max(0, AttackPower - player.DefensePower);
            player.Health -= damage;
            return damage;
        }
        public void Defeated(ref Player player)
        {
            player.Gold += Gold;

        }
        public void RandomAction(Player player)
        {

            Random random = new Random();

            int action = random.Next(1, 11);
            if (action <= 6)
            {
                Attack(player);
            }
            if (action  >= 7)
            {
                Heal(3);
            }
           
           


        }
    }
}