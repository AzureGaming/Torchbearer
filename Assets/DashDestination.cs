using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDestination : MonoBehaviour {
    public Transform player;

    void Update() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - player.position.y, mouse.x - player.position.x) * Mathf.Rad2Deg - 90);
        mouse.z = 0f;
        Vector3 newPos = player.position + transform.up * 3f;
        transform.position = newPos;

    }
}
