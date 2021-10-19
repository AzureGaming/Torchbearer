using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour {
    public Animator animator;

    Vector2 lastMovement;

    public void SetMovement(Vector2 movement) {
        Vector2 target;
        if (movement == Vector2.zero) {
            target = lastMovement;
        } else {
            target = movement;
            lastMovement = movement;
        }

        animator.SetFloat("Horizontal", target.x);
        animator.SetFloat("Vertical", target.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
}
