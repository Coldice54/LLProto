using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Vector3 cord;

    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<GameManager>().updateCheckpoint(cord);
        gameObject.SetActive(false);
    }
}
