using UnityEngine;

public class BushCollision : MonoBehaviour
{

    private SoundManager sm_instance = null;

    // Start is called before the first frame update
    void Start()
    {
        sm_instance = SoundManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        sm_instance.PlayRandomTheme(sm_instance.collisions);
    }
}
