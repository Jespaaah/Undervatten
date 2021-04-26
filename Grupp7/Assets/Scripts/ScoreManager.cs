using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int ThresholdScore;
    public bool small, medium, big;
    public GameObject player;
    public TextMeshProUGUI text;
    public AudioSource audioSource;
    [Header("Small")]
    public float smallSpeed;
    public float smallSize;
    public string smallText;
    public AudioClip smallNarration;
    [Header("Medium")]
    public float mediumSpeed;
    public float mediumSize;
    public string mediumText;
    public AudioClip mediumNarration;
    [Header("Big")]
    public float bigSpeed;
    public float bigSize;
    public string bigText;
    public AudioClip bigNarration;
    [Header("Current parameters")]
    public float currentSpeed;
    public float currentSize;
    public string currentText;
    public AudioClip currentNarration;
   
    
    // Start is called before the first frame update

    void Start()
    {
        ThresholdScore = score + ThresholdScore;
        small = true;
        text = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckScore()
    {
        if(score == ThresholdScore)
        {
            ThresholdScore = score + ThresholdScore;
            Debug.Log("You became bigger");
            if (small && !big)
            {
                medium = true;
                small = false;
            }
            if (!small && !big)
            {
                big = true;
            }
            LevelUp();
        }
    }
    public void LevelUp()
    {
        currentSpeed = GetSpeed();
        currentSize = GetSize();
        currentText = GetText();
        currentNarration = GetNarration();

        player.transform.localScale = new Vector3(currentSize,currentSize,currentSize);
        text.text = currentText;
        audioSource.clip = currentNarration;
        audioSource.Play();
    }
    public void IncreaseScore() 
    {
        score += 1;
    }
    public float GetSpeed()
    {
        if (small) { return smallSpeed; }
        if (medium) { return mediumSpeed; }
        if(big) { return bigSpeed; }
        else { return 0;}
    }
    public float GetSize()
    {
        if (small) { return smallSize; }
        if (medium) { return mediumSize; }
        if (big) { return bigSize; }
        else { return 0; }
    }
    public string GetText()
    {
        if (small) { return smallText; }
        if (medium) { return mediumText; }
        if (big) { return bigText; }
        else { return null; }
    }
    public AudioClip GetNarration()
    {
        if (small) { return smallNarration; }
        if (medium) { return mediumNarration; }
        if (big) { return bigNarration; }
        else { return null; }
    }
}
