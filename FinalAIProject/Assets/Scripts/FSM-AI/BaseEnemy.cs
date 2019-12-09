using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void takeDamage(int damage);
}

public class BaseEnemy : FSM//, IDamageable
{
    //public int initalHealth = 10;
    //public int currentHealth;
    public float rotationSpeed = 5f;
    public float agroDistance = 5f;

    [Tooltip("Raidus at which nearby enemies are activated upon exiting passive state. Set to 0 for no activation")]
    public float activateRaidus = 0f;
    public bool isAwake = false;

    protected override void Initalize()
    {
        //currentHealth = initalHealth;

        BuildFSM();
    }

    protected override void FSMFixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    protected override void FSMUpdate()
    {
        //throw new System.NotImplementedException();
    }

    protected virtual void BuildFSM()
    {
        //Other States Here

        DeadState dead = new DeadState();

        AddFSMState(dead);
    }

    /* public void takeDamage(int damage)
    {
        Debug.Log("Taking Damage");
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, initalHealth);
    } */
}
