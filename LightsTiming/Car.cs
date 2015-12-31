using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsTiming
{
    public class Car
    {
        public enum Direction
        {
            NORTH,EAST,SOUTH,WEST
        }

        public Direction CurrentDirection;
        public double CurrentVelocity;
        public float X, Y;

        public Car(Direction initialDirection, double initialVeloctiy) {
            CurrentDirection = initialDirection;
            CurrentVelocity = initialVeloctiy;
        }
    }
}
