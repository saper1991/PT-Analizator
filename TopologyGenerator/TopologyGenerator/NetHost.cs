using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopologyGenerator
{
    public class NetHost
    {
        private string FileName;
        public List<HostRecord> ListOfRecords = new List<HostRecord>();
        private string[] Hosts;
        private Boolean router;
        public ToolTip tip = new ToolTip();
        public ToolTip adresstip1 = new ToolTip();
        public ToolTip adresstip2 = new ToolTip();
        public List<Label> labelList = new List<Label>();

        public NetHost(string FileName, Boolean router)
        {
            this.FileName = FileName;
            this.router = router;
        }

        public void addRecord(HostRecord input)
        {
            ListOfRecords.Add(input);
        }

        public Boolean GetIfRouter()
        {
            return router;
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
