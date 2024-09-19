namespace SIR_simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            testCase();
        }

        static void testCase()
        {
            DiffSystem sys = new DiffSystem(0.5, 0.333333333, 7900000, 10, 0, 7900000);

            for (int i = 0; i < 150; i++)
            {
                sys.calcStep();

                //output every 5th step
                if (i % 5 == 0)
                {
                    Console.WriteLine(sys.currentValues[0] + " " + sys.currentValues[1] + " " + sys.currentValues[2]);
                }
            }
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

                DiffSystem sys = new DiffSystem(b, k, S0, I0, R0, N);

                for (int i = 0; i < 150; i++)
                {
                    sys.calcStep();

                    //output every 5th step
                    if (i % 5 == 0)
                    {
                        Console.WriteLine(sys.currentValues[0] + " " + sys.currentValues[1] + " " + sys.currentValues[2]);
                    }
                }
                Console.WriteLine("want more y/n?");
            }
        }
    }
}