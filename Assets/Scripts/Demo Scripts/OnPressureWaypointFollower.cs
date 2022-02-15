using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressureWaypointFollower : MonoBehaviour
{
    /*
    void Start()
    {
        
    }*/
    [SerializeField] GameObject movingObject;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject weight;
    //[SerializeField] Vector3 objectMotion;
    [SerializeField] float speed = 1f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Weight")
        {
            movingObject.transform.position = Vector3.MoveTowards(waypoints[1].transform.position, waypoints[0].transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Weight")
        {
            movingObject.transform.position = Vector3.MoveTowards(waypoints[0].transform.position, waypoints[1].transform.position, speed * Time.deltaTime);
        }
    }
    
}
