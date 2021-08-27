using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public delegate void Activate();
    public static Activate OnActivate;

    public AudioSource activate;
    public AudioSource hit;
    public LayerMask enemyLayer;

    public float range;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        OnActivate += Attack;
    }

    private void OnDisable() {
        OnActivate -= Attack;
    }

    void Attack() {
        animator.SetTrigger("Attack");
        CheckCollision();
        activate.Play();
    }

    void CheckCollision() {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);

        foreach (Collider2D collision in collisions) {
            collision.GetComponent<Enemy>().TakeDamage();
            hit.Play();
        }
    }
}
