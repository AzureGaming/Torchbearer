using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtInterval : MonoBehaviour {
    public GameObject objToSpawn;
    int counter = 0;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        for (; ; ) {
            float seconds;
            if (counter >= 5 && counter <= 10) {
                seconds = 0.3f;
            } else {
                seconds = 1f;
            }
            counter++;
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(seconds);

            if (counter == 10) {
                counter = 0;
            }
        }
    }
}
