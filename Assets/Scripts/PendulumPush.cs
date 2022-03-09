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
            col.gameObject.GetComponent<Rigidbody>().AddForce(speed*col.gameObject.transform.forward, ForceMode.Impulse);
            col.gameObject.GetComponent<Rigidbody>().AddForce(speed * -col.gameObject.transform.right, ForceMode.Impulse);

    }
}
