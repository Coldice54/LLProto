using UnityEngine;

public class Button : Interactable
{
    public Material isLitMat;
    public bool isLit = false;
    public override void Interact () {
        isLit = true;
        defocusMat = isLitMat;
    }

}
