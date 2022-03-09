using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDifficulty : MonoBehaviour
{
    [SerializeField] PlatformSpin[] platformSpins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach (PlatformSpin platform in platformSpins)
            {
                platform.speed *= 2;
            }
        }
    }
}
