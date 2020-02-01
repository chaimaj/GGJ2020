
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
   
    Vector2 movement;
    float idleTimer = 0;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Idle", idleTimer);



    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
        {
                idleTimer = 0;
        }
        else
        {
                idleTimer += Time.fixedDeltaTime;
        }
       
    }
}
