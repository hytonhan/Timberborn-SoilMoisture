using Bindito.Core;
using Timberborn.SingletonSystem;
using Timberborn.SoilMoistureSystem;
using Timberborn.WeatherSystem;

namespace Hytone.Timberborn.Mods.SoilMoisture
{
    public class DroughtListener : ILoadableSingleton
    {
        private EventBus _eventBus;
        private SoilMoistureSimulationSettings _soilMoistureSimulationSettings;

        [Inject]
        public void InjectDependencies(EventBus eventBus, SoilMoistureSimulationSettings soilMoistureSimulationSettings)
        {
            _eventBus = eventBus;
            _soilMoistureSimulationSettings = soilMoistureSimulationSettings;
        }

        public void Load()
        {
            _eventBus.Register(this);
        }

        [OnEvent]
        public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent)
        {
            _soilMoistureSimulationSettings._maxMoisture = SoilMoisturePlugin.Config.DroughtMoistureDistance();
        }

        [OnEvent]
        public void OnDroughtEnded(DroughtEndedEvent droughtEndedEvent)
        {
            _soilMoistureSimulationSettings._maxMoisture = SoilMoisturePlugin.Config.MoistureDistance;
        }
    }
}
