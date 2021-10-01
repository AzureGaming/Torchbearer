using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Health health;
    public Slider slider;

    private void Update() {
        slider.value = health.value;
    }
}
