using UnityEngine;

public class LiftOnCompletion : MonoBehaviour
{
    [SerializeField] SymbolActive leaf;
    [SerializeField] SymbolActive cross;
    [SerializeField] SymbolActive sun;
    [SerializeField] PlayerInMainRoom player;

    // Start is called before the first frame update
    void Update()
    {
        if (leaf.active && cross.active && sun.active && transform.localPosition.y < -390 && player.inMainRoom)
        {
            transform.position += Vector3.up * 0.5f * Time.deltaTime;
        }
    }
}
