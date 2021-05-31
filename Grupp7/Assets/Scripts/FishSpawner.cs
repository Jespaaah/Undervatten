using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish,fishCounter;
    public float cooldown;
    public float time,currentTime,desiredTime;
    public FishCounter FS;
    // Start is called before the first frame update
    void Start()
    {
        FS = fishCounter.GetComponent<FishCounter>();
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (time >= desiredTime && FS.amountOfFishAlive < FS.maxAmountOfFishAlive ) 
        { 
            Instantiate(fish,transform.position,transform.rotation);
            FS.AddFish();
            Timer();
        }
    }
public void Timer()
    {
        currentTime = Time.time;
        desiredTime = currentTime + cooldown;

    }
}
