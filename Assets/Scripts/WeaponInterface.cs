using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInterface : MonoBehaviour {
    public delegate void EquipSword();
    public static EquipSword OnEquipSword;

    public delegate void EquipGun();
    public static EquipGun OnEquipGun;

    public Image skill1;
    public Image skill2;
    public Image equippedWeapon;
    public Sprite swordSprite;
    public Sprite swordSkill1Sprite;
    public Sprite swordSkill2Sprite;
    public Sprite gunSprite;
    public Sprite gunSkill1Sprite;
    public Sprite gunSkill2Sprite;

    private void OnEnable() {
        OnEquipSword += SetSwordSprites;
        OnEquipGun += SetGunSprites;
    }

    private void OnDisable() {
        OnEquipSword -= SetSwordSprites;
        OnEquipGun -= SetGunSprites;
    }

    void SetSwordSprites() {
        equippedWeapon.sprite = swordSprite;
        skill1.sprite = swordSkill1Sprite;
        skill2.sprite = swordSkill2Sprite;
    }

    void SetGunSprites() {
        equippedWeapon.sprite = gunSprite;
        skill1.sprite = gunSkill1Sprite;
        skill2.sprite = gunSkill2Sprite;
    }
}
