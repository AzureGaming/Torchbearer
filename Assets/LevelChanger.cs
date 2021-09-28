using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;
    public string[] levelNames;

    int levelToLoad;

    public void FadeToNextLevel() {
        levelToLoad = Random.Range(0, levelNames.Length);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        string scene = levelNames[levelToLoad];
        SceneManager.LoadScene(scene);
    }
}
