using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyre : MonoBehaviour {
    public AudioSource ignite;

    public bool _isActive = false;
    public bool isActive {
        get => _isActive;
        set {
            _isActive = value;
            Ignite();
        }
    }

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isActive) {
            isActive = true;
            Ignite();
        }
    }

    void Ignite() {
        animator.SetBool("Active", isActive);
        if (isActive) {
            PlayIgniteSound();
            GameManager.OnPyreIgnite?.Invoke();
        }
    }

    // Hack to expose setter in inspector
    private void OnValidate() {
        if (animator) {
            isActive = _isActive;
        }
    }

    void PlayIgniteSound() {
        List<float[]> times = new List<float[]>();
        times.Add(new float[2] { 0, 1.7f });
        ignite.time = times[0][0];
        ignite.Play();
    }
}
