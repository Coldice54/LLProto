using UnityEngine;

public class WeightPlateShirleySideRoom : MonoBehaviour
{

    public GameObject[] gameObjects;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Weight") {
            foreach (GameObject gameObject in gameObjects){
                gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Weight") {
            foreach (GameObject gameObject in gameObjects){
                gameObject.SetActive(false);
            }
        }
    }
}
