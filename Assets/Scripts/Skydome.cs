using UnityEngine;
using System.Collections;

public class Skydome : MonoBehaviour {

    public Transform player;
    Renderer thisRend;
    float cloudSpeed = 1;

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
        this.cloudSpeed = speed;
        //Debug.Log(cloudSpeed);
    }

    public void SetCloudColor(Color nCol)
    {
        thisRend.material.SetColor("_CloudColour", nCol);
    }

    void Update()
    {
        var shaderTime = thisRend.material.GetFloat("_time");
        shaderTime += Time.deltaTime * (cloudSpeed / 1000);
        thisRend.material.SetFloat("_time", shaderTime);
    }
}
