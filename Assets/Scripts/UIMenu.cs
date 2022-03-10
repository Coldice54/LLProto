using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{   
    public AudioSource hoverSound;
    public AudioSource clickSound;

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void MainMenu() {
        FindObjectOfType<GameManager>().Resume();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() {
        FindObjectOfType<GameManager>().Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HoverOnButton(){
        hoverSound.Play();
    }

    public void ClickOnButton(){
        clickSound.Play();
    }

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
