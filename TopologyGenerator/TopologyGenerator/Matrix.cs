using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologyGenerator
{
    public class Matrix
    {
        private int count = 0;
        private int[,] matrix = null;
        List<NetHost> hosts = null;

        public Matrix(List<NetHost> inputList)
        {
            hosts = inputList;
            count = hosts.Count;
            matrix = new int[count, count];

            for (int i = 0; i < count ; i++)
            {
                for(int j = 0 ; j < count ; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for(int i = 0 ; i < hosts.Count ; i++)
            {
                string currentHostName = hosts[i].GetFileName();
                string[] hostConnections = hosts[i].GetHosts();

                for(int j = 0 ; j < hostConnections.Length ; j++)
                {
                    int consindex = GetIndex(hostConnections[j]);

                    matrix[i, consindex] = 1;
                }
            }
        }

        private int GetIndex(string HostName)
        {
            int result = -1;

            for(int i = 0 ; i < count ; i++)
            {
                if(hosts[i].GetFileName().Contains(HostName))
                {
                    result = i;
                }
            }

            return result;
        }

        public void Display()
        {
            string mes = "";

            for(int i = 0 ; i < count ; i++)
            {
                for(int j = 0 ; j < count ; j++)
                {
                    mes += (matrix[i, j].ToString() + " ");
                }
                mes += "\n";
            }

            System.Windows.Forms.MessageBox.Show(mes);
        }

        public int[,] getMatrix()
        {
            return matrix;
        }

        public string[] getHosts()
        {
            List<string> result = new List<string>();

            for(int i = 0 ; i < hosts.Count ; i++)
            {
                result.Add(hosts[i].GetFileName());
            }
            return result.ToArray();
        }
    }
}
