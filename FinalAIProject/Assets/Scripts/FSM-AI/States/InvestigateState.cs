using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : FSMState
{

    private Enemy enemyController;
    private float counter = 0.0f;

    public InvestigateState(Enemy enemy)
    {
        stateID = FSMStateID.Investigate;

        enemyController = enemy;
    }

    public override void Act(Transform player, GameObject self)
    {
        self.transform.eulerAngles = new Vector3(0, 0, self.transform.eulerAngles.z);
        enemyController.agent.SetDestination(enemyController.playernoiseLocation);
        if (enemyController.agent.remainingDistance <= 0.1f && counter < 360)
        {

            self.transform.eulerAngles = new Vector3(0, 0, self.transform.eulerAngles.z + 5);
            counter += 5;
        }
    }

    public override void Reason(Transform player, GameObject self)
    {
        if ( counter >= 360)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.FoundNothing);
        }
        if (enemyController.seePlayer == true)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.SawPlayer); //if seen, move to shoot.S
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {

    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        counter = 0.0f;
    }
}
