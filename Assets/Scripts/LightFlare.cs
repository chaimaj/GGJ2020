using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightFlare : MonoBehaviour
{
    Light2D light;
    int numFlares;
    bool flareOn;
    float lastFlareTime;
    float flareInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light2D>();
        numFlares = 3;
        flareOn = false;

    // Update is called once per frame
    void Update()
    {
        if (flareOn) {
            if (Time.time > lastFlareTime + flareInterval)
            {
                flareOn = false;
                light.pointLightInnerRadius = 1.31f;
                light.pointLightOuterRadius = 3.47f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was released.");
            if (numFlares > 0) { 
                light.pointLightInnerRadius = 2;
                light.pointLightOuterRadius = 5;
                flareOn = true;
                lastFlareTime = Time.time;
                numFlares--;
            }
        }

    }
}
