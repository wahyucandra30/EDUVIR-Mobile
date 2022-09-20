using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstanceController : MonoBehaviour
{
    private string unameText;
    [SerializeField] private GameObject xrRig,avatarSiswa;
    [SerializeField] private Vector3 initPosOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (LoginController.instance != null)
        {
            unameText = LoginController.instance.GetUsername();
            if (unameText == "murid")
            {
                xrRig.transform.position = avatarSiswa.transform.position + initPosOffset;
                xrRig.transform.rotation = avatarSiswa.transform.rotation;
                avatarSiswa.SetActive(false);
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
