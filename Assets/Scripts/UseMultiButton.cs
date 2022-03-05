using UnityEngine;

public class UseMultiButton : MonoBehaviour
{
    public MultiButtonInteraction[] buttons;
    public GameObject[] hiddenGameObjects;
    public GameObject[] ShownGameObjects;
    bool isCompleted;

    public void CheckButtonsLit() {
        foreach(MultiButtonInteraction button in buttons){
            if(!button.isLit){
                return;
            }
        }

        if (!isCompleted){
            showGameObjects();
            hideGameObjects();
            isCompleted = true;
        }
    }

    private void showGameObjects(){
        foreach(GameObject gameObject in hiddenGameObjects){
            gameObject.SetActive(true);
        }
    }

        private void hideGameObjects(){
        foreach(GameObject gameObject in ShownGameObjects){
            gameObject.SetActive(false);
        }
    }
}
