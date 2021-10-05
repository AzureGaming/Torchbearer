using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    public GameObject playerPrefab;
    public static int currentScene = 0;

    private void OnEnable() {
        OnPyreIgnite += RoomClear;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        OnPyreIgnite -= RoomClear;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void RoomClear() {
        Enemy.OnPyreIgnite?.Invoke();
        CanvasManager.OnRoomClear?.Invoke();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        //SpawnPlayer();
    }

    void SpawnPlayer() {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Spawn");

        if (spawnPoint) {
            Debug.Log("Spawn");
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
    }
}
