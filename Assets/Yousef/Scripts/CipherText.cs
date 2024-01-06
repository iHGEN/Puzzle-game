using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CipherText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI _plainText;
    [SerializeField] GameObject winningScreen;
    [SerializeField] coins _coins;
    [SerializeField] TextMeshProUGUI _text;

    private string userText;
    private string wrd;
    private string cipherText = "";
    private string plainText = ""; 
    private int shift;
    private char[] alphabet;
    private string[] words = new string[] {"Riyadh", "Jeddah", "Tuwaiq", "Meta", "Expo", "Unity"};
    private int randNum;
    private bool isRestartGame; 



    void Start()
    {
        randNum = Random.Range(0, words.Length);
        wrd = words[randNum];
        shift = Random.Range(1, 3);
    }
    
   public void get_start()
    {
        if(_coins.check_coins())
        {
            EncryptedText();
        }
        else
        {
            _text.text = $"There's not enough coins to play";
            winningScreen.SetActive(true);
        }
    }
   
    public void EncryptedText()
    {
        cipherText = null;
        shift %= 26;
        randNum = Random.Range(0, words.Length);
        wrd = words[randNum];
        foreach (char ch in wrd) 
        {
            if (char.IsLetter(ch)) 
            {
                char baseChar = char.IsUpper(ch) ? 'A' : 'a';
                char encryptedChar = (char)(((ch - baseChar + shift) % 26) + baseChar);
                cipherText += encryptedChar;
            } 
            else
            {
                cipherText += ch;
            }
        }

              text.text = cipherText;
    }

    public void DecryptText()
    {
        shift %= 26;
        plainText = null;
        foreach (char ch in cipherText)
        {
            if (char.IsLetter(ch))
            {
                char baseChar = char.IsUpper(ch) ? 'A' : 'a';
                char encryptedChar = (char)(((ch - baseChar - shift + 26) % 26) + baseChar);
                plainText += encryptedChar;
            }
            else
            {
                plainText += ch;
            }
        }

        _plainText.text = plainText.Trim();

    }


    public void isWinner()
    {
        if (userText == plainText.Trim())
        {
            _text.text = $"You Win do you want to play agian ?";
            winningScreen.SetActive(true);
            _coins.add_coins(2);
        }
        else
        {
            _coins.take_conis(1);
            _text.text = $"You Lost \r\n\r\n do you want to try again ?";
            winningScreen.SetActive(true);
            return;
        }
    }

    


   

    public void ReadInputText(string s)
    {
        userText = s.Trim(); 
    }



}
