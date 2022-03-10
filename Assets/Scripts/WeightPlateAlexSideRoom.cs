using UnityEngine;

public class WeightPlateAlexSideRoom : MonoBehaviour
{

    private bool rotationToggle;
    public bool publicRotationToggle;


    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision");
        if (collider.gameObject.name == "Weight")
        {
            
            rotationToggle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Weight")
        {

            rotationToggle = false;
        }
    }
    void Update()
    {
        publicRotationToggle = rotationToggle;
    }
}
