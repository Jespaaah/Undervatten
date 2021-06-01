using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Restart : MonoBehaviour
{
    public float lossPerSec = 1;
    public float gainPerSec = 30;
    public float currentValue = 1;
    public float maxValue;
    public Image bar;
    public TextMeshProUGUI text;
    public GameObject hand_L,hand_R,G_Text;
    public bool restarting = false;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        currentValue = 0;
        text = G_Text.GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (hand_L.activeSelf == false && hand_R.activeSelf == false) { restarting = true; }
        else { restarting = false; }
        if (restarting) { Increase(); text.enabled = true; }
        if (!restarting) { Decrease(); text.enabled = false; }
        if (currentValue >= maxValue) { GoToMenu(); }
    }
    void Increase()
    {
        currentValue += gainPerSec * Time.deltaTime;
        bar.fillAmount = currentValue / maxValue;
    }
    void Decrease()
    {
        currentValue = 0;
        bar.fillAmount = currentValue / maxValue;

    }
    void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}