using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TopologyGenerator
{
    public class NetHosts
    {
        public List<NetHost> listOfHosts = new List<NetHost>();
        public List<HostRectangle> listOfHostRectangles = new List<HostRectangle>();
 
        public void addNetHost(NetHost host)
        {
            listOfHosts.Add(host);
        }

        public List<NetHost> getListOfHosts()
        {
            return listOfHosts;
        }

        public void addSetHostRectangle(NetHost host, Rectangle rectangle)
        {
            listOfHostRectangles.Add(new HostRectangle(host, rectangle));
        }

        public class HostRectangle
        {
            public Rectangle rectangle;
            public NetHost netHost;

            public HostRectangle(NetHost netHost, Rectangle rectangle)
            {
                this.netHost = netHost;
                this.rectangle = rectangle;
            }
        }
    }
}
