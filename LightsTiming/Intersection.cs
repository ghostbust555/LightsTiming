using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsTiming
{
    public class Intersection
    {
        public List<Car> Cars = new List<Car>();
        public int Width;
        public Light[] Lights = new Light[] { new Light(), new Light(), new Light(), new Light() };

        public Intersection(int width) {
            Cars.Add(new Car(Car.Direction.EAST, 40));
            Width = width;
        }
    }
}
