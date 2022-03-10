using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumPush : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        Vector3 forceDirection = col.gameObject.transform.position - transform.position;
        col.gameObject.GetComponent<Rigidbody>().AddForce(speed * forceDirection, ForceMode.Impulse);

    }
}
