namespace AvanceradDotNetLabb3
{
    internal class Car
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }

        public static int place = 1;

        public static int totalCars = 0;

        

        public Car(string name)
        {
            Name = name;
            Distance = 0;
            Speed = 120;
        }

        public void Race(object raceDistanceObject)
        {
            int raceDistance = (int)raceDistanceObject;
            totalCars++;
            while (Distance < raceDistance)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                HandleRandomEvent();
                Distance += Speed / 2;
            }
            Console.WriteLine($"Car {Name} has crossed the finish line in place {place}!");
            place++;
            totalCars--;
            if (totalCars < 1)
            {
                Console.WriteLine($"That was the last car of the race, enter exit to terminate program");
            }
        }

        public void HandleRandomEvent()
        {
            Random random = new Random();
            int probability = random.Next(1, 51);

            if (probability == 1)
            {
                Console.WriteLine($"Car {Name} runs out of gas, 30 seconds delay.");
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
            else if (probability <= 2)
            {
                Console.WriteLine($"Car {Name} gets a flat tire, 20 seconds delay.");
                Thread.Sleep(TimeSpan.FromSeconds(20));
            }
            else if (probability <= 5)
            {
                Console.WriteLine($"Car {Name} hits a bird, 5 seconds delay.");
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            else if (probability <= 10)
            {
                Console.WriteLine($"Car {Name} gets an engine malfunction, speed is reduced from {Speed} km/h to {Speed - 1} km/h.");
                Speed -= 1;
            }
        }
    }
}
