using UnityEngine;
using System.Collections;

public class Skydome : MonoBehaviour {

    public Transform player;
    Renderer thisRend;

    void Awake()
    {
        thisRend = GetComponent<Renderer>();
    }

	void Start () {
        transform.parent = null;
	}
	
	void Update () {
        transform.position = player.position;
	}

    public void SetCloudDensity(float density)
    {
        thisRend.material.SetFloat("_Density", density);
    }

    public void SetWindSpeed(float speed)
    {
        thisRend.material.SetFloat("_CloudSpeed", speed);
    }
}
