using UnityEngine;

public class SideRoomButton : MonoBehaviour
{
    public DoorButton doorButton;
    public GameObject[] gameObjects;
    private bool isActive = false;

    private void Update() {
        if(doorButton.isLit && !isActive){
            foreach (GameObject gameObject in gameObjects){
                gameObject.SetActive(true);
            }
            isActive = true;
        }
    }
}
