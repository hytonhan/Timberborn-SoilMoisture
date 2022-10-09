using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace Hytone.Timberborn.Mods.SoilMoisture
{
    [Configurator(SceneEntrypoint.InGame)]
    public class SoilMoistureConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<DroughtListener>().AsSingleton();
        }
    }
}
