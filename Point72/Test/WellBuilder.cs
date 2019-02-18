using System.Collections.Generic;
using NUnit.Framework;

namespace Point72.Model
{
    [TestFixture]
    public class WellBuilderTest
    {
        [TestCase]
        public static void NoWellOnInitialDay()
        {
            WellBuilder builder = new WellBuilder(
                    new Drill(10),
                    () =>
                    {
                        return new Well(100D, 5);
                    }
                );
            Assert.IsNull(builder.BuildWell());
        }

        [TestCase]
        public static void WellCountGrowth()
        {
            WellBuilder builder = new WellBuilder(
                    new Drill(2), // Creation rate of 2
                    () =>
                    {
                        return new Well(100D, 5);
                    }
                );

            List<Well> wells = new List<Well>();

            Well well = null;
            for (int day = 0; day<10; day++)
            {
                well = builder.BuildWell();
                if (well != null)
                {
                    wells.Add(well);
                }
            }

            Assert.AreEqual(5, wells.Count);
        }
    }
}
