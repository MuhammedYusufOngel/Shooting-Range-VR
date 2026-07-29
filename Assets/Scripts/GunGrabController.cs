using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class GunGrabController : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
        if(!PlayerController.instance.GetIsTimeRunning())
        {
            PlayerController.instance.StartCountdown();
        }
    }
}
