using UnityEngine;

public class FallingPlatform : Respawnable
{
    bool falling = false;
    float downSpeed = 0f;
    Vector3 originalPosition;

    private void Start() {
        originalPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            falling = true;
        }
    }

    public override void resetGameObject(){
        falling = false;
    }

    private void Update() {
        if (falling == true){
            downSpeed -= Time.deltaTime * 0.5f;
            transform.position = new Vector3(transform.position.x, transform.position.y + downSpeed, transform.position.z);

        }
    }
}
