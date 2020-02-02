using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{


    public int damage = 1;

    public Sprite half_pear;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        CharacterHealth.characterHealth -= damage;
        int index = CharacterHealth.characterHealth / 2;
        if (CharacterHealth.characterHealth % 2 == 0)
        {
            CharacterHealth.health_pears[index].SetActive(false);
        }
        else
        {
            CharacterHealth.health_pears[index].GetComponent<Image>().sprite = half_pear;
        }
    }
}
