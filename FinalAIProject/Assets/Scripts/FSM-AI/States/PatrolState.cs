using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    //basic movement until navmesh is added.
    public PatrolState()
    {
        stateID = FSMStateID.Patrol;

        destination = waypoints[curWaypoint].position;
        
    }

    public override void Act(Transform player, GameObject self)
    {
        if(Vector2.Distance(self.transform.position, destination) <= 0.5f)
        {
            curWaypoint += 1;
            if (curWaypoint == waypoints.Length){
                curWaypoint = 0;
            }
            destination = waypoints[curWaypoint].position;
        }
        // rotate sprite to look at next desination.
        Quaternion targetRotation = Quaternion.LookRotation(destination - self.transform.position);
        self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        // this moves sprite towards new destination.
        self.transform.Translate(Vector2.up *Time.deltaTime * speed);
    }

    public override void Reason(Transform player, GameObject self)
    {
        if(Vector2.Distance(self.transform.position, player.transform.position) <= 5.0f)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.HeardPlayer); // transitions to Investigate.
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        
    }

    public override void OnStateExit(Transform player, GameObject self)
    {

    }
}
