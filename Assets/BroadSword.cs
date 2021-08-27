using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadSword : Weapon {
    protected override Collider2D[] GetCollisions() {
        return Physics2D.OverlapCircleAll(transform.position, collisionRange, enemyLayer);
    }
}
