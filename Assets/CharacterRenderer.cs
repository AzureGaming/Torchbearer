using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour {
    public Animator animator;

    Vector2 lastMovement;

    public void SetMovement(Vector2 movement) {
        if (movement == Vector2.zero) {
            animator.SetFloat("Horizontal", lastMovement.x);
            animator.SetFloat("Vertical", lastMovement.y);
        } else {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            lastMovement = movement;
        }
        animator.SetFloat("Speed", movement.magnitude);
    }
}
