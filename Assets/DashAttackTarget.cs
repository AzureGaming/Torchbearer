using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackTarget : MonoBehaviour {
    public void TakeDamage(Vector2 sourcePos, float knockback) {
        GetComponentInParent<Enemy>().TakeDamage(sourcePos, knockback);
    }
}
