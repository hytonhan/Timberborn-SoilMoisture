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
    }
}
