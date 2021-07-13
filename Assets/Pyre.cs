using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyre : MonoBehaviour {

    bool _isActive = false;
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
        if (collision.CompareTag("Player")) {
            Ignite();
        }
    }

    void Ignite() {
        if (!isActive) {
            animator.SetBool("Active", true);
            GameManager.OnPyreIgnite?.Invoke();
        }
    }
}
