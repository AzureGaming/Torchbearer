using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public delegate void BroadSwordSpecialAttack(Vector2 dir, float strength, float time, Action cb);
    public static BroadSwordSpecialAttack OnBroadSwordSpecialAttack;

    public delegate void BroadSwordDash();
    public static BroadSwordDash OnBroadSwordDash;

    public delegate void GunDash();
    public static GunDash OnGunDash;

    public GameObject rollPrefab;
    public GameObject bulletStormPrefab;
    public GameObject bulletStormHitbox;

    public Transform dashTarget;

    public AudioSource roll;
    public AudioSource bulletStorm;

    Rigidbody2D rb;
    Animator animator;
    Camera cam;
    SpriteRenderer spriteR;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 mousePosDir;

    float speed = 3f;
    bool isCharging = false;
    bool isRolling = false;

    private void OnEnable() {
        OnBroadSwordSpecialAttack += StartCharge;
        OnBroadSwordDash += Roll;
        OnGunDash += StartGunDash;
    }

    private void OnDisable() {
        OnBroadSwordSpecialAttack -= StartCharge;
        OnBroadSwordDash -= Roll;
        OnGunDash -= StartGunDash;
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = FindObjectOfType<Camera>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        animator.SetBool("Grounded", true);
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
        if (!isCharging && !isRolling) {
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }

    public void DoneAction() {
        WeaponSwitch.OnWeaponSwitchValid?.Invoke();
    }

    void Animate() {
        if (!isCharging && !isRolling) {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x -= transform.position.x;
            mousePos.y -= transform.position.y;
            mousePosDir = mousePos.normalized;
            animator.SetFloat("Horizontal", mousePosDir.x);
            animator.SetFloat("Vertical", mousePosDir.y);
        }
    }

    void Attack() {
        WeaponSwitch.OnWeaponSwitchInvalid?.Invoke();
        Weapon.OnBasicAttack?.Invoke();
    }

    void SpecialAttack() {
        WeaponSwitch.OnWeaponSwitchInvalid?.Invoke();
        Weapon.OnSpecialAttack?.Invoke();
    }

    void StartGunDash() {
        WeaponSwitch.OnWeaponSwitchInvalid?.Invoke();
        StartCoroutine(GunDashRoutine());
    }

    IEnumerator GunDashRoutine() {
        bulletStorm.Play();
        isRolling = true;
        spriteR.flipY = true;

        GameObject bulletStormEffect = Instantiate(bulletStormPrefab, transform);
        bulletStormEffect.transform.up = -movement.normalized;

        float timeElapsed = 0f;
        float rollTime = 0.5f;
        Vector2 start = transform.position;
        Vector2 target = (Vector2)transform.position + movement.normalized * 3f;

        bulletStormHitbox.GetComponent<BoxCollider2D>().enabled = true;
        bulletStormHitbox.GetComponent<MoveDirectionTracking>().enabled = false;
        bulletStormHitbox.GetComponent<RotateToInputDirection>().enabled = false;


        while (timeElapsed <= rollTime) {
            Vector2 newPos = Vector2.Lerp(start, target, ( timeElapsed / rollTime ));
            rb.MovePosition(newPos);
            timeElapsed += Time.deltaTime;
            yield return null;
            bulletStormEffect.GetComponent<RotateToInputDirection>().enabled = false;
        }

        bulletStormHitbox.GetComponent<BoxCollider2D>().enabled = false;
        bulletStormHitbox.GetComponent<MoveDirectionTracking>().enabled = true;
        bulletStormHitbox.GetComponent<RotateToInputDirection>().enabled = true;

        Destroy(bulletStormEffect);
        isRolling = false;
        spriteR.flipY = false;
    }

    void Roll() {
        WeaponSwitch.OnWeaponSwitchInvalid?.Invoke();
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

    void StartCharge(Vector2 dir, float strength, float time, Action cb) {
        WeaponSwitch.OnWeaponSwitchInvalid?.Invoke();
        GetComponentInChildren<FaceMouse>().enabled = false;
        GetComponentInChildren<WeaponPosition>().enabled = false;
        StartCoroutine(Charge(dir, strength, time, cb));
    }

    IEnumerator Charge(Vector2 dir, float distance, float time, Action cb) {
        isCharging = true;
        float timeElapsed = 0f;
        Vector2 destination = dashTarget.position;
        Vector2 start = transform.position;
        while (timeElapsed <= time) {
            Vector2 newPos = Vector2.Lerp(start, destination, ( timeElapsed / time ));
            rb.MovePosition(newPos);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        isCharging = false;
        GetComponentInChildren<FaceMouse>().enabled = true;
        GetComponentInChildren<WeaponPosition>().enabled = true;
        cb();
    }
}
