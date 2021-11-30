using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    private void Update() {
        FollowMouse();
    }

    void FollowMouse() {
        Vector3 mousePxPos = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePxPos);
        Vector2 dir = -( transform.position - mousePos ).normalized;
        Debug.Log(dir);
        Vector2 newPos = (Vector2)transform.position + ( dir * speed * Time.deltaTime );

        transform.position = newPos;
    }
}
