using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWeight : MonoBehaviour
{
    public static bool isNotOnMovingPlatform = true;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotOnMovingPlatform = false;
            gameObject.transform.SetParent(collision.gameObject.transform);

        }
    }

    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isNotOnMovingPlatform = true;
            gameObject.transform.SetParent(null);
        }
    }
}
