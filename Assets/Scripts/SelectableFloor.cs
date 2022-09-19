using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableFloor : MonoBehaviour, ICrosshairSelectable
{
    [SerializeField] private GameObject teleportIcon;
    private Transform teleportTransform;
    private Vector3 point;
    private void Awake()
    {
        teleportTransform = teleportIcon.transform;
        teleportIcon.SetActive(false);
    }
    private void Update()
    {
        if (teleportIcon.activeSelf)
        {
            teleportTransform.position = point;
        }
    }
    public void Hover()
    {
        teleportIcon.SetActive(true);
    }

    public void Select()
    {
        throw new System.NotImplementedException();
    }

    public void Unhover()
    {
        teleportIcon.SetActive(false);
    }
}
