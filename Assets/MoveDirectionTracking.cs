using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirectionTracking : MonoBehaviour {
    public Transform origin;
    public float offset;

    Vector2 moveDir;

    void Update() {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        Vector2 newPos = (Vector2)origin.position + moveDir.normalized * offset;
        transform.position = newPos;
    }
}
