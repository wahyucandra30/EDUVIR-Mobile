using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGuru : MonoBehaviour
{
    public ScrollRect[] scrollRect;
    public GameObject[] videoMateri;
    [SerializeField] private GameObject panelGuruAwal, panelGuruMateri, panelGuruVideo;
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < scrollRect.Length; i++)
        {
            scrollRect[i].verticalScrollbar.value = scrollRect[0].verticalScrollbar.value;
        }
    }

    public void OpenPanelMateri()
    {
        for (int i = 0; i < scrollRect.Length; i++)
        {
            scrollRect[i].transform.parent.gameObject.SetActive(true);
            scrollRect[i].gameObject.SetActive(true);
        } 
        panelGuruAwal.SetActive(false);
    }

    public void ClosePanelMateri()
    {
        for (int i = 0; i < scrollRect.Length; i++)
        {
            if (i == 0)
            {
                scrollRect[i].transform.parent.gameObject.SetActive(false);
            } 
            scrollRect[i].gameObject.SetActive(false);
        }
        panelGuruAwal.SetActive(true);
    }

    public void OpenPanelVideo()
    {
        for (int i = 0; i < videoMateri.Length ; i++)
        {
            videoMateri[i].transform.parent.gameObject.SetActive(true);
            videoMateri[i].SetActive(true);
        }
        panelGuruAwal.SetActive(false);
    }

    public void ClosePanelVideo()
    {
        for (int i = 0; i < videoMateri.Length; i++)
        {
            if (i == 0)
            {
                videoMateri[i].transform.parent.gameObject.SetActive(false);
            }
            videoMateri[i].SetActive(false);
        }
        panelGuruAwal.SetActive(true);
    }
}
