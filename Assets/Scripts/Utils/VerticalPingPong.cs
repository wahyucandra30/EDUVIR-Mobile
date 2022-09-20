using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPingPong : MonoBehaviour
{
    [SerializeField] private int length = 2;
    [SerializeField] private float speed = 1f;
    private float initialY = 0f;
    private Transform trans;
    private void Awake()
    {
        trans = transform;
        initialY = trans.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            initialY + Mathf.PingPong(Time.time * speed, length) - length / 2f,
            transform.position.z);
    }
}
