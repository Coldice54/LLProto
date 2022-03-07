using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBis : MonoBehaviour
{
    public GameObject pivot;
    
    public WeightPlateAlexSideRoom weightPlateBehavior;

    // Update is called once per frame
    void Update()
    {

        if (weightPlateBehavior.publicRotationToggle)
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, 20 * Time.deltaTime);
        }

    }
}

