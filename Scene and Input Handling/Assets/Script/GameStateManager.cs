using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    //--keegan R. [Lose sound]---------------------------

    [SerializeField]
    private AudioClip m_LoseSound;
    [SerializeField]
    private AudioClip m_WinSound;
    [SerializeField]
    private AudioSource m_AudioSource;

    //used to call the scence for each level (1 or 2) (K.R.)
    [SerializeField]
    private string m_LevelSceneName;
    [SerializeField]
    private string m_Level2SceneName;


    //--Keegan R.----------------------------------------^

    [SerializeField]
    private List<string> m_levels = new List<string>();
    [SerializeField]
    private string m_TitleSceneName;


    private static GameStateManager _instance;

    //K.R for InGameUI
    public static InGameUI.GameOverDelegate OnGameOver;
    public static InGameUI.LevelCompleteDelegate OnLevelComplete;
    public static InGameUI.YouWinDelegate OnYouWin;

    //Cameron Romeis

    [SerializeField] private GameObject pauseMenuUI;

    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        WIN,
        WIN2,
        LOSE,
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

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void NewGame()
    {
        //m_state = GAMESTATE.PLAYING;
        //if (_instance.m_levels.Count > 0)
        //{
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene(_instance.m_levels[0]);
        SceneManager.LoadScene(_instance.m_LevelSceneName);
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
            Time.timeScale = 0f;
            
        }
        else if(m_state == GAMESTATE.PAUSED)
        {
            m_state = GAMESTATE.PLAYING;
            Time.timeScale = 1f;
        }


    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.TogglePause();
        }
    }

    //Keegan R. GameOver/Sound----------------

    // when time runs out or goal is achieved this is called and gamestate is changed to activate (K.R.)
    // the right gameover (K.R.)

    public static void GameOver()
    {
        //checks if checks gamestate (win or lose) prompts players with sound/Message/buttons (K.R.)

        if (m_state == GAMESTATE.LOSE)
        {
            //will play sound and activate ui to show before change of scnene (K.R.)
            _instance.m_AudioSource.PlayOneShot(_instance.m_LoseSound);
            _instance.StartCoroutine(_instance.GameOverRoutine());

        }
        else if (m_state == GAMESTATE.WIN)
        {
            //will play sound and activate ui to show before change of scnene (K.R.)
            _instance.m_AudioSource.PlayOneShot(_instance.m_WinSound);
            _instance.StartCoroutine(_instance.LevelCompleteRoutine());


        }else if (m_state == GAMESTATE.WIN2)
        {
            _instance.m_AudioSource.PlayOneShot(_instance.m_WinSound);
            _instance.StartCoroutine(_instance.YouWinRoutine());
        }


    }

    //used by button to go to the next scene once level is completed/won (K.R.)
    public static void NextLevel()
    {
        //will be called before changed to the main menu or nextlevel (K.R.)
        //checks whether you are in level one or two to know whats the next scence also gamestate (K.R.)
        if (m_state == GAMESTATE.WIN)
        {
            SceneManager.LoadScene(_instance.m_Level2SceneName);
        }
        else if (m_state == GAMESTATE.LOSE)
        {
            GameStateManager.Title();
        }else if(m_state == GAMESTATE.WIN2)
        {
            //after level 2 is completed
            GameStateManager.Title();
        }

    }

    //checks if level wass complete or failed and calls gameover sets gamestate (lose or win)
    public static void WinOrLose(int number)
    {
        if (number == 1)
        {
            m_state = GAMESTATE.LOSE;
            GameStateManager.GameOver();

        }
        else if (number == 0)
        {
            m_state = GAMESTATE.WIN;
            GameStateManager.GameOver();
        }
        else if (number == 2)
        {
            m_state = GAMESTATE.WIN2;
            GameStateManager.GameOver();
        }

    }
    //Keegan R. ------------------------------

    private IEnumerator GameOverRoutine()
    {
        yield return OnGameOver();
    }
    private IEnumerator LevelCompleteRoutine()
    {
        yield return OnLevelComplete();
    }

    private IEnumerator YouWinRoutine()
    {
        yield return OnYouWin();
    }

}
