using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CipherText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private string userText;
    private int cipherIndex = 2;
    private string alphabetLetters = " abcdefghijklmnopqrstuvwxyz";
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
        if (userText != null)
        {
            EncryptedText(userText);

        }
    }
    void EncryptedText(string word)
    {
        string assigned_word = null; 
        for (int i = 0; i < word.Length; i++)
        {
            assigned_word += word[i];


        }
        text.text = assigned_word;



    }

    void DecryptText()
    {

    }

    void CheckText()
    {

    }





    public void ReadInputText(string s)
    {
        userText = s;
    }



}
