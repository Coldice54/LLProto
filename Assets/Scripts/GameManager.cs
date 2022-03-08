using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float checkpointDelay = 3f;
    Vector3 checkpointCord;
    public GameObject player;
    [SerializeField] Respawnable[] respawnables;
    [SerializeField] PlayerSizeChange2 sizeScript;
    [SerializeField] Canvas pauseUI;

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

        if (respawnables.Length > 0) {
            respawnItems();
        }

        player.SetActive(true);
    }

    private void respawnItems() {
        foreach(Respawnable gameObj in respawnables){
            gameObj.resetGameObject();
        }
    }

    private void Update() {
        if(Input.GetKeyUp("escape")) {
            Invoke("Pause", 0.2f);
        }
    }

    private void Pause() {
        pauseUI.enabled = true;
    }

    public void LevelComplete() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
