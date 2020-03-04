using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2.Models
{
    public class Location
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }

        public Location(double c1, double c2, string name, DateTime o, DateTime c)
        {
            X = c1;
            Y = c2;
            Name = name;
            Opening = o;
            Closing = c;
        }

        public double Distance(Location l)
        {
            int R = 6371000;//radijus zemlje
            double f1 = (X * Math.PI) / 180;//u radijane
            double f2 = (l.X * Math.PI) / 180;
            double df = ((l.X - X) * Math.PI) / 180;
            double dl = ((l.Y - Y) * Math.PI) / 180;

            double a = Math.Sin(df / 2) * Math.Sin(df / 2) + Math.Cos(f1) * Math.Cos(f2) * Math.Sin(dl / 2) * Math.Sin(dl / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d/1000;//u km rastojanje
        }
    }
}
