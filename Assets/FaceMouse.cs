using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    public Transform target;
    Camera cam;

    private void Awake() {
        cam = FindObjectOfType<Camera>();
    }

    void Update() {
        Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - target.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 135f, Vector3.forward);
    }
}
