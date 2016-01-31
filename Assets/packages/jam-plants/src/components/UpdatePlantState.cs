using UnityEngine;
using Jam.Weathers;
using Jam.Symbols;
using Jam.Utils;
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

        public GameObject weatherNotice;
        public GameObject shaderTarget;
        public GameObject animationTarget;

        public float minWind = 0.1f;
        public float maxWind = 0.5f;

        public float matchThreshold = 0.3f;

        // Debugging
        public bool debugHappy = false;
        public bool debugSad = false;
        public float debugWind = -1;

        public void UpdateState(WeatherDelta newWeather)
        {
            // Update shader state
            var wind = minWind + newWeather.weather.detail.wind * (maxWind - minWind);

            // Get a delta between current weather and targets weather
            var delta = targetWeather.Delta(newWeather.weather.detail);
            if (delta < matchThreshold)
            {
                UpdateAnimationState(true);
                PickRandomWeatherTarget();
            }
            else
            {
                UpdateAnimationState(false);
            }
        }

        public void UpdateShaderState(float wind)
        {
            if (shaderTarget == null)
            {
                Debug.LogError("Missing shaderTarget on UpdatePlantState");
            }
            else
            {
                var renderer = shaderTarget.GetComponent<Renderer>();
                renderer.material.SetFloat("_Speed", wind);
            }
        }

        public void UpdateAnimationState(bool happy)
        {
            if (animationTarget == null)
            {
                Debug.LogError("Missing animationTarget on UpdatePlantState");
            }
            else
            {
                var animator = animationTarget.GetComponent<Animator>();
                if (happy) { animator.SetTrigger("Happy"); }
                else { animator.SetTrigger("Unhappy"); }
            }
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
                SpawnPrefabForTarget();
            }
        }

        public void SpawnPrefabForTarget()
        {
            var instance = PlantTarget.FindMarker(gameObject);
            if (instance != null)
            {
                GameObject.Destroy(instance.gameObject);
            }
            var prefab = WeatherUtils.WeatherPrefab(targetWeatherId);
            Scene.Spawn(prefab).Then((pp) =>
            {
                var x = pp.AddComponent<PlantTargetMarker>();
                x.parent = gameObject;
                if (weatherNotice == null)
                {
                    Debug.LogError("You need to Pick a notice quad for the PlantUpdateState object");
                }
                else
                {
                    x.transform.position = weatherNotice.transform.position;
                    x.transform.rotation = weatherNotice.transform.rotation;
                    x.transform.localScale = weatherNotice.transform.localScale;
                }
            });
        }

        public void Update()
        {
            if (genNewTarget)
            { PickRandomWeatherTarget(); }

            // Debugging
            if (debugHappy) { UpdateAnimationState(true); debugHappy = false; }
            if (debugSad) { UpdateAnimationState(false); debugSad = false; }
            if (debugWind >= 0) { UpdateShaderState(debugWind); debugWind = -1f; }
        }
    }
}
