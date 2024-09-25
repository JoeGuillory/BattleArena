using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Player : Character
    {
        public Player(string name, float maxHealth, float attackPower, float defensePower, int gold) : base (name, maxHealth, attackPower, defensePower, gold)
        {

        }

        public float Attack(Enemy enemy)
        {
            float damage = Math.Max(0, AttackPower - enemy.DefensePower);
            enemy.Health -= damage;
            return damage;
        }

    }
}
