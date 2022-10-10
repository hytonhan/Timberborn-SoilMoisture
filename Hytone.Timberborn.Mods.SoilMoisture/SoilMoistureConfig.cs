using System;
using TimberApi.ConfigSystem;

namespace Hytone.Timberborn.Mods.SoilMoisture
{
    /// <summary>
    /// Represent the JSON config that is used by the mod
    /// </summary>
    public class SoilMoistureConfig : IConfig
    {
        public string ConfigFileName => "SoilMoisture";

        public int MoistureDistance = 16;
        public int UphillPenalty = 6;
        public float DroughtMoistureMultiplier = 1f;

        // the following code works but logs an exception that DroughtMoistureDistance is missing in the config file.
        //[JsonIgnore]
        //public int DroughtMoistureDistance { get { return (int)Math.Ceiling(MoistureDistance * DroughtMoistureMultiplier); } }

        public int DroughtMoistureDistance()
        {
            return (int)Math.Ceiling(MoistureDistance * DroughtMoistureMultiplier);
        }
    }
}
