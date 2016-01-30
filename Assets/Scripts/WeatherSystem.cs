using UnityEngine;
using System.Collections;
using Weather;

namespace Weather
{
    public enum WeatherId
    {
        FINE = 0,
        HEATWAVE,
        OVERCAST,
        SHOWERS,
        RAINY,
        STORM,
        SNOW,
        BLIZZARD
    }

    [System.Serializable]
    public struct WeatherState
    {
        public int wid;
        public int cloudDensity;
        public int windSpeed;
        public Color lightColour;
        public Color cloudTint;
        public Color fogColour;
        public bool raining;
        public bool snowing;
    }

    [System.Serializable]
    public struct WeatherStateCollection
    {
        public WeatherState[] weatherStates;
    }
}


public class WeatherSystem : MonoBehaviour {

 
    public Light sun;
    public Skydome skydome;
    public ParticleSystem rainParticles;
    public ParticleSystem snowParticles;

    IEnumerator transition;

    bool snowing = false;
    bool raining = false;

    WeatherId defaultWeather = WeatherId.FINE;
    WeatherStateCollection stateInfo;
    
    float cloudDensity;
    float windSpeed;
    Color cloudColour;
    Color sunColour;
    Color fogColour;
    public float transitionTime = 10.0f; // seconds it takes from one state to another
    
    public WeatherId currentWeather;

    void Awake()
    {
        currentWeather = defaultWeather;
    }

    void Start()
    {
        LoadWeatherData();

        cloudDensity = stateInfo.weatherStates[(int)defaultWeather].cloudDensity;
        cloudColour = stateInfo.weatherStates[(int)defaultWeather].cloudTint;
        sunColour = stateInfo.weatherStates[(int)defaultWeather].lightColour;
        fogColour = stateInfo.weatherStates[(int)defaultWeather].fogColour;
        windSpeed = stateInfo.weatherStates[(int)defaultWeather].windSpeed;
        skydome.SetCloudDensity((float)cloudDensity);
        skydome.SetWindSpeed(windSpeed);
 
    }

    void LoadWeatherData()
    {
        string weatherData = Resources.Load<TextAsset>("weatherStates").text;
        stateInfo = JsonUtility.FromJson<WeatherStateCollection>(weatherData);
    }

    public void TransitionTo(WeatherId newState)
    {
        if(transition != null)
            StopCoroutine(transition);

        transition = TransitionWeather(newState, currentWeather);
        StartCoroutine(transition);

        currentWeather = newState;
    }

    void ToggleSnow(bool f)
    {
        snowing = f;
        snowParticles.enableEmission = f;
    }

    void ToggleRain(bool f)
    {
        raining = f;
        rainParticles.enableEmission = f;
    }

    IEnumerator TransitionWeather(WeatherId newState, WeatherId oldState)
    {
        float t = 0;
        float startDensity = cloudDensity;
        float startWind = windSpeed;
        Color startCloudColour = cloudColour;
        Color startFogColour = fogColour;
        Color startSunColour = sunColour;

        WeatherState cState = stateInfo.weatherStates[(int)newState];

        skydome.SetWindSpeed(cState.windSpeed);

        ToggleSnow(cState.snowing);
        ToggleRain(cState.raining);

        while (t < 1)
        {
            cloudDensity = Mathf.Lerp(startDensity, cState.cloudDensity, t);
            skydome.SetCloudDensity(cloudDensity);

            windSpeed = Mathf.Lerp(startWind, cState.windSpeed, t);
            skydome.SetWindSpeed(windSpeed);

            cloudColour = Color.Lerp(startCloudColour, cState.cloudTint, t);
            skydome.SetCloudColor(cloudColour);

            fogColour = Color.Lerp(startFogColour, cState.fogColour, t);
            RenderSettings.fogColor = fogColour;

            //TODO fog density
            
            sunColour = Color.Lerp(startSunColour, cState.lightColour, t);
            sun.color = sunColour;

            if (raining)
            {
                rainParticles.startColor = new Color(1, 1, 1, t);
                
            }

            if (snowing)
            {
                snowParticles.startColor = new Color(1, 1, 1, t);
            }

            t += Time.deltaTime / transitionTime;
            yield return null;
        }
    }
}
