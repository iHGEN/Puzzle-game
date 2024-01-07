using UnityEngine;
using TMPro; 

public class ButtonSequenceDetector : MonoBehaviour
{
    


    public coins _coins;
    public TextMeshProUGUI sequenceText;
    public GameObject _error_canvas;
    public TextMeshProUGUI _text;

  
    private string correctSequence = "123579";

    
    private string currentSequence = "";

    void Start()
    {
       
        ResetSequence();
    }

  
    public void ButtonPressed(int buttonNumber)
    {
        if(!_coins.check_coins())
        {
            _text.text = $"There's not enough coins to play";
            _error_canvas.SetActive(true);
            return;
        }
        currentSequence += buttonNumber.ToString();

        
        if (sequenceText != null)
            sequenceText.text = currentSequence;

        
        if (currentSequence == correctSequence)
        {
            _coins.add_coins(2);
            _text.text = $"You Win";
            _error_canvas.SetActive(true);

            ResetSequence();
        }
        
        else if (currentSequence.Length >= correctSequence.Length)
        {
            _text.text = $"You Lost";
            _error_canvas.SetActive(true);
            _coins.take_conis(1);
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
