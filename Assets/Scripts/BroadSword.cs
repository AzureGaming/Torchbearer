using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadSword : Weapon {
    Camera cam;

    protected override void Awake() {
        base.Awake();
        cam = FindObjectOfType<Camera>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Roll();
        }
    }

    protected override void Attack() {
        animator.SetTrigger("Attack");
        CheckBasicCollision();
        basicAttack.Play();
    }

    protected override void Attack2() {
        SpecialAction(() => {
            animator.SetTrigger("Special Attack");
            CheckSpecialCollision();
            specialAttack.Play();
        });
    }

    void Roll() {
        Player.OnBroadSwordDash?.Invoke();
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

    Collider2D[] GetBasicCollisions() {
        return Physics2D.OverlapCircleAll(transform.position, collisionRange, enemyLayer);
    }

    void SpecialAction(Action cb) {
        Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition).normalized;
        Player.OnBroadSwordSpecialAttack?.Invoke(dir, 10f, 0.25f, cb);
    }
}
