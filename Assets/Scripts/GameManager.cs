using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    public bool isDebug;
    public static int currentScene = 0;

    private void OnEnable() {
        OnPyreIgnite += RoomClear;
    }

    private void OnDisable() {
        OnPyreIgnite -= RoomClear;
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
