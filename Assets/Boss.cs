using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public delegate void CompleteStage2();
    public static CompleteStage2 OnCompleteStage2;

    public delegate void CompleteStage4();
    public static CompleteStage4 OnCompleteStage4;

    public delegate void CompleteStage6();
    public static CompleteStage6 OnCompleteStage6;

    public delegate void CompleteStage7();
    public static CompleteStage7 OnCompleteStage7;

    public GameObject[] stages;
    public Pyre centerPyre;

    bool isStage2Complete = false;
    bool isStage4Complete = false;
    bool isStage6Complete = false;
    bool isStage7Complete = false;

    private void OnEnable() {
        OnCompleteStage2 += () => isStage2Complete = true;
        OnCompleteStage4 += () => isStage4Complete = true;
        OnCompleteStage6 += () => isStage6Complete = true;
        OnCompleteStage7 += () => isStage7Complete = true;
    }

    void Start() {
        StartCoroutine(FirePathRoutine());
    }

    IEnumerator FirePathRoutine() {
        ActivateStage(1);
        yield return StartCoroutine(CompletedStage1());
        ActivateStage(2);
        yield return StartCoroutine(CompletedStage2());
        ActivateStage(3);
        yield return StartCoroutine(CompletedStage3());
        ActivateStage(4);
        yield return StartCoroutine(CompletedStage4());
        ActivateStage(5);
        yield return StartCoroutine(CompletedStage5());
        ActivateStage(6);
        yield return StartCoroutine(CompletedStage6());
        ActivateStage(7);
        yield return StartCoroutine(CompletedStage7());
        ActivateStage(8);
        yield return StartCoroutine(CompletedStage8());
        foreach (GameObject stage in stages) {
            stage.SetActive(false);
        }
    }

    void ActivateStage(int stg) {
        foreach (GameObject stage in stages) {
            if (stages[stg - 1] == stage) {
                stage.SetActive(true);
            } else {
                stage.SetActive(false);
            }
        }
    }

    IEnumerator CompletedStage1() {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator CompletedStage2() {
        yield return new WaitUntil(() => isStage2Complete);
    }

    IEnumerator CompletedStage3() {
        centerPyre.isActive = false;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator CompletedStage4() {
        yield return new WaitUntil(() => isStage4Complete);
    }

    IEnumerator CompletedStage5() {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator CompletedStage6() {
        yield return new WaitUntil(() => isStage6Complete);
    }

    IEnumerator CompletedStage7() {
        yield return new WaitUntil(() => isStage7Complete);
    }

    IEnumerator CompletedStage8() {
        yield return new WaitForSeconds(2f);
    }
}
