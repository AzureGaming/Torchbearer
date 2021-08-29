using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    public delegate void Deactivate();
    public static Deactivate OnDeactivate;

    public delegate void Activate();
    public static Activate OnActivate;

    public Transform target;

    Camera cam;
    bool isActive = true; 

    private void Awake() {
        cam = FindObjectOfType<Camera>();
    }

    void OnEnable() {
      OnDeactivate += SetInactive;
      OnActivate += SetActive;
    }

    void OnDisable() {
      OnDeactivate -= SetInactive;
      OnActivate -= SetActive;
    }

    void Update() {
      if (isActive) {
        Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - target.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 135f, Vector3.forward);
      }
    }

    void SetActive() {
      isActive = true;
    }

    void SetInactive() {
      isActive = false;
    }
}
