using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPingPong : MonoBehaviour
{
    [SerializeField] private int length = 2;
    [SerializeField] private float speed = 1f;
    private float initialX = 0f;
    private Transform trans;
    private void Awake()
    {
        trans = transform;
        initialX = trans.position.x;
    }
    void Update()
    {
        transform.position = new Vector3(initialX + Mathf.PingPong(Time.time * speed, length) - length / 2f,
            transform.position.y,
            trans.position.z);
    }
}
