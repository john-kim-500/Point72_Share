using System;
using System.Collections.Generic;
using System.Globalization;


namespace Point72.Model
{
    /// <summary>
    /// Models an output scenario
    /// </summary>
    public class Output
    {
        private int day;
        private List<Well> wells = new List<Well>();

        #region DayOutput struct
        public struct DayOutput
        {
            public DayOutput(int days, double output)
            {
                this.Day = days;
                this.Output = output;

            }

            public int Day
            {
                get;
                private set;
            }

            public double Output
            {
                get;
                private set;
            }

            public override string ToString()
            {
                return String.Format(CultureInfo.InvariantCulture, "Max Output @ : Day = {0} Barrels = {1}", Day, Output);
            }
        }
        #endregion

        public Output()
        {
            this.Drills = new List<WellBuilder>();
            this.day = 0;
        }

        public List<WellBuilder> Drills
        {
            get;
            private set;
        }

        public IEnumerable<Well> Wells
        {
            get
            {
                foreach (Well w in this.wells)
                {
                    yield return w;
                }
            }
        }

        /// <summary>
        /// Current day
        /// </summary>
        public int CurrentDay
        {
            get
            {
                return this.day;
            }
        }

        /// <summary>
        /// Current output
        /// </summary>
        public double CurrentOutput
        {
            get
            {
                // Compute current output
                double output = 0;

                foreach (Well w in this.Wells)
                {
                    output += w.Output;
                }

                return output;
            }
        }

        // Advance current day by one
        public void MoveNext()
        {
            // Age each existing well by one day
            foreach (Well w in wells)
            {
                w.Age += 1;
            }

            // See if any new wells are ready
            foreach (WellBuilder d in Drills)
            {
                Well w = d.BuildWell();
                if (w == null)
                {
                    continue;
                }

                wells.Add(w);
            }
        }
    }
}
