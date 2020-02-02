using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLauncher : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update

   public void TaskOnClick()
    {
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }
}