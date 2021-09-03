using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public delegate void BroadSwordSpecialAttack(Vector2 dir, float strength, float time, Action cb);
    public static BroadSwordSpecialAttack OnBroadSwordSpecialAttack;

    public GameObject rollPrefab;
    public Transform dashTarget;
    public AudioSource roll;

    Rigidbody2D rb;
    Animator animator;
    Camera cam;

    Vector2 movement;
    float speed = 3f;
    bool isDashing = false;
    bool isRolling = false;

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
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            Roll();
        }
    }

    private void FixedUpdate() {
        if (!isDashing && !isRolling) {
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

    void Roll() {
        StartCoroutine(RollRoutine());
    }

    IEnumerator RollRoutine() {
        if (movement.normalized != Vector2.zero) { // only roll when movement is detected
            roll.Play();
            isRolling = true;

            GameObject rollEffect = Instantiate(rollPrefab, transform);
            rollEffect.transform.up = -movement.normalized;

            float timeElapsed = 0f;
            float rollTime = 0.15f;
            Vector2 start = transform.position;
            Vector2 target = (Vector2)transform.position + movement.normalized * 3f;
            while (timeElapsed <= rollTime) {
                Vector2 newPos = Vector2.Lerp(start, target, ( timeElapsed / rollTime ));
                rb.MovePosition(newPos);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            Destroy(rollEffect);
            isRolling = false;
        }
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
            Vector2 newPos = Vector2.Lerp(start, destination, ( timeElapsed / time ));
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
