using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LightsTiming
{
    public partial class Form1 : Form
    {
        Intersection intersection = new Intersection(ROAD_WIDTH);
        const int ROAD_WIDTH = 60;


        float mx, my;

        public Form1()
        {
            InitializeComponent();

            mx = this.Width / 2.0f;
            my = this.Height / 2.0f;

            intersection.Cars[0].X = 0;
            intersection.Cars[0].Y = my;


            var aTimer = new System.Timers.Timer(10);
            aTimer.Elapsed += TimePassed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;            
        }

        private void TimePassed(Object source, ElapsedEventArgs e)
        {
            foreach(var car in intersection.Cars)
            {
                switch (car.CurrentDirection)
                {
                    case Car.Direction.EAST:
                        var eastLightStatus = intersection.Lights[(int)Car.Direction.EAST].Status;
                        if (eastLightStatus == Light.LightStatus.RED || (eastLightStatus == Light.LightStatus.YELLOW && new Random().NextDouble() < .2))
                        {
                            if (car.CurrentVelocity > 0 && car.X < mx && Math.Abs(car.X - mx) < 200) //slowing down from the east
                            {
                                car.CurrentVelocity -= .15;
                            }
                        }

                        car.X+=(float)(car.CurrentVelocity/50);
                        break;
                    default:
                        break;
                }

                Invalidate();
            }
        }

        private RectangleF[] GetRoadRects()
        {
            var rectList = new List<RectangleF>();

            rectList.Add(new RectangleF(0, my - ROAD_WIDTH - 20, Width, 2*ROAD_WIDTH));
            rectList.Add(new RectangleF(mx - ROAD_WIDTH - 10, 0, 2*ROAD_WIDTH, Height));

            return rectList.ToArray();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            g.FillRectangles(Brushes.Black, GetRoadRects());
            foreach (var car in intersection.Cars) {
                g.FillRectangle(Brushes.Red, car.X, car.Y, 20, 20);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
