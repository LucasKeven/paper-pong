using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;

    //public StateMachine stateMachine;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public StateMachine stateMachine;

    public Player[] players;

    [Header("Menus")]
    public GameObject uiMainMenu;

    private void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<Player>();
    }

    /* Sumiu no vídeo aos 11:09, mas deixei aqui.
    public void SwitchStateReset()
    {
        stateMachine.ResetPosition();
    }
    */


    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }
    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
