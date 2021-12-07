using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private List<string> m_levels = new List<string>();
    [SerializeField]
    private string m_TitleSceneName;


    private static GameStateManager _instance;


    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }
    private static GAMESTATE m_state;

    /*
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestoryLoad(_instance);
        }
    }
    */

    public static void NewGame()
    {
        //m_state = GAMESTATE.PLAYING;
        //if (_instance.m_levels.Count > 0)
        //{
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene(_instance.m_levels[0]);
        SceneManager.LoadScene("TheGameScene");
       // }
    }

    public static void Title()
    {
        m_state = GAMESTATE.MENU;
        SceneManager.LoadScene(_instance.m_TitleSceneName);
    }

    public static void TogglePause()
    {
        if(m_state == GAMESTATE.PLAYING)
        {
            m_state = GAMESTATE.PAUSED;
            Time.timeScale = 0;
        }
        else if(m_state == GAMESTATE.PAUSED)
        {
            m_state = GAMESTATE.PLAYING;
            Time.timeScale = 1; 
        }


    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.TogglePause();
        }
    }


}
