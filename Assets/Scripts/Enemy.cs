using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator animator;
    Collider2D collider2d;

    private void Awake() {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
    }

    public void TakeDamage() {
        animator.SetTrigger("Death");
        collider2d.enabled = false;
    }
}
