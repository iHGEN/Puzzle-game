using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyGrabInteraction : MonoBehaviour
{
    public ParticleSystem grabParticleSystem; 

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        
        if (grabParticleSystem == null)
        {
            
            return;
        }

        grabInteractable.selectEntered.AddListener(HandleGrab);
        grabInteractable.selectExited.AddListener(HandleRelease);
    }

    private void HandleGrab(SelectEnterEventArgs args)
    {
        grabParticleSystem.Play(); 
    }

    private void HandleRelease(SelectExitEventArgs args)
    {
        grabParticleSystem.Stop(); 
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(HandleGrab);
            grabInteractable.selectExited.RemoveListener(HandleRelease);
        }
    }
}
