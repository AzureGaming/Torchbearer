using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;

    int levelToLoad;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex) {
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
