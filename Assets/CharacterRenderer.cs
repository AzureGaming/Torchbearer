using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour {
    public Animator animator;

    Vector2 lastMovement;

    public void SetMovement(Vector2 movement) {
        Vector2 target = movement;
        if (movement == Vector2.zero) {
            target = lastMovement;
        }

        animator.SetFloat("Horizontal", target.x);
        animator.SetFloat("Vertical", target.y);
        lastMovement = movement;
        animator.SetFloat("Speed", movement.magnitude);
    }
}
