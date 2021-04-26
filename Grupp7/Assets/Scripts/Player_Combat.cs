using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform MouthPosition;
    public float EatRadius = 5;
    public LayerMask edible;
    public GameObject scoreManager;
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
            scoreManager.GetComponent<ScoreManager>().IncreaseScore();
            scoreManager.GetComponent<ScoreManager>().CheckScore();
        } 
        
    }
}
