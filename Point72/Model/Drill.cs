using System;

namespace Point72.Model
{
    /// <summary>
    /// Models a drill's output of wells
    /// </summary>
    public class Drill
    {
        /// <summary>
        /// Create new instance of <see cref="Drill"/>
        /// </summary>
        /// <param name="wellCreationRate"></param>
        public Drill(int wellCreationRate)
        {
            if (wellCreationRate <=0)
            {
                throw new ArgumentException("wellCreationRate must be a positive value");
            }
            this.Rate = wellCreationRate;
        }

        /// <summary>
        /// Get the number of days to create a new well
        /// </summary>
        public int Rate
        {
            get;
            private set;
        }
    }
}
