using UnityEngine;

public class SymbolActive : MonoBehaviour
{
    public bool active = false;
    [SerializeField] Material activeMaterial;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void Activate()
    {
        active = true;
        rend.material = activeMaterial;
    }
}
