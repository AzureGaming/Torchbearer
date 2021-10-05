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

    protected Animator animator;

    public float collisionRange;
    public float knockbackStrength;

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

    protected virtual void Attack() {
    }

    protected virtual void Attack2() {
    }
}
