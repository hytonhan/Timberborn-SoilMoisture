using HarmonyLib;
using System;
using TimberApi.ConfigSystem;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.SoilMoistureSystem;

namespace Hytone.Timberborn.Mods.Random
{
    [HarmonyPatch]
    public class SoilMoisturePlugin : IModEntrypoint
    {
        private static SoilMoistureConfig _config;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            _config = mod.Configs.Get<SoilMoistureConfig>();

            var harmony = new Harmony("hytone.plugins.random");
            harmony.PatchAll();

        }

        [HarmonyPatch(typeof(SoilMoistureSimulator), nameof(SoilMoistureSimulator.Load))]
        public static void Postfix(SoilMoistureSimulator __instance)
        {
            __instance._soilMoistureSimulationSettings._maxMoisture = _config.MoistureDistance;
        }
    }

    public class SoilMoistureConfig : IConfig
    {
        public string ConfigFileName => "SoilMoisture";

        public int MoistureDistance = 16;
    }

}
