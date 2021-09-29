using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;
    public string[] levelNames;
    public AudioSource hauntedVortex;

    int levelToLoad;

    public void FadeToNextLevel() {
        levelToLoad = Random.Range(0, levelNames.Length);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        string scene = levelNames[levelToLoad];
        SceneManager.LoadScene(scene);
    }

    public void PlayFadeIn() {
        PlaySoundInterval(hauntedVortex, 0f, 0.9f);
    }

    public void PlayFadeOut() {
        PlaySoundInterval(hauntedVortex, 0f, 0.9f);
        //PlaySoundInterval(hauntedVortex, 2.40f, 3f);
    }

    void PlaySoundInterval(AudioSource audio, float start, float end) {
        audio.time = start;
        audio.Play();
        audio.SetScheduledEndTime(AudioSettings.dspTime + ( end - start ));
    }
}
