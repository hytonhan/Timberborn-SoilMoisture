using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.Persistence;
using Timberborn.SoilMoistureSystem;

namespace Hytone.Timberborn.Mods.SoilMoisture
{
    /// <summary>
    /// Entrypoint of the mod
    /// </summary>
    [HarmonyPatch]
    public class SoilMoisturePlugin : IModEntrypoint
    {
        public static SoilMoistureConfig Config;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Config = mod.Configs.Get<SoilMoistureConfig>();

            var harmony = new Harmony("hytone.plugins.soilmoisture");
            harmony.PatchAll();

        }

        /// <summary>
        /// Patch the SoilMoistureSimulator.Load to alter the SoilMoistureSimulator values
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch(typeof(SoilMoistureSimulator), nameof(SoilMoistureSimulator.Load))]
        public static void Postfix(SoilMoistureSimulator __instance)
        {
            var isDrought = __instance._singletonLoader.GetSingleton(new SingletonKey("DroughtService")).Get(new PropertyKey<bool>("IsDrought"));

            var moistureDistance = isDrought ? Config.DroughtMoistureDistance() : Config.MoistureDistance;

            __instance._soilMoistureSimulationSettings._maxMoisture = moistureDistance;
            __instance._soilMoistureSimulationSettings._verticalSpreadCostMultiplier = Config.UphillPenalty;
        }
    }

}
