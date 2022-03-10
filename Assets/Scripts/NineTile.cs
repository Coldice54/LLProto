using UnityEngine;

public class NineTile : MonoBehaviour
{
    [SerializeField] Tile[] tiles;
    public GameObject door;

    public void interact(int index){
        int left = (Mathf.Floor((index - 1)/3) ==  Mathf.Floor(index/3)) ? (index - 1) : -1;
        int right = (Mathf.Floor((index + 1)/3) ==  Mathf.Floor(index/3)) ? (index + 1) : -1;

        int[] indexes = {index, left, right, index - 3, index + 3};

        foreach (int ind in indexes){
            //Debug.Log(ind);
            if (ind >= 0 && ind <= 8){
                tiles[ind].changeLight();
            }
        }
        checkPuzzleComplete();
    }

    public void checkPuzzleComplete(){
        int slabsLight = 0;

        foreach (Tile tile in tiles){
            if (tile.isLight == true) {
                slabsLight = slabsLight + 1;
            }
        }

        if(slabsLight == 9){
            door.SetActive(false);
        }
    }
}
