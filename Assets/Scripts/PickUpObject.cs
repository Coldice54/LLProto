using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand
                  // Start is called before the first frame update
    public GameObject eyes; //eyes from which ray is drawn
    public GameObject hands;
    private GameObject pickedUpObject;
    
    private void Start()
    {

    }

    private void Update()
    {
        Ray ray = new Ray(eyes.transform.position, this.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetKeyDown("r"))
        {
            

            RaycastHit hit;
            Debug.Log("about to ray cast");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("we have a hit");
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "Pickup")
                { //add collider reference otherwise you can't access gameObject!
                    Debug.Log("hit on pickup obj");
                    pickedUpObject = hit.collider.gameObject;
                    hit.collider.gameObject.transform.parent = hands.transform;
                    hit.collider.gameObject.transform.position = hands.transform.position - transform.forward;
                }
            }
        }
        else
        { //i think a regular else statement is fine
            if (pickedUpObject != null) {
            pickedUpObject.transform.parent = null;
            pickedUpObject = null;
            }
        }
    }

}