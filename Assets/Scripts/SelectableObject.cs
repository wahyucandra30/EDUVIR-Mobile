using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour, ICrosshairSelectable
{
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material selectMaterial;
    private Material initialMaterial;
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialMaterial = meshRenderer.material;
    }
    public void Hover()
    {
        meshRenderer.sharedMaterial = hoverMaterial;
    }
    public void Unhover()
    {
        meshRenderer.sharedMaterial = initialMaterial;
    }
    public void Select()
    {
        gameObject.SetActive(false);
    }
}
