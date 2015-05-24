using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopologyGenerator
{
    public partial class TopologyWnd : Form
    {
        private int[,] matrix = null;
        private int count = 0;
        private Point[] points = null;
        private int radius = 20;
        private int mPointMoveInProgress = 0;
        private List<Rectangle> rectangles = new List<Rectangle>();

        public TopologyWnd(Matrix input)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            matrix = input.getMatrix();
            count = input.getHosts().Length;

            points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(50, i * 40);
            }
        }

        private void TopologyPBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle;

            for (int i = 0; i < count; i++)
            {
                rectangle = new Rectangle(points[i].X - radius, points[i].Y - radius, radius * 2, radius * 2);
                e.Graphics.FillRectangle(Brushes.White, rectangle);
                e.Graphics.DrawRectangle(Pens.Black, rectangle);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), points[i], points[j]);
                    }
                }
            }
        }

        private void TopologyPBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (points != null)
            {
                mPointMoveInProgress = 0;

                for (int i = 0; i < points.Length; i++)
                {
                    if (Math.Abs(e.X - points[i].X) < radius && Math.Abs(e.Y - points[i].Y) < radius)
                    {
                        mPointMoveInProgress = i + 1;
                        break;
                    }
                }
            }
        }

        private void TopologyPBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mPointMoveInProgress != 0 || points != null)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (mPointMoveInProgress == i + 1)
                    {
                        points[i].X = e.X;
                        points[i].Y = e.Y;
                        Refresh();

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


    }
}
