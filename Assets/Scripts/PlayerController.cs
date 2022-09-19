using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 3.3f;
    private float rotSpeed = 90f;
    private Vector3 moveDir = Vector3.zero;
    [SerializeField] private CharacterController controller;

    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;
    private Transform rawGyroRot;
    private float tempSmoothing;

    private float smoothing = 0.1f;

    private void Update()
    {
        //Vector3 move = new Vector3(Input.acceleration.x * speed * Time.deltaTime, 0, -Input.acceleration.z * speed * Time.deltaTime);
        //Vector3 rotMovement = transform.TransformDirection(move);
        //controller.Move(rotMovement);

        ApplyGyroRotation();
        ApplyCalibration();

        transform.rotation = Quaternion.Lerp(transform.rotation, rawGyroRot.rotation, smoothing);
    }
    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 120;
        initialYAngle = transform.eulerAngles.y;

        rawGyroRot = new GameObject("GyroRaw").transform;
        rawGyroRot.position = transform.position;
        rawGyroRot.rotation = transform.rotation;

        yield return new WaitForSeconds(1);
        StartCoroutine(CalibrateYAngle());
    }
    private void ApplyGyroRotation()
    {
        rawGyroRot.rotation = Input.gyro.attitude;
        rawGyroRot.Rotate(0f, 0f, 180f, Space.Self);
        rawGyroRot.Rotate(90f, 180f, 0f, Space.World);
        appliedGyroYAngle = rawGyroRot.eulerAngles.y; 
    }
    private void ApplyCalibration()
    {
        rawGyroRot.Rotate(0f, -calibrationYAngle, 0f, Space.World);
    }
    private IEnumerator CalibrateYAngle()
    {
        tempSmoothing = smoothing;
        smoothing = 1;
        calibrationYAngle = appliedGyroYAngle - initialYAngle;
        yield return null;
        smoothing = tempSmoothing;
    }
    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
}
