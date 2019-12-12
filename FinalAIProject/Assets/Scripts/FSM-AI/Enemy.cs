using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

public class Enemy : BaseEnemy
{

    public Transform[] waypoints;

    public bool seePlayer = false;

    public bool heardPlayer = false;

    public Vector2 playernoiseLocation;

    public PolyNavAgent agent { get; private set; }

    public int curWaypoint = 0;

    protected override void Initalize()
    {
        //currentHealth = initalHealth;

        BuildFSM();

        agent = gameObject.GetComponent<PolyNavAgent>();
    }

    protected override void FSMFixedUpdate()
    {
        transform.eulerAngles = new Vector3(0,0, transform.eulerAngles.z);
    }

    protected override void BuildFSM()
    {
        //Other States Here

        PatrolState patrol = new PatrolState(this);
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

        DeadState dead = new DeadState();

        AddFSMState(dead);
    }
}
