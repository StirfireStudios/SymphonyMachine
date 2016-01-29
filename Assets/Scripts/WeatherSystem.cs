using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the world's weather based on inputs and "random" events?
/// </summary>
/// 

public enum WeatherState
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

public class WeatherSystem : MonoBehaviour {

    public Skydome skydome;
    public ParticleSystem rainParticles;
    public ParticleSystem snowParticles;

    IEnumerator transition;

    float[] cloudDensities = 
    {
        0,
        0,
        0.25f,
        0.55f,
        0.9f,
        1,
        0.8f,
        1
    };

    float[] windSpeeds =
    {
        0.003f,
        0,
        0.007f,
        0.01f,
        0.03f,
        0.08f,
        0.02f,
        0.08f
    };

    WeatherState defaultWeather = WeatherState.FINE;
    float cloudDensity;
    public float transitionTime = 10.0f; // seconds it takes from one state to another
    
    public WeatherState currentWeather;

    float windSpeed = 0.0f;

    void Awake()
    {
        currentWeather = defaultWeather;
        cloudDensity = cloudDensities[(int)currentWeather];
        windSpeed = windSpeeds[(int)currentWeather];
    }

    void Start()
    {
        skydome.SetCloudDensity(cloudDensity);
        skydome.SetWindSpeed(windSpeed);
    }

    public void TransitionTo(WeatherState newState)
    {
        if(transition != null)
            StopCoroutine(transition);

        transition = TransitionWeather(newState, currentWeather);
        StartCoroutine(transition);

        currentWeather = newState;
    }

    void StartRain()
    {
        //temp
        rainParticles.enableEmission = true;
    }

    void StopRain()
    {
        //temp
        rainParticles.enableEmission = false;
    }

    IEnumerator TransitionWeather(WeatherState newState, WeatherState oldState)
    {
        float t = 0;
        float startDensity = cloudDensity;
        float startWind = windSpeed;

        while (t < 1)
        {
            cloudDensity = Mathf.Lerp(startDensity, cloudDensities[(int)newState], t);
            skydome.SetCloudDensity(cloudDensity);

            windSpeed = Mathf.Lerp(startWind, windSpeeds[(int)newState], t);
            skydome.SetWindSpeed(windSpeed);

            t += Time.deltaTime / transitionTime;
            yield return null;
        }

        if (currentWeather == WeatherState.RAINY || currentWeather == WeatherState.STORM)
        {
            StartRain();
        }
        else
        {
            StopRain();
        }
    }
}
