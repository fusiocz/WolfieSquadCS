using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FireSide
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public int player = 1;
        public int mode = 1;
        public double angle = 0;
        public double speed = 0;
        public double vx = 12;
        public double vy = 292;
        private double BulletX = 14;
        private double BulletY = 295;
        private const int hgt = 7;
        private const double YPosun = 9.8 / (100);
        public bool develop = false;
        public int scoreA = 0;
        public int scoreB = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
            prekazky();
            label6.Text = "Obstacle 1 " + prek1.Location.ToString();
            label7.Text = "Obstacle 2 " + prek2.Location.ToString();
            label9.Text = "Obstacle 3 " + prek3.Location.ToString();
            label10.Text = "Obstacle 4 " + prek4.Location.ToString();
            label11.Text = "Obstacle 5 " + prek5.Location.ToString();
        }
        private void prekazky()
        {
            prek1.Location = new Point(231, r.Next(30, 270));
            prek2.Location = new Point(259, r.Next(30, 270));
            prek3.Location = new Point(287, r.Next(30, 270));
            prek4.Location = new Point(315, r.Next(30, 270));
            prek5.Location = new Point(343, r.Next(30, 270));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (player == 1)
            {
                vx = speed * Math.Cos(angle) / 10;
                vy = -speed * Math.Sin(angle) / 10;
            }
            else
            {
                vx = -speed * Math.Cos(angle) / 10;
                vy = -speed * Math.Sin(angle) / 10;
            }
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            trackBar1.Enabled = false;
            trackBar2.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            angle = trackBar1.Value * (Math.PI / 180);
            label3.Text = trackBar1.Value.ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            speed = trackBar2.Value;
            label4.Text = trackBar2.Value.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics gr = panel1.CreateGraphics())
            {
                using (Brush br = new SolidBrush(panel1.BackColor))
                {
                    gr.FillEllipse(br, (float)(BulletX), (float)(BulletY),
                        hgt, hgt);
                }

                vy += YPosun;
                BulletX += vx;
                BulletY += vy;

                gr.FillEllipse(Brushes.Black,
                    (float)(BulletX), (float)(BulletY),
                    hgt, hgt);

                //Pošťouchaná kolize
                if (BulletX >= 231 && BulletX <= 253)
                {
                    if (BulletY >= prek1.Location.Y && BulletY <= (prek1.Location.Y + 22))
                    {
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                //2
                if (BulletX >= 259 && BulletX <= 281)
                {
                    if (BulletY >= prek2.Location.Y && BulletY <= (prek2.Location.Y + 22))
                    {
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                //3
                if (BulletX >= 287 && BulletX <= 309)
                {
                    if (BulletY >= prek3.Location.Y && BulletY <= (prek3.Location.Y + 22))
                    {
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                //4
                if (BulletX >= 315 && BulletX <= 337)
                {
                    if (BulletY >= prek4.Location.Y && BulletY <= (prek4.Location.Y + 22))
                    {
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                //5
                if (BulletX >= 343 && BulletX <= 365)
                {
                    if (BulletY >= prek5.Location.Y && BulletY <= (prek5.Location.Y + 22))
                    {
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                //TARGET COLL
                if ((BulletX >= 14 && BulletX <= 36) && (player == 2))
                {
                    if (BulletY >= obj1.Location.Y && BulletY <= (obj1.Location.Y + 22))
                    {
                        scoreB++;
                        panel1.Invalidate();
                        Thread.Sleep(2000);
                        stop();

                    }
                }
                        if ((BulletX >= 553 && BulletX <= 575) && (player == 1))
                        {
                            if (BulletY >= obj2.Location.Y && BulletY <= (obj2.Location.Y + 22))
                            {
                                scoreA++;
                                panel1.Invalidate();
                                Thread.Sleep(2000);
                                stop();

                            }
                        }

                        //Konec pošťouchané kolize
                        if ((BulletY > panel1.ClientRectangle.Height) ||
                            (BulletX > panel1.ClientRectangle.Width))
                        {
                            stop();
                        }
                    } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scoreA = 0;
            scoreB = 0;
            scoreboard.Text = "0 : 0";
            mode = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            scoreA = 0;
            scoreB = 0;
            scoreboard.Text = "0 : 0";
            player = 1;
            BulletX = 14;
            BulletY = 295;
            mode = 2;
        }

        private void developerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (develop == false)
            {
                develop = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
            }
            else
            {
                develop = false;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
            }

        }
        private void stop()
        {
            scoreboard.Text = scoreA.ToString() + " : " + scoreB.ToString();
            timer1.Stop();
            timer1.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            Cursor = Cursors.Default;
            if (player == 1)
            {
                player = 2;
                BulletX = 555;
                BulletY = 295;
            }
            else
            {
                player = 1;
                BulletX = 14;
                BulletY = 295;
            }
            if (player == 2 && mode == 2)
            {
                speed = r.Next(65, 80);
                angle = r.Next(45, 65) * (Math.PI / 180);
                button1.PerformClick();
            }
            panel1.Invalidate();
            prekazky();
            label6.Text = "Obstacle 1 " + prek1.Location.ToString();
            label7.Text = "Obstacle 2 " + prek2.Location.ToString();
            label9.Text = "Obstacle 3 " + prek3.Location.ToString();
            label10.Text = "Obstacle 4 " + prek4.Location.ToString();
            label11.Text = "Obstacle 5 " + prek5.Location.ToString();
        }
    }
}
