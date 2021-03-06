using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    // keegan r. Princess when both players enter triggers gameover win  or next level (K.R.)

    // string variable used to insert tags for players to check if tag is equal to the player tags (K.R.)
    [SerializeField]
    private string m_PlayerOneTag;
    [SerializeField]
    private string m_PlayerTwoTag;
    [SerializeField]
    private string m_GoalTag;
    //used to determine wether its win(0), lost(1) or final win(2) (0, 1, 2)
    [SerializeField]
    private static int m_Number = 0;

    // used to ensure both players made it to save princess to go to next level or win the entire game (K.R.)
    private bool m_PlayerOneTrigger;
    private bool m_PlayerTwoTrigger;
    private bool m_GoalTagTrigger;


    void Start()
    {
        m_PlayerOneTrigger = false;
        m_PlayerTwoTrigger = false;
        m_GoalTagTrigger = false;

        if(this.tag == "Level2")
        {
            m_Number = 2;
        }
        if (this.tag == "Level1")
        {
            m_Number = 0;
        }
    }

    // Update is called once per frame and checks if both variables are true to initiate the princess sae to win (K.R.)
    void Update()
    {
        if(m_PlayerOneTrigger == true && m_PlayerTwoTrigger == true && m_GoalTagTrigger == true)
        {
            Debug.Log("Saved pt1");
            PrincessSaved();
        }
    }

    //confirms if object (colling) triggering is either player one or two (K.R.)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggering with princess");
        if (collision.tag == m_PlayerOneTag)
        {
            Debug.Log("player one");
            m_PlayerOneTrigger = true;

        }

        if (collision.tag == m_PlayerTwoTag)
        {
            Debug.Log("player two");
            m_PlayerTwoTrigger = true;

        }

        if (collision.tag == m_GoalTag)
        {
            Debug.Log("goal two");
            m_GoalTagTrigger = true;

        }
    }

    //calls win or lose with parameter of 0 to initate game over with win sound (K.R.)
    private static void PrincessSaved()
    {
        Debug.Log("Saved pt2");
        //winorlose will check if there is another level or gameover (win) (K.R.)
        GameStateManager.WinOrLose(m_Number); 
       
    }

    //keegan r. ---------------------------------------------------------------

}
