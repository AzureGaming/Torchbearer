using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject playerPrefab;

    void Start() {
        SpawnPlayer();
    }

    void SpawnPlayer() {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Spawn");

        if (spawnPoint) {
            Instantiate(playerPrefab, transform.position, Quaternion.identity, transform.root);
        }
    }
}
