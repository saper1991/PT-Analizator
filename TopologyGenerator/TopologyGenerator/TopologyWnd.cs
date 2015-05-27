using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TopologyGenerator
{
    public partial class TopologyWnd : Form
    {
        private int[,] matrix = null;
        private int count = 0;
        private List<PointToText> points = new List<PointToText>();
        private int radius = 20;
        private int mPointMoveInProgress = 0;
        private List<Rectangle> rectangles = new List<Rectangle>();
        private NetHosts netHosts = new NetHosts();
        private List<ToolTip> tips = new List<ToolTip>();
        private Point location;


        public TopologyWnd(Matrix input, NetHosts netHosts)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.netHosts = netHosts;

            matrix = input.getMatrix();
            count = input.getHosts().Length;

            for (int i = 0; i < count; i++)
            {
                points.Add(new PointToText(new Point(300, 200)));
                if (!netHosts.listOfHosts[i].GetIfRouter())
                    points[i].text.Add(netHosts.listOfHosts[i].ListOfRecords[0].GetEthMAC());
                else
                {
                    for (int j = 0; j < netHosts.listOfHosts[i].ListOfRecords.Count; j++)
                    {
                        points[i].text.Add(netHosts.listOfHosts[i].ListOfRecords[j].GetEthMAC());
                    }
                }
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void TopologyPBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), points[i].getPoint(), points[j].getPoint());
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                Image newImage = null;
                if (netHosts.getListOfHosts()[i].GetIfRouter() == false)
                    newImage = Image.FromFile("1.png");
                else
                    newImage = Image.FromFile("11.png");

                rectangle = new Rectangle(points[i].point.X - radius, points[i].point.Y - radius, radius * 2, radius + radius / 2 + radius / 4);
                Rectangle source = new Rectangle(points[i].point.X - radius, points[i].point.Y - radius, radius * 2, radius + radius / 2 + radius / 4);
                newImage = resizeImage(newImage, new Size(40, 30));

                GraphicsUnit units = GraphicsUnit.Pixel;
                //e.Graphics.FillRectangle(Brushes.White, rectangle);
                //e.Graphics.DrawRectangle(Pens.Black, rectangle);

                e.Graphics.DrawImageUnscaledAndClipped(newImage, rectangle);
                //rectangles.Add(rectangle);
                netHosts.addSetHostRectangle(netHosts.getListOfHosts()[i], rectangle);
            }
        }

        private void TopologyPBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (points != null)
            {
                mPointMoveInProgress = 0;

                for (int i = 0; i < points.Count; i++)
                {
                    if (Math.Abs(e.X - points[i].getPoint().X) < radius && Math.Abs(e.Y - points[i].getPoint().Y) < radius)
                    {
                        mPointMoveInProgress = i + 1;
                        break;
                    }
                }
            }
        }

        private void TopologyPBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (location == e.Location)
                return;

            if (mPointMoveInProgress != 0 || points != null)
            {

                for (int j = 0; j < netHosts.listOfHostRectangles.Count; j++)
                {
                    if (netHosts.listOfHostRectangles[j].rectangle.Contains(e.Location))
                    {
                        location = e.Location;
                        string name = netHosts.listOfHostRectangles[j].netHost.GetFileName();
                        netHosts.listOfHostRectangles[j].netHost.tip.Show(name, this, e.X, e.Y + 30);
                    }
                    else
                    {
                        netHosts.listOfHostRectangles[j].netHost.tip.Hide(this);
                        netHosts.listOfHostRectangles[j].netHost.adresstip1.Hide(this);
                        netHosts.listOfHostRectangles[j].netHost.adresstip2.Hide(this);
                    }
                }

                for (int i = 0; i < points.Count; i++)
                {
                    if (mPointMoveInProgress == i + 1)
                    {
                        points[i].point.X = e.X;
                        points[i].point.Y = e.Y;
                        TopologyPBox.Refresh();
                        break;
                    }
                }
            }

        }

        private void TopologyPBox_MouseUp(object sender, MouseEventArgs e)
        {
            mPointMoveInProgress = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void screenCaptureButton_Click(object sender, EventArgs e)
        {

            var frm = Form.ActiveForm;
            var pb = TopologyPBox;
            var gr = groupBox1;

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Zapisz obraz";
            save.Filter = "Obrazy (*.png, *.jpg) | *.png; *.jpg";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = save.FileName;

                using (var bmp = new Bitmap(pb.Width, pb.Height))
                {
                    pb.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(path);
                    //@"C:\Users\Laura\Desktop\screenshot.png"
                }

                MessageBox.Show("Obraz zapisano pomyślnie");

            }




        }

        private void TopologyWnd_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TopologyWnd_Load_1(object sender, EventArgs e)
        {

        }

        private void tooltipadresses_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (!netHosts.listOfHosts[i].GetIfRouter())
                    netHosts.listOfHostRectangles[i].netHost.tip.Show(points[i].text[0], this, points[i].point.X, points[i].point.Y + 20);
                else
                {
                    netHosts.listOfHostRectangles[i].netHost.tip.Show(points[i].text[0], this, points[i].point.X, points[i].point.Y);
                    netHosts.listOfHostRectangles[i].netHost.adresstip1.Show(points[i].text[1], this, points[i].point.X, points[i].point.Y + 20);
                    netHosts.listOfHostRectangles[i].netHost.adresstip2.Show(points[i].text[2], this, points[i].point.X, points[i].point.Y-20);
                }
            }

        }

        private void TopologyWnd_Resize(object sender, EventArgs e)
        {
            
           // groupBox1.Width = this.Width;
          
        }

        private void TopologyPBox_Click(object sender, EventArgs e)
        {
           // TopologyPBox.Width = this.Width;
        }

        private void groupBox1_Resize(object sender, EventArgs e)
        {

        }
    }

    public class PointToText
    {
        public Point point;
        public List<string> text = new List<string>();

        public PointToText(Point point)
        {
            this.point = point;
        }

        public Point getPoint()
        {
            return point;
        }

    }
}
