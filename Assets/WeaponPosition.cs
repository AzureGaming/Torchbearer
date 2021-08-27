using UnityEngine;

public class WeaponPosition : MonoBehaviour {
    public delegate void PlayerFaceNorth();
    public static PlayerFaceNorth OnPlayerFaceNorth;

    public delegate void PlayerFaceNorthEast();
    public static PlayerFaceNorthEast OnPlayerFaceNorthEast;

    public delegate void PlayerFaceEast();
    public static PlayerFaceEast OnPlayerFaceEast;

    public delegate void PlayerFaceSouthEast();
    public static PlayerFaceSouthEast OnPlayerFaceSouthEast;

    public delegate void PlayerFaceSouth();
    public static PlayerFaceSouth OnPlayerFaceSouth;

    public delegate void PlayerFaceSouthWest();
    public static PlayerFaceSouthWest OnPlayerFaceSouthWest;

    public delegate void PlayerFaceWest();
    public static PlayerFaceWest OnPlayerFaceWest;

    public delegate void PlayerFaceNorthWest();
    public static PlayerFaceNorthWest OnPlayerFaceNorthWest;

    // 0: north
    // 2: east
    // 4: south
    // 6: west
    public Transform[] positions;

    private void OnEnable() {
        OnPlayerFaceNorth += SetPosNorth; 
        OnPlayerFaceNorthEast += SetPosNorthEast;
        OnPlayerFaceEast += SetPosEast;
        OnPlayerFaceSouthEast += SetPosSouthEast;
        OnPlayerFaceSouth += SetPosSouth;
        OnPlayerFaceSouthWest += SetPosSouthWest;
        OnPlayerFaceWest += SetPosWest;
        OnPlayerFaceNorthWest += SetPosNorthWest;
    }

    private void OnDisable() {
        OnPlayerFaceNorth -= SetPosNorth;
        OnPlayerFaceNorthEast -= SetPosNorthEast;
        OnPlayerFaceEast -= SetPosEast;
        OnPlayerFaceSouthEast -= SetPosSouthEast;
        OnPlayerFaceSouth -= SetPosSouth;
        OnPlayerFaceSouthWest -= SetPosSouthWest;
        OnPlayerFaceWest -= SetPosWest;
        OnPlayerFaceNorthWest -= SetPosNorthWest;
    }

    private void Start() {
        SetAllPositionsActive(false);
    }

    void SetPosNorth() {
        SetAllPositionsActive(false);
        if (!positions[0].gameObject.activeInHierarchy) {
            positions[0].gameObject.SetActive(true);
        }
    }

    void SetPosNorthEast() {
        SetAllPositionsActive(false);
        if (!positions[1].gameObject.activeInHierarchy) {
            positions[1].gameObject.SetActive(true);
        }
    }
    
    void SetPosEast() {
        SetAllPositionsActive(false);
        if (!positions[2].gameObject.activeInHierarchy) {
            positions[2].gameObject.SetActive(true);
        }
    }

    void SetPosSouthEast() {
        SetAllPositionsActive(false);
        if (!positions[3].gameObject.activeInHierarchy) {
            positions[3].gameObject.SetActive(true);
        }
    }

    void SetPosSouth() {
        SetAllPositionsActive(false);
        if (!positions[4].gameObject.activeInHierarchy) {
            positions[4].gameObject.SetActive(true);
        }
    }

    void SetPosSouthWest() {
        SetAllPositionsActive(false);
        if (!positions[5].gameObject.activeInHierarchy) {
            positions[5].gameObject.SetActive(true);
        }
    }

    void SetPosWest() {
        SetAllPositionsActive(false);
        if (!positions[6].gameObject.activeInHierarchy) {
            positions[6].gameObject.SetActive(true);
        }
    }

    void SetPosNorthWest() {
        SetAllPositionsActive(false);
        if (!positions[7].gameObject.activeInHierarchy) {
            positions[7].gameObject.SetActive(true);
        }
    }

    void SetAllPositionsActive(bool isActive) {
        foreach (Transform t in positions) {
            t.gameObject.SetActive(isActive);
        }
    }
}
