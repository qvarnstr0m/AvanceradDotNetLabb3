using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvanceradDotNetLabb3
{
    internal class Program
    {
        private static List<Car> raceList = new List<Car>();
        static void Main(string[] args)
        {
            Car audi = new Car("Audi");
            Car bmw = new Car("Bmw");

            raceList.Add(audi);
            raceList.Add(bmw);

            int raceDistance = 1000;

            Console.WriteLine("The race is starting!");
            Console.WriteLine($"Car {audi.Name} starts the race");
            Console.WriteLine($"Car {bmw.Name} starts the race");

            Thread thread1 = new Thread(audi.Race);
            thread1.Start(raceDistance);

            Thread thread2 = new Thread(bmw.Race);
            thread2.Start(raceDistance);

            Thread thread3 = new Thread(HandleInput);
            thread3.Start();

            // Wait for both threads to complete
            thread1.Join();
            thread2.Join();
        }

        private static void HandleInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "status")
                {
                    foreach (var item in raceList)
                    {
                        Console.WriteLine($"{item.Name} has travelled {item.Distance} and is running at a speed of {item.Speed} km/h");
                    }
                }
                else if (input.ToLower() == "exit")
                {
                    break;
                }
            }
        }
    }
}
