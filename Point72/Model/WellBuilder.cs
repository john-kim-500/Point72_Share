using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point72.Model
{
    /// <summary>
    /// Models the building of <see cref="Well"/> instances, based on elapsed time (etc.)
    /// </summary>
    public class WellBuilder
    {
        /// <summary>
        /// Delegate for creating new Wells
        /// </summary>
        /// <returns></returns>
        public delegate Well WellFactoryDelegate();

        private Drill drill;
        private int elapsedDay;
        private WellFactoryDelegate wellDelegate;

        /// <summary>
        /// Create WellBuilder instance
        /// </summary>
        /// <param name="drill">Drill instance</param>
        /// <param name="wellFactory">Well factory delegate</param>
        public WellBuilder(Drill drill, WellFactoryDelegate wellFactory)
        {
            if (drill == null)
            {
                throw new ArgumentNullException("drill");
            }
            if (wellFactory==null)
            {
                throw new ArgumentNullException("wellFactory");
            }
            this.drill = drill;
            this.elapsedDay = 0;
            this.wellDelegate = wellFactory;
        }


        /// <summary>
        /// Elapse by one day and see if a new well is ready
        /// </summary>
        /// <returns>New well instance.  Null, if a new well is not ready. </returns>
        public Well BuildWell()
        {
            this.elapsedDay++;

            if ((this.elapsedDay % this.drill.Rate) == 0)
            {
                this.elapsedDay = 0; // Prevent overflow
                return this.wellDelegate();
            }
             
            return null;
        }
    }
}
