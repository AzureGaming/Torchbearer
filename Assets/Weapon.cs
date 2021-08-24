using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public delegate void Attack();
    public static Attack OnAttack;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        OnAttack += Animate;
    }

    private void OnDisable() {
        OnAttack -= Animate;
    }

    void Animate() {
        animator.SetTrigger("Attack");
    }
}
