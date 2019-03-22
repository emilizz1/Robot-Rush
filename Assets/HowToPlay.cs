using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject gameName;
    [SerializeField] GameObject howToPlayText;
    
    void Start()
    {
        howToPlayText.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        gameName.SetActive(false);
        howToPlayText.SetActive(true);
    }
}
