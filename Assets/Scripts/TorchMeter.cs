using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMeter : MonoBehaviour {
    public Health health;

    private void Start() {
        StartCoroutine(test());
    }

    IEnumerator test() {
        for (; ; ) {
            health.value--;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
