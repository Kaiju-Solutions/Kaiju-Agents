using System.Collections.Generic;
using KaijuSolutions.Agents.Sensors;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// Sensor for <see cref="Flag"/>s.
    /// </summary>
    public class FlagVisionSensor : KaijuVisionSensor<Flag>
    {
        /// <summary>
        /// If there are no explicitly defined observable objects, define how to query for default observables.
        /// </summary>
        /// <returns>Both <see cref="Flag"/>s.</returns>
        protected override IEnumerable<Flag> DefaultObservables()
        {
            return Flag.Flags;
        }
    }
}