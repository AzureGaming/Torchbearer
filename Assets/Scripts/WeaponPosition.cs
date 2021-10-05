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

    void SetPosNorth() {
        transform.position = positions[0].position;
    }

    void SetPosNorthEast() {
        transform.position = positions[1].position;
    }

    void SetPosEast() {
        transform.position = positions[2].position;
    }

    void SetPosSouthEast() {
        transform.position = positions[3].position;
    }

    void SetPosSouth() {
        transform.position = positions[4].position;
    }

    void SetPosSouthWest() {
        transform.position = positions[5].position;
    }

    void SetPosWest() {
        transform.position = positions[6].position;
    }

    void SetPosNorthWest() {
        transform.position = positions[7].position;
    }
}
