using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    //private void Update() {
    //    if (Input.GetMouseButtonDown(0)) {
    //        StartCoroutine(Shake(0.1f, 0.1f));
    //    }
    //}

    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 origPos = transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration) {
            float x = Random.Range(origPos.x - magnitude, origPos.x + magnitude);
            float y = Random.Range(origPos.y - magnitude, origPos.y + magnitude);
            Vector3 newPos = new Vector3(x, y, origPos.z);

            transform.position = newPos;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = origPos;
    }
}
