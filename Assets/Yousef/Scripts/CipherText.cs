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

    private string userText;
    private string wrd;
    private string cipherText = "";
    private string plainText = ""; 
    private int shift;
    private char[] alphabet;
    private string[] words = new string[] {"Riyadh", "Jeddah", "Tuwaiq", "Meta", "Expo", "Unity"};
    private int randNum;
    private bool isRestartGame; 

    //user input


    void Start()
    {
        randNum = Random.Range(0, words.Length);
        wrd = words[randNum];
        shift = Random.Range(1, 3);
    }
    
    void Update()
    {
        if (isWinner())
        {
            //winningScreen.SetActive(true);
            Debug.Log("You Won!");
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

        _plainText.text = plainText;

    }

    private bool isWinner()
    {
        if ( userText == plainText)
        {  return true; }

        else
        {
            Debug.Log("You Lost!");
            return false;
        }

    }

    


   

    public void ReadInputText(string s)
    {
        userText = s;
    }



}
