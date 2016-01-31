using UnityEngine;
using Jam.Weathers;
using Jam.Symbols;
using Weather;

namespace Jam.Plants
{
    [AddComponentMenu("Jam/Plants/Update Plant State")]
    public class UpdatePlantState : MonoBehaviour
    {
        [Tooltip("Generate a new target for this plant")]
        public bool genNewTarget = false;

        public WeatherId targetWeatherId;

        public SymbolBase targetWeather;

        public void SetDesiredState(WeatherId weatherId)
        {
        }

        public void UpdateState(WeatherDelta newWeather)
        {
        }

        public void PickRandomWeatherTarget()
        {
            genNewTarget = false;
            var targets = WeatherUtils.KnownWeather();
            KnownWeatherPattern new_target = null;
            for (var i = 0; i < 10; ++i)
            {
                new_target = Jam.Utils.Random.Pick(targets);
                if (new_target.weather != targetWeatherId)
                {
                    break;
                }
            }
            if (new_target != null)
            {
                targetWeatherId = new_target.weather;
                targetWeather = new_target.detail;
            }
        }

        public void Update()
        {
            if (genNewTarget)
            { PickRandomWeatherTarget(); }
        }
    }
}
