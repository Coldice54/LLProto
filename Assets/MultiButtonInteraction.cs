using UnityEngine;

public class MultiButtonInteraction : Interactable
{
    public Material isLitMat;
    public bool isLit = false;
    public UseMultiButton controller;

    public override void Interact () {
        isLit = true;
        defocusMat = isLitMat;
        controller.CheckButtonsLit();
    }
}
