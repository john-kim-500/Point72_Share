using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point72
{
    /// <summary>
    /// Models of the well output
    /// </summary>
    public class Well
    {
        private double initialOutput;
        private double dailyDecayAmount;

        /// <summary>
        /// Create instance of <see cref="Well"/>
        /// </summary>
        /// <param name="initialOutput">Initial well output (in number of barrels)</param>
        /// <param name="dailyDecayAmount">The reduction of output per day (in number of barrels)</param>
        public Well(double initialOutput, double dailyDecayAmount)
        {
            this.initialOutput = initialOutput;
            this.dailyDecayAmount = dailyDecayAmount;
        }

        public double DailyOutput(int elapsedDay)
        {
            double ret = (this.initialOutput - this.dailyDecayAmount * elapsedDay);
            if (ret<0D)
            {
                ret = 0D;
            }

            return ret;
        }
    }
}
