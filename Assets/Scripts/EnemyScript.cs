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
            for (int i = CharacterHealth.health_pears.Length - 1; i >= index; i--)
            {
                CharacterHealth.health_pears[i].SetActive(false);
            }            
        }
        else
        {
            for (int i = CharacterHealth.health_pears.Length - 1; i > index; i--)
            {
                CharacterHealth.health_pears[i].SetActive(false);
            }
            CharacterHealth.health_pears[index].GetComponent<Image>().sprite = half_pear;
        }
    }
}
