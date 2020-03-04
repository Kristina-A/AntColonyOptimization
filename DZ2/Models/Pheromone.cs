using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2.Models
{
    public class Pheromone
    {
        public double[][] Pheromones { get; set; }

        public Pheromone(int numLocations)
        {
            Pheromones = new double[numLocations][];

            for (int i = 0; i < numLocations; i++)
                Pheromones[i] = new double[numLocations];

            for (int i = 0; i < numLocations; i++)
                for (int j = 0; j < numLocations; j++)
                    Pheromones[i][j] = 0.01;
        }

        public void UpdatePheromones(List<Ant> ants, double rho, double Q)
        {
            for(int i = 0; i < Pheromones.Length; i++)
            {
                for(int j = i+1; j < Pheromones.Length; j++)
                {
                    double increase = 0.0;
                    double decrease = (1.0 - rho) * Pheromones[i][j];

                    for (int k = 0; k < ants.Count; k++)
                    {
                        double length = ants[k].Length();
                        int lates = ants[k].LateArrivals();

                        if (ants[k].InPath(i, j) == true)
                        {
                            increase += Q / (length+lates);
                        }
                    }

                    Pheromones[i][j] = decrease + increase;

                    if (Pheromones[i][j] < 0.0001)
                    {
                        Pheromones[i][j] = 0.0001;
                    }
                    else if (Pheromones[i][j] > 100000.0)
                    {
                        Pheromones[i][j] = 100000.0;
                    }

                    Pheromones[j][i] = Pheromones[i][j];
                }
            }
        }
    }
}
