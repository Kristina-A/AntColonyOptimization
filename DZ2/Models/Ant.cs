using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2.Models
{
    public class Ant
    {
        public List<int> Locations { get; set; }
        public int Start { get; set; }
        private double[][] Distances;
        private Tuple<DateTime,DateTime>[] WorkingHours;
        private Random rand;

        public Ant(double[][] dist, Tuple<DateTime, DateTime>[] t,  Random r)
        {
            rand = r;
            Locations = new List<int>();
            Distances = dist;
            WorkingHours = t;
            Start = rand.Next(dist.Length);

            RandomPath();
        }

        private void RandomPath()
        {
            for (int i = 0; i < Distances.Length; i++)
                Locations.Add(i);

            for(int i = 0; i < Distances.Length; i++)
            {
                int r = rand.Next(i, Locations.Count);
                int tmp = Locations[r];
                Locations[r] = Locations[i];
                Locations[i] = tmp;
            }

            int ind = Locations.IndexOf(Start);
            int temp = Locations[0];
            Locations[0] = Locations[ind];
            Locations[ind] = temp;
        }

        public void UpdateAnt(Pheromone pheromones, int alpha, int beta)
        {
            int numLocations = Locations.Count;
            Start = rand.Next(numLocations);

            Locations = BuildPath(pheromones, alpha, beta);
        }

        private List<int> BuildPath(Pheromone pheromones, int alpha, int beta)
        {
            int numLocations = Locations.Count;
            List<int> locations = new List<int>();
            bool[] visited = new bool[numLocations];
            DateTime[] times = new DateTime[numLocations];//vremena kad stizu na lokacije

            locations.Add(Start);
            visited[Start]=true;
            times[Start] = DateTime.Parse("9:00");

            for(int i = 0; i < numLocations - 1; i++)
            {
                int locX = locations[i];
                int next = NextLocation(locX, visited, times, pheromones, alpha, beta);
                locations.Add(next);
                visited[next] = true;

                if(times[locX].TimeOfDay<WorkingHours[locX].Item1.TimeOfDay || times[locX].TimeOfDay> WorkingHours[locX].Item2.AddHours(-1).TimeOfDay)
                    times[next] = times[locX].AddHours(0.25+Distances[locX][next] / 5.0);//15min na lokaciji prethodnoj + vreme da stignu
                else
                    times[next] = times[locX].AddHours(1.0 + Distances[locX][next] / 5.0);
            }

            return locations;
        }

        private int NextLocation(int locX, bool[] visited, DateTime[] times, Pheromone pheromones, int alpha, int beta)
        {
            double[] probs = MoveProbs(locX, visited, times, pheromones, alpha, beta);

            double[] cumul = new double[probs.Length + 1];
            cumul[0] = 0.0;
            for (int i = 0; i < probs.Length; ++i)
                cumul[i + 1] = cumul[i] + probs[i];

            double p = rand.NextDouble();

            for (int i = 0; i < cumul.Length - 1; ++i)
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;
            throw new Exception("Nije pronadjena validna lokacija!");
        }

        private double[] MoveProbs(int locX, bool[] visited, DateTime[] times, Pheromone pheromones, int alpha, int beta)
        {
            int numLocations = Locations.Count;
            double[] thau = new double[numLocations];
            double sum = 0.0;
            for (int i = 0; i < thau.Length; ++i)
            {
                if (i == locX)
                    thau[i] = 0.0;
                else if (visited[i] == true)
                    thau[i] = 0.0;
                else
                {
                    DateTime arrival;
                    if (times[locX].TimeOfDay < WorkingHours[locX].Item1.TimeOfDay || times[locX].TimeOfDay > WorkingHours[locX].Item2.AddHours(-1).TimeOfDay)
                        arrival = times[locX].AddHours(0.25 + Distances[locX][i] / 5.0);
                    else
                        arrival = times[locX].AddHours(1.0 + Distances[locX][i] / 5.0);

                    if (arrival.TimeOfDay>=WorkingHours[i].Item1.TimeOfDay && arrival.TimeOfDay<=WorkingHours[i].Item2.AddHours(-1).TimeOfDay)//stizu na vreme
                        thau[i] = Math.Pow(pheromones.Pheromones[locX][i], alpha) *
                          Math.Pow(1.0 / Distances[locX][i], beta);
                    else
                        thau[i] = Math.Pow(pheromones.Pheromones[locX][i], alpha) *
                              Math.Pow(1.0 / (Distances[locX][i] + 1.0), beta);//ne stizu na vreme
                    if (thau[i] < 0.0001)
                        thau[i] = 0.0001;
                    else if (thau[i] > (double.MaxValue / (numLocations * 100)))
                        thau[i] = double.MaxValue / (numLocations * 100);
                }
                sum += thau[i];
            }

            double[] probs = new double[numLocations];
            for (int i = 0; i < probs.Length; ++i)
                probs[i] = thau[i] / sum;
            return probs;
        }

        public double Length()
        {
            double result = 0.0;

            for(int i = 0; i < Locations.Count - 1; i++)
            {
                result += Distances[Locations[i]][Locations[i + 1]];
            }

            return result;
        }

        public int LateArrivals()
        {
            int lates = 0;
            DateTime start = DateTime.Parse("9:00");

            for(int i = 0; i < Locations.Count-1; i++)
            {
                if (start.TimeOfDay < WorkingHours[Locations[i]].Item1.TimeOfDay || start.TimeOfDay > WorkingHours[Locations[i]].Item2.AddHours(-1).TimeOfDay)
                {
                    lates++;
                    start = start.AddHours(0.25+Distances[Locations[i]][Locations[i + 1]]/5.0);//kasne, 15min zadrzavanje
                }
                else
                    start = start.AddHours(1.0 + Distances[Locations[i]][Locations[i + 1]]/5.0);
            }

            if (start.TimeOfDay < WorkingHours[Locations[Locations.Count-1]].Item1.TimeOfDay || start.TimeOfDay > WorkingHours[Locations[Locations.Count-1]].Item2.AddHours(-1).TimeOfDay)
                lates++;

            return lates;
        }

        public bool InPath(int locX, int locY)//da li su lokacije x i y susedne
        {
            int lastIndex = Locations.Count - 1;
            int index = Locations.IndexOf(locX);

            if (index == 0 && Locations[1] == locY)
            {
                return true;
            }
            else if (index == 0)
            {
                return false;
            }
            else if (index == lastIndex && Locations[lastIndex - 1] == locY)
            {
                return true;
            }
            else if (index == lastIndex)
            {
                return false;
            }
            else if (Locations[index - 1] == locY)
            {
                return true;
            }
            else if (Locations[index + 1] == locY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
