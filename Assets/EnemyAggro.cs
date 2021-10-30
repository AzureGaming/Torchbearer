using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour {
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            StartCoroutine(GetComponentInParent<Enemy>().FollowPlayer());
        }
    }
}
