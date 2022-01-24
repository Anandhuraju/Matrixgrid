using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MATRIX
{
    public partial class Form1 : Form
    {
        public int m_Width;
        public int m_Height;
        public int m_rows;
        public int m_cols;
        public int m_xoffset;
        public int m_yoffset;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        public int rc = 8;


        public Form1()
        {
            InitializeComponent();
            intialize();
        }

        public void intialize()
        {
            m_rows = DEFAULT_NO_ROWS;
            m_cols = DEFAULT_NO_ROWS;
            m_Width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_xoffset = DEFAULT_X_OFFSET;
            m_yoffset = DEFAULT_Y_OFFSET;

        }
        void ondraw()
        {

            Graphics boardLayout = this.CreateGraphics();

            Pen layoutPen = new Pen(Color.Black);

            layoutPen.Width = 7;
            int counterflag = 2;
            while (counterflag <= rc)
            {
                Thread.Sleep(1000);
                if (counterflag != rc)
                {
                    m_rows = counterflag;
                    m_cols = counterflag;
                    //boardLayout.DrawLine(layoutPen, 0, 0, 100, 0);
                    int X = DEFAULT_X_OFFSET;
                    int Y = DEFAULT_Y_OFFSET;
                    //Draw The rows
                    for (int i = 0; i <= m_rows; i++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X + this.m_Width * this.m_cols, Y);
                        Y = Y + m_Height;
                    }

                    //Draw The Cols
                    X = DEFAULT_X_OFFSET;
                    Y = DEFAULT_Y_OFFSET;
                    for (int j = 0; j <= m_cols; j++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_rows);
                        X = X + this.m_Width;
                    }
                    counterflag++;
                }
                else
                {
                    counterflag = 2;

                    Invalidate();


                }


            }

        }


        private void Stop_Click(object sender, EventArgs e)
        {
            flag.Suspend();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            flag = new Thread(new ThreadStart(ondraw));
            flag.Start();
            Invalidate();
        }
        private void Resume_click(object sender, EventArgs e)
        {
            flag.Resume();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rc = 4;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            rc = 5;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            rc = 6;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            rc = 7;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            rc = 8;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            rc = 9;
        }


    }
}
