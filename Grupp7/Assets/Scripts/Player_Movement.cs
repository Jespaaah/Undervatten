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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,100000, move,QueryTriggerInteraction.Collide))
        {
            if (hit.collider.tag == "noMove")
            {
                swim = false;
            }
            else
            {
                Debug.Log("Background hit");
                Debug.Log(hit.collider.gameObject.name);
                dir = hit.point - transform.position;
                dir.Normalize();
                swim = true;
            }
           
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        else { swim = false; }
    }
    private void FixedUpdate()
    {
        if (swim){Move(dir);}
    }
    public void Move(Vector3 dir)
    {
        Vector3 realDir = new Vector3(dir.x,dir.y,0);
       transform.rotation = Quaternion.LookRotation(realDir);

        rb.AddForce(realDir * scoremanager.GetComponent<ScoreManager>().currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
