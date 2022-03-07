using UnityEngine;

public class MultiItemWeightPlate : MonoBehaviour
{

    public GameObject[] gameObjects;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Weight") {
            foreach (GameObject gameObject in gameObjects){
                bool active = gameObject.activeSelf;
                gameObject.SetActive(!active);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Weight") {
            foreach (GameObject gameObject in gameObjects){
                bool active = gameObject.activeSelf;
                gameObject.SetActive(!active);
            }
        }
    }
}
