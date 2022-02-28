using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject pivot;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}

