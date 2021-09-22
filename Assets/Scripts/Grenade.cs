using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public GameObject explosionPrefab;
    public AudioSource explosion;
    public float hitRadius;
    public float knockback;

    SpriteRenderer spriteR;

    private void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void ArcToPosition(Vector3 start, Vector3 target) {
        StartCoroutine(ArcToPositionRoutine(start, target));
    }

    public void Explode() {
        explosion.Play();
        SpawnExplosion();
        CheckCollisions();
        spriteR.enabled = false;
        StartCoroutine(DestroySelf());
    }

    IEnumerator ArcToPositionRoutine(Vector3 start, Vector3 target) {
        float timeElapsed = 0f;
        float travelTime = 1f;
        float arcHeight = 1;
        float dist = target.x - start.x;

        while (timeElapsed <= travelTime) {
            Vector2 newPos = Vector2.Lerp(start, target, ( timeElapsed / travelTime ));
            float arc = arcHeight * ( newPos.x - start.x ) * ( newPos.x - target.x ) / ( -0.25f * dist * dist );

            newPos.y += arc;
            transform.position = newPos;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
        Explode();
    }

    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
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

    void SpawnExplosion() {
        Instantiate(explosionPrefab, transform);
    }
}
