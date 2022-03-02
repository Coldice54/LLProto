using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public AudioSource hoverSound;
    public AudioSource clickSound;

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HoverOnButton(){
        hoverSound.Play();
    }

    public void ClickOnButton(){
        clickSound.Play();
    }
}
