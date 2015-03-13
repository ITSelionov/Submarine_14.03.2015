using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineHW
{
    class TorpedoIII: ISpeed
    {
        public int nCountTorpedoIII;
        public int nSpeedIII;

        public TorpedoIII()
        {
            nSpeedIII = 70;
            nCountTorpedoIII = 10;
        }

        public int CountTorpedoIII
        {
            get { return nCountTorpedoIII; }
        }

        public int SpeedIII
        {
            get { return nSpeedIII; }
        }

        public void Speed()
        {
            Console.WriteLine(nCountTorpedoIII + " torpedoes speed " + nSpeedIII + " nodes");
        }
    }
}
