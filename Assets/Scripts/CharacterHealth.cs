using UnityEngine;

public class CharacterHealth : MonoBehaviour
{

    public static GameObject[] health_pears;
    public static int characterHealth = 6;


    private void Start()
    {
        health_pears = GameObject.FindGameObjectsWithTag("health");
    }

    private void Update()
    {
        if (characterHealth <= 0)
        {

        }

    }

}
