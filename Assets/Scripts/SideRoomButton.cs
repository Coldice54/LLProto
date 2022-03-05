using UnityEngine;

public class SideRoomButton : MonoBehaviour
{
    public Button button;
    public GameObject[] gameObjects;
    private bool isActive = false;

    private void Update() {
        if(button.isLit && !isActive){
            foreach (GameObject gameObject in gameObjects){
                gameObject.SetActive(true);
            }
            isActive = true;
        }
    }
}
