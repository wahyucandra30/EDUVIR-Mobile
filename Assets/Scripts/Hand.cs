using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))] 
public class Hand : MonoBehaviour
{
    [SerializeField] private float animationSpeed;
    private Animator animator;
    private SkinnedMeshRenderer mesh;
    private float gripTarget, triggerTarget,gripCurrent,triggerCurrent;
    private const string animatorGripParam = "Grip";
    private const string animatorTriggerParam = "Trigger"; 
    private static readonly int Grip = Animator.StringToHash(animatorGripParam);
    private static readonly int Trigger = Animator.StringToHash(animatorTriggerParam);

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        //animation
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        //Physics movement
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        //Teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        AnimateHand();
        PhysicsMove(); 
    }

    private void PhysicsMove()
    {
        //position
        var positionWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);


        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    }

    internal void SetTrigger(float v) 
    {
        triggerTarget = v;
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    void AnimateHand()
    {
        if(gripCurrent!= gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent!= triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }
    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
