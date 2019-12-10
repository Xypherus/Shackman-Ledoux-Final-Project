using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompleteState : FSMState
{
    public PlayerCompleteState()
    {
        stateID = FSMStateID.PlayerComplete;
    }

    public override void Act(Transform player, GameObject self)
    {
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        Debug.Log("Complete State Reached");
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
    }

    public override void Reason(Transform player, GameObject self)
    {
    }
}
