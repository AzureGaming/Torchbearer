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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dash();
        }
    }

    protected override void Attack() {
        animator.SetTrigger("Attack");
        PlayBasicAttack();
        CheckBasicCollision();
    }

    protected override void Attack2() {
        specialAttack.Play();
        ThrowGrenade();
    }

    void Dash() {
        Player.OnGunDash?.Invoke();
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

    // https://luminaryapps.com/blog/arcing-projectiles-in-unity/
    void ThrowGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, hitboxOrigin.position, Quaternion.identity);
        grenade.GetComponent<Grenade>().ArcToPosition(grenade.transform.position, grenadeTarget.position);
        WeaponSwitch.OnWeaponSwitchValid?.Invoke();
    }
}
