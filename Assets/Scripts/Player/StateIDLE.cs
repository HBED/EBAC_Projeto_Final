using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class StateIDLE : StateBase
{

    public override void OnStateEnter(object o = null)
    {
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
