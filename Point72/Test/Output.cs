using System.Linq;
using NUnit.Framework;

namespace Point72.Model
{
    [TestFixture]
    public class OutputTest
    {
        [TestCase]
        public static void InitialDayIsZero()
        {
            Output o = new Output();
            int drills = 5;
            int wellCreateRate = 3;
            int wellIntialOutput = 100;
            int wellDecayRate = 5;

            // Initialize output model with the drills and wells
            for (int i = 0; i < drills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(wellIntialOutput, wellDecayRate);
                        }
                    )
                );
            }

            Assert.AreEqual(0, o.CurrentDay);
        }

        [TestCase]
        public static void DayAdvancesOnMoveNext()
        {
            Output o = new Output();
            int drills = 5;
            int wellCreateRate = 3;
            int wellIntialOutput = 100;
            int wellDecayRate = 5;

            // Initialize output model with the drills and wells
            for (int i = 0; i < drills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(wellIntialOutput, wellDecayRate);
                        }
                    )
                );
            }

            o.MoveNext();

            Assert.AreEqual(0, o.CurrentDay);
        }

        [TestCase]
        public static void WellCreatedOnCreateRate()
        {
            Output o = new Output();
            int drills = 5;
            int wellCreateRate = 3;
            int wellIntialOutput = 100;
            int wellDecayRate = 5;

            // Initialize output model with the drills and wells
            for (int i = 0; i < drills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(wellIntialOutput, wellDecayRate);
                        }
                    )
                );
            }

            Assert.AreEqual(0, o.Wells.Count<Well>());

            o.MoveNext();
            Assert.AreEqual(0, o.Wells.Count<Well>());

            o.MoveNext();
            Assert.AreEqual(0, o.Wells.Count<Well>());

            o.MoveNext();
            Assert.AreEqual(5, o.Wells.Count<Well>());
        }

        [TestCase]
        public static void WellsAgeWithMoveNext()
        {
            Output o = new Output();
            int drills = 2;
            int wellCreateRate = 2;
            int wellIntialOutput = 100;
            int wellDecayRate = 5;

            // Initialize output model with the drills and wells
            for (int i = 0; i < drills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(wellIntialOutput, wellDecayRate);
                        }
                    )
                );
            }

            o.MoveNext();
            Assert.AreEqual(0, o.Wells.Count<Well>()); // Sanity check

            o.MoveNext();
            Assert.AreEqual(2, o.Wells.Count<Well>()); // Sanity check
            foreach (Well w in o.Wells)
            {
                Assert.AreEqual(0, w.Age); // Sanity check for brand new wells
            }

            o.MoveNext();
            foreach (Well w in o.Wells)
            {
                Assert.AreEqual(1, w.Age);
            }
        }

        [TestCase]
        public static void WellsCanHaveDifferentAgeWithMoveNext()
        {
            Output o = new Output();
            int drills = 2;
            int wellCreateRate = 2;
            int wellIntialOutput = 100;
            int wellDecayRate = 5;

            // Initialize output model with the drills and wells
            for (int i = 0; i < drills; i++)
            {
                o.Drills.Add(
                    new WellBuilder(
                        new Drill(wellCreateRate),
                        () =>
                        {
                            return new Well(wellIntialOutput, wellDecayRate);
                        }
                    )
                );
            }

            o.MoveNext();
            o.MoveNext();
            o.MoveNext();
            o.MoveNext();

            int twoCount = 0;
            int zeroCount = 0;
            foreach (Well w in o.Wells)
            {
                if (w.Age==2)
                {
                    twoCount++;
                }
                else if (w.Age==0)
                {
                    zeroCount++;
                }
            }

            Assert.AreEqual(2, zeroCount);
            Assert.AreEqual(2, twoCount);
        }
    }
}
