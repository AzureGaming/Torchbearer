using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public delegate void BroadSwordSpecialAttack(Vector2 dir, float strength, float time, Action cb);
    public static BroadSwordSpecialAttack OnBroadSwordSpecialAttack;

    public Transform dashTarget;

    Rigidbody2D rb;
    Animator animator;
    Camera cam;

    Vector2 movement;
    float speed = 3f;
    bool isDashing = false;

    private void OnEnable() {
        OnBroadSwordSpecialAttack += StartDash;
    }

    private void OnDisable() {
        OnBroadSwordSpecialAttack -= StartDash;
    }

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
        } else if (Input.GetMouseButtonDown(1)) {
            SpecialAttack();
        }
    }

    private void FixedUpdate() {
       if (!isDashing) {
           rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
       }
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
        Weapon.OnBasicAttack?.Invoke();
    }

    void SpecialAttack() {
        Weapon.OnSpecialAttack?.Invoke();
    }

    void StartDash(Vector2 dir, float strength, float time, Action cb) {
        GetComponentInChildren<FaceMouse>().enabled = false;
        GetComponentInChildren<WeaponPosition>().enabled = false;
        StartCoroutine(Dash(dir, strength, time, cb));
    }

    IEnumerator Dash(Vector2 dir, float distance, float time, Action cb) {
        isDashing = true;
        float timeElapsed = 0f;
        Vector2 destination = dashTarget.position;
        Vector2 start = transform.position;
        while (timeElapsed <= time) {
          Vector2 newPos = Vector2.Lerp(start, destination, (timeElapsed / time));
          rb.MovePosition(newPos);
          timeElapsed += Time.deltaTime;
          yield return null;
        }
        
        isDashing = false;
        GetComponentInChildren<FaceMouse>().enabled = true;
        GetComponentInChildren<WeaponPosition>().enabled = true;
        cb();
    }
}
