using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : FSMState
{
    private PlayerController playerController;

    public PlayerWaitState(PlayerController player)
    {
        stateID = FSMStateID.PlayerWait;
        playerController = player;
    }

    public override void Act(Transform player, GameObject self)
    {

    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        playerController.startDelay(playerController.currentAction.waitTime);
        playerController.setVisability(false);
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        playerController.setVisability(true);
    }

    public override void Reason(Transform player, GameObject self)
    {
        if(!playerController.isCurrentlyWaiting)
        {
            playerController.SetTransition(FSMTransitions.PlayerDoneWaiting);
        }
    }
}
