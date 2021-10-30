using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour {
    public UnityEvent listeners;

    private void OnTriggerEnter2D(Collider2D collision) {
        listeners?.Invoke();
    }
}
