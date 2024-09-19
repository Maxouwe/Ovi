using System.Windows.Forms;

namespace SIR_simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //close the form if you want to input a new scenario
            loopPrompt();
            
            

            Console.ReadLine();
        }

        static void testCase()
        {
            DiffSystem sys = new DiffSystem(0.5, 0.333333333, 7900000, 10, 0, 7900000);
            List<double> ySus = new List<double>();
            List<double> yInf = new List<double>();
            List<double> yRec = new List<double>();
            int totalDays = 140;

            for (int i = 0; i < totalDays; i++)
            {
                sys.calcStep();

                //Console.WriteLine(sys.currentValues[0] + " " + sys.currentValues[1] + " " + sys.currentValues[2]);
                ySus.Add(sys.currentValues[0]);
                yInf.Add(sys.currentValues[1]);
                yRec.Add(sys.currentValues[2]);
            }

            MyForm chart = new MyForm(totalDays, 0, 1, 5);
            chart.addValues(ySus, yInf, yRec);
            chart.ShowDialog();
        }
        static void loopPrompt()
        {
            Console.WriteLine("you want some? y/n");
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("how many contacts per day");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("what is the recovery rate");
                double k = double.Parse(Console.ReadLine());
                Console.WriteLine("how big is the population");
                int N = Int32.Parse(Console.ReadLine());
                Console.WriteLine("How many susceptibles at t=0");
                double S0 = double.Parse(Console.ReadLine());
                Console.WriteLine("How many infected at t=0");
                double I0 = double.Parse(Console.ReadLine());
                Console.WriteLine("How many recovered at t=0");
                double R0 = double.Parse(Console.ReadLine());
                Console.WriteLine("total span of days");
                int totalDays = Int32.Parse(Console.ReadLine());

                DiffSystem sys = new DiffSystem(b, k, S0, I0, R0, N);

                List<double> ySus = new List<double>();
                List<double> yInf = new List<double>();
                List<double> yRec = new List<double>();
                

                for (int i = 0; i < totalDays; i++)
                {
                    sys.calcStep();

                    //Console.WriteLine(sys.currentValues[0] + " " + sys.currentValues[1] + " " + sys.currentValues[2]);
                    ySus.Add(sys.currentValues[0]);
                    yInf.Add(sys.currentValues[1]);
                    yRec.Add(sys.currentValues[2]);
                }

                MyForm chart = new MyForm(totalDays, 0, 1, 5);
                chart.addValues(ySus, yInf, yRec);
                chart.ShowDialog();

                Console.WriteLine("want more y/n?");
            }
        }
    }
}