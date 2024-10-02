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
        
       
        public void UseItem(Item[] item,ref Player player)
        {
            PrintInventory(item);
            Console.ReadKey();
            
            item[0].ItemAffect(ref player);


        }
        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    continue;
                }
                int count = 1;
                Console.WriteLine();
                Console.WriteLine("Inventory");
                Console.WriteLine("-------------------");
                Console.WriteLine(count + ". " + inventory[i].Name + " -"  + "Uses: " + inventory[i].Uses);
                Console.WriteLine("   " + inventory[i].Discription);
                count++;
            }

        }
       
 
        public float Attack(Enemy enemy)
        {
            float damage = Math.Max(0, AttackPower - enemy.DefensePower);
            enemy.Health -= damage;
            return damage;
        }

      

    }
}
