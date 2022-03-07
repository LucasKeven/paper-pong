using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
   public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currentState;
    public Player player;
    public float timeToStartGame = 1f;

    



    // Surgiu no vídeo aos 11:09, e deixei aqui.
    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    /*
    private void StartGame()
    {
        SwitchState(States.MENU);
    }
    */

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(States.PLAYING);                      
        }
        */
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }

    
}
