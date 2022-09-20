using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    public GameObject button; 
    public UnityEvent onPress, onRelease;
    GameObject press;
    AudioSource sound;
    bool isPressed;
    InGameController inGameDesk;
    
    void Start()
    {
        inGameDesk = transform.parent.GetComponent<InGameController>();
        //press = GetComponent<GameObject>();
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.gameObject.name=="RightHand")
        {
            button.transform.localPosition = new Vector3(-0.510999978f, 0.9928f, 0.686999977f);
            press = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == press)
        {
            button.transform.localPosition = new Vector3(-0.510999978f, 1.01252341f, 0.686999977f);
            onRelease.Invoke();
            if (slider != null)
            {
                if (slider.active == false)
                {
                    slider.SetActive(true);
                }
                else
                {
                    slider.SetActive(false);
                }
            }
            StopAllCoroutines();
            StartCoroutine(inGameDesk.AnimationOrgansShowUp());
            isPressed = false;
        }
    }
 

}
