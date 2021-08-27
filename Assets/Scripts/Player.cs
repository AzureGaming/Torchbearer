using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    Animator animator;
    Camera cam;

    Vector2 movement;
    float speed = 3f;
    float attackRange = 2f;
    bool isAttacking = false;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = FindObjectOfType<Camera>();
    }

    private void Start() {
        animator.SetBool("Grounded", true);
        Follow.OnPlayerSpawned?.Invoke(transform);
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animate();

        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void Animate() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x -= transform.position.x;
        mousePos.y -= transform.position.y;
        mousePos = mousePos.normalized;
        animator.SetFloat("Horizontal", mousePos.x);
        animator.SetFloat("Vertical", mousePos.y);
    }

    void Attack() {
        Weapon.OnActivate?.Invoke();
    }
}
