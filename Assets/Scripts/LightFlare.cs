using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightFlare : MonoBehaviour
{

    
    public float flareInterval = 3f;
    
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
                light_.pointLightInnerRadius = smallInnerRadius;
                light_.pointLightOuterRadius = smallOuterRadius;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was released.");
            if (numFlares > 0) { 
                light_.pointLightInnerRadius = largeInnerRadius;
                light_.pointLightOuterRadius = largeOuterRadius;
                flareOn = true;
                lastFlareTime = Time.time;
                numFlares--;
                matches[numFlares].SetActive(false);
            }
        }

    }
}
