using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CrosshairController : MonoBehaviour
{
    private Camera cam;
    private GameObject highlightedObject = null;
    private Transform trans;
    private Ray ray;
    [SerializeField] private float rayDistance = 50f;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        cam = GetComponent<Camera>();
        trans = cam.transform;
    }
    private void Update()
    {
        if (highlightedObject)
        {
            if (Input.touchCount > 0)
            {
                highlightedObject.GetComponent<ICrosshairSelectable>()?.Select();
                highlightedObject = null;
            }
        }
        ray = new Ray(trans.position, trans.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, layerMask.value))
        {
            if (highlightedObject)
            {
                return;
            }
            highlightedObject = hitInfo.transform.gameObject;
            highlightedObject.GetComponent<ICrosshairSelectable>()?.Hover();
        }
        else if (highlightedObject)
        {
            highlightedObject.GetComponent<ICrosshairSelectable>()?.Unhover();
            highlightedObject = null;
        }
    }
}
