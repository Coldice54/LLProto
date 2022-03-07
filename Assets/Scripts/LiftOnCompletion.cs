using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOnCompletion : MonoBehaviour
{
    [SerializeField] SymbolActive leaf;
    [SerializeField] SymbolActive cross;
    [SerializeField] SymbolActive sun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position.y);
        if (leaf.active && cross.active && sun.active && transform.localPosition.y < -390)
        {
            print("done");
            transform.position += Vector3.up * 0.1f;
        }
    }
}
