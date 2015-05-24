using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologyGenerator
{
    public class HostRecord
    {
        private string ethName = null;
        private string ethMAC = null;
        private string consMAC = null;
        public bool isPlugged = false;

        public HostRecord(string ethName, string ethMAC, string consMAC, bool isPlugged)
        {
            this.ethName = ethName;
            this.ethMAC = ethMAC;
            this.consMAC = consMAC;
            this.isPlugged = isPlugged;
        }

        public string GetCons()
        {
            return consMAC;
        }

        public string GetEthMAC()
        {
            return ethMAC;
        }

        private string GetEthName()
        {
            return ethName;
        }
    }
}
