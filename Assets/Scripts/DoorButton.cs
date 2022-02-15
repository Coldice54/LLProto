using UnityEngine;

public class DoorButton : Interactable
{
    public Material isLitMat;
    public bool isLit = false;
    public override void Interact () {
        isLit = true;
        defocusMat = isLitMat;
    }

}
