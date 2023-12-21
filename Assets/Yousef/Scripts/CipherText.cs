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

    private string userText;
    private string cipherText = "";
    private string plainText = ""; 
    private int shift = 3;
    private char[] alphabet;
    private string[] words = new string[] {"Riyadh", "Jeddah", "Tuwaiq", "Meta", "Expo", "World Cup"};
    private int randNum;

    //user input


    void Start()
    {
        randNum = Random.Range(0, words.Length);
        Debug.Log(words[randNum]);
    }
    
    void Update()
    {
        
        
    }
    public void EncryptedText()
    {
        shift %= 26;

        foreach (char ch in userText) 
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

        _plainText.text = plainText;

    }

    void CheckText()
    {

    }





    public void ReadInputText(string s)
    {
        userText = s;
    }



}
