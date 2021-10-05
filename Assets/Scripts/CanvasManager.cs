using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    //public delegate void RoomInit();
    //public static RoomInit OnRoomInit;

    public delegate void RoomClear();
    public static RoomClear OnRoomClear;

    public GameObject nextButton;

    private void OnEnable() {
        //OnRoomInit += () => SetNextButton(false);
        OnRoomClear += () => SetNextButton(true);
    }

    private void OnDisable() {
        //OnRoomInit -= () => SetNextButton(false);
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
