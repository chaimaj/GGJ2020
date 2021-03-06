﻿using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public static int characterHealth = 6;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
   
    Vector2 movement;
    float idleTimer = 0;

    private SoundManager sm_instance = null;

    private void Start()
    {
        sm_instance = SoundManager.instance;
        sm_instance.PlayLoopingThemes(sm_instance.loopingSounds);
        sm_instance.PlayTheme("GamePlay");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Idle", idleTimer);
        if (Math.Abs(movement.x) == 1)
        {
            animator.SetFloat("IdleX", movement.x);
            animator.SetFloat("IdleY", 0);
        }
        if (Math.Abs(movement.y) == 1)
        {
            animator.SetFloat("IdleY", movement.y);
            animator.SetFloat("IdleX", 0);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
        {
            sm_instance.PlayOnce("FootSteps", 2.5f, sm_instance.soundEffects);
            idleTimer = 0;
        }
        else
        {
            sm_instance.StopSound("FootSteps", sm_instance.soundEffects);
            idleTimer += Time.fixedDeltaTime;
        }
       
    }
}
