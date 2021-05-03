using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float speed = 1;
    public Transform cameraTarget;
    public Transform cam;
    public Vector3 offset,temp;
    public float lerpSpeed = 1;
    public bool zoomOut = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, speed * Time.deltaTime);
       
        if (zoomOut) { cam.localPosition = Vector3.Lerp(cam.localPosition, temp, lerpSpeed * Time.deltaTime); }
    }
    public void ZoomOut()
    {
        temp = cam.localPosition += offset;
        zoomOut = true;

    }   
}
