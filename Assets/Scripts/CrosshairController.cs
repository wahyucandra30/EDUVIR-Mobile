using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CrosshairController : MonoBehaviour
{
    private Camera cam;
    private GameObject highlightedObject = null;
    [SerializeField] private LayerMask layerMask;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (highlightedObject)
        {
            if (Input.touchCount > 0)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    EventSystem.current.currentSelectedGameObject.SetActive(false);
                    return;
                }
                highlightedObject.GetComponent<ICrosshairSelectable>()?.Select();
            }
        }
        if (Physics.Raycast(cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out RaycastHit hitInfo, float.MaxValue, layerMask.value))
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
