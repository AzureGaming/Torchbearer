using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    public delegate void RoomClear();
    public static RoomClear OnRoomClear;

    public GameObject nextButton;

    private void OnEnable() {
        OnRoomClear += () => SetNextButton(true);
    }

    private void OnDisable() {
        OnRoomClear -= () => SetNextButton(true);
    }

    private void Start() {
        SetNextButton(false);
    }

    void SetNextButton(bool isActive) {
        if (nextButton != null) {
            nextButton.SetActive(isActive);
        }
    }
}
