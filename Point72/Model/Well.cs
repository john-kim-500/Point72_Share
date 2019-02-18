namespace Point72
{
    /// <summary>
    /// Models of the well output
    /// </summary>
    public class Well
    {
        private double initialOutput;

        /// <summary>
        /// Create instance of <see cref="Well"/>
        /// </summary>
        /// <param name="initialOutput">Initial well output (in number of barrels)</param>
        /// <param name="dailyDecayAmount">The reduction of output per day (in number of barrels)</param>
        public Well(double initialOutput, double dailyDecayAmount)
        {
            this.initialOutput = initialOutput;
            this.Decay = dailyDecayAmount;
            this.Age = 0;
        }

        /// <summary>
        /// Get output, given the age of the well
        /// </summary>
        public double Output
        {
            get
            {
                double ret = (this.initialOutput - this.Decay * this.Age);
                if (ret < 0D)
                {
                    ret = 0D;
                }

                return ret;
            }
        }

        /// <summary>
        /// Get the daily decay of well, by number of barrels
        /// </summary>
        public double Decay
        {
            get;
            private set;
        }

        /// <summary>
        /// Get/set age of the well, in days
        /// </summary>
        public int Age
        {
            get;
            set;
        }
    }
}
