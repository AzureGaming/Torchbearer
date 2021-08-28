using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public delegate void BasicAttack();
    public static BasicAttack OnBasicAttack;

    public delegate void SpecialAttack();
    public static SpecialAttack OnSpecialAttack;

    public AudioSource basicAttack;
    public AudioSource basicHit;
    public AudioSource specialAttack;
    public AudioSource specialHit;
    public LayerMask enemyLayer;

    public float collisionRange;
    public float knockbackStrength;

    Animator animator;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        OnBasicAttack += Attack;
        OnSpecialAttack += Attack2;
    }

    private void OnDisable() {
        OnBasicAttack -= Attack;
        OnSpecialAttack -= Attack2;
    }

    void Attack() {
        animator.SetTrigger("Attack");
        CheckBasicCollision();
        basicAttack.Play();
    }

    void Attack2() {
        animator.SetTrigger("Special Attack");
        SpecialAction();
        CheckSpecialCollision();
        specialAttack.Play();
    }

    void CheckBasicCollision() {
        Collider2D[] collisions = GetBasicCollisions();

        foreach (Collider2D collision in collisions) {
            collision.GetComponent<Enemy>().TakeDamage(transform.position, knockbackStrength);
            basicHit.Play();
        }
    }

    void CheckSpecialCollision() {
        Collider2D[] collisions = GetBasicCollisions();

        foreach (Collider2D collision in collisions) {
            collision.GetComponent<Enemy>().TakeDamage(transform.position, knockbackStrength);
            specialHit.Play();
        }
    }

    protected virtual Collider2D[] GetBasicCollisions() {
        return new Collider2D[] { };
    }

    protected virtual Collider2D[] GetSpecialCollisions() {
        return new Collider2D[] { };
    }

    protected virtual void SpecialAction() {
    
    }
}
