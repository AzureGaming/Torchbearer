using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    Animator animator;
    Collider2D collider2d;
    Rigidbody2D rb;

    private void OnEnable() {
        OnPyreIgnite += Die;
    }

    private void OnDisable() {
        OnPyreIgnite -= Die;
    }

    private void Awake() {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        //StartCoroutine(AIRoutine());
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

    IEnumerator AIRoutine() {
        float moveSpeed = 10f;
        for (; ; ) {
            Vector2 target = FindObjectOfType<Player>().transform.position;
            Vector2 direction = ( target - (Vector2)transform.position ).normalized;
            rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Die() {
        animator.SetTrigger("Death");
        collider2d.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;
    }
}
