using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    [SerializeField] private GameObject canvasMenu,canvasPlay;
    [SerializeField] private GameObject panelMateri, panelMateriExpand, panelMateriGuru, panelMateriGuruExpand;
    void Start()
    {
    }
     
    void Update()
    {
        
    }
    public void StartGame()
    { 
        canvasPlay.SetActive(true);
        canvasMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        canvasPlay.SetActive(false);
        canvasMenu.SetActive(true);
    }

    public void OpenPanel(GameObject a)
    {
        a.SetActive(true);
    }
    
    public void ClosePanel(GameObject a)
    {
        a.SetActive(false);
    }
}
