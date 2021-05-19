using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;
    public float cooldown;
    public float time,currentTime,desiredTime;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (time >= desiredTime ) { Instantiate(fish,transform.position,transform.rotation); Timer(); }
    }
public void Timer()
    {
        currentTime = Time.time;
        desiredTime = currentTime + cooldown;

    }
}
