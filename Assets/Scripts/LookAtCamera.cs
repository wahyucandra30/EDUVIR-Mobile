using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        transform.LookAt(2 * transform.position - cam.transform.position);
    }
}
