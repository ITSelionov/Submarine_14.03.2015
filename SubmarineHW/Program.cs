using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubmarineHW
{
    class Program
    {
        static void Select(int nSelect, string[] menu, Submarine submarine, Torpedo torpedo, List<string>list )
        {
            Console.Clear();

            if (nSelect == 0)
                Console.WriteLine(submarine.sName);

            if (nSelect == 1)
                Console.WriteLine("Torpedoes : " + torpedo.CountTorpedo + "\nThe average speed : " + torpedo.SpeedAVG + " nodes");

            if (nSelect == 2)
                Console.WriteLine(submarine.nFuel + " halon");

            if (nSelect == 3)
            {
                submarine.bFlag = true;
                submarine.bDirection = true;
                new Thread(submarine.Swim).Start();
                Menu(menu, submarine, torpedo, list);
            }

            if (nSelect == 4)
            {
                submarine.bFlag = false;
                Menu(menu, submarine, torpedo, list);
            }

            if (nSelect == 5)
            {
                submarine.bFlag = true;
                submarine.bDirection = false;
                new Thread(submarine.Swim).Start();
                Menu(menu, submarine, torpedo, list);
            }

            if (nSelect == 6)
            {
                if (!submarine.bFlag)
                    submarine.Refuel();
                else
                    Console.WriteLine("Please stop submarine!");
            }

            if (nSelect == 7)
                torpedo.Pointing(list);

            if (nSelect == 8)
            {
                torpedo.bCharge = true;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Ready!");
                Console.ResetColor();
            }

            if (nSelect == 9)
            {
                if (torpedo.bCharge)
                {
                    torpedo.bCharge = false;
                    submarine.Fire(list, torpedo.Goal);
                    torpedo.nTorpedo--;
                }
                else
                    Console.WriteLine("Not charged!");  
            }  
            
            Console.WriteLine("\nPress 'Backspace' for return...");
            Console.WriteLine("Press 'Enter' for exit...");

            if (Console.ReadKey().Key == ConsoleKey.Backspace)
                Menu(menu, submarine, torpedo, list);
        }

        static void Menu(string[] menu, Submarine submarine, Torpedo torpedo, List<string>list )
        {
            ConsoleKeyInfo key;
            int nSelect = 0;

            do
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    if (i == 0)
                        Console.WriteLine("Information");
                    if (i == 3)
                        Console.WriteLine("Mode of move");
                    if (i == 7)
                        Console.WriteLine("Mode of Attack");
                    Console.ResetColor();

                    if (nSelect == i)
                    {
                        Console.Write(" ► ");
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(menu[i]);
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine(String.Concat("   ", menu[i]));
                }

                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (nSelect <= 0)
                            nSelect = menu.Length - 1;
                        else
                            nSelect--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (nSelect >= menu.Length - 1)
                            nSelect = 0;
                        else
                            nSelect++;
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);

            Select(nSelect, menu, submarine, torpedo, list);
        }

        static void Main(string[] args)
        {
            string[] menu = {
                "Name",
                "The number of torpedoes",
                "Fuel",
                "Start moving forward",
                "Stop",
                "Start moving back",
                "Refueling (only in stop mode)",
                "Destination search",
                "The charge launcher apparatus (torpedoes)",
                "Attack"
            };

            var submarine = new Submarine();
            var torpedo = new Torpedo();

            List<string> goalList = new List<string>
            {
                "Type \"Seawolf\"",
                "Type \"Virginia\"",
                "Project 885",
                "Project 955",
                "Type \"Los Angeles\""
            };

            Menu(menu, submarine, torpedo, goalList);
        }
    }
}
