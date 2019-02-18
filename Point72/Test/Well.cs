using NUnit.Framework;

namespace Point72.Model
{
    /// <summary>
    /// Test cases for the Well class model
    /// </summary>
    [TestFixture]
    public static class WellTest
    {
        /// <summary>
        /// Test initial well output
        /// </summary>
        [TestCase]
        public static void InitialOutput()
        {
            Well testWell = new Well(10, 0.5);

            Assert.AreEqual(10, testWell.Output);

            testWell = new Well(5, 100);

            Assert.AreEqual(5, testWell.Output);
        }

        /// <summary>
        /// Test various decay rates
        /// </summary>
        [TestCase]
        public static void DecayRate()
        {
            Well testWell = new Well(12, 0.5);
            testWell.Age = 12;
            Assert.AreEqual(6, testWell.Output);
            testWell.Age = 24;
            Assert.AreEqual(0, testWell.Output);

            testWell = new Well(100, 10);
            testWell.Age = 5;
            Assert.AreEqual(50, testWell.Output);
            testWell.Age = 10;
            Assert.AreEqual(0, testWell.Output);
        }

        /// <summary>
        /// Ensure output is never negative
        /// </summary>
        [TestCase]
        public static void ZeroOutputAfterExceedingLife()
        {
            Well testWell = new Well(12, 0.5);
            testWell.Age = 100;
            Assert.AreEqual(0, testWell.Output);

            testWell = new Well(100, 10);
            testWell.Age = 1000;
            Assert.AreEqual(0, testWell.Output);
        }
    }
}
