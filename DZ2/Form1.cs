using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ2.Models;
using System.Windows.Forms;
using System.IO;

namespace DZ2
{
    public partial class Form1 : Form
    {
        private bool draw;
        private Random r;
        public List<int> bestPath { get; set; }
        public int alpha { get; set; }
        public int beta { get; set; }
        public double rho { get; set; }
        public double Q { get; set; }
        public int numLocations { get; set; }
        public int numAnts { get; set; }
        private int time;
        public List<Location> Locations { get; set; }
        public List<Ant> Ants { get; set; }
        public double[][] Distances { get; set; }
        public Tuple<DateTime, DateTime>[] Times { get; set; }
        public Pheromone Pheromone { get; set; }
        public Form1()
        {
            draw = false;
            r = new Random();
            Locations = new List<Location>();
            Ants = new List<Ant>();
            bestPath = new List<int>();
            //alpha = 3;
            //beta = 2;
            //rho = 0.01;
            //Q = 2.0;
            numAnts = 4;
            numLocations = 0;
            time = 2;

            InitializeComponent();
            lblFile.Text = "";
            lblDuzina.Text = "";
            lblRedosled.Text = "";
        }

        private void InitLocation(string name, double x, double y, DateTime op, DateTime cl)
        {
            Location c = new Location(x, y, name,op,cl);
            Locations.Add(c);
        }

        private void CalculateDistances()
        {
            for(int i = 0; i < numLocations; i++)
            {
                for(int j = i+1; j < numLocations; j++)
                {
                    Distances[i][j] = Locations[i].Distance(Locations[j]);
                    Distances[j][i] = Distances[i][j];
                }
            }
        }

        private void AddWorkingHours()
        {
            for(int i = 0; i < numLocations; i++)
            {
                Times[i] = new Tuple<DateTime, DateTime>(Locations[i].Opening, Locations[i].Closing);
            }
        }

        private List<int> BestPath()
        {
            double best = Ants[0].Length() + Ants[0].LateArrivals();
            int bestInd = 0;

            for(int i = 1; i < numAnts; i++)
            {
                double good = Ants[i].Length() + Ants[i].LateArrivals();
                if (good < best)
                {
                    best = good;
                    bestInd = i;
                }
            }

            List<int> bestPath = new List<int>();
            bestPath = Ants[bestInd].Locations;

            return bestPath;
        }

        public double Length(List<int> locations)
        {
            double result = 0.0;

            for (int i = 0; i < locations.Count - 1; i++)
            {
                result += Distances[locations[i]][locations[i + 1]];
            }

            return result;
        }

        public List<int> LateArrivals(List<int> locations)
        {
            List<int> lates = new List<int>();

            DateTime start = DateTime.Parse("9:00");

            for (int i = 0; i < numLocations - 1; i++)
            {
                DateTime dt = Times[locations[i]].Item2.AddHours(-1);
                if (start.TimeOfDay < Times[locations[i]].Item1.TimeOfDay || start.TimeOfDay > Times[locations[i]].Item2.AddHours(-1).TimeOfDay)
                {
                    lates.Add(locations[i]);
                    start = start.AddHours(0.25 + Distances[locations[i]][locations[i + 1]]/5.0);//kasne, ne mogu da udju, 15min za slikanje ispred
                }
                else
                    start = start.AddHours(1.0 + Distances[locations[i]][locations[i + 1]]/5.0);
            }

            if (start.TimeOfDay < Times[locations[numLocations - 1]].Item1.TimeOfDay || start.TimeOfDay > Times[locations[numLocations - 1]].Item2.AddHours(-1).TimeOfDay)
                lates.Add(locations[numLocations - 1]);

            return lates;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (draw)
            {
                double ptXmin = Locations.Min(l => l.X);
                double ptXmax = Locations.Max(l => l.X);
                double ptYmin = Locations.Min(l => l.Y);
                double ptYmax = Locations.Max(l => l.Y);
                int drawX = pictureBox.ClientRectangle.Width;
                int drawY = pictureBox.ClientRectangle.Height;

                double[] x = new double[numLocations];
                double[] y = new double[numLocations];

                for (int i = 0; i < numLocations; i++)
                {
                    x[i] = (Locations[i].X - ptXmin) * (drawX / (ptXmax - ptXmin));
                    y[i] = (Locations[i].Y - ptYmin) * (drawY / (ptYmax - ptYmin));
                }

                Graphics g = e.Graphics;

                for (int i = 0; i < numLocations; i++)//crta lokacije, zeleno je pocetna lokacija
                {
                    RectangleF r;
                    Font drawFont = new Font("Arial", 7);
                    if (x[i] == drawX)
                        r = new RectangleF((float)x[i] - 50, pictureBox.Height - (float)y[i] + 50, 50, 50);
                    else
                        r = new RectangleF((float)x[i] + 50, pictureBox.Height - (float)y[i] - 50, 50, 50);

                    if (bestPath[0] == i)
                        g.DrawString(Locations[i].Name, drawFont, Brushes.Green, r);
                    else
                        g.DrawString(Locations[i].Name, drawFont, Brushes.Red, r);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            draw = true;
            alpha = (int)numAlpha.Value;
            beta = (int)numBeta.Value;
            rho = (double)numRho.Value;
            Q = (double)numQ.Value;

            Distances = new double[numLocations][];
            for (int i = 0; i < numLocations; i++)
                Distances[i] = new double[numLocations];

            CalculateDistances();

            Times = new Tuple<DateTime, DateTime>[numLocations];
            AddWorkingHours();

            Ants.Clear();

            for (int i = 0; i < numAnts; i++)
                Ants.Add(new Ant(Distances, Times, r));

            bestPath = BestPath();
            double bestQuality = Length(bestPath) + LateArrivals(bestPath).Count;

            Pheromone = new Pheromone(numLocations);

            int t = 0;

            while(t<time)
            {
                foreach (Ant a in Ants)
                    a.UpdateAnt(Pheromone, alpha, beta);

                Pheromone.UpdatePheromones(Ants, rho, Q);

                List<int> currBestPath = BestPath();
                double currBestQuality = Length(currBestPath) + LateArrivals(currBestPath).Count;

                if (currBestQuality < bestQuality)
                {
                    bestQuality = currBestQuality;
                    bestPath = currBestPath;
                }
                t++;
            }

            List<int> lates = LateArrivals(bestPath);

            lblDuzina.Text = "";
            lblDuzina.Text += Math.Round(Length(bestPath)).ToString() + "km";

            lblRedosled.Text = "";
            foreach(int i in bestPath)
            {
                if (bestPath.IndexOf(i) % 2 == 0)
                {
                    if (lates.Contains(i))
                        lblRedosled.Text += "\n" + Locations[i].Name + "(!)" + ", ";
                    else
                        lblRedosled.Text += "\n" + Locations[i].Name + ", ";
                }
                else
                {
                    if (lates.Contains(i))
                        lblRedosled.Text += Locations[i].Name + "(!)" + ", ";
                    else
                        lblRedosled.Text += Locations[i].Name + ", ";
                }
            }

            pictureBox.Refresh();
        }

        private void btnFile_Click(object sender, EventArgs e)//inicijalizuje lokacije iz fajla
        {
            string lineContent;
            if (ofdValues.ShowDialog() == DialogResult.OK)
            {
                lblFile.Text = ofdValues.FileName;
                Locations.Clear();

                var fileStream = ofdValues.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    lineContent = reader.ReadLine();

                    while (lineContent != null)
                    {
                        string[] infos = lineContent.Split(',');
                        numLocations++;
                        InitLocation(infos[0], double.Parse(infos[1]), double.Parse(infos[2]), DateTime.Parse(infos[3]), DateTime.Parse(infos[4]));
                        lineContent = reader.ReadLine();
                    }
                    
                }
            }
        }
    }
}
