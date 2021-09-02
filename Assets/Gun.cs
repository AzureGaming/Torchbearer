using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
    public Transform hitboxOrigin;

    protected override void Attack() {
        animator.SetTrigger("Attack");
        PlayBasicAttack();
        CheckBasicCollision();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(hitboxOrigin.position, transform.right * collisionRange);
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
}
