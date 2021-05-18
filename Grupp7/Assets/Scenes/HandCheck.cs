using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HandCheck : MonoBehaviour
{
    public GameObject hand_L, hand_R;
    void Update()
    {
        if (hand_L.activeSelf == false && hand_R.activeSelf == false){ SceneManager.LoadScene(0);}
    }
}
