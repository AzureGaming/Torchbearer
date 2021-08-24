using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public delegate void PlayerSpawned(Transform player);
    public static PlayerSpawned OnPlayerSpawned;

    public Vector3 offset;
    public Transform target;

    private void OnEnable() {
        OnPlayerSpawned += UpdateTargetRef;
    }

    private void OnDisable() {
        OnPlayerSpawned -= UpdateTargetRef;
    }

    private void FixedUpdate() {
        if (target) {
            transform.position = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
        }
    }

    void UpdateTargetRef(Transform newTarget) {
        target = newTarget;
    }
}
