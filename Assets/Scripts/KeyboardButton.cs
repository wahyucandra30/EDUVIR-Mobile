using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardButton : MonoBehaviour
{
    Keyboard keyboard;
    TextMeshProUGUI buttonText;
    void Start()
    {
       /* keyboard = GetComponent<Keyboard>();
        buttonText = GetComponent<TextMeshProUGUI>();
        if(buttonText.text.Length == 1)
        {
            GetComponentInChildren<ButtonVR>().onRelease.AddListener(delegate { keyboard.InsertChar(buttonText.text);});
        }*/  
    }

    public void NameButtonText()
    {
        buttonText.text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
