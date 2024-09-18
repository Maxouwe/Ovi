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
        public List<float> currentValues;

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
            float st = currentValues[0];
            float it = currentValues[1];
            float rt = currentValues[2];

            //insert the values into the equations
            float dSdt = calcdsdt(st, it, b);
            float dIdt = calcdidt(st, it, b, k);
            float dRdt = calcdrdt(it, k);

            //by doing this we obtain the slope of each function
            //we just add the slope value to the current s(t), i(t), r(t) values to get s(t+1), i(t+1), r(t+1)
            //copy the results to this.currentValues
            currentValues[0] = st + dSdt;
            currentValues[1] = it + dIdt;
            currentValues[2] = rt + dRdt;

            //we can access this.currentValues from outside every step to create graphs etc.
        }


        //calculates ds/dt based on given input s(t), i(t) and b
        private float calcdsdt(float s, float i, float b)
        {
            return (-b) * s * i;
        }

        //calculates di/dt based on given input s(t), i(t), b and k
        private float calcdidt(float s, float i, float b, float k)
        {
            return b * s * i - k * i;
        }

        //calculates dr/dt based on given input i(t) and k
        private float calcdrdt(float i, float k)
        {
            return k * i;
        }
    }
}
