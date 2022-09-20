using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TouchDebug : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            tmp.text = $"<color=blue>{true}</color>";
            if (EventSystem.current.IsPointerOverGameObject())
            {
                tmp.text = $"<color=green>{true} over {EventSystem.current.currentSelectedGameObject}</color>";
            }
        }
        else
        {
            tmp.text = $"<color=red>{false}</color>";
        }
    }
}
