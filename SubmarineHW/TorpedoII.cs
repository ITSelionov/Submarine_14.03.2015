using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineHW
{
    class TorpedoII: TorpedoIII, ISpeed
    {
        public int nSpeedII;
        public int nCountTorpedoII;

        public TorpedoII()
        {
            nSpeedII = 50;
            nCountTorpedoII = 10;
        }

        public int CountTorpedoII
        {
            get { return nCountTorpedoII + CountTorpedoIII; }
        }

        public int SpeedII
        {
            get { return nSpeedII + SpeedIII; }
        }

        public void Speed()
        {
            Console.WriteLine(nCountTorpedoII + " torpedoes speed " + nSpeedII + " nodes");
        }
    }
}
