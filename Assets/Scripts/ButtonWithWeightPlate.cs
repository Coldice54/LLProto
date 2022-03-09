using UnityEngine;

public class ButtonWithWeightPlate : MonoBehaviour
{
    public Button[] buttons;
    public MultiItemWeightPlate[] plates;
    public GameObject[] items;

    bool conditionsMet = false;

    private void Update() {
        if(CheckButtons() && CheckPlates()) {
            conditionsMet = true;
        } else {
            conditionsMet = false;
        }

        if (conditionsMet) {
            ShowItems();
        }
        
    }

    private bool CheckButtons() {
        foreach(Button button in buttons) {
            if(!button.isLit){
                return false;
            }
        }

        return true;
    }

    private bool CheckPlates() {
        foreach(MultiItemWeightPlate plate in plates) {
            if(!plate.weightOn){
                return false;
            }
        }
        return true;
    }

    private void ShowItems() {
        foreach(GameObject item in items){
            item.SetActive(false);
        }
    }
}
