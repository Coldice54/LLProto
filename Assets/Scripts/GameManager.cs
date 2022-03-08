using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float checkpointDelay = 3f;
    Vector3 checkpointCord;
    bool gamePaused = false;
    public GameObject player;
    [SerializeField] Respawnable[] respawnables;
    [SerializeField] PlayerSizeChange2 sizeScript;
    [SerializeField] GameObject pauseUI;

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
            if(gamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void LevelComplete() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
