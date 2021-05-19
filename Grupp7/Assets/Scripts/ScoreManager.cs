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
    public int currentLevel = 0;
    public int maxLevel;
    public GameObject player,cam;
    public GameObject textfield;
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
    public Transform hands;
    public Vector3 handScaleAtStart;
   
    
    // Start is called before the first frame update

    void Start()
    {
        ThresholdScore = score + ThresholdScore;
        small = true;
        text = textfield.GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        handScaleAtStart = hands.localScale;
        LevelUp();
    }
   
    public void CheckScore()
    {
        
        if(score == ThresholdScore && currentLevel != maxLevel)
        {
            ThresholdScore = score + ThresholdScore;
            Debug.Log("You became bigger");
            currentLevel += 1;
            if (currentLevel == 1) { small = false; medium = true; }
            if (currentLevel == 2) { medium = false; big = true; }
            
            LevelUp();
        }
    }
    public void LevelUp()
    {
        currentSpeed = GetSpeed();
        currentSize = GetSize();
        hands.localScale = handScaleAtStart * GetSize();
        currentText = GetText();
        currentNarration = GetNarration();

        player.transform.localScale = new Vector3(currentSize,currentSize,currentSize);
        text.text = currentText.ToString();
        audioSource.clip = currentNarration;
        audioSource.Play();
        if (!small) { cam.GetComponent<Camera_Movement>().ZoomOut(); }  
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
