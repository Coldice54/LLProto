using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<GameManager>().LevelComplete();
    }
    
}
