using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIR_simulation
{
    internal class DiffSystem
    {
        //number of contacts per day
        public float b;
        //recovery rate
        public float k;
        //population size
        public int N;
        //holds the current s(t), i(t), r(t) values
        List<float> currentValues;

        //supply capital S(0), I(0), R(0) values and population size
        public DiffSystem(float b, float k, float SStart, float IStart, float RStart, int N)
        {
            this.N = N;
            this.b = b;
            this.k = k;

            //calc ratios
            float st = SStart / N;
            float it = IStart / N;
            float rt = RStart / N;

            currentValues = new List<float>();
            currentValues.Add(st);
            currentValues.Add(it);
            currentValues.Add(rt);
        }

        public void calcStep()
        {
            //we have the s(t), i(t) and r(t) values calculated from the previous step

            //insert the values into the equations
            //by doing this we obtain the slope of each function
            //we just add the slope value to the current s(t), i(t), r(t) values to get s(t+1), i(t+1), r(t+1)

            //copy the results to this.currentValues
            //we can access this.currentValues from outside every step to create graphs etc.
            throw new NotImplementedException();
        }


        //calculates ds/dt based on given input s(t), i(t) and b
        private float calcStepdSdt(float s, float i, float b)
        {
            throw new NotImplementedException ();
        }

        //calculates di/dt based on given input s(t), i(t), b and k
        private float calcStepdIdt(float s, float i, float b, float k)
        {
            throw new NotImplementedException();
        }

        //calculates dr/dt based on given input i(t) and k
        private float calcStepdRdt(float i, float k)
        {
            throw new NotImplementedException();
        }
    }
}
