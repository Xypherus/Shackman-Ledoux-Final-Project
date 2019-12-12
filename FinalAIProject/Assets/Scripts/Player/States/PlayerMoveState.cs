using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : FSMState
{
    private PlayerController playerController;

    private float timer = 0.0f;
    private float increments = 1.5f;
    private float makenoise;

    public PlayerMoveState(PlayerController player)
    {
        stateID = FSMStateID.PlayerMove;
        playerController = player;
    }

    public override void Act(Transform player, GameObject self)
    {
        timer += Time.deltaTime;
        if(timer >= makenoise)
        {
            player.GetComponent<PlayerController>().makingNoise = true;
            makenoise = timer + increments;
        }
        else
        {
            player.GetComponent<PlayerController>().makingNoise = false;
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        playerController.agent.SetDestination(playerController.currentAction.destinationPoint);
        makenoise = timer + increments;
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        player.GetComponent<PlayerController>().makingNoise = false;
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
