using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float speed = 1;
    public Transform cameraTarget;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3.Lerp(transform.position, cameraTarget.position, speed * Time.deltaTime);
    }
   
}
