using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public delegate void Activate();
    public static Activate OnActivate;

    public AudioSource activate;
    public AudioSource hit;
    public LayerMask enemyLayer;

    public float collisionRange;
    public float knockbackStrength;

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
        Collider2D[] collisions = GetCollisions();

        foreach (Collider2D collision in collisions) {
            collision.GetComponent<Enemy>().TakeDamage(transform.position, knockbackStrength);
            hit.Play();
        }
    }

    protected virtual Collider2D[] GetCollisions() {
        return new Collider2D[] { };
    }
}
