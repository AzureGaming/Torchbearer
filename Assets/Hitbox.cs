using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// enemy hitbox
public class Hitbox : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<Player2>().TakeDamage();
        FindObjectOfType<TorchMeter>().GetComponent<Health>().Subtract(20);
    }
}
