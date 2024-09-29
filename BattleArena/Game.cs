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
        Item[] maininventory = new Item[2];
        Item[] playerinventory = new Item[2];
        private bool _winner = false;
        
        /// <summary>
        /// Gets input for a 2 choice question
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
        /// <summary>
        /// Gets input for a 3 choice question
        /// </summary>
        int GetInput(string description, string option1, string option2 , string option3)
        {
            ConsoleKeyInfo key;
            int inputRecieved = 0;
            while (inputRecieved != 1 && inputRecieved != 2 && inputRecieved !=3)
            {
                // Print option
                Console.Clear();
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
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
                else if (key.KeyChar == '3')
                {
                    inputRecieved = 3;
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
            Wand icewand = new Wand("Ice Wand", 10, 0, 3, 10, "Shoots ice spike at enemy");
            Wand firewand = new Wand("Fire Wand", 10, 0, 3, 10, "Shoots a fireball at enemy");
            Shield dragonshield = new Shield("Dragon Shield", 0, 50, 3, 50, "Gives player more shield");
            player = new Player(name: "Scarletta", maxHealth: 25, attackPower: 5, defensePower: 5, gold: 5);
            goblin = new Enemy(name: "Goblin", maxHealth: 10, attackPower: 3, defensePower: 1,gold: 10);
            orc = new Enemy(name: "Orc", maxHealth: 25, attackPower: 6, defensePower: 2,gold: 20);
            dragon = new Enemy(name: "Dragon", maxHealth: 100, attackPower: 10, defensePower: 6,gold: 1000);
            Console.WriteLine("Welcome to the Arena");
            player.PrintStats();
            Console.WriteLine();
            int awnser = GetInput("Would you like a Wand or a Sheild", "Wand", "Shield");
            if (awnser == 1)
            {
                Console.WriteLine("You got a wand");
                playerinventory[0] = icewand;
            }
            else if (awnser == 2)
            {
                Console.WriteLine("You got a shield");
                playerinventory[0] = dragonshield;
            }
            player.PrintInventory(playerinventory);
           
            
            Console.WriteLine();
            Console.ReadKey();
           
            
        }
        private void Update()
        {
           
            BattleLoop(ref player, goblin);
            BattleLoop(ref player, orc);
            BattleLoop(ref player, dragon);
            if (player.Health != 0)
            {
                _winner = true;

            }
            _gameOver = true;
        }
        private void End()
        {
            if (_winner == true)
            {
                Console.Clear();
                Console.WriteLine("Congratulations on beating the arena");


            }
            if (_winner == false)
            {
                Console.Clear();
                Console.WriteLine("You are dead");
                
            }

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
        private void BattleLoop(ref Player player, Enemy enemy)
        {
            bool dead = false;

            Console.WriteLine("Your opponent is a " + enemy.Name);
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
            while (!dead)
            {
                // Player attacks
                PlayerTurn(ref player, ref enemy);
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
                // when the enemy dies 
                else if (enemy.Health == 0)
                {
                    Console.Clear();

                    BattleResults(ref player, enemy);
                    dead = true;
                    Console.ReadKey();
                    Console.Clear();
                }
                //when the player dies
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
        /// <summary>
        /// Function to execute player input for 3 choices
        /// </summary>
        private void AttackRequest(ref Player player, ref Enemy enemy)
        {
            int attack = GetInput("Will you Attack, Heal, or Use Item", "Attack", "Heal", "Use Item");
            if (attack == 1)
            {
                player.Attack(enemy);

            }
            else if (attack == 2)
            {
                player.Heal(10);
            
            }  
            else if(attack == 3)
            {
                player.UseItem(playerinventory, ref player);
                
                
            }
          
           

        }
        /// <summary>
        /// Displays the Final results and pays the player
        /// </summary>
        private void BattleResults(ref Player player, Enemy enemy)
        {
            Console.WriteLine("Congratulations on defeating " + enemy.Name);
            Console.WriteLine();
            enemy.Defeated(ref player);
            Console.WriteLine("You got " + enemy.Gold + " Gold");
            Console.WriteLine();
            player.PrintStats();
        }
        /// <summary>
        /// Player Attacks
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        private void PlayerTurn(ref Player player, ref Enemy enemy)
        {


            AttackRequest(ref player, ref enemy);
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
            AttackRequest(ref player, ref enemy);
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
            AttackRequest(ref player, ref enemy);
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();

            




        }
    }
}
