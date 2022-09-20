using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler
{
    private Vector3 initialScale;
    private Color initialColor;
    private void Awake()
    {

    }
    public void Hover()
    { 
    }

    public void Select()
    {

    }

    public void Unhover()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("AAAA");
    }
}
