using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMove : MonoBehaviour
{
    public Transform rHand;
    public float radius = 1f;
    public LayerMask swimMask;
    public Player_Movement playerMove;


    void Update()
    {
        Vector3 markerDestination = new Vector3(rHand.position.x, rHand.position.y, 0);
        transform.position = markerDestination;
    }

    private void FixedUpdate()
    {
        playerMove.swim = Physics.CheckSphere(transform.position, radius, swimMask) ? false : true;
    }
}
