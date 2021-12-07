using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

    public void OnClickNewGame()
    {
        GameStateManager.NewGame();
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
