using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public AudioSource explosion;
    public float hitRadius;
    public float knockback;

    SpriteRenderer spriteR;

    private void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void Explode() {
        explosion.Play();
        CheckCollisions();
        spriteR.enabled = false;
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(0.35f);
        gameObject.SetActive(false);
    }

    void CheckCollisions() {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, hitRadius);

        foreach (Collider2D collision in collisions) {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy) {
                enemy.TakeDamage(transform.position, knockback);
            }
        }
    }
}
