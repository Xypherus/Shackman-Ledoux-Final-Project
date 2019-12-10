using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDecideState : FSMState
{
    private PlayerController playerController;
    private bool willContinue;

    public PlayerDecideState(PlayerController player)
    {
        stateID = FSMStateID.PlayerDecide;
        playerController = player;
    }

    public override void Act(Transform player, GameObject self)
    {
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        willContinue = playerController.setNextStep();
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
    }

    public override void Reason(Transform player, GameObject self)
    {
        if (willContinue) { playerController.SetTransition(FSMTransitions.PlayerMoreStepsFound); }
        else { playerController.SetTransition(FSMTransitions.PlayerNoStepsFound); }
    }
}
