using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class PlayerSM : MonoBehaviour
{
    public enum GameStates
    {
        IDLE,
        RUN,
        JUMP
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.IDLE, new StateIDLE());
        stateMachine.RegisterStates(GameStates.RUN, new StateRUN());
        stateMachine.RegisterStates(GameStates.JUMP, new StateJUMP());
    }

    private void Update()
    {
        stateMachine.UpdateState();
    }



}
