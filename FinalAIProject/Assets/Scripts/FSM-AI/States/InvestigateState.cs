using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : FSMState
{

    private Enemy enemyController;
    public InvestigateState(Enemy enemy)
    {
        stateID = FSMStateID.Investigate;

        enemyController = enemy;
    }

    public override void Act(Transform player, GameObject self)
    {
        self.transform.eulerAngles = new Vector3(0, 0, self.transform.eulerAngles.z);

    }

    public override void Reason(Transform player, GameObject self)
    {
        
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {

    }

    public override void OnStateExit(Transform player, GameObject self)
    {

    }
}
