using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    public GameObject hitbox;
    public GameObject aggroRange;
    public GameObject dashHurtbox;
    public float speed;

    Animator animator;
    SpriteRenderer spriteR;
    Collider2D collider2d;
    Rigidbody2D rb;

    bool isDead = false;

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
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(Vector2 sourcePos, float knockback) {
        TakeKnockback(sourcePos, knockback);
        Die();
    }

    public IEnumerator FollowPlayer() {
        for (; ; ) {
            Vector2 target = FindObjectOfType<Player2>().transform.position;
            Vector2 direction = ( target - (Vector2)transform.position ).normalized;
            Vector2 newPos = (Vector2)transform.position + direction * speed;
            if (direction.x > 0) {
                spriteR.flipX = false;
            } else {
                spriteR.flipX = true;
            }

            animator.SetFloat("Speed", newPos.magnitude);
            rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    void TakeKnockback(Vector2 sourcePos, float knockback) {
        Vector2 dir = ( (Vector2)transform.position - sourcePos ).normalized;
        Vector2 force = dir * knockback;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Die() {
        if (!isDead) {
            isDead = true;
            animator.SetTrigger("Death");
            collider2d.enabled = false;
            hitbox.SetActive(false);
            aggroRange.SetActive(false);
            dashHurtbox.SetActive(false);
            rb.bodyType = RigidbodyType2D.Static;
            rb.simulated = false;
        }
    }
}
