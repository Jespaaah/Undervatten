using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int amountOfFishAlive;
    public int maxAmountOfFishAlive = 10;
   

   public void AddFish()
    {
        amountOfFishAlive += 1;
    }

}
