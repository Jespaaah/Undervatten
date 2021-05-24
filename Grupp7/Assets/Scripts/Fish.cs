using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 100;
    public float detectionRadius = 10;
    public LayerMask fishDetectionLayer;
    public Vector3 runAwayDir;
    public bool swimAway = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] mososaurus = Physics.OverlapSphere(transform.position, detectionRadius, fishDetectionLayer,QueryTriggerInteraction.Collide);
        
          foreach (Collider col in mososaurus)
            {
            runAwayDir = transform.position - col.transform.position;
            runAwayDir.Normalize();
            swimAway = true;
            }
        if (mososaurus == null) { swimAway = false; }
    }
    private void FixedUpdate()
    {
        if (swimAway) { SwimAway(); }
        transform.rotation = Quaternion.LookRotation(runAwayDir);
    }
    public void SwimAway()
    {
        rb.AddForce(runAwayDir * speed * Time.fixedDeltaTime,ForceMode.VelocityChange);
    }
}
