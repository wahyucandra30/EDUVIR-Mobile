using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPingPong : MonoBehaviour
{
    [SerializeField] private int length = 2;
    [SerializeField] private float speed = 1f;
    private float initialZ = 0f;
    private Transform trans;
    private void Awake()
    {
        trans = transform;
        initialZ = trans.position.z;
    }
    void Update()
    {
        transform.position = new Vector3(trans.position.x,
            transform.position.y,
            initialZ + Mathf.PingPong(Time.time * speed, length) - length / 2f);
    }
}
