using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHitboxTriggerOnStart : MonoBehaviour {
    void Start() {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
