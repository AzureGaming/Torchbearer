using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    public bool isDebug;

    private void OnEnable() {
        OnPyreIgnite += Win;
    }

    private void OnDisable() {
        OnPyreIgnite -= Win;
    }


    private void Start() {
        if (!isDebug) {
            LoadLevel();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            LoadLevel();
        }
    }

    void Win() {
        LoadLevel();
    }

    void LoadLevel() {
        int scene = Random.Range(0, 3);
        SceneManager.LoadScene(0);
    }
}
