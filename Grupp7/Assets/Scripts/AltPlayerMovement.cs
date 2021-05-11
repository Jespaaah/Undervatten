using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour
{
    public Vector3 dir;
    public Rigidbody rb;
    public float speed = 10;
    public bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, v, 0);
        if (dir.x == 0 && dir.y ==0) { move = false; }
        else { move = true; }
    }
    private void FixedUpdate()
    {
        if (move)
        {
            rb.AddForce(dir * speed * Time.fixedDeltaTime,ForceMode.VelocityChange);
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
