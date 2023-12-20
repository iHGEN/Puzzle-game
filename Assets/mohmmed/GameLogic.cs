using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CableDetector : MonoBehaviour
{
    [SerializeField] XRSocketInteractor Socket;
    [SerializeField] GameObject Light;
    [SerializeField] ParticleSystem Particle;
    [SerializeField] string gameObjecttag;
    [SerializeField] Sequence sequence;
    bool is_check;
    private void Update()
    {
        if (Socket.hasSelection)
        {
            IXRSelectInteractable result = Socket.GetOldestInteractableSelected();
            if (result.transform.gameObject.tag == gameObjecttag)
            {
                if (!is_check)
                {
                    is_check = true;
                    Particle.Stop();
                    Light.gameObject.SetActive(true);
                    for (int i = 0; i < sequence.spotLightNames.Length; i++)
                    {
                        if (sequence.spotLightNames[i] == string.Empty)
                        {
                            sequence.spotLightNames[i] = Light.transform.gameObject.name;
                            break;
                        }
                    }
                }
            }
            else
            {
                Particle.Play();
            }
        } 
        else
        {
            is_check = false;
            Light.gameObject.SetActive(false);
        }
    }
}

   