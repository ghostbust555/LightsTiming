using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsTiming
{
    public class Light
    {
        public LightStatus Status;

        public enum LightStatus
        {
            RED,YELLOW,GREEN
        }

        public Light(LightStatus status = LightStatus.RED) { Status = status; }
    }
}
