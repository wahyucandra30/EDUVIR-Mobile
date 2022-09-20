using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskButton : MonoBehaviour
{
    DeskObject deskObject;
    public Vector3 targetScale;
    public float timeScale;
    private void Start()
    {
        deskObject = transform.parent.GetComponentInChildren<DeskObject>();
    }
    public void PressButton()
    {  
            deskObject.Scale(targetScale, timeScale); 
        
    }
}
