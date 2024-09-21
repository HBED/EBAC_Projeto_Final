using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class StateIDLE : StateBase
{

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        Debug.Log("Entrou em IDLE");
    }

    public override void OnStateStay()
    {
        Debug.Log("Está em IDLE");
    }

    public override void OnStateExit()
    {
        Debug.Log("Saiu de IDLE");
    }
}
