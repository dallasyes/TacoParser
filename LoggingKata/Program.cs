using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;
            double distance = 0;

            // NESTED LOOPS SECTION----------------------------

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var distance1 = corA.GetDistanceTo(corB);
                    if (distance1 > distance)
                    {
                        distance = distance1;
                        tacobell1 = locA;
                        tacobell2 = locB;

                    }
                }
            }
            // NESTED LOOPS SECTION COMPLETE ---------------------
            Console.WriteLine("The two TacoBells that are farthest from each other are:");
            Console.WriteLine($"Name: {tacobell1.Name}");
            Console.WriteLine($"Name: {tacobell2.Name}");
            Console.WriteLine($"The distance from one to the other: {distance} meters");


            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.



        }
    }
}
