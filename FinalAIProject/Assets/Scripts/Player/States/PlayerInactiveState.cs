using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInactiveState : FSMState
{
    //This state is basicly just an idle state
    private PlayerController playerController;

    public PlayerInactiveState(PlayerController player)
    {
        stateID = FSMStateID.PlayerInactive;
        playerController = player;
    }

    public override void Act(Transform player, GameObject self)
    {
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        Debug.Log("PlayerInactiveState Start");
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        playerController.setNextStep();
    }

    public override void Reason(Transform player, GameObject self)
    {
        //Debug.Log("A");
        if (playerController.playerActive)
        {
            Debug.Log("Player Activating");
            playerController.SetTransition(FSMTransitions.PlayerActivated);
        }
    }
}
