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
        public double b;
        //recovery rate
        public double k;
        //population size
        public int N;
        //holds the current s(t), i(t), r(t) values
        public List<double> currentValues;

        //supply capital S(0), I(0), R(0) values and population size
        public DiffSystem(double b, double k, double SStart, double IStart, double RStart, int N)
        {
            this.N = N;
            this.b = b;
            this.k = k;

            //calc ratios
            double st = SStart / N;
            double it = IStart / N;
            double rt = RStart / N;

            currentValues = new List<double>();
            currentValues.Add(st);
            currentValues.Add(it);
            currentValues.Add(rt);
        }

        public void calcStep()
        {
            //we have the s(t), i(t) and r(t) values calculated from the previous step
            double st = currentValues[0];
            double it = currentValues[1];
            double rt = currentValues[2];

            //insert the values into the equations
            double dSdt = calcdsdt(st, it, b);
            double dIdt = calcdidt(st, it, b, k);
            double dRdt = calcdrdt(it, k);

            //by doing this we obtain the slope of each function
            //we just add the slope value to the current s(t), i(t), r(t) values to get s(t+1), i(t+1), r(t+1)
            //copy the results to this.currentValues
            currentValues[0] = Math.Max(st + dSdt, 0);
            currentValues[1] = Math.Min(it + dIdt, 1);
            currentValues[2] = Math.Min(rt + dRdt, 1);

            //we can access this.currentValues from outside every step to create graphs etc.
        }


        //calculates ds/dt based on given input s(t), i(t) and b
        private double calcdsdt(double s, double i, double b)
        {
            return (-b) * s * i;
        }

        //calculates di/dt based on given input s(t), i(t), b and k
        private double calcdidt(double s, double i, double b, double k)
        {
            return b * s * i - k * i;
        }

        //calculates dr/dt based on given input i(t) and k
        private double calcdrdt(double i, double k)
        {
            return k * i;
        }
    }
}
