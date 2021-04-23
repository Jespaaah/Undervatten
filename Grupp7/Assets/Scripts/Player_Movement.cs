using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float speed;
    public Rigidbody rb;
    public Vector3 dir;
    public LayerMask move;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,move))
        {
            Debug.Log("Background hit");
            //Quaternion lookRotation = Quaternion.LookRotation(dir);
            
            dir = hit.point - transform.position;
            dir.Normalize();
            
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
    private void FixedUpdate()
    {
        Move(dir);
    }
    public void Move(Vector3 dir)
    {
        Vector3 realDir = new Vector3(dir.x,dir.y,0);
        rb.AddForce(realDir * speed * Time.fixedDeltaTime,ForceMode.VelocityChange);
    }
}
