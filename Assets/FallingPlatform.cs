using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool falling = false;
    float downSpeed = 0f;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            falling = true;
        }
    }

    private void Update() {
        if (falling == true){
            downSpeed -= Time.deltaTime * 0.1f;
            transform.position = new Vector3(transform.position.x, transform.position.y + downSpeed, transform.position.z);

        }
    }
}
