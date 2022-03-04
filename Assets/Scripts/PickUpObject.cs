using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem = false; // a bool to see if you have an item in your hand
                          // Start is called before the first frame update
    public GameObject eyes; //eyes from which ray is drawn
    public GameObject hands; //reference to your hands/the position where you want your object to go
    private GameObject pickedUpObject;

    public Material focusMat;
    public Material defocusMat;
    protected Renderer rend;

    private void Start()
    {

    }

    private void Update()
    {
        Ray ray = new Ray(eyes.transform.position, this.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject.tag == "Pickup" && hit.distance < 5)
            {
                rend = hit.collider.gameObject.GetComponent<Renderer>();
                rend.material = focusMat;
            }
            else
            {
                if(rend){rend.material = defocusMat; }
            }
        }

        if (Input.GetKeyDown("r"))
        {

            if (hasItem == false)
            {
                
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("we have a hit");
                    Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.gameObject.tag == "Pickup" && hit.distance<5)
                    { //add collider reference otherwise you can't access gameObject!
                        
                        Debug.Log("hit on pickup obj");
                        pickedUpObject = hit.collider.gameObject;
                        //pickedUpObject.transform.parent = hands.transform;
                        pickedUpObject.transform.position = hands.transform.position - transform.forward;
                        pickedUpObject.transform.SetParent(hands.transform, true);
                        pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                        pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        hasItem = true;
                    }
                }
            }
            else
            {
                Debug.Log("about to drop item");
                pickedUpObject.transform.SetParent(null);
                pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hasItem = false;
            }

        }
        

    }

}