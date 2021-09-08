using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToInputDirection : MonoBehaviour {
    void Update() {
        Vector2 moveDir;
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        transform.right = moveDir.normalized;
    }
}
