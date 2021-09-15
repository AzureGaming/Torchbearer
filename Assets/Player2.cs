using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    Animator animator;
    Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    public AudioSource slide;
    public float movementSpeed = 3f;
    public float dashSpeed = 2f;
    bool isRolling = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animate();

        if (Input.GetMouseButtonDown(0)) {
            Roll();
        }
    }

    private void FixedUpdate() {
        if (!isRolling) {
            rb.AddForce(movement * movementSpeed);
        }
    }

    void Animate() {
        Vector2 mousePosDir;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x -= transform.position.x;
        mousePos.y -= transform.position.y;
        mousePosDir = mousePos.normalized;
        animator.SetFloat("Horizontal", mousePosDir.x);
        animator.SetFloat("Vertical", mousePosDir.y);
    }

    void Roll() {
        StartCoroutine(RollRoutine());
    }

    IEnumerator RollRoutine() {
        rb.velocity = Vector2.zero;
        isRolling = true;
        Vector2 start = transform.position;
        Vector2 target = (Vector2)transform.position + movement.normalized * dashSpeed;
        float timeElapsed = 0f;
        float rollTime = 0.15f;

        slide.time = 2.5f;
        slide.Play();

        while ((Vector2)transform.position != target) {
            Vector2 newPos = Vector2.Lerp(start, target, ( timeElapsed / rollTime ));
            rb.MovePosition(newPos);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        isRolling = false;
    }
}
