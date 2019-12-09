using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : FSMState
{
    public ShootState()
    {
        stateID = FSMStateID.Shoot;
    }

    public override void Act(Transform player, GameObject self)
    {
        
    }

    public override void Reason(Transform player, GameObject self)
    {
        //Can Never Leave DeadState - No Transitions
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {

    }

    public override void OnStateExit(Transform player, GameObject self)
    {

    }

    
}
