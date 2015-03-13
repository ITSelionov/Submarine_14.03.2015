using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineHW
{
    class TorpedoI: TorpedoII, ISpeed
    {
        public int nSpeedI;
        public int nCountTorpedoI;

        public TorpedoI()
        {
            nCountTorpedoI = 10;
            nSpeedI = 40;
        }

        public int CountTorpedoI
        {
            get { return nCountTorpedoI + CountTorpedoII; }
        }

        public int SpeedI
        {
            get { return nSpeedI + SpeedII; }
        }

        public void Speed()
        {
            Console.WriteLine(nCountTorpedoI + " torpedoes speed " + nSpeedI + " nodes");
        }
    }
}
