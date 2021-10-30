using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    private void Start() {
        FacePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
        }   
    }

    void FacePlayer() {
        transform.right = FindObjectOfType<Player2>().transform.position - transform.position;
    }
}
