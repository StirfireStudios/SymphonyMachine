using UnityEngine;
using Jam.Symbols;
using Jam.Weathers;
using Jam.Utils;
using Jam.Plants;
using Weather;

namespace Jam.Actions
{
    public class UpdatePlantsWithNewWeather : ITask
    {
        public WeatherDelta delta;

        public UpdatePlantsWithNewWeather(WeatherDelta delta)
        { this.delta = delta; }

        public void Execute(TaskComplete callback)
        {
            // Update any plant on the scene
            foreach (var plant in Scene.FindComponents<UpdatePlantState>())
            { plant.UpdateState(delta); }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
