using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    float speed = 3f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        animator.SetBool("Grounded", true);
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animate();
        Flip();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void Animate() {
        animator.SetInteger("AnimState", (int)movement.magnitude);

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack1");
        }
    }

    void Flip() {
        Vector3 newScale = transform.localScale;
        if (movement.x > 0) {
            newScale.x = 1f;
        } else if (movement.x < 0) {
            newScale.x = -1f;
        }
        transform.localScale = newScale;
    }
}
