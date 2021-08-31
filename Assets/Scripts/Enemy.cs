using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator animator;
    Collider2D collider2d;
    Rigidbody2D rb;

    private void Awake() {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(Vector2 sourcePos, float knockback) {
        animator.SetTrigger("Hurt");
        TakeKnockback(sourcePos, knockback);
        //collider2d.enabled = false;
    }

    void TakeKnockback(Vector2 sourcePos, float knockback) {
        Vector2 dir = ( (Vector2)transform.position - sourcePos ).normalized;
        Vector2 force = dir * knockback;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
