using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public static LoginController instance;
    [SerializeField] private InputField uname, pass;
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
        loggedIn = true;
        SetUsername("murid");
        Debug.Log("ANDA MURID");
        SceneManager.LoadScene(1);
        //if(pass.text != "")
        //{
        //    if (uname.text == "murid")
        //    {
        //    }
        //}
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
