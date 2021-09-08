using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public delegate void WeaponSwitchValid();
    public static WeaponSwitchValid OnWeaponSwitchValid;

    public delegate void WeaponSwitchInvalid();
    public static WeaponSwitchInvalid OnWeaponSwitchInvalid;

    public List<GameObject> weapons;

    int currentWeapon = 0;
    bool canSwitch = true;

    private void OnEnable() {
        OnWeaponSwitchValid += SetValid;
        OnWeaponSwitchInvalid += SetInvalid;
    }

    private void OnDisable() {
        OnWeaponSwitchValid -= SetValid;
        OnWeaponSwitchInvalid -= SetInvalid;
    }

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

    void SetValid() {
        canSwitch = true;
    }

    void SetInvalid() {
        canSwitch = false;
    }
}
