using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (transform.localScale.x != 5f)
            {
                gameObject.transform.localScale = new Vector3(
                    transform.localScale.x * 5f, transform.localScale.y * 5f, transform.localScale.z * 5f);
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (transform.localScale.x != 0.2f)
            {
                gameObject.transform.localScale = new Vector3(
                    transform.localScale.x / 5f, transform.localScale.y / 5f, transform.localScale.z / 5f);
            }
        }
    }
}
