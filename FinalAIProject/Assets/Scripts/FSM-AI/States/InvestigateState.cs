using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : FSMState
{
    public InvestigateState()
    {
        stateID = FSMStateID.Investigate;
    }

    public override void Act(Transform player, GameObject self)
    {
         Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - self.transform.position);
        self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        // this moves sprite towards the player.
        self.transform.Translate(Vector2.up *Time.deltaTime * speed);
    }

    public override void Reason(Transform player, GameObject self)
    {
        if(Vector2.Distance(player.transform.position, self.transform.position) >= 5.0f)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.FoundNothing);
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {

    }

    public override void OnStateExit(Transform player, GameObject self)
    {

    }
}
