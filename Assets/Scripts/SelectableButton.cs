using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectableButton : MonoBehaviour, ICrosshairSelectable
{
    [SerializeField] private UnityEvent hoverEvent;
    [SerializeField] private UnityEvent selectEvent;
    [SerializeField] private UnityEvent unhoverEvent;
    private void Start()
    {
    }
    public void Hover()
    {
        hoverEvent.Invoke();
    }
    public void Unhover()
    {
        unhoverEvent.Invoke();
    }
    public void Select()
    {
        selectEvent.Invoke();
    }
}
