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
            GameObject player = Instantiate(playerPrefab, spawnPoint.transform);
            Follow.OnPlayerSpawned?.Invoke(player.transform);
        }
    }
}
