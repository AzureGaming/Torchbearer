using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour {
    public Transform origin;
    public float offset;

    void Update() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - origin.position.y, mouse.x - origin.position.x) * Mathf.Rad2Deg - 90);
        mouse.z = 0f;
        Vector3 newPos = origin.position + transform.up * offset;
        transform.position = newPos;
    }
}
