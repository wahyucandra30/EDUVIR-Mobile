using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera cam;
    private Transform trans;
    private void Awake()
    {
        cam = Camera.main;
        trans = transform;
    }
    private void Update()
    {
        trans.LookAt(2 * trans.position - cam.transform.position);
    }
}
