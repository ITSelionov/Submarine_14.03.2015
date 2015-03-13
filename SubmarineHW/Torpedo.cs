using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineHW
{
    class Torpedo : TorpedoI, IPointing, ISpeed
    {
        public int nTorpedo;
        private int nSpeedAVG;
        public int nGoal;
        public bool bCharge;
        private bool bFlag;

        public int Goal
        {
            get { return nGoal; }
            set { nGoal = value; }
        }
        public int CountTorpedo
        {
            get { return nTorpedo + CountTorpedoI; }
            set { nTorpedo = value; }
        }

        public int SpeedAVG
        {
            get { return (nSpeedAVG + SpeedI) / 3; }
        }

        public Torpedo()
        {
            nTorpedo = 0;
            bCharge = false;
            bFlag = true;
        }

        public void Pointing(List<string> goalList)
        {
            int nSelect = 0;
            bFlag = true;

            while (bFlag)
            {
                Console.Clear();
                for (int i = 0; i < goalList.Count; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    if (i == 0)
                        Console.WriteLine("Detected!");
                    Console.ResetColor();

                    if (nSelect == i)
                    {
                        Console.Write(" ► ");
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(goalList[i]);
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine(string.Concat("   ", goalList[i]));
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (nSelect <= 0)
                            nSelect = goalList.Count - 1;
                        else
                            nSelect--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (nSelect >= goalList.Count - 1)
                            nSelect = 0;
                        else
                            nSelect++;
                        break;
                    case ConsoleKey.Enter:
                        bFlag = false;
                        Goal = nSelect;
                        break;
                }
            }
        }

        public void Speed()
        {
            Console.WriteLine(nSpeedAVG);
        }
    }
}
