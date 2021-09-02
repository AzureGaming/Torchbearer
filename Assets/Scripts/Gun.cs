using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
    public Transform hitboxOrigin;
    public GameObject grenadePrefab;
    public Transform grenadeTarget;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(hitboxOrigin.position, transform.right * collisionRange);
    }

    protected override void Attack() {
        animator.SetTrigger("Attack");
        PlayBasicAttack();
        CheckBasicCollision();
    }

    protected override void Attack2() {
        specialAttack.Play();
        StartCoroutine(ThrowGrenade());
    }

    void PlayBasicAttack() {
        // Only the first sound effect
        float startTime = 0.05f;
        float endTime = 0.5f;

        basicAttack.time = startTime;
        basicAttack.Play();
        basicAttack.SetScheduledEndTime(AudioSettings.dspTime + ( endTime - startTime ));
    }

    void CheckBasicCollision() {
        RaycastHit2D hit = Physics2D.Raycast(hitboxOrigin.position, transform.right, collisionRange);
        if (hit.collider != null) {
            if (hit.collider.GetComponent<Enemy>()) {
                hit.collider.GetComponent<Enemy>().TakeDamage(transform.position, knockbackStrength);
                basicHit.Play();
            }
        }
    }

    IEnumerator ThrowGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, hitboxOrigin.position, Quaternion.identity);
        float timeElapsed = 0f;
        float travelTime = 1f;
        Vector3 destination = grenadeTarget.position;
        Vector3 start = grenade.transform.position;

        while (timeElapsed <= travelTime) {
            Vector2 newPos = Vector2.Lerp(start, destination, ( timeElapsed / travelTime ));

            grenade.transform.position = newPos;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        grenade.transform.position = destination;
        grenade.GetComponent<Grenade>().Explode();
    }
}
