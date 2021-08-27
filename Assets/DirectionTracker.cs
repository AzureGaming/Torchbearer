using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTracker : MonoBehaviour {
    // Blend trees continuously fire all animation events.
    // Distinguish events based on string parameter defined on the animation event.

    public void UpdateWeaponPosNorth(AnimationEvent evt) {
        if (IsValid(evt, "RunUp")) {
            WeaponPosition.OnPlayerFaceNorth?.Invoke();
        }
    }
    public void UpdateWeaponPosNorthEast(AnimationEvent evt) {
        if (IsValid(evt, "RunRightUp")) {
            WeaponPosition.OnPlayerFaceNorthEast?.Invoke();
        }
    }

    public void UpdateWeaponPosEast(AnimationEvent evt) {
        if (IsValid(evt, "RunRight")) {
            WeaponPosition.OnPlayerFaceEast?.Invoke();
        }
    }

    public void UpdateWeaponPosSouthEast(AnimationEvent evt) {
        if (IsValid(evt, "RunDownRight")) {
            WeaponPosition.OnPlayerFaceSouthEast?.Invoke();
        }
    }

    public void UpdateWeaponPosSouth(AnimationEvent evt) {
        if (IsValid(evt, "RunDown")) {
            WeaponPosition.OnPlayerFaceSouth?.Invoke();
        }
    }

    public void UpdateWeaponPosSouthWest(AnimationEvent evt) {
        if (IsValid(evt, "RunLeftDown")) {
            WeaponPosition.OnPlayerFaceSouthWest?.Invoke();
        }
    }

    public void UpdateWeaponPosWest(AnimationEvent evt) {
        if (IsValid(evt, "RunLeft")) {
            WeaponPosition.OnPlayerFaceWest?.Invoke();
        }
    }

    public void UpdateWeaponPosNorthWest(AnimationEvent evt) {
        if (IsValid(evt, "RunLeftUp")) {
            WeaponPosition.OnPlayerFaceNorthWest?.Invoke();
        }
    }

    bool IsValid(AnimationEvent evt, string id) {
        return evt.stringParameter == id && evt.animatorClipInfo.weight > 0.5f;
    }
}
