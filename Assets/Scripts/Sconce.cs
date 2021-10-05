using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sconce : MonoBehaviour {
    public GameObject lightSource;
    public AudioSource ignite;

    bool isActive = false;

    private void Start() {
        lightSource.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isActive) {
            isActive = true;
            lightSource.SetActive(true);
            collision.GetComponent<Health>().Add(25);
            PlayIgnite();
        }
    }

    void PlayIgnite() {
        List<float[]> times = new List<float[]>();
        //times.Add(new float[2] { 0f, 1.6f });
        times.Add(new float[2] { 10.4f, 11.8f });
        PlaySoundInterval(ignite, times[0][0], times[0][1]);
    }

    void PlaySoundInterval(AudioSource audio, float start, float end) {
        audio.time = start;
        audio.Play();
        audio.SetScheduledEndTime(AudioSettings.dspTime + ( end - start ));
    }
}
