using UnityEngine;

public class ShowSecretPassage : MonoBehaviour
{
    [SerializeField] SymbolActive[] symbols;
    private bool symbolsLit = false;
    private bool shown = false;
    [SerializeField] GameObject plate;

    private void Update() {
        if (CheckSymbols()) {
            symbolsLit = true;
        } else {
            symbolsLit = false;
        }

        if (symbolsLit && !shown) {
            plate.SetActive(false);
            shown = true;
        }
    }

    private bool CheckSymbols() {
        foreach(SymbolActive symbol in symbols) {
            if (!symbol.active) {
                return false;
            }
        }

        return true;
    }

}
