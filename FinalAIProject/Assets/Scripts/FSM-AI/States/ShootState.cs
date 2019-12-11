using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : FSMState
{

    protected float timer = 0.0f;

    public float killTimeIncrement = 1.5f;
    protected float killTime = 1000.0f;
    private GameObject getPlayer;
    public ShootState()
    {
        stateID = FSMStateID.Shoot;
    }

    public override void Act(Transform player, GameObject self)
    {
        timer += Time.deltaTime;
        if (timer >= killTime)
        {
            getPlayer.GetComponent<PlayerController>().TakeShot();
        }
        if(self.GetComponent<Enemy>().seePlayer == false)
        {
            
        }
    }

    public override void Reason(Transform player, GameObject self)
    {
        if (self.GetComponent<Enemy>().seePlayer == false)
        {
            self.GetComponent<BaseEnemy>().SetTransition(FSMTransitions.PlayerOutOfRange); //if seen, move to shoot.
        }
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        getPlayer = GameObject.FindGameObjectWithTag("Player");
        killTime += killTimeIncrement;
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        killTime = 1000.0f;
    }

    
}
