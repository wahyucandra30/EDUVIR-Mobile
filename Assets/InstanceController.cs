using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstanceController : MonoBehaviour
{
    [SerializeField] private string unameText;
    [SerializeField] private GameObject xrRig,avatarSiswa,avatarGuru;
    // Start is called before the first frame update
    void Start()
    {
        if (LoginController.instance != null)
        {
            unameText = LoginController.instance.GetUsername();
            if (unameText == "murid")
            {
                xrRig.transform.position = avatarSiswa.transform.position;
                xrRig.transform.rotation = avatarSiswa.transform.rotation;
                avatarSiswa.SetActive(false);
            }
            else if(unameText == "guru")
            {
                xrRig.transform.position = avatarGuru.transform.position;
                xrRig.transform.rotation = avatarGuru.transform.rotation;
                avatarGuru.SetActive(false);
            }
            else
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitToHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
