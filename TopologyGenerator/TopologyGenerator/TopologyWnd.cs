﻿using System;
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
        private NetHosts netHosts = new NetHosts();
        private List<ToolTip> tips = new List<ToolTip>();

        public TopologyWnd(Matrix input, NetHosts netHosts)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.netHosts = netHosts;

            matrix = input.getMatrix();
            count = input.getHosts().Length;

            points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(50, i * 40);
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
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), points[i], points[j]);
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                Image newImage = null;
                if(netHosts.getListOfHosts()[i].GetIfRouter() == false)
                    newImage = Image.FromFile("1.png");
                else
                    newImage = Image.FromFile("11.png");

                rectangle = new Rectangle(points[i].X - radius, points[i].Y - radius, radius * 2, radius + radius / 2 + radius / 4);
                Rectangle source = new Rectangle(points[i].X - radius, points[i].Y - radius, radius * 2, radius + radius / 2 + radius / 4);
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
            for (int i = 0; i < netHosts.listOfHostRectangles.Count; i++)
            {
                if (netHosts.listOfHostRectangles[i].rectangle.Contains(e.X, e.Y))
                {
                    string name = netHosts.listOfHostRectangles[i].netHost.GetFileName();
                    netHosts.listOfHostRectangles[i].netHost.tip.Show(name, this, e.X, e.Y);
                }
                else
                {
                    netHosts.listOfHostRectangles[i].netHost.tip.Hide(this);
                }
            }

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
