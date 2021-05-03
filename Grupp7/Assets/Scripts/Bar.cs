using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float lossPerSec = 1;
    public float currentValue = 1;
    public float maxValue;
    public Image bar;
    public bool submerged = true;
    public Transform surface, player;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        currentValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < surface.position.y) { submerged = true; }
        else { submerged = false; }
        if (!submerged) { Increase(); }
        if (submerged) { Decrease(); }
    }
   void Increase()
    {
        currentValue += lossPerSec * Time.deltaTime;
        bar.fillAmount = currentValue / maxValue;
    } 
    void Decrease()
    {
        currentValue -= lossPerSec * Time.deltaTime;
        bar.fillAmount = currentValue / maxValue;
    }
}
