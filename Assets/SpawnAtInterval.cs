using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtInterval : MonoBehaviour {
    public GameObject objToSpawn;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        for (; ; ) {
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
