using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void UseMagic()
    {
        if (animator != null)
        {
            animator.SetTrigger("attack");
        }
    }
}
