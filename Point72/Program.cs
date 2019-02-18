using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Point72.Model;

namespace Point72
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDrills = 10;
            int wellCreationRate = 2;
            int initialOutput = 10;
            int wellDecayRate = 1;

            FindMaxOutput(numberOfDrills, wellCreationRate, initialOutput, wellDecayRate);
        }

        private static void FindMaxOutput(int numDrills, int wellCreateRate, int initialOutput, int wellDecayRate)
        {
            Dictionary<double, int> output = new Dictionary<double, int>();

            // Create and initialize output model with drill and well models
            Output o = new Output();
            for (int i = 0; i < numDrills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(initialOutput, wellDecayRate);
                        }
                    )
                );
            }

            double maxOutput = 0;
            int maxDay = 0;

            int day = 0;
            while (o.CurrentOutput == 0 && day <= wellCreateRate)
            {
                o.MoveNext();
                day++;
            }

            while (day < 10000) // safety brake, in case cyclical assumption doesn't hold true...
            {
                double curOutput = o.CurrentOutput;

                // Assumption:  Output becomes cyclical, so halt once cycling
                if (output.ContainsKey(curOutput)
                    && output[curOutput] > 4)
                {
                    break;
                }
                else if (!output.ContainsKey(curOutput))
                {
                    output[curOutput] = 0;
                }
                output[curOutput]++;

                Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "Day = {0} Output = {1}", day, curOutput));

                if (maxOutput < curOutput )
                {
                    maxOutput = curOutput;
                    maxDay = day;
                }
                o.MoveNext();

                day++;
            }

            Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "Peak Output : Day = {0} Output = {1}", maxDay, maxOutput));
        }
    }
}
