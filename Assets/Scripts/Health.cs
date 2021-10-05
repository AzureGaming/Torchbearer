using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int value;
    public int maxValue;

    public void Add(int val) {
        value += val;
        if (value > maxValue) {
            value = maxValue;
        }
    }

    public void Subtract(int val) {
        value -= val;
        if (value < 0) {
            value = 0;
        }
    }
}
