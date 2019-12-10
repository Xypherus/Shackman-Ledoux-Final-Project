using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : FSMState
{
    private PlayerController playerController;

    public PlayerMoveState(PlayerController player)
    {
        stateID = FSMStateID.PlayerMove;
        playerController = player;
    }

    public override void Act(Transform player, GameObject self)
    {
        
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        playerController.agent.SetDestination(playerController.currentAction.destinationPoint);
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        playerController.agent.Stop();
    }

    public override void Reason(Transform player, GameObject self)
    {
        if(playerController.agent.remainingDistance <= .1f)
        {
            playerController.SetTransition(FSMTransitions.PlayerDoneMoving);
        }
    }
}
