using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    Animator animator;
    Rigidbody2D rb;
    Collider2D collider2d;

    Vector2 movement;
    Vector2 mousePos;

    public AudioSource slide;
    public float movementSpeed = 3f;
    public float dashSpeed = 2f;
    public float dashCollisionRadius;
    public float dashCollisionForce = 5f;
    public Transform dashCollisionPoint;
    bool isRolling = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animate();

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (movement != Vector2.zero) {
                Roll();
            }
        }
    }

    private void FixedUpdate() {
        if (!isRolling) {
            rb.AddForce(movement * movementSpeed);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dashCollisionRadius);
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
        collider2d.enabled = false;
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

        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, dashCollisionRadius, LayerMask.GetMask(new string[1] { "Dash Attack" }));

        foreach (Collider2D collision in collisions) {
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();
            Vector2 point = (Vector2)transform.position + direction * dashCollisionRadius;
            float distanceFromPerimeter = Vector2.Distance(collision.transform.position, point);
            float force = distanceFromPerimeter * dashCollisionForce;

            collision.GetComponent<DashAttackTarget>().TakeDamage(transform.position, force);
        }
        collider2d.enabled = true;
    }
}
