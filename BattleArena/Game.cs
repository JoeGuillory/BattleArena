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
        Character player;
        Character enemy;

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
            
            player = new Character(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
            enemy = new Character(name: "Enemy", maxHealth: 100, attackPower: 9, defensePower: 5);
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
        }
        private void Update()
        {
            
           if (GetInput("Would you like to attack or heal", "Attack","Heal") == 1)
           {
                player.Attack(enemy);

           }
           else
           {
                player.Heal(10);
           }

        }
        private void End()
        {


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
    }
}
