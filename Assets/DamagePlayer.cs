using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<Player2>().TakeDamage();
        FindObjectOfType<TorchMeter>().GetComponent<Health>().Subtract(20);
    }
}
