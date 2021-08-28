using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadSword : Weapon {
    Camera cam;

    protected override void Awake() {
        base.Awake();
        cam = FindObjectOfType<Camera>();
    }

    protected override Collider2D[] GetBasicCollisions() {
        return Physics2D.OverlapCircleAll(transform.position, collisionRange, enemyLayer);
    }

    protected override void SpecialAction() {
        Vector2 dir = ( cam.ScreenToWorldPoint(Input.mousePosition)).normalized;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle - 135f, Vector3.forward);
        Player.OnBroadSwordSpecialAttack?.Invoke(dir, 10f, 1f);
    }
}
