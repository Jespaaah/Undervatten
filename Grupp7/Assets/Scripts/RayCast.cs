using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform cam;
    public float rayLength = 100;
    public Button button;
    public LayerMask buttonLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.position - cam.position;
        RaycastHit hit;
        if(Physics.Raycast(cam.position,dir,out hit, rayLength,buttonLayer))
        {
            button.active = true;
        }
        else
        {
            button.active = false;
        }
    }
}
