using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    
    public Animator animator;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Popup", false);
        layerMask = LayerMask.GetMask("Edible");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            animator.SetBool("Popup", true);
            
        }
        
    }
}
