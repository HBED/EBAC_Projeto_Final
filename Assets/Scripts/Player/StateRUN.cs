using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class StateRUN : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        Debug.Log("Entrou em RUN");
    }

    public override void OnStateStay()
    {
        Debug.Log("Está em RUN");
    }

    public override void OnStateExit()
    {
        Debug.Log("Saiu de RUN");
    }
}
