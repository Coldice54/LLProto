using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField] SymbolActive activeScript;
    Renderer rend;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activeMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = inactiveMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeScript.active)
        {
            rend.material = activeMaterial;
        } 
        else
        {
            rend.material = inactiveMaterial;
        }
    }
}
