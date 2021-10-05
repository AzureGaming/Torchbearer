using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Enemy>()) {
            collision.GetComponent<Enemy>().TakeDamage(transform.position, 2f);
        }
    }
}
