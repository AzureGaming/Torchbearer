using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlames : MonoBehaviour {
    public GameObject leftPosition;
    public GameObject rightPosition;
    public GameObject downPosition;
    public GameObject upPosition;
    public Transform flames;

    public void SetLeftPosition() {
        flames.position = leftPosition.transform.position;
    }

    public void SetRightPosition() {
        flames.position = rightPosition.transform.position;
    }

    public void SetDownPosition() {
        flames.position = downPosition.transform.position;
    }

    public void SetUpPosition() {
        flames.position = upPosition.transform.position;
    }
}
