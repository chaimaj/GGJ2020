using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {

    }

   public void TaskOnClick()
    {
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }
}