using UnityEngine;

public class PlayerInMainRoom : MonoBehaviour
{
    public bool inMainRoom = false;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "MainRoomFloor") {
            inMainRoom = true;
        } else {
            inMainRoom = false;
        }
    }
}
