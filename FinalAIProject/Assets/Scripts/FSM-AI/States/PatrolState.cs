using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    //basic movement until navmesh is added.
    public List<Vector2> waypoints;
    public PatrolState()
    {
        stateID = FSMStateID.Patrol;

        
        
    }

    public override void Act(Transform player, GameObject self)
    {
        
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
