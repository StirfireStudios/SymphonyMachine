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
	
    public void SetCloudDensity(float density)
    {
        thisRend.material.SetFloat("_Density", density / 100);
    }

    public void SetWindSpeed(float speed)
    {
        thisRend.material.SetFloat("_CloudSpeed", speed / 1000);
    }

    public void SetCloudColor(Color nCol)
    {
        thisRend.material.SetColor("_CloudColour", nCol);
    }
}
