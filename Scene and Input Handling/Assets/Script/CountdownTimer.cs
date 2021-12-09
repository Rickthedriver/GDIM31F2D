using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Cameron Romeis

    private float currentTime = 0f;
    [SerializeField] private float startingTime = 10f;

    [SerializeField] private Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            GameStateManager.NewGame();
        }
    }
}

