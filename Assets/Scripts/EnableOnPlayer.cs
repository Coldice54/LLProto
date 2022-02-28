using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnPlayer : MonoBehaviour
{

    [SerializeField] MonoBehaviour script;
    // Start is called before the first frame update
    void Start()
    {
        script.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            script.enabled = true;
        }
    }
}
