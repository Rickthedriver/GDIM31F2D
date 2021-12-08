using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    //objects/message
    [SerializeField]
    private GameObject m_GameOver;
    [SerializeField]
    private GameObject m_LevelComplete;
    [SerializeField]
    private GameObject m_YouWin;
  
    [SerializeField]
    private float m_MessageTime = 5f;

    //delegates (message control ui) (K.R.)
    public delegate IEnumerator GameOverDelegate();
    public delegate IEnumerator LevelCompleteDelegate();
    public delegate IEnumerator YouWinDelegate();


    // Start is called before the first frame update (K.R.)
    void Start()
    {
        GameStateManager.OnGameOver += OnGamerOver;
        GameStateManager.OnLevelComplete += OnLevelComplete;
        GameStateManager.OnYouWin += OnYouWin;
    }

    //(K.R.)
    private IEnumerator OnGamerOver()
    {
        yield return StartCoroutine(ShowMessage(m_GameOver));
    }
    //(K.R.)
    private IEnumerator OnLevelComplete()
    {
        yield return StartCoroutine(ShowMessage(m_LevelComplete));
    }
    //(K.R.)
    private IEnumerator OnYouWin()
    {
        yield return StartCoroutine(ShowMessage(m_YouWin));
    }



    //controls time message is shown/also buttons (K.R.)

    private IEnumerator ShowMessage(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(m_MessageTime);
        
    }

    //button to call nextlevel after completing level (K.R.)
    public void OnClickNext()
    {
        Debug.Log("pressed next btn");
        GameStateManager.NextLevel();
    }

    //button to call next after gameover (K.R.)
    public void OnClickYouWin()
    {
        Debug.Log("pressed you win btn");
        GameStateManager.NextLevel();
    }
    //(K.R.)----------------

}
