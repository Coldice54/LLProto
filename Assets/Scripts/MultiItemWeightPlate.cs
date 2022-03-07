using UnityEngine;

public class MultiItemWeightPlate : MonoBehaviour
{

    public GameObject[] gameObjects;
    public bool weightOn = false;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Weight") {
            weightOn = true;
            foreach (GameObject gameObject in gameObjects){
                bool active = gameObject.activeSelf;
                gameObject.SetActive(!active);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Weight") {
            weightOn = false;
            foreach (GameObject gameObject in gameObjects){
                bool active = gameObject.activeSelf;
                gameObject.SetActive(!active);
            }
        }
    }
}
