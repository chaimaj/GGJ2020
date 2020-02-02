using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;

public class LightFlare : MonoBehaviour
{

    
    public float flareInterval = 1f;
    
    public float largeInnerRadius = 2f;
    public float largeOuterRadius = 4f;

    public GameObject[] matches;
    float smallInnerRadius;
    float smallOuterRadius;

    Light2D light_;
    float lastFlareTime;
    int numFlares;
    bool flareOn;
    

    // Start is called before the first frame update
    void Start()
    {
        light_ = GetComponent<Light2D>();
        smallInnerRadius = light_.pointLightInnerRadius;
        smallOuterRadius = light_.pointLightOuterRadius;
        numFlares = 3;
        flareOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flareOn) {
            if (Time.time > lastFlareTime + flareInterval)
            {
                flareOn = false;
                StartCoroutine(FadeOutInner(0.3f, smallInnerRadius, largeInnerRadius));
                StartCoroutine(FadeOutOuter(0.3f, smallOuterRadius, largeOuterRadius));
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was released.");
            if (numFlares > 0) {
                StartCoroutine(FadeInInner(0.5f, smallInnerRadius, largeInnerRadius));
                StartCoroutine(FadeInOuter(0.5f, smallOuterRadius, largeOuterRadius));
                flareOn = true;
                lastFlareTime = Time.time;
                numFlares--;
                matches[numFlares].SetActive(false);
            }
        }

    }


    IEnumerator FadeInInner(float speed, float minSize, float maxSize)
    {
        light_.pointLightInnerRadius = minSize;

        while (light_.pointLightInnerRadius < maxSize)
        {
            light_.pointLightInnerRadius += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeInOuter(float speed, float minSize, float maxSize)
    {
        light_.pointLightOuterRadius = minSize;

        while (light_.pointLightOuterRadius < maxSize)
        {
            light_.pointLightOuterRadius += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOutInner(float speed, float minSize, float maxSize)
    {
        light_.pointLightInnerRadius = maxSize;

        while (light_.pointLightInnerRadius >= minSize)
        {
            light_.pointLightInnerRadius -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOutOuter(float speed, float minSize, float maxSize)
    {
        light_.pointLightOuterRadius = maxSize;

        while (light_.pointLightOuterRadius >= minSize)
        {
            light_.pointLightOuterRadius -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
