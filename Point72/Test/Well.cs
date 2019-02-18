using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Point72.Model;

namespace Point72.Model.Test
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

            Assert.AreEqual(10, testWell.DailyOutput(0));

            testWell = new Well(5, 100);

            Assert.AreEqual(5, testWell.DailyOutput(0));
        }

        /// <summary>
        /// Test various decay rates
        /// </summary>
        [TestCase]
        public static void DecayRate()
        {
            Well testWell = new Well(12, 0.5);
            Assert.AreEqual(6, testWell.DailyOutput(12));
            Assert.AreEqual(0, testWell.DailyOutput(24));

            testWell = new Well(100, 10);
            Assert.AreEqual(50, testWell.DailyOutput(5));
            Assert.AreEqual(0, testWell.DailyOutput(10));
        }

        /// <summary>
        /// Ensure output is never negative
        /// </summary>
        [TestCase]
        public static void ZeroOutputAfterExceedingLife()
        {
            Well testWell = new Well(12, 0.5);
            Assert.AreEqual(0, testWell.DailyOutput(1000));

            testWell = new Well(100, 10);
            Assert.AreEqual(0, testWell.DailyOutput(1000));
        }
    }
}
