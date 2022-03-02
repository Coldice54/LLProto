using UnityEngine;

public class NineSlab : MonoBehaviour
{
    public Slab[] slabs;

    public void interact(int index){
        int left = (Mathf.Floor((index - 1)/3) ==  Mathf.Floor(index/3)) ? (index - 1) : -1;
        int right = (Mathf.Floor((index + 1)/3) ==  Mathf.Floor(index/3)) ? (index + 1) : -1;

        int[] indexes = {index, left, right, index - 3, index + 3};

        foreach (int ind in indexes){
            Debug.Log(ind);
            if (ind >= 0 && ind <= 8){
                slabs[ind].changeLight();
            }
        }
        checkPuzzleComplete();
    }

    public void checkPuzzleComplete(){
        int slabsLight = 0;

        foreach (Slab slab in slabs){
            if (slab.isLight == true) {
                slabsLight = slabsLight + 1;
            }
        }

        if(slabsLight == 9){
            Debug.Log("complete :)");
        }
    }
}
