using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Test
{
    public partial class Form1 : Form
    {
        int handleRadius = 10;
        int mPointMoveInProgress = 0;
        Point mPoint1, mPoint2;

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            mPoint1 = new Point(50, 50);
            mPoint1 = new Point(50, 100); 
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine if a point is under the cursor. If so, declare that a move is in progress
            if (Math.Abs(e.X - mPoint1.X) < handleRadius && Math.Abs(e.Y - mPoint1.Y) < handleRadius) 
            {
                mPointMoveInProgress = 1;
            }

            else if (Math.Abs(e.X - mPoint2.X) < handleRadius && Math.Abs(e.Y - mPoint2.Y) < handleRadius)
            {
                mPointMoveInProgress = 2;
            }
            else mPointMoveInProgress = 0;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mPointMoveInProgress == 1) // If moving first point
            {
                mPoint1.X = e.X;
                mPoint1.Y = e.Y;
                Refresh();
            }
            else if (mPointMoveInProgress == 2) // If moving second point
            {
                mPoint2.X = e.X;
                mPoint2.Y = e.Y;
                Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Declare that no move is in progress
            mPointMoveInProgress = 0;
        }

        private void GenerateButton_Paint(object sender, PaintEventArgs e)
        {
            // Draw line
            e.Graphics.DrawLine(new Pen(Color.Black, 2), mPoint1, mPoint2);

            Rectangle rectangle;

            // Draw first handle
            rectangle = new Rectangle(mPoint1.X - handleRadius, mPoint1.Y - handleRadius, handleRadius * 2, handleRadius * 2);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);

            // Draw second handle
            rectangle = new Rectangle(mPoint2.X - handleRadius, mPoint2.Y - handleRadius, handleRadius * 2, handleRadius * 2);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);
        }
    }
}
