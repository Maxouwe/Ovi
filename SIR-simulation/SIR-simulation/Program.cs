namespace SIR_simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("you want some? y/n");
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("how many contacts per day");
                float b = float.Parse(Console.ReadLine());
                Console.WriteLine("what is the recovery rate");
                float k = float.Parse(Console.ReadLine());
                Console.WriteLine("how big is the population");
                int N = Int32.Parse(Console.ReadLine());
                Console.WriteLine("How many susceptibles at t=0");
                float S0 = float.Parse(Console.ReadLine());
                Console.WriteLine("How many infected at t=0");
                float I0 = float.Parse(Console.ReadLine());
                Console.WriteLine("How many recovered at t=0");
                float R0 = float.Parse(Console.ReadLine());

                DiffSystem sys = new DiffSystem(b, k, S0, I0, R0, N);

                for (int i = 0; i < 150; i++)
                {
                    sys.calcStep();

                    //output every 10th step
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