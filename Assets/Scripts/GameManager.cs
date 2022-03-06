using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float checkpointDelay = 3f;
    Vector3 checkpointCord;
    public GameObject player;
    [SerializeField] PlayerSizeChange2 sizeScript;

    private void Start() {
        checkpointCord = player.gameObject.transform.position;
    }

    public void Respawn() {
        Invoke("FromCheckpoint", checkpointDelay);
    }

    public void updateCheckpoint(Vector3 cord) {
        checkpointCord = cord;
    }

    private void FromCheckpoint() {
        //for player death particle effect
        //particalSystem.gameObject.SetActive(false);

        sizeScript.resetSize();
        player.transform.position = checkpointCord;
        player.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyUp("escape")) {
            Invoke("Restart", 0.5f);
        }
    }

    void Restart() {
        SceneManager.LoadScene(0);
    }



}
