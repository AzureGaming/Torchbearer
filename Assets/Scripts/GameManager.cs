using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public delegate void PyreIgnite();
    public static PyreIgnite OnPyreIgnite;

    private void OnEnable() {
        OnPyreIgnite += Win;
    }

    private void OnDisable() {
        OnPyreIgnite -= Win;
    }

    void Win() {
        Debug.LogWarning("Impleemnt Win");
    }
}
