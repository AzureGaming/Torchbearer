using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    private void OnEnable() {
        OnPyreIgnite += Win;
    }

    private void OnDisable() {
        OnPyreIgnite -= Win;
    }


    private void Start() {
        LoadLevel();
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
        SceneManager.LoadScene(scene);
    }
}
