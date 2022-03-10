using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float interactionRadius = 3f;

    bool isFocus = false;

    bool hasInteracted = false;

    GameObject player;

    public Material focusMat;

    public Material defocusMat;

    protected Renderer rend;
    
    private void Start() {
        rend = GetComponent<Renderer>();
    }

    public virtual void Interact () {
        //Debug.Log("interacting");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C)){
            if (isFocus && !hasInteracted) {
                Interact();
                hasInteracted = true;
            }
        }

        if (isFocus) {
            rend.material = focusMat;
        } else {
            rend.material = defocusMat;
        }
    }

    public bool TryFocusOn (float distance) {
        if (distance <= interactionRadius) {
            return true;
        }

        return false;
    }

    public void OnFocus (GameObject playerObj) {
        isFocus = true;
        player = playerObj;
    }

    public void OnDefocus () {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }
    
    //Draws the radius on dev side (Debug)
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
