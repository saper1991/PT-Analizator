using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologyGenerator
{
    class Topology
    {
        private int[,] matrix;
        private string[] hosts;

        public Topology(Matrix input)
        {
            this.matrix = input.getMatrix();
            this.hosts = input.getHosts();
        }
    }
}
