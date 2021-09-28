using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    public bool isDebug;
    int currentScene = 0;

    private void OnEnable() {
        OnPyreIgnite += RoomClear;
    }

    private void OnDisable() {
        OnPyreIgnite -= RoomClear;
    }

    private void Start() {
        CanvasManager.OnRoomInit?.Invoke();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            LoadLevel();
        }
    }

    void RoomClear() {
        Enemy.OnPyreIgnite?.Invoke();
        CanvasManager.OnRoomClear?.Invoke();
        //LoadLevel();
    }

    void LoadLevel() {
        currentScene += 1;
        SceneManager.LoadScene(currentScene);
    }
}
