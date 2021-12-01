using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    KeyCode keyUp = KeyCode.W;
    KeyCode keyRight = KeyCode.D;
    KeyCode keyDown = KeyCode.S;
    KeyCode keyLeft = KeyCode.A;
    KeyCode lastKey;
    public float speed = 3f;
    public float dashDistance = 2f;
    public float dashTime = 0.25f;
    public float secondDashWindow = 0.5f;
    public float secondDashDistance = 2f;
    public float secondDashTime = 0.25f;

    bool queueDash = false;
    bool dashing = false;
    bool canMove = true;
    Vector2 movement;
    SpriteRenderer spriteR;
    KeyCode[] keys;

    private void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
        keys = new KeyCode[] { keyUp, keyRight, keyDown, keyLeft };
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (AnyKeyDown(keys) && !dashing) {
            for (int i = 0; i < keys.Length; i++) {
                if (Input.GetKey(keys[i])) {
                    lastKey = keys[i];
                    break;
                }
            }
            queueDash = true;
        }
    }

    private void FixedUpdate() {
        if (queueDash) {
            queueDash = false;
            canMove = false;
            Dash();
        } else if (canMove) {
            FollowMouse();
        }
    }

    void FollowMouse() {
        Vector3 mousePxPos = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePxPos);
        mousePos.z = transform.position.z;
        Vector2 dir = ( mousePos - transform.position ).normalized;
        Vector2 newPos = (Vector2)transform.position + ( dir * speed * Time.deltaTime );

        transform.position = newPos;
    }

    void Dash() {
        StartCoroutine(DashRoutine());
    }

    IEnumerator DashRoutine() {
        Vector2 start = transform.position;
        Vector2 target = start + movement * dashDistance;
        Vector2 lastMovement = movement;

        dashing = true;

        spriteR.color = Color.red;
        yield return StartCoroutine(MoveTo(start, target, dashTime));
        spriteR.color = Color.yellow;

        bool secondDash = false;
        float timeElapsed = 0f;
        yield return new WaitUntil(() => {
            if (timeElapsed > secondDashWindow) {
                return true;
            } else if (Input.GetKeyDown(lastKey)) {
                secondDash = true;
                return true;
            }

            timeElapsed += Time.deltaTime;
            return false;
        });

        if (secondDash) {
            start = transform.position;
            target = start + lastMovement * secondDashDistance;
            yield return StartCoroutine(MoveTo(start, target, secondDashTime));
        }

        spriteR.color = Color.white;
        canMove = true;
        dashing = false;
    }

    bool AnyKeyDown(KeyCode[] keys) {
        foreach (KeyCode key in keys) {
            if (Input.GetKeyDown(key)) {
                return true;
            }
        }
        return false;
    }

    IEnumerator MoveTo(Vector2 start, Vector2 target, float seconds) {
        float timeElapsed = 0f;
        while (timeElapsed <= seconds) {
            Vector2 newPos = Vector2.Lerp(start, target, ( timeElapsed / seconds ));
            transform.position = newPos;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }
}
