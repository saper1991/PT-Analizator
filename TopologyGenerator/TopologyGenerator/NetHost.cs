using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologyGenerator
{
    public class NetHost
    {
        private string FileName;
        public List<HostRecord> ListOfRecords = new List<HostRecord>();
        private string[] Hosts;

        public NetHost(string FileName)
        {
            this.FileName = FileName;
        }

        public void addRecord(HostRecord input)
        {
            ListOfRecords.Add(input);
        }

        public string GetFileName()
        {
            return FileName;
        }

        public void SetHosts(string[] input)
        {
            Hosts = input;
        }

        public string GetHosts(int index)
        {
            if(index < Hosts.Length)
            {
                return Hosts[index];
            }
            else
            {
                return null;
            }
        }

        public string[] GetHosts()
        {
            return Hosts;
        }

    }
}
