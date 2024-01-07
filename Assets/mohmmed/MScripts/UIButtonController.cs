using UnityEngine;
using TMPro;
using System;

public class ButtonSequenceDetector : MonoBehaviour
{
    public coins _coins;
    public TextMeshProUGUI sequenceText;
    public GameObject _error_canvas;
    public TextMeshProUGUI _text;
    public TextMeshProUGUI _get_text_number;
    private string correctSequence;
    private string currentSequence = "";
    private int sequenceLength = 6;

    void Start()
    {
        ResetSequence();
    }

    public void GenerateRandomSequence()
    {
        correctSequence = "";
        for (int i = 0; i < sequenceLength; i++)
        {
            correctSequence += i == 3 ? $"\r\n{UnityEngine.Random.Range(1, 10).ToString()}" :$"{UnityEngine.Random.Range(1, 10).ToString()}";
        }
        _get_text_number.text = correctSequence;
        sortnumber(correctSequence);
    }

    void sortnumber(string number)
    {
        number = number.Trim().Replace("\r\n", string.Empty).Replace(" ",string.Empty);
        char[] textnumber = number.ToCharArray();
        Array.Sort(textnumber);
        correctSequence = string.Empty;
        for (int i = 0; i < textnumber.Length; i++)
        {
            correctSequence += textnumber[i];
        }
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


        if (currentSequence == correctSequence.Trim().Replace("\r\n", string.Empty))
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
        _get_text_number.text = string.Empty;
    }
}
