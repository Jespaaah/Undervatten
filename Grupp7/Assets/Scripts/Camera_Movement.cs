using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float speed = 1;
    public Transform cameraTarget;
    public Transform cam;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = Vector3.Lerp(transform.position, cameraTarget.position, speed * Time.deltaTime);
    }
    public void ZoomOut()
    {
        cam.localPosition += offset;
    }   
}
