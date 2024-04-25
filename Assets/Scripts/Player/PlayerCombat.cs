using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Attack();
        else NoAttack();
    }
    private void Attack()
    {
        animator.SetBool("attack",true);
    }
    private void NoAttack()
    {
        animator.SetBool("attack", false);
    }
}
