using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public float jumpFactor = 1f;
    public float slideFactor = 1f;
    public float slideWindow = 0.5f;


    Rigidbody2D rb;
    SpriteRenderer spriteR;
    Animator animator;
    Vector2 mousePos;
    Coroutine jumpRoutine;
    Coroutine slideRoutine;

    bool queueJump;
    bool queueSlide;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 normalizedMousePos = new Vector2(mousePos.x, mousePos.y).normalized;
        animator.SetFloat("Horizontal", normalizedMousePos.x);
        animator.SetFloat("Vertical", normalizedMousePos.y);

        Flip();

        if (Input.GetMouseButtonDown(0) && jumpRoutine == null) {
            queueJump = true;
        } else if (Input.GetMouseButtonDown(1) && slideRoutine == null && jumpRoutine == null) {
            queueSlide = true;
        }
    }

    private void FixedUpdate() {
        if (queueJump && jumpRoutine == null) {
            jumpRoutine = StartCoroutine(Jump());
            queueJump = false;
        } else if (queueSlide && slideRoutine == null) {
            slideRoutine = StartCoroutine(Slide());
            queueSlide = false;
        } else if (jumpRoutine == null && slideRoutine == null) {
            Vector2 dir = ( mousePos - (Vector2)transform.position ).normalized;
            Vector2 newPos = (Vector2)transform.position + dir * speed * Time.deltaTime;
            rb.MovePosition(newPos);
        }
    }

    void Flip() {
        if (mousePos.normalized.x > 0) {
            spriteR.flipX = true;
        } else {
            spriteR.flipX = false;
        }
    }

    IEnumerator Jump() {
        float jumpStrength = 1f;
        while (Input.GetMouseButton(0)) {
            jumpStrength += 0.01f * jumpFactor;
            yield return null;
        }
        Debug.Log("Jump Strength: " + jumpStrength);
        Vector2 start = transform.position;
        Vector2 dir = ( mousePos - start ).normalized;
        Vector2 target = start + dir * jumpStrength;
        float time = 1f;

        animator.SetTrigger("Jump");
        yield return StartCoroutine(MoveTo(start, target, time));

        float elapsed = 0f;

        while (elapsed <= slideWindow) {
            spriteR.color = Color.green;
            if (Input.GetMouseButtonDown(1)) {
                slideRoutine = StartCoroutine(Slide());
                break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        spriteR.color = Color.white;
        jumpRoutine = null;
    }

    IEnumerator Slide() {
        animator.SetTrigger("Slide");
        Vector2 start = transform.position;
        Vector2 dir = ( mousePos - start ).normalized;
        Vector2 target = start + dir * slideFactor;
        float time = 0.5f;

        yield return StartCoroutine(MoveTo(start, target, time));
        slideRoutine = null;
    }

    IEnumerator MoveTo(Vector2 start, Vector2 target, float time) {
        float elapsed = 0f;
        while (elapsed < time) {
            Vector2 newPos = Vector2.Lerp(start, target, ( elapsed / time ));
            rb.MovePosition(newPos);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }
}
