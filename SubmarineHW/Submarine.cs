using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace SubmarineHW
{
    class Submarine : ISwim, IFire
    {
        public string sName;
        public int nFuel;
        public bool bFlag;
        public bool bDirection;

        public Submarine()
        {
            sName = "К-141 \"Kursk\"";
            nFuel = 25000;
            bFlag = false;
            bDirection = true;
        }

        public void Swim()
        {
            while (true)
            {
                if (nFuel <= 0 || !bFlag)
                {
                    if (nFuel <= 0)
                        bFlag = false;
                    break;
                }

                if (bDirection)
                    Console.Beep(8000, 333);

                if (!bDirection)
                    Console.Beep(6000, 500);

                nFuel -= 250;
            }
        }

        public void Refuel()
        {
            nFuel = 25000;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Filled!\n");
            Console.ResetColor();
        }

        public void Fire(List<string> goalList, int value)
        {
            goalList.RemoveAt(value);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Destroyed!");
            Console.ResetColor();
        }
    }
}
