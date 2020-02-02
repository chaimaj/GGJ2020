using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject GameOverWinCanvas;
    public GameObject UICanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yeey you win!");
            GameOverWinCanvas.SetActive(true);
            UICanvas.SetActive(false);
            Destroy(gameObject);
        }
    }
}
