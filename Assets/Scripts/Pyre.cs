using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyre : MonoBehaviour {
    public AudioSource ignite;
    public AudioSource fireCrackling;
    public GameObject flameLight;

    public bool _isActive = false;
    public bool isActive {
        get => _isActive;
        set {
            _isActive = value;
            Ignite();
        }
    }

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        Ignite();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isActive) {
            isActive = true;
            Ignite();
        }
    }

    void Ignite() {
        animator.SetBool("Active", isActive);
        if (isActive) {
            flameLight.SetActive(true);
            PlayIgnite();
            PlayFireCracklingSound();
            if (GetComponent<PyreEvent>()) {
                GetComponent<PyreEvent>().TriggerEvent();
            }
        } else {
            fireCrackling.Stop();
            flameLight.SetActive(false);
        }
    }

    // Hack to expose setter in inspector
    private void OnValidate() {
        if (animator) {
            isActive = _isActive;
        }
    }

    void PlayIgnite() {
        List<float[]> times = new List<float[]>();
        //times.Add(new float[2] { 0f, 1.6f });
        times.Add(new float[2] { 10.4f, 11.8f });
        PlaySoundInterval(ignite, times[0][0], times[0][1]);
    }

    void PlayFireCracklingSound() {
        fireCrackling.loop = true;
        fireCrackling.Play();
    }

    void PlaySoundInterval(AudioSource audio, float start, float end) {
        audio.time = start;
        audio.Play();
        audio.SetScheduledEndTime(AudioSettings.dspTime + ( end - start ));
    }
}
