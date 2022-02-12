using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Interactable focus; 
    public GameObject eyes;

    private void Update() {

        Ray ray = new Ray(eyes.transform.position, this.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        RaycastHit hit;

        //If the ray hits an interactable decide if it can interact and set focus on true
        if (Physics.Raycast(ray, out hit)){
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null && interactable.TryFocusOn(hit.distance)) {
                SetFocus(interactable);
            }
        } else {
            RemoveFocus();
        }
    }

    private void SetFocus (Interactable newFocus) {
        if (focus == null){
            ChangeFocus(newFocus);
        } else if (focus != newFocus) {
            focus.OnDefocus();
            ChangeFocus(newFocus);
        }
    }

    private void ChangeFocus (Interactable newFocus) {
        focus = newFocus;
        focus.OnFocus(this.gameObject);
    }

    private void RemoveFocus () {
        if (focus != null) {
            focus.OnDefocus();
        }
        focus = null;
    }
}
