using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Game
    {

        private bool _gameOver = false;
        Player player;
        Enemy goblin;
        Enemy orc;
        Enemy dragon;
        Item[] inventory = new Item[1];
        
        /// <summary>
        /// Gets input from the player
        /// </summary>
        
        int GetInput(string description, string option1, string option2)
        {
            ConsoleKeyInfo key;
            int inputRecieved = 0;
            while (inputRecieved != 1 && inputRecieved != 2)
            {
                // Print option
                Console.Clear();
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");
                // Get input from player
                key = Console.ReadKey();
                
                // if first option
                if (key.KeyChar == '1')
                {
                    // set input recieved to 1
                    inputRecieved = 1;
                }
                // otherwise if second option
                else if (key.KeyChar == '2')
                {
                    // set input recieved to 2
                    inputRecieved = 2;
                }
                // Else neither
                else
                {
                    // Display error message
                    Console.WriteLine("\nInvalid Input");
                    Console.ReadKey();
                }
                
            }
            Console.WriteLine();
            return inputRecieved;
        }
        
     
        
        private void Start()
        {
            Wand icewand = new Wand("Ice wand", 10, 0, 3, 10, "Shoots ice spike at enemy");
            inventory[0] = icewand;

            player = new Player(name: "Scarletta", maxHealth: 25, attackPower: 5, defensePower: 5, gold: 5);
            goblin = new Enemy(name: "Goblin", maxHealth: 10, attackPower: 3, defensePower: 1,gold: 10);
            orc = new Enemy(name: "Orc", maxHealth: 25, attackPower: 6, defensePower: 2,gold: 20);
            dragon = new Enemy(name: "Dragon", maxHealth: 200, attackPower: 20, defensePower: 10,gold: 1000);
            Console.WriteLine("Welcome to the Arena");
            player.PrintStats();
            Console.WriteLine();
            
            player.PrintInventory(inventory);
           
            Console.ReadKey();
            Console.WriteLine();
            Console.ReadKey();
           
            
        }
        private void Update()
        {
           
            AttackRequest(ref player, goblin);
            AttackRequest(ref player, orc);
            AttackRequest(ref player, dragon);

            

           
            




        }
        private void End()
        {
            Console.WriteLine("You are dead");

        }



        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();
            }
            End();

        }
        /// <summary>
        /// Battle Loop for the main game
        /// </summary>
        private void AttackRequest(ref Player player, Enemy enemy)
        {
            bool dead = false;

            Console.WriteLine("Your opponent is a " + enemy.Name);
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
            while (!dead)
            {
                Console.WriteLine("Choose three times.");
                int attack1 = GetInput("Do you want to Attack or Heal", "Attack", "Heal");
                if (attack1 == 1)
                {
                    player.Attack(enemy);
                }
                else if (attack1 == 2)
                {
                    player.Heal(5);
                }
                int attack2 = GetInput("Next", "Attack", "Heal");
                if (attack2 == 1)
                {
                    player.Attack(enemy);
                }
                else if (attack2 == 2)
                {
                    player.Heal(5);
                }
                int attack3 = GetInput("Next", "Attack", "Heal");
                if (attack3 == 1)
                {
                    player.Attack(enemy);
                }
                else if (attack3 == 2)
                {
                    player.Heal(5);
                }
                // After Turn Stats
                player.PrintStats();
                Console.WriteLine();
                enemy.PrintStats();
                Console.ReadKey();
                // Enemy fights back
                if (enemy.Health != 0)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Clear();
                        player.PrintStats();
                        Console.WriteLine();
                        enemy.RandomAction(player);
                        enemy.PrintStats();
                        Console.ReadKey();


                    }
                }
                else if (enemy.Health == 0)
                {
                    Console.Clear();

                    BattleResults(ref player, enemy);
                    dead = true;
                    Console.ReadKey();
                    Console.Clear();
                }
                if(player.Health == 0)
                {
                    Console.Clear();
                    player.PrintStats();
                    dead = true;
                    _gameOver = true;
                    Console.ReadKey();
                }

            }

        }
        private void BattleResults(ref Player player, Enemy enemy)
        {
            Console.WriteLine("Congratulations on defeating " + enemy.Name);
            Console.WriteLine();
            enemy.Defeated(ref player);
            Console.WriteLine("You got " + enemy.Gold + " Gold");
            Console.WriteLine();
            player.PrintStats();
        }
    }
}
