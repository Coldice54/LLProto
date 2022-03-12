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
    [SerializeField] GameObject[] haungsModeItems;
    [SerializeField] Vector3[] haungsModeSpawnPoints;
    bool haungsModeActive = false;
    int spawnPointIndex = 0;

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
        if(Input.GetKeyUp("h") && !haungsModeActive) {
            haungsModeActive = true;
            foreach(GameObject item in haungsModeItems) {
                item.SetActive(!item.activeSelf);
            }
        }
        if(Input.GetKeyUp("j") && haungsModeActive) {
            if (haungsModeSpawnPoints.Length >= (spawnPointIndex + 1)) {
                player.gameObject.transform.position = haungsModeSpawnPoints[spawnPointIndex];
                spawnPointIndex = spawnPointIndex + 1;
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
