using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyGrabInteraction : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;
    [SerializeField] coins _coins;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HandleGrab);
    }

    private void HandleGrab(SelectEnterEventArgs args)
    {
        _coins.add_coins(2);
        Destroy(gameObject);
    }


    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(HandleGrab);
        }
    }
}
