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
    public GameObject scoremanager;
    public bool swim = false;
    public Transform marker;
    public Transform seaSurface;
    public bool InSea = true;
    public bool surfaceBool = false;
    public float fallSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(swim){dir = marker.position - transform.position;}
        if (transform.position.y >= seaSurface.position.y) { InSea = false; }
        if (transform.position.y >= seaSurface.position.y ) 
        {
            InSea = false;
        }
        if (transform.position.y < seaSurface.position.y)
        {
            InSea = true;
        }
    }
    private void FixedUpdate()
    {
        if (swim && InSea){Move(dir);}
        if (!InSea) { Fall(); }
    }
    public void Move(Vector3 dir)
    {
       Vector3 realDir = new Vector3(dir.x,dir.y,0);
       transform.rotation = Quaternion.LookRotation(realDir);

        rb.AddForce(realDir * scoremanager.GetComponent<ScoreManager>().currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
    void Fall()
    {
        Debug.Log("Falling");
        rb.AddForce(Vector3.down * fallSpeed);
        Vector3 realDir = new Vector3(dir.x, dir.y, 0);
        transform.rotation = Quaternion.LookRotation(realDir);
    }
}
