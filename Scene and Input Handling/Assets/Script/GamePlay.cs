using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{

    [SerializeField] private string SceneName;

    public void OnClickNewGame()
    {
        GameStateManager.NewGame();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
