﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{


    private Enemy enemyController;
    //basic movement until navmesh is added.
    public PatrolState(Enemy enemy)
    {
        stateID = FSMStateID.Patrol;

        enemyController = enemy;
    }

    public override void Act(Transform player, GameObject self)
    {
        self.transform.eulerAngles = new Vector3(0, 0, self.transform.eulerAngles.z);
        if (enemyController.agent.remainingDistance <= 0.1f)
        {
            enemyController.curWaypoint += 1;
            if (enemyController.curWaypoint == enemyController.waypoints.Length)
            {
                enemyController.curWaypoint = 0;
            }
            enemyController.agent.SetDestination(enemyController.waypoints[enemyController.curWaypoint].position);
        }
    }

    public override void Reason(Transform player, GameObject self)
    {
        //Debug.Log("In Patrol Reason");
        if (enemyController.seePlayer == true)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.SawPlayer); //if seen, move to shoot.S
        }
        if(enemyController.heardPlayer == true)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.HeardPlayer);
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        enemyController.agent.SetDestination(enemyController.waypoints[enemyController.curWaypoint].position);
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        enemyController.agent.Stop();
    }
}
