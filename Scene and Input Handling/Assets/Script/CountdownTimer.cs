using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Cameron Romeis for all

    private float currentTime = 0f;
    [SerializeField] private float startingTime = 10f;

    [SerializeField] private Text countdownText;

    //Keegan Rodriguez-----
    [SerializeField]
    private int m_number = 1;
    //k.r------------------

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        

        if(currentTime <= 0)
        {
            GameStateManager.WinOrLose(m_number);
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
    }
}

