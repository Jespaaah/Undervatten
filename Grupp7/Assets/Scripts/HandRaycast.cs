using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine;

public class HandRaycast : MonoBehaviour
{

    Hand leapHand;
    FingerModel finger;
    HandModel handModel;
    public RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        handModel = GetComponent<HandModel>();
        leapHand = handModel.GetLeapHand();
        if (leapHand == null) Debug.LogError("No leap_hand founded");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        finger = handModel.fingers[1];

        if (Physics.Raycast(finger.GetTipPosition(), fwd, out hit))
        {
            float distanceToGround = hit.distance;
            Debug.Log("hit something" + distanceToGround);
        }
        Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red, Time.deltaTime, true);
    }
}