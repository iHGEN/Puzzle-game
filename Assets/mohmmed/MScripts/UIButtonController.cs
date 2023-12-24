using UnityEngine;
using TMPro; 

public class ButtonSequenceDetector : MonoBehaviour
{
    
    public ParticleSystem myParticleSystem;

    
    public TextMeshProUGUI sequenceText;

  
    private string correctSequence = "123579";

    
    private string currentSequence = "";

    void Start()
    {
       
        ResetSequence();
    }

  
    public void ButtonPressed(int buttonNumber)
    {
        
        currentSequence += buttonNumber.ToString();

        
        if (sequenceText != null)
            sequenceText.text = currentSequence;

        
        if (currentSequence == correctSequence)
        {
           
            myParticleSystem.Play();

            
            ResetSequence();
        }
        
        else if (currentSequence.Length >= correctSequence.Length)
        {
            ResetSequence();
        }
    }

   
    public void ResetSequence()
    {
        currentSequence = "";
        if (sequenceText != null)
            sequenceText.text = currentSequence;
    }
}
