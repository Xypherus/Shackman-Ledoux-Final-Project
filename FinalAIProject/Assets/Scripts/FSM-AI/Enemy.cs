using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{

    float moveSpeed = 2.0f;
    protected override void BuildFSM()
    {
        //Other States Here

        DeadState dead = new DeadState();

        AddFSMState(dead);

        PatrolState patrol = new PatrolState();
        patrol.AddTransitionState(FSMStateID.Investigate, FSMTransitions.HeardPlayer);
        patrol.AddTransitionState(FSMStateID.Shoot, FSMTransitions.SawPlayer);
        AddFSMState(patrol);

        InvestigateState investigate = new InvestigateState();
        investigate.AddTransitionState(FSMStateID.Patrol, FSMTransitions.FoundNothing);
        investigate.AddTransitionState(FSMStateID.Shoot, FSMTransitions.SawPlayer);
        AddFSMState(investigate);

        ShootState shoot = new ShootState();
        shoot.AddTransitionState(FSMStateID.Investigate, FSMTransitions.PlayerOutOfRange);
        AddFSMState(shoot);
    }
}
