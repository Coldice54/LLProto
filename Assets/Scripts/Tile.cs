using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject symbol;
    public Material lightMat;
    public Material darkMat;
    public int index;
    private Renderer rend;
    public bool isLight = false;

    private void Start() {
        rend = symbol.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<NineTile>().interact(index);
        }
    }

    public void changeLight(){
        if (isLight) {
            rend.material = darkMat;
            isLight = false;
        } else {
            rend.material = lightMat;
            isLight = true;
        }
    }
}
