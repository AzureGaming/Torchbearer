using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;
    public string[] levelNames;
    public AudioSource hauntedVortex;

    public void FadeToNextLevel() {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        //int levelToLoad = Random.Range(0, levelNames.Length);
        //string scene = levelNames[levelToLoad];

        //SceneManager.LoadScene(scene);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
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
