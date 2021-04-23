using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform MouthPosition;
    public float EatRadius = 5;
    public LayerMask edible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Collider col in Physics.OverlapSphere(MouthPosition.position, EatRadius, edible))
        {
            Destroy(col.gameObject);
        } 
        
    }
}
