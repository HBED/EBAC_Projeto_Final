using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class StateJUMP : StateBase
{

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        Debug.Log("Entrou em JUMP");
    }

    public override void OnStateStay()
    {
        Debug.Log("Está em JUMP");

    }

    public override void OnStateExit()
    {
        Debug.Log("Saiu de JUMP");
    }
}
