using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
    
{
    public LayerMask marker;
    public float fillSpeed = 1;
    public float currentValue = 0;
    public float maxValue = 100;
    public Image image;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        currentValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){Fill();}
        if(!active){Empty();}
        image.fillAmount = currentValue / maxValue;
        if(currentValue >= maxValue){StartGame();}    
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Fill()
    {
        Debug.Log("Filling");
        currentValue += fillSpeed * Time.deltaTime;
    }
    public void Empty()
    {
        Debug.Log("Emptying");
        currentValue = 0;
    }
    private void OnTriggerStay(Collider other)
    {
      
        if(other.gameObject.tag == "Marker")
        {
            Debug.Log(other.name);
            active = true;
        }
        else { active = false; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Marker")
        {
            active = false;
        }
    }
}
