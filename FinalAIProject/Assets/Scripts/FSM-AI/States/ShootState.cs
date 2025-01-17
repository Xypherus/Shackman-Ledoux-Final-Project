﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : FSMState
{

    protected float timer = 0.0f;

    public float killTimeIncrement = 1.5f;
    protected float killTime;
    private GameObject getPlayer;
    public ShootState()
    {
        stateID = FSMStateID.Shoot;
    }

    public override void Act(Transform player, GameObject self)
    {
        //self.transform.eulerAngles = new Vector3(0,0, player.transform.position.z - self.transform.position.z);
        Vector3 dir = player.position - self.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        self.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

        timer += Time.deltaTime;
        if (timer >= killTime)
        {
            getPlayer.GetComponent<PlayerController>().TakeShot();
        }
        if (self.GetComponent<Enemy>().seePlayer == false)
        {
            self.GetComponent<Enemy>().playernoiseLocation = player.position;
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
        killTime = timer + killTimeIncrement;

        player.gameObject.GetComponentInChildren<Animator>().SetBool("IsGettingShot", true);
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        timer = 0.0f;
        self.GetComponent<Enemy>().playernoiseLocation = player.transform.position;
        player.gameObject.GetComponentInChildren<Animator>().SetBool("IsGettingShot", false);
    }


}
