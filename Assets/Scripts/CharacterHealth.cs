using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{

    public GameObject UICanvas;
    public GameObject GameOverCanvas;
    public Sprite full_pear;

    public static GameObject[] health_pears;
    public static int characterHealth = 6;


    private void Start()
    {
        characterHealth = 6;        
        GameOverCanvas.SetActive(false);
        UICanvas.SetActive(true);
        health_pears = GameObject.FindGameObjectsWithTag("health");
        foreach (GameObject pear in health_pears)
        {
            pear.SetActive(true);
            pear.GetComponent<Image>().sprite = full_pear;
        }
    }

    private void Update()
    {
        if (characterHealth <= 0)
        {
            GameOverCanvas.SetActive(true);
            UICanvas.SetActive(false);
        }

    }

}
