using UnityEngine;
using System.Collections;

public class TempWeatherTester : MonoBehaviour {

    WeatherSystem weatherSystem;

    void Awake()
    {
        weatherSystem = GameObject.Find("WeatherSystem").GetComponent<WeatherSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weatherSystem.TransitionTo(WeatherState.FINE);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            weatherSystem.TransitionTo(WeatherState.HEATWAVE);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            weatherSystem.TransitionTo(WeatherState.OVERCAST);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            weatherSystem.TransitionTo(WeatherState.SHOWERS);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            weatherSystem.TransitionTo(WeatherState.RAINY);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            weatherSystem.TransitionTo(WeatherState.STORM);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            weatherSystem.TransitionTo(WeatherState.SNOW);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            weatherSystem.TransitionTo(WeatherState.BLIZZARD);
        }
	}
}
