using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public InputField unameInputField,passInputField;
    public GameObject normalButtons;
    public GameObject capsButtons;
    private bool caps;
    private string fieldActive="";

    void Start()
    {
        caps = false;
    
    }

    public void InsertChar(string a)
    {
        if (fieldActive=="uname")
        {
            unameInputField.text += a;
        }
        else if (fieldActive=="pass")
        {
            passInputField.text += a;
        }
        
    }

    public void DeleteChar()
    {
        if(unameInputField.text.Length >0 && fieldActive=="uname")
        {
            unameInputField.text = unameInputField.text.Substring(0, unameInputField.text.Length - 1);
        }
        if(passInputField.text.Length>0 && fieldActive=="pass")
        {
            passInputField.text = passInputField.text.Substring(0, passInputField.text.Length - 1);
        }

    }

    public void InsertSpace()
    {
        if (fieldActive=="uname")
        {
            unameInputField.text += " ";
        }
        else if (fieldActive=="pass")
        {
            passInputField.text += " ";
        }
        
    }

    public void CapsPressed()
    {
        if (!caps)
        {
            normalButtons.SetActive(false);
            capsButtons.SetActive(true);
            caps = true;
        }
        else
        {
            capsButtons.SetActive(false);
            normalButtons.SetActive(true);
            caps = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (unameInputField.isFocused)
        {
            fieldActive = "uname";
        }
        else if (passInputField.isFocused)
        {
            fieldActive = "pass";
        } 
    }
}
