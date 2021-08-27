using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    Camera cam;

    private void Awake() {
        cam = FindObjectOfType<Camera>();
    }

    void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.right = mousePos;
    }
}
