using UnityEngine;

public class Respawnable : MonoBehaviour
{
    public virtual void resetGameObject() {
        Debug.Log("respawning");
    }
}
