using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopologyGenerator
{
    public partial class MainWnd : Form
    {

        public List<NetHost> ListOfFiles = new List<NetHost>();
        private NetHosts netHosts = new NetHosts();

        public MainWnd()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.DoubleBuffered = true;
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pliki .ethan (*.ethan)|*.ethan|Wszystkie pliki (*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();

            bool exists = false;

            if (dr == DialogResult.OK)
            {

                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                NetHost newhost = null;

                for (int i = 0; i < netHosts.listOfHosts.Count; i++)
                {
                    if (netHosts.listOfHosts[i].GetFileName() == ofd.SafeFileName)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {

                    if (ofd.SafeFileName[0] == 'R')
                    {
                        newhost = new NetHost(ofd.SafeFileName, true);
                    }
                    else
                    {
                        newhost = new NetHost(ofd.SafeFileName, false);
                    }

                    while (!sr.EndOfStream)
                    {
                        string tmp = sr.ReadLine();
                        int count = 0;

                        string eth = "";
                        for (; count < tmp.Length; count++)
                        {
                            if (tmp[count] != '\t')
                            {
                                eth += tmp[count];
                            }
                            else
                            {
                                count++;
                                break;
                            }
                        }

                        string ethmac = "";
                        for (; count < tmp.Length; count++)
                        {
                            if (tmp[count] != '\t')
                            {
                                ethmac += tmp[count];
                            }
                            else
                            {
                                count++;
                                break;
                            }
                        }

                        string consmac = "";
                        for (; count < tmp.Length; count++)
                        {
                            if (tmp[count] != '\t')
                            {
                                consmac += tmp[count];
                            }
                            else
                            {
                                count++;
                                break;
                            }
                        }

                        for (; count < tmp.Length; count++)
                        {
                            if (tmp[count] != '\t')
                            {
                                eth += tmp[count];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (eth.Contains("true"))
                        {
                            eth = eth.Substring(0, 4);
                        }

                        newhost.addRecord(new HostRecord(eth, ethmac, consmac, true));

                    }

                    netHosts.addNetHost(newhost);

                    listOfFilesListBox.Items.Add(ofd.SafeFileName);
                }
                sr.Close();
                fs.Close();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            string selected = (string)listOfFilesListBox.SelectedItem;

            for (int i = 0; i < netHosts.listOfHosts.Count; i++)
            {
                if (netHosts.listOfHosts[i].GetFileName() == selected)
                {
                    netHosts.listOfHosts.RemoveAt(i);
                    break;
                }
            }

            listOfFilesListBox.Items.Remove(listOfFilesListBox.SelectedItem);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < netHosts.listOfHosts.Count; i++)
            {
                netHosts.listOfHosts[i].SetHosts(getHostNames(getConnections(netHosts.listOfHosts[i].GetFileName())));
            }

            Matrix matr = new Matrix(netHosts.listOfHosts);

            TopologyWnd tplg = new TopologyWnd(matr, netHosts);
            tplg.Show();
        }

        private string[] getConnections(string Filename)
        {
            NetHost Selected = null;
            for (int i = 0; i < netHosts.listOfHosts.Count; i++)
            {
                if (netHosts.listOfHosts[i].GetFileName().Contains(Filename))
                {
                    Selected = netHosts.listOfHosts[i];
                    break;
                }
            }

            List<string> result = new List<string>();
            for (int i = 0; i < Selected.ListOfRecords.Count; i++)
            {
                result.Add(Selected.ListOfRecords[i].GetCons());
            }

            return result.ToArray();
        }

        private string[] getHostNames(string[] input)
        {
            List<string> results = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];

                for (int a = 0; a < netHosts.listOfHosts.Count; a++)
                {
                    for (int b = 0; b < netHosts.listOfHosts[a].ListOfRecords.Count; b++)
                    {
                        if (netHosts.listOfHosts[a].ListOfRecords[b].GetEthMAC().Contains(current))
                        {
                            results.Add(netHosts.listOfHosts[a].GetFileName());
                        }
                    }
                }
            }

            return results.ToArray();
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            listOfFilesListBox.Items.Clear();
            netHosts.listOfHosts.Clear();
        }

        private void MainWnd_Resize(object sender, EventArgs e)
        {
           // LoadFileButton.Width = this.Width;

            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }
        }
    }
}
