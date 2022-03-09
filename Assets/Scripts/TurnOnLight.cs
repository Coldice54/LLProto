using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField] SymbolActive symbol;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            symbol.Activate();
        }
    }
}
