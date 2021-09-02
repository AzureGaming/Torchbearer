using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public List<GameObject> weapons;

    int currentWeapon = 0;

    //private void Awake() {
    //    weapons = new List<GameObject>();
    //}

    private void Start() {
        foreach (GameObject weapon in weapons) {
            weapon.SetActive(false);
        }

        weapons[0].SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            currentWeapon = ( currentWeapon + 1 ) % 2;
            foreach (GameObject weapon in weapons) {
                weapon.SetActive(false);
            }
            weapons[currentWeapon].SetActive(true);
        }
    }
}
