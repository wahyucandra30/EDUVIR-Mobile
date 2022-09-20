using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public static LoginController instance;
    [SerializeField] private InputField uname,pass;
    string username;
    public bool loggedIn = false;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        //TouchScreenKeyboard.Open("");
    }

    public void LoginFunction()
    {
        if(pass.text != "")
        {
            if (uname.text == "murid")
            {
                loggedIn = true;
                SetUsername(uname.text.ToString());
                Debug.Log("ANDA MURID");
                SceneManager.LoadScene("InGame");
            }
            else if (uname.text == "guru")
            {
                loggedIn = false;
                SetUsername(uname.text.ToString());
                Debug.Log("ANDA GURU");
                SceneManager.LoadScene("InGame");
            }
        }
        
    }
    public void SetUsername(string username)
    {
        this.username = username; 
    }
    public string GetUsername()
    {
        return this.username;
    }

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("");
    }

    public void OpenSceneMurid()
    {
        SetUsername("murid");
        SceneManager.LoadScene("InGame");
    }
    
    public void OpenSceneGuru()
    {
        SetUsername("guru");
        SceneManager.LoadScene("InGame");
    }
}
