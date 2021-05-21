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
    public bool inSea = true;
    public Transform marker;
    public Transform seaSurface;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= seaSurface.transform.position.y){inSea = false;}
        else{inSea = true;}
        if(swim) {dir = marker.position - transform.position; dir.Normalize();}
        if (!inSea) { rb.isKinematic = false; rb.useGravity = true; }
    }
    private void FixedUpdate()
    {
        if (swim && inSea){Move(dir);}
    }
    public void Move(Vector3 dir)
    {
       Vector3 realDir = new Vector3(dir.x,dir.y,0);
       rb.rotation = Quaternion.LookRotation(realDir);

        rb.AddForce(realDir.normalized * scoremanager.GetComponent<ScoreManager>().currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
