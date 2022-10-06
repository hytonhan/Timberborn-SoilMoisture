using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.SoilMoistureSystem;

namespace Hytone.Timberborn.Mods.SoilMoisture
{
    /// <summary>
    /// Entrypoint of the mod
    /// </summary>
    [HarmonyPatch]
    public class SoilMoisturePlugin : IModEntrypoint
    {
        private static SoilMoistureConfig _config;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            _config = mod.Configs.Get<SoilMoistureConfig>();

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
            __instance._soilMoistureSimulationSettings._maxMoisture = _config.MoistureDistance;
            __instance._soilMoistureSimulationSettings._verticalSpreadCostMultiplier = _config.UphillPenalty;
        }
    }

}
